using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PGS.UI
{
    /// <summary>
    /// Логика взаимодействия для SegmentDisplayControl.xaml
    /// </summary>
    public partial class SegmentDisplayControl : UserControl
    {
        public SegmentDisplayControl()
        {
            InitializeComponent();
        }

        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            (DataContext as ElementDisplayBase)?.OnElementSelected();
        }
    }
}
