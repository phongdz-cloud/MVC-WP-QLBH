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
    public class DetailReceiptDAO
    {
        public DataTable getProduct()
        {
            return DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM dbo.CHITIET_HD", CommandType.Text, null);
        }
        public bool insertDetailReceipt(ref string err, DetailReceiptDTO detailReceipt)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spChiTiet_HD", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MHD", detailReceipt.IdReceipt),
                new SqlParameter("@MASANPHAM", detailReceipt.IdProduct),
                new SqlParameter("@SOLUONG", detailReceipt.Amount));
        }
    }
}
