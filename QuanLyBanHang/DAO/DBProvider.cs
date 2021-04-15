using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace DAO
{
    public class DBProvider
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adp;
        string strConnect = "Data Source=(local);Initial Catalog=PROJECT_DBMS;Integrated Security=True";
        /*
         * Hàm khởi tạo có chức năng thực hiện kết nối tới Database trên local 
         */
        public DBProvider()
        {
            conn = new SqlConnection(strConnect);
            cmd = conn.CreateCommand();
        }
        /*
         * Phương thức này có chức năng lấy dữ liệu từ Database để hiển thị trên form khách hàng
         * Tham số truyền vào gồm có Câu lệnh truy vấn DB , loại truy vấn , tham số nhận vào
         * Trả về một datatable
         */
        public DataTable ExecuteQueryDataSet(string strSQL, CommandType ct, params SqlParameter[] p)
        {
            DataTable db = new DataTable();
            cmd.CommandText = strSQL;
            cmd.CommandType = ct;
            adp = new SqlDataAdapter(cmd);
            db.Clear();
            adp.Fill(db);
            return db;
        }
        /*
         * Phương thức này có chức năng thêm sửa xóa dữ liệu của bảng khách hàng
         * Tham số truyền vào gồm có Câu lệnh truy vấn DB , loại truy vấn , và lỗi nếu có , và tham số truyền vào
         * Trả về một datatable
         */
        public bool MyExcuteNonQuery(string strSQL, CommandType ct
            , ref string error, params SqlParameter[] p)
        {
            bool f = false;
            conn.Open();
            cmd.Parameters.Clear();
            cmd.CommandText = strSQL;
            cmd.CommandType = ct;
            foreach (var item in p)
            {
                cmd.Parameters.Add(item);
            }
            try
            {
                cmd.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return f;
        }
        
    }
}
