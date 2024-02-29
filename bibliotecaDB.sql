USE [bibliotecaDB]
GO

/****** Object:  Table [dbo].[categoria]    Script Date: 29/2/2024 00:38:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[categoria](
	[idCategoria] [int] IDENTITY(1,1) NOT NULL,
	[descripcion] [varchar](250) NOT NULL,
	[tiempoRegistro] [datetime] NOT NULL,
	[tiempoModificacion] [datetime] NULL,
	[activo] [bit] NOT NULL,
 CONSTRAINT [PK_categoria] PRIMARY KEY CLUSTERED 
(
	[idCategoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[libro](
	[idLibro] [int] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](250) NOT NULL,
	[tiempoRegistro] [datetime] NOT NULL,
	[tiempoModificacion] [datetime] NULL,
	[activo] [bit] NOT NULL,
	[categoriaId] [int] NOT NULL,
 CONSTRAINT [PK_libro] PRIMARY KEY CLUSTERED 
(
	[idLibro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[libro]  WITH CHECK ADD  CONSTRAINT [FK_libro_categoria] FOREIGN KEY([categoriaId])
REFERENCES [dbo].[categoria] ([idCategoria])
GO

ALTER TABLE [dbo].[libro] CHECK CONSTRAINT [FK_libro_categoria]
GO


