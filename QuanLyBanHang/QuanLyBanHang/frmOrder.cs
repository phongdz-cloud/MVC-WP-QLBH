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
using Function;
namespace QuanLyBanHang
{
    public partial class frmOrder : Form
    {
        #region Khởi tạo các thuộc tính cần có của form hóa đơn
        CustomerBUS customerBUS = new CustomerBUS();
        ProductGroupBUS productGroupBUS = new ProductGroupBUS();
        EmployeeBUS employeeBUS = new EmployeeBUS();
        ProductBUS productBUS = new ProductBUS();
        private static double total = 0;

        public frmOrder()
        {
            InitializeComponent();
        }
        #endregion
        #region sự kiện cho form load
        private void frmOrder_Load(object sender, EventArgs e)
        {
            loadKH();
            loadNV();
            loadSP();
            TotalPrice();

        }
        private void TotalPrice()
        {
            for(int i =0; i< dgvProd.Rows.Count;i++)
            {
                if (dgvProd.Rows[i].Cells[2].Value != null)
                {
                    total += Convert.ToDouble(dgvProd.Rows[i].Cells[2].Value.ToString());
                }
            }
            txtTongTien.Text = total.ToString();
            lbToTal.Text = Func.NumbertoWord(total);
        }
        #endregion
        #region Phương thức có chức năng load form KH
        
        private void loadKH()
        {
            DataTable dbCustomer = customerBUS.GetCustomer();
            cbbMaKH.DataSource = dbCustomer;
            cbbMaKH.DisplayMember = "MAKH";
            cbbMaKH.ValueMember = "MAKH";
            cbbTenKH.DataSource = dbCustomer;
            cbbTenKH.DisplayMember = "TENKH";
            cbbTenKH.ValueMember = "MAKH";
            cbbDiaChi.DataSource = dbCustomer;
            cbbDiaChi.DisplayMember = "DIACHI";
            cbbDiaChi.ValueMember = "MAKH";
            cbbSDT.DataSource = dbCustomer;
            cbbSDT.DisplayMember = "DIENTHOAI";
            cbbSDT.ValueMember = "MAKH";
        }
        #endregion
        #region Phương thức có chức nang load form Nhân viên
        private void loadNV()
        {
            DataTable dbEmployee = employeeBUS.GetEmployee();
            cbbMaNV.DataSource = dbEmployee;
            cbbMaNV.DisplayMember = "MANV";
            cbbMaNV.ValueMember = "MANV";
            cbbTenNV.DataSource = dbEmployee;
            cbbTenNV.DisplayMember = "HOTEN";
            cbbTenNV.ValueMember = "MANV";
        }
        private void loadSP()
        {
            DataTable dbProductType = productGroupBUS.GetProductGroup();
            MANHOMSP.DataSource = dbProductType;
            MANHOMSP.DisplayMember = "TENNHOMSP";
            MANHOMSP.ValueMember = "MANHOMSP";
            DataTable dbProduct = productBUS.GetProduct();
            dgvProd.DataSource = dbProduct;
            cbbMaSP.DataSource = dbProduct;
            cbbMaSP.DisplayMember = "MASANPHAM";
            cbbMaSP.ValueMember = "MASANPHAM";
            cbbTenSP.DataSource = dbProduct;
            cbbTenSP.DisplayMember = "TENSANPHAM";
            cbbTenSP.ValueMember = "MASANPHAM";
            txtGiaSP.Clear();
            txtGiaSP.DataBindings.Add("Text", dgvProd.DataSource, "GIABAN");
        }
        #endregion
    }
}
