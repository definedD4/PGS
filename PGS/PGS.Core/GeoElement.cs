using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGS.Core.Constraints;
using PGS.Util;

namespace PGS.Core
{
    public abstract class GeoElement : PropertyChangedNotifier
    {
        public List<IConstraint> Constraints { get; } = new List<IConstraint>();
    }
}
