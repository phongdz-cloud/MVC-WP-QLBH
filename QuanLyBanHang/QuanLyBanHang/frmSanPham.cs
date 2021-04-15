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
        ProductBUS productBUS = new ProductBUS();
        ProductGroupBUS productGroupBUS = new ProductGroupBUS();
        ProductDTO product = new ProductDTO();
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
    }
}
