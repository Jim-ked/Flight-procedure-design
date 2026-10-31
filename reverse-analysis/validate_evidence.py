"""Read-only validation of inputs; writes only analysis audit outputs."""
from pathlib import Path
import csv, hashlib, json, struct
from datetime import datetime, timezone
from cryptography.hazmat.primitives.ciphers import Cipher, algorithms, modes
from cryptography.hazmat.primitives.padding import PKCS7

ROOT = Path(__file__).resolve().parent
OUT = ROOT / '00_manifest'
def sha(path):
    h = hashlib.sha256()
    with Path(path).open('rb') as stream:
        for chunk in iter(lambda: stream.read(1048576), b''):
            h.update(chunk)
    return h.hexdigest()
def rows(path):
    with path.open(encoding='utf-8-sig', newline='') as stream:
        return list(csv.DictReader(stream))
def dump(name, value):
    (OUT / name).write_text(json.dumps(value, ensure_ascii=False, indent=2), encoding='utf-8')

checks = []
for row in rows(OUT / 'hashes.csv'):
    expected = row['SHA256'].lower()
    for kind, column in [('original', 'OriginalPath'), ('snapshot', 'SnapshotPath')]:
        path = Path(row[column])
        actual = sha(path) if path.is_file() else None
        checks.append(dict(kind=kind, path=str(path), expected=expected, actual=actual, ok=actual == expected))
dump('original-recheck.json', checks)
original = (ROOT / '01_original/WsTools-master/WindSpiral2026/WindSpiralBasic.dll').read_bytes()
key = bytes([28,140,35,220,242,181,128,254,224,127,127,85,26,117,99,60,219,55,207,32,16,227,240,251,98,107,210,152,125,236,124,188])
iv = bytes([23,5,86,220,164,189,42,28,127,65,63,226,210,146,81,145])
strings = json.loads((ROOT / '02_deobfuscated/strings.json').read_text(encoding='utf-8'))
string_checks = []
for row in strings:
    offset = int(row['file_offset'], 16)
    length = struct.unpack_from('<I', original, offset)[0]
    pad = PKCS7(128).padder()
    plaintext = row['value'].encode('utf-16le')
    padded = pad.update(plaintext) + pad.finalize()
    encryptor = Cipher(algorithms.AES(key), modes.CBC(iv)).encryptor()
    ciphertext = encryptor.update(padded) + encryptor.finalize()
    string_checks.append(dict(offset=row['offset'], ok=length == row['cipher_length'] and ciphertext == original[offset+4:offset+4+length]))
dump('string-roundtrip.json', string_checks)
bools = json.loads((ROOT / '02_deobfuscated/booleans.json').read_text(encoding='utf-8'))
bool_ok = all(original[r['original_file_offset']] == r['original_byte'] and r['value'] == (r['original_byte'] == 128) for r in bools)
methods = rows(ROOT / '04_type-map/methods-only/methods.csv')
tokens = {r['token'] for r in methods}
event_checks = []
for r in rows(ROOT / '04_type-map/events.csv'):
    raw = r['handler_tokens']
    # Retain ambiguous/unresolved sites, never silently count them as validated.
    event_checks.append(dict(source=r['source'], line=r['line'], handler=r['handler'], token=raw, unique_valid=raw in tokens))
dump('event-token-check.json', event_checks)
inventory = []
for directory in ['tools', '00_manifest/unpacked']:
    for p in sorted((ROOT / directory).rglob('*')):
        if p.is_file():
            inventory.append(dict(path=str(p.relative_to(ROOT)), bytes=p.stat().st_size, sha256=sha(p)))
dump('derivative-tool-hashes.json', inventory)
summary = dict(timestamp_utc=datetime.now(timezone.utc).isoformat(),
    originals=sum(r['kind']=='original' for r in checks), original_and_snapshot_checks=len(checks),
    hash_failures=sum(not r['ok'] for r in checks), string_roundtrips=len(string_checks),
    string_roundtrip_failures=sum(not r['ok'] for r in string_checks), booleans=len(bools), boolean_provenance_ok=bool_ok,
    direct_event_bindings=len(event_checks), event_unique_tokens=sum(r['unique_valid'] for r in event_checks),
    unresolved_event_tokens=[r for r in event_checks if not r['unique_valid']],
    method_status={status:sum(r['status']==status for r in methods) for status in sorted({r['status'] for r in methods})},
    tool_and_unpacked_files=len(inventory))
dump('validation-summary.json', summary)
print(json.dumps(summary, ensure_ascii=False, indent=2))
assert summary['hash_failures']==0 and summary['string_roundtrip_failures']==0 and bool_ok
