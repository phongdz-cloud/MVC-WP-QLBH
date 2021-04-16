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
    public partial class frmLoaiKhachHang : Form
    {
        #region Khởi tạo các thuộc tính cần có của form loại khách hàng
        CustomerTypeDTO customerTypeDTO;
        CustomerTypeBUS customerTypeBUS = new CustomerTypeBUS();
        private string err;
        private int flag;
        public frmLoaiKhachHang()
        {
            InitializeComponent();
        }
        #endregion
        #region Phương thức này có chức năng load dữ liệu loại khách hàng từ Database
        private void load()
        {
            DataTable dbCustomerType = customerTypeBUS.GetCustomerType();
            dgvLoaiKhachHang.DataSource = dbCustomerType;
        }
        #endregion
        #region Phương thức này có chức năng binding dữ liệu từ view lên property CustomerType
        private void binding()
        {
            try // ở đây có 1 try catch chưa xử lý !!!
            {
                txtMaLoaiKH.DataBindings.Clear();
                txtMaLoaiKH.DataBindings.Add("Text", dgvLoaiKhachHang.DataSource, "MALOAIKH");
                txtTenLoai.DataBindings.Clear();
                txtTenLoai.DataBindings.Add("Text", dgvLoaiKhachHang.DataSource, "TENLOAI");
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
        #region Phương thức này có chức năng lấy dữ liệu từ các text box vào CustomerTypeDTO
        private CustomerTypeDTO getData()
        {
            CustomerTypeDTO customerTypeDTO = new CustomerTypeDTO();
            customerTypeDTO.MaLoaiKH = txtMaLoaiKH.Text.Trim();
            customerTypeDTO.TenLoaiKH = txtTenLoai.Text.Trim();
            return customerTypeDTO;
        }
        #endregion
        #region Chức năng bật tắt property Customer Type
        /*
         * Phương thức này có chức năng bật tắt các thuộc tính của loại khách hàng
         */
        private void dis_en(bool e)
        {
            txtMaLoaiKH.Enabled = e;
            txtTenLoai.Enabled = e;
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnSua.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
        }
        #endregion
        #region Sự kiện load form loại khách hàng
        private void frmLoaiKhachHang_Load(object sender, EventArgs e)
        {
            load();
            binding();
            dis_en(false);
        }
        #endregion
        #region Sự kiện thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            dis_en(true);
        }
        #endregion
        #region Sự kiện sửa
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
                customerTypeDTO = getData();
                if (customerTypeBUS.DeleteCustomerType(ref err, customerTypeDTO))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region Sự kiện Lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flag == 0) // Insert
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn thêm không?", "Xác nhận hủy",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    customerTypeDTO = getData();
                    if (customerTypeBUS.InsertCustomerType(ref err, customerTypeDTO))
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
                    customerTypeDTO = getData();
                    if (customerTypeBUS.UpdateCustomerType(ref err, customerTypeDTO))
                    {
                        MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else MessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            dis_en(false);
        }
        #endregion
        #region Sự kiện hiển thị
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            frmLoaiKhachHang_Load(sender, e);
            dis_en(false);
        }
        #endregion
        #region Sự kiện hủy
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
