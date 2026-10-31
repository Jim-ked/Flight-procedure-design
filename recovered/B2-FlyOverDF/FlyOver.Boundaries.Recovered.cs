using System.Collections.Generic;
using Recovered.Geometry;

namespace Recovered.Round3.B2
{
    public sealed class FlyOverBoundaryModel
    {
        public IReadOnlyList<IReadOnlyList<Point2>> BoundaryList03 { get; init; } = new List<IReadOnlyList<Point2>>();
        public IReadOnlyList<IReadOnlyList<Point2>> BoundaryList01 { get; init; } = new List<IReadOnlyList<Point2>>();
        public IReadOnlyList<IReadOnlyList<Point2>> BoundaryList04 { get; init; } = new List<IReadOnlyList<Point2>>();
        public IReadOnlyList<IReadOnlyList<Point2>> BoundaryList02 { get; init; } = new List<IReadOnlyList<Point2>>();
        public IReadOnlyList<IReadOnlyList<Point2>> SpiralGroup01 { get; init; } = new List<IReadOnlyList<Point2>>();
        public IReadOnlyList<IReadOnlyList<Point2>> Tolerance { get; init; } = new List<IReadOnlyList<Point2>>();
        public IReadOnlyList<IReadOnlyList<Point2>>? NominalConnection { get; init; }

        // Source 67449-67521. No ATT equality branch was recovered.
        public static (double earliest, double latest) Distances(double att,
            double reactionTime, double bankTime, double tas, double wind) =>
            (att, -att - (reactionTime + bankTime) * (tas + wind) / 3.6);

        // Source _0089_009E_008C IL_0214/028E and IL_02DF/0356.
        public static (double firstFixedDistance, double secondFixedDistance) FixedPathLengths() => (12000.0, 13000.0);
    }
}
