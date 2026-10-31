# B2 Fly-over DF recovery

**Status: partial static recovery.** The independent `_008C_0089` class, input mapping, scalar earliest/latest setup, spiral/line candidate logic and ATT=0 negative search are documented. A complete DF boundary vertex port is not claimed.

The handler prompts the same three points as B1 and constructs start, middle and end descriptors. The center descriptor receives ATT; start and end receive the same width and have ATT-like field zeroed by the event. The object passed to the CAD writer is `_008C_0089`, not `_008C_0087`.

The B2 class has its own 15° constant, copied spiral/line operations, candidate-distance comparisons and fixed 12000/13000 construction distances. Similarity to B1 is code duplication and shared base state, not a shared boundary method.
