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
    public class ProductBUS
    {
        #region Khởi tạo cho lớp CusomterBUS
        private ProductDAO productDAO;
        public ProductBUS()
        {
            productDAO = new ProductDAO();
        }
        #endregion
        #region 0. Get Data
        public DataTable GetProduct()
        {
            return productDAO.getProduct();
        }
        #endregion
        #region 1. Insert
        public bool InsertProduct(ref string error, ProductDTO pdt)
        {
            return productDAO.insertProduct(ref error, pdt);
        }
        #endregion
        #region 2. Update
        public bool UpdateProduct(ref string error, ProductDTO pdt)
        {
            return productDAO.updateProduct(ref error, pdt);
        }
        #endregion
        #region 3. Delete
        public bool DeleteProduct(ref string error, ProductDTO pdt)
        {
            return productDAO.deleteProduct(ref error, pdt);
        }
        #endregion
    }
}
