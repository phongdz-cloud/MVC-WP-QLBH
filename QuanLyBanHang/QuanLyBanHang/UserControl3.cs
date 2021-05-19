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
    public partial class UserControl3 : UserControl
    {
        public UserControl3(string name, string amount, string price)
        {
            InitializeComponent();
            lbSP.Text = name;
            lbSL.Text = "x" + amount;
            lbPrice.Text = price;
        }
    }
}
