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
    public class DetailReceiptBUS
    {

        DetailReceiptDAO detailReceiptDAO = new DetailReceiptDAO();
        public DataTable GetEmployee()
        {
            return detailReceiptDAO.getProduct();
        }
        public bool InsertDetailRecipt(ref string error, DetailReceiptDTO detailReceipt)
        {
            return detailReceiptDAO.insertDetailReceipt(ref error, detailReceipt);
        }
    }
}
