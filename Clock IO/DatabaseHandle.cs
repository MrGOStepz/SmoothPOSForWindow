using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock_IO
{
    public class DatabaseHandle
    {
        public MySqlConnection _conn;

        private const string TABLE_EMPLOYEE = "tb_employee";

        public void DatabaseOpen()
        {
            string connectionPath = "server=localhost;Port=3306;user id=root;persistsecurityinfo=True;database=smoothdb;password=G4856162651O;";
            _conn = new MySqlConnection(connectionPath);
            _conn.Open();
        }

        public void DatabaseClose()
        {
            _conn.Close();
        }


        /// <summary>
        /// Add New Employee
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Phone"></param>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public int AddNewEmployee(string FirstName, string Password)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append("tb_employee");
                stringSQL.Append(" (first_name, password)");
                stringSQL.Append(" VALUES (@FirstName, @Password);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@firstName", FirstName);
                cmd.Parameters.AddWithValue("@password", Password);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        
        public Employee CheckUser(string password)
        {
            try
            {
                Employee employee = new Employee();

                StringBuilder stringSQL = new StringBuilder();
                DatabaseOpen();
                stringSQL.Append("SELECT employee_id, first_name, status_id ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_EMPLOYEE);
                stringSQL.Append(" WHERE password LIKE @password;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@password", password);

                MySqlDataReader reader = cmd.ExecuteReader();



                while (reader.Read())
                {
                    employee.Name = reader["first_name"].ToString();
                    employee.ClockInStatus = (int)reader["status_id"];
                    employee.EmployeeID = (int)reader["employee_id"];
                }

                DatabaseClose();

                return employee;


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public int UpdateUserStatus(int EmployeeID, int StatusID)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();
                DatabaseOpen();
                stringSQL.Append("UPDATE ");
                stringSQL.Append(TABLE_EMPLOYEE);
                stringSQL.Append(" SET status_id = @statusID");
                stringSQL.Append(" WHERE employee_id = @employeeID;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@statusID", StatusID);
                cmd.Parameters.AddWithValue("@employeeID", EmployeeID);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int AddEmployeeTime(String firstName)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();

                DatabaseOpen();
                stringSQL.Append("INSERT INTO ");
                stringSQL.Append("tb_employee_time_sheet");
                stringSQL.Append(" (first_name, clockin_time)");
                stringSQL.Append(" VALUES (@EmployeeName, @ClockIn);");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@EmployeeName", firstName);
                cmd.Parameters.AddWithValue("@ClockIn", DateTime.Now);

                cmd.ExecuteNonQuery();

                DatabaseClose();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int UpdateClockOut(string name)
        {
            try
            {
                int employeeTimeID = 0;
                StringBuilder stringSQL = new StringBuilder();
                DatabaseOpen();

                stringSQL.Append("SELECT employee_time_sheet_id ");
                stringSQL.Append("FROM tb_employee_time_sheet ");
                stringSQL.Append("WHERE first_name LIKE @employeeName ");
                stringSQL.Append("ORDER BY employee_time_sheet_id DESC LIMIT 1;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@employeeName", name);

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    employeeTimeID = Convert.ToInt32(reader["employee_time_sheet_id"]);
                }

                DatabaseClose();
                DatabaseOpen();

                stringSQL = new StringBuilder();
                stringSQL.Append("UPDATE ");
                stringSQL.Append("tb_employee_time_sheet ");
                stringSQL.Append("SET clockout_time = @clockout");
                stringSQL.Append(" WHERE employee_time_sheet_ID = @employeeTimeID;");

                cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@clockout", DateTime.Now);
                cmd.Parameters.AddWithValue("@employeeTimeID", employeeTimeID);

                cmd.ExecuteNonQuery();

                DatabaseClose();

                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public DataTable ListOfUser()
        {
            try
            {
                Employee employee = new Employee();

                StringBuilder stringSQL = new StringBuilder();
                DatabaseOpen();
                stringSQL.Append("SELECT employee_id, first_name ");
                stringSQL.Append("FROM ");
                stringSQL.Append(TABLE_EMPLOYEE);

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DatabaseClose();

                return dt;


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<EmployeeTimeSheet> GetEmployeeTimeSheet(String Name,DateTime dtFrom, DateTime dtTo)
        {
            try
            {
                StringBuilder stringSQL = new StringBuilder();
                EmployeeTimeSheet employeeTimeSheet;
                List<EmployeeTimeSheet> lstEmployeeTimeSheet = new List<EmployeeTimeSheet>();

                DatabaseOpen();

                stringSQL.Append("SELECT * ");
                stringSQL.Append("FROM tb_employee_time_sheet ");
                stringSQL.Append("WHERE first_name LIKE @employeeName AND ");
                stringSQL.Append("clockin_time BETWEEN @DateTimeFrom AND @DateTimeTo;");

                MySqlCommand cmd = new MySqlCommand(stringSQL.ToString(), _conn);
                cmd.Parameters.AddWithValue("@employeeName", Name);
                cmd.Parameters.AddWithValue("@DateTimeFrom", dtFrom.ToString("yyyy/MM/dd"));
                cmd.Parameters.AddWithValue("@DateTimeTo", dtTo.ToString("yyyy/MM/dd"));

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    employeeTimeSheet = new EmployeeTimeSheet();
                    employeeTimeSheet.Name = reader["first_name"].ToString();

                    if (reader["clockin_time"] != DBNull.Value)
                    {
                        employeeTimeSheet.DateFrom = (DateTime)reader["clockin_time"];
                    }


                    if (reader["clockout_time"] != DBNull.Value)
                    {
                        employeeTimeSheet.DateTo = (DateTime)reader["clockout_time"];
                    }

                    lstEmployeeTimeSheet.Add(employeeTimeSheet);
                }

                DatabaseClose();

                return lstEmployeeTimeSheet;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
