using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using System.Data.SqlClient;
using Function;
namespace QuanLyBanHang
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DBProvider.Instance.Conn.Open();
                string sql = "SELECT * FROM dbo._USER WHERE userID = "+txtID.Text+" AND userPassword = '"+Encrytion.Encrypt(txtPassword.Text)+"'";
                DBProvider.Instance.Cmd.CommandText = sql;
                DBProvider.Instance.Cmd.CommandType = CommandType.Text;
                SqlDataReader read = DBProvider.Instance.Cmd.ExecuteReader();
                if(read.Read())
                {
                    MessageBox.Show("Chúc mừng bạn đã đăng nhập thành công","Login thành công",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    if(guna2ToggleSwitch1.Checked == false)
                    {
                        txtID.ResetText();
                        txtPassword.ResetText();
                    }
                    read.Close();
                    read.Dispose();
                }
                else
                {
                    MessageBox.Show("Sai tên tài khoản hoặc mật khẩu mời bạn nhập lại", "Login thất bại", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                DBProvider.Instance.Conn.Close();
                DBProvider.Instance.Cmd.Dispose();
                frmSell.Intance.ShowDialog();
                this.Show();
            }
        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
