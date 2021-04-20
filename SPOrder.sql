﻿-- THÊM ĐƠN ĐẶT HÀNG
ALTER PROCEDURE spInsertDonDatHang
@MADDH VARCHAR(15),
@GHICHU NVARCHAR(35),
@MAKH VARCHAR(15),
@MANV VARCHAR(15)
AS
BEGIN
INSERT INTO	 dbo.DONDATHANG
(
    MADDH,
    GHICHU,
    MAKH,
    MANV
)
VALUES
(   @MADDH,  -- MADDH - varchar(15)
    @GHICHU, -- GHICHU - nvarchar(35)
    @MAKH,  -- MAKH - varchar(15)
    @MANV   -- MANV - varchar(15)
    )
END
GO
-- UPDATE ĐƠN ĐẶT HÀNG
ALTER PROCEDURE spDeleteDonDatHang
@MADDH VARCHAR(15)
AS
BEGIN
DELETE FROM dbo.DONDATHANG
WHERE MADDH = @MADDH
END
GO