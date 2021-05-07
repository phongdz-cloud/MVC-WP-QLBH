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
    public class SupplierDAO
    {
        public SupplierDAO()
        {
        }
        #region Lấy dữ liệu từ DataBase của sản phẩm
        /*
         * Phương thức này có chức năng đưa dữ liệu từ nhà cung cấp xuống
         */
        public DataTable getSupllier()
        {
            return DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM NHACUNGCAP", CommandType.Text, null);
        }
        #endregion
        #region Insert supllier
        public bool insertSupllier(ref string err, SupplierDTO supplier)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spInsertNhaCungCap", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MANCC", supplier.MaNCC),
                new SqlParameter("@TENNCC", supplier.TenNCC),
                new SqlParameter("@DIACHI", supplier.DiaChi),
                new SqlParameter("@DIENTHOAI", supplier.Sdt),
                new SqlParameter("@EMAIL", supplier.Email));
        }
        #endregion
        #region Update supllier
        public bool updateSupllier(ref string err, SupplierDTO supplier)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spUpdateNhaCungCap", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MANCC", supplier.MaNCC),
                new SqlParameter("@TENNCC", supplier.TenNCC),
                new SqlParameter("@DIACHI", supplier.DiaChi),
                new SqlParameter("@DIENTHOAI", supplier.Sdt),
                new SqlParameter("@EMAIL", supplier.Email));
        }
        #endregion
        #region Delete supllier
        public bool deleteSupllier(ref string err, SupplierDTO supplier)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spDeleteNhaCungCap", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MANCC", supplier.MaNCC));
        }
        #endregion
    }
}
