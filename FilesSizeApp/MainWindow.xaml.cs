using FilesSizeApp.Services;
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
using System.Windows.Forms;
using System.IO;
using FilesSizeApp.Models;
using System.Xml.Serialization;
using System.Threading;

namespace FilesSizeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SizeService _sizeService;
        private string _viewData;
        private object obj = new object();
        public MainWindow(SizeService service)
        {
            _sizeService = service;
            InitializeComponent();
        }

        private void ChooseFolder(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            var dialogResult = dialog.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                SizesTextBox.Text = "";
                _sizeService.SetFolder(dialog.SelectedPath);
                ViewData();
                _sizeService.MakeXml();
            }
        }
        private void ViewOnTextBox(string size, string path)
        {
            _viewData = path + " " + size + " byte\n";
            SizesTextBox.AppendText(_viewData);
        }
        private void ViewData()
        {
            _sizeService.FolderSizesPrint(ViewOnTextBox);
        }
    }
}
