CREATE SCHEMA [LA_BANDA_DEL_CHAVO] AUTHORIZATION [gd];
GO
BEGIN TRANSACTION
CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario](
	[ID_Usuario] int IDENTITY (1,1),
	[Username] nvarchar(255) NOT NULL,
	[Password] nvarchar (64) NOT NULL,
	[Pass_Temporal] bit DEFAULT 0
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Rol](
	[ID_Rol] int IDENTITY (1,1),
	[Descripcion] nvarchar (255) NOT NULL,
	[Activo] bit NOT NULL DEFAULT(1)
);

INSERT INTO LA_BANDA_DEL_CHAVO.TL_Rol (Descripcion) VALUES ('Cliente');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Rol (Descripcion) VALUES ('Empresa');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Rol (Descripcion) VALUES ('Administrativo');

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad](
	[ID_Funcionalidad] int IDENTITY (1,1),
	[Descripcion] nvarchar (255) NOT NULL
);

INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('ABM de Rol');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('Registro de Usuario');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('ABM de Cliente (comprador/vendedor)');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('ABM de Empresa (Vendedor)');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('ABM de Rubro');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('ABM visibilidad de publicacion');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('Generar Publicacion');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('Editar Publicacion');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('Gestion de Preguntas');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('Comprar/Ofertar');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('Historial del cliente');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('Calificar al Vendedor');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('Facturar Publicaciones');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('Listado Estadistico');

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
	[CUIL] nvarchar(50),
	[Activo] bit NOT NULL DEFAULT(1)
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Empresa](
	[ID_Empresa] int IDENTITY (1,1),
	[ID_Usuario] int NOT NULL,
	[Razon_Social] nvarchar(255) NOT NULL,
	[Mail] nvarchar(255) NOT NULL,
	[Telefono] nvarchar(255),
	[Direccion] nvarchar(255) NOT NULL,
	[Codigo_Postal] nvarchar(255) NOT NULL,
	[Ciudad] nvarchar(255),
	[CUIT] nvarchar(50) NOT NULL,
	[Nombre_Contacto] nvarchar(255),
	[Fecha_Creacion] datetime NOT NULL,
	[Activo] bit NOT NULL DEFAULT(1)
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Rol](
	[ID_Usuario_Rol] int IDENTITY (1,1),
	[ID_Usuario] int NOT NULL,
	[ID_Rol] int NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Oferta](
	[ID_Oferta] int IDENTITY (1,1),
	[ID_Cliente] int NOT NULL,
	[ID_Publicacion] numeric(18,0) NOT NULL,
	[Monto] numeric(18,2) NOT NULL,
	[Fecha] datetime NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Pregunta](
	[ID_Pregunta] int IDENTITY (1,1),
	[ID_Publicacion] numeric(18,0) NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Respuesta](
	[ID_Respuesta] int IDENTITY (1,1),
	[ID_Pregunta] int NOT NULL,
	[Texto] varchar,
	[Efectiva] bit NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Tipo_Publicacion](
	[ID_Tipo_Publicacion] int IDENTITY (1,1),
	[Descripcion] nvarchar (255) NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Rubro] (
	[ID_Rubro] int IDENTITY (1,1),
	[Descripcion] nvarchar(255) NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Rubro_Publicacion] (
	[ID_Rubro_Publicacion] int IDENTITY (1,1),
	[ID_Rubro] int NOT NULL,
	[ID_Publicacion] numeric(18,0) NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Visibilidad](
	[ID_Visibilidad] numeric(18,0) UNIQUE NOT NULL,
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
	[ID_Publicacion] numeric(18,0) NOT NULL,
	[Monto] numeric(18, 2) NOT NULL,
	[Cantidad] numeric(18, 0) NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Calificacion] (
	[Codigo_Calificacion] numeric(18,0) UNIQUE NOT NULL,
	[ID_Publicacion] numeric(18,0) NOT NULL,
	[ID_Comprador] int NOT NULL,
	[Cantidad_Estrellas] numeric(18, 0),
	[Descripcion] nvarchar(255)
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Publicacion](
	[ID_Publicacion] numeric(18,0) UNIQUE NOT NULL,
	[ID_Tipo_Publicacion] int NOT NULL,
	[Descripcion] nvarchar(255) NOT NULL,
	[ID_Usuario] int NOT NULL,
	[Stock] numeric(18, 0) NOT NULL,
	[Fecha_Vencimiento] datetime NOT NULL,
	[Fecha_Inicio] datetime NOT NULL,
	[Precio] numeric(18, 2) NOT NULL,
	[ID_Visibilidad] numeric(18,0) NOT NULL,
	[ID_Estado_Publicacion] INT NOT NULL,
	[Permitir_Preguntas] bit DEFAULT(1)
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Compra](
	[ID_Compra] int IDENTITY (1,1),
	[ID_Publicacion] numeric(18,0) NOT NULL,
	[ID_Usuario] int NOT NULL,
	[Compra_Fecha] datetime NOT NULL,
	[Compra_Cantidad] numeric(18, 0) NOT NULL
);

 CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Tipo_Documento] (
	[ID_Tipo_Documento] int IDENTITY (1,1),
	[Descripcion] nvarchar(50) NOT NULL
);

INSERT INTO LA_BANDA_DEL_CHAVO.TL_Tipo_Documento (Descripcion) VALUES ('DNI');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Tipo_Documento (Descripcion) VALUES ('CI');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Tipo_Documento (Descripcion) VALUES ('LC');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Tipo_Documento (Descripcion) VALUES ('LE');

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Visibilidad] (
	[ID_Usuario_Visibilidad] int IDENTITY (1,1),
	[ID_Usuario] int NOT NULL,
	[ID_Visibilidad] numeric(18,0) NOT NULL,
	[Cantidad_compras] int NOT NULL,
);

COMMIT