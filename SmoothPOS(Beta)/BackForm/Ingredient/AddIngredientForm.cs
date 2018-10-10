using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmoothPOS_Beta_
{
    public partial class AddIngredientForm : Form
    {
        public AddIngredientForm()
        {
            InitializeComponent();
        }

        private void btnUploadImage_Click(object sender, EventArgs e)
        {
            var thread = new Thread(ShowOpenDialog);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        private void ShowOpenDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
                pbImage.Image = new Bitmap(ofd.FileName);
                pbImage.Tag = ofd.FileName.ToString();
            }
            ofd = null;
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {

        }
    }
}
