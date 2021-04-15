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
    public class CustomerTypeBUS
    {
        #region Khởi tạo cho lớp CusomterBUS
        private  CustomerTypeDAO customerTypeDAO;
        public CustomerTypeBUS()
        {
            customerTypeDAO = new CustomerTypeDAO();
        }
        #endregion
        #region 0. Get Data
        public  DataTable GetCustomerType()
        {
            return customerTypeDAO.getCustomerType();
        }
        #endregion
    }
}
