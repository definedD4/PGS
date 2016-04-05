using PGS.Util;
using PGS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGS.UI
{
    public class SegmentDisplay : ElementDisplayBase
    {
        public SegmentDisplay(Segment segment, PointDisplay point1, PointDisplay point2)
        {
            Segment = segment;
            Point1 = point1;
            Point2 = point2;

            Segment.PropertyChanged += (s, e) => NotifyChanged();
        }

        public override int ZIndex => 1;

        public Segment Segment { get; }
        public PointDisplay Point1 { get; }
        public PointDisplay Point2 { get; }

        public double X1 => Segment.Point1.Pos.X + 3.5 - XPos;
        public double Y1 => Segment.Point1.Pos.Y + 3.5 - YPos;
        public double X2 => Segment.Point2.Pos.X + 3.5 - XPos;
        public double Y2 => Segment.Point2.Pos.Y + 3.5 - YPos;

        public double XPos => Segment.Middle.X;
        public double YPos => Segment.Middle.Y;

        public string Label => Math.Round(Segment.Length, 2).ToString();

        public override GeoElement Element => Segment;

        public override ElementPropertiesBase GetProperties() => new SegmentProperties(this);

        public override void NotifyChanged()
        {
            NotifyPropertyChanged(nameof(X1));
            NotifyPropertyChanged(nameof(Y1));
            NotifyPropertyChanged(nameof(X2));
            NotifyPropertyChanged(nameof(Y2));
            NotifyPropertyChanged(nameof(XPos));
            NotifyPropertyChanged(nameof(YPos));
            NotifyPropertyChanged(nameof(Label));
        }
    }
}
