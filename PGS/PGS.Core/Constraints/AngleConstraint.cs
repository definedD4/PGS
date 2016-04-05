using PGS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGS.Core.Constraints
{
    public class AngleConstraint : IConstraint
    {
        public const double ForceModifier = 30d;

        public AngleConstraint(Angle angle, double targetAngle)
        {
            Angle = angle;
            TargetAngle = targetAngle;
            Angle.Constraints.Add(this);
        }

        public double TargetAngle { get; set; }

        public Angle Angle;

        public void Apply()
        {

            double force = (TargetAngle - Angle.Radians) * ForceModifier;

            Vec2 toLeftN = Angle.ToLeft.Normalized();
            Vec2 toRightN = Angle.ToRight.Normalized();
            Vec2 middleN = Vec2.Average(toLeftN, toRightN).Normalized();

            Vec2 fl = toLeftN.PerpLeft() * force;
            Vec2 fr = toRightN.PerpRight() * force;

            Angle.Left.AddForce(fl);
            Angle.Right.AddForce(fr);
            Angle.Center.AddForce(
                -middleN*(
                middleN*toLeftN.PerpLeft() *force*2));
        }
    }
}
