using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace QuanLyBanHang
{
    public partial class FrmNhanVien : Form
    {
        #region Khởi tạo các thuộc tính cần có của form nhân viên
        EmployeeDTO employeeDTO;
        EmployeeBUS employeeBUS = new EmployeeBUS();
        private string err;
        private int flag;
        #endregion

        public FrmNhanVien()
        {
            InitializeComponent();
        }
        #region Phương thức này có chức năng load dữ nhân viên hàng từ Database
        private void load()
        {
            DataTable dbEmployee = employeeBUS.GetEmployee();
            dgvNhanVien.DataSource = dbEmployee;
        }
        #endregion
        #region Phương thức này có chức năng lấy dữ liệu từ các text box vào Customer DTO
        private EmployeeDTO getData()
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();
            employeeDTO.MaNV = txtMaNhanVien.Text.Trim();
            employeeDTO.HoTen = txtTenNhanVien.Text.Trim();
            employeeDTO.GioiTinh = cbbGioiTinh.Text;
            employeeDTO.NgaySinh = dtpNgaySinh.Text;
            employeeDTO.DiaChi = txtDiaChi.Text.Trim();
            employeeDTO.DienThoai = txtDienThoai.Text.Trim();
            employeeDTO.NgayVaoLam = dtpNgayVaoLam.Text;
            employeeDTO.GhiChu = txtGhiChu.Text;
            return employeeDTO;
        }
        #endregion
        #region Phương thức này có chức năng binding dữ liệu từ view lên property Employee
        private void binding()
        {
            try // ở đây có 1 try catch chưa xử lý !!!
            {
                txtMaNhanVien.DataBindings.Clear();
                txtMaNhanVien.DataBindings.Add("Text", dgvNhanVien.DataSource, "MANV");
                txtTenNhanVien.DataBindings.Clear();
                txtTenNhanVien.DataBindings.Add("Text", dgvNhanVien.DataSource, "HOTEN");
                cbbGioiTinh.DataBindings.Add("Text", dgvNhanVien.DataSource, "GIOITINH");
                dtpNgaySinh.DataBindings.Add("Text", dgvNhanVien.DataSource, "NGAYSINH");
                txtDiaChi.DataBindings.Clear();
                txtDiaChi.DataBindings.Add("Text", dgvNhanVien.DataSource, "DIENTHOAI");
                dtpNgayVaoLam.DataBindings.Add("Text", dgvNhanVien.DataSource, "NGAYVAOLAM");
                txtGhiChu.DataBindings.Clear();
                txtGhiChu.DataBindings.Add("Text", dgvNhanVien.DataSource, "GHICHU");
                txtDienThoai.DataBindings.Clear();
                txtDienThoai.DataBindings.Add("Text", dgvNhanVien.DataSource, "DIENTHOAI");
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region Chức năng bật tắt property Employee
        /*
         * Phương thức này có chức năng bật tắt các thuộc tính của khách hàng
         */
        private void dis_en(bool e)
        {
            txtMaNhanVien.Enabled = e;
            txtTenNhanVien.Enabled = e;
            txtGhiChu.Enabled = e;
            txtDienThoai.Enabled = e;
            txtDiaChi.Enabled = e;
            dtpNgaySinh.Enabled = e;
            dtpNgayVaoLam.Enabled = e;
            cbbGioiTinh.Enabled = e;
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnSua.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
        }
        #endregion
        #region Sự kiện load form
        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            load();
            binding();
            dis_en(false);
        }
        #endregion
        #region sự kiện Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            dis_en(true);
        }
        #endregion
        #region sự kiện sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            dis_en(true);
        }
        #endregion
        #region Sự kiện xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận hủy",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                employeeDTO = getData();
                if (employeeBUS.DeleteEmployee(ref err, employeeDTO))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmNhanVien_Load(sender, e);
                }
                else
                {
                    MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region sự kiện lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flag == 0) // Insert
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn thêm không?", "Xác nhận hủy",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    employeeDTO = getData();
                    if (employeeBUS.InsertEmployee(ref err, employeeDTO))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else MessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else // Update
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn sửa không?", "Xác nhận hủy",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    employeeDTO = getData();
                    if (employeeBUS.UpdateEmployee(ref err, employeeDTO))
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else MessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            FrmNhanVien_Load(sender, e);
            dis_en(false);
        }
        #endregion
        #region sự kiện hủy
        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn hủy thao tác này?", "Xác nhận hủy",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                dis_en(false);
            }
        }
        #endregion
    }
}
