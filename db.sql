USE [QLquatrinhbanhang]
GO
/****** Object:  Table [dbo].[tblChaucay]    Script Date: 3/26/2021 8:42:15 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChaucay](
	[Machaucay] [nvarchar](50) NOT NULL,
	[Maloaichaucay] [nvarchar](50) NOT NULL,
	[Tenhaucay] [nvarchar](50) NULL,
	[Kichthuoc] [nvarchar](50) NULL,
	[Dongia] [float] NULL,
	[Anh] [nvarchar](1000) NULL,
	[Soluong] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[Machaucay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblChitiethoadon]    Script Date: 3/26/2021 8:42:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChitiethoadon](
	[Mahoadon] [nvarchar](50) NOT NULL,
	[Machaucay] [nvarchar](50) NOT NULL,
	[Soluong] [float] NULL,
	[Dongia] [float] NULL,
	[Giamgia] [float] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblHoadon]    Script Date: 3/26/2021 8:42:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHoadon](
	[Mahoadon] [nvarchar](50) NOT NULL,
	[Manhanvien] [nvarchar](50) NOT NULL,
	[Makhachhang] [nvarchar](50) NOT NULL,
	[Ngayban] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Mahoadon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblKhachhang]    Script Date: 3/26/2021 8:42:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKhachhang](
	[Makhachhang] [nvarchar](50) NOT NULL,
	[Tenkhachhang] [nvarchar](50) NULL,
	[Diachi] [nvarchar](50) NULL,
	[Dienthoai] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Makhachhang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblLoaichaucay]    Script Date: 3/26/2021 8:42:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLoaichaucay](
	[Maloaichaucay] [nvarchar](50) NOT NULL,
	[Loaichaucay] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Maloaichaucay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tblNhanvien]    Script Date: 3/26/2021 8:42:16 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNhanvien](
	[Manhanvien] [nvarchar](50) NOT NULL,
	[Tennhanvien] [nvarchar](50) NULL,
	[Ngaysinh] [nvarchar](100) NULL,
	[Gioitinh] [nvarchar](50) NULL,
	[Diachi] [nvarchar](50) NULL,
	[Username] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Manhanvien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[tblChitiethoadon]  WITH CHECK ADD FOREIGN KEY([Mahoadon])
REFERENCES [dbo].[tblHoadon] ([Mahoadon])
GO
ALTER TABLE [dbo].[tblHoadon]  WITH CHECK ADD FOREIGN KEY([Makhachhang])
REFERENCES [dbo].[tblKhachhang] ([Makhachhang])
GO
ALTER TABLE [dbo].[tblHoadon]  WITH CHECK ADD FOREIGN KEY([Manhanvien])
REFERENCES [dbo].[tblNhanvien] ([Manhanvien])
GO
