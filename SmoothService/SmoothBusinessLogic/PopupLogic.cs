using Newtonsoft.Json;
using SmoothDataLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothBusinessLogic
{
    public class PopupLogic
    {
        private PopupDAO _popupDAO;
        const string IMAGE_FOLDER = @"D:\Images\";
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmployeeLogic));

        public PopupLogic()
        {
            _popupDAO = new PopupDAO();
        }

        public int AddNewPopupLogic(string stringJSON)
        {
            try
            {
                log.Info("BusinessLogic => AddPopup - Begin");
                PopupModel productModel = JsonConvert.DeserializeObject<PopupModel>(stringJSON);
                //TODO Printer ID

                List<string> lstName = new List<string>();
                List<float> lstPrice = new List<float>();
                List<string> lstImageBase64 = new List<string>();
                List<string> lstImagePath = new List<string>();



                for (int i = 0; i < productModel.ListSubPopup.Count; i++)
                {
                    lstName.Add(productModel.ListSubPopup[i].Name);
                    lstPrice.Add(productModel.ListSubPopup[i].Price);
                    lstImageBase64.Add(productModel.ListSubPopup[i].Image64);
                }


                if (!Directory.Exists(IMAGE_FOLDER))
                {
                    Directory.CreateDirectory(IMAGE_FOLDER);
                }

                string imagePath;

                for (int i = 0; i < lstImageBase64.Count; i++)
                {
                    if(lstImageBase64[i] == "")
                    {
                        lstImagePath.Add(@"Resources/Images/Icons/Cancel.png");
                        continue;
                    }

                    long GUID = DateTime.Now.Ticks;
                    Image image = ConvertImage.StringToImage(lstImageBase64[i]);

                    Bitmap bitmap = new Bitmap(image);

                    imagePath = IMAGE_FOLDER + GUID + "_" + i + ".jpg";
                    bitmap.Save(imagePath);
                    lstImagePath.Add(imagePath);
                }

                return _popupDAO.AddPopup(productModel.Name, lstName, lstPrice, lstImagePath);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddProduct" + ex.Message);
                return -1;
            }
        }
    }
}
