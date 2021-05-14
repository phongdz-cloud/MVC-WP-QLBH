using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReceiptDTO
    {
        private string idHD;
        private string idCustomer;
        private string idEmployee;
        private double total;
        public ReceiptDTO()
        {

        }
        public ReceiptDTO(string idHD, string idCustomer, string idEmployee, double total)
        {
            IdHD = idHD;
            IdCustomer = idCustomer;
            IdEmployee = idEmployee;
            Total = total;
        }

        public string IdHD { get => idHD; set => idHD = value; }
        public string IdCustomer { get => idCustomer; set => idCustomer = value; }
        public string IdEmployee { get => idEmployee; set => idEmployee = value; }
        public double Total { get => total; set => total = value; }
    }
}
