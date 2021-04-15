
-- Srore procedure này dùng để thêm khách hàng
CREATE PROCEDURE spInsertKhachHang
@maKH VARCHAR(15)
,@tenKH NVARCHAR(30)
,@gioiTinh NVARCHAR(10)
,@diaChi NVARCHAR(30)
,@dienThoai VARCHAR(15)
,@maLoaiKH VARCHAR(15)
AS
BEGIN
INSERT INTO	 dbo.KHACHHANG
(
    MAKH,
    TENKH,
    GIOITINH,
    DIACHI,
    DIENTHOAI,
    MALOAIKH
)
VALUES
(   @maKH,  -- MAKH - varchar(15)
    @tenKH, -- TENKH - nvarchar(30)
    @gioiTinh, -- GIOITINH - nvarchar(10)
    @diaChi, -- DIACHI - nvarchar(30)
    @dienThoai,  -- DIENTHOAI - varchar(15)
    @maLoaiKH   -- MALOAIKH - varchar(15)
    )
END
GO
-- Srore procedure này dùng để update khách hàng
CREATE PROCEDURE spUpdateKhachHang
@maKH VARCHAR(15)
,@tenKH NVARCHAR(30)
,@gioiTinh NVARCHAR(10)
,@diaChi NVARCHAR(30)
,@dienThoai VARCHAR(15)
,@maLoaiKH VARCHAR(15)
AS
BEGIN
UPDATE dbo.KHACHHANG 
SET	TENKH = @tenKH,
	GIOITINH = @gioiTinh,
	DIACHI = @diaChi,
	DIENTHOAI = @dienThoai,
	MALOAIKH = @maLoaiKH
WHERE MAKH = @maKH
END
GO
--Srore procedure này dùng để delete khách hàng
CREATE PROCEDURE spDeleteKhachHang
@maKH VARCHAR(15)
AS
BEGIN
DELETE dbo.KHACHHANG WHERE MAKH = @maKH
END
GO
