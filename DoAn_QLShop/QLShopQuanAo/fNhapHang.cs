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
namespace QLShopQuanAo
{
    partial class fNhapHang : Form
    {
        public XuLy XL { get; set; }
        public int MaNV {get;set;}
        fThongBao TB = new fThongBao();
        public fNhapHang()
        {
            InitializeComponent();
        }
        void HienThiDSPhieuNhap() {
            XL.LayDSPhieuNhap(dtgvDSPN);
        }
        void LoadTenSanPham() {
            cbbTenSP.DataSource = XL.tblSanPham();
            cbbTenSP.DisplayMember = "TenSP";
            cbbTenSP.ValueMember = "MaSP";

        }
        private void fNhapHang_Load(object sender, EventArgs e)
        {
            HienThiDSPhieuNhap();
            LoadTenSanPham();
            btnThem.Enabled = false;
        }
        //Hiển thị thông tin chi tiết phiếu nhập lên listview
        private void dtgvDSPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int mapn = int.Parse(dtgvDSPN.CurrentRow.Cells[0].Value.ToString());
            XL.HienThiCTPhieuNhap(mapn, CTPhieuNhap);
            txtTongTien.Text = dtgvDSPN.CurrentRow.Cells[3].Value.ToString();

        }
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) & !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        //thêm sản phẩm nhập vào listview phiếu nhập
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (XL.KTRong(cbbTenSP.Text) || XL.KTRong(txtSoLuong.Text) || XL.KTRong(txtGiaNhap.Text))
            {
                //MessageBox.Show("Vui lòng nhập đủ thông tin!");
                TB.MessageThongBao = "Vui lòng nhập đủ thông tin!";
                TB.ShowDialog();
            }
            else {
                SanPham sp = new SanPham();
                sp.MaSP = (int)cbbTenSP.SelectedValue;
                sp.TenSP = cbbTenSP.Text;
                sp.SoLuong = int.Parse(txtSoLuong.Text);
                sp.GiaNhap = int.Parse(txtGiaNhap.Text);
                XL.ThemSPVaoCTPN(sp,CTPhieuNhap);
                txtTongTien.Text = XL.TinhTongTienPhieuNhap(CTPhieuNhap).ToString();
                cbbTenSP.Text = "";
                txtSoLuong.Text = "";
                txtGiaNhap.Text = "";
                cbbTenSP.Focus();
            }
        }
        //Tạo phiếu nhập hàng

        private void btnTaoPN_Click(object sender, EventArgs e)
        {
            if (XL.KTPhieuNhap(CTPhieuNhap))
            {
                if (XL.ThemPhieuNhap(MaNV,XL.TinhTongTienPhieuNhap(CTPhieuNhap), CTPhieuNhap))
                {
                    //MessageBox.Show("Tạo phiếu nhập thành công!");
                    //TB.MessageThongBao = "Tạo phiếu nhập thành công!";
                    //TB.ShowDialog();
                    HienThiDSPhieuNhap();
                    CTPhieuNhap.Items.Clear();
                    cbbTenSP.Text = "";
                    txtSoLuong.Text = "";
                    txtGiaNhap.Text = "";
                    btnThem.Enabled = false;
                    fInPhieuNhap ipn = new fInPhieuNhap();
                    ipn.MaPN = XL.LayMaPhieuNhapMoi()-1;
                    ipn.ShowDialog();
                }
                else
                {

                    TB.MessageThongBao = "Lỗi!";
                    TB.ShowDialog();
                }
            }
            else
            {
                TB.MessageThongBao = "Vui lòng chọn Sản Phẩm nhập!";
                TB.ShowDialog();
            }
        }
        //Bắt đầu tạo một phiếu nhập mới
        private void btnTaoMoiPN_Click(object sender, EventArgs e)
        {
            CTPhieuNhap.Items.Clear();
            cbbTenSP.Text = "";
            txtSoLuong.Text = "";
            txtGiaNhap.Text = "";
            btnThem.Enabled = true;
            cbbTenSP.Focus();
        }
        //Tìm phiếu nhập hàng theo ngày
        private void dtpNgayLap_ValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show(dtpNgayLap.Value.ToShortDateString());
        }
        //Tìm kiếm những phiếu nhập hàng theo ngày trên datetimepicker
        private void btnTKPN_Click(object sender, EventArgs e)
        {
            XL.LayDSPhieuNhap_TheoNgay(dtgvDSPN,dtpNgayLap.Value.ToShortDateString());
        }
    }
}
