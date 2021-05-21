using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAO;
namespace QuanLyBanHang
{
    public partial class UserHistoryTrans : UserControl
    {
        CustomerBUS customerBUS = new CustomerBUS();
        EmployeeBUS employeeBUS = new EmployeeBUS();
        private static UserHistoryTrans instance;
        private double sum;
        Form  window;

        public static UserHistoryTrans Instance { get { if (instance == null) instance = new UserHistoryTrans();return UserHistoryTrans.instance; } set => instance = value; }

        public double Sum { get => sum; set => sum = value; }

        public UserHistoryTrans()
        {
            InitializeComponent();

        }
        void loadTrans()
        {
            Sum = 0;
            MAKHACHHANG.DataSource = customerBUS.GetCustomer();
            MAKHACHHANG.DisplayMember = "TENKH";
            MAKHACHHANG.ValueMember = "MAKH";
            MANHANVIEN.DataSource = employeeBUS.GetEmployee();
            MANHANVIEN.DisplayMember = "HOTEN";
            MANHANVIEN.ValueMember = "MANV";
            DataTable dbTrans = DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM dbo.HOADON", CommandType.Text, null);
            dgvHistoryTrans.DataSource = dbTrans;
           for(int i =0; i<=dbTrans.Rows.Count-1;i++)
            {
                Sum += Convert.ToDouble(dbTrans.Rows[i][4].ToString());
            }
            lbPrice.Text = Sum.ToString() +"đ";
        }

        private void UserHistoryTrans_Load(object sender, EventArgs e)
        {
            loadTrans();
        }
        public DialogResult ShowDialog()
        {
             window = new Form
            {
                TopLevel = true,
                FormBorderStyle = FormBorderStyle.None, //Disables user resizing
                MaximizeBox = false,
                MinimizeBox = false,
                ClientSize = instance.Size //size the form to fit the content
                
            };
            window.Controls.Add(instance);
            window.StartPosition = FormStartPosition.CenterParent;
            instance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            return window.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}
