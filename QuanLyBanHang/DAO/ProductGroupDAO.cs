using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class ProductGroupDAO
    {
        #region Mở kết nối 
        DBProvider db;
        public ProductGroupDAO()
        {
            db = new DBProvider();
        }
        #endregion
        #region Lấy dữ liệu từ DataBase
        /*
         * Phương thức này có chức năng đưa dữ liệu từ nhóm sản phẩm xuống
         */
        public DataTable getProductGroup()
        {
            return db.ExecuteQueryDataTable("SELECT * FROM NHOMSANPHAM", CommandType.Text, null);
        }
        #endregion
    }
}
