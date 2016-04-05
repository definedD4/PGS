using PGS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGS.UI
{
    public class SegmentProperties : ElementPropertiesBase
    {
        private SegmentDisplay m_Segment;

        public SegmentProperties(SegmentDisplay segment)
        {
            m_Segment = segment;

            m_Label = new Propagate<string>(() => m_Segment.Point1.Label + m_Segment.Point2.Label,
                nameof(Label), this, m_Segment.Point1, m_Segment.Point2);

            m_Point1Label = new Propagate<string>(() => m_Segment.Point1.Label,
                nameof(Point1Label), this, m_Segment.Point1);

            m_Point2Label = new Propagate<string>(() => m_Segment.Point2.Label,
                nameof(Point2Label), this, m_Segment.Point2);

            m_Length = new Propagate<string>(() => m_Segment.Label,
                nameof(Length), this, m_Segment);
        }

        private Propagate<string> m_Label;
        public string Label => m_Label.Evaluate();

        private Propagate<string> m_Point1Label;
        public string Point1Label => m_Point1Label.Evaluate();

        private Propagate<string> m_Point2Label;
        public string Point2Label => m_Point2Label.Evaluate();

        private Propagate<string> m_Length;
        public string Length => m_Length.Evaluate();

        public DelegateCommand RemoveCmd => new DelegateCommand(x => m_Segment.Remove());
    }
}
