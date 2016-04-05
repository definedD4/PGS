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
    /// Логика взаимодействия для DisplayPointControl.xaml
    /// </summary>
    public partial class DisplayPointControl : UserControl
    {
        private bool m_Captured = false;
        private Point m_LastMousePos;

        public DisplayPointControl()
        {
            InitializeComponent();
        }

        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            m_Captured = true;
            m_LastMousePos = Mouse.GetPosition(Application.Current.MainWindow);

            (DataContext as ElementDisplayBase)?.OnElementSelected();
        }

        private void Control_MouseUp(object sender, MouseButtonEventArgs e)
        {
            m_Captured = false;
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_Captured)
            {
                MovePoint();
            }
        }

        private void Control_OnMouseLeave(object sender, MouseEventArgs e)
        {
            if (m_Captured)
            {
                MovePoint();

                if (Mouse.LeftButton == MouseButtonState.Released)
                {
                    m_Captured = false;
                }
            }
        }

        private void Control_MouseEnter(object sender, MouseEventArgs e)
        {
            if (m_Captured)
            {
                if (Mouse.LeftButton == MouseButtonState.Released)
                {
                    m_Captured = false;
                }
            }
        }

        private void MovePoint()
        {
            Vector mouseDelta;
            do
            {
                Point newMousePos = Mouse.GetPosition(Application.Current.MainWindow);
                mouseDelta = newMousePos - m_LastMousePos;
                m_LastMousePos = newMousePos;
                (DataContext as PointDisplay)?.Move(mouseDelta);
                (DataContext as PointDisplay)?.NotifyChanged();
            } while (mouseDelta.X != 0 && mouseDelta.Y != 0);
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            (DataContext as PointDisplay).Point.OnForcesApply += (s, ea) => {
                if (m_Captured)
                {
                    if (Mouse.LeftButton == MouseButtonState.Released)
                    {
                        m_Captured = false;
                    }
                    else
                    {
                        MovePoint();
                    }
                }
            };
        }
    }
}
