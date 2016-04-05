using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGS.Core;
using PGS.Core.Constraints;
using PGS.Util;

namespace PGS.UI.Model
{
    public class DisplayContext
    {
        public DisplayContext()
        {
            Elements.CollectionChanged += (s, e) =>
            {
                if (e.NewItems != null)
                {
                    foreach (var i in e.NewItems)
                    {
                        ((ElementDisplayBase)i).ElementSelected += (sender, args) => ElementSelected(this, args);
                        ((ElementDisplayBase)i).RemoveRequested += (sender, args) => RemoveElement((ElementDisplayBase)sender);
                    }
                }
            };
        }

        public GeoContext GeoContext { get; private set; } = new GeoContext();

        public ObservableCollection<ElementDisplayBase> Elements { get; set; } = new ObservableCollection<ElementDisplayBase>();

        public void SimulateStep(double delta)
        {
            GeoContext.Step(delta);
            foreach (var elem in Elements)
            {
                elem.NotifyChanged();
            }
        }

        public Point CreatePoint(Vec2 pos, string label)
        {
            var p = new Point(pos);
            GeoContext.Points.Add(p);
            Elements.Add(new PointDisplay(p, label));
            return p;
        }

        public Segment CreateSegment(Point p1, Point p2)
        {
            var s = new Segment(p1, p2);
            Elements.Add(new SegmentDisplay(s, 
                Elements.Where(x => (x as PointDisplay)?.Element == p1).FirstOrDefault() as PointDisplay,
                Elements.Where(x => (x as PointDisplay)?.Element == p2).FirstOrDefault() as PointDisplay));
            return s;
        }

        public Angle CreateAngle(Point left, Point center, Point right)
        {
            var a = new Angle(left, center, right);
            Elements.Add(new AngleDisplay(a));
            return a;
        }

        public void RemoveElement(ElementDisplayBase element)
        {
            if (Elements.Contains(element))
            {
                Elements.Remove(element);
                foreach (var constraint in element.Element.Constraints)
                {
                    GeoContext.Constraints.Remove(constraint);
                }
                if (element is PointDisplay)
                {
                    var pnt = (PointDisplay)element;
                    List<ElementDisplayBase> removeList = new List<ElementDisplayBase>();
                    foreach (var e in Elements)
                    {
                        if (e is SegmentDisplay)
                        {
                            var s = (SegmentDisplay)e;
                            if (s.Segment.Point1 == pnt.Point || s.Segment.Point2 == pnt.Point)
                            {
                                removeList.Add(e);
                            }
                        }
                        else if (e is AngleDisplay)
                        {
                            var a = (AngleDisplay)e;
                            if (a.Angle.Left == pnt.Point || a.Angle.Center == pnt.Point || a.Angle.Right == pnt.Point)
                            {
                                removeList.Add(e);
                            }
                        }
                    }
                    foreach(var i in removeList)
                    {
                        RemoveElement(i);
                    }
                }
                else if (element is SegmentDisplay)
                {
                    var seg = (SegmentDisplay)element;
                    var pnts = new []{ seg.Segment.Point1, seg.Segment.Point2 };
                    foreach(var i in Elements.Where(x => pnts.Contains((x as AngleDisplay)?.Angle.Left) 
                                                      || pnts.Contains((x as AngleDisplay)?.Angle.Center) 
                                                      || pnts.Contains((x as AngleDisplay)?.Angle.Right)).ToList())
                    {
                        RemoveElement(i);
                    }
                }
            }
        }

        public void AddConstraint(IConstraint constraint)
        {
            GeoContext.Constraints.Add(constraint);
        }

        public event EventHandler<ElementSelectedEventArgs> ElementSelected;
    }
}
