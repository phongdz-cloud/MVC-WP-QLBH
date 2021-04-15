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
    public class EmployeeBUS
    {
        #region Khởi tạo cho lớp EmployeeBUS
        private EmployeeDAO employeeDAO;
        public EmployeeBUS()
        {
            employeeDAO = new EmployeeDAO();
        }
        #endregion
        #region 0. Get Data
        public DataTable GetEmployee()
        {
            return employeeDAO.getEmployee();
        }
        #endregion
        #region 1. Insert Employee
        public bool InsertEmployee(ref string error, EmployeeDTO employee)
        {
            return employeeDAO.insertEmployee(ref error, employee);
        }
        #endregion
        #region 2. Update Employee
        public bool UpdateEmployee(ref string error, EmployeeDTO employee)
        {
            return employeeDAO.updateEmployee(ref error, employee);
        }
        #endregion
        #region 3. Delete Employee
        public bool DeleteEmployee(ref string error, EmployeeDTO employee)
        {
            return employeeDAO.deleteEmployee(ref error, employee);
        }
        #endregion
    }
}
