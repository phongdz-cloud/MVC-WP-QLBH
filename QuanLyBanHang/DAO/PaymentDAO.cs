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
    public class PaymentDAO
    {
        public PaymentDAO()
        {

        }
        public DataTable getPayment()
        {
            return DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM dbo.PHIEUCHI", CommandType.Text, null);
        }
        public bool insertPayment(ref string err, PaymentDTO paymentDTO)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spInsertPhieuChi", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MAPHIEUCHI", paymentDTO.IdPayment),
                new SqlParameter("@MAHD", paymentDTO.MaHD),
                 new SqlParameter("@MANV", paymentDTO.MaNV),
                new SqlParameter("@SOTIENCHI", paymentDTO.Total));
        }

    }
}
