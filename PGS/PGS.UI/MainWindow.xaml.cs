using PGS.Util;
using PGS.Core;
using System;
using System.Collections.ObjectModel;
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
using PGS.Core.Constraints;
using System.ComponentModel;
using System.Windows.Threading;
using PGS.UI.Model;

namespace PGS.UI
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        private double m_StepDelta = 0.1;

        private Player m_Player;
        private DisplayContext m_DisplayContext;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            m_Player = new Player(() => DisplayContext.SimulateStep(StepDelta), TimeSpan.FromMilliseconds(10));

            DisplayContext = new DisplayContext();
            DisplayContext.ElementSelected += (s, e) => ElementProperties = e.ElementDisplay.GetProperties();

            SelectToolCmd = new DelegateCommand(x => SelectTool((string)x));

            Demo();
        }

        public DisplayContext DisplayContext
        {
            get { return m_DisplayContext; }
            private set
            {
                m_DisplayContext = value;
                NotifyPropertyChanged(nameof(DisplayContext));
            }
        }

        private bool m_Simulate = false;
        public bool Simulate
        {
            get { return m_Simulate; }
            set
            {
                m_Simulate = value;
                if (m_Simulate)
                {
                    m_Player.Play();
                }
                else
                {
                    m_Player.Stop();
                }
                NotifyPropertyChanged(nameof(Simulate));
            }
        }

        public double StepDelta
        {
            get { return m_StepDelta; }
            set
            {
                m_StepDelta = value;
                NotifyPropertyChanged(nameof(StepDelta));
            }
        }

        public DelegateCommand SelectToolCmd { get; private set; }

        private ElementPropertiesBase m_ElementProperties;
        public ElementPropertiesBase ElementProperties
        {
            get { return m_ElementProperties; }
            set { m_ElementProperties = value;  NotifyPropertyChanged(nameof(ElementProperties)); }
        }

        private void StepButton_Click(object sender, RoutedEventArgs e)
        {
            m_Player.Trigger();
        }

        private void SelectTool(string tool)
        {
            switch (tool)
            {
                case "edit":
                    DisplayControl.DisplayTool = DisplayTool.Edit;
                    break;
                case "point":
                    DisplayControl.DisplayTool = DisplayTool.AddPoint;
                    break;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Demo()
        {
            var a = DisplayContext.CreatePoint(new Vec2(300, 200), "A");
            var b = DisplayContext.CreatePoint(new Vec2(200, 300), "B");
            var c = DisplayContext.CreatePoint(new Vec2(250, 350), "C");

            var ab = DisplayContext.CreateSegment(a, b);
            var ac = DisplayContext.CreateSegment(a, c);
            var bc = DisplayContext.CreateSegment(b, c);

            var bac = DisplayContext.CreateAngle(b, a, c);

            DisplayContext.AddConstraint(new LengthConstraint(ab, 120));
            DisplayContext.AddConstraint(new LengthConstraint(ac, 160));
            DisplayContext.AddConstraint(new AngleConstraint(bac, Math.PI / 2));
        }
    }
}
