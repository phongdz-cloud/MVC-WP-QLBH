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
using Function;
namespace QuanLyBanHang
{
    public partial class frmKhachHang : Form
    {
        #region Khởi tạo các thuộc tính cần có của form khách hàng
        CustomerDTO customerDTO;
        CustomerBUS customerBUS = new CustomerBUS();
        CustomerTypeBUS customerTypeBUS = new CustomerTypeBUS();
        private string err;
        private int flag;
        public frmKhachHang()
        {
            InitializeComponent();
        }
        #endregion
        #region Sự kiện load form
        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            load();
            binding();
            dis_en(false);
        }
        #endregion
        #region Chức năng bật tắt property Customer
        /*
         * Phương thức này có chức năng bật tắt các thuộc tính của khách hàng
         */
        private void dis_en(bool e)
        {
            txtMaKhachHang.Enabled = e;
            txtTenKhachHang.Enabled = e;
            cbbGioiTinh.Enabled = e;
            cbbMaLoaiKH.Enabled = e;
            txtDiaChi.Enabled = e;
            txtDienThoai.Enabled = e;
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnSua.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
        }
        #endregion
        #region Phương thức này có chức năng load dữ liệu khách hàng từ Database
        private void load()
        {
            DataTable dbCustomerType = customerTypeBUS.GetCustomerType();
            MaLoaiKH.DataSource = dbCustomerType;
            MaLoaiKH.DisplayMember = "TENLOAI";
            MaLoaiKH.ValueMember = "MALOAIKH";
            DataTable dbCustomer = customerBUS.GetCustomer();
            dgvKhachHang.DataSource = dbCustomer;
        }
        #endregion
        #region Phương thức này có chức năng binding dữ liệu từ view lên property Customer
        private void binding()
        {
            try // ở đây có 1 try catch chưa xử lý !!!
            {
                txtMaKhachHang.DataBindings.Clear();
                txtMaKhachHang.DataBindings.Add("Text", dgvKhachHang.DataSource, "MAKH");
                txtTenKhachHang.DataBindings.Clear();
                txtTenKhachHang.DataBindings.Add("Text", dgvKhachHang.DataSource, "TENKH");
                cbbGioiTinh.DataBindings.Add("Text", dgvKhachHang.DataSource, "GIOITINH");
                txtDiaChi.DataBindings.Clear();
                txtDiaChi.DataBindings.Add("Text", dgvKhachHang.DataSource, "DIACHI");
                txtDienThoai.DataBindings.Clear();
                txtDienThoai.DataBindings.Add("Text", dgvKhachHang.DataSource, "DIENTHOAI");
                cbbMaLoaiKH.DataBindings.Add("Text", dgvKhachHang.DataSource, "MALOAIKH");
            }catch(Exception ex)
            {

            }
        }
        #endregion
        #region Phương thức này có chức năng lấy dữ liệu từ các text box vào Customer DTO
        private CustomerDTO getData()
        {
            CustomerDTO customerDTO = new CustomerDTO();
            customerDTO.MaKH = txtMaKhachHang.Text.Trim();
            customerDTO.TenKH = txtTenKhachHang.Text.Trim();
            customerDTO.GioiTinh = cbbGioiTinh.Text.Trim();
            customerDTO.DiaChi = txtDiaChi.Text.Trim();
            customerDTO.DienThoai = txtDienThoai.Text.Trim();
            customerDTO.MaLoaiKH = cbbMaLoaiKH.Text.Trim();
            return customerDTO;
        }
        #endregion
        #region Sự kiện thêm click
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            dis_en(true);
            txtMaKhachHang.Text = Func.taoID(3, ref err);
        }
        #endregion
        #region Sự kiện sửa click
        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            dis_en(true);
        }
        #endregion
        #region Sự kiện xóa click
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận hủy",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                customerDTO = getData();
                if(customerBUS.DeleteCustomer(ref err,customerDTO))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmKhachHang_Load(sender, e);
                }
                else
                {
                    MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region Sự kiện Lưu click
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(flag == 0) // Insert
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn thêm không?", "Xác nhận hủy",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dr == DialogResult.Yes)
                {
                    customerDTO = getData();
                    if(customerBUS.InsertCustomer(ref err,customerDTO))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        Func.updateAutoID();
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
                    customerDTO = getData();
                    if (customerBUS.UpdateCustomer(ref err, customerDTO))
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else MessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            frmKhachHang_Load(sender, e);
            dis_en(false);
        }
        #endregion
        #region Sự kiện hủy click
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
