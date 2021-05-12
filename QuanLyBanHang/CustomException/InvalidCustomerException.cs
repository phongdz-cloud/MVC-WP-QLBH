using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace CustomException
{
    public class InvalidCustomerException
    {
        private string message;
        public InvalidCustomerException()
        {

        }

        public string Message { get => message; private set => message = value; }

    }
}
