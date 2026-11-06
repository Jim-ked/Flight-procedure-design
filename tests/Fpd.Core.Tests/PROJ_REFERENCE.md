# Independent CGCS2000 reference

Generated 2026-11-06 with pyproj 3.8.0 / PROJ 9.8.1 (separate test-only installation).

```python
from pyproj import Transformer
transform = Transformer.from_crs(4490, 4548, always_xy=True)
print(transform.transform(117.346183, 39.124353))
```

| Longitude ° | Latitude ° | Easting m | Northing m |
|---|---|---|---|
|117.346183|39.124353|529936.0628666884|4332366.307251088|
|117.300000|39.200000|525914.6247423843|4340750.342561825|
|118.600000|39.200000|638214.8574548216|4341927.356207282|
|115.500000|39.000000|370057.27276682795|4319574.560958737|
|117.000000|39.000000|500000.0|4318503.984691529|

Parameters checked from EPSG:4548: CGCS2000 / 3-degree Gauss-Kruger CM 117E,
a=6378137 m, inverse flattening=298.257222101, latitude origin=0°,
central meridian=117°, k=1, false easting=500000 m, false northing=0 m.
EPSG formal axes are Northing(X), Easting(Y). `always_xy=True` explicitly uses
longitude/latitude on input and easting/northing on output, matching CAD WCS X=E, Y=N.

The production implementation uses a standard Transverse Mercator series; tests compare
against this independent reference to 1 mm for the sample cases. The earlier report's
N=4332366.307376 was a same-formula recalculation, not an independent reference;
the difference from PROJ is approximately 0.125 mm.

The project fixes its central meridian from the airport ARP. The 118.6°E point deliberately
crosses the local 118.5°E zone boundary: it must still use CM117E, not CM120E.
No ARP subtraction is applied. Heights are input metres, defaulting to 0; no vertical datum conversion.
