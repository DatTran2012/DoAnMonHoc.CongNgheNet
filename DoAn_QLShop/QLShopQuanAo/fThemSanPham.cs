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
     partial class fThemSanPham : Form
    {
        public XuLy XL { get; set; }
        fThongBao TB = new fThongBao();
        public fThemSanPham()
        {
            InitializeComponent();
        }
        //Lấy dữu liệu từ bảng Sản Phẩm, Loại Sản Phẩm và Nhà Cung Cấp đổ lên Data Set
        private void fThemSanPham_Load(object sender, EventArgs e)
        {
            
            HienThiDSSanPham();
            LoadCBBLoaiSP();
            LoadCBBNhaCungCap();
        }
        //Hiển thị danh sách sản phẩm trong kho
        private void HienThiDSSanPham()
        {
            XL.LayDSSanPham_ThemSP(dtgvSanPham);
        }
        //Load tên nhà cung cấp lên cbbNhaCungCap
        private void LoadCBBNhaCungCap()
        {
            cbbNhaCungCap.DataSource =XL.tblNhaCungCap();
            cbbNhaCungCap.DisplayMember = "TenNCC";
            cbbNhaCungCap.ValueMember = "MaNCC";
            cbbNhaCungCap.Text = "";
        }
        //Load tên loại sản phẩm lên cbbLoaiSanPham
        private void LoadCBBLoaiSP()
        {
            cbbLoaiSP.DataSource = XL.tblLoaiSanPham();
            cbbLoaiSP.DisplayMember = "TenLoai";
            cbbLoaiSP.ValueMember = "MaLoai";
            cbbLoaiSP.Text = "";

        }
        //Hiển thị thông tin sản phẩm lên TextBox,Combobox,PictureBoxm...
        private void dtgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtMaSP.Text = dtgvSanPham.CurrentRow.Cells[0].Value.ToString();
                XL.HienThiThongTinSanPham(int.Parse(txtMaSP.Text), txtTenSP, cbbLoaiSP, cbbNhaCungCap, cbbSize, txtSoLuong, txtDVT, txtGiaNhap, txtGiaBan, pcbHinhAnh, txtHinhAnh);
                btnXoaSP.Enabled = btnCapNhatSP.Enabled = true;
            }
            catch
            {
            }
        }
        //load hình ảnh lên pictureBox và txtxHinhAnh
        private void btnHinhAnh_Click(object sender, EventArgs e)
        {
            try
            {
                txtHinhAnh.Clear();
                openFileDialog1.ShowDialog();
                string[] path = openFileDialog1.FileNames;
                foreach (string item in path)
                {
                    txtHinhAnh.Text += item;
                }
                pcbHinhAnh.Image = Image.FromFile(txtHinhAnh.Text);
            }
            catch 
            {
            }

        }
        //Ràng buộc nhập số 
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        //Thêm Sản Phẩm mới
        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (XL.KTRong(txtTenSP.Text) || XL.KTRong(cbbLoaiSP.Text) || XL.KTRong(cbbNhaCungCap.Text) || XL.KTRong(cbbSize.Text) || XL.KTRong(txtSoLuong.Text) || XL.KTRong(txtDVT.Text) || XL.KTRong(txtGiaNhap.Text) || XL.KTRong(txtGiaBan.Text) || XL.KTRong(txtHinhAnh.Text))
            {
                //MessageBox.Show("Vui lòng nhập đủ thông tin cho Sản Phẩm!");
                TB.MessageThongBao = "Vui lòng nhập đủ thông tin cho Sản Phẩm!";
                TB.ShowDialog();
            }
            else
            {
                SanPham sp = new SanPham(int.Parse(txtMaSP.Text),txtTenSP.Text, XL.LayMaLoai( cbbLoaiSP.Text), XL.LayMaNCC(cbbNhaCungCap.Text), cbbSize.Text, int.Parse(txtSoLuong.Text), txtDVT.Text, int.Parse(txtGiaNhap.Text), int.Parse(txtGiaBan.Text), txtHinhAnh.Text);
                if (XL.ThemSanPham(sp))
                {
                    //MessageBox.Show("Thêm Thành Công!");
                    TB.MessageThongBao = "Thêm Sản Phẩm Thành Công!";
                    TB.ShowDialog();
                    ClearThongTin();
                    txtTenSP.Focus();
                    HienThiDSSanPham(); // cập nhật lại danh sách sản phẩm đang có trong DataSet
                    btnXoaSP.Enabled = btnCapNhatSP.Enabled = false;
                }
                else
                {
                    //MessageBox.Show("Thêm Thất Bại!");
                    TB.MessageThongBao = "Lỗi!";
                    TB.ShowDialog();
                }
            }
        }
        //Clear thông tin trên textbox,combobox
        private void ClearThongTin()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtSoLuong.Clear();
            txtDVT.Clear();
            txtGiaNhap.Clear();
            txtGiaNhap.Clear();
            txtHinhAnh.Clear();
            cbbLoaiSP.Text = cbbNhaCungCap.Text = cbbSize.Text = "";
            pcbHinhAnh.Image = null;
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (dtgvSanPham.CurrentRow == null & XL.KTRong(txtTenSP.Text) || XL.KTRong(cbbLoaiSP.Text) || XL.KTRong(cbbNhaCungCap.Text) || XL.KTRong(cbbSize.Text) || XL.KTRong(txtSoLuong.Text) || XL.KTRong(txtDVT.Text) || XL.KTRong(txtGiaNhap.Text) || XL.KTRong(txtGiaBan.Text) || XL.KTRong(txtHinhAnh.Text))
            {
                //MessageBox.Show("Vui lòng chọn Sản Phẩm muốn xóa!");
                TB.MessageThongBao = "Vui lòng chọn Sản Phẩm muốn xóa!";
                TB.ShowDialog();
            }
            else
            {
                if (XL.XoaSanPham(int.Parse(txtMaSP.Text)))
                {
                    //MessageBox.Show("Xóa thành công!");
                     TB.MessageThongBao = "Xóa Sản Phẩm thành công!";
                     TB.ShowDialog();
                     HienThiDSSanPham();
                     ClearThongTin();
                     btnXoaSP.Enabled = btnCapNhatSP.Enabled = false;
                }
            }
        }
        private void btnCapNhatSP_Click(object sender, EventArgs e)
        {
            if (dtgvSanPham.CurrentRow == null & XL.KTRong(txtTenSP.Text) || XL.KTRong(cbbLoaiSP.Text) || XL.KTRong(cbbNhaCungCap.Text) || XL.KTRong(cbbSize.Text) || XL.KTRong(txtSoLuong.Text) || XL.KTRong(txtDVT.Text) || XL.KTRong(txtGiaNhap.Text) || XL.KTRong(txtGiaBan.Text) || XL.KTRong(txtHinhAnh.Text))
            {
                //MessageBox.Show("Vui lòng chọn Sản Phẩm cập nhật!");
                TB.MessageThongBao = "Vui lòng chọn Sản Phẩm cập nhật!";
                TB.ShowDialog();
            }
            else
            {
                int maloai = (int)cbbLoaiSP.SelectedValue;
                int mancc = (int)cbbNhaCungCap.SelectedValue;
                SanPham sp = new SanPham(int.Parse(txtMaSP.Text), txtTenSP.Text,maloai, mancc, cbbSize.Text, int.Parse(txtSoLuong.Text), txtDVT.Text, double.Parse(txtGiaNhap.Text), double.Parse(txtGiaBan.Text), txtHinhAnh.Text);
                if (XL.CapNhatSanPham(sp))
                {
                    //MessageBox.Show("Cập nhật thành công!");
                    TB.MessageThongBao = "Cập nhật Sản Phẩm thành công!";
                    TB.ShowDialog();
                    HienThiDSSanPham();
                    ClearThongTin();
                    btnXoaSP.Enabled = btnCapNhatSP.Enabled = false;
                }
                else
                {
                    //MessageBox.Show("Lỗi!");
                    TB.MessageThongBao = "Lỗi!";
                    TB.ShowDialog();
                }
            }
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
            LoadCBBNhaCungCap();
        }
        //tạo mới để bắt đầu thêm sp mới
        private void btnTaoMoiSP_Click(object sender, EventArgs e)
        {
            ClearThongTin();
            txtMaSP.Text = XL.LayMaSanPhamMoi().ToString();
        }
    }
}
