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
    partial class fThongTinNhanVien : Form
    {
        public XuLy XL { get; set; }
        public NhanVien NhanVien { get; set; }
        public TaiKhoan TKDangNhap { get; set; }
        public fThongTinNhanVien()
        {
            InitializeComponent();
        }
        private void fThongTinNhanVien_Load(object sender, EventArgs e)
        {
            txtMaNV.Text = NhanVien.MaNV.ToString(); ;
            txtHoTen.Text = NhanVien.HoTenNV;
            txtGT.Text = NhanVien.GioiTinh;
            txtNgaySinh.Text = NhanVien.NgaySinh.ToShortDateString();
            txtNgayVaoLam.Text = NhanVien.NgayVaoLam.ToShortDateString();
            txtLuong.Text = NhanVien.Luong.ToString();
            txtTaiKhoan.Text = TKDangNhap.Tendangnhap;
            lblChucVu.Text = TKDangNhap.Quyen;
            txtSDT.Text = NhanVien.SDT;
            txtDiaChi.Text = NhanVien.DiaChi;
            pcbAvatarNV.Image = Image.FromFile(NhanVien.HinhAnh);
            
        }
        //Đổi mật khẩu cho tài khoản đang đăng nhập
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            fDoiMatKhau dmk = new fDoiMatKhau();
            dmk.MaNV = NhanVien.MaNV;
            dmk.XL = XL;
            dmk.ShowDialog();
        }
    }
}
