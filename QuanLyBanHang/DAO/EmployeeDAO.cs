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
        #region Mở kết nối 
        DBProvider db;
        public EmployeeDAO()
        {
            db = new DBProvider();
        }
        #endregion
        #region Lấy dữ liệu từ DataBase
        /*
         * Phương thức này có chức năng đưa dữ liệu từ bảng nhân viên xuống
         */
        public DataTable getEmployee()
        {
            return db.ExecuteQueryDataTable("SELECT * FROM NHANVIEN", CommandType.Text, null);
        }
        #endregion
        #region Insert Employee
        public bool insertEmployee(ref string err, EmployeeDTO employee)
        {
            return db.MyExcuteNonQuery("spInsertNhanVien", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MANV", employee.MaNV),
                new SqlParameter("@HOTEN", employee.HoTen),
                new SqlParameter("@GIOITINH", employee.GioiTinh),
                new SqlParameter("@NGAYSINH", employee.NgaySinh),
                new SqlParameter("@DIACHI", employee.DiaChi),
                new SqlParameter("@DIENTHOAI", employee.DienThoai),
                new SqlParameter("@NGAYVAOLAM", employee.NgayVaoLam),
                new SqlParameter("@GHICHU", employee.GhiChu));
        }
        #endregion
        #region Update Employee
        public bool updateEmployee(ref string err, EmployeeDTO employee)
        {
            return db.MyExcuteNonQuery("spUpdateNhanVien", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MANV", employee.MaNV),
                new SqlParameter("@HOTEN", employee.HoTen),
                new SqlParameter("@GIOITINH", employee.GioiTinh),
                new SqlParameter("@NGAYSINH", employee.NgaySinh),
                new SqlParameter("@DIACHI", employee.DiaChi),
                new SqlParameter("@DIENTHOAI", employee.DienThoai),
                new SqlParameter("@NGAYVAOLAM", employee.NgayVaoLam),
                new SqlParameter("@GHICHU", employee.GhiChu));
        }
        #endregion
        #region Delete Employee
        public bool deleteEmployee(ref string err, EmployeeDTO employee)
        {
            return db.MyExcuteNonQuery("spDeleteNhanVien", CommandType.StoredProcedure, ref err,
               new SqlParameter("@MANV", employee.MaNV));

        }
        #endregion
    }
}
