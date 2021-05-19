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
    public class DetailSupllierContractDAO
    {
        public DetailSupllierContractDAO()
        {

        }
        public DataTable getDetailSupllierContract()
        {
            return DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM dbo.CHITIET_HDCCAP", CommandType.Text, null);
        }
        public bool insertDetailSupllierContract(ref string err, DetailSupllierContractDTO detailSupllierContract)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spInsertChiTietHDCC", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MAHD", detailSupllierContract.MaHD),
                new SqlParameter("@MASANPHAM", detailSupllierContract.MaSP),
                 new SqlParameter("@SOLUONG", detailSupllierContract.Sl),
                 new SqlParameter("@THANHTIEN", detailSupllierContract.ThanhTien),
                new SqlParameter("@GIAGOC", detailSupllierContract.GiaGoc));
        }
    }
}
