using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2;
namespace QuanLyBanHang
{
    public partial class frmSell : Form
    {
        private static frmSell instance;
        public static frmSell Intance { get { if (instance == null) instance = new frmSell(); return frmSell.instance; } private set => instance = value; }
        public frmSell()
        {
            InitializeComponent();
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmSell_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);

        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
        private void btnEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEmployeeGuna.Instance.ShowDialog();
            this.Show();
        }
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSanPhamGuna.Instance.ShowDialog();
            this.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmCustomer.Instance.ShowDialog();
            this.Show();
        }
    }
}
