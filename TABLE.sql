﻿CREATE DATABASE PROJECT_DBMS
GO
USE PROJECT_DBMS
GO

-- Tạo bảng loại khách hàng
CREATE TABLE LOAIKHACHHANG(
MALOAIKH VARCHAR(15),
TENLOAI NVARCHAR(30),
CONSTRAINT PK_LOAIKHACHHANG PRIMARY KEY(MALOAIKH))
GO
-- Tạo bảng khách hàng
CREATE TABLE KHACHHANG(
MAKH VARCHAR(15),
TENKH NVARCHAR(30),
GIOITINH NVARCHAR(10),
DIACHI NVARCHAR(30),
DIENTHOAI VARCHAR(15),
MALOAIKH VARCHAR(15),
CONSTRAINT FK_KHACHHANG FOREIGN KEY(MALOAIKH) REFERENCES dbo.LOAIKHACHHANG(MALOAIKH),
CONSTRAINT PK_KHACHHANG PRIMARY KEY(MAKH))
GO
-- Tạo bảng đơn đặt hàng
CREATE TABLE DONDATHANG(
MADDH VARCHAR(15),
GHICHU NVARCHAR(35),
MAKH VARCHAR(15),
CONSTRAINT FK_DONDATHANG FOREIGN KEY(MAKH) REFERENCES dbo.KHACHHANG (MAKH),
CONSTRAINT PK_DONDATHANG PRIMARY KEY(MADDH))
GO
-- Tạo bảng phiếu thu
CREATE TABLE PHIEUTHU(
MAPHIEUTHU VARCHAR(15),
MADDH VARCHAR(15),
NGAYTHU DATE,
SOTIENTHU INT,
CONSTRAINT FK_PHIEUTHU FOREIGN KEY(MADDH) REFERENCES dbo.DONDATHANG(MADDH),
CONSTRAINT PK_PHIEUTHU PRIMARY KEY(MAPHIEUTHU))
GO
-- Tạo bảng phiếu giao hàng
CREATE TABLE PHIEUGIAOHANG(
MAPHIEUGIAOHANG VARCHAR(15),
MADDH VARCHAR(15),
GHICHU NVARCHAR(35),
CONSTRAINT FK_PHIEUGIAOHANG FOREIGN KEY(MADDH) REFERENCES dbo.DONDATHANG(MADDH),
CONSTRAINT PK_PHIEUGIAOHANG PRIMARY KEY(MAPHIEUGIAOHANG))
GO
-- Tạo bảng nhân viên
CREATE TABLE NHANVIEN(
MANV VARCHAR(15),
HOTEN NVARCHAR(30),
GIOITINH NVARCHAR(5),
NGAYSINH DATE,
DIACHI NVARCHAR(30),
DIENTHOAI VARCHAR(10),
NGAYVAOLAM DATE,
GHICHU NVARCHAR(35),
CONSTRAINT PK_NHANVIEN PRIMARY KEY(MANV))
GO
-- Tạo bảng nhà cung cấp
CREATE TABLE NHACUNGCAP(
MANCC VARCHAR(15),
TENNCC NVARCHAR(30),
DIACHI NVARCHAR(30),
DIENTHOAI VARCHAR(10),
EMAIL VARCHAR(25),
CONSTRAINT PK_NHACUNGCAP PRIMARY KEY(MANCC))
GO
-- Tạo bảng hợp đồng cung cấp
CREATE TABLE HOPDONGCUNGCAP(
MAHD VARCHAR(15),
MANCC VARCHAR(15), 
CONSTRAINT FK_HOPDONGNHACUNGCAP FOREIGN KEY(MANCC) REFERENCES dbo.NHACUNGCAP(MANCC),
CONSTRAINT PK_HOPDONGNHACUNGCAP PRIMARY KEY(MAHD))
GO
-- Tạo bảng phiếu chi
CREATE TABLE PHIEUCHI(
MAPHIEUCHI VARCHAR(15),
MAHD VARCHAR(15),
MANV VARCHAR(15),
NGAYLAPPC DATE,
SOTIENCHI INT,
CONSTRAINT FK_PHIEUCHI_HOPDONGCUNGCAP FOREIGN KEY(MAHD) REFERENCES dbo.HOPDONGCUNGCAP(MAHD),
CONSTRAINT FK_PHIEUCHI_NHANVIEN FOREIGN KEY(MANV) REFERENCES dbo.NHANVIEN(MANV),
CONSTRAINT PK_PHIEUCHI PRIMARY KEY(MAPHIEUCHI))
GO
-- Tạo bảng nhóm sản phẩm
CREATE TABLE NHOMSANPHAM(
MANHOMSP VARCHAR(15),
TENNHOMSP NVARCHAR(30),
CONSTRAINT PK_NHOMSANPHAM PRIMARY KEY(MANHOMSP))
GO
-- Tạo bảng sản phẩm
CREATE TABLE SANPHAM(
MASANPHAM VARCHAR(15),
TENSANPHAM NVARCHAR(30),
GIABAN INT,
SOLUONGTON INT,
MANHOMSP VARCHAR(15),
NUOCSX NVARCHAR(15),
NGAYSX DATE,
HANSD DATE,
CONSTRAINT FK_SANPHAM FOREIGN KEY(MANHOMSP) REFERENCES dbo.NHOMSANPHAM(MANHOMSP),
CONSTRAINT PK_SANPHAM PRIMARY KEY(MASANPHAM))
GO 
-- Tạo bảng chi tiết phiếu giao hàng
CREATE TABLE CHITIET_PGH(
MAPHIEUGIAOHANG VARCHAR(15),
MASANPHAM VARCHAR(15),
NGAYGIAOHANG DATE,
CONSTRAINT FK_CHITIETPGH_PHIEUGIAOHANG FOREIGN KEY(MAPHIEUGIAOHANG) REFERENCES dbo.PHIEUGIAOHANG(MAPHIEUGIAOHANG),
CONSTRAINT FK_CHITIETPGH_SANPHAM FOREIGN KEY(MASANPHAM) REFERENCES dbo.SANPHAM(MASANPHAM),
CONSTRAINT PK_CHITIET_PGH PRIMARY KEY(MAPHIEUGIAOHANG, MASANPHAM)
)
GO
-- Tạo bảng chi tiết hợp đồng cung cấp
CREATE TABLE CHITIET_HDCCAP(
MAHD VARCHAR(15),
MASANPHAM VARCHAR(15),
SOLUONG INT,
THANHTIEN INT,
CONSTRAINT FK_CHITIET_HDCCAP_HOPDONGCUNGCAP FOREIGN KEY(MAHD) REFERENCES dbo.HOPDONGCUNGCAP(MAHD),
CONSTRAINT FK_CHITIET_HDCCAP_SANPHAM FOREIGN KEY(MASANPHAM) REFERENCES dbo.SANPHAM(MASANPHAM),
CONSTRAINT PK_CHITIET_HDCCAP PRIMARY KEY(MAHD,MASANPHAM))
GO
-- Tạo bảng chi tiết đơn đặt hàng
CREATE TABLE CHITIET_DDH(
MADDH VARCHAR(15),
MASANPHAM VARCHAR(15),
NGAYDATHANG DATE,
SOLUONG INT,
CONSTRAINT FK_CHITIET_DDH_DONDATHANG FOREIGN KEY(MADDH) REFERENCES dbo.DONDATHANG(MADDH),
CONSTRAINT FK_CHITIET_DDH_SANPHAM FOREIGN KEY(MASANPHAM) REFERENCES dbo.SANPHAM(MASANPHAM),
CONSTRAINT PK_CHITIET_DDH PRIMARY KEY(MADDH,MASANPHAM))
GO

