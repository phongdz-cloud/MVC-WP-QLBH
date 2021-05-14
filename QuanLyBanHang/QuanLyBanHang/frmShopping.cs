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
using DAO;
using DTO;
using Guna.UI2.WinForms;
using Function;
namespace QuanLyBanHang
{
    public partial class frmShopping : Form
    {
        private ReceiptDAO receiptDAO = new ReceiptDAO();
        private DetailReceiptDAO detailReceiptDAO = new DetailReceiptDAO();
        private DataTable dblistImageGroupProduct;
        private DataTable dblistImageProduct;
        private DataTable dbProduct = new DataTable();
        private Byte[] ImageByteArray;
        private PictureBox pic;
        private Label description;
        private Label price;
        private Guna2GradientButton status;
        private Guna2GradientButton flagstatus;
        private int step;
        private string err;
        private string idNSP;
        List<List<PictureBox>> matrixListSP = new List<List<PictureBox>>();
        List<PictureBox> row;
        List<double> listPriceMax = new List<double>();
        Dictionary<string, UserControl1> newOrder = new Dictionary<string, UserControl1>();
        public frmShopping()
        {
            InitializeComponent();
        }


        UserControl1 orderProduct(string nameProduct, string price, int amount,string idSP)
        {
            UserControl1 ctl1 = new UserControl1(amount);
            ctl1.Controls["lbSP"].Text = nameProduct;
            ctl1.Controls["lbPrice"].Text = price + "đ";
            ctl1.Controls["lbPrice"].Tag = idSP; // luu idSP
            ctl1.Controls["btnRemove"].Click += eventButtonClick;
            ctl1.Controls["btnRemove"].Tag = nameProduct;

            Guna2NumericUpDown numeric = (Guna2NumericUpDown)ctl1.Controls["numericSL"];
            numeric.ValueChanged += eventValueChangedNumberic;
            newOrder.Add(nameProduct, ctl1);
            return ctl1;
        }
        private void eventValueChangedNumberic(object sender, EventArgs e)
        {
            Guna2NumericUpDown numeric;
            if (floPanel.Controls.Count > 0)
            {
                double sum;
                double total = 0;
                foreach (UserControl item in floPanel.Controls)
                {
                    numeric = (Guna2NumericUpDown)item.Controls["numericSL"];
                    sum = Convert.ToInt32(numeric.Value) * Convert.ToDouble(item.Controls["lbPrice"].Text.Substring(0, item.Controls["lbPrice"].Text.Length - 1));
                    total += sum;
                }
                lbTotal.Text = total.ToString() + "đ";
                lbSubTotal.Text = Func.NumbertoWord(total);
            }
            else
            {
                lbTotal.Text = "";
                lbSubTotal.Text = "";
            }
        }
        // Procedure  -> số dòng bị ảnh hưởng - > Message trigger
        // Fuction
        private void eventButtonClick(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm khỏi giỏ hàng không ?", "Xác nhận hủy",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Guna2Button button = (Guna2Button)sender;
                foreach (UserControl item in floPanel.Controls)
                {
                    if (item.Controls["btnRemove"].Tag.ToString() == button.Tag.ToString())
                    {
                        floPanel.Controls.Remove(item);
                        newOrder.Remove(item.Controls["btnRemove"].Tag.ToString());
                        eventValueChangedNumberic(sender, e);
                        break;
                    }
                }
            }
        }
        #region method
        void load()
        {
            cbbID.DataSource = frmCustomer.Instance.DbAll;
            cbbID.DisplayMember = "TENKH";
            cbbID.ValueMember = "MAKH";
            cbbType.DataSource = frmCustomer.Instance.DbCustomerALL;
            cbbType.DisplayMember = "TENLOAI";
            cbbType.ValueMember = "MALOAIKH";
            cbbIDEmployee.DataSource = frmEmployeeGuna.Instance.DbAll;
            cbbIDEmployee.DisplayMember = "HOTEN";
            cbbIDEmployee.ValueMember = "MANV";
             if (dblistImageGroupProduct == null) loadListNhomSP();
             if (dblistImageProduct == null) loadListSP();
            searchPriceMax();

        }
        private string[] searchProduct(string maSP)
        {
            string[] s = new string[2];
            dbProduct = DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM SANPHAM", CommandType.Text, null);
            for (int i = 0; i <= dbProduct.Rows.Count - 1; i++)
            {
                if (maSP == dbProduct.Rows[i][0].ToString())
                {
                    s[0] = dbProduct.Rows[i][1].ToString();
                    s[1] = dbProduct.Rows[i][2].ToString();
                }
            }
            return s;
        }
        void loadListSPBestSeller()
        {
            DataTable dbBestSeller = DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM Best_Seller('" + idNSP + "')", CommandType.Text, null);
            string[] s;
            for (int i = 0; i <= dbBestSeller.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dblistImageProduct.Rows.Count - 1; j++)
                {
                    if (dblistImageProduct.Rows[j][0].ToString() == dbBestSeller.Rows[i][0].ToString())
                    {
                        s = searchProduct(dblistImageProduct.Rows[j][0].ToString());
                        byte[] ImageArray = (byte[])dblistImageProduct.Rows[j][3];
                        ImageByteArray = ImageArray;
                        pic = new PictureBox();
                        pic.Width = 150;
                        pic.Height = 150;

                        description = new Label();
                        description.Width = 150;
                        description.Text = s[0];
                        description.BackColor = Color.FromArgb(37, 131, 227);
                        description.TextAlign = ContentAlignment.MiddleCenter;

                        pic.Image = Image.FromStream(new MemoryStream(ImageByteArray));
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic.Controls.Add(description);

                        flowBestSeller.Controls.Add(pic);
                    }
                }
            }
        }
        void loadListSP()
        {

            dblistImageProduct = DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM dbo.ListImageSP", CommandType.Text, null);
            string[] s;
            for (int i = 0; i <= dblistImageGroupProduct.Rows.Count - 1; i++)
            {
                row = new List<PictureBox>();
                for (int j = 0; j <= dblistImageProduct.Rows.Count - 1; j++)
                {
                    if (dblistImageGroupProduct.Rows[i][0].ToString() == dblistImageProduct.Rows[j][1].ToString())
                    {
                        s = searchProduct(dblistImageProduct.Rows[j][0].ToString());
                        byte[] ImageArray = (byte[])dblistImageProduct.Rows[j][3];
                        ImageByteArray = ImageArray;
                        pic = new PictureBox();
                        pic.Width = 150;
                        pic.Height = 154;

                        price = new Label();
                        price.Width = 150;
                        price.Text = s[1];
                        price.Name = "price";
                        price.BackColor = Color.FromArgb(255, 121, 121);
                        price.TextAlign = ContentAlignment.MiddleCenter;
                        price.Dock = DockStyle.Bottom;


                        description = new Label();
                        description.Width = 150;
                        description.Text = s[0];
                        description.BackColor = Color.FromArgb(37, 131, 227);
                        description.TextAlign = ContentAlignment.MiddleCenter;

                        status = new Guna2GradientButton();
                        status.Name = "status";
                        status.FillColor = Color.FromArgb(249, 130, 68);
                        status.Width = 50;
                        status.Height = 50;
                        status.TextAlign = HorizontalAlignment.Center;
                        status.Location = new Point(100, 80);
                        status.Tag = dblistImageProduct.Rows[j][0].ToString(); // lấy ra mã sản phẩm
                        status.Visible = false;
                        status.Image = Image.FromFile(@"C:\Users\dell\Desktop\Image\checkmark_50pxwhite.png");
                        status.ImageAlign = HorizontalAlignment.Center;

                        pic.Image = Image.FromStream(new MemoryStream(ImageByteArray));
                        pic.SizeMode = PictureBoxSizeMode.StretchImage;
                        pic.Click += pictureSanPham_click;
                        pic.Tag = j;
                        pic.Controls.Add(price);
                        pic.Controls.Add(description);
                        pic.Controls.Add(status);
                        row.Add(pic);
                    }
                }
                matrixListSP.Add(row);
            }
        }
        void loadListNhomSP()
        {
            dblistImageGroupProduct = DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM dbo.ListImageNhomSP", CommandType.Text);
            for (int i = 0; i <= dblistImageGroupProduct.Rows.Count - 1; i++)
            {
                byte[] ImageArray = (byte[])dblistImageGroupProduct.Rows[i][3];
                ImageByteArray = ImageArray;
                pic = new PictureBox();
                pic.Width = 150;
                pic.Height = 154;
                pic.BorderStyle = BorderStyle.None;
                description = new Label();
                description.Width = 150;
                description.Text = dblistImageGroupProduct.Rows[i][1].ToString();
                description.BackColor = Color.FromArgb(37, 131, 227);
                description.TextAlign = ContentAlignment.MiddleCenter;

                status = new Guna2GradientButton();
                status.FillColor = Color.FromArgb(249, 130, 68);
                status.Width = 50;
                status.Height = 50;
                status.Name = "status";
                status.Tag = dblistImageGroupProduct.Rows[i][0].ToString();
                status.TextAlign = HorizontalAlignment.Center;
                status.Location = new Point(100, 80);
                status.Visible = false;
                status.Image = Image.FromFile(@"C:\Users\dell\Desktop\Image\checkmark_50pxwhite.png");
                status.ImageAlign = HorizontalAlignment.Center;

                pic.Image = Image.FromStream(new MemoryStream(ImageByteArray));
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Click += pictureNhom_click; // publicsher 
                pic.Tag = i;
                pic.Controls.Add(description);
                pic.Controls.Add(status);
                flpProductGroup.Controls.Add(pic);
            }
        }
        void pictureSanPham_click(object sender, EventArgs e) // bắt sự kiện cho nhóm
        {
            PictureBox clikedPicture = (PictureBox)sender;
            for (int i = 0; i <= clikedPicture.Controls.Count; i++)
            {
                if (clikedPicture.Controls[i].GetType() == typeof(Guna2GradientButton) && clikedPicture.Controls[i].Visible == false)
                {
                    if (newOrder.ContainsKey(frmSanPhamGuna.Instance.DbProduct.Rows[Convert.ToInt32(clikedPicture.Tag)][1].ToString())) break;
                    clikedPicture.Controls[i].Visible = true;
                    int index = Convert.ToInt32(clikedPicture.Tag);
                    floPanel.Controls.Add(orderProduct(frmSanPhamGuna.Instance.DbProduct.Rows[Convert.ToInt32(clikedPicture.Tag)][1].ToString()
                        , frmSanPhamGuna.Instance.DbProduct.Rows[Convert.ToInt32(clikedPicture.Tag)][2].ToString()
                        , Convert.ToInt32(frmSanPhamGuna.Instance.DbProduct.Rows[Convert.ToInt32(clikedPicture.Tag)][3])
                        ,clikedPicture.Controls["status"].Tag.ToString()));
                    break;
                }
                if (clikedPicture.Controls[i].GetType() == typeof(Guna2GradientButton) && clikedPicture.Controls[i].Visible == true)
                {
                    clikedPicture.Controls[i].Visible = false;
                    break;
                }
            }
            if (clikedPicture.BorderStyle == BorderStyle.None)
            {
                clikedPicture.BorderStyle = BorderStyle.Fixed3D;
                clikedPicture.Paint += pictureBox1_Paint_1;
                clikedPicture.Refresh();
            }
            else
            {
                clikedPicture.BorderStyle = BorderStyle.None;
            }

        }
        private void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            ControlPaint.DrawBorder(e.Graphics, pic.ClientRectangle, Color.FromArgb(249, 130, 68), ButtonBorderStyle.Solid);
        }
        void pictureNhom_click(object sender, EventArgs e) // handeler 
        {
            flowBestSeller.Controls.Clear();
            flowLayoutList.Controls.Clear();
            PictureBox clikedPicture = (PictureBox)sender;
            idNSP = clikedPicture.Controls["status"].Tag.ToString();
            if (flagstatus != null) flagstatus.Visible = false;
            for (int i = 0; i <= clikedPicture.Controls.Count; i++)
            {
                if (clikedPicture.Controls[i].GetType() == typeof(Guna2GradientButton) && clikedPicture.Controls[i].Visible == false)
                {
                    clikedPicture.Controls[i].Visible = true;
                    flagstatus = (Guna2GradientButton)clikedPicture.Controls[i];
                    break;
                }
            }
            loadListSPBestSeller(); // load best seller
            step = Convert.ToInt32(clikedPicture.Tag.ToString());
            for (int i = 0; i < matrixListSP[step].Count; i++)
            {
                flowLayoutList.Controls.Add(matrixListSP[step][i]);
            }
         
            tBPrice.Value = 0;
            tBPrice.Maximum = Convert.ToInt32(listPriceMax[step]);
        }
        void searchPriceMax()
        {
            double max;
            PictureBox pic;
            foreach (var row in matrixListSP)
            {
                max = 0;
                foreach (var column in row)
                {
                    pic = (PictureBox)column;
                    if (Convert.ToDouble(pic.Controls["price"].Text) > max) max = Convert.ToDouble(pic.Controls["price"].Text);
                }
                max /= 1000;
                listPriceMax.Add(max);
            }
        }
        #endregion
        #region event

        #endregion

        private void frmShopping_Load(object sender, EventArgs e)
        {
            load();
            if (dblistImageGroupProduct == null)
            {
                loadListNhomSP();
            }
        }
        #region ??
        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion
        private void cbbID_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSex.Text = frmCustomer.Instance.DbAll.Rows[cbbID.SelectedIndex][2].ToString();
            txtDiaChi.Text = frmCustomer.Instance.DbAll.Rows[cbbID.SelectedIndex][3].ToString();
            txtPhone.Text = frmCustomer.Instance.DbAll.Rows[cbbID.SelectedIndex][4].ToString();
            cbbType.SelectedValue = frmCustomer.Instance.DbAll.Rows[cbbID.SelectedIndex][5];
        }

        private void cbbIDEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSexEmployee.Text = frmEmployeeGuna.Instance.DbAll.Rows[cbbIDEmployee.SelectedIndex][2].ToString();
            txtDiaChiEmployee.Text = frmEmployeeGuna.Instance.DbAll.Rows[cbbIDEmployee.SelectedIndex][4].ToString();
            txtPhoneEmloyee.Text = frmEmployeeGuna.Instance.DbAll.Rows[cbbIDEmployee.SelectedIndex][5].ToString();
        }

        private void guna2GradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            frmCustomer.Instance.ShowDialog();
        }

        private void tBPrice_ValueChanged(object sender, EventArgs e)
        {
            if (tBPrice.Value == 0) lbValue.Text = "0";
            else
            {
                lbValue.Text = tBPrice.Value.ToString() + "000";
                double max = Convert.ToDouble(lbValue.Text);
                for (int i = 0; i < matrixListSP[step].Count; i++)
                {
                    if (Convert.ToDouble(matrixListSP[step][i].Controls["price"].Text) < max)
                    {
                        matrixListSP[step][i].Hide();
                    }
                    else matrixListSP[step][i].Show();
                }
            }
        }
        private ReceiptDTO getReceipt(string idHD)
        {
            ReceiptDTO receipt = new ReceiptDTO();
            receipt.IdHD = idHD;
            receipt.IdEmployee = cbbIDEmployee.SelectedValue.ToString();
            receipt.IdCustomer = cbbID.SelectedValue.ToString();
            receipt.Total = Convert.ToDouble(lbTotal.Text.Substring(0,lbTotal.Text.Length - 1));
            return receipt;
        }
        private DetailReceiptDTO getDetailReceipt(string idHD,string idProduct,int amount)
        {
            DetailReceiptDTO detailReceipt = new DetailReceiptDTO();
            detailReceipt.IdReceipt = idHD;
            detailReceipt.IdProduct = idProduct;
            detailReceipt.Amount = amount;
            return detailReceipt;
        }
        private void btnPay_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn thanh toán giỏ hàng này không?", "Xác nhận hủy",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                try
                {
                    string idHD = Func.taoID(7, ref err);
                    if(receiptDAO.insertReceipt(ref err,getReceipt(idHD)))
                    {
                        foreach (var item in floPanel.Controls)
                        {
                            UserControl1 ctl = (UserControl1)item;
                            Guna2NumericUpDown num = (Guna2NumericUpDown)ctl.Controls["numericSL"];
                            if (!detailReceiptDAO.insertDetailReceipt(ref err, getDetailReceipt(idHD, ctl.Controls["lbPrice"].Tag.ToString(), Convert.ToInt32(num.Value))))
                            {
                                MessageBox.Show("Thanh toán thất bại", "Xác nhận",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                                break;
                            }
                        }
                        MessageBox.Show("Chúc mừng bạn đã thanh toán thành công", "Xác nhận",
                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                        floPanel.Controls.Clear();
                        Func.updateAutoID();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
