using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Data;
namespace BUS
{
    public class ProductGroupBUS
    {
        #region Khởi tạo cho lớp ProductGroupDAO
        private ProductGroupDAO productGroupDAO;
        public ProductGroupBUS()
        {
            productGroupDAO = new ProductGroupDAO();
        }
        #endregion
        #region 0. Get Data
        public DataTable GetProductGroup()
        {
            return productGroupDAO.getProductGroup();
        }
        #endregion
        #region 1. Insert
        public bool InsertProductGroup(ref string error, ProductGroupDTO productGroup)
        {
            return productGroupDAO.insertProductGroup(ref error, productGroup);
        }
        #endregion
        #region 2. Update
        public bool UpdateProductGroup(ref string error, ProductGroupDTO productGroup)
        {
            return productGroupDAO.updateProductGroup(ref error, productGroup);
        }
        #endregion
        #region 3. Delete
        public bool DeleteProductGroup(ref string error, ProductGroupDTO productGroup)
        {
            return productGroupDAO.deleteProductGroup(ref error, productGroup);
        }
        #endregion
    }
}
