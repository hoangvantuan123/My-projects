USE [MvcCRUDDB]
GO
/****** Object:  Table [dbo].[Lop]    Script Date: 05-Aug-2017 8:21:09 PM ******/
IF  EXISTS (SELECT *
FROM sys.objects
WHERE object_id = OBJECT_ID(N'[dbo].[Lop]') AND type in (N'U'))
DROP TABLE [dbo].[Lop]
GO
/****** Object:  Table [dbo].[Lop]    Script Date: 05-Aug-2017 8:21:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT *
FROM sys.objects
WHERE object_id = OBJECT_ID(N'[dbo].[Lop]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Lop]
    (
        [ID] [int] IDENTITY(1,1) NOT NULL,
        [MaSV] [char](15) NULL,
        [TenSV] [nvarchar](50) NULL,
        [MaLop] [nvarchar](50) NULL,
        [TenLop] [nvarchar](70) NULL,


        CONSTRAINT [PK_Lop] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
    ) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
