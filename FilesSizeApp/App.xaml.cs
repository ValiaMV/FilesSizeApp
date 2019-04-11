using FilesSizeApp.Interfaces;
using FilesSizeApp.Models;
using FilesSizeApp.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;

namespace FilesSizeApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            //make sure your container is configured
            container.RegisterType<IFolder, FolderDetails>();
            container.RegisterType<SizeService, SizeService>();
            container.RegisterType<MainWindow, MainWindow>();
            container.Resolve<MainWindow>().Show();
        }
    }
}
