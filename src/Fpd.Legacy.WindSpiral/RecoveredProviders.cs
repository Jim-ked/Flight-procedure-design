using System;
using System.Collections.Generic;
using Fpd.Domain;

namespace Fpd.Legacy.WindSpiral
{
    // Compatibility shim mechanically derived from recovered GeometryPrimitives.
    // The recovered files remain unchanged and are the evidence source.
    public sealed class RecoveredTurnParameterEngine : ITurnParameterEngine
    {
        public TurnParameterResult Calculate(TurnParameterInput input)
        {
            var k = 171233.0 * Math.Sqrt(288.0 + input.Temperature - 0.006496 * input.Altitude) /
                    Math.Pow(288.0 - 0.006496 * input.Altitude, 2.628);
            var tas = input.IAS * k;
            var rate = Math.Min(6355.0 * Math.Tan(input.Bank * Math.PI / 180.0) / (Math.PI * tas), 3.0);
            var radius = 1000.0 * tas / (Math.PI * 20.0 * rate);
            var windRadius = 1000.0 * input.Wind / (Math.PI * 20.0 * rate);
            var drift = Math.Asin(input.Wind / tas);
            return new TurnParameterResult(k, tas, rate, radius, windRadius, drift, input.Wind);
        }
    }

    public sealed class RecoveredWindSpiralEngine : IWindSpiralEngine
    {
        public WindSpiralResult Create(WindSpiralInput input)
        { return new WindSpiralResult(input.Origin, input.Heading, input.Offset, input.WindRadius, input.TurnRadius, input.Drift, input.PositiveDirection); }
    }

    public sealed class RecoveredObstacleAssessmentEngine : IObstacleAssessmentEngine
    {
        public IList<ObstacleAssessment> Evaluate(ProtectionFrame frame, IList<ObstaclePoint> obstacles, double startWidth, double startMoc, double endWidth, double endMoc, EvaluationMode mode)
        {
            var length = Math.Sqrt(Math.Pow(frame.EndY - frame.StartY, 2) + Math.Pow(frame.EndX - frame.StartX, 2));
            var axis = Math.Atan2(frame.StartY - frame.EndY, frame.StartX - frame.EndX);
            var result = new List<ObstacleAssessment>();
            var maximum = startWidth > endWidth ? startWidth : endWidth;
            if (obstacles == null) return result;
            foreach (var source in obstacles)
            {
                var distance = Math.Sqrt(Math.Pow(source.Y - frame.StartY, 2) + Math.Pow(source.X - frame.StartX, 2));
                var angle = Math.Atan2(source.Y - frame.StartY, source.X - frame.StartX) - axis;
                var x = distance * Math.Cos(angle);
                var y = distance * Math.Sin(angle);
                var absY = Math.Abs(y);
                var within = mode == EvaluationMode.If ? (x <= 0.0 && x >= -length) : (x < 0.0 && x > -length);
                if (!within || !(absY < maximum)) continue;
                var moc = endMoc + (startMoc - endMoc) * (length + x) / length;
                var primary = LineY(0.0, startWidth / 2.0, -length, mode == EvaluationMode.If ? endWidth : endWidth / 2.0, x);
                var outer = LineY(0.0, startWidth, -length, endWidth, x);
                if (absY <= primary)
                    result.Add(new ObstacleAssessment(source.Id, source.Name, "主区", moc, moc + source.Z));
                else if (absY <= outer)
                {
                    var secondaryMoc = outer - primary == 0.0 ? moc : moc * (outer - absY) / (outer - primary);
                    result.Add(new ObstacleAssessment(source.Id, source.Name, "副区", secondaryMoc, secondaryMoc + source.Z));
                }
            }
            return result;
        }

        private static double LineY(double x0, double y0, double x1, double y1, double x)
        {
            var a = y1 - y0; var b = x0 - x1; var c = y0 * (x1 - x0) - x0 * (y1 - y0);
            var numerator = -c - a * x;
            return b != 0.0 ? numerator / b : (numerator > 0.0 ? 1000000.0 : -1000000.0);
        }
    }
}
