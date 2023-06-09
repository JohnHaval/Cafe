USE [master]
GO
/****** Object:  Database [Cafe]    Script Date: 17.04.2023 22:25:45 ******/
CREATE DATABASE [Cafe]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Cafe', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Cafe.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Cafe_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Cafe_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Cafe] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Cafe].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Cafe] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Cafe] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Cafe] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Cafe] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Cafe] SET ARITHABORT OFF 
GO
ALTER DATABASE [Cafe] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Cafe] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Cafe] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Cafe] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Cafe] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Cafe] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Cafe] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Cafe] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Cafe] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Cafe] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Cafe] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Cafe] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Cafe] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Cafe] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Cafe] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Cafe] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Cafe] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Cafe] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Cafe] SET  MULTI_USER 
GO
ALTER DATABASE [Cafe] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Cafe] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Cafe] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Cafe] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Cafe] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Cafe] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Cafe] SET QUERY_STORE = OFF
GO
USE [Cafe]
GO
/****** Object:  Table [dbo].[Checks]    Script Date: 17.04.2023 22:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Checks](
	[CheckID] [bigint] NOT NULL,
	[Cost] [money] NOT NULL,
	[Discount] [money] NOT NULL,
	[CostNDiscount] [money] NOT NULL,
	[IsComplexLunch] [bit] NOT NULL,
 CONSTRAINT [PK_Checks] PRIMARY KEY CLUSTERED 
(
	[CheckID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Measures]    Script Date: 17.04.2023 22:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Measures](
	[MeasureID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Measures] PRIMARY KEY CLUSTERED 
(
	[MeasureID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 17.04.2023 22:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[HoldCount] [int] NOT NULL,
	[MeasureID] [int] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchases]    Script Date: 17.04.2023 22:25:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchases](
	[PurchaseID] [bigint] NOT NULL,
	[CheckID] [bigint] NOT NULL,
	[ProductID] [int] NOT NULL,
	[ProductCount] [int] NOT NULL,
 CONSTRAINT [PK_Purchase] PRIMARY KEY CLUSTERED 
(
	[PurchaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Checks] ([CheckID], [Cost], [Discount], [CostNDiscount], [IsComplexLunch]) VALUES (1, 480.0000, 0.0000, 480.0000, 1)
INSERT [dbo].[Checks] ([CheckID], [Cost], [Discount], [CostNDiscount], [IsComplexLunch]) VALUES (2, 55.0000, 0.0000, 55.0000, 0)
INSERT [dbo].[Checks] ([CheckID], [Cost], [Discount], [CostNDiscount], [IsComplexLunch]) VALUES (3, 154.0000, 0.0000, 154.0000, 0)
INSERT [dbo].[Checks] ([CheckID], [Cost], [Discount], [CostNDiscount], [IsComplexLunch]) VALUES (4, 614.0000, 30.7000, 583.3000, 0)
INSERT [dbo].[Checks] ([CheckID], [Cost], [Discount], [CostNDiscount], [IsComplexLunch]) VALUES (5, 478.0000, 14.3400, 463.6600, 0)
INSERT [dbo].[Checks] ([CheckID], [Cost], [Discount], [CostNDiscount], [IsComplexLunch]) VALUES (6, 540.0000, 0.0000, 540.0000, 1)
INSERT [dbo].[Checks] ([CheckID], [Cost], [Discount], [CostNDiscount], [IsComplexLunch]) VALUES (7, 300.0000, 9.0000, 291.0000, 0)
INSERT [dbo].[Checks] ([CheckID], [Cost], [Discount], [CostNDiscount], [IsComplexLunch]) VALUES (8, 515.0000, 25.7500, 489.2500, 0)
INSERT [dbo].[Checks] ([CheckID], [Cost], [Discount], [CostNDiscount], [IsComplexLunch]) VALUES (9, 1273.0000, 0.0000, 1273.0000, 1)
INSERT [dbo].[Checks] ([CheckID], [Cost], [Discount], [CostNDiscount], [IsComplexLunch]) VALUES (10, 80.0000, 0.0000, 80.0000, 0)
INSERT [dbo].[Checks] ([CheckID], [Cost], [Discount], [CostNDiscount], [IsComplexLunch]) VALUES (11, 100.0000, 0.0000, 100.0000, 0)
GO
INSERT [dbo].[Measures] ([MeasureID], [Name]) VALUES (1, N'шт')
INSERT [dbo].[Measures] ([MeasureID], [Name]) VALUES (2, N'л')
INSERT [dbo].[Measures] ([MeasureID], [Name]) VALUES (3, N'кг')
INSERT [dbo].[Measures] ([MeasureID], [Name]) VALUES (4, N'мл')
INSERT [dbo].[Measures] ([MeasureID], [Name]) VALUES (5, N'г')
GO
INSERT [dbo].[Products] ([ProductID], [Name], [Price], [HoldCount], [MeasureID]) VALUES (1, N'Борщ', 100.0000, 3, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Price], [HoldCount], [MeasureID]) VALUES (2, N'Суп с фрикадельками', 150.0000, 2, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Price], [HoldCount], [MeasureID]) VALUES (3, N'Капучино', 35.0000, 2, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Price], [HoldCount], [MeasureID]) VALUES (4, N'Чай с лимоном', 24.0000, 24, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Price], [HoldCount], [MeasureID]) VALUES (5, N'Чай с сахаром', 30.0000, 7, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Price], [HoldCount], [MeasureID]) VALUES (6, N'Крабовый салат', 350.0000, 3, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Price], [HoldCount], [MeasureID]) VALUES (7, N'Курица гриль', 120.0000, 4, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Price], [HoldCount], [MeasureID]) VALUES (8, N'Кола (маленькая)', 25.0000, 5, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Price], [HoldCount], [MeasureID]) VALUES (9, N'Кола (средняя)', 35.0000, 5, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Price], [HoldCount], [MeasureID]) VALUES (10, N'Кола (большая)', 45.0000, 18, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Price], [HoldCount], [MeasureID]) VALUES (11, N'Торт "Глазурное вдохновение"', 450.0000, 1, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Price], [HoldCount], [MeasureID]) VALUES (12, N'Пирожки с капустой', 45.0000, 1, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Price], [HoldCount], [MeasureID]) VALUES (13, N'Пирожки с картошкой', 40.0000, 2, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Price], [HoldCount], [MeasureID]) VALUES (14, N'Булочки с сыром', 20.0000, 6, 1)
INSERT [dbo].[Products] ([ProductID], [Name], [Price], [HoldCount], [MeasureID]) VALUES (15, N'Булочка "Моя прелесть"', 34.0000, 3, 1)
GO
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (1, 1, 1, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (2, 1, 6, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (3, 1, 5, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (4, 2, 3, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (5, 2, 14, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (6, 3, 12, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (7, 3, 10, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (8, 3, 4, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (9, 3, 13, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (10, 4, 15, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (11, 4, 14, 3)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (12, 4, 3, 2)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (13, 4, 11, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (14, 5, 6, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (15, 5, 5, 2)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (16, 5, 15, 2)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (17, 6, 1, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (18, 6, 6, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (19, 6, 10, 2)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (20, 7, 13, 2)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (21, 7, 12, 2)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (22, 7, 14, 2)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (23, 7, 10, 2)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (24, 8, 14, 3)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (25, 8, 3, 3)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (26, 8, 6, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (27, 9, 3, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (28, 9, 7, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (29, 9, 15, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (30, 9, 15, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (31, 9, 11, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (32, 9, 6, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (33, 9, 2, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (34, 9, 1, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (35, 10, 3, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (36, 10, 12, 1)
INSERT [dbo].[Purchases] ([PurchaseID], [CheckID], [ProductID], [ProductCount]) VALUES (37, 11, 1, 1)
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Measures] FOREIGN KEY([MeasureID])
REFERENCES [dbo].[Measures] ([MeasureID])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Measures]
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK_Purchases_Checks] FOREIGN KEY([CheckID])
REFERENCES [dbo].[Checks] ([CheckID])
GO
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK_Purchases_Checks]
GO
ALTER TABLE [dbo].[Purchases]  WITH CHECK ADD  CONSTRAINT [FK_Purchases_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ProductID])
GO
ALTER TABLE [dbo].[Purchases] CHECK CONSTRAINT [FK_Purchases_Products]
GO
USE [master]
GO
ALTER DATABASE [Cafe] SET  READ_WRITE 
GO
