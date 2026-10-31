using System;
using System.Collections.Generic;

namespace Fpd.Domain
{
    public enum StaticClosureStatus { PartialStatic, CompleteStatic }
    public enum IntegrationStatus { Recovered, Executable, BehaviorLocked, RuleMapped, Adopted }

    public struct Point2
    {
        public readonly double X;
        public readonly double Y;
        public Point2(double x, double y) { X = x; Y = y; }
        public double DistanceTo(Point2 other) { var dx = X - other.X; var dy = Y - other.Y; return Math.Sqrt(dx * dx + dy * dy); }
    }

    public sealed class TurnParameterInput
    {
        public readonly double IAS, Altitude, Temperature, Bank, Wind;
        public TurnParameterInput(double ias, double altitude, double temperature, double bank, double wind)
        { IAS = ias; Altitude = altitude; Temperature = temperature; Bank = bank; Wind = wind; }
    }

    public sealed class TurnParameterResult
    {
        public readonly double K, TAS, Rate, Radius, WindRadius, Drift, Wind;
        public TurnParameterResult(double k, double tas, double rate, double radius, double windRadius, double drift, double wind)
        { K = k; TAS = tas; Rate = rate; Radius = radius; WindRadius = windRadius; Drift = drift; Wind = wind; }
        public double E(double degrees) { return degrees * Math.PI / 180.0 * WindRadius; }
        public double C6() { return (TAS + Wind) / 0.6; }
    }

    public sealed class WindSpiralInput
    {
        public readonly Point2 Origin;
        public readonly double Heading, Offset, WindRadius, TurnRadius, Drift;
        public readonly bool PositiveDirection;
        public WindSpiralInput(Point2 origin, double heading, double offset, double windRadius, double turnRadius, double drift, bool positiveDirection)
        { Origin = origin; Heading = heading; Offset = offset; WindRadius = windRadius; TurnRadius = turnRadius; Drift = drift; PositiveDirection = positiveDirection; }
    }

    public sealed class WindSpiralResult
    {
        private readonly Point2 _origin; private readonly double _heading, _offset, _windRadius, _turnRadius, _drift; private readonly int _sign;
        public WindSpiralResult(Point2 origin, double heading, double offset, double windRadius, double turnRadius, double drift, bool positive)
        { _origin = origin; _heading = Normalize(heading); _offset = offset; _windRadius = windRadius; _turnRadius = turnRadius; _drift = drift; _sign = positive ? 1 : -1; }
        public Point2 Point(double angle, double extraOffset) { var q = angle * _windRadius + _offset + extraOffset; var d = Math.Sqrt(_turnRadius * _turnRadius + q * q + 2.0 * _turnRadius * q * Math.Cos(_drift)); var effective = angle - Math.Asin(q * Math.Sin(_drift) / d); var a = _sign * effective + _heading; return new Point2(d * Math.Cos(a) + _origin.X, d * Math.Sin(a) + _origin.Y); }
        public Point2 BasePoint(double angle) { var a = _sign * angle + _heading; return new Point2(_turnRadius * Math.Cos(a) + _origin.X, _turnRadius * Math.Sin(a) + _origin.Y); }
        public double Radius(double angle, double extraOffset) { var q = angle * _windRadius + _offset + extraOffset; return Math.Sqrt(_turnRadius * _turnRadius + q * q + 2.0 * _turnRadius * q * Math.Cos(_drift)); }
        public IList<Point2> Sample(double start, double end, double extraOffset, double stepDegrees) { var r = new List<Point2>(); var p = start; var step = stepDegrees * Math.PI / 180.0; while (true) { if (p >= end) { r.Add(Point(end, extraOffset)); return r; } r.Add(Point(p, extraOffset)); p += step; } }
        public IList<IList<Point2>> SampleSplit(double start, double end, double extraOffset, double stepDegrees, double splitEvery) { var result = new List<IList<Point2>>(); var current = new List<Point2>(); var p = start; var step = stepDegrees * Math.PI / 180.0; var counter = 1.0; var keep = true; while (true) { if (p >= end) { current.Add(Point(end, extraOffset)); result.Add(current); return result; } if (keep) current.Add(Point(p, extraOffset)); if (counter++ % splitEvery == 0.0) { if (keep) { result.Add(current); current = new List<Point2>(); } keep = !keep; } p += step; } }
        public double ParameterForPolar(double targetAngle, double extraOffset) { var target = Normalize(targetAngle); var p = target; for (var i = 0; i < 20; i++) { var q = p * _windRadius + _offset + extraOffset; var d = Radius(p, extraOffset); var corrected = p - Math.Asin(q * Math.Sin(_drift) / d); var delta = target - corrected; p += delta; if (delta <= 1e-9) return p; } return p; }
        public double ParameterForLineDistance(Func<Point2, double> distance, double targetDistance, double lower, double upper, double extraOffset, bool increasing) { var result = lower; for (var i = 0; i <= 20; i++) { result = (lower + upper) / 2.0; var d = distance(Point(result, extraOffset)); if (Math.Abs(d - targetDistance) <= 0.01) return result; if (increasing) { if (d > targetDistance) upper = result; else lower = result; } else { if (d > targetDistance) lower = result; else upper = result; } } return result; }
        public static double Normalize(double angle) { while (angle < 0.0) angle += Math.PI * 2.0; while (angle >= Math.PI * 2.0) angle -= Math.PI * 2.0; return angle; }
    }

