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
                string sql = "SELECT * FROM dbo._USER WHERE userID = "+txtID.Text+" AND userPassword = '"+Encrytion.Encrypt(txtPassword.Text)+"'";
                DataTable read = DBProvider.Instance.ExecuteQueryDataTable(sql, CommandType.Text, null);
                if(read.Rows.Count>0)
                {
                    this.Hide();
                    if(guna2ToggleSwitch1.Checked == false)
                    {
                        txtID.ResetText();
                        txtPassword.ResetText();
                    }
                    if (cbEmploy.Checked == false) frmShopping.Instance.ShowDialog();
                    else frmSell.Intance.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Sai tên tài khoản hoặc mật khẩu mời bạn nhập lại", "Login thất bại", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Tên tài khoản không tồn tại", "Login thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSignUp_Click(object sender, EventArgs e)
        {
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void cbEmploy_CheckedChanged(object sender, EventArgs e)
        {

            if (cbEmploy.Checked == false) lbEmploy.Text = "Employee";
            else lbEmploy.Text = "Manager";
        }
    }
}
