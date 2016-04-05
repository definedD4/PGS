using PGS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGS.Core.Constraints
{
    public class LengthConstraint : IConstraint
    {
        public const double ForceModifier = 1d;

        public LengthConstraint(Segment segment, double targetLength)
        {
            Segment = segment;
            TargetLength = targetLength;
            Segment.Constraints.Add(this);
        }

        public double TargetLength { get; set; }

        public Segment Segment { get; }

        public void Apply()
        {
            double length = Segment.Length;
            double force = (TargetLength - length) * ForceModifier;

            Vec2 f21 = Segment.From2To1.Normalized() * force;
            Segment.Point1.AddForce(f21);
            Segment.Point2.AddForce(-f21);
        }
    }
}
