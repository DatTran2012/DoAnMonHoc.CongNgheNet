CREATE DATABASE QLShopQuanAo
Go
USE QLShopQuanAo
select * from SANPHAM
Go
CREATE TABLE NHANVIEN(
	MaNV int identity,
	HoTen nvarchar(50),
	NgaySinh date,
	GioiTinh nvarchar(10),
	DiaChi nvarchar(50),
	SDT varchar(15),
	NgayVaoLam date,
	Luong money,
	HinhAnh varchar(100),
	Constraint PK_Nhanvien Primary key(MaNV)
)
go
CREATE TABLE TAIKHOAN (
	TaiKhoan varchar(50),
	MatKhau varchar(50),
	MaNV int,
	CapQuyen nvarchar(50),
	TrangThai nvarchar(50),
	Constraint PK_TaiKhoan primary key(TaiKhoan),
	Constraint FK_TaiKhoan foreign key(MaNV) references NhanVien(MaNV) ON DELETE CASCADE
)
go
CREATE TABLE NHACUNGCAP(
	MaNCC int identity primary key,
	TenNCC nvarchar(20),
)
CREATE TABLE LOAISANPHAM(
	MaLoai int identity primary key,
	TenLoai nvarchar(50)
)
go

CREATE TABLE SANPHAM(
	MaSP int identity primary key,
	TenSP nvarchar(50),
	MaLoai int,
	MaNCC int,
	Size varchar(20),
	SoLuong int default 0,
	DonViTinh nvarchar(20),
	GiaNhap money,
	GiaBan money,
	HinhAnh nvarchar(100),
	Constraint FK_SanPham_MaLoai foreign key(MaLoai) references LOAISANPHAM(MaLoai) ON DELETE CASCADE,
	Constraint FK_SanPham_MaNCC foreign key(MaNCC) references NhaCungCap(MaNCC) ON DELETE CASCADE,
)
CREATE TABLE HOADON(
	MaHD int identity ,
	MaNV int,
	TenKH nvarchar(50),
	SDT varchar(15),
	NgayLap date,
	TongTien money,
	GiamGia int,
	ThanhToan money,
	Constraint PK_HoaDon_MaHD primary key(MaHD),
	Constraint FK_HoaDon_MaNV foreign key(MaNV) references NhanVien(MaNV) ON DELETE CASCADE,
)
CREATE TABLE CT_HOADON (
	MaHD int,
	MaSP int,
	SoLuong int,
	ThanhTien money,
	Constraint PK_CTHoaDon primary key(MaHD,MaSP),
	Constraint FK_CTHoaDon foreign key(MaHD) references HoaDon(MaHD) ON DELETE CASCADE,
	Constraint FK_CTHoaDon_MaSP foreign key(MaSP) references SanPham(MaSP) ON DELETE CASCADE
)
CREATE TABLE PHIEUNHAP(
	MaPN int identity primary key,
	MaNV int,
	NgayLap date,
	TongTien money
)
CREATE TABLE CT_PHIEUNHAP(
	MaPN int,
	MaSP int,
	SoLuong int,
	DonGia money,
	ThanhTien money,
	Constraint PK_CTPhieuNhap primary key(MaPN,MaSP) ,
	Constraint FK_CTPhieuNhap_MaPN foreign key(MaPN) references PhieuNhap(MaPN) ON DELETE CASCADE,
	Constraint FK_CTPhieuNhap_MaSP foreign key(MaSP) references SanPham(MaSP) ON DELETE CASCADE,
)
---- Ràng buộc
/*Bảng Nhân Viên*/
ALTER TABLE NHANVIEN
ADD CONSTRAINT Check_GioiTinh Check(GioiTinh = N'Nam' OR GioiTinh=N'Nữ'),
CONSTRAINT Check_LuongCB check(Luong >= 0)

