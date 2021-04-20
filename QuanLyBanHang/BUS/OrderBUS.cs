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
    public class OrderBUS
    {
        #region Khởi tạo cho lớp OrderDao
        private OrderDAO orderDAO;
        public OrderBUS()
        {
            orderDAO = new OrderDAO();
        }
        #endregion
        #region 0. Get Data
        public DataTable GetOrder()
        {
            return orderDAO.getOrder();
        }
        #endregion
        #region 1. Insert
        public bool InsertOrder(ref string error, OrderDTO order)
        {
            return orderDAO.insertOrder(ref error, order);
        }
        #endregion
        #region 2. Delete
        public bool DeleteOrder(ref string error, OrderDTO order)
        {
            return orderDAO.deleteOrder(ref error, order);
        }
        #endregion
    }
}
