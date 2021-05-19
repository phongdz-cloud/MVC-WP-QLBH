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
using DTO;
using Function;
using Guna.UI2.WinForms;
namespace QuanLyBanHang
{
    public partial class frmDetailContract : Form
    {
        private EmployeeDAO employee = new EmployeeDAO();
        private SupplierDAO supplier = new SupplierDAO();
        private PaymentBUS paymentBUS = new PaymentBUS();
        private DetailSupllierContractBUS detailSupllierContractBUS = new DetailSupllierContractBUS();
        private SupllierContractBUS supllierContractBUS = new SupllierContractBUS();
        private DetailSupllierContractDTO detailSupllierContractDTO;
        private SupllerContractDTO supllerContractDTO;
        private PaymentDTO paymentDTO;
        private DataTable dbEmployee;
        private DataTable dbSupllier;
        private string err;
        public frmDetailContract()
        {
            InitializeComponent();
        }
        private PaymentDTO getPayment(string idContract,string idEmployee,double total)
        {
            PaymentDTO payment = new PaymentDTO();
            payment.IdPayment = Func.taoID(9, ref err);
            payment.MaHD = idContract;
            payment.MaNV = idEmployee;
            payment.Total = total;
            return payment;
        }
        private SupllerContractDTO getSupplerContract()
        {
            SupllerContractDTO supllerContract = new SupllerContractDTO();
            supllerContract.MaHD = txtMHD.Text;
            supllerContract.MaNCC = cbbIDSupllier.SelectedValue.ToString();
            return supllerContract;
        }
        private DetailSupllierContractDTO getDetailSupllerContract(string idProduct,int SL,int total,int price)
        {
            DetailSupllierContractDTO detailSupllierContractDTO = new DetailSupllierContractDTO();
            detailSupllierContractDTO.MaHD = txtMHD.Text;
            detailSupllierContractDTO.MaSP = idProduct;
            detailSupllierContractDTO.Sl = SL;
            detailSupllierContractDTO.ThanhTien = total;
            detailSupllierContractDTO.GiaGoc = price;
            return detailSupllierContractDTO;
        }
        private void DetailContract_Load(object sender, EventArgs e)
        {
            if (dbEmployee == null)
            {
                dbEmployee = employee.getEmployee();
                dbSupllier = supplier.getSupllier();
                cbbIDEmployee.DataSource = dbEmployee;
                cbbIDEmployee.DisplayMember = "HOTEN";
                cbbIDEmployee.ValueMember = "MANV";
                cbbIDSupllier.DataSource = dbSupllier;
                cbbIDSupllier.DisplayMember = "TENNCC";
                cbbIDSupllier.ValueMember = "MANCC";
                txtMHD.Text = Func.taoID(8, ref err);
                load();
            }
        }
        void load()
        {
            double priceSupller = 0;
            foreach (var item in frmSanPhamGuna.Instance.UpdateOrder)
            {
                Guna2NumericUpDown numeric = (Guna2NumericUpDown)item.Value.Controls["numericSL"];
                floPanel.Controls.Add(orderProduct(item.Value.Controls["lbSP"].Text
                    ,Convert.ToInt32(numeric.Value),
                    item.Value.Controls["lbPrice"].Text));
                priceSupller += Convert.ToInt32(numeric.Value) 
                    *Convert.ToDouble(item.Value.Controls["lbPrice"].Text.Substring(0, item.Value.Controls["lbPrice"].Text.Length - 1));
            }
            lbTotalPrice.Text = priceSupller.ToString();
        }
        UserControl3 orderProduct(string nameProduct, int amount,string price)
        {
            UserControl3 ctl3 = new UserControl3(nameProduct,amount.ToString(),price);
            return ctl3;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn hủy đơn hàng này không?", "Xác nhận hủy",
                 MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dr == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc muốn nhập số đơn hàng này không?", "Xác nhận hủy",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            try
            {
                if (dr == DialogResult.Yes)
                {
                    supllerContractDTO = getSupplerContract();
                    if (supllierContractBUS.InsertSupllerContract(ref err, supllerContractDTO))
                    {
                        foreach (var item in frmSanPhamGuna.Instance.UpdateOrder)
                        {
                            Guna2NumericUpDown numeric = (Guna2NumericUpDown)item.Value.Controls["numericSL"];
                            detailSupllierContractDTO =
                                getDetailSupllerContract(item.Value.Controls["lbPrice"].Tag.ToString(),
                              Convert.ToInt32(numeric.Value)
                              , Convert.ToInt32(numeric.Value) * Convert.ToInt32(item.Value.Controls["lbPrice"].Text.Substring(0, item.Value.Controls["lbPrice"].Text.Length - 1))
                              , Convert.ToInt32(item.Value.Controls["lbPrice"].Text.Substring(0, item.Value.Controls["lbPrice"].Text.Length - 1)));
                            if(!detailSupllierContractBUS.InsertDetailSupllierContract(ref err,detailSupllierContractDTO))
                            {
                                MessageBox.Show("Thanh toan that bai!");
                                break;
                            }
                        }
                        MessageBox.Show("Chúc mừng bạn đã thanh toán thành công!");
                        Func.updateAutoID();
                        paymentDTO = getPayment(supllerContractDTO.MaHD, cbbIDEmployee.SelectedValue.ToString(), Convert.ToDouble(lbTotalPrice.Text));
                        if (paymentBUS.InsertPayment(ref err, paymentDTO))
                            Func.updateAutoID();
                        this.Close();
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
