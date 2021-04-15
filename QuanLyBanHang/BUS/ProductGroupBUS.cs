using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
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
    }
}
