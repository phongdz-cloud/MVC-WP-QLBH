using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
namespace QuanLyBanHang
{
    public partial class frmViewEmployee : Form
    {
        private EmployeeDTO employeeDTO;
        public frmViewEmployee()
        {
            InitializeComponent();
        }
        public frmViewEmployee( EmployeeDTO employee)
        {
            employeeDTO = employee;
            InitializeComponent();
        }
        private void frmEmployeeDetailGuna_Load(object sender, EventArgs e)
        {
            lbID.Text = employeeDTO.MaNV;
            lbName.Text = employeeDTO.HoTen;
            lbSex.Text = employeeDTO.GioiTinh;
            lbBirthDay.Text = employeeDTO.NgaySinh;
            lbDiaChi.Text = employeeDTO.DiaChi;
            lbPhone.Text = employeeDTO.DienThoai;
            lbNgayVaoLam.Text = employeeDTO.NgayVaoLam;
            if (employeeDTO.Images.Length <= 0)
                pbAvatar.Image = Image.FromFile(@"C:\Users\dell\Desktop\CloneProject\Project-Qu-n-l-b-n-h-ng\QuanLyBanHang\QuanLyBanHang\Image\DSC3605.jpg");
            else
                pbAvatar.Image = Image.FromFile(@employeeDTO.Images);
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
