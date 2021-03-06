USE [QLBANSACH]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 5/12/2018 12:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Admin](
	[UserAdmin] [varchar](30) NOT NULL,
	[PassAdmin] [varchar](30) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserAdmin] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHUDE]    Script Date: 5/12/2018 12:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUDE](
	[MaCD] [int] IDENTITY(1,1) NOT NULL,
	[TenChuDe] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ChuDe] PRIMARY KEY CLUSTERED 
(
	[MaCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTDATHANG]    Script Date: 5/12/2018 12:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTDATHANG](
	[SoDH] [int] NOT NULL,
	[Masach] [int] NOT NULL,
	[Soluong] [int] NULL,
	[Dongia] [decimal](9, 2) NULL,
	[Thanhtien]  AS ([SoLuong]*[Dongia]),
 CONSTRAINT [PK_CTDatHang] PRIMARY KEY CLUSTERED 
(
	[SoDH] ASC,
	[Masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CTTHAMDO]    Script Date: 5/12/2018 12:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTTHAMDO](
	[MaCH] [int] NOT NULL,
	[STT] [int] NOT NULL,
	[Noidungtraloi] [nvarchar](255) NOT NULL,
	[Solanbinhchon] [int] NULL,
 CONSTRAINT [PK_CTThamDo] PRIMARY KEY CLUSTERED 
(
	[MaCH] ASC,
	[STT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DONDATHANG]    Script Date: 5/12/2018 12:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DONDATHANG](
	[SoDH] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NULL,
	[NgayDH] [smalldatetime] NULL,
	[Trigia] [money] NULL,
	[Dagiao] [bit] NULL DEFAULT ((0)),
	[Ngaygiaohang] [smalldatetime] NULL,
	[Tennguoinhan] [varchar](50) NULL,
	[Diachinhan] [nvarchar](1) NULL,
	[Dienthoainhan] [varchar](15) NULL,
	[HTThanhtoan] [bit] NULL DEFAULT ((0)),
	[HTGiaohang] [bit] NULL DEFAULT ((0)),
 CONSTRAINT [PK_DonDatHang] PRIMARY KEY CLUSTERED 
(
	[SoDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 5/12/2018 12:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[HoTenKH] [nvarchar](50) NOT NULL,
	[DiachiKH] [nvarchar](50) NULL,
	[DienthoaiKH] [varchar](10) NULL,
	[TenDN] [varchar](15) NULL,
	[Matkhau] [varchar](15) NOT NULL,
	[Ngaysinh] [smalldatetime] NULL,
	[Gioitinh] [bit] NULL DEFAULT ((1)),
	[Email] [varchar](50) NULL,
	[Daduyet] [bit] NULL DEFAULT ((0)),
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[TenDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[NHAXUATBAN]    Script Date: 5/12/2018 12:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHAXUATBAN](
	[MaNXB] [int] IDENTITY(1,1) NOT NULL,
	[TenNXB] [nvarchar](100) NOT NULL,
	[Diachi] [nvarchar](150) NULL,
	[DienThoai] [nvarchar](15) NULL,
 CONSTRAINT [PK_NhaXuatBan] PRIMARY KEY CLUSTERED 
(
	[MaNXB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[QUANGCAO]    Script Date: 5/12/2018 12:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[QUANGCAO](
	[STT] [int] IDENTITY(1,1) NOT NULL,
	[TenCty] [nvarchar](200) NOT NULL,
	[Hinhminhhoa] [varchar](20) NULL,
	[Href] [varchar](100) NULL,
	[Ngaybatdau] [smalldatetime] NULL,
	[Ngayhethan] [smalldatetime] NULL,
 CONSTRAINT [PK_QuangCao] PRIMARY KEY CLUSTERED 
(
	[STT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SACH]    Script Date: 5/12/2018 12:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SACH](
	[Masach] [int] IDENTITY(1,1) NOT NULL,
	[Tensach] [nvarchar](100) NOT NULL,
	[Donvitinh] [nvarchar](50) NULL DEFAULT ('cu?n'),
	[Dongia] [money] NULL,
	[Mota] [ntext] NULL,
	[Hinhminhhoa] [varchar](50) NULL,
	[MaCD] [int] NULL,
	[MaNXB] [int] NULL,
	[Ngaycapnhat] [smalldatetime] NULL,
	[Soluongban] [int] NULL,
	[solanxem] [int] NULL DEFAULT ((0)),
	[moi] [int] NULL,
 CONSTRAINT [PK_Sach] PRIMARY KEY CLUSTERED 
(
	[Masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TACGIA]    Script Date: 5/12/2018 12:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TACGIA](
	[MaTG] [int] IDENTITY(1,1) NOT NULL,
	[TenTG] [nvarchar](50) NOT NULL,
	[DiachiTG] [nvarchar](100) NULL,
	[DienthoaiTG] [varchar](15) NULL,
 CONSTRAINT [PK_TacGia] PRIMARY KEY CLUSTERED 
(
	[MaTG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[THAMDO]    Script Date: 5/12/2018 12:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THAMDO](
	[MaCH] [int] IDENTITY(1,1) NOT NULL,
	[Ngaydang] [smalldatetime] NULL,
	[Noidungthamdo] [nvarchar](255) NOT NULL,
	[Tongsobinhchon] [int] NULL,
 CONSTRAINT [PK_ThamDo] PRIMARY KEY CLUSTERED 
(
	[MaCH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VIETSACH]    Script Date: 5/12/2018 12:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VIETSACH](
	[MaTG] [int] NOT NULL,
	[Masach] [int] NOT NULL,
	[Vaitro] [nvarchar](30) NULL,
 CONSTRAINT [PK_VietSach] PRIMARY KEY CLUSTERED 
(
	[MaTG] ASC,
	[Masach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[CTTHAMDO] ADD  DEFAULT ((0)) FOR [Solanbinhchon]
GO
ALTER TABLE [dbo].[THAMDO] ADD  DEFAULT ((0)) FOR [Tongsobinhchon]
GO
ALTER TABLE [dbo].[CTDATHANG]  WITH CHECK ADD  CONSTRAINT [FK_CTDatHang_DonDatHang] FOREIGN KEY([SoDH])
REFERENCES [dbo].[DONDATHANG] ([SoDH])
GO
ALTER TABLE [dbo].[CTDATHANG] CHECK CONSTRAINT [FK_CTDatHang_DonDatHang]
GO
ALTER TABLE [dbo].[CTDATHANG]  WITH CHECK ADD  CONSTRAINT [FK_CTDatHang_Sach] FOREIGN KEY([SoDH])
REFERENCES [dbo].[SACH] ([Masach])
GO
ALTER TABLE [dbo].[CTDATHANG] CHECK CONSTRAINT [FK_CTDatHang_Sach]
GO
ALTER TABLE [dbo].[CTTHAMDO]  WITH CHECK ADD  CONSTRAINT [FK_CTThamDo_ThamDo] FOREIGN KEY([MaCH])
REFERENCES [dbo].[THAMDO] ([MaCH])
GO
ALTER TABLE [dbo].[CTTHAMDO] CHECK CONSTRAINT [FK_CTThamDo_ThamDo]
GO
ALTER TABLE [dbo].[DONDATHANG]  WITH CHECK ADD  CONSTRAINT [FK_DonDatHang_KhachHang] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KHACHHANG] ([MaKH])
GO
ALTER TABLE [dbo].[DONDATHANG] CHECK CONSTRAINT [FK_DonDatHang_KhachHang]
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD  CONSTRAINT [FK_Sach_ChuDe] FOREIGN KEY([MaCD])
REFERENCES [dbo].[CHUDE] ([MaCD])
GO
ALTER TABLE [dbo].[SACH] CHECK CONSTRAINT [FK_Sach_ChuDe]
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD  CONSTRAINT [FK_Sach_NhaXuatBan] FOREIGN KEY([MaNXB])
REFERENCES [dbo].[NHAXUATBAN] ([MaNXB])
GO
ALTER TABLE [dbo].[SACH] CHECK CONSTRAINT [FK_Sach_NhaXuatBan]
GO
ALTER TABLE [dbo].[VIETSACH]  WITH CHECK ADD  CONSTRAINT [FK_VietSach_Sach] FOREIGN KEY([Masach])
REFERENCES [dbo].[SACH] ([Masach])
GO
ALTER TABLE [dbo].[VIETSACH] CHECK CONSTRAINT [FK_VietSach_Sach]
GO
ALTER TABLE [dbo].[VIETSACH]  WITH CHECK ADD  CONSTRAINT [FK_VietSach_TacGia] FOREIGN KEY([MaTG])
REFERENCES [dbo].[TACGIA] ([MaTG])
GO
ALTER TABLE [dbo].[VIETSACH] CHECK CONSTRAINT [FK_VietSach_TacGia]
GO
ALTER TABLE [dbo].[CTDATHANG]  WITH CHECK ADD CHECK  (([Dongia]>=(0)))
GO
ALTER TABLE [dbo].[CTDATHANG]  WITH CHECK ADD CHECK  (([Soluong]>(0)))
GO
ALTER TABLE [dbo].[DONDATHANG]  WITH CHECK ADD CHECK  (([Trigia]>(0)))
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD CHECK  (([Dongia]>=(0)))
GO
ALTER TABLE [dbo].[SACH]  WITH CHECK ADD CHECK  (([Soluongban]>(0)))
GO
/****** Object:  StoredProcedure [dbo].[sp_ThemSach]    Script Date: 5/12/2018 12:24:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[sp_ThemSach]
@MaSach int,
@TenSach nvarchar(100),
@Dongia money,
@Mota ntext,
@maTG_1 int,
@maTG_2 int
as
	if not exists( select * from Tacgia where MaTG = @maTG_1 or MaTG = @maTG_2)
		raiserror('Ma tac gia nay khong ton tai !', 16, 1)
	else if exists( select * from SACH where Masach = @MaSach)
		raiserror('Trung khoa chinh, sach da ton tai !', 16, 1)

	else if exists(select * from TACGIA where @maTG_1 = @maTG_2)
		raiserror('Tac gia khong duoc trung !', 16, 1)
	else
	begin
		set identity_insert SACH on
		insert into SACH(Masach, Tensach, Dongia, Mota)values
		(@MaSach, @TenSach, @Dongia, @Mota)
		set identity_insert SACH off
		insert into VIETSACH(MaTG, Masach) values
		(@maTG_1, @MaSach),
		(@maTG_2, @MaSach)

	end
--
GO
