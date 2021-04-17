using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SupplierDTO
    {
        #region Attributes Supplier
        private string maNCC;
        private string tenNCC;
        private string diaChi;
        private string sdt;
        private string email;
        #endregion
        #region Khởi tạo cho Supllier
        public SupplierDTO()
        {

        }
        public SupplierDTO(string maNCC, string tenNCC, string diaChi, string sdt, string email)
        {
            MaNCC = maNCC;
            TenNCC = tenNCC;
            DiaChi = diaChi;
            Sdt = sdt;
            Email = email;
        }
        #endregion
        #region Property cho lớp Supllier
        public string MaNCC { get => maNCC; set => maNCC = value; }
        public string TenNCC { get => tenNCC; set => tenNCC = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public string Email { get => email; set => email = value; }
        #endregion
    }
}
