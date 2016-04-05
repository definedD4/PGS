using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGS.Util;

namespace PGS.Core
{
    public class Segment : GeoElement
    {
        public Segment(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        private Point m_Point1;
        public Point Point1
        {
            get { return m_Point1; }
            set
            {
                m_Point1 = value;
                m_Point1.PropertyChanged += (s, e) => NotifyChanged();
                NotifyChanged();
            }
        }

        private Point m_Point2;
        public Point Point2
        {
            get { return m_Point2; }
            set
            {
                m_Point2 = value;
                m_Point2.PropertyChanged += (s, e) => NotifyChanged();
                NotifyChanged();
            }
        }

        public void NotifyChanged()
        {
            NotifyPropertyChanged(nameof(Point1));
            NotifyPropertyChanged(nameof(Point2));
            NotifyPropertyChanged(nameof(From1To2));
            NotifyPropertyChanged(nameof(From2To1));
            NotifyPropertyChanged(nameof(Length));
            NotifyPropertyChanged(nameof(Middle));
        }

        public Vec2 From1To2 => Point2.Pos - Point1.Pos;
        public Vec2 From2To1 => Point1.Pos - Point2.Pos;
        public double Length => From1To2.Length;

        public Vec2 Middle => Vec2.Average(Point1.Pos, Point2.Pos);
    }
}
