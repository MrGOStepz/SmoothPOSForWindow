﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SmoothDataBaseControl
{
    public class BusinessLogic
    {
        private EmployeeDAO _employeeDAO;
        private PopupDAO _popupDAO;
        private ProductDAO _productDAO;

        public BusinessLogic()
        {
            _employeeDAO = new EmployeeDAO();
            _popupDAO = new PopupDAO();
            _productDAO = new ProductDAO();
        }
        

        #region Employee
        

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(BusinessLogic));



        public int AddNewEmployeeLogic(string stringJSON)
        {
            try
            {
                log.Info("BusinessLogic => AddNewEmplouee - Begin");
                EmployeeModel employeeModel = JsonConvert.DeserializeObject<EmployeeModel>(stringJSON);
                return _employeeDAO.AddNewEmployee(employeeModel.FirstName, employeeModel.LastName, employeeModel.Phone, employeeModel.Email, employeeModel.Password);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddNewEmployee" + ex.Message);
                return -1;
            }
        }

        public int UpdateEmployeeLogic(string stringJSON)
        {
            log.Info("BusinessLogic -- UpdateEmployee");
            try
            {
                EmployeeModel employeeModel = JsonConvert.DeserializeObject<EmployeeModel>(stringJSON);
                if (employeeModel.EmployeeID == 0)
                {
                    log.Info("BusinessLogic => UpdateEmployeeProfile, EmployeeID == 0");
                    return 0;
                }
                else
                    return _employeeDAO.UpdateProfileEmployee(employeeModel.EmployeeID, employeeModel.FirstName, employeeModel.LastName, employeeModel.NickName, employeeModel.Phone, employeeModel.Email, employeeModel.Password);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddNewEmployee" + ex.Message);
                return -1;
            }
        }

        public string GetListOfEmployeeLogic()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = _employeeDAO.GetListOfEmployee();

                //Convert DataTable to JSON
                //Add Refernces System.Web.Extension
                //Import using System.Web.Script.Serialization;
                JavaScriptSerializer serializer = new JavaScriptSerializer();

                List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
                Dictionary<string, object> row;
                foreach (DataRow dr in dt.Rows)
                {
                    row = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        row.Add(col.ColumnName, dr[col]);
                    }
                    rows.Add(row);
                }

                //Return to JSON format
                //return JsonConvert.SerializeObject(rows);
                return serializer.Serialize(rows);
            }
            catch (Exception ex)
            {
                log.Error("BussinessLogic => GetListOfEmployeeLogic()" + ex.Message);
                return null;
            }
        }

        public string GetEmployeeDetailByPassword(string Password)
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                DataTable dataTable = new DataTable();
                dataTable = _employeeDAO.GetEmployeeDetailByPassword(Password);

                if (dataTable != null)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        employeeModel = new EmployeeModel();
                        employeeModel.EmployeeID = (int)row["employee_id"];
                        employeeModel.FirstName = row["first_name"].ToString();
                        employeeModel.LastName = row["last_name"].ToString();
                        employeeModel.Phone = row["phone"].ToString();
                        employeeModel.Email = row["email"].ToString();
                        employeeModel.StatusID = (int)row["status_id"];
                        employeeModel.LevelID = (int)row["level_id"];
                    }

                    string stringJSON = JsonConvert.SerializeObject(employeeModel);

                    return stringJSON;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => GetEmployeeDetailByPassword" + ex.Message);
                return null;
            }
        }
        #endregion

        #region Popup
        
        const string IMAGE_FOLDER = @"C:\Images\";

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
                    if (lstImageBase64[i] == "")
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

        public int UpdatePopup(string stringJSON)
        {
            try
            {
                PopupModel popupModel = JsonConvert.DeserializeObject<PopupModel>(stringJSON);

                List<int> lstSubpPopupID = new List<int>();
                List<string> lstSubPopupName = new List<string>();
                List<float> lstSubPopupPrice = new List<float>();
                List<string> lstSubpopupImagePath = new List<string>();

                lstSubpPopupID = popupModel.ListSubPopup.Select(x => x.SubPopUpID).ToList();
                lstSubPopupName = popupModel.ListSubPopup.Select(x => x.Name).ToList();
                lstSubPopupPrice = popupModel.ListSubPopup.Select(x => x.Price).ToList();
                lstSubpopupImagePath = popupModel.ListSubPopup.Select(x => x.Image64).ToList();

                return _popupDAO.UpdatePopup(popupModel.PopupID, popupModel.Name, lstSubpPopupID, lstSubPopupName, lstSubPopupPrice, lstSubpopupImagePath);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddProduct" + ex.Message);
                return -1;
            }
        }

        public int DeletePopup(int PopupID)
        {
            try
            {
                if (PopupID != 1)
                {
                    return _popupDAO.DeletePopup(PopupID);
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => DeletePopup" + ex.Message);
                return -1;
            }
        }

        public string GetListOfPopup()
        {
            try
            {
                DataTable dt = new DataTable();
                List<PopupModel> lstPopupModel = new List<PopupModel>();
                PopupModel popupModel = new PopupModel();
                dt = _popupDAO.GetListOfPopup();

                foreach (DataRow row in dt.Rows)
                {
                    popupModel = new PopupModel();
                    popupModel.PopupID = (int)row["popup_id"];
                    popupModel.Name = row["name"].ToString();

                    lstPopupModel.Add(popupModel);
                }

                string stringJSON = JsonConvert.SerializeObject(lstPopupModel);

                return stringJSON;
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddProduct" + ex.Message);
                return null;
            }
        }

        public string GetListOfPopupFilter(string name)
        {
            try
            {
                DataTable dt = new DataTable();
                List<PopupModel> lstPopupModel = new List<PopupModel>();
                PopupModel popupModel = new PopupModel();
                dt = _popupDAO.GetListOfPopupFilter(name);

                foreach (DataRow row in dt.Rows)
                {
                    popupModel = new PopupModel();
                    popupModel.PopupID = (int)row["popup_id"];
                    popupModel.Name = row["name"].ToString();

                    lstPopupModel.Add(popupModel);
                }

                string stringJSON = JsonConvert.SerializeObject(lstPopupModel);

                return stringJSON;
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddProduct" + ex.Message);
                return null;
            }
        }

        public string GetPopupDetail(int PopupID)
        {
            try
            {
                List<DataTable> lstDataTables = new List<DataTable>();
                List<ListPopup> lstPopup = new List<ListPopup>();
                ListPopup popupDetail = new ListPopup();
                PopupModel popupModel = new PopupModel();

                lstDataTables = _popupDAO.GetPopupDetail(PopupID);

                //lstDataTables Index 0 = Main Popup
                foreach (DataRow row in lstDataTables[0].Rows)
                {
                    popupModel = new PopupModel();
                    popupModel.PopupID = (int)row["popup_id"];
                    popupModel.Name = row["name"].ToString();

                }

                //lstDataTables Index 1 = Sup Popup
                foreach (DataRow row in lstDataTables[1].Rows)
                {
                    lstPopup = new List<ListPopup>();
                    popupDetail = new ListPopup();

                    popupDetail.SubPopUpID = (int)row["popup_item_id"];
                    popupDetail.Name = row["name"].ToString();
                    popupDetail.Price = (float)row["price"];
                    popupDetail.Image64 = row["image_path"].ToString();
                    lstPopup.Add(popupDetail);
                }

                popupModel.ListSubPopup = new List<ListPopup>();
                popupModel.ListSubPopup = lstPopup;

                string stringJSON = JsonConvert.SerializeObject(popupModel);

                return stringJSON;
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddProduct" + ex.Message);
                return null;
            }
        }
        #endregion

        #region Product
        

        public int AddProductLogic(string stringJSON)
        {
            try
            {
                log.Info("BusinessLogic => AddProduct - Begin");
                ProductModel productModel = JsonConvert.DeserializeObject<ProductModel>(stringJSON);
                return _productDAO.AddProduct(productModel.Name, productModel.ShortName, productModel.Description, productModel.PopupID, productModel.Price, productModel.Stock, productModel.Avaliable, productModel.ProductOfIngredientID, productModel.TypeOfFood, productModel.ImagePath);
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
                return _productDAO.UpdateProduct(productModel.ProductID, productModel.Name, productModel.ShortName, productModel.Description, productModel.PopupID, productModel.Price, productModel.Stock, productModel.Avaliable, productModel.ProductOfIngredientID, productModel.TypeOfFood, productModel.ImagePath);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => UpdateProduct" + ex.Message);
                return -1;
            }
        }
        #endregion

    }
}