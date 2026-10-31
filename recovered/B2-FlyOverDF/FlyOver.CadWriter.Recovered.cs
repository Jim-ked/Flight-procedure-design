using System;
using System.Collections.Generic;

namespace Recovered.Round3.B2
{
    public enum FlyOverEntityKind { Polyline, Group, DescriptorPolyline }
    public sealed record FlyOverEntityPlan(string Name, FlyOverEntityKind Kind, bool WithWsObject,
        IReadOnlyList<IReadOnlyList<Recovered.Geometry.Point2>> Vertices);

    public static class FlyOverCadWriterRecovered
    {
        // Source: original 0x060004E1, annotated source 53553-53557.
        public static IReadOnlyList<FlyOverEntityPlan> Plan(FlyOverBoundaryModel m,
            bool showNominalTrack, bool showPriBoundary, bool showSecBoundary,
            bool showSpiral, bool showTolerance, string metadata)
        {
            var result = new List<FlyOverEntityPlan>();
            bool xdata = !string.IsNullOrWhiteSpace(metadata);
            if (showNominalTrack && m.NominalConnection != null)
                result.Add(new FlyOverEntityPlan("NominalConnectionDescriptor", FlyOverEntityKind.DescriptorPolyline, xdata, m.NominalConnection));
            if (showPriBoundary)
            {
                result.Add(Line("BoundaryList03", m.BoundaryList03, xdata));
                result.Add(Line("BoundaryList01", m.BoundaryList01, xdata));
            }
            if (showSecBoundary)
            {
                result.Add(Line("BoundaryList04", m.BoundaryList04, xdata));
                result.Add(Line("BoundaryList02", m.BoundaryList02, xdata));
            }
            if (showSpiral) result.Add(new FlyOverEntityPlan("SpiralGroup01", FlyOverEntityKind.Group, xdata, m.SpiralGroup01));
            // Original P6 branch calls _0088_008A without P8.
            if (showTolerance) result.Add(Line("TolerancePolyline", m.Tolerance, false));
            return result;
        }

        private static FlyOverEntityPlan Line(string name, IReadOnlyList<IReadOnlyList<Recovered.Geometry.Point2>> v, bool xdata) =>
            new FlyOverEntityPlan(name, FlyOverEntityKind.Polyline, xdata, v ?? Array.Empty<IReadOnlyList<Recovered.Geometry.Point2>>());
    }
}
