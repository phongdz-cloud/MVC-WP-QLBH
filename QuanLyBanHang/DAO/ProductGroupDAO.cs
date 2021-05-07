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

        public ProductGroupDAO()
        {
            
        }
        #region Lấy dữ liệu từ DataBase
        /*
         * Phương thức này có chức năng đưa dữ liệu từ nhóm sản phẩm xuống
         */
        public DataTable getProductGroup()
        {
            return DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM NHOMSANPHAM", CommandType.Text, null);
        }
        #endregion
        #region Insert product group
        public bool insertProductGroup(ref string err, ProductGroupDTO productGroup)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spInsertNhomSanPham", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MANHOMSP", productGroup.ManhomSP),
                new SqlParameter("@TENNHOMSP", productGroup.TennhomSP));
        }
        #endregion
        #region Update product group
        public bool updateProductGroup(ref string err, ProductGroupDTO productGroup)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spUpdateNhomSanPham", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MANHOMSP", productGroup.ManhomSP),
                new SqlParameter("@TENNHOMSP", productGroup.TennhomSP));
        }
        #endregion
        #region Delete product group
        public bool deleteProductGroup(ref string err, ProductGroupDTO productGroup)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spDeleteNhomSanPham", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MANHOMSP", productGroup.ManhomSP));
        }
        #endregion
    }
}
