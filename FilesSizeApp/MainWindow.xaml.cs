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
        public MainWindow(SizeService service)
        {
            _sizeService = service;
            InitializeComponent();
        }
        private async void ChooseFolder(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            var dialogResult = dialog.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            { 
                SizesTextBox.Text = "";
                await Dispatcher.InvokeAsync(() => FolderPath.Content = dialog.SelectedPath);                
                try
                {
                    _sizeService.SetFolder(dialog.SelectedPath);
                    await ViewData();
                    _sizeService.MakeXml();
                }
                catch (Exception ex)
                {
                    SizesTextBox.Text = ex.Message;
                }
            }
        }
        private async Task ViewOnTextBox(string size, string path)
        {
            await Dispatcher.InvokeAsync(() => SizesTextBox.AppendText( path + " " + size + " byte\n"));
        }
        private async Task ViewData()
        {
            await _sizeService.FolderSizesPrint(ViewOnTextBox);
        }
    }
}
