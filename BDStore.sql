USE [master]
GO
/****** Object:  Database [BdStore]    Script Date: 08/06/2023 11:07:23 ******/
CREATE DATABASE [BdStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BdStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BdStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BdStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\BdStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BdStore] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BdStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BdStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BdStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BdStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BdStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BdStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [BdStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BdStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BdStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BdStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BdStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BdStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BdStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BdStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BdStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BdStore] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BdStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BdStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BdStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BdStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BdStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BdStore] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [BdStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BdStore] SET RECOVERY FULL 
GO
ALTER DATABASE [BdStore] SET  MULTI_USER 
GO
ALTER DATABASE [BdStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BdStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BdStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BdStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BdStore] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BdStore', N'ON'
GO
ALTER DATABASE [BdStore] SET QUERY_STORE = OFF
GO
USE [BdStore]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 08/06/2023 11:07:24 ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 08/06/2023 11:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[IdInvoice] [int] IDENTITY(1,1) NOT NULL,
	[CreationDate] [datetime2](7) NOT NULL,
	[ClientName] [nvarchar](50) NOT NULL,
	[ClientLastName] [nvarchar](50) NOT NULL,
	[ClientAddress] [nvarchar](100) NOT NULL,
	[ClientPhone] [nvarchar](12) NOT NULL,
	[SubTotal] [decimal](18, 2) NOT NULL,
	[Discount] [decimal](18, 2) NOT NULL,
	[Iva] [decimal](18, 2) NOT NULL,
	[TotalInvoice] [decimal](18, 2) NOT NULL,
	[ClientDocument] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
(
	[IdInvoice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 08/06/2023 11:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProduct] [int] NOT NULL,
	[IdInvoice] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[SalePrice] [decimal](18, 2) NOT NULL,
	[TotalSale] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_InvoiceDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 08/06/2023 11:07:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Code] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[ProductName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230607181955_initialmigration', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230607185408_addInvoiceTable', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230607194022_alterTableInvoice', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230608005704_alterTableInvoice_2', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230608025305_alterTableInvoice_3', N'6.0.16')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230608155752_updateInvoiceEntoty', N'6.0.16')
SET IDENTITY_INSERT [dbo].[Invoice] ON 

