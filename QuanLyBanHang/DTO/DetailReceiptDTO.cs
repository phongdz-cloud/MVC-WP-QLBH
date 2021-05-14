using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DetailReceiptDTO
    {
        private string idReceipt;
        private string idProduct;
        private int amount;
        public DetailReceiptDTO()
        {

        }
        public DetailReceiptDTO(string idReceipt, string idProduct,int amount)
        {
            IdReceipt = idReceipt;
            IdProduct = idProduct;
            Amount = amount;
        }

        public string IdReceipt { get => idReceipt; set => idReceipt = value; }
        public string IdProduct { get => idProduct; set => idProduct = value; }
        public int Amount { get => amount; set => amount = value; }
    }
}
