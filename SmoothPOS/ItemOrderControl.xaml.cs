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

namespace SmoothPOS
{
    /// <summary>
    /// Interaction logic for ItemOrderControl.xaml
    /// </summary>
    public partial class ItemOrderControl : UserControl
    {
        public ItemOrderControl()
        {
            InitializeComponent();
        }

        private void BtnSetting_Click(object sender, RoutedEventArgs e)
        {
            lbComment.Content = "";
        }

        private void BtnIncrease_Click(object sender, RoutedEventArgs e)
        {
            int temp = int.Parse(txtTotal.Text);
            temp++;
            txtTotal.Text = temp.ToString();
        }

        private void BtnDecrease_Click(object sender, RoutedEventArgs e)
        {
            int temp = int.Parse(txtTotal.Text);
            temp--;
            txtTotal.Text = temp.ToString();
        }

        private void TxtTotal_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtTotal.Text == "")
                return;

            int totalItem;
            if (!int.TryParse(txtTotal.Text, out totalItem))
            {
                txtTotal.Text = "0";
            }
        }
    }
}
