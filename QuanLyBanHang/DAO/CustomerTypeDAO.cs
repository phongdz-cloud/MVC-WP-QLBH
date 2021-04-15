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
    public class CustomerTypeDAO
    {
        #region Mở kết nối 
        DBProvider db;
        public CustomerTypeDAO()
        {
            db = new DBProvider();
        }
        #endregion
        #region Lấy dữ liệu từ DataBase
        /*
         * Phương thức này có chức năng đưa dữ liệu từ loại khách hàng xuống
         */
        public DataTable getCustomerType()
        {
            return db.ExecuteQueryDataTable("SELECT * FROM LOAIKHACHHANG", CommandType.Text, null);
        }
        #endregion
    }
}
