using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using QLShopQuanAo.Object;
namespace QLShopQuanAo
{
    partial class fHeThong : Form
    {
        public XuLy XL { get; set; }
        public TaiKhoan TKDangnhap { get; set; }
        fThongBao TB = new fThongBao();
        public fHeThong()
        {
            InitializeComponent();
        }
        private void fHeThong_Load(object sender, EventArgs e)
        {
            HienThiNhanVien();
            HienThiDSSanPham();
            LoadCBBLoaiSP();
            LoaCBBNhaCungCap();
            if (TKDangnhap.Quyen == "Nhân Viên") {
                btnQLNhanVien.Enabled = btnQLTaiKhoan.Enabled = btnTKDonHang.Enabled = false;
            }
        }
        //Load tên nhà cung cấp lên cbbNhaCungCap
        private void LoaCBBNhaCungCap()
        {
            cbbNhaCungCap.SelectedValueChanged -= cbbNhaCungCap_SelectedValueChanged;
            cbbNhaCungCap.DataSource = XL.tblNhaCungCap();
            cbbNhaCungCap.DisplayMember = "TenNCC";
            cbbNhaCungCap.ValueMember = "MaNCC";
            cbbNhaCungCap.Text = "";
            cbbNhaCungCap.SelectedValueChanged += cbbNhaCungCap_SelectedValueChanged;
        }
        //Load tên loại sản phẩm lên cbbLoaiSanPham
        private void LoadCBBLoaiSP()
        {
            cbbLoaiSanPham.SelectedValueChanged -= cbbLoaiSanPham_SelectedValueChanged;
            cbbLoaiSanPham.DataSource = XL.tblLoaiSanPham();
            cbbLoaiSanPham.DisplayMember = "TenLoai";
            cbbLoaiSanPham.ValueMember = "MaLoai";
            cbbLoaiSanPham.Text = "";
            cbbLoaiSanPham.SelectedValueChanged += cbbLoaiSanPham_SelectedValueChanged;
        }

        //Hiển thị tênn  và quyền nhân viên đăng nhập vào
        private void HienThiNhanVien()
        {
            lblTenNV.Text = "Xin chào: " + TKDangnhap.TenNhanVien;
            lblQuyen.Text = "Quyền: " + TKDangnhap.Quyen;
        }

