using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Project.Windows;


namespace Project.Tests
{
    [TestClass]
    public class ObservableObjectTests
    {
        [TestMethod]
        public void PropertyChangedEventHandler_IsRaised()
        {
            var obj = new StubObservableObject();
            bool raised = false;

            obj.PropertyChanged += (sender, e) =>
            {
                Assert.IsTrue(e.PropertyName == "ChangedProperty");
                raised = true;

            };

            obj.ChangedProperty = "Some value";

            if (!raised) Assert.Fail("PropertyChanged was never invoked.");


        }


        class StubObservableObject : ObservableObject
        {
            private string changedProperty;

            public string ChangedProperty
            {
                get
                {
                    return changedProperty;
                }
                set
                {
                    changedProperty = value;
                    NotifyPropertyChanged("ChangedProperty");

                }
            }
        }
    }
}
