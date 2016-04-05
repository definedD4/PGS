using PGS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGS.Core
{
    public class Angle : GeoElement
    {
        public Angle(Point left, Point center, Point right)
        {
            Left = left;
            Center = center;
            Right = right;
        }

        private Point m_Left;
        public Point Left
        {
            get { return m_Left; }
            set
            {
                m_Left = value;
                NotifyPropertyChanged(nameof(Left));
                m_Left.PropertyChanged += (s, e) =>
                {
                    NotifyPropertyChanged(nameof(ToLeft));
                    NotifyPropertyChanged(nameof(ToRight));
                    NotifyPropertyChanged(nameof(Radians));
                };
            }
        }

        private Point m_Center;
        public Point Center
        {
            get { return m_Center; }
            set
            {
                m_Center = value;
                NotifyPropertyChanged(nameof(Center));
                m_Center.PropertyChanged += (s, e) =>
                {
                    NotifyPropertyChanged(nameof(ToLeft));
                    NotifyPropertyChanged(nameof(ToRight));
                    NotifyPropertyChanged(nameof(Radians));
                };
            }
        }

        private Point m_Right;
        public Point Right
        {
            get { return m_Right; }
            set
            {
                m_Right = value;
                NotifyPropertyChanged(nameof(Right));
                m_Right.PropertyChanged += (s, e) =>
                {
                    NotifyPropertyChanged(nameof(ToLeft));
                    NotifyPropertyChanged(nameof(ToRight));
                    NotifyPropertyChanged(nameof(Radians));
                };
            }
        }

        public Vec2 ToLeft => Left.Pos - Center.Pos;
        public Vec2 ToRight => Right.Pos - Center.Pos;

        public Vec2 InMiddle => Vec2.Average(ToLeft, ToRight);

        /// <summary>
        /// Value of angle in radians.
        /// </summary>
        public double Radians => ToLeft ^ ToRight;
    }
}
