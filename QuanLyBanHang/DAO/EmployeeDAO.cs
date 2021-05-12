using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
namespace DAO
{
    public class EmployeeDAO
    {
        public EmployeeDAO()
        {
        }
        #region Lấy dữ liệu từ DataBase
        /*
         * Phương thức này có chức năng đưa dữ liệu từ bảng nhân viên xuống
         */
        public DataTable getEmployee()
        {
            // SQLDataReader 
            return DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM NHANVIEN", CommandType.Text, null);
        }
        #endregion
        #region Insert Employee
        public bool insertEmployee(ref string err, EmployeeDTO employee) // StoreProcedure <=> void ->> func -> return
        {
            return DBProvider.Instance.MyExcuteNonQuery("spInsertNhanVien", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MANV", employee.MaNV),
                new SqlParameter("@HOTEN", employee.HoTen),
                new SqlParameter("@GIOITINH", employee.GioiTinh),
                new SqlParameter("@NGAYSINH", employee.NgaySinh),
                new SqlParameter("@DIACHI", employee.DiaChi),
                new SqlParameter("@DIENTHOAI", employee.DienThoai),
                new SqlParameter("@NGAYVAOLAM", employee.NgayVaoLam),
                new SqlParameter("@SALARY", employee.Salary),
                new SqlParameter("@IMAGES", employee.Images));
        }
        #endregion
        #region Update Employee
        public bool updateEmployee(ref string err, EmployeeDTO employee)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spUpdateNhanVien", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MANV", employee.MaNV),
                new SqlParameter("@HOTEN", employee.HoTen),
                new SqlParameter("@GIOITINH", employee.GioiTinh),
                new SqlParameter("@NGAYSINH", employee.NgaySinh),
                new SqlParameter("@DIACHI", employee.DiaChi),
                new SqlParameter("@DIENTHOAI", employee.DienThoai),
                new SqlParameter("@NGAYVAOLAM", employee.NgayVaoLam),
                new SqlParameter("@SALARY", employee.Salary),
                new SqlParameter("@IMAGES", employee.Images));
        }
        #endregion
        #region Delete Employee
        public bool deleteEmployee(ref string err, EmployeeDTO employee)
        {
            return DBProvider.Instance.MyExcuteNonQuery("spDeleteNhanVien", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MANV", employee.MaNV));
        }
        #endregion
    }
}
