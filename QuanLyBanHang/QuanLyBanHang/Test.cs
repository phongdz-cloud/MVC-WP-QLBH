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
using DTO;
namespace QuanLyBanHang
{
    public partial class Test : Form
    {
        private EmployeeDTO emloyee;
        String filename;
        Byte[] ImageByteArray;
        PictureBox pic;
        string err;
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {


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
            txtImage.Text = ImageByteArray.ToString();
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
        private EmployeeDTO getData(int RowIndex)
        {
            EmployeeDTO employee = new EmployeeDTO();
            employee.MaNV = dgvEmployee.Rows[RowIndex].Cells[0].Value.ToString();
            employee.HoTen = dgvEmployee.Rows[RowIndex].Cells[1].Value.ToString();
            employee.GioiTinh = dgvEmployee.Rows[RowIndex].Cells[2].Value.ToString();
            employee.NgaySinh = dgvEmployee.Rows[RowIndex].Cells[3].Value.ToString();
            employee.DiaChi = dgvEmployee.Rows[RowIndex].Cells[4].Value.ToString();
            employee.DienThoai = dgvEmployee.Rows[RowIndex].Cells[5].Value.ToString();
            employee.NgayVaoLam = dgvEmployee.Rows[RowIndex].Cells[6].Value.ToString();
            employee.Salary = Convert.ToInt32(dgvEmployee.Rows[RowIndex].Cells[7].Value.ToString());
           // employee.Images = (byte[])dgvEmployee.Rows[RowIndex].Cells[8].Value;
            return employee;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                emloyee = getData(dgvEmployee.CurrentCell.RowIndex);
                ImageByteArray = new byte[] { };
                Image temp = new Bitmap(filename);
                MemoryStream strm = new MemoryStream();
                temp.Save(strm, System.Drawing.Imaging.ImageFormat.Jpeg);
                ImageByteArray = strm.ToArray();
                DBProvider.Instance.MyExcuteNonQuery("spUpdateNhanVien", CommandType.StoredProcedure, ref err,
                new SqlParameter("@MANV",emloyee.MaNV),
                 new SqlParameter("@HOTEN", emloyee.HoTen),
                 new SqlParameter("@GIOITINH", emloyee.GioiTinh),
                 new SqlParameter("@NGAYSINH", emloyee.NgaySinh),
                 new SqlParameter("@DIACHI", emloyee.DiaChi),
                 new SqlParameter("@DIENTHOAI", emloyee.DienThoai),
                 new SqlParameter("@NGAYVAOLAM", emloyee.NgayVaoLam),
                 new SqlParameter("@SALARY", emloyee.Salary),
                 new SqlParameter("@IMAGES", ImageByteArray));
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
                dgvEmployee.DataSource = DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM dbo.NHANVIEN", CommandType.Text, null);
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
        }
    }
}
