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
using Guna.UI2.WinForms;

namespace QuanLyBanHang
{
    public partial class UserControl3 : UserControl
    {
        private static UserControl3 instance;
        private Guna.UI2.WinForms.Guna2PictureBox picture;

        public UserControl3()
        {
            InitializeComponent();
            Picture = new Guna.UI2.WinForms.Guna2PictureBox();
            Picture = ptbox;
        }
        public static UserControl3 Instance { get {  instance = new UserControl3(); return UserControl3.instance;  }private set => instance = value; }
        public Guna2PictureBox Picture { get => picture; set => picture = value; }
    }
}
