using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerDTO
    {
        #region Attributes Customer
        private string maKH;
        private string tenKH;
        private string gioiTinh;
        private string diaChi;
        private string dienThoai;
        private string maLoaiKH;
        private string images;
        #endregion
        #region Khởi tạo cho Customer
        public CustomerDTO()
        {

        }
        public CustomerDTO(string maKH, string tenKH, string gioiTinh, 
            string diaChi , string dienThoai, string maloaiKH)
        {
            MaKH = maKH;
            TenKH = tenKH;
            GioiTinh = gioiTinh;
            DiaChi = diaChi;
            DienThoai = dienThoai;
            MaLoaiKH = maLoaiKH;
        }
        #endregion
        #region Property cho lớp khách hàng
        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
        public string MaLoaiKH { get => maLoaiKH; set => maLoaiKH = value; }
        public string Images { get => images; set => images = value; }
        #endregion
    }
}
