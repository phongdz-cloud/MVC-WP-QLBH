using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
namespace QuanLyBanHang
{
    public partial class frmViewEmployee : Form
    {

        public frmViewEmployee()
        {
            InitializeComponent();
        }
        private void frmEmployeeDetailGuna_Load(object sender, EventArgs e)
        {
            lbID.Text = frmEmployeeGuna.Instance.EmployeeDTO.MaNV;
            lbName.Text = frmEmployeeGuna.Instance.EmployeeDTO.HoTen;
            lbSex.Text = frmEmployeeGuna.Instance.EmployeeDTO.GioiTinh;
            lbBirthDay.Text = frmEmployeeGuna.Instance.EmployeeDTO.NgaySinh;
            lbDiaChi.Text = frmEmployeeGuna.Instance.EmployeeDTO.DiaChi;
            lbPhone.Text = frmEmployeeGuna.Instance.EmployeeDTO.DienThoai;
            lbNgayVaoLam.Text = frmEmployeeGuna.Instance.EmployeeDTO.NgayVaoLam;
            pbAvatar.Image = Image.FromStream(new MemoryStream(frmEmployeeGuna.Instance.EmployeeDTO.Images));
        }
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
                this.Close();
        }
       
        private void frmViewEmployee_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
