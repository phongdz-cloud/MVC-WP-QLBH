using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Function;
using DAO;
using DTO;
using System.Data.SqlClient;
namespace QuanLyBanHang
{
    public partial class frmInsertProduct : Form
    {
        private ProductDAO productDAO = new ProductDAO();
        ProductDTO product;
        private Byte[] ImageByteArray;
        private string err;
        public frmInsertProduct()
        {
            InitializeComponent();
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

        private void frmInsertProduct_Load(object sender, EventArgs e)
        {
            cbbGroupProduct.DataSource = frmSanPhamGuna.Instance.DbProductType;
            cbbGroupProduct.DisplayMember = "TENNHOMSP";
            cbbGroupProduct.ValueMember = "MANHOMSP";

            if (frmSanPhamGuna.Instance.Flag == -1)
            {
                btnUpdate.Enabled = false;
                if (txtID.Text == "") txtID.Text = Func.taoID(1, ref err);
            }
            if (frmSanPhamGuna.Instance.Flag == 0)
            {
                btnInsert.Enabled = false;
                btnUpdate.Enabled = true;
                if (product == null && frmSanPhamGuna.Instance.Product != null)
                {
                    product = frmSanPhamGuna.Instance.Product;
                    load();
                }
            }
        }
        private void load()
        {
            txtID.Text = product.MaSP;
            txtNameProduct.Text = product.TenSP;
            cbbNuocSX.Text = product.NuocSX;
            cbbGroupProduct.SelectedValue = product.ManhomSP;
            DataTable db = DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM dbo.ListImageSP", CommandType.Text, null);
            for(int i =0; i<=db.Rows.Count -1; i++)
            {
                if(product.MaSP == db.Rows[i][0].ToString())
                {
                    ImageByteArray = (byte [])db.Rows[i][3];
                    pbAvatar.Image = Image.FromStream(new MemoryStream(ImageByteArray));
                    txtFileName.Text = db.Rows[i][2].ToString();
                    break;
                }
            }
        }
        private ProductDTO getDATA()
        {
            ProductDTO product = new ProductDTO();
            product.MaSP = txtID.Text;
            product.TenSP = txtNameProduct.Text;
            product.NuocSX = cbbNuocSX.Text;
            product.ManhomSP = cbbGroupProduct.SelectedValue.ToString();
            product.GiaBan = Convert.ToInt32(txtPrice.Text);
            product.SlTon = 0;
            return product;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn thêm sản phẩm này không?", "Xác nhận hủy",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                     product = getDATA();
                    if (productDAO.insertProduct(ref err, product))
                    {
                        if(DBProvider.Instance.MyExcuteNonQuery("InsertListImageSP", CommandType.StoredProcedure, ref err,
                        new SqlParameter("@MASANPHAM", product.MaSP),
                        new SqlParameter("@MANHOMSP", product.ManhomSP),
                        new SqlParameter("@FILENAME", txtFileName.Text),
                        new SqlParameter("@Data", ImageByteArray)))
                        {
                            MessageBox.Show("Thêm sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Func.updateAutoID();
                        }
                    }
                }
            }catch(Exception ex)
            {
                err = ex.Message;
                MessageBox.Show(err);
            }
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            txtID.ResetText();
            txtNameProduct.ResetText();
            cbbGroupProduct.SelectedIndex = 0;
            cbbNuocSX.SelectedIndex = 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có muốn cập nhật sản phẩm này không?", "Xác nhận hủy",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    ProductDTO product = getDATA();
                    if (productDAO.updateProduct(ref err, product) &&
                        DBProvider.Instance.MyExcuteNonQuery("updateListImageSP", CommandType.StoredProcedure, ref err,
                        new SqlParameter("@MASANPHAM", product.MaSP),
                        new SqlParameter("@MANHOMSP", product.ManhomSP),
                        new SqlParameter("@FILENAME", txtFileName.Text),
                        new SqlParameter("@Data", ImageByteArray)))
                    {
                        
                        {
                            MessageBox.Show("cập nhật sản phẩm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Func.updateAutoID();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                err = ex.Message;
                MessageBox.Show(err);
            }
        }
    }
}

