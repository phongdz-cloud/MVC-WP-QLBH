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
    public partial class frmSanPham : Form
    {
        #region Khởi tạo các lớp cần có của form khách hàng
        
        ProductGroupBUS productGroupBUS = new ProductGroupBUS();
        ProductBUS productBUS = new ProductBUS();
        ProductDTO product;
        private string err;
        private int flag;
        public frmSanPham()
        {
            InitializeComponent();
        }
        #endregion
        #region Phương thức này có chức năng load dữ liệu sản phẩm từ Database
        private void load()
        {
            DataTable dbProductType = productGroupBUS.GetProductGroup();
            MANHOMSP.DataSource = dbProductType;
            MANHOMSP.DisplayMember = "TENNHOMSP";
            MANHOMSP.ValueMember = "MANHOMSP";
            cbbNhomSP.DataSource = dbProductType;
            cbbNhomSP.DisplayMember = "MANHOMSP";
            cbbNhomSP.ValueMember = "MANHOMSP";
            DataTable dbProduct = productBUS.GetProduct();
            dgvProduct.DataSource = dbProduct;
        }
        #endregion
        #region Phương thức này có chức năng binding dữ liệu từ view lên property Product
        private void binding()
        {
            try // ở đây có 1 try catch chưa xử lý !!!
            {
                txtMaSP.DataBindings.Clear();
                txtMaSP.DataBindings.Add("Text", dgvProduct.DataSource, "MASANPHAM");
                txtTenSP.DataBindings.Clear();
                txtTenSP.DataBindings.Add("Text", dgvProduct.DataSource, "TENSANPHAM");
                txtGiaBan.DataBindings.Clear();
                txtGiaBan.DataBindings.Add("Text", dgvProduct.DataSource, "GIABAN");
                txtSL.DataBindings.Clear();
                txtSL.DataBindings.Add("Text", dgvProduct.DataSource, "SOLUONGTON");
                cbbNhomSP.DataBindings.Add("Text", dgvProduct.DataSource, "MANHOMSP");
                cbbNuocSX.DataBindings.Add("Text", dgvProduct.DataSource, "NUOCSX");
                dtpNgaySX.DataBindings.Add("Text", dgvProduct.DataSource, "NGAYSX");
                dtpHanSD.DataBindings.Add("Text", dgvProduct.DataSource, "HANSD");
            }
            catch (Exception ex)
            {
            }
        }
        #endregion
        #region Chức năng bật tắt property Product
        /*
         * Phương thức này có chức năng bật tắt các thuộc tính của khách hàng
         */
        private void dis_en(bool e)
        {
            txtMaSP.Enabled = e;
            txtTenSP.Enabled = e;
            txtGiaBan.Enabled = e;
            txtSL.Enabled = e;
            cbbNhomSP.Enabled = e;
            cbbNuocSX.Enabled = e;
            dtpNgaySX.Enabled = e;
            dtpHanSD.Enabled = e;
            btnThem.Enabled = !e;
            btnXoa.Enabled = !e;
            btnSua.Enabled = !e;
            btnLuu.Enabled = e;
            btnHuy.Enabled = e;
        }
        #endregion
        #region Sự kiện load form
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            load();
            binding();
            dis_en(false);
        }
        #endregion
        #region Phương thức này có chức năng lấy dữ liệu từ các text box vào ProductDTO
        private ProductDTO getData()
        {
            ProductDTO product = new ProductDTO();
            product.MaSP = txtMaSP.Text;
            product.TenSP = txtTenSP.Text;
            product.GiaBan = Int32.Parse(txtGiaBan.Text.Trim());
            product.SlTon = Int32.Parse(txtSL.Text.Trim());
            product.ManhomSP = cbbNhomSP.Text;
            product.NuocSX = cbbNuocSX.Text;
            product.NgaySX = dtpNgaySX.Text;
            product.HanSD = dtpHanSD.Text;
            return product;
        }
        #endregion
        #region Sự kiện Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            flag = 0;
            dis_en(true);
        }
        #endregion
        #region Sự kiện Sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            flag = 1;
            dis_en(true);
        }
        #endregion
        #region Sự kiện Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận hủy",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                product = getData();
                if (productBUS.DeleteProduct(ref err, product))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmSanPham_Load(sender, e);
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
                    product = getData();
                    if (productBUS.InsertProduct(ref err, product))
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
                    product = getData();
                    if (productBUS.UpdateProduct(ref err, product))
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
        #region Sự kiện Hiển thị
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            frmSanPham_Load(sender, e);
            dis_en(false);
        }
        #endregion
        #region sự kiện Hủy
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
