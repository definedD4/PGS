using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGS.UtilTests
{
    public class SampleChangeNotifier : INotifyPropertyChanged
    {
        public int SampleProperty => 1;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SampleProperty)));
        }
    }
}
