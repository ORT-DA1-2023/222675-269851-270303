USE [master]
GO
/****** Object:  Database [TestRenderDB-ByConnectionString]    Script Date: 14/6/2023 14:31:18 ******/
CREATE DATABASE [TestRenderDB-ByConnectionString]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestRenderDB-ByConnectionString', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\TestRenderDB-ByConnectionString.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TestRenderDB-ByConnectionString_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\TestRenderDB-ByConnectionString_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestRenderDB-ByConnectionString].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET  MULTI_USER 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET QUERY_STORE = ON
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [TestRenderDB-ByConnectionString]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 14/6/2023 14:31:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ClientEntities]    Script Date: 14/6/2023 14:31:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ClientEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Password] [nvarchar](max) NULL,
	[RegisterDate] [datetime] NOT NULL,
	[Aperture] [float] NOT NULL,
	[LookFromX] [float] NOT NULL,
	[LookFromY] [float] NOT NULL,
	[LookFromZ] [float] NOT NULL,
	[LookAtX] [float] NOT NULL,
	[LookAtY] [float] NOT NULL,
	[LookAtZ] [float] NOT NULL,
	[Fov] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ClientEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FigureEntities]    Script Date: 14/6/2023 14:31:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FigureEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Radius] [float] NOT NULL,
	[X] [float] NOT NULL,
	[Y] [float] NOT NULL,
	[Z] [float] NOT NULL,
	[ClientEntity_Id] [int] NULL,
 CONSTRAINT [PK_dbo.FigureEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogEntities]    Script Date: 14/6/2023 14:31:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RenderTimeInSeconds] [int] NOT NULL,
	[RenderDate] [datetime] NOT NULL,
	[TimeWindowSinceLastRender] [nvarchar](max) NULL,
	[NumberElements] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ClientEntity_Id] [int] NULL,
 CONSTRAINT [PK_dbo.LogEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialEntities]    Script Date: 14/6/2023 14:31:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Red] [int] NOT NULL,
	[Green] [int] NOT NULL,
	[Blue] [int] NOT NULL,
	[Blur] [float] NOT NULL,
	[ClientEntity_Id] [int] NULL,
 CONSTRAINT [PK_dbo.MaterialEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ModelEntities]    Script Date: 14/6/2023 14:31:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModelEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Preview] [varbinary](max) NULL,
	[ClientEntity_Id] [int] NULL,
	[FigureEntity_Id] [int] NULL,
	[MaterialEntity_Id] [int] NULL,
	[SceneEntity_Id] [int] NULL,
 CONSTRAINT [PK_dbo.ModelEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SceneEntities]    Script Date: 14/6/2023 14:31:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SceneEntities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreationDate] [datetime] NOT NULL,
	[LastModificationDate] [datetime] NOT NULL,
	[LastRenderizationDate] [datetime] NULL,
	[Preview] [varbinary](max) NULL,
	[Aperture] [float] NOT NULL,
	[LookFromX] [float] NOT NULL,
	[LookFromY] [float] NOT NULL,
	[LookFromZ] [float] NOT NULL,
	[LookAtX] [float] NOT NULL,
	[LookAtY] [float] NOT NULL,
	[LookAtZ] [float] NOT NULL,
	[Fov] [int] NOT NULL,
	[LensRadius] [float] NOT NULL,
	[ClientEntity_Id] [int] NULL,
 CONSTRAINT [PK_dbo.SceneEntities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientEntity_Id]    Script Date: 14/6/2023 14:31:18 ******/
