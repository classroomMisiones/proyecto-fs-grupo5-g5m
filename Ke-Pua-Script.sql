USE [master]
GO
/****** Object:  Database [ke-pua]    Script Date: 14/09/2021 13:28:02 ******/
CREATE DATABASE [ke-pua]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ke-pua', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER03\MSSQL\DATA\ke-pua.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ke-pua_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER03\MSSQL\DATA\ke-pua_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ke-pua] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ke-pua].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ke-pua] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ke-pua] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ke-pua] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ke-pua] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ke-pua] SET ARITHABORT OFF 
GO
ALTER DATABASE [ke-pua] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ke-pua] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ke-pua] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ke-pua] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ke-pua] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ke-pua] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ke-pua] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ke-pua] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ke-pua] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ke-pua] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ke-pua] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ke-pua] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ke-pua] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ke-pua] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ke-pua] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ke-pua] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ke-pua] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ke-pua] SET RECOVERY FULL 
GO
ALTER DATABASE [ke-pua] SET  MULTI_USER 
GO
ALTER DATABASE [ke-pua] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ke-pua] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ke-pua] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ke-pua] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ke-pua] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ke-pua] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ke-pua', N'ON'
GO
ALTER DATABASE [ke-pua] SET QUERY_STORE = OFF
GO
USE [ke-pua]
GO
/****** Object:  Table [dbo].[comisiones]    Script Date: 14/09/2021 13:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comisiones](
	[id_comision] [int] IDENTITY(1,1) NOT NULL,
	[id_transaccion] [int] NOT NULL,
	[fecha] [date] NOT NULL,
 CONSTRAINT [PK_comisiones] PRIMARY KEY CLUSTERED 
(
	[id_comision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuentas]    Script Date: 14/09/2021 13:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuentas](
	[id_cuenta] [int] IDENTITY(1,1) NOT NULL,
	[cvu] [varchar](22) NULL,
	[id_usuario] [int] NULL,
	[id_estado_cuenta] [int] NULL,
 CONSTRAINT [PK_cuentas] PRIMARY KEY CLUSTERED 
(
	[id_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuentas_historial_estado]    Script Date: 14/09/2021 13:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuentas_historial_estado](
	[id_historia_cuenta] [int] IDENTITY(1,1) NOT NULL,
	[fecha_hora] [datetime] NULL,
	[estado] [varchar](50) NULL,
	[id_cuenta] [int] NULL,
	[id_usuario] [int] NULL,
 CONSTRAINT [PK_cuentas_historial_estado] PRIMARY KEY CLUSTERED 
(
	[id_historia_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[email]    Script Date: 14/09/2021 13:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[email](
	[id_email] [int] IDENTITY(1,1) NOT NULL,
	[mail] [varchar](50) NULL,
	[id_usuario] [int] NULL,
 CONSTRAINT [PK_email] PRIMARY KEY CLUSTERED 
(
	[id_email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estado_cuenta]    Script Date: 14/09/2021 13:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estado_cuenta](
	[id_estado_cuenta] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_estado_cuenta] PRIMARY KEY CLUSTERED 
(
	[id_estado_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[localidad]    Script Date: 14/09/2021 13:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[localidad](
	[id_localidad] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[id_provincia] [int] NULL,
 CONSTRAINT [PK_localidad] PRIMARY KEY CLUSTERED 
(
	[id_localidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[login_usuarios]    Script Date: 14/09/2021 13:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[login_usuarios](
	[id_login] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NULL,
	[fecha_hora_inicio] [datetime] NULL,
	[fecha_hora_final] [datetime] NULL,
 CONSTRAINT [PK_login_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pais]    Script Date: 14/09/2021 13:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pais](
	[id_pais] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_pais] PRIMARY KEY CLUSTERED 
(
	[id_pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[provincia]    Script Date: 14/09/2021 13:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[provincia](
	[id_provincia] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[id_pais] [int] NULL,
 CONSTRAINT [PK_provincia] PRIMARY KEY CLUSTERED 
(
	[id_provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 14/09/2021 13:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[id_rol] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[saldo_cuenta]    Script Date: 14/09/2021 13:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[saldo_cuenta](
	[id_saldo] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NULL,
	[id_moneda] [int] NULL,
	[saldo] [float] NULL,
	[fecha] [date] NULL,
	[hora] [time](7) NULL,
 CONSTRAINT [PK_saldo_cuenta] PRIMARY KEY CLUSTERED 
(
	[id_saldo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[telefono]    Script Date: 14/09/2021 13:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[telefono](
	[id_telefono] [int] IDENTITY(1,1) NOT NULL,
	[numero_telefono] [varchar](50) NULL,
	[id_usuario] [int] NULL,
 CONSTRAINT [PK_telefono] PRIMARY KEY CLUSTERED 
(
	[id_telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_documento_identidad]    Script Date: 14/09/2021 13:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_documento_identidad](
	[id_tipo_dni] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_tipo_documento_identidad] PRIMARY KEY CLUSTERED 
(
	[id_tipo_dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_moneda]    Script Date: 14/09/2021 13:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_moneda](
	[id_moneda] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_tipo_moneda] PRIMARY KEY CLUSTERED 
(
	[id_moneda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_transaccion]    Script Date: 14/09/2021 13:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_transaccion](
	[id_tipo_transaccion] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](50) NULL,
	[valor_comision] [float] NULL,
 CONSTRAINT [PK_tipo_transaccion] PRIMARY KEY CLUSTERED 
(
	[id_tipo_transaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transacciones_cuenta]    Script Date: 14/09/2021 13:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transacciones_cuenta](
	[id_transaccion] [int] IDENTITY(1,1) NOT NULL,
	[id_usuario] [int] NULL,
	[fecha] [date] NULL,
	[hora] [time](7) NULL,
	[id_tipo_transaccion] [int] NULL,
	[id_cuenta_origen] [int] NULL,
	[id_moneda1] [int] NULL,
	[monto1] [float] NULL,
	[id_cuenta_destino] [int] NULL,
	[id_moneda2] [int] NULL,
	[monto2] [float] NULL,
 CONSTRAINT [PK_Transacciones_cuenta] PRIMARY KEY CLUSTERED 
(
	[id_transaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 14/09/2021 13:28:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[dni_numero] [int] NULL,
	[id_tipo_dni] [int] NULL,
	[direccion] [varchar](50) NULL,
	[nro_direccion] [int] NULL,
	[piso_departamento] [varchar](5) NULL,
	[id_email] [int] NULL,
	[id_telefono] [int] NULL,
	[id_pais] [int] NULL,
	[id_provincia] [int] NULL,
	[id_localidad] [int] NULL,
	[id_estado_cuenta] [int] NULL,
	[id_rol] [int] NULL,
	[passw] [varchar](50) NULL,
	[fecha_passw] [date] NULL,
	[nombre_de_usuario] [varchar](50) NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[cuentas]  WITH CHECK ADD  CONSTRAINT [FK_cuentas_estado_cuenta] FOREIGN KEY([id_estado_cuenta])
REFERENCES [dbo].[estado_cuenta] ([id_estado_cuenta])
GO
ALTER TABLE [dbo].[cuentas] CHECK CONSTRAINT [FK_cuentas_estado_cuenta]
GO
ALTER TABLE [dbo].[cuentas]  WITH CHECK ADD  CONSTRAINT [FK_cuentas_usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[cuentas] CHECK CONSTRAINT [FK_cuentas_usuarios]
GO
ALTER TABLE [dbo].[cuentas_historial_estado]  WITH CHECK ADD  CONSTRAINT [FK_cuentas_historial_estado_cuentas] FOREIGN KEY([id_cuenta])
REFERENCES [dbo].[cuentas] ([id_cuenta])
GO
ALTER TABLE [dbo].[cuentas_historial_estado] CHECK CONSTRAINT [FK_cuentas_historial_estado_cuentas]
GO
ALTER TABLE [dbo].[cuentas_historial_estado]  WITH CHECK ADD  CONSTRAINT [FK_cuentas_historial_estado_usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[cuentas_historial_estado] CHECK CONSTRAINT [FK_cuentas_historial_estado_usuarios]
GO
ALTER TABLE [dbo].[localidad]  WITH CHECK ADD  CONSTRAINT [FK_localidad_provincia] FOREIGN KEY([id_provincia])
REFERENCES [dbo].[provincia] ([id_provincia])
GO
ALTER TABLE [dbo].[localidad] CHECK CONSTRAINT [FK_localidad_provincia]
GO
ALTER TABLE [dbo].[login_usuarios]  WITH CHECK ADD  CONSTRAINT [FK_login_usuarios_usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[login_usuarios] CHECK CONSTRAINT [FK_login_usuarios_usuarios]
GO
ALTER TABLE [dbo].[provincia]  WITH CHECK ADD  CONSTRAINT [FK_provincia_pais] FOREIGN KEY([id_pais])
REFERENCES [dbo].[pais] ([id_pais])
GO
ALTER TABLE [dbo].[provincia] CHECK CONSTRAINT [FK_provincia_pais]
GO
ALTER TABLE [dbo].[saldo_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_saldo_cuenta_tipo_moneda] FOREIGN KEY([id_moneda])
REFERENCES [dbo].[tipo_moneda] ([id_moneda])
GO
ALTER TABLE [dbo].[saldo_cuenta] CHECK CONSTRAINT [FK_saldo_cuenta_tipo_moneda]
GO
ALTER TABLE [dbo].[saldo_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_saldo_cuenta_usuarios] FOREIGN KEY([id_saldo])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[saldo_cuenta] CHECK CONSTRAINT [FK_saldo_cuenta_usuarios]
GO
ALTER TABLE [dbo].[Transacciones_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_cuenta_cuentas] FOREIGN KEY([id_cuenta_origen])
REFERENCES [dbo].[cuentas] ([id_cuenta])
GO
ALTER TABLE [dbo].[Transacciones_cuenta] CHECK CONSTRAINT [FK_Transacciones_cuenta_cuentas]
GO
ALTER TABLE [dbo].[Transacciones_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_cuenta_cuentas1] FOREIGN KEY([id_cuenta_destino])
REFERENCES [dbo].[cuentas] ([id_cuenta])
GO
ALTER TABLE [dbo].[Transacciones_cuenta] CHECK CONSTRAINT [FK_Transacciones_cuenta_cuentas1]
GO
ALTER TABLE [dbo].[Transacciones_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_cuenta_tipo_moneda] FOREIGN KEY([id_moneda1])
REFERENCES [dbo].[tipo_moneda] ([id_moneda])
GO
ALTER TABLE [dbo].[Transacciones_cuenta] CHECK CONSTRAINT [FK_Transacciones_cuenta_tipo_moneda]
GO
ALTER TABLE [dbo].[Transacciones_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_cuenta_tipo_moneda1] FOREIGN KEY([id_moneda2])
REFERENCES [dbo].[tipo_moneda] ([id_moneda])
GO
ALTER TABLE [dbo].[Transacciones_cuenta] CHECK CONSTRAINT [FK_Transacciones_cuenta_tipo_moneda1]
GO
ALTER TABLE [dbo].[Transacciones_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_cuenta_tipo_transaccion] FOREIGN KEY([id_tipo_transaccion])
REFERENCES [dbo].[tipo_transaccion] ([id_tipo_transaccion])
GO
ALTER TABLE [dbo].[Transacciones_cuenta] CHECK CONSTRAINT [FK_Transacciones_cuenta_tipo_transaccion]
GO
ALTER TABLE [dbo].[Transacciones_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_cuenta_usuarios] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[usuarios] ([id_usuario])
GO
ALTER TABLE [dbo].[Transacciones_cuenta] CHECK CONSTRAINT [FK_Transacciones_cuenta_usuarios]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_email] FOREIGN KEY([id_email])
REFERENCES [dbo].[email] ([id_email])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_email]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_localidad] FOREIGN KEY([id_localidad])
REFERENCES [dbo].[localidad] ([id_localidad])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_localidad]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_pais] FOREIGN KEY([id_pais])
REFERENCES [dbo].[pais] ([id_pais])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_pais]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_provincia] FOREIGN KEY([id_provincia])
REFERENCES [dbo].[provincia] ([id_provincia])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_provincia]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_rol] FOREIGN KEY([id_rol])
REFERENCES [dbo].[rol] ([id_rol])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_rol]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_telefono] FOREIGN KEY([id_telefono])
REFERENCES [dbo].[telefono] ([id_telefono])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_telefono]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_tipo_documento_identidad] FOREIGN KEY([id_tipo_dni])
REFERENCES [dbo].[tipo_documento_identidad] ([id_tipo_dni])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_tipo_documento_identidad]
GO
USE [master]
GO
ALTER DATABASE [ke-pua] SET  READ_WRITE 
GO
