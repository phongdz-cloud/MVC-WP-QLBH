-- Srore procedure này dùng để thêm sản phẩm
ALTER PROCEDURE spInsertSanPham
@maSP VARCHAR(15)
,@tenSP NVARCHAR(30)
,@giaban int
,@soluongton int
,@manhomsp VARCHAR(15)
,@nuocsx NVARCHAR(15)
,@ngaysx DATE
,@hansd DATE
AS
BEGIN
INSERT INTO dbo.SANPHAM
(
    MASANPHAM,
    TENSANPHAM,
    GIABAN,
    SOLUONGTON,
    MANHOMSP,
    NUOCSX,
    NGAYSX,
    HANSD
)
VALUES
(   @maSP,        -- MASANPHAM - varchar(15)
    @tenSP,       -- TENSANPHAM - nvarchar(30)
    @giaban,         -- GIABAN - int
    @soluongton,         -- SOLUONGTON - int
    @manhomsp,        -- MANHOMSP - varchar(15)
    @nuocsx,       -- NUOCSX - nvarchar(15)
    @ngaysx, -- NGAYSX - date
    @hansd  -- HANSD - date
    )
END
GO
-- Srore procedure này dùng để update khách hàng
ALTER PROCEDURE spUpdateSanPham
@maSP VARCHAR(15)
,@tenSP NVARCHAR(30)
,@giaban int
,@soluongton int
,@manhomsp VARCHAR(15)
,@nuocsx NVARCHAR(15)
,@ngaysx DATE
,@hansd DATE
AS
BEGIN
UPDATE dbo.SANPHAM 
SET TENSANPHAM = @tenSP,
	GIABAN = @giaban,
	SOLUONGTON = @soluongton,
	MANHOMSP = @manhomsp,
	NUOCSX = @nuocsx,
	NGAYSX = @ngaysx,
	HANSD = @hansd
WHERE MASANPHAM = @maSP
END
GO
--Srore procedure này dùng để delete khách hàng
ALTER PROCEDURE spDeleteSanPham
@maSP VARCHAR(15)
AS
BEGIN
DELETE FROM dbo.SANPHAM WHERE MASANPHAM = @maSP
END
GO