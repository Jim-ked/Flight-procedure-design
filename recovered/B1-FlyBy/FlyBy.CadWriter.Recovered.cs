using System;
using System.Collections.Generic;

namespace Recovered.Round3.B1
{
    // Evidence carrier, not a replacement AutoCAD plug-in. Names are neutral where
    // the original writer did not carry an aviation semantic string.
    public enum FlyByEntityKind { Polyline, Group, DescriptorPolyline }
    public sealed record FlyByEntityPlan(string Name, FlyByEntityKind Kind, bool WithWsObject,
        IReadOnlyList<IReadOnlyList<Recovered.Geometry.Point2>> Vertices);

    public static class FlyByCadWriterRecovered
    {
        // Source: original 0x060004C7, annotated source 52420-52462.
        public static IReadOnlyList<FlyByEntityPlan> Plan(FlyByBoundaryModel m,
            bool showNominalTrack, bool showBoundary, bool showKK, bool showNN,
            bool showSpiral, bool showTolerance, string metadata)
        {
            var result = new List<FlyByEntityPlan>();
            bool xdata = !string.IsNullOrWhiteSpace(metadata);
            if (showNominalTrack && m.NominalConnection != null)
                result.Add(new FlyByEntityPlan("NominalConnectionDescriptor", FlyByEntityKind.DescriptorPolyline, xdata, m.NominalConnection));
            if (showBoundary)
            {
                result.Add(Line("BoundaryList03", m.BoundaryList03, xdata));
                result.Add(Line("BoundaryList01", m.BoundaryList01, xdata));
                result.Add(Line("BoundaryList04", m.BoundaryList04, xdata));
                result.Add(Line("BoundaryList02", m.BoundaryList02, xdata));
            }
            if (showKK) result.Add(Line("BoundaryList05", m.BoundaryList05, xdata));
            if (showNN) result.Add(new FlyByEntityPlan("BoundaryGroup02", FlyByEntityKind.Group, xdata, m.BoundaryGroup02));
            if (showSpiral) result.Add(new FlyByEntityPlan("SpiralGroup01", FlyByEntityKind.Group, xdata, m.SpiralGroup01));
            // Original tolerance call omits P9, so metadata is deliberately false.
            if (showTolerance) result.Add(Line("TolerancePolyline", m.Tolerance, false));
            return result;
        }

        private static FlyByEntityPlan Line(string name, IReadOnlyList<IReadOnlyList<Recovered.Geometry.Point2>> v, bool xdata) =>
            new FlyByEntityPlan(name, FlyByEntityKind.Polyline, xdata, v ?? Array.Empty<IReadOnlyList<Recovered.Geometry.Point2>>());
    }
}
