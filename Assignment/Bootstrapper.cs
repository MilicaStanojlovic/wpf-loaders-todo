using Assignment.ViewModels;
using Caliburn.Micro;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Assignment
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            await DisplayRootViewForAsync<ShellViewModel>();
            Application.Current.MainWindow.Title = "TBP Software";
        }
    }
}
