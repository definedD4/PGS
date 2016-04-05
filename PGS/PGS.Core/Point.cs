using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGS.Util;

namespace PGS.Core
{
    public class Point : GeoElement
    {
        public Point(Vec2 pos)
        {
            Pos = pos;
        }

        private Vec2 m_Pos;
        public Vec2 Pos {
            get { return m_Pos; }
            set {
                m_Pos = value;
                NotifyPropertyChanged(nameof(Pos));   
            }
        }

        public Vec2 Force { get; private set; } = new Vec2();

        public event EventHandler OnForcesApply;

        public void AddForce(Vec2 force)
        {
            Force += force;
            NotifyPropertyChanged(nameof(Force));
        }

        public void ApplyForces(double delta)
        {
            Pos += Force * delta;
            Force = new Vec2();

            OnForcesApply?.Invoke(this, null);
            NotifyPropertyChanged(nameof(Force));
        }
    }
}
