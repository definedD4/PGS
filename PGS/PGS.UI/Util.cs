using PGS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PGS.UI
{
    public static class Vec2Ext
    {
        public static Point ToWndPoint(this Vec2 vec)
        {
            return new Point(vec.X, vec.Y);
        }
    }

    public static class PointExt
    {
        public static Vec2 ToVec2(this Point point)
        {
            return new Vec2(point.X, point.Y);
        }
    }
}
