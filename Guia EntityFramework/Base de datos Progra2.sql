CREATE DATABASE [Progra2]
USE [Progra2]
GO

/****** Object:  Table [dbo].[Estudiantes]    Script Date: 15/10/2023 14:41:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Estudiantes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Sexo] [varchar](50) NULL,
	[Edad] [int] NULL
) ON [PRIMARY]
GO

