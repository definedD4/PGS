using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PGS.Core;
using PGS.Util;
using Point = PGS.Core.Point;

namespace PGS.UI
{
    public class PointDisplay : ElementDisplayBase
    {
        public PointDisplay(Point point, string label)
        {
            Point = point;
            Label = label;
        }

        public override int ZIndex => 3;
        public override GeoElement Element => Point;

        public Point Point { get; }

        private string m_Label;
        public string Label
        {
            get { return m_Label; }
            set { m_Label = value; NotifyPropertyChanged(nameof(Label)); }
        }

        public double XPos => Point.Pos.X;
        public double YPos => Point.Pos.Y;

        public void Move(Vector amount)
        {
            Point.Pos += new Vec2(amount.X, amount.Y);
            NotifyChanged();
        }

        public override void NotifyChanged()
        {
            NotifyPropertyChanged(nameof(XPos));
            NotifyPropertyChanged(nameof(YPos));
        }

        public override ElementPropertiesBase GetProperties() => new PointProperties(this);
    }
}
