USE [master]
GO

/****** Object:  Database [MilesCar]    Script Date: 12/03/2024 2:58:15 p. m. ******/
CREATE DATABASE [MilesCar]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MilesCar', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MilesCar.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MilesCar_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\MilesCar_log.ldf' , SIZE = 69568KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MilesCar].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [MilesCar] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [MilesCar] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [MilesCar] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [MilesCar] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [MilesCar] SET ARITHABORT OFF 
GO

ALTER DATABASE [MilesCar] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [MilesCar] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [MilesCar] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [MilesCar] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [MilesCar] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [MilesCar] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [MilesCar] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [MilesCar] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [MilesCar] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [MilesCar] SET  DISABLE_BROKER 
GO

ALTER DATABASE [MilesCar] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [MilesCar] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [MilesCar] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [MilesCar] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [MilesCar] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [MilesCar] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [MilesCar] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [MilesCar] SET RECOVERY FULL 
GO

ALTER DATABASE [MilesCar] SET  MULTI_USER 
GO

ALTER DATABASE [MilesCar] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [MilesCar] SET DB_CHAINING OFF 
GO

ALTER DATABASE [MilesCar] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [MilesCar] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [MilesCar] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [MilesCar] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [MilesCar] SET QUERY_STORE = OFF
GO

ALTER DATABASE [MilesCar] SET  READ_WRITE 
GO


USE MilesCar
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 12/03/2024 2:57:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [uniqueidentifier] NULL,
	[Plate] [varchar](50) NULL,
	[Model] [varchar](50) NULL,
	[Color] [varchar](50) NULL,
	[Brand] [varchar](50) NULL,
	[Address_Country] [varchar](30) NULL,
	[Address_Line1] [varchar](50) NULL,
	[Address_Line2] [varchar](50) NULL,
	[Address_City] [varchar](50) NULL,
	[Address_State] [varchar](50) NULL,
	[Address_ZipCode] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 12/03/2024 2:57:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[PhoneNumber] [varchar](10) NOT NULL,
	[Address_Country] [varchar](30) NOT NULL,
	[Address_Line1] [varchar](20) NOT NULL,
	[Address_Line2] [varchar](20) NULL,
	[Address_City] [varchar](40) NOT NULL,
	[Address_State] [varchar](40) NOT NULL,
	[Address_ZipCode] [varchar](10) NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RentCar]    Script Date: 12/03/2024 2:57:23 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RentCar](
	[Id] [uniqueidentifier] NOT NULL,
	[Plate] [varchar](50) NULL,
	[Model] [varchar](50) NULL,
	[Color] [varchar](50) NULL,
	[Brand] [varchar](50) NULL,
	[AddressCollection_Country] [varchar](50) NULL,
	[AddressCollection_Line1] [varchar](50) NULL,
	[AddressCollection_Line2] [varchar](50) NULL,
	[AddressCollection_City] [varchar](50) NULL,
	[AddressCollection_State] [varchar](50) NULL,
	[AddressCollection_ZipCode] [varchar](50) NULL,
	[AddressDelivery_Country] [varchar](50) NULL,
	[AddressDelivery_Line1] [varchar](50) NULL,
	[AddressDelivery_Line2] [varchar](50) NULL,
	[AddressDelivery_City] [varchar](50) NULL,
	[AddressDelivery_State] [varchar](50) NULL,
	[AddressDelivery_ZipCode] [varchar](50) NULL
) ON [PRIMARY]
GO
