using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
namespace QLShopQuanAo.Object
{
    class XLDangNhap
    {
        public XLDangNhap()
        {
        }
        //Kiểm tra tài khoản và mật khẩu
        public bool KTTaiKhoan(string taikhoan, string matkhau)
        {
            DataProvider pro = new DataProvider();
            DataTable dt = pro.ExecuteQuery("LayTaiKhoan '" + taikhoan + "','" + matkhau + "'");
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }
        //Kiểm tra trạng thái của tài khoản
        public bool KTTrangThai(string taikhoan, string matkhau)
        {
            DataProvider pro = new DataProvider();
            DataTable dt = pro.ExecuteQuery("LayTrangThaiTK '" + taikhoan + "','" + matkhau + "'");
            string tt = dt.ToString();
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }
        //Lấy thông tin tài khoản
        public TaiKhoan LayTTTaiKhoan(string taikhoan, string matkhau)
        {
            DataProvider pro = new DataProvider();
            DataTable dt = pro.ExecuteQuery("LayTTTK'" + taikhoan + "','" + matkhau + "'");
            TaiKhoan tk = new TaiKhoan();
            foreach (DataRow item in dt.Rows)
            {
                tk.Tendangnhap = item["TaiKhoan"].ToString();
                tk.TenNhanVien = item["HoTen"].ToString();
                tk.Matkhau = item["MatKhau"].ToString();
                tk.Manv = int.Parse(item["MaNV"].ToString());
                tk.Quyen = item["CapQuyen"].ToString();
                tk.Trangthai = item["TrangThai"].ToString();
            }
            return tk;
        }
    }
}