/*Bảng Tài Khoản*/
ALTER TABLE TAIKHOAN
ADD CONSTRAINT Check_CapQuyen check(CapQuyen = N'Quản lý' OR CapQuyen=N'Nhân viên'),
	CONSTRAINT Check_TrangThai check(TrangThai = N'Hoạt động' OR TrangThai =N'Khóa') 
/*Bảng Sản Phẩm*/
ALTER TABLE SANPHAM
ADD CONSTRAINT Check_GiaBan Check(GiaBan >= 0),
	CONSTRAINT Check_SoLuong Check(SoLuong >= 0)

/*Bảng Hóa Đơn*/
ALTER TABLE HOADON
ADD CONSTRAINT Default_NgayLap Default GetDate() for NgayLap,
	Constraint Default_TongTien default 0 for TongTien,
	Constraint Defalut_Giamgia default 0 for Giamgia,
	Constraint Defalut_ThanhToan default 0 for ThanhToan
	
/*Bảng CT_HoaDon*/
ALTER TABLE CT_HOADON
ADD CONSTRAINT Check_CTHoaDonSoLuong Check(SoLuong >= 0)
/*Bảng Phieu nhập*/
ALTER TABLE PHIEUNHAP
ADD CONSTRAINT Default_NgayLap_PN default GETDATE() for NgayLap,
	CONSTRAINT Default_TongTien_PN default 0 for TongTien

