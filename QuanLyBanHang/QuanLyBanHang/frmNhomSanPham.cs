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
    public partial class frmNhomSanPham : Form
    {
        #region Khởi tạo các lớp cần có của form khách hàng

        ProductGroupDTO productGroupDTO;
        ProductGroupBUS productGroupBUS = new ProductGroupBUS();
        private string err;
        private int flag;
        public frmNhomSanPham()
        {
            InitializeComponent();
        }
        #endregion
        #region Phương thức này có chức năng load dữ liệu nhóm sản phẩm từ Database
        private void load()
        {
            DataTable dbProductGroup = productGroupBUS.GetProductGroup();
            dgvNhomSanPham.DataSource = dbProductGroup;
        }
        #endregion
        #region Phương thức này có chức năng binding dữ liệu từ view lên property Product
        private void binding()
        {
            try // ở đây có 1 try catch chưa xử lý !!!
            {
                txtMaNhomSP.DataBindings.Clear();
                txtMaNhomSP.DataBindings.Add("Text", dgvNhomSanPham.DataSource, "MANHOMSP");
                txtTenNhomSP.DataBindings.Clear();
                txtTenNhomSP.DataBindings.Add("Text", dgvNhomSanPham.DataSource, "TENNHOMSP");
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
        #region Phương thức này có chức năng lấy dữ liệu từ các text box vào ProductGroupDTO
        private ProductGroupDTO getData()
        {
            ProductGroupDTO productGroupDTO = new ProductGroupDTO();
            productGroupDTO.ManhomSP = txtMaNhomSP.Text.Trim();
            productGroupDTO.TennhomSP = txtTenNhomSP.Text.Trim();
            return productGroupDTO;
        }
        #endregion
        #region Chức năng bật tắt property Product Group
        /*
         * Phương thức này có chức năng bật tắt các thuộc tính của nhóm sản phẩm
         */
        private void dis_en(bool e)
        {
            txtMaNhomSP.Enabled = e;
            txtTenNhomSP.Enabled = e;
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnSua.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
        }
        #endregion
        #region Sự kiện load form nhóm sản phẩm
        private void frmNhomSanPham_Load(object sender, EventArgs e)
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
                productGroupDTO = getData();
                if (productGroupBUS.DeleteProductGroup(ref err, productGroupDTO))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmNhomSanPham_Load(sender, e);
                }
                else
                {
                    MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
        #region Sự kiện lưu
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (flag == 0) // Insert
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn thêm không?", "Xác nhận hủy",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    productGroupDTO = getData();
                    if (productGroupBUS.InsertProductGroup(ref err, productGroupDTO))
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
                    productGroupDTO = getData();
                    if (productGroupBUS.UpdateProductGroup(ref err, productGroupDTO))
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
            frmNhomSanPham_Load(sender, e);
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
