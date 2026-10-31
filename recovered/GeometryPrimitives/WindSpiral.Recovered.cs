using System;
using System.Collections.Generic;

namespace Recovered.Geometry
{
    // Mechanical port of _008F_0086 (processed P7A1-P7AD; original class RVA C4620).
    // This file intentionally has no Autodesk dependency and is not a replacement plug-in.
    public struct Point2
    {
        public double X, Y;
        public Point2(double x, double y) { X = x; Y = y; }
        public static double Distance(Point2 a, Point2 b)
        { double x = a.X - b.X, y = a.Y - b.Y; return Math.Sqrt(x*x + y*y); }
    }

    public sealed class WindSpiralRecovered
    {
        public readonly Point2 Origin;
        public readonly double Heading;
        public readonly double Offset;
        public readonly double WindRadius;
        public readonly double TurnRadius;
        public readonly double Drift;
        public readonly int DirectionSign;
        public readonly double DegreeStep = Math.PI / 180.0;

        public WindSpiralRecovered(Point2 origin, double heading, double offset,
            double windRadius, double turnRadius, double drift, bool positiveDirection)
        {
            Origin = origin; Heading = Normalize(heading); Offset = offset;
            WindRadius = windRadius; TurnRadius = turnRadius; Drift = drift;
            DirectionSign = positiveDirection ? 1 : -1;
        }

        // P7A2: repeated +/- 2PI loop, unlike the one-pass normalizers in some windows.
        public static double Normalize(double angle)
        {
            while (angle < 0.0) angle += Math.PI * 2.0;
            while (angle >= Math.PI * 2.0) angle -= Math.PI * 2.0;
            return angle;
        }

        // P7A5. The source does not clamp asin input or special-case zero radius.
        public Point2 Point(double angle, double extraOffset = 0.0)
        {
            double q = angle * WindRadius + Offset + extraOffset;
            double d = Math.Sqrt(TurnRadius * TurnRadius + q * q +
                                 2.0 * TurnRadius * q * Math.Cos(Drift));
            double effective = angle - Math.Asin(q * Math.Sin(Drift) / d);
            double a = DirectionSign * effective + Heading;
            return new Point2(d * Math.Cos(a) + Origin.X, d * Math.Sin(a) + Origin.Y);
        }

        // P7A6. Base circle has no wind displacement.
        public Point2 BaseCirclePoint(double angle)
        {
            double a = DirectionSign * angle + Heading;
            return new Point2(TurnRadius * Math.Cos(a) + Origin.X,
                             TurnRadius * Math.Sin(a) + Origin.Y);
        }

        // P7A7. Radius after wind displacement.
        public double Radius(double angle, double extraOffset = 0.0)
        {
            double q = angle * WindRadius + Offset + extraOffset;
            return Math.Sqrt(TurnRadius * TurnRadius + q*q +
                             2.0 * TurnRadius * q * Math.Cos(Drift));
        }

        // P7A3. P3 is expressed in degrees; the exact terminal point is always appended.
        public List<Point2> Sample(double start = 0.0, double end = Math.PI,
                                   double extraOffset = 0.0, double stepDegrees = 1.0)
        {
            var result = new List<Point2>();
            double p = start, step = stepDegrees * DegreeStep;
            while (true)
            {
                if (p >= end) { result.Add(Point(end, extraOffset)); return result; }
                result.Add(Point(p, extraOffset));
                p += step;
            }
        }

        // P7A4. Preserve the original alternating list behavior and split counter.
        public List<List<Point2>> SampleSplit(double start = 0.0, double end = Math.PI,
                                              double extraOffset = 0.0, double stepDegrees = 1.0,
                                              double splitEvery = 5.0)
        {
            var result = new List<List<Point2>>();
            var current = new List<Point2>();
            double p = start, step = stepDegrees * DegreeStep, counter = 1.0;
            bool keep = true;
            while (true)
            {
                if (p >= end) { current.Add(Point(end, extraOffset)); result.Add(current); return result; }
                if (keep) current.Add(Point(p, extraOffset));
                if (counter++ % splitEvery == 0.0)
                {
                    if (keep) { result.Add(current); current = new List<Point2>(); }
                    keep = !keep;
                }
                p += step;
            }
        }

        // P7A7/P7A8 fixed-point inverse used by the original point/angle helpers.
        public double ParameterForPolar(double targetAngle, double extraOffset = 0.0)
        {
            double target = Normalize(targetAngle), p = target, previous = 0.0;
            for (int i = 0; i < 20; i++)
            {
                double q = p * WindRadius + Offset + extraOffset;
                double d = Radius(p, extraOffset);
                double corrected = p - Math.Asin(q * Math.Sin(Drift) / d);
                double delta = target - corrected;
                p += delta;
                if (delta <= 1e-9) return p;
                previous = delta;
            }
            return p;
        }

        // P7AD/P7A9 family: distance-bisection helper used for line/spiral joins.
        public double ParameterForLineDistance(Func<Point2, double> distance,
                                               double targetDistance, double lower,
                                               double upper, double extraOffset = 0.0,
                                               bool increasing = true)
        {
            double result = lower;
            for (int i = 0; i <= 20; i++)
            {
                result = (lower + upper) / 2.0;
                double d = distance(Point(result, extraOffset));
                if (Math.Abs(d - targetDistance) <= 0.01) return result;
                if (increasing)
                {
                    if (d > targetDistance) upper = result; else lower = result;
                }
                else
                {
                    if (d > targetDistance) lower = result; else upper = result;
                }
            }
            return result;
        }

        // P7AD: point-to-spiral tangent/parameter iteration. The original first
        // chooses a base-circle tangent candidate, then corrects it against the
        // sampled spiral for at most ten updates (1e-7 angular stop). The exact
        // no-tangent branch is protected by obfuscated control flow; this carrier
        // preserves the recovered candidate update, not a normative fallback.
        public double ParameterForPoint(Point2 point, double extraOffset = 0.0)
        {
            double radial = Point2.Distance(point, Origin);
            double bearing = Math.Atan2(point.Y - Origin.Y, point.X - Origin.X);
            double candidate = bearing;
            if (radial >= TurnRadius && radial != 0.0)
                candidate = Normalize(Heading - DirectionSign * Math.Acos(TurnRadius / radial));
            for (int i = 0; i <= 10; i++)
            {
                Point2 basePoint = BaseCirclePoint(candidate);
                Point2 spiralPoint = Point(candidate, extraOffset);
                double toPoint = Math.Atan2(point.Y - spiralPoint.Y, point.X - spiralPoint.X);
                double toBase = Math.Atan2(basePoint.Y - spiralPoint.Y, basePoint.X - spiralPoint.X);
                double delta = Math.PI / 2.0 - DirectedAngle(toPoint, toBase, DirectionSign);
                candidate += delta;
                if (delta <= 1e-7) break;
            }
            return candidate;
        }

        private static double DirectedAngle(double from, double to, int sign)
        {
            from = Normalize(from); to = Normalize(to);
            if (sign > 0) return (to < from ? to + 2.0*Math.PI : to) - from;
            return from - (to > from ? to - 2.0*Math.PI : to);
        }

        public static List<Point2> Concatenate(List<Point2> first, List<Point2> second)
        {
            var result = new List<Point2>(first ?? new List<Point2>());
            if (second != null) result.AddRange(second);
            return result;
        }
    }
}
