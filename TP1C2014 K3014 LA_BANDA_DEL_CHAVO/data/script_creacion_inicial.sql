USE [GD1C2014];
CREATE SCHEMA [LA_BANDA_DEL_CHAVO] AUTHORIZATION [gd];

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario](
	[ID_Usuario] int IDENTITY (1,1),
	[Username] nvarchar(255) NOT NULL,
	[Password] nvarchar (64) NOT NULL,
	[Pass_Temporal] bit DEFAULT 0
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Rol](
	[ID_Rol] int IDENTITY (1,1),
	[Descripcion] nvarchar (255) NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad](
	[ID_Funcionalidad] int IDENTITY (1,1),
	[Descripcion] nvarchar (255) NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad_Rol](
	[ID_Funcionalidad_Rol] int IDENTITY (1,1),
	[ID_Funcionalidad] int NOT NULL,
	[ID_Rol] int NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Cliente](
	[ID_Cliente] int IDENTITY (1,1),
	[ID_Usuario] int NOT NULL,
	[Nombre] nvarchar(255) NOT NULL,
	[Apellido] nvarchar(255) NOT NULL,
	[Tipo_Documento] nvarchar(255) NOT NULL,
	[Nro_Documento] numeric(18,0) NOT NULL,
	[Mail] nvarchar(255) NOT NULL,
	[Telefono] nvarchar(255),
	[Direccion] nvarchar(255) NOT NULL,
	[Codigo_Postal] nvarchar(255) NOT NULL,
	[Fecha_nacimiento] datetime NOT NULL,
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Empresa](
	[ID_Empresa] int IDENTITY (1,1),
	[ID_Usuario] int NOT NULL,
	[Razon_Social] nvarchar(255) NOT NULL,
	[Mail] nvarchar(255) NOT NULL,
	[Telefono] nvarchar(255),
	[Direccion] nvarchar(255) NOT NULL,
	[Codigo_Postal] nvarchar(255) NOT NULL,
	[Ciudad] nvarchar(255) NOT NULL,
	[CUIT] nvarchar(50) NOT NULL,
	[Nombre_Contacto] numeric(18,0) NOT NULL,
	[Fecha_Creacion] datetime NOT NULL,
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_ROL](
	[ID_Usuario_Rol] int IDENTITY (1,1),
	[ID_Usuario] int NOT NULL,
	[ID_Rol] int NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Oferta](
	[ID_Oferta] int IDENTITY (1,1),
	[ID_Cliente] int NOT NULL,
	[ID_Publicacion] int NOT NULL,
	[Monto] numeric(18,2) NOT NULL,
	[Fecha] datetime NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Pregunta](
	[ID_Pregunta] int IDENTITY (1,1),
	[Codigo_Publicacion] numeric(18,2) NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Respuesta](
	[ID_Respuesta] int IDENTITY (1,1),
	[ID_Pregunta] int NOT NULL,
	[Texto] varchar,
	[Efectiva] bit NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Tipo_Publicacion](
	[ID_Funcionalidad] int IDENTITY (1,1),
	[Descripcion] nvarchar (255) NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Rubro] (
	[ID_Rubro] int IDENTITY (1,1),
	[Descripcion] nvarchar(255) NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Rubro_Publicacion](
[ID_Rubro_Publicacion] int IDENTITY (1,1),
[ID_Rubro] int NOT NULL,
[Codigo_Publicacion] int NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Visibilidad](
	[ID_Visibilidad] numeric(18, 0) UNIQUE NOT NULL,
	[Descripcion] nvarchar(255) NOT NULL,
	[Precio_Publicar] numeric(18, 2) NOT NULL,
	[Porcentaje_Venta] numeric(18, 2) NOT NULL 
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Estado_Publicacion](
	[ID_Estado_Publicacion] int IDENTITY (1,1),
	[Descripcion] nvarchar (255) NOT NULL,
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Factura] (
	[ID_Factura] int IDENTITY (1,1),
	[Numero] numeric(18, 0) UNIQUE NOT NULL,
	[Fecha] datetime NOT NULL,
	[Descripcion_Forma_Pago] nvarchar(255) NOT NULL,
	[Total] numeric(18, 2) NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Item_Factura] (
	[ID_Item_Factura] int IDENTITY (1,1),
	[ID_Factura] int NOT NULL,
	[ID_Publicacion] int NOT NULL,
	[Monto] numeric(18, 2) NOT NULL,
	[Cantidad] numeric(18, 0) NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Calificacion] (
	[Codigo_Calificacion] numeric(18,0) UNIQUE,
	[ID_Publicacion] int NOT NULL,
	[ID_Comprador] int NOT NULL,
	[Cantidad_Estrellas] numeric(18, 0),
	[Descripcion] nvarchar(255)
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Publicacion](
	[ID_Publicacion] numeric(18, 0) UNIQUE,
	[ID_Tipo_Publicacion] int NOT NULL,
	[Descripcion] nvarchar(255) NOT NULL,
	[ID_Usuario] int NOT NULL,
	[ID_Comprador] int NOT NULL,
	[Stock] numeric(18, 0) NOT NULL,
	[Fecha_Vencimiento] datetime NOT NULL,
	[Fecha_Inicio] datetime NOT NULL,
	[Precio] numeric(18, 2) NOT NULL,
	[ID_Visibilidad] int NOT NULL,
	[ID_Estado_Publicacion] INT NOT NULL,
	[Permitir_Preguntas] bit DEFAULT(0)
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Compra](
	[ID_Compra] int IDENTITY (1,1),
	[ID_Publicacion] int NOT NULL,
	[ID_Usuario] int NOT NULL,
	[Compra_Fecha] datetime NOT NULL,
	[Compra_Cantidad] numeric(18, 0) NOT NULL
);