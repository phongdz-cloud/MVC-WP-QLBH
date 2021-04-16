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
        #region Khởi tạo cho lớp CusomterTypeBUS
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
        #region 1. Insert
        public bool InsertCustomerType(ref string error, CustomerTypeDTO ctm)
        {
            return customerTypeDAO.insertCustomerType(ref error, ctm);
        }
        #endregion
        #region 2. Update
        public bool UpdateCustomerType(ref string error, CustomerTypeDTO ctm)
        {
            return customerTypeDAO.updateCustomerType(ref error, ctm);
        }
        #endregion
        #region 3. Delete
        public bool DeleteCustomerType(ref string error, CustomerTypeDTO ctm)
        {
            return customerTypeDAO.deleteCustomerType(ref error, ctm);
        }
        #endregion
    }
}
