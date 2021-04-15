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
    public class CustomerBUS
    {
        #region Khởi tạo cho lớp CusomterBUS
        private  CustomerDAO customerDAO;
        public CustomerBUS()
        {
            customerDAO = new CustomerDAO();
        }
        #endregion
        #region 0. Get Data
        public  DataTable GetCustomer()
        {
            return customerDAO.getCustomer();
        }
        #endregion
        #region 1. Insert
        public  bool InsertCustomer(ref string error,CustomerDTO ctm)
        {
            return customerDAO.insertCustomer(ref error, ctm);
        }
        #endregion
        #region 2. Update
        public  bool UpdateCustomer(ref string error, CustomerDTO ctm)
        {
            return customerDAO.updateCustomer(ref error, ctm);
        }
        #endregion
        #region 3. Delete
        public  bool DeleteCustomer(ref string error, CustomerDTO ctm)
        {
            return customerDAO.deleteCustomer(ref error, ctm);
        }
        #endregion
    }
}
