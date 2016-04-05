using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGS.Util
{
    public class Propagate<T>
    {
        private Func<T> m_Function;
        private string m_PropertyName;
        private PropertyChangedNotifier m_Owner;
        private List<INotifyPropertyChanged> m_Sources;

        public Propagate(Func<T> function, string propertyName, PropertyChangedNotifier owner, params INotifyPropertyChanged[] sources)
        {
            m_Function = function;
            m_PropertyName = propertyName;
            m_Owner = owner;
            m_Sources = new List<INotifyPropertyChanged>(sources);
            foreach (var source in m_Sources)
            {
                source.PropertyChanged += OnSourcesChanged;
            }
        }

        public T Evaluate() => m_Function();

        protected void OnSourcesChanged(object sender, PropertyChangedEventArgs args)
        {
            if (sender == this && args.PropertyName == m_PropertyName) // to avoid infinite loops
                return;

            m_Owner.NotifyPropertyChanged(m_PropertyName);
        }
    }
}
