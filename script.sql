USE [master]
GO
/****** Object:  Database [BASEBRIRESTCSHARP]    Script Date: 18/08/2022 16:05:51 ******/
CREATE DATABASE [BASEBRIRESTCSHARP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BASEBRIRESTCSHARP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BASEBRIRESTCSHARP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BASEBRIRESTCSHARP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\BASEBRIRESTCSHARP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BASEBRIRESTCSHARP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET ARITHABORT OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET  MULTI_USER 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'BASEBRIRESTCSHARP', N'ON'
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET QUERY_STORE = OFF
GO
USE [BASEBRIRESTCSHARP]
GO
/****** Object:  Table [dbo].[Caja]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Caja](
	[Id_Caja] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Tema] [varchar](50) NULL,
	[Serial_PC] [varchar](max) NULL,
	[Estado] [varchar](50) NULL,
	[Tipo] [varchar](50) NULL,
	[Ruta_para_copias_de_seguridad] [varchar](max) NULL,
	[Ultima_fecha_de_copia_de_seguridad] [varchar](50) NULL,
	[Ultima_fecha_de_copia_date] [datetime] NULL,
	[Frecuencia_de_copias] [int] NULL,
	[Estado_Copia_De_seguridad] [varchar](50) NULL,
 CONSTRAINT [PK_Caja] PRIMARY KEY CLUSTERED 
(
	[Id_Caja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[clientes]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clientes](
	[idclientev] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NULL,
	[Direccion] [varchar](max) NULL,
	[IdentificadorFiscal] [varchar](max) NULL,
	[Celular] [varchar](max) NULL,
	[Estado] [varchar](50) NULL,
	[Saldo] [numeric](18, 2) NULL,
	[Cedula] [varchar](50) NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[idclientev] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Grupo_de_Productos]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grupo_de_Productos](
	[Idline] [int] IDENTITY(1,1) NOT NULL,
	[Grupo] [varchar](50) NULL,
	[Por_defecto] [varchar](50) NULL,
	[Icono] [image] NULL,
	[Estado] [varchar](50) NULL,
	[Estado_de_icono] [varchar](50) NULL,
 CONSTRAINT [PK_linea] PRIMARY KEY CLUSTERED 
(
	[Idline] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IniciosSesion]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IniciosSesion](
	[Idsesion] [int] IDENTITY(1,1) NOT NULL,
	[IdCaja] [int] NULL,
	[IdUsuario] [int] NULL,
 CONSTRAINT [PK_IniciosSesion] PRIMARY KEY CLUSTERED 
(
	[Idsesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mesas]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mesas](
	[Id_mesa] [int] IDENTITY(1,1) NOT NULL,
	[Mesa] [varchar](50) NULL,
	[Id_salon] [int] NULL,
	[Estado_de_vida] [varchar](50) NULL,
	[Estado_de_Disponibilidad] [varchar](50) NULL,
 CONSTRAINT [PK_Mesas] PRIMARY KEY CLUSTERED 
(
	[Id_mesa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modulos]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modulos](
	[IdModulo] [int] IDENTITY(1,1) NOT NULL,
	[Modulo] [varchar](max) NULL,
 CONSTRAINT [PK_Modulos] PRIMARY KEY CLUSTERED 
(
	[IdModulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovimientosCaja]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovimientosCaja](
	[IdMovimientoCaja] [int] IDENTITY(1,1) NOT NULL,
	[fechainicio] [datetime] NULL,
	[fechafin] [datetime] NULL,
	[ingresos] [numeric](18, 2) NULL,
	[egresos] [numeric](18, 2) NULL,
	[VEfectivo] [numeric](18, 2) NULL,
	[VCredito] [numeric](18, 2) NULL,
	[VTarjeta] [numeric](18, 2) NULL,
	[Idusuario] [int] NULL,
	[EfectivoCalculado] [numeric](18, 2) NULL,
	[EfectivoReal] [numeric](18, 2) NULL,
	[EfectivoDiferencia] [numeric](18, 2) NULL,
	[IdCaja] [int] NULL,
 CONSTRAINT [PK_MovimientosCaja] PRIMARY KEY CLUSTERED 
(
	[IdMovimientoCaja] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[IdPermiso] [int] IDENTITY(1,1) NOT NULL,
	[IdModulo] [int] NULL,
	[IdUsuario] [int] NULL,
 CONSTRAINT [PK_Permisos] PRIMARY KEY CLUSTERED 
(
	[IdPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto1]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto1](
	[Id_Producto1] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Imagen] [image] NULL,
	[Id_grupo] [int] NULL,
	[Usa_inventarios] [varchar](50) NULL,
	[Stock] [varchar](50) NULL,
	[Precio_de_venta] [numeric](18, 2) NULL,
	[Stock_minimo] [numeric](18, 2) NULL,
	[Precio_de_compra] [numeric](18, 2) NULL,
	[Estado_imagen] [varchar](50) NULL,
 CONSTRAINT [PK_Producto1] PRIMARY KEY CLUSTERED 
(
	[Id_Producto1] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Propiedades_de_mesas]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Propiedades_de_mesas](
	[Id_propiedades] [int] IDENTITY(1,1) NOT NULL,
	[x] [int] NULL,
	[y] [int] NULL,
	[Tamanio_letra] [int] NULL,
 CONSTRAINT [PK_Propìedades_de_mesas] PRIMARY KEY CLUSTERED 
(
	[Id_propiedades] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SALON]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SALON](
	[Id_salon] [int] IDENTITY(1,1) NOT NULL,
	[Salon] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
 CONSTRAINT [PK_SALON] PRIMARY KEY CLUSTERED 
(
	[Id_salon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[IdUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NULL,
	[Login] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[Icono] [image] NULL,
	[Correo] [varchar](max) NULL,
	[Rol] [varchar](max) NULL,
	[Estado] [varchar](max) NULL,
 CONSTRAINT [PK_Usuarios] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ventas]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ventas](
	[idventa] [int] IDENTITY(1,1) NOT NULL,
	[idclientev] [int] NULL,
	[fecha_venta] [datetime] NULL,
	[Numero_de_doc] [varchar](50) NULL,
	[Monto_total] [numeric](18, 2) NULL,
	[Tipo_de_pago] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
	[IGV] [numeric](18, 2) NULL,
	[Comprobante] [varchar](50) NULL,
	[Id_usuario] [int] NULL,
	[Fecha_de_pago] [varchar](50) NULL,
	[ACCION] [varchar](50) NULL,
	[Saldo] [numeric](18, 2) NULL,
	[Pago_con] [numeric](18, 2) NULL,
	[Porcentaje_IGV] [numeric](18, 2) NULL,
	[Id_caja] [int] NULL,
	[Referencia_tarjeta] [varchar](50) NULL,
	[Vuelto] [numeric](18, 2) NULL,
	[Efectivo] [numeric](18, 2) NULL,
	[Credito] [numeric](18, 2) NULL,
	[Tarjeta] [numeric](18, 2) NULL,
	[Id_mesa] [int] NULL,
	[Numero_personas] [int] NULL,
	[Donde_se_consumira] [varchar](50) NULL,
 CONSTRAINT [PK_ventas] PRIMARY KEY CLUSTERED 
(
	[idventa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IniciosSesion]  WITH CHECK ADD  CONSTRAINT [FK_IniciosSesion_Caja] FOREIGN KEY([IdCaja])
REFERENCES [dbo].[Caja] ([Id_Caja])
GO
ALTER TABLE [dbo].[IniciosSesion] CHECK CONSTRAINT [FK_IniciosSesion_Caja]
GO
ALTER TABLE [dbo].[IniciosSesion]  WITH CHECK ADD  CONSTRAINT [FK_IniciosSesion_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[IniciosSesion] CHECK CONSTRAINT [FK_IniciosSesion_Usuarios]
GO
ALTER TABLE [dbo].[Mesas]  WITH CHECK ADD  CONSTRAINT [FK_Mesas_SALON] FOREIGN KEY([Id_salon])
REFERENCES [dbo].[SALON] ([Id_salon])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Mesas] CHECK CONSTRAINT [FK_Mesas_SALON]
GO
ALTER TABLE [dbo].[MovimientosCaja]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosCaja_Caja] FOREIGN KEY([IdCaja])
REFERENCES [dbo].[Caja] ([Id_Caja])
GO
ALTER TABLE [dbo].[MovimientosCaja] CHECK CONSTRAINT [FK_MovimientosCaja_Caja]
GO
ALTER TABLE [dbo].[MovimientosCaja]  WITH CHECK ADD  CONSTRAINT [FK_MovimientosCaja_Usuarios] FOREIGN KEY([Idusuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[MovimientosCaja] CHECK CONSTRAINT [FK_MovimientosCaja_Usuarios]
GO
ALTER TABLE [dbo].[Permisos]  WITH CHECK ADD  CONSTRAINT [FK_Permisos_Modulos] FOREIGN KEY([IdModulo])
REFERENCES [dbo].[Modulos] ([IdModulo])
GO
ALTER TABLE [dbo].[Permisos] CHECK CONSTRAINT [FK_Permisos_Modulos]
GO
ALTER TABLE [dbo].[Permisos]  WITH CHECK ADD  CONSTRAINT [FK_Permisos_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Permisos] CHECK CONSTRAINT [FK_Permisos_Usuarios]
GO
ALTER TABLE [dbo].[Producto1]  WITH CHECK ADD  CONSTRAINT [FK_Producto1_Grupo_de_Productos] FOREIGN KEY([Id_grupo])
REFERENCES [dbo].[Grupo_de_Productos] ([Idline])
GO
ALTER TABLE [dbo].[Producto1] CHECK CONSTRAINT [FK_Producto1_Grupo_de_Productos]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_Caja] FOREIGN KEY([Id_caja])
REFERENCES [dbo].[Caja] ([Id_Caja])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_ventas_Caja]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_clientes] FOREIGN KEY([idclientev])
REFERENCES [dbo].[clientes] ([idclientev])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_ventas_clientes]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_Mesas] FOREIGN KEY([Id_mesa])
REFERENCES [dbo].[Mesas] ([Id_mesa])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_ventas_Mesas]
GO
ALTER TABLE [dbo].[ventas]  WITH CHECK ADD  CONSTRAINT [FK_ventas_Usuarios] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[Usuarios] ([IdUsuario])
GO
ALTER TABLE [dbo].[ventas] CHECK CONSTRAINT [FK_ventas_Usuarios]
GO
/****** Object:  StoredProcedure [dbo].[aumentar_tamanio_letra]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[aumentar_tamanio_letra]


as

update Propiedades_de_mesas set Tamanio_letra=Tamanio_letra+10




GO
/****** Object:  StoredProcedure [dbo].[aumentar_tamanio_mesa]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[aumentar_tamanio_mesa]


as
update Propiedades_de_mesas set x=x+10,y=y+10

GO
/****** Object:  StoredProcedure [dbo].[buscar_usuarios]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[buscar_usuarios]
@buscador varchar(50)
as
select * from Usuarios 
where Login+Nombre+Correo Like '%' + @buscador + '%'
GO
/****** Object:  StoredProcedure [dbo].[contar_productos_por_grupo]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[contar_productos_por_grupo]
@idgrupo int
as
select count(Id_Producto1 ) from Producto1
where Id_grupo=@idgrupo 
GO
/****** Object:  StoredProcedure [dbo].[disminuir_tamanio_letra]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[disminuir_tamanio_letra]


as
if exists(select Tamanio_letra  from  Propiedades_de_mesas Where Tamanio_letra<=9)
RAISERROR ('Exede el Limite de Medida', 16,1)
else
update Propiedades_de_mesas set Tamanio_letra=Tamanio_letra-10
GO
/****** Object:  StoredProcedure [dbo].[disminuir_tamanio_mesa]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[disminuir_tamanio_mesa]


as

if exists(select x,y from  Propiedades_de_mesas Where x=92 and y=77)
RAISERROR ('Exede el Limite de medida', 16,1)
else
update Propiedades_de_mesas set x=x-10,y=y-10


GO
/****** Object:  StoredProcedure [dbo].[editar_mesa]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[editar_mesa]

@mesa as varchar(50)
,@id_mesa as int
as
if EXISTS (SELECT Mesa FROM Mesas  where (Mesa  = @mesa and Id_mesa  <>@Id_mesa ))

RAISERROR ('Ya Existe una mesa con este Nombre, POR FAVOR INGRESE DE NUEVO', 16,1)
else
update Mesas set Mesa=@mesa 
where Id_mesa=@id_mesa 


GO
/****** Object:  StoredProcedure [dbo].[editar_Modulos]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[editar_Modulos]
@IdModulo As int,
@Modulo As varchar(MAX)
As
UPDATE Modulos Set

Modulo=@Modulo
Where IdModulo=@IdModulo

GO
/****** Object:  StoredProcedure [dbo].[editar_Usuarios]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[editar_Usuarios]
@IdUsuario As int,
@Nombre As varchar(MAX),
@Login As varchar(MAX),
@Password As varchar(MAX),
@Icono As image,
@Correo As varchar(MAX),
@Rol As varchar(MAX)
As
if EXISTS(Select Login,IdUsuario  from Usuarios where Login=@Login and IdUsuario <>@IdUsuario )
RAISERROR ('Usuario en Uso, usa otro nombre de Usuario por favor', 16,1)
else
UPDATE Usuarios Set

Nombre=@Nombre,
Login=@Login,
Password=@Password,
Icono=@Icono,
Correo=@Correo,
Rol=@Rol
Where IdUsuario=@IdUsuario

GO
/****** Object:  StoredProcedure [dbo].[eliminar_Modulos]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[eliminar_Modulos]
@IdModulo As int

As
DELETE FROM Modulos
WHERE IdModulo=@IdModulo
GO
/****** Object:  StoredProcedure [dbo].[eliminar_Permisos]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[eliminar_Permisos]
@IdUsuario As int

As
DELETE FROM Permisos
WHERE IdUsuario=@IdUsuario
GO
/****** Object:  StoredProcedure [dbo].[eliminar_Usuarios]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[eliminar_Usuarios]
@IdUsuario As int

As
update Usuarios set Estado='ELIMINADO'
WHERE IdUsuario=@IdUsuario
GO
/****** Object:  StoredProcedure [dbo].[insertar_Grupo_de_Productos]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[insertar_Grupo_de_Productos]
@Grupo As varchar(50),
@Por_defecto As varchar(50),
@Icono As image,
@Estado As varchar(50),
@Estado_de_icono As varchar(50)
As

if EXISTS (SELECT * FROM Grupo_de_Productos Where Grupo=@Grupo)
RAISERROR ('YA EXISTE UN GRUPO CON ESTE NOMBRE, Ingrese de nuevo
', 16,1)
Else
INSERT INTO Grupo_de_Productos
Values (
@Grupo,
@Por_defecto,
@Icono,
@Estado,
@Estado_de_icono)

GO
/****** Object:  StoredProcedure [dbo].[insertar_mesa]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertar_mesa]
@mesa varchar(50),
@idsalon int
AS
declare @Estado_de_vida varchar(50)
declare @Estado_de_Disponibilidad varchar(50)
set @Estado_de_vida ='ACTIVO'
set @Estado_de_Disponibilidad = 'LIBRE'
if EXISTS(select Mesa  from Mesas  where Mesa= @mesa and Mesa <>'NULO')
RAISERROR('YA EXISTE UNA MESA CON ESE NOMBRE, ingrese de nuevo', 16,1)
else
insert into Mesas values (@mesa, @idsalon ,@Estado_de_vida , @Estado_de_Disponibilidad )

GO
/****** Object:  StoredProcedure [dbo].[insertar_Modulos]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[insertar_Modulos]
@Modulo As varchar(MAX)
As
INSERT INTO Modulos
Values (
@Modulo)

GO
/****** Object:  StoredProcedure [dbo].[insertar_Permisos]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[insertar_Permisos]
@IdModulo As int,
@IdUsuario As int
As
INSERT INTO Permisos
Values (
@IdModulo,
@IdUsuario)

GO
/****** Object:  StoredProcedure [dbo].[insertar_Producto]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[insertar_Producto]   
           @Descripcion varchar(50),
		    @Imagen image,			             
          @Id_grupo as int	,     
           @Precio_de_venta numeric(18,2)    ,
		   @Estado_imagen varchar(50)                		      		      
		   AS 
		   declare @Precio_de_compra numeric(18,2)
		   declare @Stock varchar(50)
		   declare @Usa_inventarios varchar(50)
		   declare @Stock_minimo numeric(18,2) 
		   set @Precio_de_compra=0
		   set @Stock=0
		   set @Usa_inventarios='NULO'
		   SET @Stock_minimo=0
if EXISTS (SELECT Descripcion  FROM Producto1  where Descripcion = @Descripcion   )
RAISERROR ('YA EXISTE UN PRODUCTO  CON ESTE NOMBRE, POR FAVOR INGRESE DE NUEVO/ SE GENERARA CODIGO AUTOMATICO', 16,1)
		ELSE
		   INSERT INTO Producto1 
     VALUES
		    (
           @Descripcion        
           ,@Imagen         
		    ,@Id_grupo 
		,@Usa_inventarios	,
		@Stock ,
          @Precio_de_venta  ,
             
           @Stock_minimo ,
       @Precio_de_compra,
	   @Estado_imagen
		 )
		

GO
/****** Object:  StoredProcedure [dbo].[insertar_Salon]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertar_Salon]
@Salon varchar(50)
as
declare @Estado varchar(50)
set @Estado ='ACTIVO'
if EXISTS(select Salon  from SALON  where Salon = @Salon )
RAISERROR('YA EXISTE UN SALON CON ESTE NOMBRE, ingrese de nuevo', 16,1)
else
insert into SALON values(@Salon , @Estado )

GO
/****** Object:  StoredProcedure [dbo].[insertar_Usuarios]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[insertar_Usuarios]
@Nombre As varchar(MAX),
@Login As varchar(MAX),
@Password As varchar(MAX),
@Icono As image,
@Correo As varchar(MAX),
@Rol As varchar(MAX),
@Estado As varchar(MAX)
As
if Exists(select Login from Usuarios where Login = @Login)
Raiserror('YA EXISTE UN REGISTRO CON ESE USUARIO, POR FAVOR INGRESE DE NUEVO',16,1)
else
INSERT INTO Usuarios
Values (
@Nombre,
@Login,
@Password,
@Icono,
@Correo,
@Rol,
@Estado)

GO
/****** Object:  StoredProcedure [dbo].[insertar_ventas]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[insertar_ventas]
@fecha_venta As datetime,
@Id_usuario As int,
@ACCION As varchar(50),
@Id_caja As int,
@Id_mesa As int,
@Numero_personas As int,
@Donde_se_consumira As varchar(50)
As
declare @idclientev  as int = (Select clientes.idclientev  from clientes where Nombre= 'GENERICO')
declare @Numero_de_doc As varchar(50) set @Numero_de_doc=0
declare @Monto_total As numeric(18,2) set @Monto_total=0
declare @Tipo_de_pago As varchar(50) set @Tipo_de_pago=0
declare @Estado As varchar(50) set @Estado=0
declare @IGV As numeric(18,2) set @IGV=0
declare @Comprobante As varchar(50) set @Comprobante=0
declare @Fecha_de_pago As varchar(50) set @Fecha_de_pago=0
declare @Saldo As numeric(18,2)set @Saldo=0
declare @Pago_con As numeric(18,2)set @Pago_con=0
declare @Porcentaje_IGV As numeric(18,2)set @Porcentaje_IGV=0
declare @Referencia_tarjeta As varchar(50)set @Referencia_tarjeta=0
declare @Vuelto As numeric(18,2)set @Vuelto=0
declare @Efectivo As numeric(18,2)set @Efectivo=0
declare @Credito As numeric(18,2)set @Credito=0
declare @Tarjeta As numeric(18,2)set @Tarjeta=0


INSERT INTO ventas
Values (
@idclientev,
@fecha_venta,
@Numero_de_doc,
@Monto_total,
@Tipo_de_pago,
@Estado,
@IGV,
@Comprobante,
@Id_usuario,
@Fecha_de_pago,
@ACCION,
@Saldo,
@Pago_con,
@Porcentaje_IGV,
@Id_caja,
@Referencia_tarjeta,
@Vuelto,
@Efectivo,
@Credito,
@Tarjeta,
@Id_mesa,
@Numero_personas,
@Donde_se_consumira)
GO
/****** Object:  StoredProcedure [dbo].[mostrar_id_salon_recien_ingresado]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrar_id_salon_recien_ingresado]
@Salon as varchar(50)
AS
select Id_salon from SALON
where Salon= @Salon

GO
/****** Object:  StoredProcedure [dbo].[mostrar_mesas_por_salon]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[mostrar_mesas_por_salon]
@id_salon int
AS
select Mesas.*,Propiedades_de_mesas.*  from Mesas inner join SALON on SALON.Id_salon = Mesas.Id_salon  
cross join Propiedades_de_mesas
wHERE Mesas.Id_salon = @id_salon 

GO
/****** Object:  StoredProcedure [dbo].[mostrar_mesas_por_salon_ventas]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrar_mesas_por_salon_ventas]
@id_salon int
AS
select Mesas.*,Propiedades_de_mesas.*  from Mesas inner join SALON on SALON.Id_salon = Mesas.Id_salon  
cross join Propiedades_de_mesas
wHERE Mesas.Id_salon = @id_salon and Mesas.Mesa<>'NULO'
GO
/****** Object:  StoredProcedure [dbo].[mostrar_Modulos]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[mostrar_Modulos]
As
Select * FROM Modulos


GO
/****** Object:  StoredProcedure [dbo].[mostrar_Permisos]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[mostrar_Permisos]
@idusuario int 
As
Select IdModulo  FROM Permisos where IdUsuario=@idusuario 

GO
/****** Object:  StoredProcedure [dbo].[mostrar_Productos_por_grupo]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrar_Productos_por_grupo]
@id_grupo int
as

select *from Producto1 INNER JOIN Grupo_de_Productos on
Grupo_de_Productos.Idline=Producto1.Id_grupo

where Producto1.Id_grupo =@id_grupo 

GO
/****** Object:  StoredProcedure [dbo].[mostrar_SALON]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[mostrar_SALON]
@buscar varchar(50)
as
select*from SALON where Salon LIKE '%' + @buscar + '%'

GO
/****** Object:  StoredProcedure [dbo].[mostrar_Usuarios]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
CREATE PROC [dbo].[mostrar_Usuarios]
As
Select * FROM Usuarios


GO
/****** Object:  StoredProcedure [dbo].[ObtenerIdUsuario]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ObtenerIdUsuario]
@Login varchar(max)
as
select IdUsuario  from Usuarios where Login=@Login 
GO
/****** Object:  StoredProcedure [dbo].[Paginar_grupos]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[Paginar_grupos]
@Desde int,
@Hasta int
as
BEGIN
SET NOCOUNT ON;
select
Idline, 
Grupo,
Icono ,
Estado_de_icono  
from 
(Select
Idline, 
Grupo,
Icono ,
Estado_de_icono ,
ROW_NUMBER() Over (Order By Idline) 'Numero_de_fila' 
From Grupo_de_Productos) as Paginado
Where (Paginado.Numero_de_fila>=@Desde ) and (Paginado.Numero_de_fila <=@Hasta )
END
GO
/****** Object:  StoredProcedure [dbo].[paginar_Productos_por_grupo]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[paginar_Productos_por_grupo]
@Desde INT,
@Hasta INT,
@id_grupo int
AS
BEGIN
SET NOCOUNT ON;
SELECT
Id_Producto1,
Descripcion,
Imagen,
Precio_de_venta,
Estado_imagen,
Id_grupo
FROM
(SELECT
Id_Producto1,
Descripcion,
Imagen,
Precio_de_venta,
Estado_imagen,
Producto1 .Id_grupo  ,
ROW_NUMBER() OVER (ORDER BY Idline) 'Numero_de_fila'
FROM
Producto1 INNER JOIN Grupo_de_Productos on
Grupo_de_Productos.Idline=Producto1.Id_grupo

) AS Paginado
WHERE
(Paginado.Numero_de_fila >= @Desde)AND (Paginado.Numero_de_fila<= @Hasta ) and Paginado.Id_grupo  =@id_grupo
END







GO
/****** Object:  StoredProcedure [dbo].[restaurar_usuario]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[restaurar_usuario]
@idusuario as int

as	 
UPDATE Usuarios  SET Estado ='ACTIVO'
WHERE IdUsuario =@idusuario

GO
/****** Object:  StoredProcedure [dbo].[validarUsuario]    Script Date: 18/08/2022 16:05:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[validarUsuario]
@password varchar(max),
@login varchar(max)

as
select IdUsuario  from Usuarios
where Password=@password and Login =@login 
GO
USE [master]
GO
ALTER DATABASE [BASEBRIRESTCSHARP] SET  READ_WRITE 
GO
