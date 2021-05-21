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
using BUS;
namespace QuanLyBanHang
{
    public partial class UserHistoryContract : UserControl
    {
        private EmployeeBUS employeeBUS = new EmployeeBUS();
        private static UserHistoryContract instance;
        Form window;
        public static UserHistoryContract Instance { get { if (instance == null) instance = new UserHistoryContract(); return UserHistoryContract.instance; } private set => Instance = value; }

        public UserHistoryContract()
        {
            InitializeComponent();
        }
        void load()
        {
            double sum = 0;
            MANV.DataSource = employeeBUS.GetEmployee();
            MANV.DisplayMember = "HOTEN";
            MANV.ValueMember = "MANV";
            DataTable dbHistoryContract = DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM dbo.PHIEUCHI", CommandType.Text, null);
            dgvHistoryContract.DataSource = dbHistoryContract;
            for (int i = 0; i <= dbHistoryContract.Rows.Count - 1; i++)
                if(dbHistoryContract.Rows[i][4].ToString().Length>0)
                sum +=Convert.ToDouble(dbHistoryContract.Rows[i][4].ToString());
            lbPrice.Text = sum.ToString() + "đ";
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

        private void UserHistoryContract_Load(object sender, EventArgs e)
        {
            load();
        }
    }
}
