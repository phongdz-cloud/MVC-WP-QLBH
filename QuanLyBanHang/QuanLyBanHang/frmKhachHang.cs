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
namespace QuanLyBanHang
{
    public partial class frmKhachHang : Form
    {
        CustomerDTO customerDTO = new CustomerDTO();
        CustomerBUS customerBUS = new CustomerBUS();
        CustomerTypeBUS customerTypeBUS = new CustomerTypeBUS();
        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            load();
            binding();
        }
        private void load()
        {
            DataTable dbCustomerType = customerTypeBUS.GetCustomerType();
            MaLoaiKH.DataSource = dbCustomerType;
            MaLoaiKH.DisplayMember = "TENLOAI";
            MaLoaiKH.ValueMember = "MALOAIKH";
            DataTable dbCustomer = customerBUS.GetCustomer();
            dgvKhachHang.DataSource = dbCustomer;
        }
        private void binding()
        {
            txtMaKhachHang.DataBindings.Clear();
            txtMaKhachHang.DataBindings.Add("Text", dgvKhachHang.DataSource, "MAKH");
            txtTenKhachHang.DataBindings.Clear();
            txtTenKhachHang.DataBindings.Add("Text", dgvKhachHang.DataSource, "TENKH");
            cbbGioiTinh.DataBindings.Add("Text", dgvKhachHang.DataSource, "GIOITINH");
            txtDiaChi.DataBindings.Clear();
            txtDiaChi.DataBindings.Add("Text", dgvKhachHang.DataSource, "DIACHI");
            txtDienThoai.DataBindings.Clear();
            txtDienThoai.DataBindings.Add("Text", dgvKhachHang.DataSource, "DIENTHOAI");
            cbbMaLoaiKH.DataBindings.Add("Text", dgvKhachHang.DataSource, "MALOAIKH");
        }
    }
}
