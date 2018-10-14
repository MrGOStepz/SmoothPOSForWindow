using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmoothPOS_Beta_
{
    public partial class AddPopupForm : Form
    {


        private ImageList _imageList = new ImageList();

        public AddPopupForm()
        {
            InitializeComponent();
            InitializeValue();
        }

        private void InitializeValue()
        {
            txtPopupPrice.Text = "0.00";
            _imageList.ImageSize = new Size(50, 50);
        }


        private void AddPopupForm_Load(object sender, EventArgs e)
        {
            lsvSubPopup.View = View.Details;
            lsvSubPopup.GridLines = true;
            lsvSubPopup.FullRowSelect = true;

            //Add column header
            lsvSubPopup.Columns.Add("Image", 70);
            lsvSubPopup.Columns.Add("Name", 120);
            lsvSubPopup.Columns.Add("Price", 100);

        }

        private void btnAddPopupItem_Click(object sender, EventArgs e)
        {
            string ImageKey = null;

            if (pbImage.Image != null)
            {
                _imageList.Images.Add(pbImage.Tag.ToString(), pbImage.Image);
                ImageKey = pbImage.Tag.ToString();
            }
            else
            {
                Image img = Image.FromFile(@"Resources/Images/Icons/Cancel.png");
                ImageKey = "Cancel";
                _imageList.Images.Add("Cancel", img);
                img = null;
            }

            lsvSubPopup.SmallImageList = _imageList;

            ListViewItem lvItem = new ListViewItem();
            lvItem.Text = "";
            lvItem.SubItems.Add(txtSupPopupName.Text);
            lvItem.SubItems.Add(txtPopupPrice.Text);
            lvItem.ImageKey = ImageKey;

            lvItem.ImageIndex = _imageList.Images.Count -1;
            lsvSubPopup.Items.Add(lvItem);

            pbImage.Image = null;
        }

        //TODO DELTE
        //private void Test(PopupModel popList)
        //{
        //    ImageList imageLists = new ImageList();
        //    ListViewItem lstVItem;
        //    Image image;

        //    lsvTest.SmallImageList = imageLists;
        //    for (int i = 0; i < popList.ListSubPopup.Count; i++)
        //    {
        //        lstVItem = new ListViewItem();
        //        lstVItem.Text = "";

        //        image = ConvertImage.StringToImage(popList.ListSubPopup[i].Image64);

        //        imageLists.Images.Add("Cancel", image);
        //        lstVItem.ImageKey = "Cancel";
        //        lstVItem.ImageIndex = imageLists.Images.Count - 1;

        //        lsvTest.Items.Add(lstVItem);
        //    }

        //}

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

        private void btnRSelect_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem eachItem in lsvSubPopup.SelectedItems)
            {
                lsvSubPopup.Items.Remove(eachItem);
            }
        }

        private void btnAddPopup_Click(object sender, EventArgs e)
        {
            int index = 0, i =0;
            PopupModel popupModel = new PopupModel();
            ListPopup listPopup;
            popupModel.Name = txtPopName.Text;
            Image tempImage;

            foreach (ListViewItem eachItem in lsvSubPopup.Items)
            {
                
                listPopup = new ListPopup();
                listPopup.Name = eachItem.SubItems[1].Text;
                listPopup.Price = float.Parse(eachItem.SubItems[2].Text);
                index = i;
                tempImage = _imageList.Images[index];

                Bitmap bitmap = new Bitmap(_imageList.Images[index]);

                if (tempImage != null)
                    listPopup.Image64 = ConvertImage.ImageToString(bitmap);
                else
                    listPopup.Image64 = "";

                popupModel.ListSubPopup.Add(listPopup);

                i++;
            }

            string JSON = JsonConvert.SerializeObject(popupModel);
            DatabaseHandle databaseHandle = new DatabaseHandle();

            if(databaseHandle.AddPopup(JSON) > 0)
            {
                MessageBox.Show("Add Popup Complete!", "Success", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Something wrong", "Fail", MessageBoxButtons.OK);
            }
        }



        private void txtPopupPrice_TextChanged(object sender, EventArgs e)
        {
            float priceInc;
            if (!float.TryParse(txtPopupPrice.Text, out priceInc))
            {
                MessageBox.Show("Price field is only number!");
                txtPopupPrice.Text = "0.00";
            }
        }
    }
}
