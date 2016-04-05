using System;
using System.Diagnostics.Contracts;
using System.Windows.Threading;

namespace PGS.UI
{
    public class Player
    {
        private Action m_Action;
        private DispatcherTimer m_Timer;

        public Player(Action action, TimeSpan interval)
        {
            m_Action = action;
            Playing = false;

            m_Timer = new DispatcherTimer();
            Interval = interval;

            m_Timer.Tick += (s, e) =>
            {
                if (Playing)
                {
                    m_Action();
                }
            };
        }

        public bool Playing { get; private set; }

        public TimeSpan Interval
        {
            get { return m_Timer.Interval; }
            set { m_Timer.Interval = value; }
        }

        public void Trigger()
        {
            if (!Playing)
            {
                m_Action();
            }
        }

        public void Play()
        {
            if (!Playing)
            {
                Playing = true;
                m_Timer.Start();
            }
        }

        public void Stop()
        {
            if (Playing)
            {
                Playing = false;
                m_Timer.Stop();
            }
        }
    }
}