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
               new SqlParameter("@MASANPHAM", product.MaSP),
                new SqlParameter("@TENSANPHAM", product.TenSP),
                new SqlParameter("@GIABAN", product.GiaBan),
                new SqlParameter("@SOLUONGTON", product.SlTon),
                new SqlParameter("@MANHOMSP", product.ManhomSP),
                new SqlParameter("@NUOCSX", product.NuocSX),
                new SqlParameter("@NGAYSX", product.NgaySX),
                new SqlParameter("@HANSD", product.HanSD));
        }
        #endregion
        #region Update product
        public bool updateProduct(ref string err, ProductDTO product)
        {
            return db.MyExcuteNonQuery("spUpdateSanPham", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MASANPHAM", product.MaSP),
                new SqlParameter("@TENSANPHAM", product.TenSP),
                new SqlParameter("@GIABAN", product.GiaBan),
                new SqlParameter("@SOLUONGTON", product.SlTon),
                new SqlParameter("@MANHOMSP", product.ManhomSP),
                new SqlParameter("@NUOCSX", product.NuocSX),
                new SqlParameter("@NGAYSX", product.NgaySX),
                new SqlParameter("@HANSD", product.HanSD));
        }
        #endregion
        #region Delete product
        public bool deleteProduct(ref string err, ProductDTO product)
        {
            return db.MyExcuteNonQuery("spDeleteSanPham", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MASANPHAM", product.MaSP));
        }
        #endregion
    }
}