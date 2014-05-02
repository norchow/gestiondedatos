--INICIO PRIMER PASO--
--CREAR EL SCHEMA DE LA BASE DE DATOS--
USE [GD1C2014];
CREATE SCHEMA [LA_BANDA_DEL_CHAVO] AUTHORIZATION [gd];
--FIN PRIMER PASO--

--INICIO SEGUNDO PASO--
--CREO LAS TABLAS DE DATOS--
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

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Rol](
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
	[ID_Publicacion] int NOT NULL
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
	[ID_Publicacion] int NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Visibilidad](
	[ID_Visibilidad] int UNIQUE NOT NULL,
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
	[Codigo_Calificacion] numeric(18,0) UNIQUE NOT NULL,
	[ID_Publicacion] int NOT NULL,
	[ID_Comprador] int NOT NULL,
	[Cantidad_Estrellas] numeric(18, 0),
	[Descripcion] nvarchar(255)
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Publicacion](
	[ID_Publicacion] int UNIQUE NOT NULL,
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
--FIN SEGUNDO PASO--

--INICIO TERCER PASO--
--CREO LAS PRIMARY KEYS--
ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Calificacion]
ADD PRIMARY KEY ([Codigo_Calificacion]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Cliente]
ADD PRIMARY KEY ([ID_Cliente]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Compra]
ADD PRIMARY KEY ([ID_Compra]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Empresa]
ADD PRIMARY KEY ([ID_Empresa]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Estado_Publicacion]
ADD PRIMARY KEY ([ID_Estado_Publicacion]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Factura]
ADD PRIMARY KEY ([ID_Factura]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad]
ADD PRIMARY KEY ([ID_Funcionalidad]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad_Rol]
ADD PRIMARY KEY ([ID_Funcionalidad_Rol]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Item_Factura]
ADD PRIMARY KEY ([ID_Item_Factura]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Oferta]
ADD PRIMARY KEY ([ID_Oferta]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Pregunta]
ADD PRIMARY KEY ([ID_Pregunta]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Publicacion]
ADD PRIMARY KEY ([ID_Publicacion]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Respuesta]
ADD PRIMARY KEY ([ID_Respuesta]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Rol]
ADD PRIMARY KEY ([ID_Rol]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Rubro]
ADD PRIMARY KEY ([ID_Rubro]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Rubro_Publicacion]
ADD PRIMARY KEY ([ID_Rubro_Publicacion]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Tipo_Publicacion]
ADD PRIMARY KEY ([ID_Tipo_Publicacion]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario]
ADD PRIMARY KEY ([ID_Usuario]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Rol]
ADD PRIMARY KEY ([ID_Usuario_Rol]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Visibilidad]
ADD PRIMARY KEY ([ID_Visibilidad]);
--FIN TERCER PASO--

--INICIO CUARTO PASO--
--CREO LAS FOREIGN KEYS--
ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Calificacion]
ADD FOREIGN KEY ([ID_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Publicacion](ID_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Calificacion]
ADD FOREIGN KEY ([ID_Comprador])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Cliente]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Compra]
ADD FOREIGN KEY ([ID_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Publicacion](ID_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Compra]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Empresa]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad_Rol]
ADD FOREIGN KEY ([ID_Funcionalidad])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad](ID_Funcionalidad);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad_Rol]
ADD FOREIGN KEY ([ID_Rol])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Rol](ID_Rol);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Item_Factura]
ADD FOREIGN KEY ([ID_Factura])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Factura](ID_Factura);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Item_Factura]
ADD FOREIGN KEY ([ID_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Publicacion](ID_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Oferta]
ADD FOREIGN KEY ([ID_Cliente])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Cliente](ID_Cliente);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Oferta]
ADD FOREIGN KEY ([ID_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Publicacion](ID_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Pregunta]
ADD FOREIGN KEY ([ID_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Publicacion](ID_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Publicacion]
ADD FOREIGN KEY ([ID_Tipo_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Tipo_Publicacion](ID_Tipo_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Publicacion]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Publicacion]
ADD FOREIGN KEY ([ID_Comprador])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Publicacion]
ADD FOREIGN KEY ([ID_Visibilidad])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Visibilidad](ID_Visibilidad);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Publicacion]
ADD FOREIGN KEY ([ID_Estado_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Estado_Publicacion](ID_Estado_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Respuesta]
ADD FOREIGN KEY ([ID_Pregunta])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Pregunta](ID_Pregunta);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Rubro_Publicacion]
ADD FOREIGN KEY ([ID_Rubro])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Rubro](ID_Rubro);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Rubro_Publicacion]
ADD FOREIGN KEY ([ID_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Publicacion](ID_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Rol]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Rol]
ADD FOREIGN KEY ([ID_Rol])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Rol](ID_Rol);
--FIN CUARTO PASO--