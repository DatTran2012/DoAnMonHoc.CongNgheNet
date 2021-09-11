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
    partial class fThemLoaiSanPham : Form
    {
        public XuLy XL { get; set; }
        fThongBao TB = new fThongBao();
        public fThemLoaiSanPham()
        {
            InitializeComponent();
        }
        //HIển thị danh sách bảng loại sản phẩm
        void HienThiDSLoaiSanPham() {
            dtgvDSLoaiSP.DataSource = XL.tblLoaiSanPham();
        }
        
        private void fThemLoaiSanPham_Load(object sender, EventArgs e)
        {
            HienThiDSLoaiSanPham();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (XL.KTRong(txtTenLoaiSP.Text)) {
                //MessageBox.Show("Vui lòng nhập tên loại");
                TB.MessageThongBao = "Vui lòng nhập tên loại";
                TB.ShowDialog();
            }
            else
            {
                if (XL.ThemLoaiSanPham(txtTenLoaiSP.Text))
                {
                    //MessageBox.Show("Thêm thành công!");
                    TB.MessageThongBao = "Thêm thành công!";
                    TB.ShowDialog();
                    txtTenLoaiSP.Clear();
                    HienThiDSLoaiSanPham();
                }
            }
        }
    }
}
