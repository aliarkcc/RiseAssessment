USE [RiseConsultingWork]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 05.03.2022 17:29:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactInfos]    Script Date: 05.03.2022 17:29:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactInfos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DirectoryId] [int] NOT NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[Email] [nvarchar](max) NULL,
	[Location] [nvarchar](max) NULL,
 CONSTRAINT [PK_ContactInfos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Directories]    Script Date: 05.03.2022 17:29:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Directories](
	[DirectoryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[Company] [nvarchar](max) NULL,
 CONSTRAINT [PK_Directories] PRIMARY KEY CLUSTERED 
(
	[DirectoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20220303210858_AddDatabaseAndAddTable', N'5.0.14')
GO
SET IDENTITY_INSERT [dbo].[ContactInfos] ON 

INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (1, 1, N'5315249824', N'mali@mali.com', N'ERZINCAN')
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (2, 1, N'6854654328', N'mehmet@mali.com', N'ERZINCAN')
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (3, 1, N'6546787868', N'', N'ERZINCAN')
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (4, 2, N'6542344577', NULL, N'BURSA')
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (5, 2, N'5643243455', N'asd@mali.com', N'DIYARBAKIR')
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (6, 2, N'6548748963', NULL, N'ÇANAKKALE')
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (7, 3, N'4564875454', NULL, N'ERZINCAN')
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (8, 3, N'4585416542', NULL, N'KARS')
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (9, 3, N'8754154546', NULL, N'BURSA')
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (10, 3, N'5467841321', N'asd1@mali.com', N'EDİRNE')
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (11, 3, N'5878941134', NULL, N'DIYARBAKIR')
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (12, 3, N'9875213546', NULL, N'BURSA')
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (13, 4, N'5794313248', NULL, NULL)
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (14, 4, N'5784321287', N'dsv@mali.com', N'ERZINCAN')
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (15, 4, N'6857651321', N'dgm@mali.com', N'EDİRNE')
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (16, 4, N'6545234567', N'bln@mali.com', N'KARS')
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (18, 1, N'5315564211', NULL, NULL)
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (19, 2, N'5798423611', NULL, NULL)
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (20, 3, N'4187465145', NULL, NULL)
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (21, 4, N'8765121567', NULL, NULL)
INSERT [dbo].[ContactInfos] ([Id], [DirectoryId], [PhoneNumber], [Email], [Location]) VALUES (22, 5, N'5749876521', NULL, NULL)
SET IDENTITY_INSERT [dbo].[ContactInfos] OFF
GO
SET IDENTITY_INSERT [dbo].[Directories] ON 

INSERT [dbo].[Directories] ([DirectoryId], [Name], [Surname], [Company]) VALUES (1, N'Mehmet', N'Arkaç', N'BLN1')
INSERT [dbo].[Directories] ([DirectoryId], [Name], [Surname], [Company]) VALUES (2, N'Ahmet', N'Öz', N'DSV')
INSERT [dbo].[Directories] ([DirectoryId], [Name], [Surname], [Company]) VALUES (3, N'Caner', N'Hak', N'DGM')
INSERT [dbo].[Directories] ([DirectoryId], [Name], [Surname], [Company]) VALUES (4, N'Sultan', N'Görgülü', N'TRENDYOL')
INSERT [dbo].[Directories] ([DirectoryId], [Name], [Surname], [Company]) VALUES (5, N'Emre', N'Arı', N'DELL')
INSERT [dbo].[Directories] ([DirectoryId], [Name], [Surname], [Company]) VALUES (6, N'İrfan', N'Şen', N'HP')
INSERT [dbo].[Directories] ([DirectoryId], [Name], [Surname], [Company]) VALUES (9, N'Sultan', N'Aslan', N'ARTI ARTI')
INSERT [dbo].[Directories] ([DirectoryId], [Name], [Surname], [Company]) VALUES (10, N'Fuat', N'Öztürk', N'Apple')
INSERT [dbo].[Directories] ([DirectoryId], [Name], [Surname], [Company]) VALUES (11, N'Seyda', N'Oturak', NULL)
INSERT [dbo].[Directories] ([DirectoryId], [Name], [Surname], [Company]) VALUES (12, N'Sinem', N'Başkabak', NULL)
INSERT [dbo].[Directories] ([DirectoryId], [Name], [Surname], [Company]) VALUES (13, N'Kübra', N'Korkmaz', NULL)
INSERT [dbo].[Directories] ([DirectoryId], [Name], [Surname], [Company]) VALUES (14, N'Burcu', N'Demirkıran', NULL)
SET IDENTITY_INSERT [dbo].[Directories] OFF
GO
