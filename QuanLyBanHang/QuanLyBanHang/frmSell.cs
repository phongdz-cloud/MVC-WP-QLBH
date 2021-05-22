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
using DAO;
using System.Security.Cryptography;

namespace QuanLyBanHang
{
    public partial class frmSell : Form
    {
        private static frmSell instance;
        DataTable dbChart;
        public static frmSell Intance { get { if (instance == null) instance = new frmSell(); return frmSell.instance; } private set => instance = value; }
        public frmSell()
        {
            InitializeComponent();
            frmShopping.Instance.Init();
            frmSanPhamGuna.Instance.Init();
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmSell_Load(object sender, EventArgs e)
        {
            guna2ShadowForm1.SetShadowForm(this);
             dbChart = DBProvider.Instance.ExecuteQueryDataTable("SELECT * FROM thongke", CommandType.Text, null);
            dgvChart.DataSource = dbChart;
        }
        void load()
        {
            var objChart = Chart.ChartAreas[0];
            // month 1-12
            objChart.AxisX.Minimum = 1;
            objChart.AxisX.Maximum = 12;
            objChart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = 0;
            objChart.AxisY.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            Chart.Series.Clear();
            Random random = new Random();
            foreach (DataRow item in dbChart.Rows)
            {
                string s = item[0].ToString();
                Chart.Series.Add(item[0].ToString());
                Chart.Series[item[0].ToString()].Color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
                Chart.Series[item[0].ToString()].Legend = "Legend1";
                Chart.Series[item[0].ToString()].ChartArea = "ChartArea1";
                Chart.Series[item[0].ToString()].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                for (int i = 1; i <= 12; i++)
                {
                    Chart.Series[item[0].ToString()].Points.AddXY(i, Convert.ToInt32(item[i].ToString()));
                }
            }
        }
        public void loadImageUser(string file,string name)
        {
            pbImageUser.Image = Image.FromFile(Application.StartupPath + @file);
            lbName.Text = name;
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



        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmShopping.Instance.ShowDialog();
            this.Show();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmSanPhamGuna.Instance.ShowDialog();
            this.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            load();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserHistoryContract.Instance.ShowDialog();
            this.Show();
        }

        private void btnShopping2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UserHistoryTrans.Instance.ShowDialog();
            lbTotalPrice.Text = "$"+UserHistoryTrans.Instance.Sum.ToString()+"đ" ;
            this.Show();
        }
    }
}
