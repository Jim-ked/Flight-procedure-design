# System architecture from frozen evidence

No unified Procedure Model is evidenced. Shared types include turn parameters, local frames, OAS core, WsCalcuLine and optional WsObject/XData writers; form state and point lists remain module-specific.

The CAD drawing is a shared-state surface. Cross-window reuse usually means manually repicking coordinates or inspecting entities. Automatic object-ID/metadata transfer is limited and writer-dependent. True same-MethodDef sharing exists for point/line primitives, CAD writers, turn parameters, OAS core and selected frame/obstacle helpers; A4→A9 and A7→B5 are not unified business calls.

Obstacle processing is partly shared and partly divergent: A7/A8/A9/A10 have static evaluation chains, B3 differs on Take5, and B4/B5 retain orphan or prompt-only evaluation paths. OAS has a reusable core with different wrappers and file formats. Turn/spiral primitives are shared while boundary algorithms are often copied.

The earlier statement remains supported: CAD entities carry geometry and sometimes metadata, while cross-module connection generally needs manual coordinate repick. Exceptions are shared helpers, WsCalcuLine/XData inspection and OAS parameter files; none establishes a global procedure object.
