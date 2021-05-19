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
    public class SupllierContractBUS
    {
        SupllierContractDAO supllierContractDAO;
        public SupllierContractBUS()
        {
            supllierContractDAO = new SupllierContractDAO();
        }
        public DataTable getSupllierContract()
        {
            return supllierContractDAO.getSupllierContract();
        }
        public bool InsertSupllerContract(ref string error, SupllerContractDTO supllerContractDTO)
        {
            return supllierContractDAO.insertSupllier(ref error, supllerContractDTO);
        }
    }
}
