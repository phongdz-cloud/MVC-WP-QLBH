using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;
namespace DAO
{
    public class OrderDAO
    {
        #region Mở kết nối 
        DBProvider db;
        public OrderDAO()
        {
            db = new DBProvider();
        }
        #endregion
        #region Lấy dữ liệu từ DataBase của đơn đặt hàng
        /*
         * Phương thức này có chức năng đưa dữ liệu từ sản phẩm xuống
         */
        public DataTable getOrder()
        {
            return db.ExecuteQueryDataTable("SELECT * FROM DONDATHANG", CommandType.Text, null);
        }
        #endregion
        #region Insert
        public bool insertOrder(ref string err, OrderDTO order)
        {
            return db.MyExcuteNonQuery("spInsertDonDatHang", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MADDH", order.MaDDH),
                new SqlParameter("@GHICHU", order.GhiChu),
                new SqlParameter("@MAKH", order.MaKH),
                new SqlParameter("@MANV", order.MaNV));
        }
        #endregion
        // bảng đơn đặt hàng không có chức năng Update
        #region Delete
        public bool deleteOrder(ref string err, OrderDTO order)
        {
            return db.MyExcuteNonQuery("spDeleteDonDatHang", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MADDH", order.MaDDH));
        }
        #endregion
    }
}
