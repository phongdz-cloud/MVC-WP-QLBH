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
using Function;
namespace QuanLyBanHang
{
    public partial class frmCustomer : Form
    {
        private CustomerBUS customerBUS = new CustomerBUS();
        private CustomerTypeBUS customerTypeBUS = new CustomerTypeBUS();
        private CustomerDTO customer;
        private static frmCustomer instance;
        private bool flag;
        private bool flag_method;
        private string err;
        private string autoID = null;
        private string fileName = null;
        private DataTable dbAll;
        private DataTable dbCustomerALL;
        public static frmCustomer Instance { 
            get { if (instance == null)
                 instance = new frmCustomer();  return frmCustomer.instance; } 
            private set => instance = value; }

        public DataTable DbAll { get => dbAll; private set => dbAll = value; }
        public DataTable DbCustomerALL { get => dbCustomerALL;private set => dbCustomerALL = value; }

        public frmCustomer()
        {
            InitializeComponent();
            load();
        }
        private void load()
        {
            DbCustomerALL = new DataTable();
            DbCustomerALL = customerTypeBUS.GetCustomerType();
            MALOAIKH.DataSource = DbCustomerALL;
            MALOAIKH.DisplayMember = "TENLOAI";
            MALOAIKH.ValueMember = "MALOAIKH";
            cbbType.DataSource = DbCustomerALL;
            cbbType.DisplayMember = "TENLOAI";
            cbbType.ValueMember = "MALOAIKH";
            dgvCustomer.DataSource = customerBUS.GetCustomer();
            lbCustomer.Text = (dgvCustomer.Rows.Count - 1).ToString() + " Employee";
            int countMale = 0;
            int countFemale = 0;
            for (int i = 0; i <= dgvCustomer.Rows.Count - 2; i++)
            {
                if (dgvCustomer.Rows[i].Cells[2].Value.ToString() == "Nam") countMale++;
                else countFemale++;
            }
            lbMale.Text = countMale.ToString() + " Male";
            lbFemale.Text = countFemale.ToString() + " Female";
            DbAll = new DataTable();
            DbAll = (DataTable)dgvCustomer.DataSource;
        }
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            if (flag == false)
            {
                if (DbAll == null) load();
                else dgvCustomer.DataSource = DbAll;
            }
            dis_en(false);
        }
        private void btnSeach_Click(object sender, EventArgs e)
        {
            Search();
        }
        private void Search()
        {
            if (txtSearch.Text.Length > 0)
            {
                flag = true;
                string sql = "SELECT * FROM dbo.KHACHHANG WHERE TENKH LIKE '%" + txtSearch.Text + "%'";
                dgvCustomer.DataSource = DBProvider.Instance.ExecuteQueryDataTable(sql, CommandType.Text, null);
            }
        }
        private CustomerDTO getData(int rowIndex)
        {
            CustomerDTO customer = new CustomerDTO();
            customer.MaKH = dgvCustomer.Rows[rowIndex].Cells[0].Value.ToString();
            customer.TenKH = dgvCustomer.Rows[rowIndex].Cells[1].Value.ToString();
            customer.GioiTinh = dgvCustomer.Rows[rowIndex].Cells[2].Value.ToString();
            customer.DiaChi = dgvCustomer.Rows[rowIndex].Cells[3].Value.ToString();
            customer.DienThoai = dgvCustomer.Rows[rowIndex].Cells[4].Value.ToString();
            customer.MaLoaiKH = dgvCustomer.Rows[rowIndex].Cells[5].Value.ToString();
            if (fileName != null) customer.Images = fileName;
            else customer.Images = @"C:\Users\dell\Desktop\CloneProject\Project-Qu-n-l-b-n-h-ng\QuanLyBanHang\QuanLyBanHang\Image\DSC3605.jpg";
            return customer;
        }
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) btnSeach_Click(sender, e);
        }

        private void btnShowList_Click(object sender, EventArgs e)
        {
            flag = false;
            frmCustomer_Load(sender, e);
        }

        private void btnBrown_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;)|*.jpg; *.jpeg; *.gif; *.bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                fileName = open.FileName;
                pbAvatar.Image = new Bitmap(open.FileName);
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtID.Text != dgvCustomer.Rows[dgvCustomer.CurrentCell.RowIndex].Cells[0].Value.ToString())
            {
                txtID.Text = dgvCustomer.Rows[dgvCustomer.CurrentCell.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dgvCustomer.Rows[dgvCustomer.CurrentCell.RowIndex].Cells[1].Value.ToString();
                cbbSex.Text = dgvCustomer.Rows[dgvCustomer.CurrentCell.RowIndex].Cells[2].Value.ToString();
                txtDiaChi.Text = dgvCustomer.Rows[dgvCustomer.CurrentCell.RowIndex].Cells[3].Value.ToString();
                txtPhone.Text = dgvCustomer.Rows[dgvCustomer.CurrentCell.RowIndex].Cells[4].Value.ToString();
                cbbType.Text = dgvCustomer.Rows[dgvCustomer.CurrentCell.RowIndex].Cells[5].Value.ToString();
                if (dgvCustomer.Rows[dgvCustomer.CurrentCell.RowIndex].Cells[6].Value.ToString().Length <= 0)
                    pbAvatar.Image = Image.FromFile(@"C:\Users\dell\Desktop\CloneProject\Project-Qu-n-l-b-n-h-ng\QuanLyBanHang\QuanLyBanHang\Image\DSC3605.jpg");
                else
                    pbAvatar.Image = Image.FromFile(@dgvCustomer.Rows[dgvCustomer.CurrentCell.RowIndex].Cells[6].Value.ToString());
            }
            dis_en(false);
        }
        private void dis_en(bool e)
        {
            txtName.Enabled = e;    
            cbbSex.Enabled = e;
            txtDiaChi.Enabled = e;
            txtPhone.Enabled = e;
            cbbType.Enabled = e;
            btnBrown.Enabled = e;
            btnSave.Enabled = e;
            btnRest.Enabled = e;
            btnInsert.Enabled = !e;
            btnDelete.Enabled = !e;
            btnEdit.Enabled = !e;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            flag_method = true;
            dis_en(true);
            if (autoID == null) autoID = Func.taoID(3,ref err);
            if(autoID != null )
            {
                txtID.Text = autoID;
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            flag_method = false;
            dis_en(true);
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa khách hàng này không?", "Xác nhận hủy",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                customer = getData(dgvCustomer.CurrentCell.RowIndex);
                if (customerBUS.DeleteCustomer(ref err, customer))
                {
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    flag = false;
                    DbAll = null;
                    frmCustomer_Load(sender, e);
                }
                else MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRest_Click(object sender, EventArgs e)
        {
            txtName.ResetText();
            txtDiaChi.ResetText();
            txtPhone.ResetText();
            cbbSex.SelectedIndex = 0;
            cbbType.SelectedIndex = 0;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (flag_method == true)
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn thêm khách hàng này không?", "Xác nhận hủy",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    customer = getData(dgvCustomer.CurrentCell.RowIndex);
                    customer.MaKH = autoID;
                    if (customerBUS.InsertCustomer(ref err, customer))
                    {
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        flag = false;
                        DbAll = null;
                        Func.updateAutoID();
                        autoID = null;
                        fileName = null;
                        frmCustomer_Load(sender, e);
                    }
                    else MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn sửa thông tin khách hàng này không?", "Xác nhận hủy",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    customer = getData(dgvCustomer.CurrentCell.RowIndex);
                    if (customerBUS.UpdateCustomer(ref err, customer))
                    {
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        flag = false;
                        DbAll = null;
                        fileName = null;
                        frmCustomer_Load(sender, e);
                    }
                    else MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn thoát không?", "Xác nhận hủy",
                  MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
        }
    }
}
