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
        #region Mở kết nối 
        DBProvider db;
        public ProductDAO()
        {
            db = new DBProvider();
        }
        #endregion
        #region Lấy dữ liệu từ DataBase của sản phẩm
        /*
         * Phương thức này có chức năng đưa dữ liệu từ sản phẩm xuống
         */
        public DataTable getProduct()
        {
            return db.ExecuteQueryDataTable("SELECT * FROM SANPHAM", CommandType.Text, null);
        }
        #endregion
        #region Insert product
        public bool insertProduct(ref string err, ProductDTO product)
        {
            return db.MyExcuteNonQuery("spInsertSanPham", CommandType.StoredProcedure, ref err,
               new SqlParameter("@maSP", product.MaSP),
                new SqlParameter("@tenSP", product.TenSP),
                new SqlParameter("@giaban", product.GiaBan),
                new SqlParameter("@soluongton", product.SlTon),
                new SqlParameter("@manhomsp", product.ManhomSP),
                new SqlParameter("@nuocsx", product.NuocSX),
                new SqlParameter("@ngaysx", product.NgaySX),
                new SqlParameter("@hansd", product.HanSD));
        }
        #endregion
        #region Update product
        public bool updateProduct(ref string err, ProductDTO product)
        {
            return db.MyExcuteNonQuery("spUpdateSanPham", CommandType.StoredProcedure, ref err,
               new SqlParameter("@maSP", product.MaSP),
                new SqlParameter("@tenSP", product.TenSP),
                new SqlParameter("@giaban", product.GiaBan),
                new SqlParameter("@soluongton", product.SlTon),
                new SqlParameter("@manhomsp", product.ManhomSP),
                new SqlParameter("@nuocsx", product.NuocSX),
                new SqlParameter("@ngaysx", product.NgaySX),
                new SqlParameter("@hansd", product.HanSD));
        }
        #endregion
        #region Delete product
        public bool deleteProduct(ref string err, ProductDTO product)
        {
            return db.MyExcuteNonQuery("spDeleteSanPham", CommandType.StoredProcedure, ref err,
               new SqlParameter("@maSP", product.MaSP));
        }
        #endregion
    }
}