using System;

namespace PGS.Util
{
    public class Vec2
    {
        /// <summary>
        /// A unit-vector along X axis.
        /// </summary>
        public static Vec2 I = new Vec2(1, 0);

        /// <summary>
        /// A unit-vector along Y axis.
        /// </summary>
        public static Vec2 J = new Vec2(0, 1);

        public Vec2() : this(0, 0)
        {

        }

        public Vec2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }
        public double Y { get; }

        public double Length{get
            {
                return Math.Sqrt(X * X + Y * Y);
            } }

        public double LengthSqr { get
            {
                return X * X + Y * Y;
            } }

        public Vec2 Normalized()
        {
            double l = Length;
            return new Vec2(X / l, Y / l);
        }

        public static Vec2 operator +(Vec2 lhs, Vec2 rhs) => new Vec2(lhs.X + rhs.X, lhs.Y + rhs.Y);
        public static Vec2 operator +(Vec2 lhs, double rhs) => new Vec2(lhs.X + rhs, lhs.Y + rhs);

        public static Vec2 operator -(Vec2 lhs, Vec2 rhs) => new Vec2(lhs.X - rhs.X, lhs.Y - rhs.Y);
        public static Vec2 operator -(Vec2 lhs, double rhs) => new Vec2(lhs.X - rhs, lhs.Y - rhs);

        public static Vec2 operator *(Vec2 lhs, double rhs) => new Vec2(lhs.X * rhs, lhs.Y * rhs);
        public static Vec2 operator /(Vec2 lhs, double rhs) => new Vec2(lhs.X / rhs, lhs.Y / rhs);

        public static Vec2 operator -(Vec2 vec) => new Vec2(-vec.X, -vec.Y);

        /// <summary>
        /// Dot product operator.
        /// </summary>
        public static double operator *(Vec2 lhs, Vec2 rhs) => lhs.X * rhs.X + lhs.Y * rhs.Y;

        /// <summary>
        /// Angle between vectors in radians.
        /// </summary>
        public static double operator ^(Vec2 lhs, Vec2 rhs) => Math.Acos(lhs.Normalized() * rhs.Normalized());

        /// <summary>
        /// Vector rotated right 90 degrees.
        /// </summary>
        public Vec2 PerpRight() => new Vec2(Y, -X);

        /// <summary>
        /// Vector rotated left 90 degrees.
        /// </summary>
        /// <returns></returns>
        public Vec2 PerpLeft() => new Vec2(-Y, X);

        public static Vec2 Average(Vec2 lhs, Vec2 rhs) => new Vec2((lhs.X + rhs.X)/2, (lhs.Y + rhs.Y)/2);

        public override string ToString()
        {
            return $"({Math.Round(X, 2)}; {Math.Round(Y, 2)})";
        }
    }
}
