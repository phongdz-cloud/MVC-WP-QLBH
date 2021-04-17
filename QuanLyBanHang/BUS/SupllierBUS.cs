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
    public class SupllierBUS
    {
        #region Khởi tạo cho lớp SupllierBus
        private SupplierDAO supplierDAO;
        public SupllierBUS()
        {
            supplierDAO = new SupplierDAO();
        }
        #endregion
        #region 0. Get Data
        public DataTable GetSupllier()
        {
            return supplierDAO.getSupllier();
        }
        #endregion
        #region 1. Insert
        public bool InsertSupllier(ref string error, SupplierDTO supplier)
        {
            return supplierDAO.insertSupllier(ref error, supplier);
        }
        #endregion
        #region 2. Update
        public bool UpdateSupllier(ref string error, SupplierDTO supplier)
        {
            return supplierDAO.updateSupllier(ref error, supplier);
        }
        #endregion
        #region 1. Delete
        public bool DeleteSupllier(ref string error, SupplierDTO supplier)
        {
            return supplierDAO.deleteSupllier(ref error, supplier);
        }
        #endregion
    }
}
