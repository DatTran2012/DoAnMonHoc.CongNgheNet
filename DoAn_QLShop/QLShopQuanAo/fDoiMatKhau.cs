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
    partial class fDoiMatKhau : Form
    {
        public XuLy XL { get; set; }
        public int MaNV { get; set; }
        fThongBao tb = new fThongBao();
        public fDoiMatKhau()
        {
            InitializeComponent();
        }
        
        private void fDoiMatKhau_Load(object sender, EventArgs e)
        {
            //Load ds tài khoản của nhân viên lên cbbTaiKhoan
            XL.LayDSTenTaiKhoan(MaNV, cbbTaiKhoan);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(XL.KTRong(cbbTaiKhoan.Text) || XL.KTRong(txtMatKhauCu.Text) || XL.KTRong(txtMatKhauMoi.Text))
            {
                tb.MessageThongBao = "Vui lòng nhập đủ thông tin!";
                tb.ShowDialog();
            }
            else
            {
                if (XL.DoiMatKhauTaiKhoan(cbbTaiKhoan.Text, txtMatKhauCu.Text, txtMatKhauMoi.Text)){
                    tb.MessageThongBao = "Đổi mật khẩu thành công!";
                }
                else
                {
                    tb.MessageThongBao = "Lỗi!";
                }
                tb.ShowDialog();
                cbbTaiKhoan.Text = txtMatKhauMoi.Text = txtMatKhauCu.Text = "";
            }
        }
    }
}
