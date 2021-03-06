USE [master]
GO
/****** Object:  Database [ke-pua]    Script Date: 18/10/2021 15:43:45 ******/
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
/****** Object:  Table [dbo].[comisiones]    Script Date: 18/10/2021 15:43:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comisiones](
	[Id_comision] [int] IDENTITY(1,1) NOT NULL,
	[Id_transaccion] [int] NULL,
	[Id_moneda] [int] NULL,
	[Porcentaje_comision] [float] NULL,
	[Monto_comision] [float] NULL,
	[Fecha] [date] NULL,
 CONSTRAINT [PK_comisiones] PRIMARY KEY CLUSTERED 
(
	[Id_comision] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuentas]    Script Date: 18/10/2021 15:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuentas](
	[Id_cuenta] [int] IDENTITY(1,1) NOT NULL,
	[Cvu] [varchar](22) NULL,
	[Id_usuario] [int] NULL,
	[Id_estado_cuenta] [int] NULL,
 CONSTRAINT [PK_cuentas] PRIMARY KEY CLUSTERED 
(
	[Id_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[cuentas_historial_estado]    Script Date: 18/10/2021 15:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cuentas_historial_estado](
	[Id_historia_cuenta] [int] IDENTITY(1,1) NOT NULL,
	[Fecha_hora] [datetime] NULL,
	[Id_estado_cuenta] [int] NULL,
	[Id_cuenta] [int] NULL,
	[Id_usuario] [int] NULL,
 CONSTRAINT [PK_cuentas_historial_estado] PRIMARY KEY CLUSTERED 
(
	[Id_historia_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[email]    Script Date: 18/10/2021 15:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[email](
	[Id_email] [int] IDENTITY(1,1) NOT NULL,
	[Mail] [varchar](50) NULL,
	[Id_usuario] [int] NULL,
 CONSTRAINT [PK_email] PRIMARY KEY CLUSTERED 
(
	[Id_email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[estado_cuenta]    Script Date: 18/10/2021 15:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[estado_cuenta](
	[Id_estado_cuenta] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_estado_cuenta] PRIMARY KEY CLUSTERED 
(
	[Id_estado_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[localidad]    Script Date: 18/10/2021 15:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[localidad](
	[Id_localidad] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Id_provincia] [int] NULL,
 CONSTRAINT [PK_localidad] PRIMARY KEY CLUSTERED 
(
	[Id_localidad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[login_usuarios]    Script Date: 18/10/2021 15:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[login_usuarios](
	[Id_login] [int] IDENTITY(1,1) NOT NULL,
	[Id_usuario] [int] NULL,
	[Fecha_hora_inicio] [datetime] NULL,
	[Fecha_hora_final] [datetime] NULL,
 CONSTRAINT [PK_login_usuarios] PRIMARY KEY CLUSTERED 
(
	[Id_login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pais]    Script Date: 18/10/2021 15:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pais](
	[Id_pais] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_pais] PRIMARY KEY CLUSTERED 
(
	[Id_pais] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[provincia]    Script Date: 18/10/2021 15:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[provincia](
	[Id_provincia] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Id_pais] [int] NULL,
 CONSTRAINT [PK_provincia] PRIMARY KEY CLUSTERED 
(
	[Id_provincia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rol]    Script Date: 18/10/2021 15:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rol](
	[Id_rol] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_rol] PRIMARY KEY CLUSTERED 
(
	[Id_rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[saldo_cuenta]    Script Date: 18/10/2021 15:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[saldo_cuenta](
	[Id_saldo] [int] IDENTITY(1,1) NOT NULL,
	[Id_usuario] [int] NULL,
	[Id_moneda] [int] NULL,
	[Saldo] [float] NULL,
	[Fecha] [date] NULL,
	[Hora] [time](7) NULL,
 CONSTRAINT [PK_saldo_cuenta] PRIMARY KEY CLUSTERED 
(
	[Id_saldo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tarjetas]    Script Date: 18/10/2021 15:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tarjetas](
	[Id_tarjeta] [int] IDENTITY(1,1) NOT NULL,
	[Numero_tarjeta] [varchar](19) NULL,
	[Fecha_vencimiento] [date] NULL,
	[Id_usuario] [int] NULL,
 CONSTRAINT [PK_tarjetas] PRIMARY KEY CLUSTERED 
(
	[Id_tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[telefono]    Script Date: 18/10/2021 15:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[telefono](
	[Id_telefono] [int] IDENTITY(1,1) NOT NULL,
	[Numero_telefono] [varchar](50) NULL,
	[Id_usuario] [int] NULL,
 CONSTRAINT [PK_telefono] PRIMARY KEY CLUSTERED 
(
	[Id_telefono] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_documento_identidad]    Script Date: 18/10/2021 15:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_documento_identidad](
	[Id_tipo_dni] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_tipo_documento_identidad] PRIMARY KEY CLUSTERED 
(
	[Id_tipo_dni] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_moneda]    Script Date: 18/10/2021 15:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_moneda](
	[Id_moneda] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
 CONSTRAINT [PK_tipo_moneda] PRIMARY KEY CLUSTERED 
(
	[Id_moneda] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tipo_transaccion]    Script Date: 18/10/2021 15:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tipo_transaccion](
	[Id_tipo_transaccion] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
	[Valor_comision] [float] NULL,
 CONSTRAINT [PK_tipo_transaccion] PRIMARY KEY CLUSTERED 
(
	[Id_tipo_transaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[transacciones_cuenta]    Script Date: 18/10/2021 15:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[transacciones_cuenta](
	[Id_transaccion] [int] IDENTITY(1,1) NOT NULL,
	[Id_usuario] [int] NULL,
	[Fecha] [date] NULL,
	[Hora] [time](7) NULL,
	[Id_tipo_transaccion] [int] NULL,
	[Id_cuenta_origen] [int] NULL,
	[Id_moneda_origen] [int] NULL,
	[Monto_origen] [float] NULL,
	[Id_cuenta_destino] [int] NULL,
	[Id_moneda_destino] [int] NULL,
	[Monto_destino] [float] NULL,
 CONSTRAINT [PK_Transacciones_cuenta] PRIMARY KEY CLUSTERED 
(
	[Id_transaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 18/10/2021 15:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[Id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Dni_numero] [int] NULL,
	[Id_tipo_dni] [int] NULL,
	[Direccion] [varchar](50) NULL,
	[Nro_direccion] [int] NULL,
	[Piso_departamento] [varchar](5) NULL,
	[Id_email] [int] NULL,
	[Id_telefono] [int] NULL,
	[Id_pais] [int] NULL,
	[Id_provincia] [int] NULL,
	[Id_localidad] [int] NULL,
	[Id_estado_cuenta] [int] NULL,
	[Id_rol] [int] NULL,
	[Clave] [varchar](400) NULL,
	[Fecha_clave] [date] NULL,
	[Nombre_de_usuario] [varchar](50) NULL,
	[N_token] [varchar](500) NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[Id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[comisiones]  WITH CHECK ADD  CONSTRAINT [FK_comisiones_tipo_moneda] FOREIGN KEY([Id_moneda])
REFERENCES [dbo].[tipo_moneda] ([Id_moneda])
GO
ALTER TABLE [dbo].[comisiones] CHECK CONSTRAINT [FK_comisiones_tipo_moneda]
GO
ALTER TABLE [dbo].[comisiones]  WITH CHECK ADD  CONSTRAINT [FK_comisiones_transacciones_cuenta] FOREIGN KEY([Id_transaccion])
REFERENCES [dbo].[transacciones_cuenta] ([Id_transaccion])
GO
ALTER TABLE [dbo].[comisiones] CHECK CONSTRAINT [FK_comisiones_transacciones_cuenta]
GO
ALTER TABLE [dbo].[cuentas]  WITH CHECK ADD  CONSTRAINT [FK_cuentas_estado_cuenta] FOREIGN KEY([Id_estado_cuenta])
REFERENCES [dbo].[estado_cuenta] ([Id_estado_cuenta])
GO
ALTER TABLE [dbo].[cuentas] CHECK CONSTRAINT [FK_cuentas_estado_cuenta]
GO
ALTER TABLE [dbo].[cuentas]  WITH CHECK ADD  CONSTRAINT [FK_cuentas_usuarios] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[usuarios] ([Id_usuario])
GO
ALTER TABLE [dbo].[cuentas] CHECK CONSTRAINT [FK_cuentas_usuarios]
GO
ALTER TABLE [dbo].[cuentas_historial_estado]  WITH CHECK ADD  CONSTRAINT [FK_cuentas_historial_estado_cuentas] FOREIGN KEY([Id_cuenta])
REFERENCES [dbo].[cuentas] ([Id_cuenta])
GO
ALTER TABLE [dbo].[cuentas_historial_estado] CHECK CONSTRAINT [FK_cuentas_historial_estado_cuentas]
GO
ALTER TABLE [dbo].[cuentas_historial_estado]  WITH CHECK ADD  CONSTRAINT [FK_cuentas_historial_estado_usuarios] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[usuarios] ([Id_usuario])
GO
ALTER TABLE [dbo].[cuentas_historial_estado] CHECK CONSTRAINT [FK_cuentas_historial_estado_usuarios]
GO
ALTER TABLE [dbo].[localidad]  WITH CHECK ADD  CONSTRAINT [FK_localidad_provincia] FOREIGN KEY([Id_provincia])
REFERENCES [dbo].[provincia] ([Id_provincia])
GO
ALTER TABLE [dbo].[localidad] CHECK CONSTRAINT [FK_localidad_provincia]
GO
ALTER TABLE [dbo].[login_usuarios]  WITH CHECK ADD  CONSTRAINT [FK_login_usuarios_usuarios] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[usuarios] ([Id_usuario])
GO
ALTER TABLE [dbo].[login_usuarios] CHECK CONSTRAINT [FK_login_usuarios_usuarios]
GO
ALTER TABLE [dbo].[provincia]  WITH CHECK ADD  CONSTRAINT [FK_provincia_pais] FOREIGN KEY([Id_pais])
REFERENCES [dbo].[pais] ([Id_pais])
GO
ALTER TABLE [dbo].[provincia] CHECK CONSTRAINT [FK_provincia_pais]
GO
ALTER TABLE [dbo].[saldo_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_saldo_cuenta_tipo_moneda] FOREIGN KEY([Id_moneda])
REFERENCES [dbo].[tipo_moneda] ([Id_moneda])
GO
ALTER TABLE [dbo].[saldo_cuenta] CHECK CONSTRAINT [FK_saldo_cuenta_tipo_moneda]
GO
ALTER TABLE [dbo].[saldo_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_saldo_cuenta_usuarios1] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[usuarios] ([Id_usuario])
GO
ALTER TABLE [dbo].[saldo_cuenta] CHECK CONSTRAINT [FK_saldo_cuenta_usuarios1]
GO
ALTER TABLE [dbo].[transacciones_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_cuenta_cuentas] FOREIGN KEY([Id_cuenta_origen])
REFERENCES [dbo].[cuentas] ([Id_cuenta])
GO
ALTER TABLE [dbo].[transacciones_cuenta] CHECK CONSTRAINT [FK_Transacciones_cuenta_cuentas]
GO
ALTER TABLE [dbo].[transacciones_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_cuenta_cuentas1] FOREIGN KEY([Id_cuenta_destino])
REFERENCES [dbo].[cuentas] ([Id_cuenta])
GO
ALTER TABLE [dbo].[transacciones_cuenta] CHECK CONSTRAINT [FK_Transacciones_cuenta_cuentas1]
GO
ALTER TABLE [dbo].[transacciones_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_cuenta_tipo_moneda] FOREIGN KEY([Id_moneda_origen])
REFERENCES [dbo].[tipo_moneda] ([Id_moneda])
GO
ALTER TABLE [dbo].[transacciones_cuenta] CHECK CONSTRAINT [FK_Transacciones_cuenta_tipo_moneda]
GO
ALTER TABLE [dbo].[transacciones_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_cuenta_tipo_moneda1] FOREIGN KEY([Id_moneda_destino])
REFERENCES [dbo].[tipo_moneda] ([Id_moneda])
GO
ALTER TABLE [dbo].[transacciones_cuenta] CHECK CONSTRAINT [FK_Transacciones_cuenta_tipo_moneda1]
GO
ALTER TABLE [dbo].[transacciones_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_cuenta_tipo_transaccion] FOREIGN KEY([Id_tipo_transaccion])
REFERENCES [dbo].[tipo_transaccion] ([Id_tipo_transaccion])
GO
ALTER TABLE [dbo].[transacciones_cuenta] CHECK CONSTRAINT [FK_Transacciones_cuenta_tipo_transaccion]
GO
ALTER TABLE [dbo].[transacciones_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_Transacciones_cuenta_usuarios] FOREIGN KEY([Id_usuario])
REFERENCES [dbo].[usuarios] ([Id_usuario])
GO
ALTER TABLE [dbo].[transacciones_cuenta] CHECK CONSTRAINT [FK_Transacciones_cuenta_usuarios]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_email] FOREIGN KEY([Id_email])
REFERENCES [dbo].[email] ([Id_email])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_email]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_localidad] FOREIGN KEY([Id_localidad])
REFERENCES [dbo].[localidad] ([Id_localidad])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_localidad]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_pais] FOREIGN KEY([Id_pais])
REFERENCES [dbo].[pais] ([Id_pais])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_pais]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_provincia] FOREIGN KEY([Id_provincia])
REFERENCES [dbo].[provincia] ([Id_provincia])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_provincia]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_rol] FOREIGN KEY([Id_rol])
REFERENCES [dbo].[rol] ([Id_rol])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_rol]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_telefono] FOREIGN KEY([Id_telefono])
REFERENCES [dbo].[telefono] ([Id_telefono])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_telefono]
GO
ALTER TABLE [dbo].[usuarios]  WITH CHECK ADD  CONSTRAINT [FK_usuarios_tipo_documento_identidad] FOREIGN KEY([Id_tipo_dni])
REFERENCES [dbo].[tipo_documento_identidad] ([Id_tipo_dni])
GO
ALTER TABLE [dbo].[usuarios] CHECK CONSTRAINT [FK_usuarios_tipo_documento_identidad]
GO
USE [master]
GO
ALTER DATABASE [ke-pua] SET  READ_WRITE 
GO
