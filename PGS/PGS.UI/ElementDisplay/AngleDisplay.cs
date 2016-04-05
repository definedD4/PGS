using PGS.Core;
using PGS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wnd = System.Windows;

namespace PGS.UI
{
    public class AngleDisplay : ElementDisplayBase
    {
        public AngleDisplay(Angle angle)
        {
            Angle = angle;
        }

        public override int ZIndex => 2;
        public override GeoElement Element => Angle;

        public double ArcRadius => 10;

        private Angle m_Angle;
        public Angle Angle
        {
            get { return m_Angle; }
            set
            {
                m_Angle = value;
                NotifyPropertyChanged(nameof(Angle));
                m_Angle.PropertyChanged += (s, e) =>
                {
                    NotifyChanged();
                };
            }
        }

        public double XPos => Angle.Center.Pos.X + 3.5;
        public double YPos => Angle.Center.Pos.Y + 3.5;
        public Wnd.Point ArcStart => (Angle.ToRight.Normalized() * ArcRadius).ToWndPoint();
        public Wnd.Point ArcEnd => (Angle.ToLeft.Normalized() * ArcRadius).ToWndPoint();
        public Wnd.Size ArcSize => new Wnd.Size(ArcRadius * 2, ArcRadius * 2);

        public string Label => Math.Round(Angle.Radians * 180 / Math.PI, 2).ToString();

        public override void NotifyChanged()
        {
            NotifyPropertyChanged(nameof(XPos));
            NotifyPropertyChanged(nameof(YPos));
            NotifyPropertyChanged(nameof(ArcStart));
            NotifyPropertyChanged(nameof(ArcEnd));
            NotifyPropertyChanged(nameof(ArcSize));
            NotifyPropertyChanged(nameof(Label));
        }

        public override ElementPropertiesBase GetProperties() => null;
    }
}
