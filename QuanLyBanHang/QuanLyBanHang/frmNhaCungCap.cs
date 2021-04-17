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
    public partial class frmNhaCungCap : Form
    {
        #region Khởi tạo các lớp cần có của form nhà cung cấp

        SupllierBUS supllierBus = new SupllierBUS();
        SupplierDTO supplier;
        private string err;
        private int flag;
        #endregion
        public frmNhaCungCap()
        {
            InitializeComponent();
        }
        #region Phương thức này có chức năng load dữ liệu nhà cung cấp từ Database
        private void load()
        {
            DataTable dbSupllier = supllierBus.GetSupllier();
            dgvSup.DataSource = dbSupllier;
        }
        #endregion
        #region Phương thức này có chức năng binding dữ liệu từ view lên property Supllier
        private void binding()
        {
            try // ở đây có 1 try catch chưa xử lý !!!
            {
                txtMaNCC.DataBindings.Clear();
                txtMaNCC.DataBindings.Add("Text", dgvSup.DataSource, "MANCC");
                txtTenNCC.DataBindings.Clear();
                txtTenNCC.DataBindings.Add("Text", dgvSup.DataSource, "TENNCC");
                txtDiaChi.DataBindings.Clear();
                txtDiaChi.DataBindings.Add("Text", dgvSup.DataSource, "DIACHI");
                txtSDT.DataBindings.Clear();
                txtSDT.DataBindings.Add("Text", dgvSup.DataSource, "DIENTHOAI");
                txtEmail.DataBindings.Clear();
                txtEmail.DataBindings.Add("Text", dgvSup.DataSource, "EMAIL");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        #region Chức năng bật tắt property Supllier
        /*
         * Phương thức này có chức năng bật tắt các thuộc tính của sản phẩm
         */
        private void dis_en(bool e)
        {
            txtMaNCC.Enabled = e;
            txtTenNCC.Enabled = e;
            txtDiaChi.Enabled = e;
            txtSDT.Enabled = e;
            txtEmail.Enabled = e;
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnSua.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
        }
        #endregion
        #region Sự kiện load form
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            load();
            binding();
            dis_en(false);
        }
        #endregion
        #region Phương thức này có chức năng lấy dữ liệu từ các text box vào ProductDTO
        private SupplierDTO getData()
        {
            SupplierDTO supplier = new SupplierDTO();
            supplier.MaNCC = txtMaNCC.Text.Trim();
            supplier.TenNCC = txtTenNCC.Text.Trim();
            supplier.DiaChi = txtDiaChi.Text.Trim();
            supplier.Sdt = txtSDT.Text.Trim();
            supplier.Email = txtEmail.Text.Trim();
            return supplier;
        }
        #endregion
        #region Sự kiện thêm
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
        #region sự kiện xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận hủy",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                supplier = getData();
                if (supllierBus.DeleteSupllier(ref err, supplier))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmNhaCungCap_Load(sender, e);
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
                    supplier = getData();
                    if (supllierBus.InsertSupllier(ref err, supplier))
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
                    supplier = getData();
                    if (supllierBus.UpdateSupllier(ref err, supplier))
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
        #region sự kiện hiển thị
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            frmNhaCungCap_Load(sender, e);
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
