using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopQuanAo.Object
{
    class NhanVien
    {
        private int maNV;
        private double luongCB;
        private string hoTenNV,gioiTinh,sDT, diaChi;
        private DateTime ngaySinh, ngayVaoLam;
        private string hinhAnh;
        public int MaNV { get => maNV; set => maNV = value; }
        public Double Luong { get => luongCB; set => luongCB = value; }
        public string HoTenNV { get => hoTenNV; set => hoTenNV = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public DateTime NgayVaoLam { get => ngayVaoLam; set => ngayVaoLam = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public NhanVien() { }
        public NhanVien(int _manv,string _hoten,string _gioitinh,DateTime _ngaysinh,DateTime _ngayvaolam,string _sdt,string _diachi,double _luong,string _hinhanh)
        {
            this.MaNV = _manv;
            this.HoTenNV = _hoten;
            this.GioiTinh = _gioitinh;
            this.NgaySinh = _ngaysinh;
            this.SDT = _sdt;
            this.DiaChi = _diachi;
            this.NgayVaoLam = _ngayvaolam;
            this.Luong = _luong;
            this.HinhAnh = _hinhanh;
        }
    }
}
