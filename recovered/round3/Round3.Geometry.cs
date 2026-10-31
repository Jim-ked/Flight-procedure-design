using System;
using System.Collections.Generic;
using Recovered.Geometry;

namespace Recovered.Round3
{
    public sealed class SegmentFrameRecovered
    {
        public readonly Point2 Center;
        public readonly double Width;
        public readonly string Name;
        public double ATT;
        public double ReactTime;
        public double BankTime;
        public SegmentFrameRecovered(Point2 center, double width = 4630.0, string name = "RNAV1")
        { Center = center; Width = width; Name = name; }
        public Point2 Offset(double bearing, double signedDistance)
        { return new Point2(Center.X + signedDistance*Math.Cos(bearing), Center.Y + signedDistance*Math.Sin(bearing)); }
        // _008C_0099::_008A_008C_0099: full/half offsets and four line descriptors.
        public BoundaryOffsets BuildOffsets(double bearing, double sideSign)
        {
            return new BoundaryOffsets(
                Offset(bearing - sideSign*Math.PI/2.0, Width),
                Offset(bearing - sideSign*Math.PI/2.0, Width/2.0),
                Offset(bearing + sideSign*Math.PI/2.0, Width),
                Offset(bearing + sideSign*Math.PI/2.0, Width/2.0));
        }
    }
    public struct BoundaryOffsets
    {
        public Point2 FullLeft, HalfLeft, FullRight, HalfRight;
        public BoundaryOffsets(Point2 a, Point2 b, Point2 c, Point2 d)
        { FullLeft=a; HalfLeft=b; FullRight=c; HalfRight=d; }
    }

    public static class TurnGeometryRecovered
    {
        public static double Normalize(double a) { return WindSpiralRecovered.Normalize(a); }
        // _008B_009E::_0089_009C_0097. Direction sign is +1 or -1.
        public static double TurnAngle(double incoming, double outgoing, out double direction)
        {
            double a=Normalize(incoming), b=Normalize(outgoing);
            if (a >= b + Math.PI) { direction=1; return b + 2*Math.PI-a; }
            if (a <= b && a + Math.PI > b) { direction=1; return b-a; }
            if (a < b - Math.PI) { direction=-1; return a + 2*Math.PI-b; }
            if (a > b && a < b + Math.PI) { direction=-1; return a-b; }
            direction=0; return 0;
        }

        // B1 constructor P5A0: num=r*tan(A/2), earliest=ATT+num,
        // latest=num-ATT-(React+Bank)*(TAS+Wind)/3.6.
        public static void FlyByEarliestLatest(double turnRadius, double turnAngle,
            double att, double reactionSeconds, double bankSeconds, double tas,
            double wind, out double earliest, out double latest)
        {
            double anticipation = turnRadius * Math.Tan(turnAngle / 2.0);
            earliest = att + anticipation;
            latest = anticipation - att - (reactionSeconds + bankSeconds)*(tas + wind)/3.6;
        }

        // B2 constructor P5AB: earliest=ATT; latest=-ATT-(React+Bank)*(TAS+Wind)/3.6.
        public static void FlyOverEarliestLatest(double att, double reactionSeconds,
            double bankSeconds, double tas, double wind, out double earliest, out double latest)
        {
            earliest = att;
            latest = -att - (reactionSeconds + bankSeconds)*(tas + wind)/3.6;
        }
    }
}
