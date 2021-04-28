using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDTO
    {
        #region Attributes Order
        private string maDDH;
        private string ghiChu;
        private string maKH;
        private string maNV;
        #endregion
        #region Khởi tạo cho Order
        public OrderDTO()
        {

        }
        public OrderDTO(string maDDH, string ghiChu, string maKH, string maNV)
        {
            MaDDH = maDDH;
            GhiChu = ghiChu;
            MaKH = maKH;
            MaNV = maNV;
        }
        #endregion
        #region Property cho lớp Order
        public string MaDDH { get => maDDH; set => maDDH = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public string MaKH { get => maKH; set => maKH = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        #endregion

    }
}
