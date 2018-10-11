using Newtonsoft.Json;
using SmoothDataLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothBusinessLogic
{
    public class PopupLogic
    {
        private PopupDAO _popupDAO;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmployeeLogic));

        public PopupLogic()
        {
            _popupDAO = new PopupDAO();
        }

        public int AddNewEmployeeLogic(string stringJSON)
        {
            try
            {
                log.Info("BusinessLogic => AddProduct - Begin");
                PopupModel productModel = JsonConvert.DeserializeObject<PopupModel>(stringJSON);
                //TODO Printer ID

                List<string> lstName = new List<string>();
                List<float> lstPrice = new List<float>();
                List<string> lstImagePatch = new List<string>();

                // Create sub directory
                if (!Directory.Exists(@"Images"))
                {
                    Directory.CreateDirectory(@"Images");
                }

                for (int i = 0; i < productModel.ListSubPopup.Count; i++)
                {
                    lstName.Add(productModel.ListSubPopup[i].Name);
                    lstPrice.Add(productModel.ListSubPopup[i].Price);

                }
                return _popupDAO.AddPopup(productModel.Name, productModel.ListSubPopup, productModel.Description, productModel.PopupID, productModel.Price, productModel.Stock, productModel.Avaliable, productModel.ProductOfIngredientID, productModel.ImagePath);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddProduct" + ex.Message);
                return -1;
            }
        }
    }
}
