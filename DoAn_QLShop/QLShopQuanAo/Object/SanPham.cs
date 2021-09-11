using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopQuanAo.Object
{
    class SanPham
    {
        private int maSP, soLuong;
        private int maLoai, maNCC;
        private double giaNhap, giaBan;
        private string tenSP, size, dVT, hinhAnh;

        public int MaSP { get => maSP; set => maSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public double GiaNhap { get => giaNhap; set => giaNhap = value; }
        public double GiaBan { get => giaBan; set => giaBan = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public string Size { get => size; set => size = value; }
        public string DVT { get => dVT; set => dVT = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public int MaLoai { get => maLoai; set => maLoai = value; }
        public int MaNCC { get => maNCC; set => maNCC = value; }
        public SanPham() { }
        public SanPham(int _masp,string _tensp,int _maloai,int _mancc,string _size,int _soluong,string _dvt,double _gianhap,double _giaban,string _hinhanh) {
            this.MaSP = _masp;
            this.TenSP = _tensp;
            this.MaLoai = _maloai;
            this.MaNCC = _mancc;
            this.Size = _size;
            this.SoLuong = _soluong;
            this.DVT = _dvt;
            this.GiaNhap = _gianhap;
            this.GiaBan = _giaban;
            this.HinhAnh = _hinhanh;

        }
    }
}
