using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PGS.Util;
using System.Linq.Expressions;

namespace PGS.UtilTests
{
    [TestClass]
    public class NotifyExprTest
    {
        private class SampleChangePropagator : PropertyChangedNotifier
        {
            public SampleChangeNotifier Notifier => new SampleChangeNotifier();

            private NotifyExpr<int> m_SampleProperty = new NotifyExpr<int>(this, nameof(SampleProperty),
                () => Notifier);
            public int SampleProperty => m_SampleProperty.Func();
        }

        [TestMethod]
        public void ConstantTest()
        {
            var p = new SampleChangePropagator();
            bool notified = false;
            p.PropertyChanged += (s, e) => { if (e.PropertyName == "SampleProperty") notified = true; };

            p.Notifier.NotifyPropertyChanged();

            Assert.IsTrue(notified);
        }
    }
}
