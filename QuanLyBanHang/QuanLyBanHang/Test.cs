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
using System.Data.SqlClient;
using Guna.UI2;
namespace QuanLyBanHang
{
    public partial class Test : Form
    {
        String filename;
        Image DefaultImage;
        Byte[] ImageByteArray;
        PictureBox pic;
        static int i = 0;
        string err;
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.HorizontalScroll.Enabled = true;
            flowLayoutPanel1.HorizontalScroll.Visible = true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp;";
            
            if (open.ShowDialog() == DialogResult.OK)
            {
                filename = open.FileName;
                pictureBox1.Image = new Bitmap(filename);
                label2.Text = System.IO.Path.GetFileName(filename);
            }
            Image temp = new Bitmap(filename);
            MemoryStream strm = new MemoryStream();
            temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
            ImageByteArray = strm.ToArray();
            pic = new PictureBox();
            pic.Width = 200;
            pic.Height = 200;
            pic.Image = Image.FromStream(new MemoryStream(ImageByteArray));
            pic.SizeMode = PictureBoxSizeMode.StretchImage;
            flowLayoutPanel1.Controls.Add(pic);
        }
        private void loadImage(DataGridView dgv, FlowLayoutPanel flowlayout)
        {
            for(int i =0; i<=dgv.Rows.Count-2;i++)
            {
                string s = dgv.Rows[i].Cells[3].Value.ToString();
                byte[] ImageArray = (byte[])dgv.Rows[i].Cells[3].Value;
                //MemoryStream strm = new MemoryStream();
                //  temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                ImageByteArray = ImageArray;
                pic = new PictureBox();
                pic.Width = 200;
                pic.Height = 200;
                pic.Image = Image.FromStream(new MemoryStream(ImageByteArray));
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                flowlayout.Controls.Add(pic);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ImageByteArray = new byte[] { };
                Image temp = new Bitmap(filename);
                MemoryStream strm = new MemoryStream();
                temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                ImageByteArray = strm.ToArray();
                DBProvider.Instance.MyExcuteNonQuery("InsertListImageNhomSP",
                                                     CommandType.StoredProcedure, ref err,
                                                     new SqlParameter("@MANHOMSP",txtMaNhomSP.Text.Trim()),
                                                     new SqlParameter("@TENNHOMSP", txtTenNhomSp.Text.Trim()),
                                                     new SqlParameter("@FILENAME", label2.Text),
                                                     new SqlParameter("@Data", ImageByteArray));
                MessageBox.Show("Save success!");
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                DBProvider.Instance.Conn.Open();
                dgvList.DataSource = DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM dbo.SANPHAM", CommandType.Text, null);
              //  loadImage(dgvList, flowLayoutPanel1);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBProvider.Instance.Conn.Close();
            }
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNhomSP.Text = dgvList.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenNhomSp.Text = dgvList.Rows[e.RowIndex].Cells[4].Value.ToString();
        }
    }
}
