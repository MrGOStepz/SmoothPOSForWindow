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

namespace SmoothPOS
{
    /// <summary>
    /// Interaction logic for TableDialog.xaml
    /// </summary>
    public partial class TableDialog : Window
    {
        public string ReturnValue { get; set; }

        public TableDialog()
        {
            InitializeComponent();
        }

        private void BtnAddName_Click(object sender, RoutedEventArgs e)
        {
            this.ReturnValue = txtTableName.Text;
            this.Close();
        }
    }
}
