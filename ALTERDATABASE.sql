-- Thêm dữ liệu bảng loại khách hàng
INSERT INTO dbo.LOAIKHACHHANG (MALOAIKH, TENLOAI)
VALUES
('D', N'Đồng'),
('B', N'Bạc'),
('V', N'Vàng'),
('BK', N'Bạch kim'),
('KC', N'Kim cương')
GO
-- Thêm dữ liệu bảng khách hàng
INSERT INTO dbo.KHACHHANG (MAKH, TENKH, GIOITINH, DIACHI, DIENTHOAI, MALOAIKH)
VALUES
('KH001', N'Trần Lê Thanh Tuyền', N'Nữ', N'179 Hiệp Bình', '0865765201', 'KC'),
('KH002', N'Trần Thị Khánh Linh', N'Nữ', N'49 Võ Văn Ngân', '0434343436', 'BK'),
('KH003', N'Hoàng Trung Nhật', N'Nam', N'777 Trần Não', '0398765432', 'V'),
('KH004', N'Hồ Hoài Phong', N'Nam', N'82/4 Lê Văn Việt', '0543433301', 'BK'),
('KH005', N'Võ Bảo Long', N'Nam', N'234 Dương Quảng Hàm', '0387659234', 'KC'),
('KH006', N'Nguyễn Hoàng Nhật', N'Nam', N'123 Phạm Văn Đồng', '0887542010', 'KC'),
('KH007', N'Quản Minh Đức', N'Nam', N'45/2 Lý Thường Kiệt', '0123876430', 'B'),
('KH008', N'Trần Duy Nhã', N'Nam', N'234 Lý Chính Thắng', '0456783421', 'V'),
('KH009', N'Nguyễn Trọng Tín', N'Nam', N'12 Chương Dương', '0543234980', 'D'),
('KH010', N'Nguyễn Đắc Thắng', N'Nam', N'10 Hoàng Diệu 2', '0865445410', 'KC'),
('KH011', N'Nguyễn Minh Nhật', N'Nam', N'17/21/1 Hoàng Sa', '0872345210', 'D'),
('KH012', N'Phạm Tấn Trung', N'Nữ', N'25/8 Kha Vạn Cân', '0999876239', 'D'),
('KH013', N'Nguyễn Bảo Trấn', N'Nam', N'99/2 Hoàng Hoa Thám', '0776542025', 'BK'),
('KH014', N'Nguyễn Mai Hoàng', N'Nữ', N'12 Chương Dương', '0889675341', 'V'),
('KH015', N'Đinh Bảo Long', N'Nam', N'11/3/1 Trường Chinh', '0234156239', 'D'),
('KH016', N'Nguyễn Mai Phương Thảo', N'Nữ', N'667 Nguyễn Gia Trí', '0564337685', 'KC'),
('KH017', N'Lê Quốc Vinh', N'Nam', N'67/45 Nguyễn Thái Sơn', '0987345129', 'B'),
('KH018', N'Nguyễn Phước Đăng', N'Nam', N'249 Tam Bình', '0887543129', 'V'),
('KH019', N'Nguyễn Đức Trí', N'Nam', N'16 Cách mạng tháng Tám', '0221345621', 'KC'),
('KH020', N'Nguyễn Minh Đăng', N'Nam', N'111/4 Tô Hiến Thành', '0665743211', 'BK')
GO 
-- Thêm dữ liệu bảng phiếu thu
INSERT INTO dbo.PHIEUTHU(MAPHIEUTHU, MADDH, NGAYTHU, SOTIENTHU)
VALUES
(   'PT001', 'DH002', '2020-12-3', NULL ),
(   'PT002', 'DH001', '2021-1-3', NULL ),
(   'PT003', 'DH002', '2020-4-4', NULL ),
(   'PT004', 'DH006', '2021-1-7', NULL ),
(   'PT005', 'DH009', '2021-2-8', NULL ),
(   'PT006', 'DH007', '2020-12-7', NULL ),
(   'PT007', 'DH010', '2020-5-5', NULL ),
(   'PT008', 'DH007', '2020-11-23', NULL ),
(   'PT009', 'DH006', '2021-3-8', NULL ),
(   'PT010', 'DH008', '2020-10-10', NULL )
GO
-- Thêm dữ liệu bảng phiếu giao hàng
INSERT INTO dbo.PHIEUGIAOHANG (MAPHIEUGIAOHANG, MADDH, GHICHU)
VALUES
(   'PG001', 'DH004', N'Cần nhẹ tay' ),
(   'PG002', 'DH001', N'Giao đúng hạn' ),
(   'PG003', 'DH002', NULL ),
(   'PG004', 'DH001', N'Giao vào buổi sáng' ),
(   'PG005', 'DH010', NULL ),
(   'PG006', 'DH008', NULL ),
(   'PG007', 'DH007', N'Giao vào chủ nhật' ),
(   'PG008', 'DH001', NULL ),
(   'PG009', 'DH002', N'Cần nhẹ tay' ),
(   'PG010', 'DH004', NULL )
GO
-- Thêm dữ liệu bảng nhân viên
INSERT INTO dbo.NHANVIEN (MANV, HOTEN, GIOITINH, NGAYSINH, DIACHI, DIENTHOAI, NGAYVAOLAM, GHICHU)
VALUES
(   'NV001', N'Trần Thanh Chi', N'Nữ', '2001-12-12', N'27/12/2 Hoàn Văn Thụ', '0843321394', '2020-6-6', N'Hoạt ngôn' ),
(   'NV002', N'Lê Nguyễn Ngọc Vũ', N'Nam', '2001-4-4', N'265/10 Hùng Vương', '0954321043', '2020-4-16', N'Toeic 700' ),
(   'NV003', N'Kiều Thúy Vy', N'Nữ', '2000-10-2', N'28 Dân Chủ', '0786453201', '2020-7-1', NULL ),
(   'NV004', N'Lê Đắc Viên', N'Nam', '1999-1-12', N'17/2 Võ Văn Kiệt', '0888345202', '2020-6-20', NULL ),
(   'NV005', N'Huỳnh Trường Vũ', N'Nam', '1997-10-27', N'784 Cống Quỳnh', '0994324235', '2020-10-10', N'Bằng giỏi Tin học văn phòng' ),
(   'NV006', N'Huỳnh Thái Thành', N'Nam', '2000-3-10', N'111/5/2 Cộng Hòa', '0854332043', '2021-1-6', NULL ),
(   'NV007', N'Trần Đình Nghi Dung', N'Nữ', '1995-4-1', N'90/5 Phạm Ngũ Lão', '0994345211', '2020-5-9', NULL ),
(   'NV008', N'Nguyễn Thị Ngọc Mai', N'Nữ', '1998-2-12', N'765/12 Trần Hưng Đạo', '0775432942', '2020-11-6', N'Toeic 750' ),
(   'NV009', N'Đặng Minh Triều', N'Nam', '1992-4-5', N'1012 Âu Cơ', '0945554545', '2021-2-2', NULL ),
(   'NV010', N'Trần Đông Thịnh', N'Nam', '1998-12-25', N'45/12/2 Lạc Long Quân', '0345554204', '2020-11-9', NULL )
GO
-- Thêm dữ liệu bảng đơn đặt hàng
INSERT INTO dbo.DONDATHANG (MADDH, GHICHU, MAKH, MANV)
VALUES
(   'DH001', N'Đóng gói trong bao bì màu hồng', 'KH012', 'NV002' ),
(   'DH002', N'Đóng gói trong bao bì giấy', 'KH012', 'NV002' ),
(   'DH003', NULL, 'KH002', 'NV007' ),
(   'DH004', NULL, 'KH005','NV010' ),
(   'DH005', N'Đóng gói trong bao bì màu đen', 'KH020','NV006' ),
(   'DH006', NULL, 'KH013', 'NV001' ),
(   'DH007', NULL, 'KH020','NV008' ),
(   'DH008', N'Hàng cần được giao sớm', 'KH011','NV007' ),
(   'DH009', NULL, 'KH013','NV006' ),
(   'DH010', N'Sản phẩm không được trầy xước', 'KH014','NV004' ),
(   'DH011', NULL, 'KH013','NV009' ),
(   'DH012', NULL, 'KH001','NV005' ),
(   'DH013', N'Sản phẩm không được trầy xước', 'KH008','NV008' ),
(   'DH014', NULL, 'KH007','NV003' ),
(   'DH015', N'Sản phẩm không được trầy xước', 'KH011','NV004' )
GO
-- Thêm dữ liệu bảng nhà cung cấp
INSERT INTO dbo.NHACUNGCAP (MANCC, TENNCC, DIACHI, DIENTHOAI, EMAIL)
VALUES 
(   'NCC001', N'XPRO', N'186 Võ Văn Ngân', '0454323291','xprovietnam@gmail.com' ),
(   'NCC002', N'VNGROUP', N'234 Lê Quang Định', '0985673203','vngroup@gmail.com' ),
(   'NCC003', N'SGTECHNOLOGY', N'111 Phạm Văn Đồng', '0843332912','sgtechnology.com' ),
(   'NCC004', N'HCMFOOD', N'321 Lý Chính Thắng', '0943432321','hcmfood.com' ),
(   'NCC005', N'DLVEGETABLE', N'103 Trường Chinh', '0546323944','dlvegetable@gmail.com' ),
(   'NCC006', N'SIMMAX', N'113 Hoàng Diệu', '0876432983','simmax@gmail.com' ),
(   'NCC007', N'BIBOO', N'345 Âu Cơ', '0943232654','biboovn@gmail.com' )
GO
-- Thêm dữ liệu bảng hợp đồng cung cấp
INSERT INTO dbo.HOPDONGCUNGCAP (MAHD, MANCC)
VALUES
(   'HD001', 'NCC007' ),
(   'HD002', 'NCC005' ),
(   'HD003', 'NCC001' ),
(   'HD004', 'NCC007' ),
(   'HD005', 'NCC003' ),
(   'HD006', 'NCC004' ),
(   'HD007', 'NCC003' ),
(   'HD008', 'NCC006' ),
(   'HD009', 'NCC006' ),
(   'HD010', 'NCC002' )
GO
-- Thêm dữ liệu bảng phiếu chi
INSERT INTO dbo.PHIEUCHI (MAPHIEUCHI, MAHD, MANV, NGAYLAPPC, SOTIENCHI)
VALUES
(   'PC001', 'HD008', 'NV002', '2020-8-8', NULL  ),
(   'PC002', 'HD008', 'NV003', '2021-1-8', NULL  ),
(   'PC003', 'HD002', 'NV003', '2021-2-12', NULL  ),
(   'PC004', 'HD003', 'NV001', '2020-12-3', NULL  ),
(   'PC005', 'HD002', 'NV008', '2021-2-8', NULL  ),
(   'PC006', 'HD005', 'NV009', '2020-3-10', NULL  ),
(   'PC007', 'HD010', 'NV005', '2020-12-8', NULL  ),
(   'PC008', 'HD009', 'NV005', '2021-2-2', NULL  ),
(   'PC009', 'HD007', 'NV010', '2020-12-10', NULL  ),
(   'PC010', 'HD008', 'NV004', '2020-11-8', NULL  )
GO
-- Thêm dữ liệu bảng nhóm sản phẩm
INSERT INTO dbo.NHOMSANPHAM (MANHOMSP, TENNHOMSP)
VALUES
(   'NSP001', N'Đồ gia dụng'),
(   'NSP002', N'Đồ điện tử'),
(   'NSP003', N'Quần áo'),
(   'NSP004', N'Thực phẩm tươi sống'),
(   'NSP005', N'Bánh kẹo'),
(   'NSP006', N'Mỹ phẩm'),
(   'NSP007', N'Nước uống')
GO
-- Thêm dữ liệu bảng sản phẩm
INSERT INTO dbo.SANPHAM (MASANPHAM, TENSANPHAM, GIABAN, SOLUONGTON, MANHOMSP, NUOCSX, NGAYSX, HANSD)
VALUES
(   'SP001', N'Nồi inox', 200000, 10, 'NSP001', N'Thái Lan'),
(   'SP002', N'Chảo chống dính', 230000,8, 'NSP001', N'Việt Nam'),
(   'SP003', N'Ly thủy tinh', 50000, 20, 'NSP001', N'Thái Lan'),
(   'SP004', N'Chén sứ', 40000, 16, 'NSP001', N'Lào'),
(   'SP005', N'Bếp điện', 500000, 5, 'NSP002', N'Nhật'),
(   'SP006', N'Lò vi sóng', 1500000, 6, 'NSP002', N'Mỹ'),
(   'SP007', N'Máy xay sinh tố', 450000, 3, 'NSP002', N'Pháp'),
(   'SP008', N'Nồi chiên không dầu', 1550000, 2, 'NSP002', N'Nhật'),
(   'SP009', N'Điện thoại', 10000000, 7, 'NSP002', N'Mỹ'),
(   'SP010', N'Máy ảnh', 15000000, 5, 'NSP002', N'Nhật')
INSERT INTO dbo.SANPHAM (MASANPHAM, TENSANPHAM, GIABAN, SOLUONGTON, MANHOMSP, NUOCSX, NGAYSX, HANSD)
VALUES
(   'SP011', N'Áo thun', 200000, 15, 'NSP003', N'Việt Nam'),
(   'SP012', N'Quần jeans', 400000, 10, 'NSP003',N'Trung Quốc'),
(   'SP013', N'Đầm', 350000, 8, 'NSP003', N'Hàn'),
(   'SP014', N'Chân váy', 300000, 6, 'NSP003', N'Việt Nam'),
(   'SP015', N'Thịt', 100000, 12, 'NSP004', N'Việt Nam'),
(   'SP016', N'Cá', 150000, 10, 'NSP004', N'Việt Nam'),
(   'SP017', N'Trứng', 30000, 70, 'NSP004', N'Việt Nam'),
(   'SP018', N'Rau', 20000, 25, 'NSP004', N'Việt Nam'),
(   'SP019', N'Trái cây', 35000, 30, 'NSP004', N'Việt Nam'),
(   'SP020', N'Bánh mì sandwich', 15000, 10, 'NSP005', N'Việt Nam')
INSERT INTO dbo.SANPHAM (MASANPHAM, TENSANPHAM, GIABAN, SOLUONGTON, MANHOMSP, NUOCSX, NGAYSX, HANSD)
VALUES
(   'SP021', N'Bánh quy', 40000, 15, 'NSP004', N'Nhật'),
(   'SP022', N'Bánh bông lan', 45000, 8, 'NSP004', N'Việt Nam'),
(   'SP023', N'Bánh trứng', 50000, 12, 'NSP004', N'Mỹ'),
(   'SP024', N'Kẹo viên', 14000, 20, 'NSP004', N'Việt Nam'),
(   'SP025', N'Chocolate', 120000, 24, 'NSP004', N'Pháp'),
(   'SP026', N'Kẹo dẻo', 30000, 30, 'NSP004', N'Nhật'),
(   'SP027', N'Rau củ sấy', 50000, 15, 'NSP004', N'Việt Nam'),
(   'SP028', N'Kem chống nắng', 50000, 14, 'NSP005', N'Nhật'),
(   'SP029', N'Sữa rửa mặt', 45000, 15, 'NSP005', N'Thái Lan'),
(   'SP030', N'Sữa tắm', 150000, 7, 'NSP005', N'Việt Nam'),
(   'SP031', N'Sữa dưỡng thể', 180000, 17, 'NSP005', N'Hàn'),
(   'SP032', N'Son môi', 250000, 9, 'NSP005', N'Hàn'),
(   'SP033', N'Chì kẻ mắt', 150000, 11, 'NSP005', N'Hàn'),
(   'SP034', N'Mascara', 180000, 7, 'NSP005', N'Mỹ'),
(   'SP035', N'Mặt nạ', 25000, 17, 'NSP005', N'Pháp'),
(   'SP036', N'Nước có ga', 10000, 50, 'NSP006', N'Việt Nam'),
(   'SP037', N'Nước suối', 7000, 30, 'NSP006', N'Việt Nam'),
(   'SP038', N'Bia', 18000, 70, 'NSP006', N'Mỹ'),
(   'SP039', N'Trà', 16000, 30, 'NSP006', N'Pháp'),
(   'SP040', N'Cafe', 14000, 38, 'NSP006', N'Việt Nam')
GO
-- Nhập dữ liệu bảng chi tiết phiếu giao hàng
INSERT INTO dbo.CHITIET_PGH (MAPHIEUGIAOHANG, MASANPHAM, NGAYGIAOHANG)
VALUES
(   'PG001', 'SP012','2021-3-13'),
(   'PG002', 'SP030','2021-8-3'),
(   'PG003', 'SP002','2020-9-1'),
(   'PG004', 'SP034','2021-1-25'),
(   'PG005', 'SP034','2021-5-23'),
(   'PG006', 'SP024','2020-10-9'),
(   'PG007', 'SP017','2021-5-8'),
(   'PG008', 'SP009','2020-7-7'),
(   'PG009', 'SP040','2020-8-5'),
(   'PG010', 'SP025','2021-2-14')
GO
--Nhập dữ liệu bảng chi tiết hợp đồng cung cấp
INSERT INTO dbo.CHITIET_HDCCAP (MAHD, MASANPHAM, SOLUONG, THANHTIEN)
VALUES
(   'HD001', 'SP012', 18, NULL ),
(   'HD001', 'SP005', 10, NULL ),
(   'HD002', 'SP034', 20, NULL ),
(   'HD003', 'SP021', 7, NULL ),
(   'HD005', 'SP034', 40, NULL ),
(   'HD006', 'SP007', 5, NULL ),
(   'HD008', 'SP001', 7, NULL ),
(   'HD006', 'SP012', 3, NULL ),
(   'HD004', 'SP015', 30, NULL ),
(   'HD009', 'SP023', 27, NULL )
GO
-- Nhập dữ liệu bảng chi tiết đơn đặt hàng
INSERT INTO dbo.CHITIET_DDH (MADDH, MASANPHAM, NGAYDATHANG, SOLUONG)
VALUES
(   'DH005', 'SP010','2020-1-4', 3 ),
(   'DH002', 'SP032','2020-12-24', 5 ),
(   'DH004', 'SP022','2020-3-18', 15 ),
(   'DH009', 'SP011','2021-4-2', 3 ),
(   'DH005', 'SP007','2021-10-2', 3 ),
(   'DH001', 'SP036','2021-9-25', 10 ),
(   'DH006', 'SP017','2021-5-17', 30 ),
(   'DH008', 'SP015','2021-4-4', 7 ),
(   'DH002', 'SP038','2021-4-5', 10 ),
(   'DH007', 'SP040','2020-9-9', 30 )

