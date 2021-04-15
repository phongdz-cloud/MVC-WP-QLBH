﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class EmployeeDTO
    {
        #region Attributes Employee
        private string maNV;
        private string hoTen;
        private string gioiTinh;
        private string ngaySinh;
        private string diaChi;
        private string dienThoai;
        private string ngayVaoLam;
        private string ghiChu;
        #endregion
        #region Khởi tạo cho Employee
        public EmployeeDTO()
        {

        }
        public EmployeeDTO(string maNV, string hoTen, string gioiTinh, string ngaySinh, string diaChi
            , string dienThoai, string ngayVaoLam, string ghiChu)
        {
            MaNV = maNV;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            DiaChi = diaChi;
            DienThoai = dienThoai;
            NgayVaoLam = ngayVaoLam;
            GhiChu = ghiChu;
        }
        #endregion
        #region Property cho lớp Employee
        public string MaNV { get => maNV; set => maNV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string DienThoai { get => dienThoai; set => dienThoai = value; }
        public string NgayVaoLam { get => ngayVaoLam; set => ngayVaoLam = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        #endregion
    }
}