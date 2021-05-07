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
        public CustomerDAO()
        {
        }
        #region Lấy dữ liệu từ DataBase
        /*
         * Phương thức này có chức năng đưa dữ liệu từ khách hàng xuống
         */
        public DataTable getCustomer()
        {
            return DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM KHACHHANG", CommandType.Text, null);
        }
        #endregion
        #region Insert customer
        public bool insertCustomer(ref string err, CustomerDTO customer)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spInsertKhachHang", CommandType.StoredProcedure, ref err,
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
            return DBProvider.Instance.MyExcuteNonQuery("spUpdateKhachHang", CommandType.StoredProcedure, ref err,
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
            return DBProvider.Instance.MyExcuteNonQuery("spDeleteKhachHang", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MAKH", customer.MaKH));
        }
        #endregion
    }
}
