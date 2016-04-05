using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGS.Core;
using Wnd = System.Windows;

namespace PGS.UI
{
    public class DisplayPoint : PropertyChangedNotifier, IDispalyElement
    {
        public int ZIndex => 2;

        public Point Point { get; set; }

        public string Label { get; set; }

        public double XPos => Point.Postion.X;
        public double YPos => Point.Postion.Y;

        public void Move(Wnd.Vector delta)
        {
            Point.Postion += new Util.Vec2(delta.X, delta.Y);
            NotifyPropertyChanged(nameof(XPos));
            NotifyPropertyChanged(nameof(YPos));
        }
    }
}
