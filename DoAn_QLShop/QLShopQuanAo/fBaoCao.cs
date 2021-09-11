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
    partial class fBaoCao : Form
    {
        public XuLy XL { get; set; }
        public fBaoCao()
        {
            InitializeComponent();
        }

        private void fBaoCao_Load(object sender, EventArgs e)
        {
            HienThiDSHoaDon();

        }
        //Hiển thị ds hóa đơn bán hàng
        private void HienThiDSHoaDon()
        {
            XL.LayDSHoaDon(dtgvDSHoaDon);
        }
        //Xem doanh thu theo ngày
        private void btnXemDT_Click(object sender, EventArgs e)
        {
            XL.LayDSHoaDon_TheoNgay(dtgvDSHoaDon, dtpNgayBan.Value.ToShortDateString(),txtSoHD,txtDoanhThu);

        }
        //Xem doanh thu theo tháng
        private void cbbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbThang.Text == "")
                return;
            XL.LayDSHoaDon_TheoThang(dtgvDSHoaDon,int.Parse(cbbThang.Text), txtSoHD, txtDoanhThu);
        }
        //load lại ds hóa đơn bán hàng
        private void btnReloadDSHoaDon_Click(object sender, EventArgs e)
        {
            HienThiDSHoaDon();
            txtSoHD.Text = "0";
            txtDoanhThu.Text = "VNĐ";
        }
    }
}
