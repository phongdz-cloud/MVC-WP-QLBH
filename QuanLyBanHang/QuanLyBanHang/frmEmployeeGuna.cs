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
using DTO;
using DAO;
using Function;
using System.IO;
namespace QuanLyBanHang
{
    public partial class frmEmployeeGuna : Form
    {
        private EmployeeBUS employeeBUS = new EmployeeBUS();

        private static frmEmployeeGuna instance;
        private DataTable dbAll;
        private bool flag = false;
        private string err;
        private EmployeeDTO employeeDTO;
        public static frmEmployeeGuna Instance { get { if (instance == null) 
            instance = new frmEmployeeGuna(); return frmEmployeeGuna.instance; } 
            private set => instance = value; }

        public DataTable DbAll { get => dbAll; set => dbAll = value;}
        public EmployeeDTO EmployeeDTO { get => employeeDTO; set => employeeDTO = value; }

        public frmEmployeeGuna()
        {
            InitializeComponent();
            load();
        }
        public void Init()
        {
            
        }
        private EmployeeDTO getData(int RowIndex)
        {
            EmployeeDTO employee = new EmployeeDTO();
            employee.MaNV = dgvEmployee.Rows[RowIndex].Cells[0].Value.ToString();
            employee.HoTen = dgvEmployee.Rows[RowIndex].Cells[1].Value.ToString();
            employee.GioiTinh = dgvEmployee.Rows[RowIndex].Cells[2].Value.ToString();
            employee.NgaySinh = dgvEmployee.Rows[RowIndex].Cells[3].Value.ToString();
            employee.DiaChi = dgvEmployee.Rows[RowIndex].Cells[4].Value.ToString();
            employee.DienThoai = dgvEmployee.Rows[RowIndex].Cells[5].Value.ToString();
            employee.NgayVaoLam = dgvEmployee.Rows[RowIndex].Cells[6].Value.ToString();
            employee.Salary = Convert.ToInt32(dgvEmployee.Rows[RowIndex].Cells[7].Value.ToString());
            employee.Images = (byte [])dgvEmployee.Rows[RowIndex].Cells[8].Value;
            return employee;
        }
        private void frmEmployeeGuna_Load(object sender, EventArgs e)
        {

            load();
        }
        private void load()
        {
            DataTable db = new DataTable();
            db = employeeBUS.GetEmployee();
            dgvEmployee.DataSource = db;
            ((DataGridViewImageColumn)dgvEmployee.Columns["IMAGES"]).ImageLayout =
    DataGridViewImageCellLayout.Stretch;
            int countMale = 0;
            int countFemale = 0;
            for (int i = 0; i <= dgvEmployee.Rows.Count - 2; i++)
            {
                if (dgvEmployee.Rows[i].Cells[2].Value.ToString() == "Nam") countMale++;
                else countFemale++;

            }
            lbEmployee.Text = (dgvEmployee.Rows.Count - 1).ToString() + " Employee";
            lbMale.Text = countMale.ToString() + " Male";
            lbFemale.Text = countFemale.ToString() + " Female";
            DbAll = new DataTable();
            DbAll = (DataTable)dgvEmployee.DataSource;
        }
        private void btnSeach_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text.Length >0)
            {
                flag = true;
                string sql = "SELECT * FROM dbo.NHANVIEN WHERE HOTEN LIKE '%" + txtSearch.Text + "%'";
                dgvEmployee.DataSource = DBProvider.Instance.ExecuteQueryDataTable(sql,CommandType.Text,null);
            }
        }
       
        private void btnShowList_Click(object sender, EventArgs e)
        {
            flag = false;
            frmEmployeeGuna_Load(sender, e);
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSeach_Click(sender, e);
        }
        private void btnDetail_Click_1(object sender, EventArgs e)
        {
            EmployeeDTO = getData(dgvEmployee.CurrentCell.RowIndex);
            frmDetailEmloyee frmDetailEmloyee = new frmDetailEmloyee();
            frmDetailEmloyee.ShowDialog();
            frmDetailEmloyee.loadForm(ref flag);
            DbAll = null;
            frmEmployeeGuna_Load(sender,e);
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            EmployeeDTO = getData(dgvEmployee.CurrentCell.RowIndex);
            frmViewEmployee frmViewEmployee = new frmViewEmployee();
            frmViewEmployee.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận hủy",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                EmployeeDTO = getData(dgvEmployee.CurrentCell.RowIndex);
                if(employeeBUS.DeleteEmployee(ref err,EmployeeDTO))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DbAll = null;
                    frmEmployeeGuna_Load(sender, e);
                }
                else MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận hủy",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
        }
        #region event không dùng
        private void frmEmployeeGuna_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void lbSoLuong_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbFemale_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton3_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {

        }

        private void lbMale_Click(object sender, EventArgs e)
        {

        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }

        private void lbEmployee_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion
    }
}
