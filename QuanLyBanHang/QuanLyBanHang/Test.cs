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
using Function;
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
            try
            {
                bool s = DBProvider.Instance.MyExcuteNonQuery("spUpdateUserID", CommandType.StoredProcedure, ref err,
                    new SqlParameter("@userID", 19110253),
                    new SqlParameter("@userPassword", Encrytion.Encrypt("12345")));
                MessageBox.Show("Update thanh cong");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
        }
        private void loadImage(DataGridView dgv, FlowLayoutPanel flowlayout)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           

        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
