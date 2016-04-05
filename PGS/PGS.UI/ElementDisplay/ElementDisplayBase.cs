using PGS.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PGS.Core;

namespace PGS.UI
{
    public class ElementSelectedEventArgs : EventArgs
    {
        public ElementSelectedEventArgs(ElementDisplayBase elementDisplay)
        {
            ElementDisplay = elementDisplay;
        }

        public ElementDisplayBase ElementDisplay { get; }
    }

    public abstract class ElementDisplayBase : PropertyChangedNotifier
    {
        public abstract int ZIndex { get; }

        public abstract GeoElement Element { get; }

        public abstract void NotifyChanged();

        public event EventHandler<ElementSelectedEventArgs> ElementSelected;

        public void OnElementSelected()
        {
            ElementSelected?.Invoke(this, new ElementSelectedEventArgs(this));
        }

        public abstract ElementPropertiesBase GetProperties();

        public event EventHandler RemoveRequested;

        public void Remove()
        {
            RemoveRequested?.Invoke(this, null);
        }


    }
}
