using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data.SqlClient;
using System.Data;
namespace Function
{
    public class fuction
    {
        DBProvider dBProvider;
        public fuction()
        {
             dBProvider = new DBProvider();
        }
        
        public static string taoID(int maAutoID,ref string error)
        {
            try
            {
                string sql = String.Format("Select * from AutoID where Ma={0}", maAutoID);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                SqlDataReader read = cmd.ExecuteReader();
                string tiento, result = "";
                int value;
                while (read.Read())
                {
                    value = (int)read.GetValue(3);
                    tiento = read.GetValue(2).ToString();
                    if (value == 0)
                    {
                        result = tiento + "00001";
                    }
                    else
                    {
                        value += 1;
                        if (value < 10)
                            result = String.Format("{0}0000{1}", tiento, value);
                        else if (value >= 10 && value < 100)
                            result = String.Format("{0}000{1}", tiento, value);
                        else if (value >= 100 && value < 1000)
                            result = String.Format("{0}00{1}", tiento, value);
                        else if (value >= 1000 && value < 10000)
                            result = String.Format("{0}0{1}", tiento, value);
                        else
                            result = tiento + value;
                    }
                }
                return result;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
                return null;
            }
        }
    }
}