CREATE NONCLUSTERED INDEX [IX_ClientEntity_Id] ON [dbo].[FigureEntities]
(
	[ClientEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientEntity_Id]    Script Date: 14/6/2023 14:31:18 ******/
CREATE NONCLUSTERED INDEX [IX_ClientEntity_Id] ON [dbo].[LogEntities]
(
	[ClientEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientEntity_Id]    Script Date: 14/6/2023 14:31:18 ******/
CREATE NONCLUSTERED INDEX [IX_ClientEntity_Id] ON [dbo].[MaterialEntities]
(
	[ClientEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientEntity_Id]    Script Date: 14/6/2023 14:31:18 ******/
CREATE NONCLUSTERED INDEX [IX_ClientEntity_Id] ON [dbo].[ModelEntities]
(
	[ClientEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FigureEntity_Id]    Script Date: 14/6/2023 14:31:18 ******/
CREATE NONCLUSTERED INDEX [IX_FigureEntity_Id] ON [dbo].[ModelEntities]
(
	[FigureEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MaterialEntity_Id]    Script Date: 14/6/2023 14:31:18 ******/
CREATE NONCLUSTERED INDEX [IX_MaterialEntity_Id] ON [dbo].[ModelEntities]
(
	[MaterialEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_SceneEntity_Id]    Script Date: 14/6/2023 14:31:18 ******/
CREATE NONCLUSTERED INDEX [IX_SceneEntity_Id] ON [dbo].[ModelEntities]
(
	[SceneEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_ClientEntity_Id]    Script Date: 14/6/2023 14:31:18 ******/
CREATE NONCLUSTERED INDEX [IX_ClientEntity_Id] ON [dbo].[SceneEntities]
(
	[ClientEntity_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FigureEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.FigureEntities_dbo.ClientEntities_ClientEntity_Id] FOREIGN KEY([ClientEntity_Id])
REFERENCES [dbo].[ClientEntities] ([Id])
GO
ALTER TABLE [dbo].[FigureEntities] CHECK CONSTRAINT [FK_dbo.FigureEntities_dbo.ClientEntities_ClientEntity_Id]
GO
ALTER TABLE [dbo].[LogEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LogEntities_dbo.ClientEntities_ClientEntity_Id] FOREIGN KEY([ClientEntity_Id])
REFERENCES [dbo].[ClientEntities] ([Id])
GO
ALTER TABLE [dbo].[LogEntities] CHECK CONSTRAINT [FK_dbo.LogEntities_dbo.ClientEntities_ClientEntity_Id]
GO
ALTER TABLE [dbo].[MaterialEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MaterialEntities_dbo.ClientEntities_ClientEntity_Id] FOREIGN KEY([ClientEntity_Id])
REFERENCES [dbo].[ClientEntities] ([Id])
GO
ALTER TABLE [dbo].[MaterialEntities] CHECK CONSTRAINT [FK_dbo.MaterialEntities_dbo.ClientEntities_ClientEntity_Id]
GO
ALTER TABLE [dbo].[ModelEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ModelEntities_dbo.ClientEntities_ClientEntity_Id] FOREIGN KEY([ClientEntity_Id])
REFERENCES [dbo].[ClientEntities] ([Id])
GO
ALTER TABLE [dbo].[ModelEntities] CHECK CONSTRAINT [FK_dbo.ModelEntities_dbo.ClientEntities_ClientEntity_Id]
GO
ALTER TABLE [dbo].[ModelEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ModelEntities_dbo.FigureEntities_FigureEntity_Id] FOREIGN KEY([FigureEntity_Id])
REFERENCES [dbo].[FigureEntities] ([Id])
GO
ALTER TABLE [dbo].[ModelEntities] CHECK CONSTRAINT [FK_dbo.ModelEntities_dbo.FigureEntities_FigureEntity_Id]
GO
ALTER TABLE [dbo].[ModelEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ModelEntities_dbo.MaterialEntities_MaterialEntity_Id] FOREIGN KEY([MaterialEntity_Id])
REFERENCES [dbo].[MaterialEntities] ([Id])
GO
ALTER TABLE [dbo].[ModelEntities] CHECK CONSTRAINT [FK_dbo.ModelEntities_dbo.MaterialEntities_MaterialEntity_Id]
GO
ALTER TABLE [dbo].[ModelEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.ModelEntities_dbo.SceneEntities_SceneEntity_Id] FOREIGN KEY([SceneEntity_Id])
REFERENCES [dbo].[SceneEntities] ([Id])
GO
ALTER TABLE [dbo].[ModelEntities] CHECK CONSTRAINT [FK_dbo.ModelEntities_dbo.SceneEntities_SceneEntity_Id]
GO
ALTER TABLE [dbo].[SceneEntities]  WITH CHECK ADD  CONSTRAINT [FK_dbo.SceneEntities_dbo.ClientEntities_ClientEntity_Id] FOREIGN KEY([ClientEntity_Id])
REFERENCES [dbo].[ClientEntities] ([Id])
GO
ALTER TABLE [dbo].[SceneEntities] CHECK CONSTRAINT [FK_dbo.SceneEntities_dbo.ClientEntities_ClientEntity_Id]
GO
USE [master]
GO
ALTER DATABASE [TestRenderDB-ByConnectionString] SET  READ_WRITE 
GO
