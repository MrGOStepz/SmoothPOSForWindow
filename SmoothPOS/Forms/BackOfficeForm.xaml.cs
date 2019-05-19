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
    /// Interaction logic for BackOffice.xaml
    /// </summary>
    public partial class BackOfficeForm : Window
    {
        public BackOfficeForm()
        {
            InitializeComponent();
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            backOfficeMainForm.Children.Clear();
            AddProductControl addProductUC = new AddProductControl();
            backOfficeMainForm.Children.Add(addProductUC);
        }

        private void BtnSearchPopup_Click(object sender, RoutedEventArgs e)
        {
            backOfficeMainForm.Children.Clear();
            PopupSearchControl popupSearchUC = new PopupSearchControl();
            backOfficeMainForm.Children.Add(popupSearchUC);

        }

        private void BtnSearchProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAddPopup_Click(object sender, RoutedEventArgs e)
        {
            backOfficeMainForm.Children.Clear();
            AddPopupControl addPopupUC = new AddPopupControl();
            backOfficeMainForm.Children.Add(addPopupUC);
        }
    }
}
