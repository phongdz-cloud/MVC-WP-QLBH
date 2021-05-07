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
        public CustomerTypeDAO()
        {
        }
        #endregion
        #region Lấy dữ liệu từ DataBase
        /*
         * Phương thức này có chức năng đưa dữ liệu từ loại khách hàng xuống
         */
        public DataTable getCustomerType()
        {
            return DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM LOAIKHACHHANG", CommandType.Text, null);
        }
        #endregion
        #region Insert CustomerType
        public bool insertCustomerType(ref string err, CustomerTypeDTO customerTypeDTO)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spInsertLoaiKhachHang", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MALOAIKH", customerTypeDTO.MaLoaiKH),
                new SqlParameter("@TENLOAI", customerTypeDTO.TenLoaiKH));
        }
        #endregion
        #region Update CustomerType
        public bool updateCustomerType(ref string err, CustomerTypeDTO customerTypeDTO)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spUpdateLoaiKhachHang", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MALOAIKH", customerTypeDTO.MaLoaiKH),
                new SqlParameter("@TENLOAI", customerTypeDTO.TenLoaiKH));
        }
        #endregion
        #region Delete CustomerType
        public bool deleteCustomerType(ref string err, CustomerTypeDTO customerTypeDTO)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spDeleteLoaiKhachHang", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MALOAIKH", customerTypeDTO.MaLoaiKH));
        }
        #endregion

    }
}
