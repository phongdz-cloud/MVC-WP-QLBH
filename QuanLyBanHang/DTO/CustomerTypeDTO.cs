using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CustomerTypeDTO
    {
        #region Attributes Customer Type
        private string maLoaiKH;
        private string tenLoaiKH;
        #endregion
        #region Khởi tạo cho CustomerType
        public CustomerTypeDTO()
        {

        }
        public CustomerTypeDTO(string maLoaiKH, string tenLoaiKH)
        {
            MaLoaiKH = maLoaiKH;
            TenLoaiKH = tenLoaiKH;
        }
        #endregion
        #region Property cho CustomerType
        public string MaLoaiKH { get => maLoaiKH; set => maLoaiKH = value; }
        public string TenLoaiKH { get => tenLoaiKH; set => tenLoaiKH = value; }
        #endregion
    }
}
