using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class UserSignUp : UserControl
    {
        string password;
        public UserSignUp()
        {
            InitializeComponent();
        }

        public string Password { get => password; private set => password = value; }

        private bool checkSignUp()
        {
            string s = txtPhone.Text;
            Password = txtPassword.Text;
            if (txtPassword.Text != txtRepassword.Text) return false;
            if (txtPhone.Text.Length < 10) return false;
            for (int i = 0; i < s.Length; i++) if (s[i] < '0' || s[i] > '9') return false;
            return true;
        }
    }
}
