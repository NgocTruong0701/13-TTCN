use QLThuVien
go

CREATE TRIGGER trg_createSach
ON SACH
AFTER INSERT
AS
BEGIN
    DECLARE @maChuDe nchar(10)
    SET @maChuDe = (SELECT maChuDe FROM inserted)
    
    -- Cập nhật tổng lượng sách sau khi thêm sách
    UPDATE CHUDESACH
    SET tongLuongSach = (SELECT COUNT(*) FROM SACH WHERE maChuDe = @maChuDe)
    WHERE maChuDe = @maChuDe
END;


