using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
    /// Interaction logic for AddPopupControl.xaml
    /// </summary>
    public partial class AddPopupControl : UserControl
    {
        public List<PopupItems> _lstPopupItems = new List<PopupItems>();
        public BitmapImage _temp;
        public string _imagePath;

        public AddPopupControl()
        {
            InitializeComponent();         
            txtPopupName.Text = "";
            ReloadUI();
        }



        private void ReloadUI()
        {
            txtPopupItemName.Text = "";
            txtPrice.Text = "0";
            _imagePath = "";
            imgItem.Source = null;
        }

        private void ResetImage()
        {
            _temp = null;
            imgItem.Source = null;
        }

        private void BtnAddPopup_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnUploadImage_Click(object sender, RoutedEventArgs e)
        {
            //TODO Try Catch
            using (System.Windows.Forms.OpenFileDialog ofd = new System.Windows.Forms.OpenFileDialog())
            {
                ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ImageSource imageSource = new BitmapImage(new Uri(ofd.FileName));
                    _imagePath = ofd.FileName;
                    imgItem.Source = imageSource;
                }
            }
        }

        private void BtnClearImage_Click(object sender, RoutedEventArgs e)
        {
            ResetImage();
        }

        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            PopupItems popupItems = new PopupItems();

            popupItems.Name = txtPopupItemName.Text;
            //popupItems.ImageItem = imgItem;
            popupItems.ImagePath = _imagePath;
            popupItems.Price = float.Parse(txtPrice.Text);

            var data = new PopupItems { ImagePath = popupItems.ImagePath, Name = popupItems.Name, Price = popupItems.Price };

            dgvItems.Items.Add(data);

            _lstPopupItems.Add(popupItems);
            ReloadUI();
        }

        private void BtnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = dgvItems.SelectedItem;
            if (selectedItem != null)
            {
                _lstPopupItems.RemoveAt(dgvItems.SelectedIndex);
                dgvItems.Items.Remove(selectedItem);
                
            }

            for (int i = 0; i < _lstPopupItems.Count; i++)
            {
                Console.WriteLine(_lstPopupItems[i].Name);
            }
        }

        public class PopupItems
        {
            //public int Number { get; set; }
            public BitmapImage ImageItem { get; set; }
            public string ImagePath { get; set; }
            public string Name { get; set; }
            public float Price { get; set; }
        }

        private void TxtPrice_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPrice.Text == "")
                return;

            float priceInc;
            if (!float.TryParse(txtPrice.Text, out priceInc))
            {
                MessageBox.Show("Price field is only number!");
                txtPrice.Text = "0";
            }
        }
    }
}
