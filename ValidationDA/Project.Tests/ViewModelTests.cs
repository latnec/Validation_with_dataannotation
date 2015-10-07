using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Project.DesktopClient.ViewModels;
using Project.Windows;

namespace Project.Tests
{
    [TestClass]
    public class ViewModelTests
    {
        [TestMethod]
        public void IsAbstactBaseClass()
        {
            Type t = typeof(ViewModel);
            Assert.IsTrue(t.IsAbstract);
        }

        [TestMethod]
        public void IsDataErrorInfo()
        {
            Assert.IsTrue(typeof(IDataErrorInfo).IsAssignableFrom(typeof(ViewModel)));
        }

        [TestMethod]
        public void IsObservableObject()
        {
            Assert.IsTrue(typeof(ObservableObject).IsAssignableFrom(typeof(ViewModel)));
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void IDataErrorInfo_ErrorProperty_IsNotSupported()
        {
            var _viewModel = new StubViewModel();
            var value = _viewModel.Error;
        }

        [TestMethod]
        public void IndexedPropertyValidatesPropertyNameWithInvalidValue()
        {
            var _viewModel = new StubViewModel();
            Assert.IsNotNull(_viewModel["RequiredProperty"]);
        }

        [TestMethod]
        public void IndexerPropertyValidatesPropertyNameWithValidValue()
        {
            var _viewModel = new StubViewModel { RequiredProperty = "Somevalue" };
            Assert.IsNull(_viewModel["RequiredProperty"]);
        }

        class StubViewModel : ViewModel
        {
            [Required]
            public string RequiredProperty { get; set; }
        }
    }
}
