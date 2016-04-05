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
using PGS.UI.Model;

namespace PGS.UI
{
    public enum DisplayTool
    {
        Edit,
        AddPoint
    }

    /// <summary>
    /// Interaction logic for DisplayControl.xaml
    /// </summary>
    public partial class DisplayControl : UserControl
    {
        private DisplayTool m_DisplayTool;

        public DisplayControl()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty DisplayContextProperty = DependencyProperty.Register(
            "DisplayContext", typeof (DisplayContext), typeof (DisplayControl), new PropertyMetadata(default(DisplayContext)));

        public DisplayContext DisplayContext
        {
            get { return (DisplayContext) GetValue(DisplayContextProperty); }
            set { SetValue(DisplayContextProperty, value); }
        }

        public DisplayTool DisplayTool
        {
            get { return m_DisplayTool; }
            set
            {
                if (m_DisplayTool != value)
                {
                    m_DisplayTool = value;
                    switch (m_DisplayTool)
                    {
                    case DisplayTool.Edit:
                        Cursor = Cursors.Arrow;
                        break;
                    case DisplayTool.AddPoint:
                        Cursor = Cursors.Pen;
                        break;
                    }
                }
            }
        }

        private void MouseClick(object sender, MouseButtonEventArgs e)
        {
            switch (DisplayTool)
            {
            case DisplayTool.AddPoint:
                DisplayContext.CreatePoint(Mouse.GetPosition(this).ToVec2(), "P");
                DisplayTool = DisplayTool.Edit;
                break;
            }
        }
    }
}