------Nhập liệu -----
/*Bảng Nhân Viên*/
SET DATEFORMAT DMY
INSERT INTO NHANVIEN(HoTen,NgaySinh,GioiTinh,DiaChi,SDT,NgayVaoLam,Luong,HinhAnh) VALUES
 (N'Trần Tấn Lộc','5/10/2000',N'Nam',N'655/49,Lê Trọng Tấn,Bình Hưng Hòa,Bình Tân','0337369439','5/10/2020',7000000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Loc.jpg');
 GO
 SET DATEFORMAT DMY
INSERT INTO NHANVIEN(HoTen,NgaySinh,GioiTinh,DiaChi,SDT,NgayVaoLam,Luong,HinhAnh) VALUES
 (N'Trần Ngọc Đạt','01/01/2000',N'Nam',N'140,Lê Trọng Tấn,Tân Phú','0337369439','01/01/2020',5000000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Dat.jpg');
  GO
SET DATEFORMAT DMY
INSERT INTO NHANVIEN(HoTen,NgaySinh,GioiTinh,DiaChi,SDT,NgayVaoLam,Luong,HinhAnh) VALUES
 (N'Nhân Viên Test','01/01/2000',N'Nam',N'140,Lê Trọng Tấn,Tân Phú','0337369439','01/01/2020',4500000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\NhanVien.png');
  GO
/*Bảng Tài khoản*/
SET DATEFORMAT DMY
INSERT INTO TAIKHOAN(TaiKhoan,MatKhau,MaNV,CapQuyen,TrangThai) VALUES
('loc','123',1,N'Quản lý',N'Hoạt động');
 GO
SET DATEFORMAT DMY
INSERT INTO TAIKHOAN(TaiKhoan,MatKhau,MaNV,CapQuyen,TrangThai) VALUES
('dat','123',2,N'Nhân Viên',N'Hoạt động');
 GO
 SET DATEFORMAT DMY
INSERT INTO TAIKHOAN(TaiKhoan,MatKhau,MaNV,CapQuyen,TrangThai) VALUES
('test','123',3,N'Nhân Viên',N'Khóa');
go
 /*Bảng nhà cung cấp*/
 INSERT INTO NHACUNGCAP(TenNCC) VALUES 
 (N'Yame'),(N'5 The Way'),(N'The Blue'),(N'Việt Tiến')
 GO
 /*Bảng loại sản phẩm*/
 INSERT INTO LOAISANPHAM(TenLoai) VALUES (N'Áo Thun'),(N'Áo Sơ Mi'),(N'Áo Khoác'),(N'Quần Jeans'),(N'Quần Sort'),(N'Quần Thun')
 GO
 /*Bảng Sản phẩm*/ 
 --Size L
 INSERT INTO SANPHAM(TenSP,MaLoai,MaNCC,Size,SoLuong,DonViTinh,GiaNhap,GiaBan,HinhAnh) VALUES
 (N'Áo Thun Trắng Sài Gòn',1,1,'L',5,N'Cái',150000,195000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\Ao1.png'),
 (N'Áo Map',1,1,'L',5,N'Cái',150000,195000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\Ao2.png'),
 (N'Áo TEFWOLD',1,1,'L',5,N'Cái',150000,205000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\Ao3.png'),
 (N'Áo Sugar Daddy',1,1,'L',10,N'Cái',175000,235000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\Ao4.png'),
 (N'Áo Among US',1,1,'L',3,N'Cái',155000,205000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\Ao5.png'),
 (N'Áo Thun Đen',1,1,'L',5,N'Cái',150000,195000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\Ao6.png'),
 (N'Áo Thun Đen',1,1,'L',5,N'Cái',150000,195000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\Ao7.png'),
 (N'Áo BAD Cat',1,1,'L',5,N'Cái',150000,205000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\Ao8.png'),
 (N'Áo Thun Trắng 1',1,2,'L',5,N'Cái',150000,235000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\Ao9.png'),
 (N'Áo Thun Đen Sài Gòn',1,2,'L',5,N'Cái',150000,205000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\Ao10.png'),
 (N'Áo Big City Boy',1,2,'L',5,N'Cái',150000,255000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\Ao11.png'),
 (N'Áo  5TheWay ',1,2,'L',5,N'Cái',150000,235000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\Ao12.png'),
 (N'Áo MonKey',1,2,'L',5,N'Cái',150000,255000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\Ao13.png'),
 (N'Áo Caro Đỏ ',2,3,'L',10,N'Cái',150000,275000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\CaroDo.PNG'),
 (N'Áo Caro Xanh',2,3,'L',10,N'Cái',150000,275000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\CaroXanh.PNG'),
 (N'Sơ Mi Xám',2,3,'L',5,N'Cái',150000,275000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\SoMiXam.PNG'),
 (N'Áo khoác 5TheWay',3,2,'L',10,N'Cái',150000,305000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\AoK1.PNG'),
 (N'Áo khoác 2020',3,1,'L',5,N'Cái',150000,255000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\AoK2.PNG'),
 (N'Áo khoác Đen',3,3,'L',5,N'Cái',150000,255000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\AoK3.PNG'),
 (N'Áo Hoodie Đỏ',3,3,'L',5,N'Cái',150000,205000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Ao\AoK4.PNG'),
 (N'Quần Jeans QJ1',4,1,'L',5,N'Cái',150000,395000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Quan\Quan1.jpg'),
 (N'Quần Jeans QJ2',4,1,'L',5,N'Cái',150000,395000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Quan\Quan2.jpg'),
 (N'Quần Jeans QJ4',4,2,'L',5,N'Cái',150000,405000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Quan\Quan3.jpg'),
 (N'Quần Jeans QJ3',4,2,'L',5,N'Cái',150000,395000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Quan\Quan4.jpg'),
 (N'Quần Jeans QJ5',4,2,'L',5,N'Cái',150000,395000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Quan\Quan5.jpg'),
 (N'Quần Sort QS1',5,1,'L',5,N'Cái',150000,195000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Quan\Quan6.jpg'),
 (N'Quần Sort QS2',5,1,'L',5,N'Cái',150000,195000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Quan\Quan7.jpg'),
 (N'Quần Sort QS3',5,1,'L',5,N'Cái',150000,195000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Quan\Quan8.jpg'),
 (N'Quần Thun QT1',6,2,'L',5,N'Cái',150000,195000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Quan\Quan9.jpg'),
 (N'Quần Thun QT2',6,2,'L',5,N'Cái',150000,195000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Quan\Quan10.jpg'),
 (N'Quần Thun AT3',6,2,'L',5,N'Cái',150000,195000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Quan\Quan11.jpg'),
 (N'Quần Thun AT4',6,3,'L',5,N'Cái',150000,195000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Quan\Quan12.jpg'),
 (N'Quần Thun AT5',6,3,'L',5,N'Cái',150000,195000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Quan\Quan13.jpg'),
 (N'Quần Thun AT6',6,1,'L',5,N'Cái',150000,195000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Quan\Quan14.jpg'),
 (N'Quần Thun AT7',6,1,'L',5,N'Cái',150000,195000,'E:\Cong_Nghe_NET\DoAn_QLShop\DoAn_QLShop\HinhAnh\Quan\Quan15.jpg')

 GO
  ------------------------------------------------------------------------------------------------------------------------------
 --1 thủ tục kiểm tra tài khoản đăng nhập
 CREATE  PROC LayTaiKhoan  @Tk varchar(50),@MK varchar(50)
 AS BEGIN
	SELECT * FROM TAIKHOAN WHERE TAIKHOAN = @Tk AND MatKhau = @MK 
	END
 GO
 --2 thủ tục kiểm tra trạng thái tài khoản
 CREATE PROC LayTrangThaiTK  @Tk varchar(50),@MK varchar(50)
 AS BEGIN
	SELECT TrangThai FROM TAIKHOAN WHERE TAIKHOAN = @Tk AND MatKhau = @MK and TrangThai = N'Hoạt Động' 
	END
 GO
 --3 thủ tục lấy thông tin tài khoản
 CREATE PROC LayTTTK  @Tk varchar(50),@MK varchar(50)
 AS BEGIN
	SELECT TaiKhoan.*,HoTen FROM TAIKHOAN,NHANVIEN WHERE TAIKHOAN = @Tk AND MatKhau = @MK and TaiKhoan.MaNV = NHANVIEN.MaNV
	END
 GO
  --10 lấy thông tin sản phẩm kèm theo tên loại và tên nhà cung cấp
CREATE PROC LayThongTinSanPham
AS BEGIN
select SANPHAM.MaSP,SANPHAM.TenSP,TenLoai,TenNCC,Size,SoLuong,DonViTinh,GiaNhap,GiaBan,HinhAnh 
from SANPHAM,LOAISANPHAM,NHACUNGCAP 
where SANPHAM.MaLoai = LOAISANPHAM.MaLoai AND NHACUNGCAP.MaNCC = SANPHAM.MaNCC 
END
GO
-----8 Thủ tục lấy thông tin hóa đơn 
 CREATE PROC LayTTHoaDon 
 AS BEGIN
	SELECT HD.MaHD,HD.TenKH,HD.SDT,HD.NgayLap,NV.HoTen,CTHD.MaSP,SP.TenSP,CTHD.SoLuong,CTHD.ThanhTien,SP.HinhAnh
	FROM HOADON HD,CT_HOADON CTHD,NHANVIEN NV,SANPHAM SP
	WHERE HD.MaHD = CTHD.MaHD AND HD.MaNV = NV.MaNV AND CTHD.MaSP = SP.MaSP
 END
 GO
 --------------------------------------------------------------------------------------------------------------------------------
 --1 Trigger tự động cập nhật thành tiền trong CT_HoaDon
 CREATE TRIGGER CapNhatThanhTien_CTHoaDon ON CT_HoaDon
 FOR INSERT AS 
 BEGIN
	UPDATE SANPHAM
	SET SoLuong = SANPHAM.SoLuong - inserted.SoLuong
	FROM inserted
	WHERE SANPHAM.MaSP = inserted.MASP
	UPDATE CT_HOADON
	SET ThanhTien = CT_HOADON.SoLuong * SANPHAM.GiaBan
	FROM inserted,SANPHAM
	WHERE CT_HOADON.MaHD = inserted.MaHD and inserted.MaSP = SANPHAM.MaSP AND inserted.MaSP = CT_HOADON.MaSP
	UPDATE HOADON
	SET TongTien = (select SUM(CT_HOADON.ThanhTien) FROM CT_HOADON,inserted,HOADON where CT_HOADON.MaHD = HOADON.MaHD and inserted.MaHD = CT_HOADON.MaHD),NgayLap = GETDATE()
	FROM inserted
	WHERE inserted.MaHD = HOADON.MaHD
 END
 GO

--3 Trigger cập nhật thanh toán khi thêm và cập nhật hóa đơn
CREATE TRIGGER CapNhatThanhToan ON HOADON
AFTER UPDATE AS BEGIN
	IF UPDATE(TONGTIEN)
	  BEGIN
		UPDATE HOADON
		SET ThanhToan = inserted.TongTien - inserted.GiamGia 
		FROM inserted
		WHERE HOADON.MaHD = inserted.MaHD
	  END
END
GO

--1 Cập nhật THÀNH tiền trong  ct phiêu nhập
CREATE TRIGGER CapNhatThanhTien_PhieuNhap ON CT_PHIEUNHAP
FOR INSERT AS BEGIN
	UPDATE CT_PHIEUNHAP
	SET ThanhTien = CT_PHIEUNHAP.DonGia * CT_PHIEUNHAP.SoLuong
	FROM inserted
	WHERE inserted.MaPN = CT_PHIEUNHAP.MaPN
END
GO

--1 Cập nhật tổng tiền trong phiêu nhập
CREATE TRIGGER CapNhatTongTien_PhieuNhap ON CT_PHIEUNHAP
FOR INSERT AS BEGIN
	UPDATE PHIEUNHAP
	SET	TongTien = (select SUM(CT_PHIEUNHAP.ThanhTien) FROM inserted,CT_PHIEUNHAP WHERE inserted.MaPN = CT_PHIEUNHAP.MaPN)
	from inserted
	where inserted.MaPN = PHIEUNHAP.MaPN
END
GO

CREATE TRIGGER CapNhatSoLuongSanPham_ThemCTPhieu ON CT_PHIEUNHAP
FOR INSERT AS BEGIN
	UPDATE SANPHAM
	SET SoLuong = SANPHAM.SoLuong + inserted.SoLuong
	FROM inserted
	WHERE inserted.MaSP = SANPHAM.MaSP
END
GO

CREATE PROC InHoaDon @MaHD int
AS BEGIN
	SELECT HD.MaHD,HD.NgayLap,NV.HoTen,HD.TenKH,CTHD.MaSP,SP.TenSP,CTHD.SoLuong,SP.GiaBan,CTHD.ThanhTien,HD.TongTien,HD.GiamGia,HD.ThanhToan
	FROM HOADON HD,CT_HOADON CTHD,SANPHAM SP,NHANVIEN NV
	WHERE HD.MaHD = CTHD.MaHD
	AND CTHD.MaSP = SP.MaSP
	AND HD.MaNV = NV.MaNV
	AND HD.MaHD = @MAHD
END
GO

CREATE PROC InPhieuNhap @MaPN int
AS BEGIN
	SELECT PN.MaPN,PN.NgayLap,NV.HoTen,CTPN.MaSP,SP.TenSP,CTPN.DonGia,CTPN.SoLuong,CTPN.ThanhTien,PN.TongTien
	FROM PHIEUNHAP PN,CT_PHIEUNHAP CTPN, SANPHAM SP,NHANVIEN NV
	WHERE PN.MaPN = CTPN.MaPN
	AND PN.MaNV = NV.MaNV
	AND CTPN.MaSP = SP.MaSP
	AND PN.MaPN = @MaPN
END
GO

select * from CT_PHIEUNHAP

/*use master
drop database QLShopQuanAo
*/
-------------------------------------------------------------------------------------------------------

