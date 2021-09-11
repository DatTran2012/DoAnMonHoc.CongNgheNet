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
    partial class fQLNhanVien : Form
    {
        public XuLy XL { get; set; }
        fThongBao TB = new fThongBao();
        public fQLNhanVien()
        {
            InitializeComponent();
        }

        private void fQLNhanVien_Load(object sender, EventArgs e)
        {
            HienThiDSNhanVien();
            txtMaNV.Text = XL.LayMaNhanVienMoi().ToString();
            dtpNgaySinh.Text = "01/01/2020";
            btnXoa.Enabled = btnCapNhat.Enabled = false;
            txtHoTen.Focus();
        }
        //Hiển thị ds nhân viên
        private void HienThiDSNhanVien()
        {
            XL.LayDSNhanVien(dtgvDSNV);
        }
        //Ràng buộc nhập số
        private void txtLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) & !char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        //Chọn hình nhân viên
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
            catch { }
        }
        //Click hiển thị thông tin lên textbox
        private void dtgvDSNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearThongTin();
            int manv = int.Parse(dtgvDSNV.CurrentRow.Cells[0].Value.ToString());
            XL.HienThiThongTinNhanVien(manv,txtMaNV,txtHoTen,rdbNam,rdbNu,dtpNgayLam,txtLuong,dtpNgaySinh,txtSDT,txtDiaChi,pcbHinhAnh,txtHinhAnh);
            btnXoa.Enabled = btnCapNhat.Enabled = true;
        }
        //clẻar thông tin trên textbox
        private void ClearThongTin()
        {
            txtMaNV.Text = txtHoTen.Text = txtLuong.Text = txtSDT.Text = txtDiaChi.Text = txtHinhAnh.Text = "";
            dtpNgaySinh.Text = dtpNgayLam.Text = "";
            pcbHinhAnh.Image = null;
        }
        //Thêm nhân viên mới
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (XL.KTRong(txtHoTen.Text) || XL.KTRong(txtLuong.Text) || XL.KTRong(txtSDT.Text) || XL.KTRong(txtDiaChi.Text) || XL.KTRong(txtHinhAnh.Text)) {
                //MessageBox.Show("Vui lòng nhập đủ thông tin cho nhân viên!");
                TB.MessageThongBao = "Vui lòng nhập đủ thông tin cho nhân viên!";
                TB.ShowDialog();
                return;
            }
            NhanVien nv = new NhanVien(1, txtHoTen.Text, rdbNam.Checked == true ? "Nam" : "Nữ",DateTime.Parse(dtpNgaySinh.Text),DateTime.Parse(dtpNgayLam.Text), txtSDT.Text, txtDiaChi.Text, double.Parse(txtLuong.Text), txtHinhAnh.Text);
            if (XL.ThemNhanVien(nv))
            {
                //MessageBox.Show("Thêm thành công!");
                TB.MessageThongBao = "Thêm Nhân Viên thành công!";
                TB.ShowDialog();
                HienThiDSNhanVien();
                ClearThongTin();
                txtHoTen.Focus();
                btnXoa.Enabled = btnCapNhat.Enabled = false;
            }
            else
            {
                MessageBox.Show("Lỗi!");
            }
        }
        //Xóa nhân viên
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (XL.KTRong(txtMaNV.Text))
            {
                //MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
                TB.MessageThongBao = "Vui lòng chọn nhân viên cần xóa!";
                TB.ShowDialog();
            }
            else {
                fThongBaoYesNo tbyn = new fThongBaoYesNo();
                tbyn.Message_ThongBao = "Bạn muốn xóa Nhân Viên " + txtHoTen.Text + " ?";
                tbyn.ShowDialog();
                if (tbyn.Check == "Có") {
                    if (XL.XoaNhanVien(int.Parse(txtMaNV.Text)))
                    {
                        //MessageBox.Show("Xóa thành công!");
                        TB.MessageThongBao = "Xóa Nhân Viên thành công!";
                        TB.ShowDialog();
                        HienThiDSNhanVien();
                        ClearThongTin();
                        btnXoa.Enabled = btnCapNhat.Enabled = false;
                        txtHoTen.Focus();
                    }
                    else
                    {
                        //MessageBox.Show("Lỗi!");
                        TB.MessageThongBao = "Lỗi!";
                        TB.ShowDialog();
                    }
                }
                //if (MessageBox.Show("Bạn xóa nhân viên "+txtHoTen.Text+" ?", "Xóa nhân viên",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                //{
                //    if (XL.XoaNhanVien(int.Parse(txtMaNV.Text)))
                //    {
                //        //MessageBox.Show("Xóa thành công!");
                //        TB.MessageThongBao = "Xóa Nhân Viên thành công!";
                //        TB.ShowDialog();
                //        HienThiDSNhanVien();
                //        ClearThongTin();
                //        btnXoa.Enabled = btnCapNhat.Enabled = false;
                //        txtHoTen.Focus();
                //    }
                //    else
                //    {
                //        MessageBox.Show("Lỗi!");
                //    }
                //}  
            }
        }
        //Cập nhật thông tin nhân viên
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (XL.KTRong(txtHoTen.Text) || XL.KTRong(txtLuong.Text) || XL.KTRong(txtSDT.Text) || XL.KTRong(txtDiaChi.Text) || XL.KTRong(txtHinhAnh.Text) || pcbHinhAnh.Image == null) {
                //MessageBox.Show("Thông tin chưa chính xác. \n Yêu cầu xem lại thông tin nhân viên!");
                {
                    TB.MessageThongBao = "Thông tin chưa chính xác. \n Yêu cầu xem lại thông tin nhân viên!";
                    TB.ShowDialog();
                }
            }
            else
            {
                fThongBaoYesNo tbyn = new fThongBaoYesNo();
                tbyn.Message_ThongBao = "Xác nhận cập nhật thông tin nhân viên!";
                tbyn.ShowDialog();
                if (tbyn.Check == "Có") {
                    NhanVien nv = new NhanVien(int.Parse(txtMaNV.Text), txtHoTen.Text, rdbNam.Checked == true ? "Nam" : "Nữ", DateTime.Parse(dtpNgaySinh.Text), DateTime.Parse(dtpNgayLam.Text), txtSDT.Text, txtDiaChi.Text, double.Parse(txtLuong.Text), txtHinhAnh.Text);
                    if (XL.CapNhatThongTinNhanVien(nv))
                    {
                        TB.MessageThongBao = "Cập Nhật Thành Công!";
                        TB.ShowDialog();
                        HienThiDSNhanVien();
                        ClearThongTin();
                        btnXoa.Enabled = btnCapNhat.Enabled = false;
                        txtHoTen.Focus();
                    }
                    else
                    {
                        TB.MessageThongBao = "Lỗi!";
                        TB.ShowDialog();
                    }
                }
                //if (MessageBox.Show("Xác nhận cập nhật thông tin nhân viên!", "Cập nhật thông tin nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2) == DialogResult.Yes) {
                //    NhanVien nv = new NhanVien(int.Parse(txtMaNV.Text), txtHoTen.Text, rdbNam.Checked == true ? "Nam" : "Nữ", DateTime.Parse(dtpNgaySinh.Text), DateTime.Parse(dtpNgayLam.Text), txtSDT.Text, txtDiaChi.Text, double.Parse(txtLuong.Text), txtHinhAnh.Text);
                //    if (XL.CapNhatThongTinNhanVien(nv)) {
                //        MessageBox.Show("Cập nhật thành công!");
                //        HienThiDSNhanVien();
                //        ClearThongTin();
                //        btnXoa.Enabled = btnCapNhat.Enabled = false;
                //        txtHoTen.Focus();
                //    }else
                //    {
                //        MessageBox.Show("Lỗi!");
                //    }
                //}   
            }
        }
        //Tìm kiếm nhân viên theo mã
        private void btnTKNhanVien_Click(object sender, EventArgs e)
        {
            if (XL.KTRong(txtTimMaNV.Text))
            {
                TB.MessageThongBao = "Vui lòng nhập Mã Nhân Viên cần tìm!";
                TB.ShowDialog();
            }
                //MessageBox.Show("Vui lòng nhập mã nhân viên cần tìm!");
            else
            {
                XL.LayNhanVienTheoMa(dtgvDSNV,int.Parse(txtTimMaNV.Text));
            }
        }
        //load lại ds nhân viên
        private void btnLoadDSNhanVien_Click(object sender, EventArgs e)
        {
            ClearThongTin();
            HienThiDSNhanVien();
        }
        //Tạo mới lại thông tin và bắt đầu thêm nhân viên mới, load manv mới lên
        private void btnTaoMoi_Click(object sender, EventArgs e)
        {
            ClearThongTin();
            txtMaNV.Text = XL.LayMaNhanVienMoi().ToString();
            txtHoTen.Focus();
        }
    }
}
