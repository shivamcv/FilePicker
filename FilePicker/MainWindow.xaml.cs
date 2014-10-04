using Microsoft.Win32;
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

namespace FilePicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dig = new OpenFileDialog();
            dig.Multiselect = true;

            
            if(dig.ShowDialog() == true)
            {
                output.Text = string.Join(",", dig.FileNames);
            }
        }

        private void cvButton_Click(object sender, RoutedEventArgs e)
        {
            cvOpenFileDialog dig = new cvOpenFileDialog();
            dig.Multiselect = true;


            if (dig.ShowDialog() == true)
            {
                output.Text = string.Join(",", dig.FileNames);
            }
        }
    }
}
