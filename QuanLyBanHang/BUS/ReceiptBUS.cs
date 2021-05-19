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
    public class ReceiptBUS
    {
        ReceiptDAO receiptDAO = new ReceiptDAO();


        public bool InsertRecipt(ref string error, ReceiptDTO receipt)
        {
            return receiptDAO.insertReceipt(ref error, receipt);
        }
    }
}
