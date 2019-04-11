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
            if(dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                _sizeService.SetFolder(dialog.SelectedPath);
                await ViewData();
            }
        }
        private void ViewOnTextBox(long number)
        {
            SizesTextBox.Text += number.ToString() + "\n";
        }
        private async Task ViewData()
        {
            await _sizeService.FolderSizesPrint(ViewOnTextBox);
        }
    }
}
