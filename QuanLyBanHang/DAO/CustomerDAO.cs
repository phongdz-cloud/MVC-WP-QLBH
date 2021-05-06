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
    public class CustomerDAO
    {
        #region Mở kết nối 
        DBProvider db;
        public CustomerDAO()
        {
            db = new DBProvider();
        }
        #endregion
        #region Lấy dữ liệu từ DataBase
        /*
         * Phương thức này có chức năng đưa dữ liệu từ khách hàng xuống
         */
        public DataTable getCustomer()
        {
            return db.ExecuteQueryDataTable("SELECT * FROM KHACHHANG", CommandType.Text, null);
        }
        #endregion
        #region Insert customer
        public bool insertCustomer(ref string err, CustomerDTO customer)
        {
            return db.MyExcuteNonQuery("spInsertKhachHang", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MAKH", customer.MaKH),
                new SqlParameter("@TENKH", customer.TenKH),
                new SqlParameter("@GIOITINH", customer.GioiTinh),
                new SqlParameter("@DIACHI", customer.DiaChi),
                new SqlParameter("@DIENTHOAI", customer.DienThoai),
                new SqlParameter("@MALOAIKH", customer.MaLoaiKH),
                new SqlParameter("@IMAGES", customer.Images));
        }
        #endregion
        #region Update customer
        public bool updateCustomer(ref string err, CustomerDTO customer)
        {
            return db.MyExcuteNonQuery("spUpdateKhachHang", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MAKH", customer.MaKH),
                new SqlParameter("@TENKH", customer.TenKH),
                new SqlParameter("@GIOITINH", customer.GioiTinh),
                new SqlParameter("@DIACHI", customer.DiaChi),
                new SqlParameter("@DIENTHOAI", customer.DienThoai),
                new SqlParameter("@MALOAIKH", customer.MaLoaiKH),
                new SqlParameter("@IMAGES", customer.Images));
        }
        #endregion
        #region Delete customer
        public bool deleteCustomer(ref string err, CustomerDTO customer)
        {
            return db.MyExcuteNonQuery("spDeleteKhachHang", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MAKH", customer.MaKH));
        }
        #endregion
    }
}
