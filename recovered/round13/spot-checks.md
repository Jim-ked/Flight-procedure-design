# Round 13 finite spot checks

| layer | check | result |
|---|---|---|
| formula | A1 q=angle·WindRadius+offset; P793 rate cap and drift | PASS — existing recovered model |
| formula | B1/B2 ATT earliest/latest formulas | PASS — existing source/IL records |
| geometry | A1 manual origin semantics and list concatenation | PASS — source 35713–35804 and overview |
| geometry | B1/B2 P1/P2/P3 bearing semantics | PASS — input-frame reports |
| branch | B1 60/90/120 plus 15/30 | PASS — geometry and writer maps |
| branch | B2 turn angle, 15°, candidate distance, 12000/13000 | PASS — geometry and boundary CSV |
| writer | A1 Polyline/Spline and optional Circles | PASS — CAD map/source |
| writer | B1 KK/NN and four-boundary order | PASS — cad-writer.md |
| writer | B2 primary/secondary/spiral/tolerance order | PASS — cad-writer.md |
| negative-evidence | A1 standalone tangent solver | PASS — absent; point-to-spiral only |
| negative-evidence | B1/B2 obstacle evaluator | PASS — absent in indexed classes |
| negative-evidence | B2 ATT=0 special dispatch | PASS — absent in public workflow/direct class |
| cross-module | shared P793/Spiral86 versus copied boundary classes | PASS — comparison CSV |
