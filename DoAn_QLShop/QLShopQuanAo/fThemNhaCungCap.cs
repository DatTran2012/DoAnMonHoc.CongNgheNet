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
    partial class fThemNhaCungCap : Form
    {
        public XuLy XL { get; set; }
        fThongBao TB = new fThongBao();
        public fThemNhaCungCap()
        {
            InitializeComponent();
        }

        private void fThemNhaCungCap_Load(object sender, EventArgs e)
        {
            HienThiDSNhaCungCap();
        }
        //Hiển thị ds nhà cung cấp 
        private void HienThiDSNhaCungCap()
        {
            dtgvDSNCC.DataSource = XL.tblNhaCungCap();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (XL.KTRong(txtTenNCC.Text))
            {
                //MessageBox.Show("Vui lòng nhập tên Nhà Cung Cấp");
                TB.MessageThongBao = "Vui lòng nhập tên Nhà Cung Cấp";
                TB.ShowDialog();
            }
            else
            {
                if (XL.ThemNhaCungCap(txtTenNCC.Text))
                {
                    //MessageBox.Show("Thêm thành công!");
                    TB.MessageThongBao = "Thêm thành công!";
                    TB.ShowDialog();
                    txtTenNCC.Clear();
                    HienThiDSNhaCungCap();
                }
            }
        }
    }
}
