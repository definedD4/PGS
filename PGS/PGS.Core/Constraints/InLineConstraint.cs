namespace PGS.Core.Constraints
{
    public class InLineConstraint : IConstraint
    {
        public const double ForceModifier = 1d;

        public InLineConstraint(Point point1, Point point2, Point inLine)
        {
            Point1 = point1;
            Point2 = point2;
            InLine = inLine;
            Point1.Constraints.Add(this);
            Point2.Constraints.Add(this);
            InLine.Constraints.Add(this);
        }

        public Point Point1 { get; }
        public Point Point2 { get; }
        public Point InLine { get; }

        public void Apply()
        {
            var v12 = Point2.Pos - Point1.Pos;
            var perp = v12.PerpLeft().Normalized();
            var v1i = InLine.Pos - Point1.Pos;
            double force = v1i*perp*ForceModifier;
            var fi = -perp*force;
            InLine.AddForce(fi);
            Point1.AddForce(-fi/2);
            Point2.AddForce(-fi/2);
        }
    }
}