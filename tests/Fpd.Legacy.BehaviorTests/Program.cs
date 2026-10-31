using System;
using System.Collections.Generic;
using Fpd.Domain;
using Fpd.Legacy.WindSpiral;

namespace Fpd.Legacy.BehaviorTests
{
    internal static class Program
    {
        private static int _passed;
        private static void Check(bool condition, string name) { if (!condition) throw new Exception("FAIL: " + name); _passed++; }
        private static void Close(double a, double b, string name) { Check(Math.Abs(a - b) < 1e-9, name); }
        public static int Main(string[] args)
        {
            var turn = new RecoveredTurnParameterEngine().Calculate(new TurnParameterInput(120, 1000, 15, 20, 30));
            var k = 171233.0 * Math.Sqrt(288.0 + 15.0 - 0.006496 * 1000.0) / Math.Pow(288.0 - 0.006496 * 1000.0, 2.628);
            Close(turn.K, k, "IAS to TAS factor"); Close(turn.TAS, 120.0 * k, "TAS");
            Close(turn.C6(), (turn.TAS + 30.0) / 0.6, "C6");
            Check(turn.Rate > 0.0 && turn.Radius > 0.0 && turn.WindRadius > 0.0, "rate/radius");
            Check(turn.Drift > 0.0 && turn.E(90.0) > 0.0, "drift/E");
            var engine = new RecoveredWindSpiralEngine();
            var spiral = engine.Create(new WindSpiralInput(new Point2(0, 0), 0, 0, turn.WindRadius, turn.Radius, turn.Drift, true));
            var basePoint = spiral.BasePoint(0.0); Close(basePoint.X, turn.Radius, "base point");
            var p90 = spiral.Point(Math.PI / 2.0, 0.0); var p180 = spiral.Point(Math.PI, 0.0); var p270 = spiral.Point(3.0 * Math.PI / 2.0, 0.0);
            Check(!double.IsNaN(p90.X) && !double.IsNaN(p180.Y) && !double.IsNaN(p270.X), "90/180/270");
            var right = engine.Create(new WindSpiralInput(new Point2(0, 0), 0, 0, 0, 100, 0, true));
            var left = engine.Create(new WindSpiralInput(new Point2(0, 0), 0, 0, 0, 100, 0, false));
            Check(right.Point(Math.PI / 2.0, 0).Y > 0 && left.Point(Math.PI / 2.0, 0).Y < 0, "left/right");
            var exact = right.Sample(0, Math.PI, 0, 70); Check(exact.Count == 4, "exact endpoint sampling"); Check(Math.Abs(exact[exact.Count - 1].X + 100.0) < 1e-8, "terminal endpoint");
            var split = right.SampleSplit(0, Math.PI, 0, 1, 5); Check(split.Count > 1, "SampleSplit");
            Check(Math.Abs(right.ParameterForPolar(0.0, 0.0)) < 1e-12, "polar fixed-point iteration");
            var lineParameter = right.ParameterForLineDistance(delegate(Point2 p) { return p.X; }, 50.0, 0.0, Math.PI, 0.0, true);
            Check(lineParameter >= 0.0 && lineParameter <= Math.PI, "line-distance iteration");
            var zeroRate = new RecoveredTurnParameterEngine().Calculate(new TurnParameterInput(100, 0, 15, 0, 10)); Check(double.IsInfinity(zeroRate.Radius), "zero turn rate Infinity");
            var nan = new RecoveredTurnParameterEngine().Calculate(new TurnParameterInput(100, 0, 15, 20, 1000)); Check(double.IsNaN(nan.Drift), "wind greater than TAS NaN");
            var noWind = new RecoveredTurnParameterEngine().Calculate(new TurnParameterInput(100, 0, 15, 20, 0)); Check(noWind.WindRadius == 0.0 && noWind.Drift == 0.0, "zero wind");
            var a9 = new RecoveredObstacleAssessmentEngine();
            var frame = new ProtectionFrame(0, 0, 0, 100, 0);
            var obstacles = new List<ObstaclePoint> {
                new ObstaclePoint("inside-primary", "p", 50, 1, 10),
                new ObstaclePoint("inside-secondary", "s", 50, 8, 20),
                new ObstaclePoint("normal-start", "n", 0, 0, 0),
                new ObstaclePoint("normal-end", "e", 100, 0, 0)
            };
            var normal = a9.Evaluate(frame, obstacles, 20, 100, 10, 80, EvaluationMode.Normal);
            Check(normal.Count == 2 && normal[0].Area == "主区" && normal[1].Area == "副区", "A9 normal primary/secondary");
            var iff = a9.Evaluate(frame, obstacles, 20, 100, 10, 80, EvaluationMode.If);
            Check(iff.Count == 4, "A9 IF inclusive endpoints");
            var zeroLength = a9.Evaluate(new ProtectionFrame(0, 0, 0, 0, 0), new List<ObstaclePoint> { new ObstaclePoint("z", "z", 0, 0, 1) }, 0, 100, 0, 100, EvaluationMode.If);
            Check(zeroLength.Count == 0 || double.IsNaN(zeroLength[0].MOC), "A9 zero length legacy behavior");
            Console.WriteLine("A1/P793 Recovered Behavior Baseline: PASS (" + _passed + " assertions)"); return 0;
        }
    }
}
