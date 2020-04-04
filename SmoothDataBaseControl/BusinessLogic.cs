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
        private ReportDAO _reportDAO;
        
        public BusinessLogic()
        {
            _employeeDAO = new EmployeeDAO();
            _popupDAO = new PopupDAO();
            _productDAO = new ProductDAO();
            _tableDAO = new TableDAO();
            _locationDAO = new LocationDAO();
            _printerDAO = new PrinterDAO();
            _reportDAO = new ReportDAO();
        }
        

        #region Employee
        

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(BusinessLogic));



        public int AddNewEmployeeLogic(string stringJSON)
        {
            try
            {
                log.Info("BusinessLogic => AddNewEmplouee - Begin");
                EmployeeModel employeeModel = JsonConvert.DeserializeObject<EmployeeModel>(stringJSON);
                return _employeeDAO.AddNewEmployee(employeeModel.FirstName, employeeModel.LastName, employeeModel.NickName, employeeModel.Phone, employeeModel.Email, employeeModel.Password);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("BussicnessLogic => AddNewEmployee");
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
                List<tb_employee> lstEmploy = new List<tb_employee>();
                List<EmployeeModel> lstEmployModel = new List<EmployeeModel>();
                EmployeeModel empModel;
                lstEmploy = _employeeDAO.GetListOfEmployee();

                for (int i = 0; i < lstEmploy.Count; i++)
                {
                    empModel = new EmployeeModel();
                    empModel.EmployeeID = lstEmploy[i].employee_id;
                    empModel.FirstName = lstEmploy[i].first_name;
                    empModel.LastName = lstEmploy[i].last_name;
                    empModel.Phone = lstEmploy[i].phone;
                    empModel.Email = lstEmploy[i].email;
                    empModel.LevelID = lstEmploy[i].level_id ?? 0;
                    empModel.StatusID = lstEmploy[i].status_id ?? 0;
                    empModel.Password = lstEmploy[i].password;
                    empModel.NickName = lstEmploy[i].nick_name;
                    lstEmployModel.Add(empModel);

                }

                return JsonConvert.SerializeObject(lstEmployModel);

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
                tb_employee employeeModel = new tb_employee();

                employeeModel = _employeeDAO.GetEmployeeDetailByPassword(Password);
                EmployeeModel empModel = new EmployeeModel();
                empModel.EmployeeID = employeeModel.employee_id;
                empModel.FirstName = employeeModel.first_name;
                empModel.LastName = employeeModel.last_name;
                empModel.Phone = employeeModel.phone;
                empModel.Email = employeeModel.email;
                empModel.LevelID = employeeModel.level_id ?? -1;
                empModel.StatusID = employeeModel.status_id ?? -1;
                empModel.Password = employeeModel.password;
                empModel.NickName = employeeModel.nick_name;

                return JsonConvert.SerializeObject(empModel);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => GetEmployeeDetailByPassword" + ex.Message);
                return null;
            }
        }

        public int UpdateEmployeeStatus(int staffID, int StatusID)
        {
            try
            {
                return _employeeDAO.UpdateEmployeeStatus(staffID, StatusID);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => UpdateEmployeeStatus" + ex.Message);
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
                log.Error("BussicnessLogic => CheckStaffStatus" + ex.Message);
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
                List<tb_popup> lstPopupModel = new List<tb_popup>();
                lstPopupModel = _popupDAO.GetListOfPopup();

                PopupModel popupModel;
                List<PopupModel> lstPopup = new List<PopupModel>();
                for (int i = 0; i < lstPopupModel.Count; i++)
                {
                    popupModel = new PopupModel();
                    popupModel.PopupID = lstPopupModel[i].popup_id;
                    popupModel.Name = lstPopupModel[i].name;
                    lstPopup.Add(popupModel);

                }

                return JsonConvert.SerializeObject(lstPopup);

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
                List<tb_popup> lstPopupModel = new List<tb_popup>();
                lstPopupModel = _popupDAO.GetListOfPopupFilter(name);
                PopupModel popupModel;
                List<PopupModel> lstPopup = new List<PopupModel>();
                for (int i = 0; i < lstPopupModel.Count; i++)
                {
                    popupModel = new PopupModel();
                    popupModel.PopupID = lstPopupModel[i].popup_id;
                    popupModel.Name = lstPopupModel[i].name;
                    lstPopup.Add(popupModel);

                }
                return JsonConvert.SerializeObject(lstPopup);
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
                List<tb_section> lstSectionModel = new List<tb_section>();
                lstSectionModel = _tableDAO.GetListOfSection();
                SectionModel sectionModel;
                List<SectionModel> lstSectionModels = new List<SectionModel>();
                for (int i = 0; i < lstSectionModel.Count; i++)
                {
                    sectionModel = new SectionModel();
                    sectionModel.Name = lstSectionModel[i].name;
                    sectionModel.SectionID = lstSectionModel[i].section_id;
                    sectionModel.IsActive = lstSectionModel[i].is_active ?? 0;
                    lstSectionModels.Add(sectionModel);

                }
                return JsonConvert.SerializeObject(lstSectionModels);

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
                List<tb_table_section> lstTableSection = new List<tb_table_section>();
                lstTableSection = _tableDAO.GetListTable();
                TableModal tableModel;
                List<TableModal> lstTableModel = new List<TableModal>();
                for (int i = 0; i < lstTableSection.Count; i++)
                {
                    tableModel = new TableModal();
                    tableModel.TableID = lstTableSection[i].table_section_id;
                    tableModel.uniName = lstTableSection[i].u_name;
                    tableModel.Name = lstTableSection[i].name;
                    tableModel.SectionID = lstTableSection[i].section_id ?? -1;
                    tableModel.MarginTop = lstTableSection[i].margin_top ?? -1;
                    tableModel.MarginBottom = lstTableSection[i].margin_bottom ?? -1;
                    tableModel.MarginRight = lstTableSection[i].margin_right ?? -1;
                    tableModel.MarginLeft = lstTableSection[i].margin_left ?? -1;
                    tableModel.Height = lstTableSection[i].height ?? 50;
                    tableModel.Width = lstTableSection[i].width ?? 50;
                    tableModel.IsActive = lstTableSection[i].is_active ?? 0;
                    lstTableModel.Add(tableModel);
                }
                return JsonConvert.SerializeObject(lstTableModel);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => GetListOfTable" + ex.Message);
                return null;
            }
        }
        #endregion

        #region Location Menu
        public int GetListOfPrinterLog(string Name)
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

        public int AddLocationTab(string Name)
        {
            try
            {
                log.Info("BusinessLogic => AddLocationTab - Begin");
                return _locationDAO.AddLocationTab(Name);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => AddLocationMenu" + ex.Message);
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
                List<tb_location_tab> lstLocationTab = new List<tb_location_tab>();
                lstLocationTab = _locationDAO.GetListOfLocationTab();
                LocationTab locationTab;
                List<LocationTab> lstLocationTabModel = new List<LocationTab>();
                for (int i = 0; i < lstLocationTab.Count; i++)
                {
                    locationTab = new LocationTab();
                    locationTab.LocationTabID = lstLocationTab[i].location_tab_id;
                    locationTab.Name = lstLocationTab[i].name;
                    locationTab.IsActive = lstLocationTab[i].is_active ?? 0;
                    lstLocationTabModel.Add(locationTab);
                }

                return JsonConvert.SerializeObject(lstLocationTabModel);

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
                List<tb_location_menu> lstlocationMenu = new List<tb_location_menu>();
                lstlocationMenu = _locationDAO.GetListLocationMenu();
                LocationMenu locationMenuModel;
                List<LocationMenu> lstLocationMenu = new List<LocationMenu>();

                for (int i = 0; i < lstlocationMenu.Count; i++)
                {
                    locationMenuModel = new LocationMenu();
                    locationMenuModel.LocationMenuID = lstlocationMenu[i].location_menu_id;
                    locationMenuModel.ProductID = lstlocationMenu[i].product_id ?? -1;
                    locationMenuModel.LocationTabID = lstlocationMenu[i].location_tab_id ?? -1;
                    locationMenuModel.Column = lstlocationMenu[i].column_no ?? -1;
                    locationMenuModel.Row = lstlocationMenu[i].row_no ?? -1;
                    lstLocationMenu.Add(locationMenuModel);
                }

                return JsonConvert.SerializeObject(lstLocationMenu);
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
                List<tb_printer> lstPrinterModel = new List<tb_printer>();
                lstPrinterModel = _printerDAO.GetListOfPrinter();
                PrinterModel printerModel;
                List<PrinterModel> lstPrinter = new List<PrinterModel>();

                for (int i = 0; i < lstPrinterModel.Count; i++)
                {
                    printerModel = new PrinterModel();
                    printerModel.PrinterID = lstPrinterModel[i].printer_id;
                    printerModel.Name = lstPrinterModel[i].name;
                    printerModel.PrinterIP = lstPrinterModel[i].printer_ip;
                    printerModel.PrinterPort = lstPrinterModel[i].printer_port;
                    printerModel.IsActive = lstPrinterModel[i].is_active ?? 0;

                    lstPrinter.Add(printerModel);
                }
                return JsonConvert.SerializeObject(lstPrinter);
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
                List<tb_printer_log> lstPrinterLogModel = new List<tb_printer_log>();
                lstPrinterLogModel = _printerDAO.GetListOfPrinterLog();

                PrinterLogModel printerLogModel;
                List<PrinterLogModel> lstPrinterLog = new List<PrinterLogModel>();
                for (int i = 0; i < lstPrinterLogModel.Count; i++)
                {
                    printerLogModel = new PrinterLogModel();
                    printerLogModel.PrinterLogID = lstPrinterLogModel[i].printer_log_id;
                    printerLogModel.PrinterID = lstPrinterLogModel[i].printer_id;
                    printerLogModel.PrinterDateTime = lstPrinterLogModel[i].print_dt;
                    //printerLogModel.PrinterDetail = lstPrinterLogModel[i].printer_detail;


                    lstPrinterLog.Add(printerLogModel);
                }
                return JsonConvert.SerializeObject(lstPrinterLogModel);

            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => GetListOfLocationTab" + ex.Message);
                return null;
            }
        }
        #endregion

        #region Report
        //public int AddPrinterLog(string stringJSON)
        //{
        //    try
        //    {
        //        log.Info("BusinessLogic => AddPrinter - Begin");
        //        PrinterLogModel printerLogModel = JsonConvert.DeserializeObject<PrinterLogModel>(stringJSON);
        //        return _printerDAO.AddPrinterLog(printerLogModel.PrinterID, printerLogModel.PrinterDateTime.ToShortDateString(), printerLogModel.PrinterDetail);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("BussicnessLogic => AddPrinter" + ex.Message);
        //        return -1;
        //    }
        //}

        public string ListOfReport()
        {
            try
            {
                List<tb_order> lstOrder = new List<tb_order>();
                lstOrder = _reportDAO.GetListOfOrder();
                OrderModel orderModel;
                List<OrderModel> lstOrderModel = new List<OrderModel>();
                for (int i = 0; i < lstOrder.Count; i++)
                {
                    orderModel = new OrderModel();
                    orderModel.OrderID = lstOrder[i].order_id;
                    orderModel.OrderTime = lstOrder[i].order_at ?? DateTime.MinValue;
                    orderModel.EmployeeID = lstOrder[i].employee_id ?? 0;
                    orderModel.TableID = lstOrder[i].table;
                    orderModel.OrderStatusID = lstOrder[i].order_status_id ?? 0;
                    orderModel.PaymentTypeID = lstOrder[i].payment_id ?? 1;
                    orderModel.CustomerID = lstOrder[i].customer_id ?? -1;
                    orderModel.IsActive = lstOrder[i].is_active.GetValueOrDefault(1);
                    lstOrderModel.Add(orderModel);
                }
                return JsonConvert.SerializeObject(lstOrderModel);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => GetListOfTable" + ex.Message);
                return null;
            }
        }

        public string ListOfReport(int Top)
        {
            try
            {
                List<tb_order> lstOrder = new List<tb_order>();
                lstOrder = _reportDAO.GetListOfOrder(Top);
                OrderModel orderModel;
                List<OrderModel> lstOrderModel = new List<OrderModel>();
                for (int i = 0; i < lstOrder.Count; i++)
                {
                    orderModel = new OrderModel();
                    orderModel.OrderID = lstOrder[i].order_id;
                    orderModel.OrderTime = lstOrder[i].order_at ?? DateTime.MinValue;
                    orderModel.EmployeeID = lstOrder[i].employee_id ?? 0;
                    orderModel.TableID = lstOrder[i].table;
                    orderModel.OrderStatusID = lstOrder[i].order_status_id ?? 0;
                    orderModel.PaymentTypeID = lstOrder[i].payment_id ?? 1;
                    orderModel.CustomerID = lstOrder[i].customer_id ?? -1;
                    orderModel.IsActive = lstOrder[i].is_active.GetValueOrDefault(0);
                    lstOrderModel.Add(orderModel);
                }
                return JsonConvert.SerializeObject(lstOrderModel);
            }
            catch (Exception ex)
            {
                log.Error("BussicnessLogic => GetListOfTable" + ex.Message);
                return null;
            }
        }

        #endregion
    }

    
}
