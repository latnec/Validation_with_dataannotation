using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

using Project.DesktopClient.ViewModels;
using Project.DesktopClient.Views;

namespace Project.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow window = new MainWindow
            {
                DataContext = new CustomerViewModel { CustomerName = "Jane Doe" }
            };
            window.ShowDialog();
        }
    }
}
