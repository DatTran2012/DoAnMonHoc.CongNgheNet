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
    partial class fDangNhap : Form
    {
        XLDangNhap DN = new XLDangNhap();
        TaiKhoan taikhoan = new TaiKhoan();
        public XuLy XL = new XuLy();
        fThongBao TB = new fThongBao();
        
        public fDangNhap()
        {
            InitializeComponent();
        }
        //Đăng nhập vào hệ thống
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTK.Text.Trim() =="" || txtMK.Text == "")
            {
                //MessageBox.Show("Vui lòng nhập đủ thông tin!");
                //return;
                TB.MessageThongBao = "Vui lòng nhập đủ thông tin!";
                TB.ShowDialog();
                return;
            }
            else
            {
                if (DN.KTTaiKhoan(txtTK.Text.Trim(), txtMK.Text.Trim()))
                {
                    if (DN.KTTrangThai(txtTK.Text.Trim(), txtMK.Text.Trim()))
                    {
                        //MessageBox.Show("Đăng nhập thành công!");
                        taikhoan = DN.LayTTTaiKhoan(txtTK.Text, txtMK.Text);
                        fHeThong ht = new fHeThong();
                        ht.XL = XL;
                        ht.TKDangnhap = taikhoan;
                        TB.MessageThongBao = "Đăng nhập thành công!";
                        TB.ShowDialog();
                        this.Hide();
                        ht.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        //MessageBox.Show("Tài khoản đang bị khóa!");
                        TB.MessageThongBao = "Tài khoản đang bị khóa!";
                        TB.ShowDialog();
                    }
                }
                else
                {
                    //MessageBox.Show("Thông tin tài khoản hoặc mật khẩu chưa chính xác!");
                    TB.MessageThongBao = "Thông tin tài khoản hoặc mật khẩu chưa chính xác!";
                    TB.ShowDialog();
                }
            }
        }

        private void fDangNhap_Load(object sender, EventArgs e)
        {
            txtTK.Focus();
        }

        private void ptbThoat_Click(object sender, EventArgs e)
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
    }
}
