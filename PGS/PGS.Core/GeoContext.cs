using PGS.Core.Constraints;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGS.Core
{
    public class GeoContext
    {
        public GeoContext()
        {

        }

        public ObservableCollection<Point> Points { get; set; } = new ObservableCollection<Point>();
        public ObservableCollection<IConstraint> Constraints { get; set; } = new ObservableCollection<IConstraint>();

        public void Step(double delta)
        {
            foreach (var constr in Constraints)
            {
                constr.Apply();
            }
            foreach (var point in Points)
            {
                point.ApplyForces(delta);
            }
        }
    }
}