INSERT [dbo].[Invoice] ([IdInvoice], [CreationDate], [ClientName], [ClientLastName], [ClientAddress], [ClientPhone], [SubTotal], [Discount], [Iva], [TotalInvoice], [ClientDocument]) VALUES (6, CAST(N'2023-06-08T10:49:40.2207879' AS DateTime2), N'Camila', N'Rodriguez', N'Carepa', N'3219081935', CAST(60000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(11400.00 AS Decimal(18, 2)), CAST(71400.00 AS Decimal(18, 2)), N'1001668312')
INSERT [dbo].[Invoice] ([IdInvoice], [CreationDate], [ClientName], [ClientLastName], [ClientAddress], [ClientPhone], [SubTotal], [Discount], [Iva], [TotalInvoice], [ClientDocument]) VALUES (8, CAST(N'2023-06-08T10:52:47.4952066' AS DateTime2), N'Oscar', N'Mendez', N'Apartado', N'3146088402', CAST(4000000.00 AS Decimal(18, 2)), CAST(200000.00 AS Decimal(18, 2)), CAST(722000.00 AS Decimal(18, 2)), CAST(4522000.00 AS Decimal(18, 2)), N'1001665384')
INSERT [dbo].[Invoice] ([IdInvoice], [CreationDate], [ClientName], [ClientLastName], [ClientAddress], [ClientPhone], [SubTotal], [Discount], [Iva], [TotalInvoice], [ClientDocument]) VALUES (9, CAST(N'2023-06-08T10:59:51.5542882' AS DateTime2), N'Alverto', N'Mendez', N'Apartado Brr Velez', N'3124567896', CAST(800000.00 AS Decimal(18, 2)), CAST(40000.00 AS Decimal(18, 2)), CAST(144400.00 AS Decimal(18, 2)), CAST(904400.00 AS Decimal(18, 2)), N'100158942')
INSERT [dbo].[Invoice] ([IdInvoice], [CreationDate], [ClientName], [ClientLastName], [ClientAddress], [ClientPhone], [SubTotal], [Discount], [Iva], [TotalInvoice], [ClientDocument]) VALUES (10, CAST(N'2023-06-08T11:02:52.1547763' AS DateTime2), N'Alquimer', N'Sepulveda', N'Carepa Crr 69 ', N'3146088404', CAST(210000.00 AS Decimal(18, 2)), CAST(0.00 AS Decimal(18, 2)), CAST(39900.00 AS Decimal(18, 2)), CAST(249900.00 AS Decimal(18, 2)), N'1038817247')
SET IDENTITY_INSERT [dbo].[Invoice] OFF
SET IDENTITY_INSERT [dbo].[InvoiceDetail] ON 

INSERT [dbo].[InvoiceDetail] ([Id], [IdProduct], [IdInvoice], [Count], [SalePrice], [TotalSale]) VALUES (1, 1, 6, 20, CAST(2000.00 AS Decimal(18, 2)), CAST(40000.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceDetail] ([Id], [IdProduct], [IdInvoice], [Count], [SalePrice], [TotalSale]) VALUES (2, 2, 6, 20, CAST(1000.00 AS Decimal(18, 2)), CAST(20000.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceDetail] ([Id], [IdProduct], [IdInvoice], [Count], [SalePrice], [TotalSale]) VALUES (3, 4, 8, 50, CAST(80000.00 AS Decimal(18, 2)), CAST(4000000.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceDetail] ([Id], [IdProduct], [IdInvoice], [Count], [SalePrice], [TotalSale]) VALUES (4, 4, 9, 10, CAST(80000.00 AS Decimal(18, 2)), CAST(800000.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceDetail] ([Id], [IdProduct], [IdInvoice], [Count], [SalePrice], [TotalSale]) VALUES (5, 2, 10, 50, CAST(1000.00 AS Decimal(18, 2)), CAST(50000.00 AS Decimal(18, 2)))
INSERT [dbo].[InvoiceDetail] ([Id], [IdProduct], [IdInvoice], [Count], [SalePrice], [TotalSale]) VALUES (6, 4, 10, 2, CAST(80000.00 AS Decimal(18, 2)), CAST(160000.00 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[InvoiceDetail] OFF
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Code], [Count], [Price], [ProductName]) VALUES (1, 2356, 80, CAST(2000.00 AS Decimal(18, 2)), N'Borrador')
INSERT [dbo].[Product] ([Id], [Code], [Count], [Price], [ProductName]) VALUES (2, 2345, 130, CAST(1000.00 AS Decimal(18, 2)), N'Sacapuntas')
INSERT [dbo].[Product] ([Id], [Code], [Count], [Price], [ProductName]) VALUES (3, 5896, 300, CAST(15000.00 AS Decimal(18, 2)), N'Cartucheras')
INSERT [dbo].[Product] ([Id], [Code], [Count], [Price], [ProductName]) VALUES (4, 4596, 38, CAST(80000.00 AS Decimal(18, 2)), N'Morral ToTTO')
SET IDENTITY_INSERT [dbo].[Product] OFF
/****** Object:  Index [IX_InvoiceDetail_IdInvoice]    Script Date: 08/06/2023 11:07:24 ******/
CREATE NONCLUSTERED INDEX [IX_InvoiceDetail_IdInvoice] ON [dbo].[InvoiceDetail]
(
	[IdInvoice] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_InvoiceDetail_IdProduct]    Script Date: 08/06/2023 11:07:24 ******/
CREATE NONCLUSTERED INDEX [IX_InvoiceDetail_IdProduct] ON [dbo].[InvoiceDetail]
(
	[IdProduct] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Product_Code]    Script Date: 08/06/2023 11:07:24 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Product_Code] ON [dbo].[Product]
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT (N'') FOR [ClientDocument]
GO
ALTER TABLE [dbo].[Product] ADD  DEFAULT (N'') FOR [ProductName]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_Invoice_IdInvoice] FOREIGN KEY([IdInvoice])
REFERENCES [dbo].[Invoice] ([IdInvoice])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_Invoice_IdInvoice]
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceDetail_Product_IdProduct] FOREIGN KEY([IdProduct])
REFERENCES [dbo].[Product] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[InvoiceDetail] CHECK CONSTRAINT [FK_InvoiceDetail_Product_IdProduct]
GO
USE [master]
GO
ALTER DATABASE [BdStore] SET  READ_WRITE 
GO
