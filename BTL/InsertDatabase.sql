-- Bảng CHUDESACH
INSERT INTO CHUDESACH (maChuDe, tenChuDe, tongLuongSach)
VALUES
    ('CD1', N'Văn học kinh điển', 50),
    ('CD2', N'Sách khoa học', 30),
    ('CD3', N'Tiểu thuyết lãng mạn', 20);
go 

-- Bảng NHAXUATBAN
INSERT INTO NHAXUATBAN (maNXB, tenNXB, soDT, diaChi)
VALUES
    ('NXB1', N'Nhà xuất bản Kim Đồng', '0123456789', N'Hà Nội'),
    ('NXB2', N'Nhà xuất bản Trẻ', '0987654321', N'Hồ Chí Minh'),
    ('NXB3', N'Nhà xuất bản NXB1', '0123456789', N'Đà Nẵng');
go

-- Bảng SACH
INSERT INTO SACH (maSach, tenSach, namXB, anhBia, moTa, giaSach, soBanLuu, soTrang, tinhTrang, ngonNgu, maTacGia, maChuDe, maNXB)
VALUES
    ('S1', N'Tiếng Chim Hót Trong Bụi Mận', '2022-01-01', 'anh1.jpg', N'Một tiểu thuyết đầy cảm xúc về tình yêu và hy vọng.', 250000, 50, 300, N'Còn hàng', N'Tiếng Việt', 'TG1', 'CD1', 'NXB1'),
    ('S2', N'Bí Mật Của Tôi', '2021-09-15', 'anh2.jpg', N'Một cuốn sách hồi ký đầy cảm động về cuộc đời tác giả.', 180000, 30, 200, N'Còn hàng', N'Tiếng Việt', 'TG2', 'CD2', 'NXB2'),
    ('S3', N'Truyện Kiều', '2010-05-20', 'anh3.jpg', N'Tác phẩm được hoàn thành vào năm 1820 và được coi là kiệt tác của văn học Việt Nam.', 300000, 20, 250, N'Còn hàng', N'Tiếng Việt', 'TG3', 'CD3', 'NXB3')
go

select * from CHUDESACH
select * from NHAXUATBAN
select * from SACH