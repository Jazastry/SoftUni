USE [master]
GO
/****** Object:  Database [Persons]    Script Date: 18/2/2015 2:23:23 PM ******/
CREATE DATABASE [Persons]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Persons', FILENAME = N'C:\Users\MSSQLSERVER\Documents\Persons.mdf' , SIZE = 20480KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Persons_log', FILENAME = N'C:\Users\MSSQLSERVER\Documents\Persons_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Persons] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Persons].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Persons] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Persons] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Persons] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Persons] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Persons] SET ARITHABORT OFF 
GO
ALTER DATABASE [Persons] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Persons] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Persons] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Persons] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Persons] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Persons] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Persons] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Persons] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Persons] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Persons] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Persons] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Persons] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Persons] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Persons] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Persons] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Persons] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Persons] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Persons] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Persons] SET  MULTI_USER 
GO
ALTER DATABASE [Persons] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Persons] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Persons] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Persons] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Persons] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Persons]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 18/2/2015 2:23:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PersonID] [int] NOT NULL,
	[Balance] [money] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 18/2/2015 2:23:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[SSN] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Accounts] ON 

INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (1, 1, 23423423.0000)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (2, 2, 324.0000)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (3, 3, 215126.0000)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (4, 4, 543637227.0000)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (5, 5, 3.0000)
INSERT [dbo].[Accounts] ([ID], [PersonID], [Balance]) VALUES (6, 6, 765.0000)
SET IDENTITY_INSERT [dbo].[Accounts] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([ID], [FirstName], [LastName], [SSN]) VALUES (1, N'Susan', N'Perry', N'1238476123465')
INSERT [dbo].[Persons] ([ID], [FirstName], [LastName], [SSN]) VALUES (2, N'Gary', N'Cooper', N'24817264')
INSERT [dbo].[Persons] ([ID], [FirstName], [LastName], [SSN]) VALUES (3, N'Miki', N'Sails', N'1234987686')
INSERT [dbo].[Persons] ([ID], [FirstName], [LastName], [SSN]) VALUES (4, N'Jack', N'Mack', N'9185712987')
INSERT [dbo].[Persons] ([ID], [FirstName], [LastName], [SSN]) VALUES (5, N'Harry', N'Sorry', N'98175857')
INSERT [dbo].[Persons] ([ID], [FirstName], [LastName], [SSN]) VALUES (6, N'Pesho', N'Peshev', N'93258712938475')
SET IDENTITY_INSERT [dbo].[Persons] OFF
ALTER TABLE [dbo].[Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Persons] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Persons] ([ID])
GO
ALTER TABLE [dbo].[Accounts] CHECK CONSTRAINT [FK_Accounts_Persons]
GO
/****** Object:  StoredProcedure [dbo].[usp_FullNamesOfAllPersons]    Script Date: 18/2/2015 2:23:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[usp_FullNamesOfAllPersons]
AS
	SELECT p.FirstName + ' ' + p.LastName AS [Persons Full Name]
	FROM Persons p

GO
USE [master]
GO
ALTER DATABASE [Persons] SET  READ_WRITE 
GO
