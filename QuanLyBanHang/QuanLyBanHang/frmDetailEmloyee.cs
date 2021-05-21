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
using BUS;
using Function;
namespace QuanLyBanHang
{
    public partial class frmDetailEmloyee : Form
    {
        private EmployeeBUS employeeBUS = new EmployeeBUS();
        private Byte[] ImageByteArray;
        private string nvID = null;
        private string err;
        private bool flag = false;
        public frmDetailEmloyee()
        {
            InitializeComponent();
        }
        public void Init()
        {

        }
        private void btnBrown_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp;";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    txtFileName.Text = open.FileName;
                }
                Image temp = new Bitmap(open.FileName);
                MemoryStream strm = new MemoryStream();
                temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                ImageByteArray = strm.ToArray();
                pbAvatar.Image = Image.FromStream(new MemoryStream(ImageByteArray));
            }
            catch (Exception ex)
            { }

        }
        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
                this.Close();
        }
        private void getData()
        {
            frmEmployeeGuna.Instance.EmployeeDTO.MaNV = txtID.Text.Trim();
            frmEmployeeGuna.Instance.EmployeeDTO.HoTen = txtName.Text.Trim();
            frmEmployeeGuna.Instance.EmployeeDTO.GioiTinh = cbbSex.Text;
            frmEmployeeGuna.Instance.EmployeeDTO.NgaySinh = dtpNgaySinh.Text;
            frmEmployeeGuna.Instance.EmployeeDTO.DiaChi = txtDiaChi.Text;
            frmEmployeeGuna.Instance.EmployeeDTO.DienThoai = txtPhone.Text.Trim();
            frmEmployeeGuna.Instance.EmployeeDTO.NgayVaoLam = dtpNgayVaoLam.Text;
            frmEmployeeGuna.Instance.EmployeeDTO.Salary = Convert.ToInt32(txtSalary.Text);
            if (ImageByteArray != null)
            frmEmployeeGuna.Instance.EmployeeDTO.Images = ImageByteArray;
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
        }

        private void frmRegisterEmployee_Load(object sender, EventArgs e)
        {
            txtID.Text = frmEmployeeGuna.Instance.EmployeeDTO.MaNV;
            txtName.Text = frmEmployeeGuna.Instance.EmployeeDTO.HoTen;
            cbbSex.Text = frmEmployeeGuna.Instance.EmployeeDTO.GioiTinh;
            dtpNgaySinh.Text = frmEmployeeGuna.Instance.EmployeeDTO.NgaySinh;
            txtDiaChi.Text = frmEmployeeGuna.Instance.EmployeeDTO.DiaChi;
            txtPhone.Text = frmEmployeeGuna.Instance.EmployeeDTO.DienThoai;
            dtpNgayVaoLam.Text = frmEmployeeGuna.Instance.EmployeeDTO.NgayVaoLam;
            txtSalary.Text = frmEmployeeGuna.Instance.EmployeeDTO.Salary.ToString();
            pbAvatar.Image = 
                Image.FromStream(
                    new MemoryStream(frmEmployeeGuna.Instance.EmployeeDTO.Images));
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
                    if (employeeBUS.InsertEmployee(ref err, frmEmployeeGuna.Instance.EmployeeDTO))
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
                if (employeeBUS.UpdateEmployee(ref err, frmEmployeeGuna.Instance.EmployeeDTO))
                {
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flag = true;
                }
                else MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
