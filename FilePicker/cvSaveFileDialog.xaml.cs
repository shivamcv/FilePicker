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
using System.Windows.Shapes;

namespace FilePicker
{
    /// <summary>
    /// Interaction logic for cvSaveFileDialog.xaml
    /// </summary>
    public partial class cvSaveFileDialog : Window
    {
        public cvSaveFileDialog()
        {
            InitializeComponent();
            Height = SystemParameters.PrimaryScreenHeight - 200;
            Width = SystemParameters.PrimaryScreenWidth - 200;
        }
    }
}
