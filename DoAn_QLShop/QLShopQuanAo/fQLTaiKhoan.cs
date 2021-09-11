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
    partial class fQLTaiKhoan : Form
    {
        public XuLy XL { get; set; }
        fThongBao TB = new fThongBao();
        public fQLTaiKhoan()
        {
            InitializeComponent();
        }

        private void fQLTaiKhoan_Load(object sender, EventArgs e)
        {
            HienThiDSTaiKhoan();
        }
        //Hiển thị ds tài khoản trong tblTaiKhoan
        private void HienThiDSTaiKhoan()
        {
            XL.LayDSTaiKhoan(dtgvDSTK);
            cbbTenNV.DataSource = XL.tblNhanVien();
            cbbTenNV.DisplayMember = "HoTen";
            cbbTenNV.ValueMember = "MaNV";
        }
        //reload lại ds tài khoản
        private void btnLoadDSTK_Click(object sender, EventArgs e)
        {
            HienThiDSTaiKhoan();
        }
        //Hiển thị thông tin tài khoản khi click chọn
        private void dtgvDSTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            XL.HienThiThongTinTaiKhoan(dtgvDSTK.CurrentRow.Cells[1].Value.ToString(), cbbTenNV, txtTenDN, txtMK, cbbQuyen, cbbTrangThai);
        }
        //làm mới lại txtbox
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            txtTKNV.Clear();txtTenDN.Clear();txtMK.Clear();
            cbbQuyen.Text = cbbTrangThai.Text = "";
            txtTenDN.Focus();
        }
        //Tìm kiếm tài khoản theo mã nhân viên
        private void btnTKTK_Click(object sender, EventArgs e)
        {
            XL.LayDSTaiKhoanTheo_MaNV(dtgvDSTK,int.Parse(txtTKNV.Text));
        }
        //Thêm một tài khoản mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (XL.KTRong(txtTenDN.Text) || XL.KTRong(txtMK.Text) || XL.KTRong(cbbTenNV.Text) || XL.KTRong(cbbQuyen.Text) || XL.KTRong(cbbTrangThai.Text)) {
                //MessageBox.Show("Vui lòng điền đủ thông tin!");
                {
                    TB.MessageThongBao = "Vui lòng điền đủ thông tin!";
                    TB.ShowDialog();
                }
            }
            else
            {
                TaiKhoan tk = new TaiKhoan(txtTenDN.Text, txtMK.Text, (int)cbbTenNV.SelectedValue, cbbTenNV.Text, cbbQuyen.Text, cbbTrangThai.Text);
                if (XL.ThemTaiKhoan(tk))
                {
                    //MessageBox.Show("Thêm thành công!");
                    TB.MessageThongBao = "Thêm Thành Công!";
                    TB.ShowDialog();
                    HienThiDSTaiKhoan();
                    txtTKNV.Clear(); txtTenDN.Clear(); txtMK.Clear();
                    cbbQuyen.Text = cbbTrangThai.Text = "";
                    txtTenDN.Focus();
                }
                else /*MessageBox.Show("Lỗi!");*/
                {
                    TB.MessageThongBao = "Lỗi!";
                    TB.ShowDialog();
                }
            }
        }
        //Xóa một tài khoản
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtgvDSTK.CurrentRow == null)
            {
                //MessageBox.Show("Vui lòng chọn tài khoản cần xóa!");
                TB.MessageThongBao = "Vui lòng chọn Tài Khoản cần xóa!";
                TB.ShowDialog();
            }
            else {
                TaiKhoan tk = new TaiKhoan(txtTenDN.Text, txtMK.Text, (int)cbbTenNV.SelectedValue, cbbTenNV.Text, cbbQuyen.Text, cbbTrangThai.Text);
                if (XL.XoaTaiKhoan(tk))
                {
                    //MessageBox.Show("Xóa thành công!");
                    TB.MessageThongBao = "Xóa Tài Khoản thành công!";
                    TB.ShowDialog();
                    HienThiDSTaiKhoan();
                    txtTKNV.Clear(); txtTenDN.Clear(); txtMK.Clear();
                    cbbQuyen.Text = cbbTrangThai.Text = "";
                    txtTenDN.Focus();
                }
                else /*MessageBox.Show("Lỗi!");*/
                {
                    TB.MessageThongBao = "Lỗi!";
                    TB.ShowDialog();
                }
            }
        }
        //Cập nhật tài khoản
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (XL.KTRong(txtTenDN.Text) || XL.KTRong(txtMK.Text) || XL.KTRong(cbbTenNV.Text) || XL.KTRong(cbbQuyen.Text) || XL.KTRong(cbbTrangThai.Text))
            {
                //MessageBox.Show("Vui lòng điền đủ thông tin!");
                TB.MessageThongBao = "Vui lòng điền đủ thông tin!";
                TB.ShowDialog();
            }
            else
            {
                TaiKhoan tk = new TaiKhoan(txtTenDN.Text, txtMK.Text, (int)cbbTenNV.SelectedValue, cbbTenNV.Text, cbbQuyen.Text, cbbTrangThai.Text);
                if (XL.CapNhatTaiKhoan(tk))
                {
                    //MessageBox.Show("Cập nhật thành công!");
                    TB.MessageThongBao = "Cập nhật Tài Khoản thành công!";
                    TB.ShowDialog();
                    HienThiDSTaiKhoan();
                    txtTKNV.Clear(); txtTenDN.Clear(); txtMK.Clear();
                    cbbQuyen.Text = cbbTrangThai.Text = "";
                    txtTenDN.Focus();
                }
                else
                {
                    TB.MessageThongBao = "Lỗi!";
                    TB.ShowDialog();
                }
            }
        }
    }
}
