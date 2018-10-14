using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmoothServer
{
    public partial class FormControl : Form
    {
        const string IMAGE_FOLDER = @"Images";

        public FormControl()
        {
            InitializeComponent();
            InitializeFolder();
        }

        private void InitializeFolder()
        {
            if (!Directory.Exists(IMAGE_FOLDER))
            {
                Directory.CreateDirectory(IMAGE_FOLDER);
            }
        }

        public void GenerateImageToFolder(List<string> lstImageBase64)
        {
            try
            {
                for (int i = 0; i < lstImageBase64.Count; i++)
                {
                    long GUID = DateTime.Now.Ticks;
                    Image image = ConvertImage.StringToImage(lstImageBase64[i]);

                    image.Save(IMAGE_FOLDER + "\\" + GUID + "_" + i);
                }
                

                return 1;
            }
            catch (Exception)
            {

                return -1;
            }            
        }


    }
}
