using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGS.UI
{
    public class PointProperties : ElementPropertiesBase
    {
        private PointDisplay m_Point;

        public PointProperties(PointDisplay point)
        {
            m_Point = point;
            m_Point.PropertyChanged += (s, e) => NotifyPropertyChanged(e.PropertyName);
        }

        public string XPos => Math.Round(m_Point.XPos, 2).ToString();
        public string YPos => Math.Round(m_Point.YPos, 2).ToString();

        public string Label
        {
            get { return m_Point.Label; }
            set { m_Point.Label = value; NotifyPropertyChanged(nameof(Label)); }
        }

        public DelegateCommand RemoveCmd => new DelegateCommand(x => m_Point.Remove());
    }
}
