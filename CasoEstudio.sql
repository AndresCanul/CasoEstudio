

USE [master]
GO

CREATE DATABASE [CasoEstudio]
GO

USE [CasoEstudio]
GO

CREATE TABLE [dbo].[Ejercicios](
	[Consecutivo] [bigint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[Monto] [decimal](10, 2) NOT NULL,
	[TipoEjercicio] [int] NOT NULL,
 CONSTRAINT [PK_Ejercicios] PRIMARY KEY CLUSTERED 
(
	[Consecutivo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[TiposEjercicio](
	[TipoEjercicio] [int] NOT NULL,
	[DescripcionTipoEjercicio] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TiposEjercicio] PRIMARY KEY CLUSTERED 
(
	[TipoEjercicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT [dbo].[TiposEjercicio] ([TipoEjercicio], [DescripcionTipoEjercicio]) VALUES (1, N'Resistencia')
GO
INSERT [dbo].[TiposEjercicio] ([TipoEjercicio], [DescripcionTipoEjercicio]) VALUES (2, N'Fuerza')
GO
INSERT [dbo].[TiposEjercicio] ([TipoEjercicio], [DescripcionTipoEjercicio]) VALUES (3, N'Flexibilidad')
GO
INSERT [dbo].[TiposEjercicio] ([TipoEjercicio], [DescripcionTipoEjercicio]) VALUES (4, N'Meditación')
GO
INSERT [dbo].[TiposEjercicio] ([TipoEjercicio], [DescripcionTipoEjercicio]) VALUES (5, N'Para niños')
GO
INSERT [dbo].[TiposEjercicio] ([TipoEjercicio], [DescripcionTipoEjercicio]) VALUES (6, N'Para adultos mayores')
GO

ALTER TABLE [dbo].[Ejercicios]  WITH CHECK ADD  CONSTRAINT [FK_Ejercicios_TiposEjercicio] FOREIGN KEY([TipoEjercicio])
REFERENCES [dbo].[TiposEjercicio] ([TipoEjercicio])
GO
ALTER TABLE [dbo].[Ejercicios] CHECK CONSTRAINT [FK_Ejercicios_TiposEjercicio]
GO