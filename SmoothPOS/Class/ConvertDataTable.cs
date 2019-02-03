using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace SmoothPOS
{
    public static class ConvertDataTable
    {
        public static object ConvertDataTableToJson(DataTable dt)
        {
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

    }
}
