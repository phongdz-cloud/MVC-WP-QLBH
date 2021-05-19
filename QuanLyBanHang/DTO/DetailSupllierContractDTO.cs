using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DetailSupllierContractDTO
    {
        private string maHD;
        private string maSP;
        private int sl;
        private double thanhTien;
        private int giaGoc;
        public DetailSupllierContractDTO()
        {

        }
        public DetailSupllierContractDTO(string maHD, string maSP, int sl, double thanhTien,int giaGoc)
        {
            MaHD = maHD;
            MaSP = maSP;
            Sl = sl;
            ThanhTien = thanhTien;
            GiaGoc = giaGoc;
        }

        public string MaHD { get => maHD; set => maHD = value; }
        public string MaSP { get => maSP; set => maSP = value; }
        public int Sl { get => sl; set => sl = value; }
        public double ThanhTien { get => thanhTien; set => thanhTien = value; }
        public int GiaGoc { get => giaGoc; set => giaGoc = value; }
    }
}
