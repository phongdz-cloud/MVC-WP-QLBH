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
    public class DetailSupllierContractBUS
    {
        private DetailSupllierContractDAO detailSupllierContractDAO = new DetailSupllierContractDAO();
        public DetailSupllierContractBUS()
        {

        }
        public DataTable getSupllierContract()
        {
            return detailSupllierContractDAO.getDetailSupllierContract();
        }
        public bool InsertDetailSupllierContract(ref string error, DetailSupllierContractDTO detailSupllierContractDTO)
        {
            return detailSupllierContractDAO.insertDetailSupllierContract(ref error, detailSupllierContractDTO);
        }

    }
}
