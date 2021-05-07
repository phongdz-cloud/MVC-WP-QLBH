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
    public class ProductDAO
    {

        public ProductDAO()
        {

        }
        #region Lấy dữ liệu từ DataBase của sản phẩm
        /*
         * Phương thức này có chức năng đưa dữ liệu từ sản phẩm xuống
         */
        public DataTable getProduct()
        {
            return DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM SANPHAM", CommandType.Text, null);
        }
        #endregion
        #region Insert product
        public bool insertProduct(ref string err, ProductDTO product)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spInsertSanPham", CommandType.StoredProcedure, ref err,
               new SqlParameter("@maSP", product.MaSP),
                new SqlParameter("@tenSP", product.TenSP),
                new SqlParameter("@giaban", product.GiaBan),
                new SqlParameter("@soluongton", product.SlTon),
                new SqlParameter("@manhomsp", product.ManhomSP),
                new SqlParameter("@nuocsx", product.NuocSX));
        }
        #endregion
        #region Update product
        public bool updateProduct(ref string err, ProductDTO product)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spUpdateSanPham", CommandType.StoredProcedure, ref err,
               new SqlParameter("@maSP", product.MaSP),
                new SqlParameter("@tenSP", product.TenSP),
                new SqlParameter("@giaban", product.GiaBan),
                new SqlParameter("@soluongton", product.SlTon),
                new SqlParameter("@manhomsp", product.ManhomSP),
                new SqlParameter("@nuocsx", product.NuocSX));
        }
        #endregion
        #region Delete product
        public bool deleteProduct(ref string err, ProductDTO product)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spDeleteSanPham", CommandType.StoredProcedure, ref err,
               new SqlParameter("@maSP", product.MaSP));
        }
        #endregion
    }
}