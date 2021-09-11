using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopQuanAo.Object
{
    class HoaDon
    {
        private int maNV;
        private string tenKH, sDTKH;
        private DateTime ngayLap;
        private int tongTien, giamGia, thanhToan;

        public int MaNV { get => maNV; set => maNV = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string SDTKH { get => sDTKH; set => sDTKH = value; }
        public int TongTien { get => tongTien; set => tongTien = value; }
        public int GiamGia { get => giamGia; set => giamGia =( value * tongTien ) / 100; }
        public Double ThanhToan { get => thanhToan; set => thanhToan = tongTien - giamGia; }
        public DateTime NgayLap { get => ngayLap; set => ngayLap = value; }

        public HoaDon(int _manv,string _tenkh,string _sdtkh,DateTime _ngaylap,int _tongtien,int _giamgia)
        {
            this.MaNV = _manv;
            this.TenKH = _tenkh;
            this.SDTKH = _sdtkh;
            this.NgayLap = _ngaylap;
            this.TongTien = _tongtien;
            this.GiamGia = _giamgia;
            this.ThanhToan = _tongtien - (giamGia* _tongtien)/100;
        }
    }
}
