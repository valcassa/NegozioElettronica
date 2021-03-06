USE [master]
GO
/****** Object:  Database [NegozioElettronica]    Script Date: 8/26/2021 2:53:57 PM ******/
CREATE DATABASE [NegozioElettronica]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'NegozioElettronica', FILENAME = N'C:\Users\v.cassano\NegozioElettronica.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'NegozioElettronica_log', FILENAME = N'C:\Users\v.cassano\NegozioElettronica_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [NegozioElettronica] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [NegozioElettronica].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [NegozioElettronica] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ARITHABORT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [NegozioElettronica] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [NegozioElettronica] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [NegozioElettronica] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [NegozioElettronica] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [NegozioElettronica] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [NegozioElettronica] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [NegozioElettronica] SET  ENABLE_BROKER 
GO
ALTER DATABASE [NegozioElettronica] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [NegozioElettronica] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [NegozioElettronica] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [NegozioElettronica] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [NegozioElettronica] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [NegozioElettronica] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [NegozioElettronica] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [NegozioElettronica] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [NegozioElettronica] SET  MULTI_USER 
GO
ALTER DATABASE [NegozioElettronica] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [NegozioElettronica] SET DB_CHAINING OFF 
GO
ALTER DATABASE [NegozioElettronica] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [NegozioElettronica] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [NegozioElettronica] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [NegozioElettronica] SET QUERY_STORE = OFF
GO
USE [NegozioElettronica]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [NegozioElettronica]
GO
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Brand] [nvarchar](50) NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[Quantity] [int] NULL,
	[Inches] [int] NULL,
	[Storage] [int] NULL,
	[OpSystem] [nvarchar](50) NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Discriminator] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Vehicles] ON 

INSERT [dbo].[Products] ([Brand], [Model], [Quantity], [Inches], [Storage], [OpSystem], [Id], [Discriminator]) VALUES (N'HP', N'I2300', 100, NULL, NULL, N'Windows 10 Home', 1, N'Laptop')
INSERT [dbo].[Products] ([Brand], [Model], [Quantity], [Inches], [Storage], [OpSystem], [Id], [Discriminator]) VALUES (N'Apple', N'IphoneX', 20, NULL, 65, NULL, 2, N'Mobile')
INSERT [dbo].[Products] ([Brand], [Model], [Quantity], [Inches], [Storage], [OpSystem], [Id], [Discriminator]) VALUES (N'Samsun', N'I001', 20, 40, NULL, NULL, 3, N'Tv')
INSERT [dbo].[Products] ([Brand], [Model], [Quantity], [Inches], [Storage], [OpSystem], [Id], [Discriminator])  VALUES (N'Huawei', N'Y20', 60, NULL, 256, NULL, 4, N'Mobile')
INSERT [dbo].[Products] ([Brand], [Model], [Quantity], [Inches], [Storage], [OpSystem], [Id], [Discriminator]) VALUES (N'Lenovo', N'Thinkpad 200', NULL, 2, 5, N'Windows 10 Pro', 5, N'Laptop')

USE [master]
GO
ALTER DATABASE [NegozioElettronica] SET  READ_WRITE 
GO
