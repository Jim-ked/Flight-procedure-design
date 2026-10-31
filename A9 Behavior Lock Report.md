# A9 Behavior Lock Report

`RecoveredObstacleAssessmentEngine` accepts only `ProtectionFrame`, `ObstaclePoint`, widths, MOC and `EvaluationMode`. It preserves local transformation, Normal strict endpoints, IF inclusive endpoints, Normal/IF primary end-width difference, primary/secondary classification, linear MOC and secondary MOC, safe-divide sentinel behavior, zero-width/zero-length arithmetic, and original obstacle ID/Z mapping.

The Legacy behavior runner verifies Normal primary/secondary results, IF endpoint inclusion, and zero-length degeneration. A9 is `BehaviorLocked`; it is intentionally not `RuleMapped` or `Adopted` while `RS-OBS-PRIMARYSECONDARY-001` remains DETAIL-PENDING.
