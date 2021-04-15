using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerTypeDTO
    {
        private string maLoaiKH;
        private string tenLoaiKH;
        public CustomerTypeDTO()
        {

        }
        public CustomerTypeDTO(string maLoaiKH, string tenLoaiKH)
        {
            MaLoaiKH = maLoaiKH;
            TenLoaiKH = tenLoaiKH;
        }
        public string MaLoaiKH { get => maLoaiKH; set => maLoaiKH = value; }
        public string TenLoaiKH { get => tenLoaiKH; set => tenLoaiKH = value; }
    }
}
