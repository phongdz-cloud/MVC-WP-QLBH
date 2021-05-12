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
using Guna.UI2.WinForms;
namespace QuanLyBanHang
{
    public partial class frmShopping : Form
    {
        private DataTable dblistImageGroupProduct;
        private DataTable dblistImageProduct;
        private DataTable dbProduct = new DataTable();
        private Byte[] ImageByteArray;
        private PictureBox pic;
        private Label description;
        private Label price;
        private Guna2GradientButton status;
        private Guna2GradientButton flagstatus;
        List<List<PictureBox>> matrixListSP = new List<List<PictureBox>>();
        List<PictureBox> row;
        public frmShopping()
        {
            InitializeComponent();
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
            if(dblistImageGroupProduct == null) loadListNhomSP();
            if(dblistImageProduct == null) loadListSP();
        }
        private string[] searchProduct(string maSP)
        {
            string[] s = new string[2];
            dbProduct = DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM SANPHAM", CommandType.Text, null);
            for(int i =0; i<= dbProduct.Rows.Count -1;i++)
            {
                if(maSP == dbProduct.Rows[i][0].ToString())
                {
                    s[0] = dbProduct.Rows[i][1].ToString(); 
                    s[1] = dbProduct.Rows[i][2].ToString();
                }
            }
            return s;
        }
        void loadListSP()
        {
            
            dblistImageProduct = DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM dbo.ListImageSP", CommandType.Text, null);
            string[] s;
            for(int i =0; i<= dblistImageGroupProduct.Rows.Count-1;i++ )
            {
                row = new List<PictureBox>();
                for(int j =0; j<= dblistImageProduct.Rows.Count-1;j++)
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
                        price.BackColor = Color.FromArgb(255, 121, 121);
                        price.TextAlign = ContentAlignment.MiddleCenter;
                        price.Dock = DockStyle.Bottom;
                        

                        description = new Label();
                        description.Width = 150;
                        description.Text = s[0];
                        description.BackColor = Color.FromArgb(37, 131, 227);
                        description.TextAlign = ContentAlignment.MiddleCenter;

                        status = new Guna2GradientButton();
                        status.FillColor = Color.FromArgb(249, 130, 68);
                        status.Width = 50;
                        status.Height = 50;
                        status.TextAlign = HorizontalAlignment.Center;
                        status.Location = new Point(100, 80);
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
            for (int i =0;i <= clikedPicture.Controls.Count;i++)
            {
                if(clikedPicture.Controls[i].GetType() == typeof(Guna2GradientButton) && clikedPicture.Controls[i].Visible == false)
                {
                    clikedPicture.Controls[i].Visible = true;
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
        private void pictureBox1_Paint_1(object sender , PaintEventArgs e)
        {
            PictureBox pic = (PictureBox)sender;
            ControlPaint.DrawBorder(e.Graphics, pic.ClientRectangle, Color.FromArgb(249, 130, 68), ButtonBorderStyle.Solid);
        }
        void pictureNhom_click(object sender, EventArgs e) // handeler 
        {
            flowLayoutList.Controls.Clear();
            PictureBox clikedPicture = (PictureBox)sender;
            if (flagstatus != null) flagstatus.Visible = false;
            for (int i = 0; i <= clikedPicture.Controls.Count; i++)
            {
                if (clikedPicture.Controls[i].GetType() == typeof(Guna2GradientButton) && clikedPicture.Controls[i].Visible == false)
                {
                    clikedPicture.Controls[i].Visible = true;
                    flagstatus =(Guna2GradientButton) clikedPicture.Controls[i];
                    break;
                }
            }
            int step = Convert.ToInt32(clikedPicture.Tag.ToString());
            for (int i =0;i<matrixListSP[step].Count;i++)
            {
                flowLayoutList.Controls.Add(matrixListSP[step][i]);   
            }
        }
    #endregion
    #region event

    #endregion

    private void frmShopping_Load(object sender, EventArgs e)
        {
            load();
            if(dblistImageGroupProduct == null)
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
    }
}
