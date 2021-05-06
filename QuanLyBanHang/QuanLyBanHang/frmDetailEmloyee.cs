using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DTO;
using BUS;
using Function;
namespace QuanLyBanHang
{
    public partial class frmDetailEmloyee : Form
    {
        private EmployeeDTO employeeDTO = new EmployeeDTO();
        private EmployeeBUS employeeBUS = new EmployeeBUS();
        private string nvID = null;
        private string err;
        private bool flag = false;
        public frmDetailEmloyee()
        {
            InitializeComponent();
        }
        public frmDetailEmloyee( EmployeeDTO employee)
        {
            InitializeComponent();
            employeeDTO = employee;
        }
        private void btnBrown_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp;";
            if(open.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = open.FileName;
                pbAvatar.Image = new Bitmap(open.FileName);
            }
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void getData()
        {
            employeeDTO.MaNV = txtID.Text.Trim();
            employeeDTO.HoTen = txtName.Text.Trim();
            employeeDTO.GioiTinh = cbbSex.Text;
            employeeDTO.NgaySinh = dtpNgaySinh.Text;
            employeeDTO.DiaChi = txtDiaChi.Text;
            employeeDTO.DienThoai = txtPhone.Text.Trim();
            employeeDTO.NgayVaoLam = dtpNgayVaoLam.Text;
            employeeDTO.Images = txtFileName.Text;
        }
        private void btnRest_Click(object sender, EventArgs e)
        {
            txtID.ResetText();
            txtName.ResetText();
            cbbSex.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now;
            txtDiaChi.ResetText();
            txtPhone.ResetText();
            dtpNgayVaoLam.Value = DateTime.Now;
            pbAvatar.Image = Image.FromFile(@"C:\Users\dell\Desktop\CloneProject\Project-Qu-n-l-b-n-h-ng\QuanLyBanHang\QuanLyBanHang\Image\DSC3605.jpg");
        }

        private void frmRegisterEmployee_Load(object sender, EventArgs e)
        {
            txtID.Text = employeeDTO.MaNV;
            txtName.Text = employeeDTO.HoTen;
            cbbSex.Text = employeeDTO.GioiTinh;
            dtpNgaySinh.Text = employeeDTO.NgaySinh;
            txtDiaChi.Text = employeeDTO.DiaChi;
            txtPhone.Text = employeeDTO.DienThoai;
            dtpNgayVaoLam.Text = employeeDTO.NgayVaoLam;
            OpenFileDialog open = new OpenFileDialog();
            if (employeeDTO.Images.Length <= 0)
            {
                pbAvatar.Image = Image.FromFile(@"C:\Users\dell\Desktop\CloneProject\Project-Qu-n-l-b-n-h-ng\QuanLyBanHang\QuanLyBanHang\Image\DSC3605.jpg");
                open.FileName = @"C:\Users\dell\Desktop\CloneProject\Project-Qu-n-l-b-n-h-ng\QuanLyBanHang\QuanLyBanHang\Image\DSC3605.jpg";
                txtFileName.Text = open.FileName;
            }
            else
            {
                pbAvatar.Image = Image.FromFile(@employeeDTO.Images);
                open.FileName = @employeeDTO.Images;
                txtFileName.Text = open.FileName;
            }
        }
        public void loadForm(ref bool flag1)
        {
            flag1 = flag;
        }
        private void guna2TileButton1_Click(object sender, EventArgs e)
        {
            if (nvID == null) nvID = Func.taoID(6, ref err);
            if (nvID != null)
            {
                txtID.Text = nvID;
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn thêm không?", "Xác nhận hủy",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    getData();
                    if (employeeBUS.InsertEmployee(ref err, employeeDTO))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        nvID = null;
                        flag = true;
                        Func.updateAutoID();
                    }
                    else MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
          
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn sửa không?", "Xác nhận hủy",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                getData();
                if (employeeBUS.UpdateEmployee(ref err, employeeDTO))
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flag = true;
                }
                else MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
