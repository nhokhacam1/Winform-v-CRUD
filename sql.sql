USE [DemoCURD]
GO
/****** Object:  Table [dbo].[StudentsTB]    Script Date: 3/22/2021 4:14:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentsTB](
	[StudentID] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[FatherName] [nvarchar](50) NULL,
	[RollNumber] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Mobile] [nvarchar](15) NULL
) ON [PRIMARY]
GO
INSERT [dbo].[StudentsTB] ([StudentID], [Name], [FatherName], [RollNumber], [Address], [Mobile]) VALUES (NULL, N'dd', N'dd', N'666', N'fffs', N'6766')
INSERT [dbo].[StudentsTB] ([StudentID], [Name], [FatherName], [RollNumber], [Address], [Mobile]) VALUES (NULL, N'fffff', N'ffff', N'77', N'777', N'ee')
INSERT [dbo].[StudentsTB] ([StudentID], [Name], [FatherName], [RollNumber], [Address], [Mobile]) VALUES (NULL, N'hfth', N'dfb', N'dfb', N'dfb', N'dfb')
GO
