from pathlib import Path
p=Path('recovered/round6/indexes.py');s=p.read_text(encoding='utf-8').replace('round6','round7').replace('B3-RnpApch','B4-PbnIls').replace('B3 core','B4 core')
a=s.index("cls=[");b=s.index('\ncore=',a);s=s[:a]+"cls=['_008B_0096','_008C_0095','_008A_0093','_008A_008D','_008A_008B','_008E_0097','_008E_009B','_008F_008C','_008F_008E','_008F_0090']"+s[b:]
s=s.replace('cls[:5]','cls[:3]').replace('range(0x4B7,0x4BD)','range(0x586,0x58B)').replace('cls[5:]','cls[3:]').replace("_008B_008C.source.txt","_008B_0096.source.txt")
Path('recovered/round7/indexes.py').write_text(s,encoding='utf-8')
