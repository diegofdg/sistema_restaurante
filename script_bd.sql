USE [master]
GO
/****** Object:  Database [bd_restaurante]    Script Date: 23/07/2022 17:20:22 ******/
CREATE DATABASE [bd_restaurante]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'bd_restaurante', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\bd_restaurante.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'bd_restaurante_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\bd_restaurante_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [bd_restaurante] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [bd_restaurante].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [bd_restaurante] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [bd_restaurante] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [bd_restaurante] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [bd_restaurante] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [bd_restaurante] SET ARITHABORT OFF 
GO
ALTER DATABASE [bd_restaurante] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [bd_restaurante] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [bd_restaurante] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [bd_restaurante] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [bd_restaurante] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [bd_restaurante] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [bd_restaurante] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [bd_restaurante] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [bd_restaurante] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [bd_restaurante] SET  DISABLE_BROKER 
GO
ALTER DATABASE [bd_restaurante] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [bd_restaurante] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [bd_restaurante] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [bd_restaurante] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [bd_restaurante] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [bd_restaurante] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [bd_restaurante] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [bd_restaurante] SET RECOVERY FULL 
GO
ALTER DATABASE [bd_restaurante] SET  MULTI_USER 
GO
ALTER DATABASE [bd_restaurante] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [bd_restaurante] SET DB_CHAINING OFF 
GO
ALTER DATABASE [bd_restaurante] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [bd_restaurante] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [bd_restaurante] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [bd_restaurante] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'bd_restaurante', N'ON'
GO
ALTER DATABASE [bd_restaurante] SET QUERY_STORE = OFF
GO
USE [bd_restaurante]
GO
/****** Object:  Table [dbo].[mesa]    Script Date: 23/07/2022 17:20:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mesa](
	[id_mesa] [int] IDENTITY(1,1) NOT NULL,
	[mesa] [varchar](50) NULL,
	[id_salon] [int] NULL,
	[estado_de_vida] [varchar](50) NULL,
	[estado_de_disponibilidad] [varchar](50) NULL,
 CONSTRAINT [PK_mesas] PRIMARY KEY CLUSTERED 
(
	[id_mesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[salon]    Script Date: 23/07/2022 17:20:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[salon](
	[id_salon] [int] IDENTITY(1,1) NOT NULL,
	[salon] [varchar](50) NULL,
	[estado] [varchar](50) NULL,
 CONSTRAINT [PK_salon] PRIMARY KEY CLUSTERED 
(
	[id_salon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[mesa]  WITH CHECK ADD  CONSTRAINT [FK_mesas_salon] FOREIGN KEY([id_salon])
REFERENCES [dbo].[salon] ([id_salon])
GO
ALTER TABLE [dbo].[mesa] CHECK CONSTRAINT [FK_mesas_salon]
GO
/****** Object:  StoredProcedure [dbo].[InsertarMesa]    Script Date: 23/07/2022 17:20:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[InsertarMesa]
@mesa varchar(50),
@id_salon int
as
declare @estado_de_vida varchar(50)
declare @estado_de_disponibilidad varchar(50)
set @estado_de_vida = 'ACTIVO'
set @estado_de_disponibilidad = 'LIBRE'
IF EXISTS(SELECT mesa FROM mesa WHERE mesa = @mesa AND mesa <> 'NULO')
RAISERROR('Ya existe una mesa con este nombre', 16, 1)
ELSE
INSERT INTO mesa VALUES (@mesa, @id_salon, @estado_de_vida, @estado_de_disponibilidad)
GO
/****** Object:  StoredProcedure [dbo].[InsertarSalon]    Script Date: 23/07/2022 17:20:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[InsertarSalon]
@salon varchar(50)
as
declare @estado varchar(50)
set @estado = 'ACTIVO'
IF EXISTS(SELECT salon FROM salon WHERE salon = @salon)
RAISERROR('Ya existe un salón con este nombre', 16, 1)
ELSE
INSERT INTO salon VALUES (@salon, @estado)
GO
/****** Object:  StoredProcedure [dbo].[MostrarMesasPorSalon]    Script Date: 23/07/2022 17:20:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[MostrarMesasPorSalon]
@id_salon int
as
SELECT * FROM mesa INNER JOIN salon on salon.id_salon = mesa.id_salon
WHERE mesa.id_salon = @id_salon
GO
/****** Object:  StoredProcedure [dbo].[MostrarSalon]    Script Date: 23/07/2022 17:20:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[MostrarSalon]
@buscar varchar(50)
as
SELECT * FROM salon WHERE salon LIKE '%' + @buscar + '%'
GO
USE [master]
GO
ALTER DATABASE [bd_restaurante] SET  READ_WRITE 
GO
