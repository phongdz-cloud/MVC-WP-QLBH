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
    public partial class frmSanPhamGuna : Form
    {
        private ProductGroupBUS productGroupBUS = new ProductGroupBUS();
        private SupllierBUS supllierBUS = new SupllierBUS();
        private ProductBUS productBUS = new ProductBUS();
        private static frmSanPhamGuna instance;
        private ProductDTO product;
        private int flag;
        private string err;
        private DataTable dbProductType;
        private DataTable dbProduct;
        public static frmSanPhamGuna Instance { get { if (instance == null) instance = new frmSanPhamGuna(); return frmSanPhamGuna.instance; } private set => instance = value; }

        public DataTable DbProductType { get => dbProductType; set => dbProductType = value; }
        public DataTable DbProduct { get => dbProduct; set => dbProduct = value; }
        public int Flag { get => flag; set => flag = value; }
        public ProductDTO Product { get => product; set => product = value; }

        public frmSanPhamGuna()
        {
            InitializeComponent();
            load();
        }
        /// <summary>
        /// Form load sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void load()
        {

            DbProductType = productGroupBUS.GetProductGroup();
            MANHOMSP.DataSource = DbProductType ;
            MANHOMSP.DisplayMember = "TENNHOMSP";
            MANHOMSP.ValueMember = "MANHOMSP";
            DbProduct = productBUS.GetProduct();
            dgvProduct.DataSource = DbProduct;
            dgvSupplier.DataSource = supllierBUS.GetSupllier();
            lbSoLuong.Text = (dgvProduct.Rows.Count).ToString();
        }
        private void frmSanPhamGuna_Load(object sender, EventArgs e)
        {
            load();
        }
        private void cbbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbSort.SelectedItem.ToString() == "Ascending Numbers")
               dgvProduct.Sort(dgvProduct.Columns["SOLUONGTON"], ListSortDirection.Ascending);
            else if (cbbSort.SelectedItem.ToString() == "Decending Numbers")
                dgvProduct.Sort(dgvProduct.Columns["SOLUONGTON"], ListSortDirection.Descending);
            else if (cbbSort.SelectedItem.ToString() == "Ascending Price")
                dgvProduct.Sort(dgvProduct.Columns["GIABAN"], ListSortDirection.Ascending);
            else if (cbbSort.SelectedItem.ToString() == "Decending Price")
                dgvProduct.Sort(dgvProduct.Columns["GIABAN"], ListSortDirection.Descending);
            else dgvProduct.Sort(dgvProduct.Columns["TENSANPHAM"], ListSortDirection.Ascending);
        }
        private ProductDTO getData(int RowIndex)
        {
            ProductDTO product = new ProductDTO();
            product.MaSP = dgvProduct.Rows[RowIndex].Cells["MASANPHAM"].Value.ToString();
            product.TenSP = dgvProduct.Rows[RowIndex].Cells["TENSANPHAM"].Value.ToString();
            product.GiaBan = Convert.ToInt32(dgvProduct.Rows[RowIndex].Cells["GIABAN"].Value.ToString());
            product.SlTon = Convert.ToInt32(dgvProduct.Rows[RowIndex].Cells["SOLUONGTON"].Value.ToString());
            product.ManhomSP = dgvProduct.Rows[RowIndex].Cells["MANHOMSP"].Value.ToString();
            product.NuocSX = dgvProduct.Rows[RowIndex].Cells["NUOCSX"].Value.ToString();
            return product;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận hủy",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Product = getData(dgvProduct.CurrentCell.RowIndex);
                if (productBUS.DeleteProduct(ref err, Product))
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            Flag = 0;
            product = getData(dgvProduct.CurrentRow.Index);
            frmInsertProduct frmInsertProduct = new frmInsertProduct();
            frmInsertProduct.ShowDialog();
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            if(Flag != -1)
            {
                frmSanPhamGuna_Load(sender, e);
                Flag = -1;
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận hủy",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            Flag = -1;
            frmInsertProduct frmInsertProduct = new frmInsertProduct();
            frmInsertProduct.ShowDialog();
        }

        private void guna2GroupBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
