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
     partial class fTimKiemHoaDon : Form
    {
        public string TenNVLap { get; set; }
        public HoaDon HoaDon { get; set; }
        public ListView CTHD { get; set; }
        XuLy XL = new XuLy();
        DataSet DS_ShopQuanAo = new DataSet();
        
        public fTimKiemHoaDon()
        {
            InitializeComponent();
        }

        //Tìm theo maHD
        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            if (txtMaHD.Text.Trim() != "")
            {
                btnTimKiem.Enabled = true;
                txtSDTKH.Enabled = false;
            }
            else
            {
                btnTimKiem.Enabled = false;
                txtSDTKH.Enabled = true;
            }
        }
        //Tìm theo SDTKH
        private void txtSDTKH_TextChanged(object sender, EventArgs e)
        {
            if (txtSDTKH.Text.Trim() != "")
            {
                btnTimKiem.Enabled = true;
                txtMaHD.Enabled = false;
            }
            else
            {
                txtMaHD.Enabled = true;
                btnTimKiem.Enabled = false;
            }
        }
        //Tìm hóa đơn 
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //tìm kiếm theo SDTKH
            if (XL.KTRong(txtMaHD.Text))
            {
                XL.LayTTHoaDon_TheoSDT(dtgvHoaDon, txtSDTKH.Text);
            }
            else //tìm kiếm theo MaHD
            {
                XL.LayTTHoaDon_TheoMaHD(dtgvHoaDon, txtMaHD.Text);
            }
        }
        private void fTimKiemHoaDon_Load(object sender, EventArgs e)
        {
            HienThiDSHoaDon();
            btnTimKiem.Enabled = false;
            txtMaHD.Focus();
        }

        private void HienThiDSHoaDon()
        {
            XL.LayDSHoaDon(dtgvHoaDon);
        }

        private void dtpNgayLap_ValueChanged(object sender, EventArgs e)
        {
            XL.LayTTHoaDon_TheoNgay(dtgvHoaDon, dtpNgayLap.Value);
        }

        private void dtgvHoaDon_Click(object sender, EventArgs e)
        {
            int mahd = int.Parse(dtgvHoaDon.CurrentRow.Cells[0].Value.ToString());
            
            XL.HienThiCT_HoaDon(lvCTHD, mahd);
            lblSDTT.Text = HoaDon.SDTKH;
            lblNVNhapp.Text = TenNVLap;
            lblTenKHH.Text = HoaDon.TenKH;
        }
    }
}