        //hiển thị danh sách sản phẩm lên DataGridView
        private void HienThiDSSanPham()
        {
            XL.LayDSSanPham(dtgvDSSanPham);
        }
        //Hiển thị thông tin ngày giờ hiện thại
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "Ngày: " + DateTime.Now.ToString();
        }
        //Khi chọn Loại SP sẽ hiển thị danh sách sản phẩm thuộc Loại SP đó
        private void cbbLoaiSanPham_SelectedValueChanged(object sender, EventArgs e)
        {
            HienThiDSSanPham_TheoLoai();
        }
        //Hiển thị DS Sản Phẩm theo Loại Sản Phẩm
        private void HienThiDSSanPham_TheoLoai()
        {
            XL.LayDSSanPhamTheoLoai(dtgvDSSanPham,cbbLoaiSanPham.SelectedValue.ToString());
        }
        //Khi chọn nhà cung cấp sẽ hiển thị danh sách sản phẩm thuộc NCC đó
        private void cbbNhaCungCap_SelectedValueChanged(object sender, EventArgs e)
        {
            HienThiDSSanPham_TheoNCC();
        }
        //Hiển thị DS Sản Phẩm theo Nhà CUng Cấp
        private void HienThiDSSanPham_TheoNCC()
        {
            XL.LayDSSanPhamTheoNCC(dtgvDSSanPham,cbbNhaCungCap.SelectedValue.ToString());
        }
        //Tìm kiếm Sản Phẩm Theo MaSP và TenSP
        private void txtTimMaSP_TextChanged(object sender, EventArgs e)
        {
            if (XL.KTRong(txtTimMaSP.Text.Trim()))
            {
                txtTimTenSP.Enabled = true;
                btnTimKiem.Enabled = false;
            }
            else
            {
                txtTimTenSP.Enabled = false;
                btnTimKiem.Enabled = true;
            }
        }
        //Tìm kiếm Sản Phẩm Theo MaSP và TenSP
        private void txtTimTenSP_TextChanged(object sender, EventArgs e)
        {
            if (XL.KTRong(txtTimTenSP.Text.Trim()))
            {
                txtTimMaSP.Enabled = true;
                btnTimKiem.Enabled = false;
            }
            else
            {
                txtTimMaSP.Enabled = false;
                btnTimKiem.Enabled = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (XL.KTRong(txtTimMaSP.Text))
            {
                //tìm sản phẩm theo mã
                HienThiSanPhamTheoTen(txtTimTenSP.Text.Trim());
            }
            else
            {
                //Tìm sản phẩm theo tên
                HienThiSanPhamTheoMa(txtTimMaSP.Text.Trim());
            }
        }
        //Hiển thị thông tin sản phâm theo mã 
        private void HienThiSanPhamTheoMa(string MaSP)
        {
            XL.LaySanPhamTheoMaSP(dtgvDSSanPham,MaSP);
        }
        //Hiển thị thông tin sản phâm theo tên
        private void HienThiSanPhamTheoTen(string TenSP)
        {
            XL.LaySanPhamTheoTenSP(dtgvDSSanPham,TenSP);
        }
        //Reload lại DS Sản phẩm
        private void btnLoadDSSanPham_Click(object sender, EventArgs e)
        {
            HienThiDSSanPham();
            ClearThongTin();
            
        }
        private void ClearThongTin()
        {
            cbbLoaiSanPham.Text = "";
            cbbNhaCungCap.Text = "";
            txtTimMaSP.Clear();txtTimTenSP.Clear();

        }
        //Sự kiện click chọn sản phẩm từ DS Sản phẩm
        private void dtgvDSSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgvDSSanPham.CurrentCell.Value.ToString() == "Chọn")
            {
                XL.ThêmSPVaoLittView(listCTHD, dtgvDSSanPham.CurrentRow); //Thêm sản phẩm vào Hóa Đơn
                txtTongTien.Text = XL.CapNhatTongTien(listCTHD).ToString(); //Cập nhật tổng tiền hóa đơn
                HienThiDSSanPham();
            }
            else if (dtgvDSSanPham.CurrentCell.Value.ToString() == "Hủy")
            {
                XL.XoaSPListView(listCTHD, dtgvDSSanPham.CurrentRow); //Xóa sản phẩm ra khỏi hóa đơn
                txtTongTien.Text = XL.CapNhatTongTien(listCTHD).ToString();
                HienThiDSSanPham();
            }
        }
        //Thanh Toán hóa đơn
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            //Kiểm thông tin trước khi thanh toán
            if (XL.KTHoaDon(listCTHD) & !XL.KTRong(txtTenKH.Text) & !XL.KTRong(txtSDTKH.Text) & !XL.KTRong(cbbGiamGia.Text))
            {
                HoaDon hd = new HoaDon(TKDangnhap.Manv, txtTenKH.Text, txtSDTKH.Text, DateTime.Now, int.Parse(txtTongTien.Text), int.Parse(cbbGiamGia.Text.Split('%')[0]));
                fThanhToan tt = new fThanhToan();
                tt.TenNVLap = TKDangnhap.TenNhanVien;
                tt.CTHD = listCTHD;
                tt.HoaDon = hd;
                tt.XL = XL;
                tt.ShowDialog();
                listCTHD.Items.Clear();
                ClearThongTin();
            }
            else
            {
                //MessageBox.Show("Kiểm tra lại thông tin trước khi thanh toán!");
                TB.MessageThongBao = "Kiểm tra lại thông tin trước khi thanh toán!";
                TB.ShowDialog();
            }
        }
        //Tìm kiếm thông tin hóa đơn 
        private void btnTKDonHang_Click(object sender, EventArgs e)
        {
            fTimKiemHoaDon tkhd = new fTimKiemHoaDon();
            tkhd.ShowDialog();
        }
        // xem thông tin đang đứng ca
        private void btnTTNhanVien_Click(object sender, EventArgs e)
        {
            fThongTinNhanVien ttnv = new fThongTinNhanVien();
            ttnv.XL = XL;
            ttnv.TKDangNhap = TKDangnhap;
            ttnv.NhanVien = XL.LayThongTinNhanVien(TKDangnhap.Manv);
            ttnv.ShowDialog();
        }
        //Thêm sản phẩm mới
        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            fThemSanPham tsp = new fThemSanPham();
            tsp.XL = XL;    
            tsp.ShowDialog();
            HienThiDSSanPham();
        }
        //Thêm loại sản phẩm mới
        private void btnThemLoaiSP_Click(object sender, EventArgs e)
        {
            fThemLoaiSanPham tlsp = new fThemLoaiSanPham();
            tlsp.XL = XL;
            tlsp.ShowDialog();
            LoadCBBLoaiSP();
        }
        //Thêm nhà cung cấp mới
        private void btnThemNhaCungCap_Click(object sender, EventArgs e)
        {
            fThemNhaCungCap tncc = new fThemNhaCungCap();
            tncc.XL = XL;
            tncc.ShowDialog();
            LoaCBBNhaCungCap();
        }
        //Quay lại đăng nhập
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            fThongBaoYesNo TBYN = new fThongBaoYesNo();
            TBYN.Message_ThongBao = "Bạn có muốn đăng nhập lại?";
            TBYN.ShowDialog();
            if (TBYN.Check == "Có") {
                fDangNhap dn = new fDangNhap();
                dn.XL = XL;
                this.Hide();
                dn.ShowDialog();
                this.Close();
            }
        }
        //Thoát khỏi chương trình
        private void btnThoat_Click(object sender, EventArgs e)
        {
            fThongBaoYesNo TBYN = new fThongBaoYesNo();
            TBYN.Message_ThongBao = "Bạn muốn thoát chương trình?";
            TBYN.ShowDialog();
            if (TBYN.Check == "Có")
            {
                this.Close();
                Application.Exit();
            }
        }
        //Quản lý nhân viên (xem,thêm,xóa,sửa)
        private void btnQLNhanVien_Click(object sender, EventArgs e)
        {
            fQLNhanVien qlnv = new fQLNhanVien();
            qlnv.XL = XL;
            qlnv.ShowDialog();
        }
        //Quản lý tài khoản nhân viên
        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            fQLTaiKhoan qltk = new fQLTaiKhoan();
            qltk.XL = XL;
            qltk.ShowDialog();
        }
        //chọn sản phẩm vào phiếu nhập
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            fNhapHang nh = new fNhapHang();
            nh.XL= XL;
            nh.MaNV = TKDangnhap.Manv;
            nh.ShowDialog();
        }
        //Báo cáo doanh thu ngày,tháng,năm
        private void btnQLDoanhThu_Click(object sender, EventArgs e)
        {
            fBaoCao bc = new fBaoCao();
            bc.XL = XL;
            bc.ShowDialog();
        }
    }
}
