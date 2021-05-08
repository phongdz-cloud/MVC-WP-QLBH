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
            set => instance = value; }

        public DataTable DbAll { get => dbAll; set => dbAll = value; }

        public frmEmployeeGuna()
        {
            InitializeComponent();
            load();
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
            employee.Images = dgvEmployee.Rows[RowIndex].Cells[7].Value.ToString();
            return employee;
        }
        private void frmEmployeeGuna_Load(object sender, EventArgs e)
        {
            if(flag == false)
            {
                if (DbAll == null) load();
                else dgvEmployee.DataSource = DbAll;
            }
        }
        private void load()
        {
            DataTable db = new DataTable();
            db = employeeBUS.GetEmployee();
            dgvEmployee.DataSource = db;
            lbEmployee.Text = (dgvEmployee.Rows.Count - 1).ToString() + " Employee";
            int countMale = 0;
            int countFemale = 0;
            for (int i = 0; i <= dgvEmployee.Rows.Count - 2; i++)
            {
                if (dgvEmployee.Rows[i].Cells[2].Value.ToString() == "Nam") countMale++;
                else countFemale++;
            }
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
            employeeDTO = getData(dgvEmployee.CurrentCell.RowIndex);
            frmDetailEmloyee frmDetailEmloyee = new frmDetailEmloyee(employeeDTO);
            frmDetailEmloyee.ShowDialog();
            frmDetailEmloyee.loadForm(ref flag);
            if(flag == true)
            {
                DbAll = null;
                frmEmployeeGuna_Load(sender,e);
            }
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            employeeDTO = getData(dgvEmployee.CurrentCell.RowIndex);
            frmViewEmployee frmViewEmployee = new frmViewEmployee(employeeDTO);
            frmViewEmployee.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa không?", "Xác nhận hủy",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                employeeDTO = getData(dgvEmployee.CurrentCell.RowIndex);
                if(employeeBUS.DeleteEmployee(ref err,employeeDTO))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DbAll = null;
                    frmEmployeeGuna_Load(sender, e);
                }
                else MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
