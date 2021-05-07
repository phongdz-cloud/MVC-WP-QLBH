using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DAO;
namespace Function
{
    public static class Func
    {
        private static string getTienTo = "";
        #region autoid
        public static void updateAutoID()
        {
            DBProvider.Instance.Conn.Open();
            DBProvider.Instance.Cmd.Parameters.Clear();
            DBProvider.Instance.Cmd.CommandText = "spUpdateAutoID";
            DBProvider.Instance.Cmd.CommandType = CommandType.StoredProcedure;
            DBProvider.Instance.Cmd.Parameters.Add("@TienTo", getTienTo);
            DBProvider.Instance.Cmd.ExecuteNonQuery();
            DBProvider.Instance.Conn.Close();
        }
        #endregion

        #region Tạo auto id
        public static string taoID(int maAutoID,ref string error)
        {
            try
            {
                DBProvider.Instance.Conn.Open();
                string sql = String.Format("Select * from AutoID where Ma={0}", maAutoID);
                DBProvider.Instance.Cmd.CommandText = sql;
                DBProvider.Instance.Cmd.CommandType = CommandType.Text;
                SqlDataReader read = DBProvider.Instance.Cmd.ExecuteReader();
                string tiento, result = "";
                int value;
                while (read.Read())
                {
                    value = (int)read.GetValue(3);
                    tiento = read.GetValue(2).ToString();
                    getTienTo = read.GetValue(2).ToString();
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
            finally
            {
                DBProvider.Instance.Conn.Close();
                DBProvider.Instance.Cmd.Dispose();
            }
        }
        #endregion
        #region Đổi số thành chữ
        public static string NumbertoWord(double inputNumber)
        {
            string result = "";
            bool isNegative = false;
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy",
                                                    "tám","chín"};
            string[] placeNumbers = new string[] { "", "nghìn", "triệu", "tỷ" };
            string sNumber = inputNumber.ToString("#"); // bỏ đi dấu ,
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number *= -1; // đưa về số dương để đọc các chữ số
                isNegative = true;
            }
            if (number == 0) return result + unitNumbers[0];
            else
            {
                // 1    .   ###
                // 2 nghìn. ###,###
                // 3 triệu. ###,###,###
                // 4 tỷ   . ###,###,###,###  
                int positionDigit = sNumber.Length;
                int ones, tens, hundreds, placeNumber;  //321312321
                placeNumber = 0;
                while (positionDigit > 0)
                {
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit-- - 1, 1));
                    if (positionDigit > 0)
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit-- - 1, 1));
                    if (positionDigit > 0)
                        hundreds = Convert.ToInt32(sNumber.Substring(positionDigit-- - 1, 1));
                    if ((ones >= 0) || (tens >= 0) || (hundreds >= 0) || (placeNumber == 3))
                        result = placeNumbers[placeNumber++] + result;
                    if (placeNumber > 3) placeNumber = 1;
                    if (ones == 1 && tens > 1) result = unitNumbers[ones] + " " + result;
                    else
                    {
                        if (ones == 5 && tens > 0) result = "lăm " + result;
                        else if (ones > 0) result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0) break;
                    else
                    {
                        if (tens == 0 && ones > 0) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) return "Âm " + result;
            return result;
        }
        #endregion
    }
}
