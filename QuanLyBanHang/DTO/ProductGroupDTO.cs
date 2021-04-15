using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductGroupDTO
    {
        #region Attributes Product Group
        private string manhomSP;
        private string tennhomSP;
        #endregion
        #region Khởi tạo cho Product Group
        public ProductGroupDTO()
        {

        }
        public ProductGroupDTO(string manhomSP, string tennhomSP)
        {
            ManhomSP = manhomSP;
            TennhomSP = tennhomSP;
        }
        #endregion
        #region Property cho Product Group
        public string ManhomSP { get => manhomSP; set => manhomSP = value; }
        public string TennhomSP { get => tennhomSP; set => tennhomSP = value; }
        #endregion
    }
}
