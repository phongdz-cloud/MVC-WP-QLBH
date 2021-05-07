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
        private static DBProvider instance;
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataAdapter adp;
        string strConnect = "Data Source=(local);Initial Catalog=PROJECT_DBMS;Integrated Security=True";
        /*
         * 
         * Hàm khởi tạo có chức năng thực hiện kết nối tới Database trên local 
         */
        public DBProvider()
        {
            conn = new SqlConnection(strConnect);
            Cmd = Conn.CreateCommand();
        }
        
        public static DBProvider Instance { 
            get
            {
                if (instance == null) { 
                    instance = new DBProvider();
                };
                return DBProvider.instance;
            }
            private set { DBProvider.instance = value; }
        }
        public SqlConnection Conn { get => conn; }
        public SqlCommand Cmd { get => cmd; set => cmd = value; }

        /*
* Phương thức này có chức năng lấy dữ liệu từ Database để hiển thị trên form khách hàng
* Tham số truyền vào gồm có Câu lệnh truy vấn DB , loại truy vấn , tham số nhận vào
* Trả về một datatable
*/
        public DataTable ExecuteQueryDataTable(string strSQL, CommandType ct, params SqlParameter[] p)
        {
            DataTable db = new DataTable();
            Cmd.CommandText = strSQL;
            Cmd.CommandType = ct;
            adp = new SqlDataAdapter(Cmd);
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
            Conn.Open();
            Cmd.Parameters.Clear();
            Cmd.CommandText = strSQL;
            Cmd.CommandType = ct;
            foreach (var item in p)
            {
                Cmd.Parameters.Add(item);
            }
            try
            {
                Cmd.ExecuteNonQuery();
                f = true;
            }
            catch (SqlException ex)
            {
                error = ex.Message;
            }
            finally
            {
                Conn.Close();
            }
            return f;
        }
        
    }
}
