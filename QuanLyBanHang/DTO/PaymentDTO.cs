using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PaymentDTO
    {
        private string idPayment;
        private string maHD;
        private string maNV;
        private double total;
        public PaymentDTO()
        {

        }
        public PaymentDTO(string idPayment,string maHD, string maNV, double total)
        {
            IdPayment = idPayment;
            MaHD = maHD;
            MaNV = maNV;
            Total = total;
        }

        public string IdPayment { get => idPayment; set => idPayment = value; }
        public string MaHD { get => maHD; set => maHD = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public double Total { get => total; set => total = value; }
    }
}
