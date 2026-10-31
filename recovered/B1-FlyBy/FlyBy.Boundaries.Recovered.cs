using System.Collections.Generic;
using Recovered.Geometry;

namespace Recovered.Round3.B1
{
    // DTO generated from the B1 list fields. It intentionally does not rename
    // BoundaryList05/BoundaryGroup02 to KK'/NN' semantic aviation terms.
    public sealed class FlyByBoundaryModel
    {
        public IReadOnlyList<IReadOnlyList<Point2>> BoundaryList03 { get; init; } = new List<IReadOnlyList<Point2>>();
        public IReadOnlyList<IReadOnlyList<Point2>> BoundaryList01 { get; init; } = new List<IReadOnlyList<Point2>>();
        public IReadOnlyList<IReadOnlyList<Point2>> BoundaryList04 { get; init; } = new List<IReadOnlyList<Point2>>();
        public IReadOnlyList<IReadOnlyList<Point2>> BoundaryList02 { get; init; } = new List<IReadOnlyList<Point2>>();
        public IReadOnlyList<IReadOnlyList<Point2>> BoundaryList05 { get; init; } = new List<IReadOnlyList<Point2>>();
        public IReadOnlyList<IReadOnlyList<Point2>> BoundaryGroup02 { get; init; } = new List<IReadOnlyList<Point2>>();
        public IReadOnlyList<IReadOnlyList<Point2>> SpiralGroup01 { get; init; } = new List<IReadOnlyList<Point2>>();
        public IReadOnlyList<IReadOnlyList<Point2>> Tolerance { get; init; } = new List<IReadOnlyList<Point2>>();
        public IReadOnlyList<IReadOnlyList<Point2>>? NominalConnection { get; init; }

        // Exact scalar recovery from _008C_0087 constructor (source 66656-66657).
        public static (double earliest, double latest) Distances(double turnRadius, double headingChange,
            double att, double reactionTime, double bankAngleDelay, double tas, double wind)
        {
            double n = turnRadius * System.Math.Tan(headingChange / 2.0);
            return (att + n, n - att - (reactionTime + bankAngleDelay) * (tas + wind) / 3.6);
        }
    }
}
