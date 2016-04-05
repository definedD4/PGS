using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGS.UI
{
    public class DisplaySegment : PropertyChangedNotifier, IDispalyElement
    {
        public int ZIndex => 1;

        private DisplayPoint p_Point1;

        public DisplayPoint Point1
        {
            get { return p_Point1; }
            set
            {
                p_Point1 = value;
                p_Point1.PropertyChanged += (s, e) =>
                {
                    NotifyPropertyChanged(nameof(X1));
                    NotifyPropertyChanged(nameof(Y1));
                    NotifyPropertyChanged(nameof(LabelX));
                    NotifyPropertyChanged(nameof(LabelY));
                    NotifyPropertyChanged(nameof(LabelText));
                };
            }
        }

        private DisplayPoint p_Point2;

        public DisplayPoint Point2
        {
            get { return p_Point2; }
            set
            {
                p_Point2 = value;
                p_Point2.PropertyChanged += (s, e) =>
                {
                    NotifyPropertyChanged(nameof(X2));
                    NotifyPropertyChanged(nameof(Y2));
                    NotifyPropertyChanged(nameof(LabelX));
                    NotifyPropertyChanged(nameof(LabelY));
                    NotifyPropertyChanged(nameof(LabelText));
                };
            }
        }

        public double X1 => Point1.XPos + 3.5;
        public double Y1 => Point1.YPos + 3.5;
        public double X2 => Point2.XPos + 3.5;
        public double Y2 => Point2.YPos + 3.5;

        public double LabelX => (X1 + X2) / 2;
        public double LabelY => (Y1 + Y2) / 2;
        public string LabelText => (Point2.Point.Postion - Point1.Point.Postion).Length.ToString();

    }
}
