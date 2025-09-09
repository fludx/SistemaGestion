CREATE TABLE [dbo].[Codigos2FA](
	[Id_Codigo2FA] [int] IDENTITY(1,1) NOT NULL,
	[Id_Usuario] [int] NOT NULL,
	[Codigo] [nvarchar](6) NOT NULL,
	[Fecha_Generacion] [datetime] NULL,
	[Usado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Codigo2FA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Codigos2FA] ADD  DEFAULT (getdate()) FOR [Fecha_Generacion]
GO

ALTER TABLE [dbo].[Codigos2FA] ADD  DEFAULT ((0)) FOR [Usado]
GO

ALTER TABLE [dbo].[Codigos2FA]  WITH CHECK ADD FOREIGN KEY([Id_Usuario])
REFERENCES [dbo].[Usuarios] ([Id_Usuario])
GO


