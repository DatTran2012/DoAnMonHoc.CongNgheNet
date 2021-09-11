using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLShopQuanAo.Object
{
    class TaiKhoan
    {
        private string tendangnhap, matkhau, quyen, trangthai, tennhanvien;
        private int manv;

        public string Tendangnhap { get => tendangnhap; set => tendangnhap = value; }
        public string TenNhanVien { get => tennhanvien; set => tennhanvien = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public string Quyen { get => quyen; set => quyen = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
        public int Manv { get => manv; set => manv = value; }
        public TaiKhoan(){}
        public TaiKhoan(string _tendn, string _mk, int _manv, string _tennv, string _quyen, string _trangthai)
        {
            this.Tendangnhap = _tendn;
            this.TenNhanVien = _tennv;
            this.Matkhau = _mk;
            this.Manv = _manv;
            this.Quyen = _quyen;
            this.Trangthai = _trangthai;
        }
    }
}
