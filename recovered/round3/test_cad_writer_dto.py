"""Writer-independent checks for the recovered B1/B2 plans.

These tests inspect the auditable recovery artifacts; they do not load AutoCAD or
the original DLL and do not claim that the C# carriers compiled.
"""
import csv
from pathlib import Path

ROOT = Path(__file__).parents[1]


def rows(path):
    with path.open(encoding="utf-8-sig", newline="") as f:
        return list(csv.DictReader(f))


def test_entity_order():
    order = rows(ROOT / "round3" / "cad-entity-order.csv")
    b1 = [r["entity_or_group"] for r in order if r["module"] == "B1"]
    assert b1 == ["NominalConnectionDescriptor", "BoundaryList03", "BoundaryList01", "BoundaryList04", "BoundaryList02", "BoundaryList05", "BoundaryGroup02", "SpiralGroup01", "TolerancePolyline"]
    b2 = [r["entity_or_group"] for r in order if r["module"] == "B2"]
    assert b2 == ["NominalConnectionDescriptor", "BoundaryList03", "BoundaryList01", "BoundaryList04", "BoundaryList02", "SpiralGroup01", "TolerancePolyline"]


def test_metadata_and_groups():
    order = rows(ROOT / "round3" / "cad-entity-order.csv")
    for r in order:
        if r["entity_or_group"] in {"BoundaryGroup02", "SpiralGroup01"}:
            assert r["group_membership"] == "true child polylines"
        if r["entity_or_group"] == "TolerancePolyline":
            assert r["xdata"] == "none (metadata omitted)"


def test_exact_literals_and_att_zero_negative():
    b2 = "\n".join((ROOT / "B2-FlyOverDF" / "boundary-vertices.csv").read_text(encoding="utf-8-sig").splitlines())
    assert "12000" in b2 and "13000" in b2
    geometry = (ROOT / "B2-FlyOverDF" / "geometry.md").read_text(encoding="utf-8")
    assert "no equality, epsilon, or `<=0` branch on ATT" in geometry


def test_sw_asymmetry_and_boundary_evidence():
    b1 = (ROOT / "B1-FlyBy" / "boundary-vertices.csv").read_text(encoding="utf-8-sig")
    assert "SW1/2" in b1 and "1.5*width" in ((ROOT / "B1-FlyBy" / "geometry.md").read_text(encoding="utf-8"))
    assert "implementation-basis-to-be-confirmed" in (ROOT / "B1-FlyBy" / "nn-kk-semantic-proof.md").read_text(encoding="utf-8")


if __name__ == "__main__":
    tests = [v for k, v in globals().items() if k.startswith("test_")]
    for test in tests:
        test()
    print(f"PASS {len(tests)} writer-independent Round3 DTO assertions")
