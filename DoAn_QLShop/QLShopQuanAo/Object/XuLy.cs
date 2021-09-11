using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLShopQuanAo.Object
{
    class XuLy
    {
        DataProvider pro = new DataProvider();
        DataSet DS_QLShopQuanAo = new DataSet();
        SqlDataAdapter DA_SanPham;
        DataColumn[] Key_SanPham = new DataColumn[1];
        SqlDataAdapter DA_TTSanPham;
        DataColumn[] Key_TTSanPham = new DataColumn[1];
        SqlDataAdapter DA_LoaiSanPham;
        DataColumn[] Key_LoaiSanPham = new DataColumn[1];
        SqlDataAdapter DA_NhaCungCap;
        DataColumn[] Key_NCC = new DataColumn[1];
        SqlDataAdapter DA_HoaDon;
        DataColumn[] Key_HoaDon = new DataColumn[1];
        SqlDataAdapter DA_CTHoaDon;
        SqlDataAdapter DA_NhanVien;
        DataColumn[] Key_NhanVien = new DataColumn[1];
        SqlDataAdapter DA_TTHoaDon;
        DataColumn[] Key_TTHoaDon = new DataColumn[1];
        SqlDataAdapter DA_TaiKhoan;
        DataColumn[] Key_TaiKhoan = new DataColumn[1];
        SqlDataAdapter DA_PhieuNhap;
        DataColumn[] Key_PhieuNhap = new DataColumn[1];
        SqlDataAdapter DA_CTPhieuNhap;
        fThongBao TB = new fThongBao();
        public XuLy()
        {
            try
            {
                DS_QLShopQuanAo = new DataSet();
                //Lấy dữ liệu từ bảng Sản phẩm đổ vào Data Set
                string jquery1 = "select * from SANPHAM";
                DA_SanPham = new SqlDataAdapter(jquery1, pro.Connect);
                DA_SanPham.Fill(DS_QLShopQuanAo, "SanPham");
                Key_SanPham[0] = DS_QLShopQuanAo.Tables["SanPham"].Columns["MaSP"];
                DS_QLShopQuanAo.Tables["SanPham"].PrimaryKey = Key_SanPham;

                //Lấy thông tin sản phẩm từ 3 bảng SanPham,LoạiSP,NhaCungCap
                string jquery2 = "LayThongTinSanPham";
                DA_TTSanPham = new SqlDataAdapter(jquery2, pro.Connect);
                DA_TTSanPham.Fill(DS_QLShopQuanAo, "TT_SanPham");
                Key_TTSanPham[0] = DS_QLShopQuanAo.Tables["TT_SanPham"].Columns["MaSP"];
                DS_QLShopQuanAo.Tables["TT_SanPham"].PrimaryKey = Key_TTSanPham;

                //LẤY dữ liêu bảng LoaiSanPham
                string jquery3 = "SELECT * FROM LOAISANPHAM";
                DA_LoaiSanPham = new SqlDataAdapter(jquery3, pro.Connect);
                DA_LoaiSanPham.Fill(DS_QLShopQuanAo, "LoaiSanPham");
                Key_LoaiSanPham[0] = DS_QLShopQuanAo.Tables["LoaiSanPham"].Columns["MaLoai"];
                DS_QLShopQuanAo.Tables["LoaiSanPham"].PrimaryKey = Key_LoaiSanPham;

                //LẤY dữ liêu bảng Nhà Cung Cấp
                string jquery4 = "SELECT * FROM NhaCungCap";
                DA_NhaCungCap = new SqlDataAdapter(jquery4, pro.Connect);
                DA_NhaCungCap.Fill(DS_QLShopQuanAo, "NhaCungCap");
                Key_NCC[0] = DS_QLShopQuanAo.Tables["NhaCungCap"].Columns["MaNCC"];
                DS_QLShopQuanAo.Tables["NhaCungCap"].PrimaryKey = Key_NCC;

                //LẤY dữ liêu bảng HoaDon
                string jquery5 = "SELECT * FROM HoaDon";
                DA_HoaDon = new SqlDataAdapter(jquery5, pro.Connect);
                DA_HoaDon.Fill(DS_QLShopQuanAo, "HoaDon");
                Key_HoaDon[0] = DS_QLShopQuanAo.Tables["HoaDon"].Columns["MaHD"];
                DS_QLShopQuanAo.Tables["HoaDon"].PrimaryKey = Key_HoaDon;

                //LẤY dữ liêu bảng CT_HoaDon
                string jquery6 = "SELECT * FROM CT_HoaDon";
                DA_CTHoaDon = new SqlDataAdapter(jquery6, pro.Connect);
                DA_CTHoaDon.Fill(DS_QLShopQuanAo, "CT_HoaDon");

                //LẤY dữ liêu bảng NhanVien
                string jquery7 = "SELECT * FROM NhanVien";
                DA_NhanVien = new SqlDataAdapter(jquery7, pro.Connect);
                DA_NhanVien.Fill(DS_QLShopQuanAo, "NhanVien");
                Key_NhanVien[0] = DS_QLShopQuanAo.Tables["NhanVien"].Columns["MaNV"];
                DS_QLShopQuanAo.Tables["NhanVien"].PrimaryKey = Key_NhanVien;

                //Lấy dữ liệu từ 3 bảng SanPham,HoaDon,NhanVien
                string jquery8 = "LayTTHoaDon";
                DA_TTHoaDon = new SqlDataAdapter(jquery8, pro.Connect);
                DA_TTHoaDon.Fill(DS_QLShopQuanAo, "TT_HoaDon");

                //LẤY dữ liêu bảng NhanVien
                string jquery9 = "SELECT * FROM TaiKhoan";
                DA_TaiKhoan = new SqlDataAdapter(jquery9, pro.Connect);
                DA_TaiKhoan.Fill(DS_QLShopQuanAo, "TaiKhoan");
                Key_TaiKhoan[0] = DS_QLShopQuanAo.Tables["TaiKhoan"].Columns["TaiKhoan"];
                DS_QLShopQuanAo.Tables["TaiKhoan"].PrimaryKey = Key_TaiKhoan;

                //LẤY dữ liêu bảng Phiếu nhập
                string jquery10 = "SELECT * FROM PHIEUNHAP";
                DA_PhieuNhap = new SqlDataAdapter(jquery10, pro.Connect);
                DA_PhieuNhap.Fill(DS_QLShopQuanAo, "PhieuNhap");
                Key_PhieuNhap[0] = DS_QLShopQuanAo.Tables["PhieuNhap"].Columns["MaPN"];
                DS_QLShopQuanAo.Tables["PhieuNhap"].PrimaryKey = Key_PhieuNhap;

                //LẤY dữ liêu bảng Phiếu nhập
                string jquery11 = "SELECT * FROM CT_PHIEUNHAP";
                DA_CTPhieuNhap = new SqlDataAdapter(jquery11, pro.Connect);
                DA_CTPhieuNhap.Fill(DS_QLShopQuanAo, "CT_PhieuNhap");
            }
            catch
            {
                TB.MessageThongBao = "Lỗi kết nối với CSDL";
                TB.ShowDialog();
            }
        }
        public DataTable tblSanPham() {
            return DS_QLShopQuanAo.Tables["SanPham"];
        }
        public DataTable tblNhanVien()
        {
            return DS_QLShopQuanAo.Tables["NhanVien"];
        }
        public DataTable tblHoaDon()
        {
            return DS_QLShopQuanAo.Tables["HoaDon"];
        }
        public DataTable tblCT_HoaDon()
        {
            return DS_QLShopQuanAo.Tables["CT_HoaDon"];
        }
        public DataTable tblNhaCungCap() {
            return DS_QLShopQuanAo.Tables["NhaCungCap"];
        }
        public DataTable tblLoaiSanPham()
        {
            return DS_QLShopQuanAo.Tables["LoaiSanPham"];
        }
        public DataTable tblTT_HoaDon()
        {
            return DS_QLShopQuanAo.Tables["TT_HoaDon"];
        }
        public DataTable tblTaiKhoan()
        {
            return DS_QLShopQuanAo.Tables["TaiKhoan"];
        }
        public DataTable tblPhieuNhap()
        {
            return DS_QLShopQuanAo.Tables["PhieuNhap"];
        }
        //Kiểm tra dữ liệu rỗng
        public bool KTRong(string data)
        {
            if (data == string.Empty)
                return true;
            return false;
        }
        //Hiển thị thông tin bảng sản phẩm lên fHeThong
        public void LayDSSanPham(DataGridView DS_SanPham) {
            try
            {
                DS_SanPham.Rows.Clear();
                Image img = null;
                foreach (DataRow row in DS_QLShopQuanAo.Tables["SanPham"].Rows)
                {
                    if(int.Parse(row["SoLuong"].ToString()) > 0)
                    {
                        try
                        {
                            img = Image.FromFile(row["HinhAnh"].ToString());
                        }
                        catch
                        {
                            img = Image.FromFile(@"E:\Cong_Nghe_NET\DoAn_QLShop\HinhAnh\logoShop.jpg");
                        }
                        DS_SanPham.Rows.Add(row["MaSP"].ToString(), row["TenSP"].ToString(), row["Size"].ToString(), row["SoLuong"].ToString(),Double.Parse(row["GiaBan"].ToString()), img, "Chọn", "Hủy");
                    }    
                }
            }
            catch
            {
            }
        }
        //Hiển thị thông tin bảng sản phẩm lên fThemSanPham
        public void LayDSSanPham_ThemSP(DataGridView DS_SanPham)
        {
            try
            {
                DS_SanPham.Rows.Clear();
                Image img = null;
                foreach (DataRow row in DS_QLShopQuanAo.Tables["SanPham"].Rows)
                {
                    try
                    {
                        img = Image.FromFile(row["HinhAnh"].ToString());
                    }
                    catch
                    {
                        img = Image.FromFile(@"D:\TranTanLoc\HK5\.NET\DoAnShopQuanAo\HinhAnh\imgShop.jpg");
                    }
                    DS_SanPham.Rows.Add(row["MaSP"].ToString(), row["TenSP"].ToString(), row["Size"].ToString(), row["SoLuong"].ToString(), row["DonViTinh"].ToString(), double.Parse(row["GiaNhap"].ToString()), double.Parse(row["GiaBan"].ToString()), img);
                }
            }
            catch
            {
            }

        }
        //Hiển thị thông tin sản phẩm theo loại
        public void LayDSSanPhamTheoLoai(DataGridView DS_SanPham, string _maloai)
        {
            DS_SanPham.Rows.Clear();
            Image img = null;
            try
            {
                foreach (DataRow row in DS_QLShopQuanAo.Tables["SanPham"].Rows)
                {
                    if (row["MaLoai"].ToString() == _maloai)
                    {
                        try
                        {
                            img = Image.FromFile(row["HinhAnh"].ToString());
                        }
                        catch
                        {
                            img = Image.FromFile(@"D:\TranTanLoc\HK5\.NET\DoAnShopQuanAo\HinhAnh\imgShop.jpg");
                        }
                        DS_SanPham.Rows.Add(row["MaSP"].ToString(), row["TenSP"].ToString(), row["Size"].ToString(), row["SoLuong"].ToString(), row["GiaBan"].ToString(), img, "Chọn", "Hủy");
                    }
                }
            }
            catch
            {
            }
        }
        //Hiển thị thông tin sản phẩm theo tên ncc
        public void LayDSSanPhamTheoNCC(DataGridView DS_SanPham, string _mancc)
        {
            DS_SanPham.Rows.Clear();
            Image img = null;
            try
            {
                foreach (DataRow row in DS_QLShopQuanAo.Tables["SanPham"].Rows)
                {
                    if (row["MaNCC"].ToString() == _mancc)
                    {
                        try
                        {
                            img = Image.FromFile(row["HinhAnh"].ToString());
                        }
                        catch
                        {
                            img = Image.FromFile(@"D:\TranTanLoc\HK5\.NET\DoAnShopQuanAo\HinhAnh\imgShop.jpg");
                        }
                        DS_SanPham.Rows.Add(row["MaSP"].ToString(), row["TenSP"].ToString(), row["Size"].ToString(), row["SoLuong"].ToString(), row["GiaBan"].ToString(), img, "Chọn", "Hủy");
                    }
                }
            }
            catch
            {
            }
        }
        //Hiển thị thông tin sản phẩm theo tên sản phẩm
        public void LaySanPhamTheoTenSP(DataGridView DS_SanPham, string _tensp)
        {
            DS_SanPham.Rows.Clear();
            Image img = null;
            try
            {
                foreach (DataRow row in  DS_QLShopQuanAo.Tables["SanPham"].Rows)
                {
                    if (row["TenSP"].ToString() == _tensp)
                    {
                        try
                        {
                            img = Image.FromFile(row["HinhAnh"].ToString());
                        }
                        catch
                        {
                            img = Image.FromFile(@"D:\TranTanLoc\HK5\.NET\DoAnShopQuanAo\HinhAnh\imgShop.jpg");
                        }
                        DS_SanPham.Rows.Add(row["MaSP"].ToString(), row["TenSP"].ToString(), row["Size"].ToString(), row["SoLuong"].ToString(), row["GiaBan"].ToString(), img, "Chọn", "Hủy");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Tên Sản Phẩm Không Tồn Tại!");
            }
        }
        //Hiển thị thông tin sản phẩm dựa vào mã sản phẩm
        public void LaySanPhamTheoMaSP(DataGridView DS_SanPham, string _masp)
        {
            try
            {
                DataRow row = DS_QLShopQuanAo.Tables["SanPham"].Rows.Find(_masp);
                if (row == null) {
                    //MessageBox.Show("Mã Sản Phẩm Không Tồn Tại!");
                    //return;
                    TB.MessageThongBao = "Mã Sản Phẩm không tồn tại";
                    TB.ShowDialog();
                    return;
                }
                DS_SanPham.Rows.Clear();
                Image img = null;
                try
                {
                    img = Image.FromFile(row["HinhAnh"].ToString());
                }
                catch
                {
                    img = Image.FromFile(@"D:\TranTanLoc\HK5\.NET\DoAnShopQuanAo\HinhAnh\imgShop.jpg");
                }
                DS_SanPham.Rows.Add(row["MaSP"].ToString(), row["TenSP"].ToString(), row["Size"].ToString(), row["SoLuong"].ToString(), row["GiaBan"].ToString(), img, "Chọn", "Hủy");
            }
            catch
            {
                //MessageBox.Show("Mã Sản Phẩm Không Tồn Tại!");
                TB.MessageThongBao = "Mã Sản Phẩm không tồn tại";
                TB.ShowDialog();
            }
        }
        //Thêm sản phẩm vào listview
        public void ThêmSPVaoLittView(ListView hoadon, DataGridViewRow row)
        {
            ListViewItem masp = new ListViewItem() { Text = row.Cells[0].Value.ToString() };
            if (KTMaSanPham_ListView(hoadon, masp.Text))
            {
                TangSoLuong(hoadon, masp.Text);
                GiamSoLuongSP_DS(int.Parse(masp.Text));
                return;
            }
            ListViewItem.ListViewSubItem tensp = new ListViewItem.ListViewSubItem() { Text = row.Cells[1].Value.ToString() };
            ListViewItem.ListViewSubItem size = new ListViewItem.ListViewSubItem() { Text = row.Cells[2].Value.ToString() };
            ListViewItem.ListViewSubItem sl = new ListViewItem.ListViewSubItem() { Text = "1" };
            ListViewItem.ListViewSubItem dongia = new ListViewItem.ListViewSubItem() { Text = row.Cells[4].Value.ToString() };
            masp.SubItems.Add(tensp);
            masp.SubItems.Add(size);
            masp.SubItems.Add(sl);
            masp.SubItems.Add(dongia);
            hoadon.Items.Add(masp);
            GiamSoLuongSP_DS(int.Parse(masp.Text));
        }
        //Giảm số lượng sản phẩm trong DataSet
        private void GiamSoLuongSP_DS(int masp) {
            DS_QLShopQuanAo.Tables["SanPham"].Rows.Find(masp)["SoLuong"] = int.Parse(DS_QLShopQuanAo.Tables["SanPham"].Rows.Find(masp)["SoLuong"].ToString()) - 1;
            if (int.Parse(DS_QLShopQuanAo.Tables["SanPham"].Rows.Find(masp)["SoLuong"].ToString()) == 0)
            {
                DataRow row = DS_QLShopQuanAo.Tables["SanPham"].Rows.Find(masp);
                DS_QLShopQuanAo.Tables["SanPham"].Rows.Remove(row);
            }
        }
        //Tăng số lượng sản phẩm trong DataSet
        private void TangSoLuongSP_DS(int masp)
        {
            DS_QLShopQuanAo.Tables["SanPham"].Rows.Find(masp)["SoLuong"] = int.Parse(DS_QLShopQuanAo.Tables["SanPham"].Rows.Find(masp)["SoLuong"].ToString()) + 1;
        }
        //Xóa sản phẩm khỏi listview 
        public void XoaSPListView(ListView hoadon, DataGridViewRow row)
        {
            string masp = row.Cells[0].Value.ToString();
            if (KTMaSanPham_ListView(hoadon, masp))
            {
                GiamSoLuong(hoadon, masp);
                TangSoLuongSP_DS(int.Parse(masp));
            }
            else
            {
                //MessageBox.Show("Bạn chưa chọn sản phẩm này!");
                TB.MessageThongBao = "Bạn chưa chọn sản phẩm này!";
                TB.ShowDialog();
            }
        }
        //Kiểm tra sản phẩm trong listView hóa đơn
        public bool KTMaSanPham_ListView(ListView hoadon, string _masp)
        {
            foreach (ListViewItem item in hoadon.Items)
            {
                if (item.Text == _masp)
                {
                    return true;
                }
            }
            return false;
        }
        //Giảm số lượng sản phẩm trong listview hóa đơn
        public void GiamSoLuong(ListView hoadon, string _masp)
        {
            foreach (ListViewItem item in hoadon.Items)
            {
                if (item.Text == _masp)
                {
                    if (item.SubItems[3].Text == "1")
                    {
                        hoadon.Items.Remove(item);
                        return;
                    }
                    item.SubItems[3].Text = (int.Parse(item.SubItems[3].Text) - 1).ToString();
                    return;
                }
            }
        }
        //Tăng số lượng sản phẩm trong listView Hóa đơn
        public void TangSoLuong(ListView hoadon, string _masp)
        {
            foreach (ListViewItem item in hoadon.Items)
            {
                if (item.Text == _masp)
                {
                    item.SubItems[3].Text = (int.Parse(item.SubItems[3].Text) + 1).ToString();
                    return;
                }
            }
        }
        //Kiểm Tra hóa đơn trước khi thanh toán
        public bool KTHoaDon(ListView hoadon)
        {
            if (hoadon.Items.Count > 0)
            {
                return true;
            }
            return false;
        }
        //Cập nhật tổng tiền trong listView hóa đơn
        public double CapNhatTongTien(ListView hoadon)
        {
            double tongtien = 0;
            foreach (ListViewItem item in hoadon.Items)
            {
                tongtien += double.Parse(item.SubItems[3].Text) * double.Parse(item.SubItems[4].Text);
            }
            return tongtien;
        }
        //Chép dữ liệu CT Hóa đơn từ from hệ thống sang from Thanh Toán
        public void LayCTHoaDon(ListView HT_HeThong, ListView HD_ThanHToan)
        {
            foreach (ListViewItem item in HT_HeThong.Items)
            {
                ListViewItem masp = new ListViewItem() { Text = item.Text };
                ListViewItem.ListViewSubItem tensp = new ListViewItem.ListViewSubItem() { Text = item.SubItems[1].Text };
                ListViewItem.ListViewSubItem size = new ListViewItem.ListViewSubItem() { Text = item.SubItems[2].Text };
                ListViewItem.ListViewSubItem sl = new ListViewItem.ListViewSubItem() { Text = item.SubItems[3].Text };
                ListViewItem.ListViewSubItem dongia = new ListViewItem.ListViewSubItem() { Text = item.SubItems[4].Text };
                ListViewItem.ListViewSubItem thanhtien = new ListViewItem.ListViewSubItem() { Text = (double.Parse(sl.Text) * double.Parse(dongia.Text)).ToString() };
                masp.SubItems.Add(tensp);
                masp.SubItems.Add(size);
                masp.SubItems.Add(sl);
                masp.SubItems.Add(dongia);
                masp.SubItems.Add(thanhtien);
                HD_ThanHToan.Items.Add(masp);
            }
        }
        //Tự động cập nhật số tiền trả khách
        public string CapNhatSoTienTraKhach(int stThanHToan, int stKhachDua)
        {
            if (stKhachDua >= stThanHToan)
                return (stKhachDua - stThanHToan).ToString();
            return "";
        }
        //Tạo hóa đơn có MANV,TeNKH,SDTKH,NgayLap,TongTien,GiamGia
        public bool TaoHoaDon(int _manv, string _tenkh, string _sdtkh,int _tongtien, int _giamgia,double thanhtoan, ListView listViewCTHD)
        {
            try
            {
                DataRow rowInsser_HD = DS_QLShopQuanAo.Tables["HoaDon"].NewRow(); //thêm hóa đơn vào data set
                rowInsser_HD["MaHD"] = LayMaHoaDonMoi();
                rowInsser_HD["MaNV"] = _manv;
                rowInsser_HD["TenKH"] = _tenkh;
                rowInsser_HD["SDT"] = _sdtkh;
                rowInsser_HD["NgayLap"] = DateTime.Now.ToShortDateString();
                rowInsser_HD["TongTien"] = _tongtien;
                rowInsser_HD["GiamGia"] = _giamgia;
                rowInsser_HD["ThanhToan"] = thanhtoan;
                DS_QLShopQuanAo.Tables["HoaDon"].Rows.Add(rowInsser_HD);
                foreach (ListViewItem item in listViewCTHD.Items)
                {
                    ThemCTHoaDon(int.Parse(rowInsser_HD["MaHD"].ToString()), int.Parse(item.SubItems[0].Text), int.Parse(item.SubItems[3].Text));

                }
                LuuThongTinHoaDon();
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Lấy mã hóa đơn vừa tạo
        public int LayMaHoaDonMoi()
        {
            int masp = 1;
            try
            {
                masp = int.Parse(DS_QLShopQuanAo.Tables["HoaDon"].Rows[DS_QLShopQuanAo.Tables["HoaDon"].Rows.Count - 1]["MaHD"].ToString()) + 1; 
            }
            catch
            {
                return 1;
            }
            return masp;
        }
        //Thêm chi tiết hóa đơn vào CSDL
        public void ThemCTHoaDon(int mahd, int masp, int soluong)
        {
            try
            {
                if (mahd == -1)
                {
                    return;
                }
                DataRow rowInsert_CTHD = DS_QLShopQuanAo.Tables["CT_HoaDon"].NewRow();
                rowInsert_CTHD["MaHD"] = mahd;
                rowInsert_CTHD["MaSP"] = masp;
                rowInsert_CTHD["SoLuong"] = soluong;
                DS_QLShopQuanAo.Tables["CT_HoaDon"].Rows.Add(rowInsert_CTHD);
            }
            catch
            {
            }
        }
        //Sao lưu dữ liêu hóa đơn vào database
        private bool LuuThongTinHoaDon()
        {
            try
            {
                SqlCommandBuilder cmdb1 = new SqlCommandBuilder(DA_HoaDon);
                DA_HoaDon.Update(DS_QLShopQuanAo, "HoaDon");
                SqlCommandBuilder cmdb2 = new SqlCommandBuilder(DA_CTHoaDon);
                DA_CTHoaDon.Update(DS_QLShopQuanAo, "CT_HoaDon");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Lấy thông tin nhân viên từ mã nhân viên
        public NhanVien LayThongTinNhanVien(int _manv) {
            NhanVien nv = new NhanVien();
            DataRow row = DS_QLShopQuanAo.Tables["NhanVien"].Rows.Find(_manv);
            nv.MaNV = int.Parse(row["MaNV"].ToString());
            nv.HoTenNV = row["HoTen"].ToString();
            nv.GioiTinh = row["GioiTinh"].ToString();
            nv.NgaySinh = DateTime.Parse(row["NgaySinh"].ToString());
            nv.SDT = row["SDT"].ToString();
            nv.DiaChi = row["DiaChi"].ToString();
            nv.NgayVaoLam = DateTime.Parse(row["NgayVaoLam"].ToString());
            nv.Luong = double.Parse(row["Luong"].ToString());
            nv.HinhAnh = row["HinhAnh"].ToString();
            return nv;

        }
        //Lấy thông tin Sản phẩm từ DataGridViewRow hiển thị lên TextBox,ComboBox,PictureBox,...
        public void HienThiThongTinSanPham(int masp, TextBox TenSP, ComboBox Loai, ComboBox NCC, ComboBox Size, TextBox SoLuong, TextBox DVT, TextBox GiaNhap, TextBox GiaBan, PictureBox HinhAnh, TextBox Hinh)
        {
            DataRow row = DS_QLShopQuanAo.Tables["TT_SanPham"].Rows.Find(masp);
            TenSP.Text = row["TenSP"].ToString();
            Loai.Text = row["TenLoai"].ToString();
            NCC.Text = row["TenNCC"].ToString();
            Size.Text = row["Size"].ToString();
            SoLuong.Text = row["SoLuong"].ToString();
            DVT.Text = row["DonViTinh"].ToString();
            GiaNhap.Text = double.Parse(row["GiaNhap"].ToString()).ToString();
            GiaBan.Text = double.Parse(row["GiaBan"].ToString()).ToString();
            Hinh.Text = row["HinhAnh"].ToString();
            Image img;
            try
            {
                img = Image.FromFile(Hinh.Text);
            }
            catch
            {
                img = Image.FromFile(@"D:\TranTanLoc\HK5\.NET\DoAnShopQuanAo\HinhAnh\imgShop.jpg");
            }
            HinhAnh.Image = img;
        }
        public bool ThemSanPham(SanPham sp)
        {
            try
            {
                if (sp.MaSP == -1)
                    return false;
                //Thêm row mới vào bảng Sanpham trong data Set
                DataRow row = DS_QLShopQuanAo.Tables["SanPham"].NewRow();
                row["MaSP"] = sp.MaSP;
                row["TenSP"] = sp.TenSP;
                row["MaLoai"] = sp.MaLoai;
                row["MaNCC"] = sp.MaNCC;
                row["Size"] = sp.Size;
                row["SoLuong"] = sp.SoLuong;
                row["DonViTinh"] = sp.DVT;
                row["GiaNhap"] = sp.GiaNhap;
                row["GiaBan"] = sp.GiaBan;
                row["HinhAnh"] = sp.HinhAnh;
                DS_QLShopQuanAo.Tables["SanPham"].Rows.Add(row);
                LuuSanPham(); //cập nhật lại trong csdl

                //Thêm row mới vào bảng TT_SanPham trong Data Set
                DataRow rowTT = DS_QLShopQuanAo.Tables["TT_SanPham"].NewRow();
                rowTT["MaSP"] = sp.MaSP;
                rowTT["TenSP"] = sp.TenSP;
                rowTT["TenLoai"] = LayTenLoaiSP(sp.MaLoai);
                rowTT["TenNCC"] = LayTenNCC(sp.MaNCC);
                rowTT["Size"] = sp.Size;
                rowTT["SoLuong"] = sp.SoLuong;
                rowTT["DonViTinh"] = sp.DVT;
                rowTT["GiaNhap"] = sp.GiaNhap;
                rowTT["GiaBan"] = sp.GiaBan;
                rowTT["HinhAnh"] = sp.HinhAnh;
                DS_QLShopQuanAo.Tables["TT_SanPham"].Rows.Add(rowTT);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Lấy Mã Sản Phẩm Mới
        public int LayMaSanPhamMoi()
        {
            try
            {
                int masp = 1;
                masp = int.Parse(DS_QLShopQuanAo.Tables["SanPham"].Rows[DS_QLShopQuanAo.Tables["SanPham"].Rows.Count - 1]["MaSP"].ToString()) + 1;
                return masp;
            }
            catch
            {
                return -1;
            }
        }
        //Lưu thông tin sản phẩm 
        public bool LuuSanPham() {
            try
            {
                SqlCommandBuilder cmdb = new SqlCommandBuilder(DA_SanPham);
                DA_SanPham.Update(DS_QLShopQuanAo, "SanPham");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Xóa sản phẩm
        public bool XoaSanPham(int masp)
        {
            try
            {
                DataRow rowDelete = DS_QLShopQuanAo.Tables["SanPham"].Rows.Find(masp);
                if (rowDelete == null)
                    return false;
                    //if (MessageBox.Show("Bạn có muốn xóa Sản Phẩm không?", "Xóa Sản Phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    //{
                    //    rowDelete.Delete();
                    //    LuuSanPham();// cập nhật lại csdl
                    //    return true;
                    //}
                fThongBaoYesNo tbyn = new fThongBaoYesNo();
                tbyn.Message_ThongBao = "Bạn có muốn xóa Sản Phẩm không?";
                tbyn.ShowDialog();
                if (tbyn.Check == "Có") {
                    rowDelete.Delete();
                    LuuSanPham();// cập nhật lại trong csdl
                    return true;
                }
                return false;    
            }
            catch
            {
                return false;
            }
        }
        //Cập nhật thông tin sản phẩm 
        public bool CapNhatSanPham(SanPham sp)
        {
            try
            {
                DataRow rowUpdate = DS_QLShopQuanAo.Tables["SanPham"].Rows.Find(sp.MaSP);
                if (rowUpdate == null)
                    return false;
                rowUpdate["TenSP"] = sp.TenSP;
                rowUpdate["MaLoai"] = sp.MaLoai;
                rowUpdate["MaNCC"] = sp.MaNCC;
                rowUpdate["Size"] = sp.Size;
                rowUpdate["DonViTinh"] = sp.DVT;
                rowUpdate["GiaNhap"] = sp.GiaNhap;
                rowUpdate["GiaBan"] = sp.GiaBan;
                rowUpdate["HinhAnh"] = sp.HinhAnh;
                LuuSanPham();// cập nhật lại csdl

                DataRow row = DS_QLShopQuanAo.Tables["TT_SanPham"].Rows.Find(sp.MaSP);
                row["TenSP"] = sp.TenSP;
                row["TenLoai"] = LayTenLoaiSP(sp.MaLoai);
                row["TenNCC"] = LayTenNCC(sp.MaNCC);
                row["Size"] = sp.Size;
                row["DonViTinh"] = sp.DVT;
                row["GiaNhap"] = sp.GiaNhap;
                row["GiaBan"] = sp.GiaBan;
                row["HinhAnh"] = sp.HinhAnh;
                return true;
            }
            catch 
            {
                return false;
            }

        }
        //Lấy MaLoai Sản Phẩm từ Tên Loại
        public int LayMaLoai(string TenLoai)
        {
            try
            {
                foreach (DataRow row in DS_QLShopQuanAo.Tables["LoaiSanPham"].Rows)
                {
                    if (row["TenLoai"].ToString() == TenLoai)
                        return int.Parse(row["MaLoai"].ToString());
                }
                return -1;
            }
            catch 
            {
                return -1;
            }
        }
        //Lấy TenLoai Sản Phẩm từ MaLoai
        public string LayTenLoaiSP(int MaLoai)
        {
            try
            {
                foreach (DataRow row in DS_QLShopQuanAo.Tables["LoaiSanPham"].Rows)
                {
                    if (row["MaLoai"].ToString() == MaLoai.ToString())
                        return row["TenLoai"].ToString();
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
        //Lấy MaNCC của Sản Phẩm từ Tên NCC
        public int LayMaNCC(string TenNCC)
        {
            try
            {

                foreach (DataRow row in DS_QLShopQuanAo.Tables["NhaCungCap"].Rows)
                {
                    if (row["TenNCC"].ToString() == TenNCC)
                        return int.Parse(row["MaNCC"].ToString());
                }
                return -1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
        //Lấy TenNCC Sản Phẩm từ MaNCC
        public string LayTenNCC(int MaNCC)
        {
            try
            {
                foreach (DataRow row in DS_QLShopQuanAo.Tables["NhaCungCap"].Rows)
                {
                    if (row["MaNCC"].ToString() == MaNCC.ToString())
                        return row["TenNCC"].ToString();
                }
                return "";
            }
            catch
            {
                return "";
            }
        }
        //Thêm loại sản phẩm mới
        public bool ThemLoaiSanPham(string TenLoai)
        {
            try
            {
                DataRow row = DS_QLShopQuanAo.Tables["LoaiSanPham"].NewRow();
                row["MaLoai"] = LayMaLoaiSanPhamMoi();
                row["TenLoai"] = TenLoai;
                DS_QLShopQuanAo.Tables["LoaiSanPham"].Rows.Add(row);
                SqlCommandBuilder cmdb = new SqlCommandBuilder(DA_LoaiSanPham);
                DA_LoaiSanPham.Update(DS_QLShopQuanAo, "LoaiSanPham");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //lấy mã loại sản phẩm mới
        public int LayMaLoaiSanPhamMoi()
        {
            try
            {
                int masp = 1;
                masp = int.Parse(DS_QLShopQuanAo.Tables["LoaiSanPham"].Rows[DS_QLShopQuanAo.Tables["LoaiSanPham"].Rows.Count - 1]["MaLoai"].ToString()) + 1;
                return masp;
            }
            catch
            {
                return -1;
            }
        }
        //Thêm nhà cung cấp mới
        public bool ThemNhaCungCap(string TenNCC)
        {
            try
            {
                DataRow row = DS_QLShopQuanAo.Tables["NhaCungCap"].NewRow();
                row["MaNCC"] = LayMaNCCMoi();
                row["TenNCC"] = TenNCC;
                DS_QLShopQuanAo.Tables["NhaCungCap"].Rows.Add(row);
                SqlCommandBuilder cmdb = new SqlCommandBuilder(DA_NhaCungCap);
                DA_NhaCungCap.Update(DS_QLShopQuanAo, "NhaCungCap");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //lấy mã loại sản phẩm mới
        public int LayMaNCCMoi()
        {
            try
            {
                int masp = 1;
                masp = int.Parse(DS_QLShopQuanAo.Tables["NhaCungCap"].Rows[DS_QLShopQuanAo.Tables["NhaCungCap"].Rows.Count - 1]["MaNCC"].ToString()) + 1;
                return masp;
            }
            catch
            {
                return -1;
            }
        }
        //Lấy Mã nhân viên mới
        public int LayMaNhanVienMoi() {
            try
            {
                int manv = 1;
                manv = int.Parse(DS_QLShopQuanAo.Tables["NhanVien"].Rows[DS_QLShopQuanAo.Tables["NhanVien"].Rows.Count-1]["MaNV"].ToString()) + 1;
                return manv ;
            }
            catch 
            {
                return -1;
            }
        }
        //Lây danh sách nhân viên
        public void LayDSNhanVien(DataGridView dtgvDSNhanVien ) {
            try
            {
                dtgvDSNhanVien.Rows.Clear();
                Image img;
                foreach (DataRow row in DS_QLShopQuanAo.Tables["NhanVien"].Rows)
                {
                    try
                    {
                        img = Image.FromFile(row["HinhAnh"].ToString());
                    }
                    catch
                    {
                        img = Image.FromFile(@"E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\NhanVien.png");
                    }
                    dtgvDSNhanVien.Rows.Add(row["MaNV"].ToString(), row["HoTen"].ToString(), row["GioiTinh"].ToString(), row["SDT"].ToString(), row["DiaChi"].ToString(), double.Parse(row["Luong"].ToString()), img);
                }
            }
            catch
            {
            }
        }
        //Hiên thị thông tin nhân viên lên textbox
        public void HienThiThongTinNhanVien(int manv,TextBox MaNV,TextBox TenNV,RadioButton rdNam,RadioButton rdNu,DateTimePicker NgayLam,TextBox Luong,DateTimePicker NgaySinh,TextBox SDT,TextBox DiaChi,PictureBox pcbHinhAnh,TextBox txtHinhAnh)
        {
            DataRow row = DS_QLShopQuanAo.Tables["NhanVien"].Rows.Find(manv);
            if (row == null)
                return;
            MaNV.Text = row["MaNV"].ToString();
            TenNV.Text = row["HoTen"].ToString();
            if (row["GioiTinh"].ToString() == "Nam")
                    rdNam.Checked = true;
            else
            {
                rdNu.Checked = true;
            }
            NgayLam.Text = row["NgayVaoLam"].ToString();
            NgaySinh.Text = row["NgaySinh"].ToString();
            Luong.Text = double.Parse(row["Luong"].ToString()).ToString();
            DiaChi.Text = row["DiaChi"].ToString();
            SDT.Text = row["SDT"].ToString();
            txtHinhAnh.Text = row["HinhAnh"].ToString();
            try
            {
                pcbHinhAnh.Image = Image.FromFile(row["HinhAnh"].ToString());
            }
            catch
            {
                pcbHinhAnh.Image = Image.FromFile(@"E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\NhanVien.png");
            }
        }
        //Thêm nhân viên mới
        public bool ThemNhanVien (NhanVien nv)
        {
            try
            {
                DataRow row = DS_QLShopQuanAo.Tables["NhanVien"].NewRow();
                row["MaNV"] = LayMaNhanVienMoi();
                row["HoTen"] = nv.HoTenNV;
                row["GioiTinh"] = nv.GioiTinh;
                row["NgaySinh"] = nv.NgaySinh.ToShortDateString();
                row["SDT"] = nv.SDT;
                row["DiaChi"] = nv.DiaChi;
                row["NgayVaoLam"] = nv.NgayVaoLam.ToShortDateString();
                row["Luong"] = nv.Luong;
                row["HinhAnh"] = nv.HinhAnh;
                DS_QLShopQuanAo.Tables["NhanVien"].Rows.Add(row);
                SqlCommandBuilder cmdb = new SqlCommandBuilder(DA_NhanVien);
                DA_NhanVien.Update(DS_QLShopQuanAo, "NhanVien");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Xóa nhân viên 
        public bool XoaNhanVien(int manv)
        {
            try
            {
                //Gở bỏ tài khoản và các hóa đơn của nhân viên trước khi xóa
                XoaTaiKhoan_TheoMaNV(manv);
                //Xóa các hóa đơn của nhân viên này
                XoaHoaDon_TheoMaNV(manv);
                //Xóa nhân viên này
                DataRow row = DS_QLShopQuanAo.Tables["NhanVien"].Rows.Find(manv);
                if (row == null)
                    return false;
                row.Delete();
                SqlCommandBuilder cmdb = new SqlCommandBuilder(DA_NhanVien);
                DA_NhanVien.Update(DS_QLShopQuanAo, "NhanVien");
                
                return true;
            }
            catch {return false;}
        }
        //Cập nhật thông tin nhân viên
        public bool CapNhatThongTinNhanVien(NhanVien nv)
        {
            try
            {
                DataRow row = DS_QLShopQuanAo.Tables["NhanVien"].Rows.Find(nv.MaNV);
                row["HoTen"] = nv.HoTenNV;
                row["GioiTinh"] = nv.GioiTinh;
                row["NgaySinh"] = nv.NgaySinh.ToShortDateString();
                row["SDT"] = nv.SDT;
                row["DiaChi"] = nv.DiaChi;
                row["NgayVaoLam"] = nv.NgayVaoLam.ToShortDateString();
                row["Luong"] = nv.Luong;
                row["HinhAnh"] = nv.HinhAnh;
                SqlCommandBuilder cmdb = new SqlCommandBuilder(DA_NhanVien);
                DA_NhanVien.Update(DS_QLShopQuanAo, "NhanVien");
                return true;
            }
            catch
            {
                return false;
            }
        }
        //Lấy thông tin nhân viên từ manv
        public void LayNhanVienTheoMa(DataGridView dtgvDSNV, int manv) {
            try
            {
                DataRow row = DS_QLShopQuanAo.Tables["NhanVien"].Rows.Find(manv);
                if (row == null)
                {
                    //MessageBox.Show("Mã nhân viên không tồn tại!");
                    TB.MessageThongBao = "Mã nhân viên không tồn tại!";
                    TB.ShowDialog();
                    return;
                }
                dtgvDSNV.Rows.Clear();
                Image img;
                try
                {
                    img = Image.FromFile(row["HinhAnh"].ToString());
                }
                catch
                {
                    img = Image.FromFile(@"E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\NhanVien.png");
                }
                dtgvDSNV.Rows.Add(row["MaNV"].ToString(), row["HoTen"].ToString(), row["GioiTinh"].ToString(), row["SDT"].ToString(), row["DiaChi"].ToString(), double.Parse(row["Luong"].ToString()), img);
            }
            catch
            {
            }
        }
        //Hiển thị ds tài khoản trong tblTaiKhoan
        public void LayDSTaiKhoan(DataGridView dtgvDSTK) {
            dtgvDSTK.Rows.Clear();
            foreach (DataRow row in DS_QLShopQuanAo.Tables["TaiKhoan"].Rows)
            {
                dtgvDSTK.Rows.Add(row["MaNV"].ToString(), row["TaiKhoan"].ToString(), row["MatKhau"].ToString(), row["CapQuyen"].ToString(), row["TrangThai"].ToString());
            }
        }
        //hiển thị thông tin tài khoản lên textbox
        public void HienThiThongTinTaiKhoan(string tendn,ComboBox MaNV,TextBox TenDN,TextBox MatKhau,ComboBox Quyen,ComboBox TrangThai) {
            try
            {
                DataRow row = DS_QLShopQuanAo.Tables["TaiKhoan"].Rows.Find(tendn);
                DataRow row_nv = DS_QLShopQuanAo.Tables["NhanVien"].Rows.Find(row["MaNV"].ToString());
                if (row == null)
                    return;
                MaNV.Text = row_nv["HoTen"].ToString();
                TenDN.Text = row["TaiKhoan"].ToString();
                MatKhau.Text = row["MatKhau"].ToString();
                Quyen.Text = row["CapQuyen"].ToString();
                TrangThai.Text = row["TrangThai"].ToString();
            }
            catch
            {
            }
        }
        //Tim tài khoản thoe mã nhân viên
        public void LayDSTaiKhoanTheo_MaNV(DataGridView dtgvDSTK, int manv) {
            try
            {
                dtgvDSTK.Rows.Clear();
                foreach (DataRow row in DS_QLShopQuanAo.Tables["TaiKhoan"].Rows)
                {
                    if(row["MaNV"].ToString() == manv.ToString())
                        dtgvDSTK.Rows.Add(row["MaNV"].ToString(), row["TaiKhoan"].ToString(), row["MatKhau"].ToString(), row["CapQuyen"].ToString(), row["TrangThai"].ToString());
                }
            }
            catch
            {
            }
        }
        //Lấy DS Tài Khoản hiển thị lên CBB
        public void LayDSTenTaiKhoan(int manv, ComboBox cbbTenTaiKhoan) {
            foreach (DataRow row in tblTaiKhoan().Rows)
            {
                if(row["MaNV"].ToString() == manv.ToString())
                {
                    cbbTenTaiKhoan.Items.Add(row["TaiKhoan"].ToString());
                }
            }
        }
        //Đổi mật khẩu tải khoản
        public bool DoiMatKhauTaiKhoan(string TenTaiKhoan, string mkcu, string mkmoi) {
            try
            {
                DataRow row = tblTaiKhoan().Rows.Find(TenTaiKhoan);
                if (row == null)
                    return false;
                else
                {
                    if (row["MatKhau"].ToString() == mkcu) {
                        row["MatKhau"] = mkmoi;
                        SqlCommandBuilder cmdb = new SqlCommandBuilder(DA_TaiKhoan);
                        DA_TaiKhoan.Update(DS_QLShopQuanAo, "TaiKhoan");
                        return true;
                    }
                    else
                    {
                        TB.MessageThongBao = "Mật khẩu cũ không đúng!";
                        TB.ShowDialog();
                        return false;
                    }
                } 
            }
            catch
            {
                return false;
            }
        }
        //Kiểm tra tên đăng nhập tài khoản đã tồn tại hay chưa
        public bool KTTaiKhoan(TaiKhoan tk) {
            try
            {
                if (DS_QLShopQuanAo.Tables["TaiKhoan"].Rows.Find(tk.Tendangnhap) != null)
                    return false;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //thêm tài khoản mới
        public bool ThemTaiKhoan(TaiKhoan tk) {
            try
            {
                if (!KTTaiKhoan(tk))
                {
                    //MessageBox.Show("Tên đăng nhập đã tồn tại!");
                    TB.MessageThongBao = "Tên đăng nhập đã tồn tại!";
                    TB.ShowDialog();
                    return false;
                }
                DataRow row = DS_QLShopQuanAo.Tables["TaiKhoan"].NewRow();
                row["MaNV"] = tk.Manv;
                row["TaiKhoan"] = tk.Tendangnhap;
                row["MatKhau"] = tk.Matkhau;
                row["CapQuyen"] = tk.Quyen;
                row["TrangThai"] = tk.Trangthai;
                DS_QLShopQuanAo.Tables["TaiKhoan"].Rows.Add(row);
                SqlCommandBuilder cmdb = new SqlCommandBuilder(DA_TaiKhoan);
                DA_TaiKhoan.Update(DS_QLShopQuanAo, "TaiKhoan");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Xóa tài khoản
        public bool XoaTaiKhoan(TaiKhoan tk) {
            try
            {
                if (!KTTaiKhoan(tk)) {
                    DS_QLShopQuanAo.Tables["TaiKhoan"].Rows.Find(tk.Tendangnhap).Delete();
                    SqlCommandBuilder cmdb = new SqlCommandBuilder(DA_TaiKhoan);
                    DA_TaiKhoan.Update(DS_QLShopQuanAo, "TaiKhoan");
                    return true;
                }
                //MessageBox.Show("Tài khoản này không tồn tại!");
                TB.MessageThongBao = "Tài khoản này không tồn tại!";
                TB.ShowDialog();
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //Xóa các tài khoản của theo mã nhân viên trong DataSet
        private void XoaTaiKhoan_TheoMaNV(int manv)
        {
            try
            {
                foreach (DataRow row in DS_QLShopQuanAo.Tables["TaiKhoan"].Rows)
                {
                    if (row["MaNV"].ToString() == manv.ToString())
                    {
                        DS_QLShopQuanAo.Tables["TaiKhoan"].Rows.Remove(row);
                    }
                }
            }catch {}  
        }
        //Cập nhật tài khoản\
        public bool CapNhatTaiKhoan(TaiKhoan tk) {
            try
            {
                if (!KTTaiKhoan(tk))
                {
                    //if(MessageBox.Show("Bạn có muốn cập nhật không!","Cập nhật tài khoản", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    //{
                    //    DataRow row = DS_QLShopQuanAo.Tables["TaiKhoan"].Rows.Find(tk.Tendangnhap);
                    //    row["MatKhau"] = tk.Matkhau;
                    //    row["CapQuyen"] = tk.Quyen;
                    //    row["TrangThai"] = tk.Trangthai;
                    //    SqlCommandBuilder cmdb = new SqlCommandBuilder(DA_TaiKhoan);
                    //    DA_TaiKhoan.Update(DS_QLShopQuanAo, "TaiKhoan");
                    //    return true;
                    //}
                    fThongBaoYesNo tbyn = new fThongBaoYesNo();
                    tbyn.Message_ThongBao = "Bạn có muốn cập nhật Tài Khoản không?";
                    tbyn.ShowDialog();
                    if (tbyn.Check == "Có") {
                        DataRow row = DS_QLShopQuanAo.Tables["TaiKhoan"].Rows.Find(tk.Tendangnhap);
                        row["MatKhau"] = tk.Matkhau;
                        row["CapQuyen"] = tk.Quyen;
                        row["TrangThai"] = tk.Trangthai;
                        SqlCommandBuilder cmdb = new SqlCommandBuilder(DA_TaiKhoan);
                        DA_TaiKhoan.Update(DS_QLShopQuanAo, "TaiKhoan");
                        return true;
                    }
                    return false;
                }   
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //xóa các hóa đơn của nhân viên có mã nhập vào
        private void XoaHoaDon_TheoMaNV(int manv) {
            try
            {
                foreach (DataRow row in DS_QLShopQuanAo.Tables["HoaDon"].Rows)
                {
                    if (row["MaNV"].ToString() == manv.ToString())
                    {
                        XoaCTHoaDon_TheoMaHD(row["MaHD"].ToString());
                        DS_QLShopQuanAo.Tables["HoaDon"].Rows.Remove(row);
                    }
                }
            }catch {}   
        }
        //Xóa các chi tiết hóa đơn với mã hóa đơn nhập vào
        private void XoaCTHoaDon_TheoMaHD(string mahd)
        {
            try
            {
                foreach (DataRow row in DS_QLShopQuanAo.Tables["CT_HoaDon"].Rows)
                {
                    if (row["MaHD"].ToString() == mahd)
                        DS_QLShopQuanAo.Tables["CT_HoaDon"].Rows.Remove(row);
                }
            }
            catch { }
        }
        //Hiển thị ds phiếu nhập
        public void LayDSPhieuNhap(DataGridView dtgvDSPN) {
            dtgvDSPN.Rows.Clear();
            foreach (DataRow row in DS_QLShopQuanAo.Tables["PhieuNhap"].Rows)
            {
                dtgvDSPN.Rows.Add(row["MaPN"], DS_QLShopQuanAo.Tables["NhanVien"].Rows.Find(row["MaNV"])["HoTen"].ToString(),DateTime.Parse(row["NgayLap"].ToString()).ToShortDateString(), row["TongTien"]);
            }
        }
        //Hiển thị thông tin chi tiết phiếu nhập lên listview
        public void HienThiCTPhieuNhap(int mapn, ListView CTPN) {
            CTPN.Items.Clear();
            foreach (DataRow row in DS_QLShopQuanAo.Tables["CT_PhieuNhap"].Rows)
            {
                if (row["MaPN"].ToString() == mapn.ToString()) {
                    ListViewItem masp = new ListViewItem() { Text = row["MaSP"].ToString()};
                    ListViewItem.ListViewSubItem tensp = new ListViewItem.ListViewSubItem() {Text = DS_QLShopQuanAo.Tables["SanPham"].Rows.Find(row["MaSP"].ToString())["TenSP"].ToString() };
                    ListViewItem.ListViewSubItem dongia = new ListViewItem.ListViewSubItem() { Text =Double.Parse(row["DonGia"].ToString()).ToString()};
                    ListViewItem.ListViewSubItem sl = new ListViewItem.ListViewSubItem() { Text = row["SoLuong"].ToString()};
                    ListViewItem.ListViewSubItem thanhtien = new ListViewItem.ListViewSubItem() { Text = Double.Parse(row["ThanhTien"].ToString()).ToString() };
                    masp.SubItems.Add(tensp);
                    masp.SubItems.Add(dongia);
                    masp.SubItems.Add(sl);
                    masp.SubItems.Add(thanhtien);
                    CTPN.Items.Add(masp);
                }
            }
        }
        //Thêm sản phẩm vào listview ct phiếu nhập
        public void ThemSPVaoCTPN(SanPham sp, ListView CTPN) {
            ListViewItem masp = new ListViewItem() { Text =sp.MaSP.ToString() };
            ListViewItem.ListViewSubItem tensp = new ListViewItem.ListViewSubItem() { Text = sp.TenSP };
            ListViewItem.ListViewSubItem dongia = new ListViewItem.ListViewSubItem() { Text =sp.GiaNhap.ToString() };
            ListViewItem.ListViewSubItem sl = new ListViewItem.ListViewSubItem() { Text = sp.SoLuong.ToString() };
            ListViewItem.ListViewSubItem thanhtien = new ListViewItem.ListViewSubItem() { Text =(sp.SoLuong * sp.GiaNhap).ToString() };
            masp.SubItems.Add(tensp);
            masp.SubItems.Add(dongia);
            masp.SubItems.Add(sl);
            masp.SubItems.Add(thanhtien);
            CTPN.Items.Add(masp);
        }
        //Tổng tiền phiếu nhập 
        public double TinhTongTienPhieuNhap(ListView CTPN) {
            double tongtien = 0;
            foreach (ListViewItem item in CTPN.Items)
            {
                tongtien += double.Parse(item.SubItems[4].Text);
            }
            return tongtien;
        }
        public bool KTPhieuNhap(ListView ctpn)
        {
            if (ctpn.Items.Count > 0)
            {
                return true;
            }
            return false;
        }
        //Lấy mã phiếu nhập m
        public int LayMaPhieuNhapMoi() {
            try
            {
                int masp = 1;
                try
                {
                    masp = int.Parse(DS_QLShopQuanAo.Tables["PhieuNhap"].Rows[tblPhieuNhap().Rows.Count - 1]["MaPN"].ToString()) + 1;
                }
                catch
                {
                    return 1;
                }
                
                return masp;
            }
            catch
            {
                return -1;
            }
        }
        //Thêm phiếu nhập mới
        public bool ThemPhieuNhap(int manv,double tongtien, ListView CTPN)
        {
            try
            {
                DataRow row = DS_QLShopQuanAo.Tables["PhieuNhap"].NewRow();
                row["MaPN"] = LayMaPhieuNhapMoi();
                row["MaNV"] = manv;
                row["NgayLap"] = DateTime.Now.ToShortDateString();
                row["TongTien"] = tongtien;
                DS_QLShopQuanAo.Tables["PhieuNhap"].Rows.Add(row);
                //Thêm vào bảng CT_PhieuNhap
                DataRow row_CT = DS_QLShopQuanAo.Tables["CT_PhieuNhap"].NewRow();
                foreach (ListViewItem item in CTPN.Items)
                {
                    ThemCTPhieuNhap(row["MaPN"].ToString(), item.SubItems[0].Text, item.SubItems[3].Text, item.SubItems[2].Text, item.SubItems[4].Text);
                }
                SqlCommandBuilder cmdb1 = new SqlCommandBuilder(DA_PhieuNhap);
                DA_PhieuNhap.Update(DS_QLShopQuanAo, "PhieuNhap");
                SqlCommandBuilder cmdb2 = new SqlCommandBuilder(DA_CTPhieuNhap);
                DA_CTPhieuNhap.Update(DS_QLShopQuanAo, "CT_PhieuNhap");
                return true;
            }
            catch
            {
                return false;
            }
        }
        private void ThemCTPhieuNhap(string mapn, string masp, string soluong, string dongia, string thanhtien) {
            try
            {
                DataRow row = DS_QLShopQuanAo.Tables["CT_PhieuNhap"].NewRow();
                row["MaPN"] = mapn;
                row["MaSP"] = masp;
                row["SoLuong"] = soluong;
                row["DonGia"] = dongia;
                row["ThanhTien"] = thanhtien;
                DS_QLShopQuanAo.Tables["CT_PhieuNhap"].Rows.Add(row);
            }
            catch
            {
            }
        }
        //Lấy ds các phiếu nhập theo ngày
        public void LayDSPhieuNhap_TheoNgay(DataGridView dtgvDSPN,string ngay) {
            dtgvDSPN.Rows.Clear();
            foreach (DataRow row in DS_QLShopQuanAo.Tables["PhieuNhap"].Rows)
            {
                if(DateTime.Parse(row["NgayLap"].ToString()).ToShortDateString() == ngay)
                 dtgvDSPN.Rows.Add(row["MaPN"], DS_QLShopQuanAo.Tables["NhanVien"].Rows.Find(row["MaNV"])["HoTen"].ToString(), DateTime.Parse(row["NgayLap"].ToString()).ToShortDateString(), row["TongTien"]);
            }
        }
        //Lấy tất cả hóa đươn bán hàng từ bảng hóa đơn
        public void LayDSHoaDon(DataGridView dtgvDSHD) {
            dtgvDSHD.Rows.Clear();
            foreach (DataRow row in DS_QLShopQuanAo.Tables["HoaDon"].Rows)
            {
                dtgvDSHD.Rows.Add(row["MaHD"].ToString(), row["TenKH"].ToString(), row["SDT"].ToString(), DateTime.Parse(row["NgayLap"].ToString()).ToShortDateString(),tblNhanVien().Rows.Find(row["MaNV"].ToString())["HoTen"].ToString(),double.Parse(row["ThanhToan"].ToString()));
            }
        }
        //Lấy ds hóa đơn bán hàng theo ngày
        public void LayDSHoaDon_TheoNgay(DataGridView dtgvDSHD,string ngay,TextBox SoHD,TextBox DoanhThu)
        {
            dtgvDSHD.Rows.Clear();
            double dt = 0;
            foreach (DataRow row in DS_QLShopQuanAo.Tables["HoaDon"].Rows)
            {
                if (DateTime.Parse(row["NgayLap"].ToString()).ToShortDateString() == ngay)
                {
                    dtgvDSHD.Rows.Add(row["MaHD"].ToString(), DateTime.Parse(row["NgayLap"].ToString()).ToShortDateString(), tblNhanVien().Rows.Find(row["MaNV"].ToString())["HoTen"].ToString(), double.Parse(row["ThanhToan"].ToString()));
                    dt += double.Parse(row["ThanhToan"].ToString());
                }
            }
            SoHD.Text = dtgvDSHD.Rows.Count.ToString();
            DoanhThu.Text = dt.ToString() + " VNĐ";
        }
        //Lấy ds hóa đơn theo tháng
        public void LayDSHoaDon_TheoThang(DataGridView dtgvDSHD, int thang, TextBox SoHD, TextBox DoanhThu)
        {
            dtgvDSHD.Rows.Clear();
            double dt = 0;
            foreach (DataRow row in DS_QLShopQuanAo.Tables["HoaDon"].Rows)
            {
                if (DateTime.Parse(row["NgayLap"].ToString()).Month == thang)
                {
                    dtgvDSHD.Rows.Add(row["MaHD"].ToString(), DateTime.Parse(row["NgayLap"].ToString()).ToShortDateString(), tblNhanVien().Rows.Find(row["MaNV"].ToString())["HoTen"].ToString(), double.Parse(row["ThanhToan"].ToString()));
                    dt += double.Parse(row["ThanhToan"].ToString());
                }
            }
            SoHD.Text = dtgvDSHD.Rows.Count.ToString();
            DoanhThu.Text = dt.ToString() + " VNĐ";
        }
        //Lấy thông tin hóa đơn theo sdt khách hàng
        public void LayTTHoaDon_TheoSDT(DataGridView dtvttHD, string sdt) {
            try
            {
                dtvttHD.Rows.Clear();
                Image img;
                foreach (DataRow row in tblHoaDon().Rows)
                {
                    if (row["SDT"].ToString() == sdt)
                    {
                        dtvttHD.Rows.Add(row["MaHD"].ToString(), row["TenKH"].ToString(), row["SDT"].ToString(), DateTime.Parse(row["NgayLap"].ToString()).ToShortDateString(),tblNhanVien().Rows.Find(row["MaNV"].ToString())["HoTen"].ToString(),double.Parse(row["ThanhToan"].ToString()));
                    }
                }
            }
            catch
            {
                MessageBox.Show("SDT không tồn tại!");
                return;
            }
        }
        //Lấy thông tin hóa đơn theo sdt khách hàng
        public void LayTTHoaDon_TheoMaHD(DataGridView dtvttHD, string mahd)
        {
            try
            {
                dtvttHD.Rows.Clear();
                Image img;
                foreach (DataRow row in tblHoaDon().Rows)
                {
                    if (row["MaHD"].ToString() == mahd)
                    {
                        dtvttHD.Rows.Add(row["MaHD"].ToString(), row["TenKH"].ToString(), row["SDT"].ToString(), DateTime.Parse(row["NgayLap"].ToString()).ToShortDateString(), tblNhanVien().Rows.Find(row["MaNV"].ToString())["HoTen"].ToString(), double.Parse(row["ThanhToan"].ToString()));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Mã Hóa Đơn không tồn tại!");
                return;
            }
        }
        //Tìm kiếm hóa đơn theo ngày
        public void LayTTHoaDon_TheoNgay(DataGridView dtvttHD, DateTime ngay)
        {
            dtvttHD.Rows.Clear();
            Image img;
            foreach (DataRow row in tblHoaDon().Rows)
            {
                if (DateTime.Parse(row["NgayLap"].ToString()).ToShortDateString() == ngay.ToShortDateString())
                {
                    try
                    {
                        img = Image.FromFile(row["HinhAnh"].ToString());
                    }
                    catch
                    {
                        img = Image.FromFile(@"E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\imgShop.jpg");
                    }
                    dtvttHD.Rows.Add(row["MaHD"].ToString(), row["TenKH"].ToString(), row["SDT"].ToString(), DateTime.Parse(row["NgayLap"].ToString()).ToShortDateString(), tblNhanVien().Rows.Find(row["MaNV"].ToString())["HoTen"].ToString(), double.Parse(row["ThanhToan"].ToString()));
                }
            }
        }
        //Hiển thị chi tiết hóa đơn lên listview
        public void HienThiCT_HoaDon(ListView cthd,int mahd) {
            cthd.Items.Clear();
            foreach (DataRow row in tblCT_HoaDon().Rows)
            {
                if(row["MaHD"].ToString() == mahd.ToString())
                {
                    ListViewItem masp = new ListViewItem() { Text = row["MaSP"].ToString() };
                    ListViewItem.ListViewSubItem tensp = new ListViewItem.ListViewSubItem() { Text = tblSanPham().Rows.Find(masp.Text)["TenSP"].ToString() };
                    ListViewItem.ListViewSubItem soluong = new ListViewItem.ListViewSubItem() {Text = row["SoLuong"].ToString() };
                    ListViewItem.ListViewSubItem dongia = new ListViewItem.ListViewSubItem() { Text = tblSanPham().Rows.Find(masp.Text)["GiaBan"].ToString() };
                    ListViewItem.ListViewSubItem thanhtien = new ListViewItem.ListViewSubItem() { Text = double.Parse(row["ThanhTien"].ToString()).ToString() };
                    masp.SubItems.Add(tensp);
                    masp.SubItems.Add(soluong);
                    masp.SubItems.Add(dongia);
                    masp.SubItems.Add(thanhtien);
                    cthd.Items.Add(masp);
                    
                }  
            }
        }
            
    }
}
