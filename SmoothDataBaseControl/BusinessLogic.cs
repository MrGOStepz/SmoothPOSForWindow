using Newtonsoft.Json;
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
        private TableDAO _tableDAO;
        private LocationDAO _locationDAO;
        private PrinterDAO _printerDAO;
        
        public BusinessLogic()
        {
            _employeeDAO = new EmployeeDAO();
            _popupDAO = new PopupDAO();
            _productDAO = new ProductDAO();
            _tableDAO = new TableDAO();
            _locationDAO = new LocationDAO();
            _printerDAO = new PrinterDAO();
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

        public int UpdateStaffStatus(int staffID, int StatusID)
        {
            try
            {
                return _employeeDAO.UpdateStaffStatus(staffID, StatusID);
            }
            catch (Exception ex)
            {   

                return -1;
            }
        }

        public int CheckStaffStatus(int staffID)
        {
            try
            {
                return _employeeDAO.CheckStaffStatus(staffID);
            }
            catch (Exception ex)
            {

                return -1;
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

        #region Table And Section

        public int AddSectionTable(string Name)
        {
           try
           {
               log.Info("BusinessLogic => AddSectionTable - Begin");
               return _tableDAO.AddSectionTable(Name);
           }
           catch (Exception ex)
           {
               log.Error("BussicnessLogic => AddTable" + ex.Message);
               return -1;
           }
        }

        public int UpdateSectionTable(string stringJSON)
        {
           try
           { 
               log.Info("BusinessLogic => UpdateSectionTable - Begin");
               SectionModel sectionModel = JsonConvert.DeserializeObject<SectionModel>(stringJSON);
               return _tableDAO.UpdateSectiontable(sectionModel.SectionID, sectionModel.Name);
           }
           catch (Exception ex)
           {
               log.Error("BussicnessLogic => UpdateSectionTable" + ex.Message);
               return -1;
           }
        }

        public int RemoveSectionTable(int SectionID)
        {
            try
            {
                log.Info("BusinessLogic => UpdateSectionTable - Begin");
                return _tableDAO.RemoveSectionTable(SectionID);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => UpdateSectionTable" + ex.Message);
                return -1;
            }
        }

        public string GetListOfSection()
        {
            try
            {
                DataTable dt = new DataTable();
                List<SectionModel> lstSectionModel = new List<SectionModel>();
                SectionModel sectionModel = new SectionModel();
                dt = _tableDAO.GetListOfSection();

                foreach (DataRow row in dt.Rows)
                {
                    sectionModel = new SectionModel();
                    sectionModel.SectionID = (int)row["section_id"];
                    sectionModel.Name = row["name"].ToString();
                    sectionModel.IsActive = (int)row["is_active"];

                    lstSectionModel.Add(sectionModel);
                }

                string stringJSON = JsonConvert.SerializeObject(lstSectionModel);

                return stringJSON;
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => GetListOfTable" + ex.Message);
                return null;
            }
        }

        public int AddTable(string stringJSON)
        {
            try
            {
                log.Info("BusinessLogic => AddTable - Begin");
                TableModal tableModel = JsonConvert.DeserializeObject<TableModal>(stringJSON);

                return _tableDAO.AddTable(tableModel.uniName, tableModel.Name, tableModel.SectionID, tableModel.MarginTop, tableModel.MarginBottom, tableModel.MarginLeft, tableModel.MarginRight);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddTable" + ex.Message);
                return -1;
            }
        }

        public int UpdateTable(string stringJSON)
        {
            try
            {
                TableModal tableModel = JsonConvert.DeserializeObject<TableModal>(stringJSON);

                return _tableDAO.UpdateTable(tableModel.TableID, tableModel.MarginTop, tableModel.MarginBottom, tableModel.MarginLeft, tableModel.MarginRight);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => UpdateTable" + ex.Message);
                return -1;
            }
        }

        public int RemoveTable(int TableID)
        {
            try
            {
                return _tableDAO.RemoveTable(TableID);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => DeletePopup" + ex.Message);
                return -1;
            }
        }

        public string GetListOfTable()
        {
            try
            {
                DataTable dt = new DataTable();
                List<TableModal> lstTableModel = new List<TableModal>();
                TableModal tableModel = new TableModal();
                dt = _tableDAO.GetListTable();

                foreach (DataRow row in dt.Rows)
                {
                    tableModel = new TableModal();
                    tableModel.TableID = (int)row["table_section_id"];
                    tableModel.uniName = row["u_name"].ToString();
                    tableModel.Name = row["name"].ToString();
                    tableModel.SectionID = (int)row["section_id"];
                    tableModel.MarginTop = (float)row["margin_top"];
                    tableModel.MarginBottom = (float)row["margin_bottom"];
                    tableModel.MarginRight = (float)row["margin_right"];
                    tableModel.MarginLeft = (float)row["margin_left"];
                    tableModel.Height = (float)row["height"];
                    tableModel.Width = (float)row["width"];
                    tableModel.is_active = (int)row["is_active"];

                    lstTableModel.Add(tableModel);
                }

                string stringJSON = JsonConvert.SerializeObject(lstTableModel);

                return stringJSON;
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => GetListOfTable" + ex.Message);
                return null;
            }
        }
        #endregion

        #region Location Menu
        public int AddLocationTab(string Name)
        {
            try
            {
                log.Info("BusinessLogic => AddLocationTab - Begin");
                return _locationDAO.AddLocationTab(Name);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddLocationTab" + ex.Message);
                return -1;
            }
        }

        public int UpdateLocationTab(string stringJSON)
        {
            try
            {
                log.Info("BusinessLogic => UpdateLocationTab - Begin");
                LocationTab locationTabModel = JsonConvert.DeserializeObject<LocationTab>(stringJSON);
                return _locationDAO.UpdateLocationTab(locationTabModel.LocationTabID, locationTabModel.Name);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => UpdateLocationTab" + ex.Message);
                return -1;
            }
        }

        public int RemoveLocationTab(int LocationTabID)
        {
            try
            {
                log.Info("BusinessLogic => UpdateSectionTable - Begin");
                return _locationDAO.RemoveLocationTab(LocationTabID);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => UpdateSectionTable" + ex.Message);
                return -1;
            }
        }

        public string GetListOfLocationTab()
        {
            try
            {
                DataTable dt = new DataTable();
                List<LocationTab> lstlocationLab = new List<LocationTab>();
                LocationTab locationLab = new LocationTab();
                dt = _locationDAO.GetListOfLocationTab();

                foreach (DataRow row in dt.Rows)
                {
                    locationLab = new LocationTab();
                    locationLab.LocationTabID = (int)row["location_tab_id"];
                    locationLab.Name = row["name"].ToString();
                    locationLab.IsActive = (int)row["is_active"];

                    lstlocationLab.Add(locationLab);
                }

                string stringJSON = JsonConvert.SerializeObject(lstlocationLab);

                return stringJSON;
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => GetListOfLocationTab" + ex.Message);
                return null;
            }
        }

        public int AddLocationMenu(string stringJson)
        {
            try
            {
                log.Info("BusinessLogic => AddLocationMenu - Begin");
                LocationMenu locationMenu = JsonConvert.DeserializeObject<LocationMenu>(stringJson);

                return _locationDAO.AddLocationMenu(locationMenu.ProductID, locationMenu.LocationTabID, locationMenu.Column, locationMenu.Row);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddLocationMenu" + ex.Message);
                return -1;
            }
        }

        public int UpdateLocationMenu(string stringJson)
        {
            try
            {
                LocationMenu locationMenu = JsonConvert.DeserializeObject<LocationMenu>(stringJson);

                return _locationDAO.UpdateLocationMenu(locationMenu.LocationMenuID, locationMenu.ProductID, locationMenu.LocationTabID, locationMenu.Column, locationMenu.Row);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => UpdateTable" + ex.Message);
                return -1;
            }
        }

        public int RemoveLocationMenu(int LocationMenuID)
        {
            try
            {
                return _locationDAO.RemoveLocationMenu(LocationMenuID);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => DeletePopup" + ex.Message);
                return -1;
            }
        }

        public string GetListLocationMenu()
        {
            try
            {
                DataTable dt = new DataTable();
                List<LocationMenu> lstLocationMenu = new List<LocationMenu>();
                LocationMenu locationMenu = new LocationMenu();
                dt = _locationDAO.GetListLocationMenu();

                foreach (DataRow row in dt.Rows)
                {
                    locationMenu = new LocationMenu();
                    locationMenu.LocationMenuID = (int)row["location_menu_id"];
                    locationMenu.LocationTabID = (int)row["location_tab_id"];
                    locationMenu.ProductID = (int)row["product_id"];
                    locationMenu.Row = (int)row["row_on"];
                    locationMenu.Column = (int)row["column_on"];


                    lstLocationMenu.Add(locationMenu);
                }

                string stringJSON = JsonConvert.SerializeObject(lstLocationMenu);

                return stringJSON;
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => GetListOfTable" + ex.Message);
                return null;
            }
        }


        #endregion

        #region Printer
        public int AddPrinter(string stringJSON)
        {
            try
            {
                log.Info("BusinessLogic => AddPrinter - Begin");
                PrinterModel printerModel = JsonConvert.DeserializeObject<PrinterModel>(stringJSON);
                return _printerDAO.AddPrinter(printerModel.Name, printerModel.PrinterIP, printerModel.PrinterPort);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddPrinter" + ex.Message);
                return -1;
            }
        }

        public int UpdatePrinter(string stringJSON)
        {
            try
            {
                log.Info("BusinessLogic => UpdatePrinter - Begin");
                PrinterModel printerModel = JsonConvert.DeserializeObject<PrinterModel>(stringJSON);
                return _printerDAO.UpdatePrinter(printerModel.PrinterID, printerModel.Name);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => UpdatePrinter" + ex.Message);
                return -1;
            }
        }

        public int RemovePrinter(int PritnerID)
        {
            try
            {
                log.Info("BusinessLogic => RemovePrinter - Begin");
                return _printerDAO.RemovePrinter(PritnerID);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => RemovePrinter" + ex.Message);
                return -1;
            }
        }

        public string GetListOfPrinter()
        {
            try
            {
                DataTable dt = new DataTable();
                List<PrinterModel> lstPrinterModel = new List<PrinterModel>();
                PrinterModel printerModel = new PrinterModel();
                dt = _printerDAO.GetListOfPrinter();

                foreach (DataRow row in dt.Rows)
                {
                    printerModel = new PrinterModel();
                    printerModel.PrinterID = (int)row["location_tab_id"];
                    printerModel.Name = row["name"].ToString();
                    printerModel.PrinterIP = row["printer_ip"].ToString();
                    printerModel.PrinterPort = row["printer_port"].ToString();
                    printerModel.IsActive = (int)row["is_active"];

                    lstPrinterModel.Add(printerModel);
                }

                string stringJSON = JsonConvert.SerializeObject(lstPrinterModel);

                return stringJSON;
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => GetListOfLocationTab" + ex.Message);
                return null;
            }
        }
        #endregion

        #region PrinterProduct
        public int AddPrinterProduct(string stringJSON)
        {
            try
            {
                log.Info("BusinessLogic => AddPrinter - Begin");
                PrinterProductModel printerProdectModel = JsonConvert.DeserializeObject<PrinterProductModel>(stringJSON);
                return _printerDAO.AddPrinterProduct(printerProdectModel.ProductID, printerProdectModel.PrinterID);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddPrinter" + ex.Message);
                return -1;
            }
        }

        public int RemovePrinterProduct(int PritnerID,int ProductID)
        {
            try
            {
                log.Info("BusinessLogic => RemovePrinter - Begin");
                return _printerDAO.RemovePrinterProduct(PritnerID, ProductID);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => RemovePrinter" + ex.Message);
                return -1;
            }
        }
        #endregion

        #region PrinterLog
        public int AddPrinterLog(string stringJSON)
        {
            try
            {
                log.Info("BusinessLogic => AddPrinter - Begin");
                PrinterLogModel printerLogModel = JsonConvert.DeserializeObject<PrinterLogModel>(stringJSON);
                return _printerDAO.AddPrinterLog(printerLogModel.PrinterID, printerLogModel.PrinterDateTime.ToShortDateString(), printerLogModel.PrinterDetail);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddPrinter" + ex.Message);
                return -1;
            }
        }

        public string GetListOfPrinterLog()
        {
            try
            {
                DataTable dt = new DataTable();
                List<PrinterLogModel> lstPrinterLogModel = new List<PrinterLogModel>();
                PrinterLogModel printerLogModel = new PrinterLogModel();
                dt = _printerDAO.GetListOfPrinter();

                foreach (DataRow row in dt.Rows)
                {
                    printerLogModel = new PrinterLogModel();
                    printerLogModel.PrinterLogID = (int)row["printer_log_id"];
                    printerLogModel.PrinterID = (int)row["printer_id"];
                    printerLogModel.PrinterDateTime = DateTime.Parse(row["print_dt"].ToString());
                    printerLogModel.PrinterDetail = row["printer_detail"].ToString();

                    lstPrinterLogModel.Add(printerLogModel);
                }

                string stringJSON = JsonConvert.SerializeObject(lstPrinterLogModel);

                return stringJSON;
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => GetListOfLocationTab" + ex.Message);
                return null;
            }
        }
        #endregion
    }
}
