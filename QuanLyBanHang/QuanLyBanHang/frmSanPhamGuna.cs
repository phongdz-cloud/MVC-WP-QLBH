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
        ProductGroupBUS productGroupBUS = new ProductGroupBUS();
        ProductBUS productBUS = new ProductBUS();
        private int flag = -1;
        private string err;
        public frmSanPhamGuna()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Form load sản phẩm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void load()
        {
            DataTable dbProductType = productGroupBUS.GetProductGroup();
            MANHOMSP.DataSource = dbProductType;
            MANHOMSP.DisplayMember = "TENNHOMSP";
            MANHOMSP.ValueMember = "MANHOMSP";
            DataTable dbProduct = productBUS.GetProduct();
            dgvProduct.DataSource = dbProduct;
            lbSoLuong.Text = (dgvProduct.Rows.Count -2).ToString();
        }
        private void frmSanPhamGuna_Load(object sender, EventArgs e)
        {
            load();
            dis_en(false);
        }
        /// <summary>
        /// Sự kiện này có chức năng sắp xếp các sản phẩm theo người dùng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        private void dis_en(bool e)
        {
            btnSave.Enabled = e;
            btnCancel.Enabled = e;
            btnDelete.Enabled = !e;
            btnEdit.Enabled = !e;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            flag = 1;
            dis_en(true);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            flag = 0;
            dis_en(true);
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            if(flag != -1)
            {
                frmSanPhamGuna_Load(sender, e);
                flag = -1;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvProduct.Rows[dgvProduct.CurrentCell.RowIndex].Cells[0].Value.ToString() != "")
            {
                if (flag == 1)
                {
                    DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận hủy",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    ProductDTO product = getData(dgvProduct.CurrentCell.RowIndex);
                    if (dr == DialogResult.Yes)
                    {
                        if (productBUS.DeleteProduct(ref err, product))
                            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (flag == 0)
                {
                    DialogResult dr = MessageBox.Show("Bạn có chắc muốn sửa không?", "Xác nhận hủy",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        ProductDTO product = getData(dgvProduct.CurrentCell.RowIndex);
                        if (productBUS.UpdateProduct(ref err, product))
                            MessageBox.Show("Cập nhật thành công", "Thông báo", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        else MessageBox.Show(err, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                dis_en(false);
            }
            else
            {
                MessageBox.Show("Không tồn tại chỉ mục?", "Xác nhận hủy",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận hủy",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                flag = -1;
                dis_en(false);
            }
            
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
