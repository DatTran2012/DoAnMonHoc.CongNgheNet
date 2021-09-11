using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLShopQuanAo.Object;
using System.Data.SqlClient;
namespace QLShopQuanAo
{
    partial class fThanhToan : Form
    {
        public string TenNVLap { get; set; }
        public HoaDon HoaDon { get; set; }
        public ListView CTHD { get; set; }
        public XuLy XL { get; set; }
        fThongBao TB = new fThongBao();
        public fThanhToan()
        {
            InitializeComponent();
        }

        private void fThanhToan_Load(object sender, EventArgs e)
        {
            HienThiCTHoaDon();
            lblTenKH.Text = HoaDon.TenKH;
            lblSDTKH.Text = HoaDon.SDTKH;
            lblTenNV.Text = TenNVLap;
            txtTongTien.Text = HoaDon.TongTien.ToString();
            txtGiamGia.Text = HoaDon.GiamGia.ToString();
            txtThanhToan.Text = HoaDon.ThanhToan.ToString();
            btnInHoaDon.Enabled = false;
            txtKhachDua.Focus();
        }
        //Hiển thị thông tin chi tiết hóa đơn
        private void HienThiCTHoaDon()
        {
            XL.LayCTHoaDon(CTHD, listViewCTHD);
        }
        // Event tự động cập nhật số tiền trả khách và thực hiện in hóa đơn
        private void txtKhachDua_TextChanged(object sender, EventArgs e)
        {
            if (!XL.KTRong(txtKhachDua.Text))
            {
                txtTraKhach.Text = XL.CapNhatSoTienTraKhach(int.Parse(txtThanhToan.Text), int.Parse(txtKhachDua.Text));
            }
        }
        //Rang buộc chỉ cho nhập số vài txtKhachDua
        private void txtKhachDua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) & !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //Khi số tiền khác đưa >= số tiền thanh toán thì thực hiện chức năng in hóa đơn
        private void txtTraKhach_TextChanged(object sender, EventArgs e)
        {
            if (!XL.KTRong(txtTraKhach.Text))
            {
                btnInHoaDon.Enabled = true;
            }
            else
            {
                btnInHoaDon.Enabled = false;
            }
        }
        //Lưu thông tin hóa đơn vào CSDL và in hóa đơn cho khác hàng
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            //Tạo hóa đơn và lưu thông tin chi tiết hóa đơn vào csdl
            if (XL.TaoHoaDon(HoaDon.MaNV, HoaDon.TenKH, HoaDon.SDTKH,HoaDon.TongTien, HoaDon.GiamGia,HoaDon.ThanhToan, listViewCTHD))
            {
                //In thông tin giao dịch hóa đơn
                fInHoaDon ihd = new fInHoaDon();
                ihd.MaHD = XL.LayMaHoaDonMoi() - 1;
                ihd.ShowDialog();
                this.Close();
            }
            else
            {
                TB.MessageThongBao = "Lỗi";
                TB.ShowDialog();
            }
        }
    }
}
