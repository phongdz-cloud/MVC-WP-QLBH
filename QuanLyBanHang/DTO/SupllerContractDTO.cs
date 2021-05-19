using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SupllerContractDTO
    {
        private string maHD;
        private string maNCC;
        public SupllerContractDTO()
        {

        }
        public SupllerContractDTO(string maHD, string maNCC)
        {
            MaHD = maHD;
            MaNCC = maNCC;
        }
        public string MaHD { get => maHD; set => maHD = value; }
        public string MaNCC { get => maNCC; set => maNCC = value; }
    }
}
