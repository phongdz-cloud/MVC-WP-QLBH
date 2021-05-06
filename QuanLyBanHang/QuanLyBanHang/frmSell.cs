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
        static frmSell_ frmsell_ ;
        static frmSanPhamGuna frmSanPhamGuna = new frmSanPhamGuna();
        static frmEmployeeGuna frmEmployeeGuna = new frmEmployeeGuna();
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
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if (frmsell_ == null)
            {
                frmsell_ = new frmSell_();
                frmsell_.Controls.Add(new frmSell().Controls["guna_container"]);
            }
            container(frmSanPhamGuna);
        }
        private void container(object _form)
        {
            if (guna_container.Controls.Count > 0) guna_container.Controls.Clear();
            Form fm = _form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            guna_container.Controls.Add(fm);
            guna_container.Tag = fm;
            fm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(frmsell_ != null)
            container(frmsell_);
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmEmployeeGuna.ShowDialog();
            this.Close();
        }
    }
}
