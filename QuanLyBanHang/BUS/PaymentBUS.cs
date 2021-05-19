using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Data;
namespace BUS
{
    public class PaymentBUS
    {
        private PaymentDAO paymentDAO;
        public PaymentBUS()
        {
            paymentDAO = new PaymentDAO();
        }
        public DataTable getPayment()
        {
            return paymentDAO.getPayment();
        }
        public bool InsertPayment(ref string error, PaymentDTO payment)
        {
            return paymentDAO.insertPayment(ref error, payment);
        }
    }
}
