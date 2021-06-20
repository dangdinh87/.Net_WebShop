GO
CREATE DATABASE NguyenDangDinhDB
GO

CREATE TABLE NguoiDung(
	id NVARCHAR(50),
	TenNV NVARCHAR(50),
	Email NVARCHAR(50),
	SDT NVARCHAR(50),
	DiaChi NVARCHAR(50),
	Quyen INT,
	Usernam NVARCHAR(50) not null,
	Password NVARCHAR(50) not null,
	PRIMARY KEY(id)
)

CREATE TABLE DanhMuc(
	DanhMuc_Id NVARCHAR(50),
	TenLoai NVARCHAR(50),
	PRIMARY KEY(DanhMuc_Id)
)

CREATE TABLE SanPham(
	id NVARCHAR(50),
	TenSP NVARCHAR(50),
	MoTa NVARCHAR(500),
	DonGia decimal,
	DanhMuc_Id NVARCHAR(50),
	HinhAnh NVARCHAR(500),
	PRIMARY KEY(DanhMuc_Id),
	FOREIGN KEY(DanhMuc_Id) REFERENCES dbo.DanhMuc(DanhMuc_Id)
)

CREATE TABLE HoaDon(
	id CHAR(4),
	NgayMua date,
	NguoiDung_Id NVARCHAR(50),
	PRIMARY KEY(id),
	FOREIGN KEY(NguoiDung_Id) REFERENCES dbo.NguoiDung(id)
)


CREATE TABLE ChiTietHoaDon(
	HoaDon_Id NVARCHAR(50) not null,
	SanPham_Id NVARCHAR(50) not null,
	SoLuong INT,
	GiaTien decimal,
	PRIMARY KEY(HoaDon_Id,SanPham_Id),
	FOREIGN KEY(HoaDon_Id) REFERENCES dbo.HoaDon(id),
	FOREIGN KEY(SanPham_Id) REFERENCES dbo.SanPham(id)
)



