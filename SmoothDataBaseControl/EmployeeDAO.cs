using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDataBaseControl
{
    public class EmployeeDAO
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(EmployeeDAO));

        /// <summary>
        /// Add New Employee
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Phone"></param>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int AddNewEmployee(string FirstName, string LastName,string NickName, string Phone, string Email, string Password)
        {
            try
            {
                using (var db = new SmoothDBEntities())
                {
                    var ds = db.tb_employee.Add(new tb_employee()
                    {
                        first_name = FirstName,
                        last_name = LastName,
                        nick_name = NickName,
                        phone = Phone,
                        email = Email,
                        password = Password
                    });

                    db.SaveChanges();
                }
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => AppNewEmployee(): " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Update Profile Employee by Employee ID
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Phone"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public int UpdateProfileEmployee(int EmployeeID, string FirstName, string LastName, string NickName, string Phone, string Email, string Password)
        {
            try
            {
                using (var db = new SmoothDBEntities())
                {
                    var update = db.tb_employee.Where(o => (o.employee_id == EmployeeID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.first_name = FirstName;
                        update.last_name = LastName;
                        update.nick_name = NickName;
                        update.phone = Phone;
                        update.email = Email;
                        update.password = Password;
                    }

                    db.SaveChanges();
                }
                log.Info("Update Profile Employee Success");
                return 1;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => UpdateProfileEmployee(): " + ex.Message);
                return -1;
            }
        }

        /// <summary>
        /// Get All Data Table Employee
        /// </summary>
        /// <returns></returns>
        public List<tb_employee> GetListOfEmployee()
        {
            try
            {
                using (var db = new SmoothDBEntities())
                {
                    var ds = (from c in db.tb_employee
                              select c).ToList();

                    // Assign to DataGridView
                    if (ds.Count() > 0)
                    {
                        log.Info("Get List Of Employee Success");
                        return ds;
                    }
                    else
                    {
                        return null;
                    }
                }     
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => ListOfEmployee(): " + ex.Message);
                return null;
            }
        }

        public tb_employee GetEmployeeDetailByPassword(string Password)
        {
            try
            {
                tb_employee employee = new tb_employee();
                using (var db = new SmoothDBEntities())
                {
                    var ds = (from c in db.tb_employee
                              select c).FirstOrDefault();

                    // if found item rows
                    if (ds != null)
                    {
                        return ds;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => GetEmployeeDetailByPassword(): " + ex.Message);
                return null;
            }

        }

        public int UpdateEmployeeStatus(int employeeID, int statusID)
        {
            try
            {
                using (var db = new SmoothDBEntities())
                {
                    var update = db.tb_employee.Where(o => (o.employee_id == employeeID)).FirstOrDefault();
                    if (update != null)
                    {
                        update.status_id = statusID;
                    }

                    log.Info("UpdateEmployeeStatus Success");
                    db.SaveChanges();
                    return 1;
                }
                
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => UpdateStaffStatus(): " + ex.Message);
                return -1;
            }
        }

        public int CheckStaffStatus(int employeeID)
        {
            try
            {
                using (var db = new SmoothDBEntities())
                {
                    var ds = (from c in db.tb_employee
                              where c.employee_id == employeeID
                              select c).FirstOrDefault();

                    log.Info("Get List Of Employee Success");
                    if (ds.status_id == null)
                        return default(int);
                    else
                        return -1;
                }
            }
            catch (Exception ex)
            {
                log.Error("DataLayer => GetEmployeeDetailByPassword(): " + ex.Message);
                return -1;
            }
        }
    }
}
