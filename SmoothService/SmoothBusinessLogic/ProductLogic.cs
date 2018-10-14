using Newtonsoft.Json;
using SmoothDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothBusinessLogic
{
    public class ProductLogic
    {
        private ProductDAO _productDAO;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmployeeLogic));

        public ProductLogic()
        {
            _productDAO = new ProductDAO();
        }

        public int AddProductLogic(string stringJSON)
        {
            try
            {
                log.Info("BusinessLogic => AddProduct - Begin");
                ProductModel productModel = JsonConvert.DeserializeObject<ProductModel>(stringJSON);
                return _productDAO.AddProduct(productModel.Name, productModel.ShortName, productModel.Description, productModel.PopupID, productModel.Price, productModel.Stock, productModel.Avaliable, productModel.ProductOfIngredientID, productModel.ImagePath);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddProduct" + ex.Message);
                return -1;
            }
        }

        public int UpdateProductLogic(string stringJSON)
        {
            try
            {
                log.Info("BusinessLogic => Update Product - Begin");
                ProductModel productModel = JsonConvert.DeserializeObject<ProductModel>(stringJSON);
                return _productDAO.UpdateProduct(productModel.ProductID, productModel.Name, productModel.ShortName, productModel.Description, productModel.PopupID, productModel.Price, productModel.Stock, productModel.Avaliable, productModel.ProductOfIngredientID, productModel.ImagePath);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => UpdateProduct" + ex.Message);
                return -1;
            }
        }
    }
}
