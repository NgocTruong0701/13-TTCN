create database QLThuVien
go

use QLThuVien
go

create table CHUDESACH (
	maChuDe nchar(10) not null primary key,
	tenChuDe nvarchar(30) not null,
	tongLuongSach int not null
)

create table NHAXUATBAN (
	maNXB nchar(10) not null primary key,
	tenNXB nvarchar(30) not null,
	soDT nvarchar(15) not null,
	diaChi nvarchar(30) not null
)

create table TACGIA (
	maTacGia nchar(10) not null primary key,
	tenTacGia nvarchar(30) not null,
	namSinh datetime not null,
	moTa nvarchar(150) not null,
	anh nvarchar(50)
)

create table SACH (
	maSach nchar(10) not null primary key,
	tenSach nvarchar(30) not null,
	namXB datetime not null,
	anhBia nvarchar(50),
	moTa nvarchar(150) not null,
	giaSach money not null,
	soBanLuu int not null,
	soTrang int not null,
	tinhTrang nvarchar(20) not null,
	ngonNgu nvarchar(20) not null,
	maTacGia nchar(10) not null,
	maChuDe nchar(10) not null, 
	maNXB nchar(10) not null

	foreign key (maTacGia) references TACGIA(maTacGia),
	foreign key (maChuDe) references CHUDESACH(maChuDe),
	foreign key (maNXB) references NHAXUATBAN(maNXB)
)

create table QUANTRIVIEN (
	maQTV nchar(10) not null primary key,
	tenQTV nvarchar(30) not null,
	taiKhoan nvarchar(20) not null,
	matKhau nvarchar(20) not null
)

create table NGUOIMUON (
	maNguoiMuon nchar(10) not null primary key,
	tenNguoiMuon nvarchar(30) not null,
	soDT nvarchar(15) not null,
	diaChi nvarchar(30) not null,
	taiKhoan nvarchar(20) not null,
	matKhau nvarchar(20) not null
)

create table PHIEUMUON (
	maPhieuMuon nchar(10) not null primary key,
	ngayMuon datetime not null,
	loaiMuon nvarchar(20) not null,
	tienTheCho money not null,
	ngayTra datetime not null,
	maNguoiMuon nchar(10) not null,

	foreign key (maNguoiMuon) references NGUOIMUON(maNguoiMuon)
)

create table PHIEUMUON_SACH (
	maSach nchar(10) not null,
	maPhieuMuon nchar(10) not null,
	soLuongSachMuon int not null,

	primary key (maSach, maPhieuMuon),

	foreign key (maSach) references SACH(maSach),
	foreign key (maPhieuMuon) references PHIEUMUON(maPhieuMuon)
)

create table PHIEUTRA (
	maPhieuTra nchar(10) not null primary key,
	ngayTra datetime not null,
	tienHoanTra money not null,
	ngayPhat datetime not null,
	maNguoiMuon nchar(10) not null,

	foreign key (maNguoiMuon) references NGUOIMUON(maNguoiMuon)
)

create table PHIEUTRA_SACH (
	maSach nchar(10) not null,
	maPhieuTra nchar(10) not null,
	soLuongSachTra int not null,

	primary key (maSach, maPhieuTra),

	foreign key (maSach) references SACH(maSach),
	foreign key (maPhieuTra) references PHIEUTRA(maPhieuTra)
)

