using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAO
{
    public class ReceiptDAO
    {
        public DataTable getProduct()
        {
            return DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM dbo.HOADON", CommandType.Text, null);
        }
        public bool insertReceipt(ref string err, ReceiptDTO receipt)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spInsertHoaDon", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MAHD", receipt.IdHD),
                new SqlParameter("@MAKHACHHANG", receipt.IdCustomer),
                new SqlParameter("@MANHANVIEN", receipt.IdEmployee),
                new SqlParameter("@THANHTIEN", receipt.Total));
        }
    }
}