    public sealed class RuleContextSnapshot
    {
        public readonly string SegmentType; public readonly double TurnAngle; public readonly string SpecificationId;
        public RuleContextSnapshot(string segmentType, double turnAngle, string specificationId) { SegmentType = segmentType; TurnAngle = turnAngle; SpecificationId = specificationId; }
    }

    public sealed class CalculationTrace
    {
        private readonly List<string> _steps = new List<string>();
        public IList<string> Steps { get { return _steps.AsReadOnly(); } }
        public void Add(string step) { _steps.Add(step); }
    }

    public interface ITurnParameterEngine { TurnParameterResult Calculate(TurnParameterInput input); }
    public interface IWindSpiralEngine { WindSpiralResult Create(WindSpiralInput input); }

    public enum EvaluationMode { Normal, If }
    public sealed class ProtectionFrame
    {
        public readonly double StartX, StartY, StartZ, EndX, EndY;
        public ProtectionFrame(double startX, double startY, double startZ, double endX, double endY) { StartX = startX; StartY = startY; StartZ = startZ; EndX = endX; EndY = endY; }
    }
    public sealed class ObstaclePoint
    {
        public readonly string Id, Name; public readonly double X, Y, Z;
        public ObstaclePoint(string id, string name, double x, double y, double z) { Id = id; Name = name; X = x; Y = y; Z = z; }
    }
    public sealed class ObstacleAssessment
    {
        public readonly string Id, Name, Area; public readonly double MOC, OCA;
        public ObstacleAssessment(string id, string name, string area, double moc, double oca) { Id = id; Name = name; Area = area; MOC = moc; OCA = oca; }
    }
    public interface IObstacleAssessmentEngine
    {
        IList<ObstacleAssessment> Evaluate(ProtectionFrame frame, IList<ObstaclePoint> obstacles, double startWidth, double startMoc, double endWidth, double endMoc, EvaluationMode mode);
    }

    public sealed class BoundarySlot
    {
        public readonly string LegacyBoundaryId; public readonly IList<Point2> Points;
        public BoundarySlot(string id, IList<Point2> points) { LegacyBoundaryId = id; Points = points; }
    }
    public sealed class AuxGeometry
    {
        public readonly string LegacyBoundaryId; public readonly IList<Point2> Points;
        public AuxGeometry(string id, IList<Point2> points) { LegacyBoundaryId = id; Points = points; }
    }
}
