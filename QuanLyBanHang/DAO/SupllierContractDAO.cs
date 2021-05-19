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
    public class SupllierContractDAO
    {
        public SupllierContractDAO()
        {

        }
        public DataTable getSupllierContract()
        {
            return DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM dbo.HOPDONGCUNGCAP", CommandType.Text, null);
        }
        public bool insertSupllier(ref string err, SupllerContractDTO supllierContract)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spInsertHopDongCungCap", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MAHD", supllierContract.MaHD),
                new SqlParameter("@MANCC", supllierContract.MaNCC));
        }
    }
}
