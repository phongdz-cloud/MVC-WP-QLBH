--CHECK
--Bảng PHIEUTHU: số tiền thu không âm
alter table PHIEUTHU
add check(SOTIENTHU>0)
GO
--Bảng SANPHAM: so luong ton và giá bán không âm
alter table SANPHAM
add check(GIABAN>0 and SOLUONGTON>=0)
GO
--Bảng CHITIET_HDCCAP có số luong và thành tiền không âm
alter table CHITIET_HDCCAP
add check(SOLUONG>0 and THANHTIEN>0)
GO
--Bang CHITIET_HD
alter table CHITIET_HD
add check (SOLUONG>0)
GO
--Bảng NHANVIEN: lương không âm và đủ 18 tuổi
alter table NHANVIEN
add check(SALARY>0)
alter table NHANVIEN
add check((year(NGAYVAOLAM)-year(NGAYSINH))>=18)
--trigger
GO
CREATE TRIGGER KT_NGAYBANHANG on	HOADON
AFTER INSERT 
AS
DECLARE @new date,@ol date
SELECT @new=ne.NGAYBANHANG,@ol=nv.NGAYVAOLAM
FROM NHANVIEN nv,inserted ne
WHERE nv.MANV=ne.MANHANVIEN
IF(@new>=@ol)
BEGIN
PRINT N'Add successful data';
END
ELSE
BEGIN
PRINT N'Add failure data';
ROLLBACK
END
drop trigger KT_NGAYBANHANG
----Tổng tiền của một hóa đơn: THANHTIEN=(SOLUONG*GIABAN)
GO
CREATE TRIGGER TONGTIEN ON CHITIET_HD
AFTER INSERT,UPDATE
AS
if((select hd.THANHTIEN
from HOADON hd,inserted ne
where ne.MHD=hd.MAHD)like NULL)
begin
UPDATE HOADON
SET THANHTIEN=0
WHERE ne.MHD=MAHD
end
UPDATE HOADON
SET THANHTIEN=THANHTIEN+sp.GIABAN*ne.SOLUONG
FROM SANPHAM sp ,inserted ne
where ne.MHD=MAHD and sp.MASANPHAM=ne.MASANPHAM
--Tạo view xem thông tin của từng loại sản phẩm có trong hóa đơn( ngày bán, loại sản phẩm nào được bán, gía bán trên thị trường ,số lượng mua từng loại và tiền của từng loại theo số lượng)
create view TT_SANPHAMBANHANG
as
select hd.NGAYBANHANG, hd.MAHD, ct.MASANPHAM, sp.GIABAN,ct.SOLUONG as SOLUONGMUA , Sum(sp.GIABAN*ct.SOLUONG) as THANHTIEN
from HOADON hd, SANPHAM sp, CHITIET_HD ct
where hd.MAHD=ct.MHD and sp.MASANPHAM=ct.MASANPHAM 
group by hd.NGAYBANHANG,hd.MAHD,ct.MASANPHAM ,sp.GIABAN, ct.SOLUONG
-- Tạo view xem thông tin vào những ngày lập phiếu chi , chi cho ai, chi cho sản phẩm nào với giá tiền bao nhiêu
go
create view TT_NHACUNGCAP
as
select pc.NGAYLAPPC, ncc.MANCC, ncc.TENNCC, hdcc.MAHD, cthd.MASANPHAM, sum (cthd.GIAGOC*cthd.SOLUONG)
from NHACUNGCAP ncc,HOPDONGCUNGCAP hdcc, CHITIET_HDCCAP cthd, PHIEUCHI pc,SANPHAM sp
where ncc.MANCC=hdcc.MANCC and cthd.MAHD = hdcc.MAHD and pc.MAHD=hdcc.MAHD and cthd.MASANPHAM=sp.MASANPHAM
group by  pc.NGAYLAPPC, ncc.MANCC, ncc.TENNCC, hdcc.MAHD, cthd.MASANPHAM, cthd.GIAGOC

