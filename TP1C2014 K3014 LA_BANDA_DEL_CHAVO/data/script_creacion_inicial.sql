CREATE SCHEMA [LA_BANDA_DEL_CHAVO] AUTHORIZATION [gd];
GO
BEGIN TRANSACTION
CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario](
	[ID_Usuario] int IDENTITY (1,1),
	[Username] nvarchar(255) NOT NULL,
	[Password] nvarchar (64) NOT NULL,
	[Intentos_Fallidos] int DEFAULT 0,
	[Pass_Temporal] bit DEFAULT 0,
	[Activo] bit DEFAULT 1,
	[Habilitado] bit DEFAULT 1,
	[Reputacion] numeric(18,2) DEFAULT 0
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
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('ABM de Cliente (Comprador/Vendedor)');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('ABM de Empresa (Vendedor)');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('ABM de Usuarios');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('ABM de Rubro');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('ABM de Visibilidad de Publicacion');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('Generar Publicacion');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('Editar Publicacion');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('Gestion de Preguntas');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('Comprar/Ofertar');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('Historial del Cliente');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('Calificar al Vendedor');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('Facturar Publicaciones');
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad(Descripcion) VALUES ('Listado Estadistico');

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad_Rol](
	[ID_Funcionalidad_Rol] int IDENTITY (1,1),
	[ID_Funcionalidad] int NOT NULL,
	[ID_Rol] int NOT NULL
);

INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad_Rol (ID_Rol, ID_Funcionalidad) (
		(SELECT ID_Rol, ID_Funcionalidad 
		FROM LA_BANDA_DEL_CHAVO.TL_Rol, LA_BANDA_DEL_CHAVO.TL_Funcionalidad
		WHERE LA_BANDA_DEL_CHAVO.TL_Rol.Descripcion = 'Cliente'
		AND (LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'Generar Publicacion'
		OR LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'Editar Publicacion'
		OR LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'Gestion de Preguntas'
		OR LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'Comprar/Ofertar'
		OR LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'Historial del Cliente'
		OR LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'Calificar al Vendedor'
		OR LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'Facturar Publicaciones'))
	);
	
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad_Rol (ID_Rol, ID_Funcionalidad) (
		(SELECT ID_Rol, ID_Funcionalidad 
		FROM LA_BANDA_DEL_CHAVO.TL_Rol, LA_BANDA_DEL_CHAVO.TL_Funcionalidad
		WHERE LA_BANDA_DEL_CHAVO.TL_Rol.Descripcion = 'Empresa'
		AND (LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'Generar Publicacion'
		OR LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'Editar Publicacion'
		OR LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'Gestion de Preguntas'
		OR LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'Historial del Cliente'
		OR LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'Facturar Publicaciones'))
	);
	
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Funcionalidad_Rol (ID_Rol, ID_Funcionalidad) (
		(SELECT ID_Rol, ID_Funcionalidad 
		FROM LA_BANDA_DEL_CHAVO.TL_Rol, LA_BANDA_DEL_CHAVO.TL_Funcionalidad
		WHERE LA_BANDA_DEL_CHAVO.TL_Rol.Descripcion = 'Administrativo'
		AND (LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'ABM de Rol'
		OR LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'Registro de Usuario'
		OR LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'ABM de Cliente (Comprador/Vendedor)'
		OR LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'ABM de Empresa (Vendedor)'
		OR LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'ABM de Rubro'
		OR LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'ABM de Visibilidad de Publicacion'
		OR LA_BANDA_DEL_CHAVO.TL_Funcionalidad.Descripcion = 'Listado Estadistico'))
	);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Cliente](
	[ID_Cliente] int IDENTITY (1,1),
	[ID_Usuario] int NOT NULL,
	[Nombre] nvarchar(255) NOT NULL,
	[Apellido] nvarchar(255) NOT NULL,
	[ID_Tipo_Documento] int NOT NULL,
	[Nro_Documento] numeric(18,0) NOT NULL,
	[Mail] nvarchar(255) NOT NULL,
	[Telefono] nvarchar(255),
	[Direccion] nvarchar(255) NOT NULL,
	[Codigo_Postal] nvarchar(255) NOT NULL,
	[Fecha_nacimiento] datetime NOT NULL,
	[CUIL] nvarchar(50)
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
	[Fecha_Creacion] datetime NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Rol](
	[ID_Usuario_Rol] int IDENTITY (1,1),
	[ID_Usuario] int NOT NULL,
	[ID_Rol] int NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Oferta](
	[ID_Oferta] int IDENTITY (1,1),
	[ID_Usuario] int NOT NULL,
	[ID_Publicacion] numeric(18,0) NOT NULL,
	[Monto] numeric(18,2) NOT NULL,
	[Fecha] datetime NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Pregunta](
	[ID_Pregunta] int IDENTITY (1,1),
	[ID_Publicacion] numeric(18,0) NOT NULL,
	[ID_Usuario] int NOT NULL,
	[Texto] nvarchar(255)
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Respuesta](
	[ID_Respuesta] int IDENTITY (1,1),
	[ID_Pregunta] int NOT NULL,
	[Texto] nvarchar(255),
	[Fecha] datetime NOT NULL
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
	[ID_Visibilidad] numeric(18, 0) NOT NULL IDENTITY (1, 1),
	[Descripcion] nvarchar(255) NOT NULL,
	[Precio_Publicar] numeric(18, 2) NOT NULL,
	[Porcentaje_Venta] numeric(18, 2) NOT NULL,
	[Duracion] numeric(18, 0) NOT NULL,
	[Activo] bit DEFAULT 1
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Estado_Publicacion](
	[ID_Estado_Publicacion] int IDENTITY (1,1),
	[Descripcion] nvarchar (255) NOT NULL,
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Factura] (
	[ID_Factura] int IDENTITY (1,1),
	[Numero] numeric(18, 0) UNIQUE NOT NULL,
	[Fecha] datetime NOT NULL,
	[Total] numeric(18, 2) NOT NULL,
	[ID_Forma_Pago] int NOT NULL,
	[ID_Usuario] int NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Item_Factura] (
	[ID_Item_Factura] int IDENTITY (1,1),
	[ID_Factura] int NOT NULL,
	[ID_Publicacion] numeric(18,0) NOT NULL,
	[Monto] numeric(18, 2) NOT NULL,
	[Cantidad] numeric(18, 0) NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Calificacion] (
	[Codigo_Calificacion] numeric(18,0) IDENTITY (1, 1),
	[ID_Publicacion] numeric(18,0) NOT NULL,
	[ID_Comprador] int NOT NULL,
	[Cantidad_Estrellas] numeric(18, 0),
	[Descripcion] nvarchar(255)
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Publicacion](
	[ID_Publicacion] numeric(18, 0) NOT NULL IDENTITY (1, 1),
	[ID_Tipo_Publicacion] int NOT NULL,
	[Descripcion] nvarchar(255) NOT NULL,
	[ID_Usuario] int NOT NULL,
	[Stock] numeric(18, 0) NOT NULL,
	[Fecha_Vencimiento] datetime NOT NULL,
	[Fecha_Inicio] datetime NOT NULL,
	[Precio] numeric(18, 2) NOT NULL,
	[ID_Visibilidad] numeric(18,0) NOT NULL,
	[ID_Estado_Publicacion] int NOT NULL,
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
	[Cantidad_Compras] int NOT NULL,
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Forma_Pago](
	[ID_Forma_Pago] int IDENTITY (1,1),
	[Descripcion] nvarchar(50) NOT NULL
);

CREATE TABLE [LA_BANDA_DEL_CHAVO].[TL_Tarjeta_Credito](
	[ID_Tarjeta_Credito] int IDENTITY (1,1),
	[Tarjeta] nvarchar(50) NOT NULL,
	[Nro_Tarjeta] numeric(16,0) NOT NULL,
	[Vencimiento] numeric(4,0) NOT NULL,
	[Cod_Seguridad] numeric(3,0) NOT NULL,
	[Titular] nvarchar(255) NOT NULL,
	[Dni_Titular] numeric(18,0) NOT NULL,
	[ID_Factura] int NOT NULL
);

COMMIT
BEGIN TRANSACTION
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

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Forma_Pago]
ADD PRIMARY KEY ([ID_Forma_Pago]);

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

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Tarjeta_Credito]
ADD PRIMARY KEY ([ID_Tarjeta_Credito]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Tipo_Documento]
ADD PRIMARY KEY ([ID_Tipo_Documento]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Tipo_Publicacion]
ADD PRIMARY KEY ([ID_Tipo_Publicacion]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario]
ADD PRIMARY KEY ([ID_Usuario]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Rol]
ADD PRIMARY KEY ([ID_Usuario_Rol]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Visibilidad]
ADD PRIMARY KEY ([ID_Usuario],[ID_Visibilidad]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Visibilidad]
ADD PRIMARY KEY ([ID_Visibilidad]);
COMMIT
 BEGIN TRANSACTION
 INSERT INTO LA_BANDA_DEL_CHAVO.TL_Empresa (ID_Usuario,Razon_Social,Mail,Telefono,Direccion,Codigo_Postal,Ciudad,CUIT,Nombre_Contacto,Fecha_Creacion)(
  SELECT DISTINCT 0
	  ,[Publ_Empresa_Razon_Social]
	  ,[Publ_Empresa_Mail]
	  ,NULL
	  ,[Publ_Empresa_Dom_Calle]+' '+CAST([Publ_Empresa_Nro_Calle] AS VARCHAR)+' '+CAST([Publ_Empresa_Piso] AS VARCHAR)+' '+[Publ_Empresa_Depto] AS Direccion
      ,[Publ_Empresa_Cod_Postal]
      ,NULL
      ,[Publ_Empresa_Cuit]
      ,NULL
      ,[Publ_Empresa_Fecha_Creacion]
 FROM gd_esquema.Maestra
 WHERE Publ_Empresa_Razon_Social IS NOT NULL);
 COMMIT

 BEGIN TRANSACTION
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Cliente (ID_Usuario,Nombre,Apellido,ID_Tipo_Documento,Nro_Documento,Mail,Telefono,Direccion,Codigo_Postal,Fecha_nacimiento)(
  SELECT DISTINCT 0
	  ,LEFT([Publ_Cli_Nombre],1)+LOWER(SUBSTRING([Publ_Cli_Nombre],2,LEN([Publ_Cli_Nombre])))
	  ,[Publ_Cli_Apeliido]
	  ,1
	  ,[Publ_Cli_Dni]
	  ,[Publ_Cli_Mail]
	  ,NULL
	  ,[Publ_Cli_Dom_Calle]+' '+CAST([Publ_Cli_Nro_Calle] AS VARCHAR)+' '+CAST([Publ_Cli_Piso] AS VARCHAR)+' '+[Publ_Cli_Depto] AS Direccion
      ,[Publ_Cli_Cod_Postal]
      ,[Publ_Cli_Fecha_Nac]
 FROM gd_esquema.Maestra
 WHERE [Publ_Cli_Dni] IS NOT NULL); 
 COMMIT
 
 BEGIN TRANSACTION
	 INSERT INTO LA_BANDA_DEL_CHAVO.TL_Tipo_Publicacion (Descripcion)(
	 SELECT DISTINCT Publicacion_Tipo FROM gd_esquema.Maestra);
 COMMIT
 
 BEGIN TRANSACTION
	 INSERT INTO LA_BANDA_DEL_CHAVO.TL_Estado_Publicacion (Descripcion) VALUES ('Borrador');
	 INSERT INTO LA_BANDA_DEL_CHAVO.TL_Estado_Publicacion (Descripcion) VALUES ('Publicada');
	 INSERT INTO LA_BANDA_DEL_CHAVO.TL_Estado_Publicacion (Descripcion) VALUES ('Pausada');
	 INSERT INTO LA_BANDA_DEL_CHAVO.TL_Estado_Publicacion (Descripcion) VALUES ('Finalizada');
 COMMIT
 
 BEGIN TRANSACTION
 
	SET IDENTITY_INSERT LA_BANDA_DEL_CHAVO.TL_Visibilidad ON
  
	 INSERT INTO LA_BANDA_DEL_CHAVO.TL_Visibilidad(ID_Visibilidad, Descripcion, Precio_Publicar,Porcentaje_Venta, Duracion)(
	 SELECT DISTINCT [Publicacion_Visibilidad_Cod]
      ,[Publicacion_Visibilidad_Desc]
      ,[Publicacion_Visibilidad_Precio]
      ,[Publicacion_Visibilidad_Porcentaje]
      ,(SELECT DISTINCT DATEDIFF(day,Publicacion_Fecha,Publicacion_Fecha_Venc)
		  FROM gd_esquema.Maestra
		  WHERE Publicacion_Visibilidad_Cod = [Publicacion_Visibilidad_Cod])
      FROM gd_esquema.Maestra);
      
      SET IDENTITY_INSERT LA_BANDA_DEL_CHAVO.TL_Visibilidad OFF

	DECLARE @maxIdVisibilidad numeric(18,0);
	SELECT @maxIdVisibilidad = MAX(Publicacion_Visibilidad_Cod) FROM gd_esquema.Maestra DBCC CHECKIDENT ('LA_BANDA_DEL_CHAVO.TL_Visibilidad', RESEED, @maxIdVisibilidad);
 COMMIT
 
 BEGIN TRANSACTION
	 INSERT INTO LA_BANDA_DEL_CHAVO.TL_Usuario(Username, Password,Pass_Temporal)(
	 SELECT CUIT,'e4540a7c8404b1becfed2f0ca242bec6cfd6096a8d944555145aafe5eab77c69',1 FROM LA_BANDA_DEL_CHAVO.TL_Empresa);
 COMMIT
 
 BEGIN TRANSACTION
	 INSERT INTO LA_BANDA_DEL_CHAVO.TL_Usuario(Username, Password,Pass_Temporal)(
	 SELECT Nro_Documento,'e4540a7c8404b1becfed2f0ca242bec6cfd6096a8d944555145aafe5eab77c69',1 FROM LA_BANDA_DEL_CHAVO.TL_Cliente);
 COMMIT
 
BEGIN TRANSACTION

SET IDENTITY_INSERT LA_BANDA_DEL_CHAVO.TL_Publicacion ON

INSERT INTO LA_BANDA_DEL_CHAVO.TL_Publicacion (ID_Publicacion,ID_Tipo_Publicacion,Descripcion,ID_Usuario,Stock,Fecha_Vencimiento,Fecha_Inicio,Precio,ID_Visibilidad,ID_Estado_Publicacion)(
  SELECT DISTINCT [Publicacion_Cod]
	  ,(SELECT TP.ID_Tipo_Publicacion FROM LA_BANDA_DEL_CHAVO.TL_Tipo_Publicacion TP WHERE TP.Descripcion=[Publicacion_Tipo])
      ,[Publicacion_Descripcion]
      ,(SELECT U.ID_Usuario FROM LA_BANDA_DEL_CHAVO.TL_Usuario U WHERE U.Username = CONVERT(nvarchar(255),[Publ_Cli_Dni]) OR U.Username = [Publ_Empresa_Cuit]) 
      ,[Publicacion_Stock]
      ,[Publicacion_Fecha_Venc]
      ,[Publicacion_Fecha]
      ,[Publicacion_Precio]
      ,[Publicacion_Visibilidad_Cod]
      ,(SELECT EP.ID_Estado_Publicacion FROM LA_BANDA_DEL_CHAVO.TL_Estado_Publicacion EP WHERE EP.Descripcion='Finalizada')
 FROM gd_esquema.Maestra
 WHERE [Publicacion_Cod] IS NOT NULL); 
 
 SET IDENTITY_INSERT LA_BANDA_DEL_CHAVO.TL_Publicacion OFF

 DECLARE @maxIdPublicacion numeric(18,0);
 SELECT @maxIdPublicacion = MAX(Publicacion_Cod) FROM gd_esquema.Maestra DBCC CHECKIDENT ('LA_BANDA_DEL_CHAVO.TL_Publicacion', RESEED, @maxIdPublicacion);
COMMIT

BEGIN TRANSACTION
	UPDATE LA_BANDA_DEL_CHAVO.TL_Empresa
	SET ID_Usuario = (SELECT ID_Usuario FROM LA_BANDA_DEL_CHAVO.TL_Usuario U
						WHERE CUIT = U.Username)
COMMIT

BEGIN TRANSACTION
	UPDATE LA_BANDA_DEL_CHAVO.TL_Cliente
	SET ID_Usuario = (SELECT ID_Usuario FROM LA_BANDA_DEL_CHAVO.TL_Usuario U
						WHERE CONVERT(nvarchar(255),Nro_Documento) = U.Username)
COMMIT

BEGIN TRANSACTION 
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Usuario_Rol] (ID_Usuario, ID_Rol) 
	(
		SELECT [ID_Usuario], [ID_Rol] 
		FROM [LA_BANDA_DEL_CHAVO].[TL_Cliente],[LA_BANDA_DEL_CHAVO].TL_Rol
		WHERE ([Descripcion] = 'Cliente')
	);
COMMIT

BEGIN TRANSACTION 
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Usuario_Rol] (ID_Usuario, ID_Rol) 
	(
		SELECT [ID_Usuario], [ID_Rol] 
		FROM [LA_BANDA_DEL_CHAVO].[TL_Empresa],[LA_BANDA_DEL_CHAVO].TL_Rol
		WHERE ([Descripcion] = 'Empresa')
	);
COMMIT

BEGIN TRANSACTION
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Usuario_Visibilidad] (ID_Usuario, ID_Visibilidad, Cantidad_compras) (
		SELECT ID_Usuario, ID_Visibilidad, COUNT(*) % 10
		FROM LA_BANDA_DEL_CHAVO.TL_Publicacion
		GROUP BY ID_Usuario, ID_Visibilidad
		)ORDER BY 1
COMMIT

BEGIN TRANSACTION

	SET IDENTITY_INSERT LA_BANDA_DEL_CHAVO.TL_Calificacion ON

	INSERT INTO LA_BANDA_DEL_CHAVO.TL_Calificacion (Codigo_Calificacion, ID_Publicacion, ID_Comprador, Cantidad_Estrellas, Descripcion) (
		SELECT [Calificacion_Codigo],
			   [Publicacion_Cod],
			   (SELECT u.ID_Usuario FROM LA_BANDA_DEL_CHAVO.TL_Usuario U 
				WHERE CONVERT(nvarchar(255), Cli_Dni) = U.Username),
		       CAST(ROUND([Calificacion_Cant_Estrellas]/2,0) AS INT),
		       [Calificacion_Descripcion]
		FROM gd_esquema.Maestra
		WHERE [Calificacion_Codigo] IS NOT NULL)
		
	SET IDENTITY_INSERT LA_BANDA_DEL_CHAVO.TL_Calificacion OFF

	DECLARE @maxIdCalificacion numeric(18,0);
	SELECT @maxIdCalificacion = MAX(Calificacion_Codigo) FROM gd_esquema.Maestra DBCC CHECKIDENT ('LA_BANDA_DEL_CHAVO.TL_Calificacion', RESEED, @maxIdCalificacion);
COMMIT

BEGIN TRANSACTION 
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Oferta] (ID_Usuario, ID_Publicacion, Monto, Fecha) (
		SELECT 
			(SELECT ID_Usuario FROM LA_BANDA_DEL_CHAVO.TL_Cliente C WHERE Cli_Dni = C.Nro_Documento),
			[Publicacion_Cod],
			[Oferta_Monto],
			[Oferta_Fecha]
		FROM gd_esquema.Maestra
		WHERE [Publicacion_Tipo] = 'Subasta'
		AND [Oferta_Monto] IS NOT NULL)
COMMIT

BEGIN TRANSACTION 
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Compra] (ID_Publicacion, ID_Usuario, Compra_Fecha, Compra_Cantidad) (
		SELECT DISTINCT
			[Publicacion_Cod],
			(SELECT ID_Usuario FROM LA_BANDA_DEL_CHAVO.TL_Cliente C WHERE Cli_Dni = C.Nro_Documento),
			[Compra_Fecha],
			[Compra_Cantidad]
		FROM gd_esquema.Maestra
		WHERE [Publicacion_Tipo] = 'Compra Inmediata'
		AND [Compra_Cantidad] IS NOT NULL)
COMMIT

BEGIN TRANSACTION
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Compra] (ID_Publicacion, ID_Usuario, Compra_Fecha, Compra_Cantidad) (
		SELECT ID_Publicacion, Id_Usuario, Fecha, 1 FROM LA_BANDA_DEL_CHAVO.TL_Oferta O
		WHERE Monto = (SELECT MAX(MONTO) 
						FROM LA_BANDA_DEL_CHAVO.TL_Oferta 
						GROUP BY ID_Publicacion 
						HAVING ID_Publicacion=O.ID_Publicacion))
COMMIT

BEGIN TRANSACTION
INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Forma_Pago] (Descripcion) (
	SELECT DISTINCT [Forma_Pago_Desc]
	FROM [gd_esquema].[Maestra]
	WHERE [Forma_Pago_Desc] IS NOT NULL)
COMMIT

BEGIN TRANSACTION

INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Forma_Pago] (Descripcion) VALUES ('Tarjeta de Crédito');
INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Forma_Pago] (Descripcion) VALUES ('Tarjeta de Débito');

COMMIT

BEGIN TRANSACTION 
INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Factura] (Numero, Fecha, Total, ID_Forma_Pago, ID_Usuario) (
	SELECT DISTINCT [Factura_Nro],
	 [Factura_Fecha],
	 [Factura_Total],
	 (SELECT ID_Forma_Pago FROM LA_BANDA_DEL_CHAVO.TL_Forma_Pago FP WHERE FP.Descripcion=[Forma_Pago_Desc]),
	 (SELECT U.ID_Usuario FROM LA_BANDA_DEL_CHAVO.TL_Usuario U WHERE U.Username = CONVERT(nvarchar(255),[Publ_Cli_Dni]) OR U.Username = [Publ_Empresa_Cuit])
	FROM [gd_esquema].[Maestra]
	WHERE [Factura_Fecha] IS NOT NULL)
COMMIT


BEGIN TRANSACTION 
INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Item_Factura] (ID_Factura, ID_Publicacion,	Monto, Cantidad) (
	SELECT (SELECT ID_Factura FROM LA_BANDA_DEL_CHAVO.TL_Factura WHERE Numero=[Factura_Nro]),
	(SELECT ID_Publicacion FROM LA_BANDA_DEL_CHAVO.TL_Publicacion WHERE ID_Publicacion=[Publicacion_Cod]),
	[Item_Factura_Monto],
    [Item_Factura_Cantidad]
	FROM [gd_esquema].[Maestra]
	WHERE [Factura_Nro] IS NOT NULL)
COMMIT

BEGIN TRANSACTION 
INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Rubro] (Descripcion) (
	SELECT DISTINCT [Publicacion_Rubro_Descripcion]
	FROM [gd_esquema].[Maestra]
	WHERE [Publicacion_Rubro_Descripcion] IS NOT NULL)
COMMIT

BEGIN TRANSACTION 
INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Rubro_Publicacion] (ID_Rubro, ID_Publicacion) (
	SELECT DISTINCT
	(SELECT ID_Rubro FROM LA_BANDA_DEL_CHAVO.TL_Rubro R WHERE R.Descripcion = [Publicacion_Rubro_Descripcion]),
	(SELECT ID_Publicacion FROM LA_BANDA_DEL_CHAVO.TL_Publicacion P WHERE P.ID_Publicacion = [Publicacion_Cod])
	FROM gd_esquema.Maestra
	WHERE [Publicacion_Cod] IS NOT NULL)
COMMIT

BEGIN TRANSACTION 
UPDATE [LA_BANDA_DEL_CHAVO].[TL_Usuario]
SET [Reputacion] = (SELECT AVG(Cantidad_Estrellas)
					FROM [LA_BANDA_DEL_CHAVO].[TL_Calificacion] C
					INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion] P ON P.ID_Publicacion = C.ID_Publicacion
					WHERE P.ID_Usuario = [LA_BANDA_DEL_CHAVO].[TL_Usuario].ID_Usuario)
COMMIT
BEGIN TRANSACTION
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

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Empresa]
ADD UNIQUE ([Razon_Social]);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Empresa]
ADD UNIQUE ([CUIT]);

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
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Oferta]
ADD FOREIGN KEY ([ID_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Publicacion](ID_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Pregunta]
ADD FOREIGN KEY ([ID_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Publicacion](ID_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Pregunta]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Publicacion]
ADD FOREIGN KEY ([ID_Tipo_Publicacion])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Tipo_Publicacion](ID_Tipo_Publicacion);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Publicacion]
ADD FOREIGN KEY ([ID_Usuario])
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

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Visibilidad]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Visibilidad]
ADD FOREIGN KEY ([ID_Visibilidad])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Visibilidad](ID_Visibilidad);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Tarjeta_Credito]
ADD FOREIGN KEY ([ID_Factura])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Factura](ID_Factura);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Cliente]
ADD FOREIGN KEY ([ID_Tipo_Documento])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Tipo_Documento](ID_Tipo_Documento);

ALTER TABLE [LA_BANDA_DEL_CHAVO].[TL_Factura]
ADD FOREIGN KEY ([ID_Usuario])
REFERENCES [LA_BANDA_DEL_CHAVO].[TL_Usuario](ID_Usuario);
COMMIT
BEGIN TRANSACTION

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdateUser]
	@ID_User int,
	@Intentos_Fallidos int,
	@Activo bit
AS
BEGIN
	UPDATE [LA_BANDA_DEL_CHAVO].[TL_Usuario]
	SET Intentos_Fallidos = @Intentos_Fallidos, Activo = @Activo
	WHERE ID_Usuario = @ID_User
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdateRolById]
	@ID_Rol int,
	@Descripcion nvarchar(255),
	@Activo bit
AS
BEGIN
	UPDATE [LA_BANDA_DEL_CHAVO].[TL_Rol]
	SET Descripcion = @Descripcion, Activo = @Activo
	WHERE ID_Rol = @ID_Rol
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetRolByName]
	@Descripcion nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [LA_BANDA_DEL_CHAVO].[TL_Rol]
	WHERE LOWER(Descripcion) = LOWER(@Descripcion)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdatePassword]
	@ID_User int,
	@Password nvarchar(64)
AS
BEGIN
	UPDATE [LA_BANDA_DEL_CHAVO].[TL_Usuario]
	SET Password = @Password, Pass_Temporal = 0
	WHERE ID_Usuario = @ID_User
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetUserByUsername]
	@Username varchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Usuario]
	WHERE [Username] = @Username
	AND [Habilitado] = 1
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetUserById]
	@Id_Usuario varchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Usuario]
	WHERE [ID_Usuario] = @Id_Usuario
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllRolByUser]
	@ID_User int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Rol] R
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Usuario_Rol] UR ON R.ID_Rol = UR.ID_Rol
	WHERE UR.ID_Usuario = @ID_User
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllFuncionalidadByRol]
	@ID_Rol int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad] F
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad_Rol] FR ON F.ID_Funcionalidad = FR.ID_Funcionalidad
	WHERE FR.ID_Rol = @ID_Rol 
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllFuncionalidad]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad]
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllTipoPublicacion]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Tipo_Publicacion]
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllTipoPublicacionById]
	@ID_Tipo_Publicacion int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Tipo_Publicacion]
	WHERE ID_Tipo_Publicacion = @ID_Tipo_Publicacion
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllEstadoPublicacion]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Estado_Publicacion]
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllEstadoPublicacionById]
	@ID_Estado_Publicacion int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Estado_Publicacion]
	WHERE ID_Estado_Publicacion = @ID_Estado_Publicacion
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllRol]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Rol]
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllRubro]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Rubro]
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertFuncionalidadByRol]
	@ID_Funcionalidad int,
	@ID_Rol int
AS
BEGIN
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad_Rol] (ID_Funcionalidad, ID_Rol)
	VALUES (@ID_Funcionalidad, @ID_Rol)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertRol]
	@Descripcion nvarchar(255),
	@Activo bit
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Rol] (Descripcion, Activo)
	OUTPUT inserted.ID_Rol
	VALUES (@Descripcion, @Activo)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[DeleteAllFuncionalidadByRol]
	@ID_Rol int
AS
BEGIN
	DELETE FROM [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad_Rol] 
	WHERE [ID_Rol] = @ID_Rol 
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllRolByNameLike]
	@Descripcion nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Rol]
	WHERE LOWER(Descripcion) LIKE '%' + LOWER(@Descripcion) + '%';
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllVisibilidad]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Visibilidad]
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllVisibilidadActive]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Visibilidad]
	WHERE Activo = 1
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertVisibilidad]
	@Descripcion nvarchar(255),
	@Precio_Publicar numeric(18,2),
	@Porcentaje_Venta numeric(18,2),
	@Duracion numeric(18,0),
	@Activo bit
AS
BEGIN
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Visibilidad] (Descripcion, Precio_Publicar, Porcentaje_Venta, Duracion, Activo)
	VALUES (@Descripcion, @Precio_Publicar, @Porcentaje_Venta, @Duracion, @Activo)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdateVisibilidad]
	@ID_Visibilidad numeric(18,0),
	@Descripcion nvarchar(255),
	@Precio_Publicar numeric(18,2),
	@Porcentaje_Venta numeric(18,2),
	@Duracion numeric(18,0),
	@Activo bit
AS
BEGIN
	UPDATE [LA_BANDA_DEL_CHAVO].[TL_Visibilidad]
	SET Descripcion = @Descripcion, Precio_Publicar = @Precio_Publicar, Porcentaje_Venta = @Porcentaje_Venta, Duracion = @Duracion, Activo = @Activo
	WHERE ID_Visibilidad = @ID_Visibilidad
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetVisibilidadById]
	@ID_Visibilidad numeric(18,0)
AS
BEGIN
	SELECT * FROM [LA_BANDA_DEL_CHAVO].[TL_Visibilidad]
	WHERE ID_Visibilidad = @ID_Visibilidad
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetPublicacionById]
	@ID_Publicacion numeric(18,0)
AS
BEGIN
	SELECT * FROM [LA_BANDA_DEL_CHAVO].[TL_Publicacion]
	WHERE ID_Publicacion = @ID_Publicacion
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllVisibilidadByParameters]
	@Descripcion nvarchar(255) = NULL,
	@Precio_Publicar numeric(18,2) = NULL,
	@Porcentaje_Venta numeric(18,2) = NULL,
	@Duracion numeric(18,0) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Visibilidad] v
	WHERE ((LOWER(v.[Descripcion]) = LOWER(@Descripcion)) OR @Descripcion is NULL)
	AND ((v.[Precio_Publicar] = @Precio_Publicar) OR @Precio_Publicar is NULL)
	AND ((v.[Porcentaje_Venta] = @Porcentaje_Venta) OR @Porcentaje_Venta is NULL)
	AND ((v.[Duracion] = @Duracion) OR @Duracion is NULL)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllVisibilidadByParametersLike]
	@Descripcion nvarchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Visibilidad] v
	WHERE ((LOWER(v.[Descripcion]) LIKE '%' + LOWER(@Descripcion) + '%') OR @Descripcion is NULL)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertPublicacion]
	@ID_Tipo_Publicacion int,
	@Descripcion nvarchar(255),
	@ID_Usuario int,
	@Stock numeric(18,0),
	@Fecha_Vencimiento datetime,
	@Fecha_Inicio datetime,
	@Precio numeric(18,2),
	@ID_Visibilidad numeric(18,0),
	@ID_Estado_Publicacion int,
	@Permitir_Preguntas bit
AS
BEGIN
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Publicacion] (ID_Tipo_Publicacion, Descripcion, ID_Usuario, Stock, Fecha_Vencimiento, Fecha_Inicio, Precio, ID_Visibilidad, ID_Estado_Publicacion, Permitir_Preguntas)
	OUTPUT inserted.ID_Publicacion
	VALUES (@ID_Tipo_Publicacion, @Descripcion, @ID_Usuario, @Stock, @Fecha_Vencimiento, @Fecha_Inicio, @Precio, @ID_Visibilidad, @ID_Estado_Publicacion, @Permitir_Preguntas)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdatePublicacion]
	@ID_Publicacion int,
	@ID_Tipo_Publicacion int,
	@Descripcion nvarchar(255),
	@Stock numeric(18,0),
	@Precio numeric(18,2),
	@ID_Visibilidad numeric(18,0),
	@ID_Estado_Publicacion int,
	@Permitir_Preguntas bit
AS
BEGIN
	UPDATE [LA_BANDA_DEL_CHAVO].[TL_Publicacion] SET ID_Tipo_Publicacion = @ID_Tipo_Publicacion, Descripcion = @Descripcion, Stock = @Stock, Precio = @Precio, ID_Visibilidad = @ID_Visibilidad, ID_Estado_Publicacion = @ID_Estado_Publicacion, Permitir_Preguntas = @Permitir_Preguntas
	WHERE (ID_Publicacion = @ID_Publicacion)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertRubroByPublicacion]
	@ID_Rubro int,
	@ID_Publicacion int
AS
BEGIN
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Rubro_Publicacion](ID_Rubro, ID_Publicacion)
	VALUES (@ID_Rubro, @ID_Publicacion)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[DeleteRubroByPublicacion]
	@ID_Publicacion int
AS
BEGIN
	DELETE FROM [LA_BANDA_DEL_CHAVO].[TL_Rubro_Publicacion] WHERE ID_Publicacion = @ID_Publicacion
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllRubroByPublicacionId]
	@ID_Publicacion int
AS
BEGIN
	SELECT * FROM [LA_BANDA_DEL_CHAVO].[TL_Rubro] R
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Rubro_Publicacion] RP
	ON R.ID_Rubro = RP.ID_Rubro
	WHERE RP.ID_Publicacion = @ID_Publicacion
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllPublicationByUserId]
	@ID_Usuario int
AS
BEGIN
	SELECT * FROM [LA_BANDA_DEL_CHAVO].[TL_Publicacion] P
	WHERE P.[ID_Usuario] = @ID_Usuario
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetPublicacionByVisibilityId]
	@ID_Visibilidad int
AS
BEGIN
	SELECT * FROM [LA_BANDA_DEL_CHAVO].[TL_Publicacion] P
	WHERE P.[ID_Visibilidad] = @ID_Visibilidad
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetComprasNotCalificadaByCliente]
	@idUsuario int,
	@Fecha_hoy datetime
AS
BEGIN
SELECT C.ID_Publicacion, P.Descripcion,  '$' + CAST(P.Precio AS varchar(10)) AS Precio
FROM LA_BANDA_DEL_CHAVO.TL_Publicacion P
INNER JOIN LA_BANDA_DEL_CHAVO.TL_Compra C ON C.ID_Publicacion  = P.ID_Publicacion
INNER JOIN LA_BANDA_DEL_CHAVO.TL_Usuario U ON C.ID_Usuario = U.ID_Usuario
WHERE U.ID_Usuario=@idUsuario
AND NOT EXISTS (SELECT * FROM LA_BANDA_DEL_CHAVO.TL_Calificacion CAL
				WHERE CAL.ID_Comprador=(SELECT U.ID_Usuario
	FROM [LA_BANDA_DEL_CHAVO].[TL_Usuario] AS U
	WHERE U.ID_Usuario = @idUsuario) AND CAL.ID_Publicacion = C.ID_Publicacion)
				
UNION

SELECT O.ID_Publicacion, P.Descripcion,  '$' + CAST(P.Precio AS varchar(10)) AS Precio
FROM LA_BANDA_DEL_CHAVO.TL_Publicacion P
INNER JOIN LA_BANDA_DEL_CHAVO.TL_Oferta O ON O.ID_Publicacion  = P.ID_Publicacion
INNER JOIN LA_BANDA_DEL_CHAVO.TL_Usuario U ON O.ID_Usuario = U.ID_Usuario
WHERE U.ID_Usuario=@idUsuario 
AND O.Monto = (	SELECT MAX(Monto)
							FROM LA_BANDA_DEL_CHAVO.TL_Oferta 
							WHERE ID_Publicacion=O.ID_Publicacion ) 
AND P.Fecha_Vencimiento < @Fecha_hoy
AND NOT EXISTS (SELECT * FROM LA_BANDA_DEL_CHAVO.TL_Calificacion CAL
				WHERE CAL.ID_Comprador=(SELECT U.ID_Usuario
	FROM [LA_BANDA_DEL_CHAVO].[TL_Usuario] AS U
	WHERE U.ID_Usuario = @idUsuario) AND CAL.ID_Publicacion = O.ID_Publicacion)
END

GO




CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertCalificacion]
	@ID_Publicacion int,
	@ID_Comprador int,
	@Cantidad_estrellas int,
	@Descripcion nvarchar(255)
AS
BEGIN
	DECLARE @T TABLE(Codigo_Calificacion int)

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Calificacion] (ID_Publicacion, ID_Comprador, Cantidad_Estrellas, Descripcion)
	OUTPUT inserted.Codigo_Calificacion
	INTO @T
	VALUES (@ID_Publicacion, @ID_Comprador, @Cantidad_Estrellas, @Descripcion)
	
	SELECT * FROM @T
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllPublicacionByParameters]
	@ID_Usuario int,
	@Descripcion nvarchar(255) = NULL,
	@Stock numeric(18,0) = NULL,
	@Precio numeric(18,2) = NULL,
	@ID_Estado_Publicacion int = NULL,
	@ID_Visibilidad int = NULL,
	@ID_Tipo_Publicacion int = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Publicacion] P
	WHERE P.[ID_Usuario] = @ID_Usuario
	AND ((LOWER(P.[Descripcion]) = LOWER(@Descripcion)) OR @Descripcion is NULL)
	AND ((P.[Stock] = @Stock) OR @Stock is NULL)
	AND ((P.[Precio] = @Precio) OR @Precio is NULL)
	AND ((P.[ID_Estado_Publicacion] = @ID_Estado_Publicacion) OR @ID_Estado_Publicacion is NULL)
	AND ((P.[ID_Visibilidad] = @ID_Visibilidad) OR @ID_Visibilidad is NULL)
	AND ((P.[ID_Tipo_Publicacion] = @ID_Tipo_Publicacion) OR @ID_Tipo_Publicacion is NULL)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllPublicacionByParametersLike]
	@ID_Usuario int,
	@Descripcion nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Publicacion] P
	WHERE P.[ID_Usuario] = @ID_Usuario
	AND ((LOWER(P.[Descripcion]) LIKE '%' + LOWER(@Descripcion) + '%'))
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetCalificacionByUserId]
	@ID_Usuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Reputacion
	FROM [LA_BANDA_DEL_CHAVO].[TL_Usuario] U
	WHERE U.[ID_Usuario] = @ID_Usuario
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllActiveAndFreeByUserId]
	@ID_Usuario int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT COUNT(*)
	FROM [LA_BANDA_DEL_CHAVO].[TL_Publicacion] P
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Visibilidad] V ON P.ID_Visibilidad = V.ID_Visibilidad
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Estado_Publicacion] E ON P.ID_Estado_Publicacion = E.ID_Estado_Publicacion
	WHERE P.ID_Usuario = @ID_Usuario
	AND V.Descripcion = 'Gratis'
	AND E.Descripcion = 'Publicada'
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertCreditCard]
	@Codigo_Seguridad numeric(3,0),
	@Dni_Titular numeric(18,0),
	@ID_Factura int,
	@Numero_Tarjeta numeric(16,0),
	@Tarjeta nvarchar(50),
	@Titular nvarchar(255),
	@Vencimiento numeric(4,0)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Tarjeta_Credito] (Tarjeta, Nro_Tarjeta, Vencimiento, Cod_Seguridad, Titular, Dni_Titular, ID_Factura)
	OUTPUT inserted.ID_Tarjeta_Credito
	VALUES (@Tarjeta, @Numero_Tarjeta, @Vencimiento, @Codigo_Seguridad, @Titular, @Dni_Titular, @ID_Factura)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetVisibilityPurchasesByUser]
	@ID_Usuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ID_Visibilidad, Cantidad_Compras FROM [LA_BANDA_DEL_CHAVO].[TL_Usuario_Visibilidad] UV
	WHERE UV.ID_Usuario = @ID_Usuario
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetVisibilityPurchasesByUserAndID]
	@ID_Usuario int,
	@ID_Visibilidad int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT * FROM [LA_BANDA_DEL_CHAVO].[TL_Usuario_Visibilidad] UV
	WHERE UV.ID_Usuario = @ID_Usuario AND UV.ID_Visibilidad = @ID_Visibilidad
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertVisibilityPurchases]
	@ID_Usuario int,
	@ID_Visibilidad int,
	@Cantidad_Compras int
AS
BEGIN
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Usuario_Visibilidad] (ID_Usuario, ID_Visibilidad, Cantidad_Compras)
	VALUES (@ID_Usuario, @ID_Visibilidad, @Cantidad_Compras)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdateVisibilityPurchases]
	@ID_Usuario int,
	@ID_Visibilidad int,
	@Cantidad_Compras int
AS
BEGIN
	UPDATE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Visibilidad] 
	SET Cantidad_Compras = @Cantidad_Compras
	WHERE ID_Usuario = @ID_Usuario 
	AND ID_Visibilidad = @ID_Visibilidad
END
GO

COMMIT
GO
CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertUser]
	@Username nvarchar(255),
	@Password nvarchar(64)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Usuario] (Username, Password)
	OUTPUT inserted.ID_Usuario
	VALUES (@Username, @Password)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllTipoDocumento]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Tipo_Documento]
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetClientByPhone]
	@Telefono varchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *, U.Habilitado
	FROM [LA_BANDA_DEL_CHAVO].[TL_Cliente] C
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Usuario U ON C.ID_Usuario=U.ID_Usuario
	WHERE [Telefono] = @Telefono
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetClientByDocument]
	@Tipo_documento int,
	@Nro_documento numeric(18,0)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *, U.Habilitado
	FROM [LA_BANDA_DEL_CHAVO].[TL_Cliente] C
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Usuario U ON C.ID_Usuario=U.ID_Usuario
	WHERE [ID_Tipo_Documento] = @Tipo_documento
	AND [Nro_Documento] = @Nro_documento
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertClient]
	@ID_Usuario int 
      ,@Nombre nvarchar(255)
      ,@Apellido nvarchar(255)
      ,@ID_Tipo_Documento int
      ,@Nro_Documento numeric(18,0)
      ,@Mail nvarchar(255)
      ,@Telefono nvarchar(255)
      ,@Direccion nvarchar(255)
      ,@Codigo_Postal nvarchar(255)
      ,@Fecha_nacimiento datetime
      ,@CUIL nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Cliente] ([ID_Usuario]
      ,[Nombre]
      ,[Apellido]
      ,[ID_Tipo_Documento]
      ,[Nro_Documento]
      ,[Mail]
      ,[Telefono]
      ,[Direccion]
      ,[Codigo_Postal]
      ,[Fecha_nacimiento]
      ,[CUIL])
	OUTPUT inserted.ID_Cliente
	VALUES (@ID_Usuario
      ,@Nombre
      ,@Apellido
      ,@ID_Tipo_Documento
      ,@Nro_Documento
      ,@Mail
      ,@Telefono
      ,@Direccion
      ,@Codigo_Postal
      ,@Fecha_nacimiento
      ,@CUIL)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllRolNotAdmin]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Rol]
	WHERE [Descripcion] <> 'Administrativo'
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetCompanyByBusinessName]
	@Razon_Social nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *, U.Habilitado
	FROM [LA_BANDA_DEL_CHAVO].[TL_Empresa] E
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Usuario U ON E.ID_Usuario=U.ID_Usuario
	WHERE [Razon_Social] = @Razon_Social
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetCompanyByCUIT]
	@CUIT nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *, U.Habilitado
	FROM [LA_BANDA_DEL_CHAVO].[TL_Empresa] E
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Usuario U ON E.ID_Usuario=U.ID_Usuario
	WHERE [CUIT] = @CUIT
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertCompany]
	@ID_Usuario int 
      ,@Razon_Social nvarchar(255)
      ,@Mail nvarchar(255)
      ,@Telefono nvarchar(255)
      ,@Direccion nvarchar(255)
      ,@Codigo_Postal nvarchar(255)
      ,@Ciudad nvarchar(255)
      ,@CUIT nvarchar(50)
      ,@Nombre_Contacto nvarchar(255)
      ,@Fecha_Creacion datetime
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Empresa] ([ID_Usuario]
      ,[Razon_Social]
      ,[Mail]
      ,[Telefono]
      ,[Direccion]
      ,[Codigo_Postal]
      ,[Ciudad]
      ,[CUIT]
      ,[Nombre_Contacto]
      ,[Fecha_Creacion])
	OUTPUT inserted.ID_Empresa
	VALUES (@ID_Usuario
      ,@Razon_Social
      ,@Mail
      ,@Telefono
      ,@Direccion
      ,@Codigo_Postal
      ,@Ciudad
      ,@CUIT
      ,@Nombre_Contacto
      ,@Fecha_Creacion)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllUsuario]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Usuario]
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllPublicationActive]
	@Fecha_hoy datetime
AS
BEGIN
	SELECT P.* FROM [LA_BANDA_DEL_CHAVO].[TL_Publicacion] P
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Estado_Publicacion EP ON P.ID_Estado_Publicacion=EP.ID_Estado_Publicacion
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Tipo_Publicacion TP ON P.ID_Tipo_Publicacion=TP.ID_Tipo_Publicacion
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Visibilidad V ON P.ID_Visibilidad = V.ID_Visibilidad
	WHERE EP.Descripcion='Publicada'
	AND P.Fecha_Vencimiento>@Fecha_hoy
	AND (TP.Descripcion = 'Subasta' OR P.Stock>0)
	ORDER BY V.Precio_Publicar DESC
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertQuestion]
	@ID_Publicacion int
	,@ID_Usuario int
    ,@Texto nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Pregunta] ([ID_Publicacion]
	  ,[ID_Usuario]
      ,[Texto])
	OUTPUT inserted.ID_Pregunta
	VALUES (@ID_Publicacion
	  ,@ID_Usuario
      ,@Texto)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetUnansweredQuestionsByUserId]
	@ID_Usuario int
AS
BEGIN
	SELECT P.ID_Publicacion, P.Descripcion, PREG.ID_Pregunta, PREG.Texto FROM LA_BANDA_DEL_CHAVO.TL_Pregunta PREG
	INNER JOIN	[LA_BANDA_DEL_CHAVO].[TL_Publicacion] P ON PREG.ID_Publicacion=P.ID_Publicacion
	WHERE P.ID_Usuario = @ID_Usuario
	AND NOT EXISTS (SELECT * FROM LA_BANDA_DEL_CHAVO.TL_Respuesta R WHERE R.ID_Pregunta=PREG.ID_Pregunta)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertAnswer]
	@ID_Pregunta int 
    ,@Texto nvarchar(255)
    ,@Fecha datetime
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Respuesta] ([ID_Pregunta]
      ,[Texto]
      ,[Fecha])
	OUTPUT inserted.ID_Respuesta
	VALUES (@ID_Pregunta
      ,@Texto
      ,@Fecha)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetQuestionsAndAnswersById]
	@ID_Publicacion int
AS
BEGIN
	SELECT PREG.ID_Pregunta, PREG.Texto AS TextoPregunta, R.ID_Respuesta, R.Texto AS TextoRespuesta
	FROM LA_BANDA_DEL_CHAVO.TL_Pregunta PREG
	INNER JOIN	[LA_BANDA_DEL_CHAVO].[TL_Respuesta] R ON PREG.ID_Pregunta=R.ID_Pregunta
	WHERE PREG.ID_Publicacion= @ID_Publicacion
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetClientByUserId]
	@ID_Usuario int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT C.*, U.Habilitado
	FROM [LA_BANDA_DEL_CHAVO].[TL_Cliente] C
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Usuario U ON C.ID_Usuario=U.ID_Usuario
	WHERE C.ID_Usuario = @ID_Usuario
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetCompanyByUserId]
	@ID_Usuario int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *, U.Habilitado
	FROM [LA_BANDA_DEL_CHAVO].[TL_Empresa] E
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Usuario U ON E.ID_Usuario=U.ID_Usuario
	WHERE E.ID_Usuario = @ID_Usuario
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetLastOfertaByPublication]
	@idPublicacion int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT TOP 1 *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Oferta]
	WHERE ID_Publicacion = @idPublicacion
	ORDER BY Monto DESC
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertOffer]
	@ID_Publicacion int 
	,@ID_Usuario int 
	,@Monto int
    ,@Fecha datetime
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Oferta] ([ID_Publicacion]
	  ,[ID_Usuario]
      ,[Monto]
      ,[Fecha])
	OUTPUT inserted.ID_Oferta
	VALUES (@ID_Publicacion
	  ,@ID_Usuario
      ,@Monto
      ,@Fecha)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertPurchase]
	@ID_Publicacion int 
	,@ID_Usuario int 
    ,@Compra_Fecha datetime
    ,@Compra_Cantidad int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Compra] ([ID_Publicacion]
	  ,[ID_Usuario]
      ,[Compra_Fecha]
      ,[Compra_Cantidad])
	OUTPUT inserted.ID_Compra
	VALUES (@ID_Publicacion
	  ,@ID_Usuario
      ,@Compra_Fecha
      ,@Compra_Cantidad)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertUserRole]
	@ID_Usuario int 
	,@ID_Rol int 
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Usuario_Rol] ([ID_Usuario]
      ,[ID_Rol])
	OUTPUT inserted.ID_Usuario_Rol
	VALUES (@ID_Usuario
	  ,@ID_Rol)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllPublicationActiveByParameters]
	@Fecha_hoy datetime
	,@Descripcion nvarchar(255) = NULL
AS
BEGIN
	SELECT P.* FROM [LA_BANDA_DEL_CHAVO].[TL_Publicacion] P
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Estado_Publicacion EP ON P.ID_Estado_Publicacion=EP.ID_Estado_Publicacion
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Tipo_Publicacion TP ON P.ID_Tipo_Publicacion=TP.ID_Tipo_Publicacion
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Visibilidad V ON P.ID_Visibilidad = V.ID_Visibilidad
	WHERE EP.Descripcion='Publicada'
	AND P.Fecha_Vencimiento>@Fecha_hoy
	AND (TP.Descripcion = 'Subasta' OR P.Stock>0)
	AND ((LOWER(P.[Descripcion]) = LOWER(@Descripcion)) OR @Descripcion is NULL)
	ORDER BY V.Precio_Publicar DESC
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllPublicationActiveByParametersLike]
	@Fecha_hoy datetime
	,@Descripcion nvarchar(255) = NULL
AS
BEGIN
	SELECT P.* FROM [LA_BANDA_DEL_CHAVO].[TL_Publicacion] P
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Estado_Publicacion EP ON P.ID_Estado_Publicacion=EP.ID_Estado_Publicacion
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Tipo_Publicacion TP ON P.ID_Tipo_Publicacion=TP.ID_Tipo_Publicacion
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Visibilidad V ON P.ID_Visibilidad = V.ID_Visibilidad
	WHERE EP.Descripcion='Publicada'
	AND P.Fecha_Vencimiento>@Fecha_hoy
	AND (TP.Descripcion = 'Subasta' OR P.Stock>0)
	AND ((LOWER(P.[Descripcion]) LIKE '%' + LOWER(@Descripcion) + '%'))
	ORDER BY V.Precio_Publicar DESC
END
GO


CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetSellersWithMoreProductsNotSold]
	@Fecha_Desde datetime
	,@Fecha_Hasta datetime
	,@Visibilidad int
AS
BEGIN
	SELECT TOP 5 (CASE WHEN  E.ID_Usuario IS NULL THEN C.Nombre+' '+C.Apellido ELSE E.Razon_Social END) AS Usuario, SUM(P.Stock) AS Valor 
	FROM LA_BANDA_DEL_CHAVO.TL_Usuario U
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Publicacion P ON P.ID_Usuario=U.ID_Usuario
	LEFT JOIN LA_BANDA_DEL_CHAVO.TL_Cliente C ON P.ID_Usuario=C.ID_Usuario
	LEFT JOIN LA_BANDA_DEL_CHAVO.TL_Empresa E ON P.ID_Usuario=E.ID_Usuario
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Tipo_Publicacion TP ON P.ID_Tipo_Publicacion = TP.ID_Tipo_Publicacion
	WHERE P.Fecha_Inicio BETWEEN @Fecha_Desde AND @Fecha_Hasta
	AND (@Visibilidad IS NULL OR P.ID_Visibilidad = @Visibilidad)
	AND ((TP.Descripcion = 'Compra Inmediata' AND P.ID_Publicacion NOT IN (SELECT C.ID_Publicacion FROM LA_BANDA_DEL_CHAVO.TL_Compra C))
	OR (TP.Descripcion = 'Subasta' AND P.ID_Publicacion NOT IN (SELECT O.ID_Publicacion FROM LA_BANDA_DEL_CHAVO.TL_Oferta O)))
	GROUP BY U.ID_Usuario, E.ID_Usuario, E.Razon_Social, C.Nombre, C.Apellido
	ORDER BY COUNT(P.ID_Publicacion) DESC
END
GO


CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetSellersWithMoreBilling]
	@Fecha_Desde datetime
	,@Fecha_Hasta datetime
AS
BEGIN
	SELECT TOP 5 (CASE WHEN  E.ID_Usuario IS NULL THEN C.Nombre+' '+C.Apellido ELSE E.Razon_Social END) AS Usuario, SUM(CO.Compra_Cantidad)*P.Precio AS Valor
	FROM LA_BANDA_DEL_CHAVO.TL_Usuario U
	LEFT JOIN LA_BANDA_DEL_CHAVO.TL_Cliente C ON U.ID_Usuario=C.ID_Usuario
	LEFT JOIN LA_BANDA_DEL_CHAVO.TL_Empresa E ON U.ID_Usuario=E.ID_Usuario
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Publicacion P ON U.ID_Usuario=P.ID_Usuario
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Compra CO ON CO.ID_Publicacion=P.ID_Publicacion
	WHERE CO.Compra_Fecha BETWEEN @Fecha_Desde AND @Fecha_Hasta
	GROUP BY U.ID_Usuario, E.ID_Usuario, E.Razon_Social, C.Nombre, C.Apellido, P.Precio
	ORDER BY SUM(CO.Compra_Cantidad)*P.Precio DESC
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetClientsWithMoreNotQualifiedPublications]
	@Fecha_Desde datetime
	,@Fecha_Hasta datetime
AS
BEGIN
	SELECT TOP 5 C.Nombre+' '+C.Apellido AS Usuario, COUNT(P.ID_Publicacion) AS Valor 
	FROM LA_BANDA_DEL_CHAVO.TL_Cliente C
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Publicacion P ON P.ID_Usuario=C.ID_Usuario
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Tipo_Publicacion TP ON P.ID_Tipo_Publicacion = TP.ID_Tipo_Publicacion
	WHERE P.Fecha_Inicio BETWEEN @Fecha_Desde AND @Fecha_Hasta
	AND P.ID_Publicacion NOT IN (SELECT CAL.ID_Publicacion FROM LA_BANDA_DEL_CHAVO.TL_Calificacion CAL WHERE CAL.ID_Comprador=C.ID_Usuario)
	GROUP BY C.Nombre, C.Apellido
	ORDER BY COUNT(P.ID_Publicacion) DESC
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetSellersWithBetterQualifications]
	@Fecha_Desde datetime
	,@Fecha_Hasta datetime
AS
BEGIN
	SELECT DISTINCT TOP 5 (CASE WHEN  E.ID_Usuario IS NULL THEN C.Nombre+' '+C.Apellido ELSE E.Razon_Social END) AS Usuario, AVG(CAL.Cantidad_Estrellas) AS Valor
	FROM LA_BANDA_DEL_CHAVO.TL_Usuario U
	LEFT JOIN LA_BANDA_DEL_CHAVO.TL_Cliente C ON U.ID_Usuario=C.ID_Usuario
	LEFT JOIN LA_BANDA_DEL_CHAVO.TL_Empresa E ON U.ID_Usuario=E.ID_Usuario
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Publicacion P ON U.ID_Usuario=P.ID_Usuario
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Calificacion CAL ON CAL.ID_Publicacion=P.ID_Publicacion
	WHERE P.Fecha_Inicio BETWEEN @Fecha_Desde AND @Fecha_Hasta
	GROUP BY U.ID_Usuario, E.ID_Usuario, E.Razon_Social, C.Nombre, C.Apellido, P.Precio
	ORDER BY AVG(CAL.Cantidad_Estrellas) DESC
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetFinishedAuctions]
	@Fecha_Hoy datetime
AS
BEGIN
	SELECT * FROM LA_BANDA_DEL_CHAVO.TL_Publicacion P
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Tipo_Publicacion TP ON P.ID_Tipo_Publicacion=TP.ID_Tipo_Publicacion 
	INNER JOIN LA_BANDA_DEL_CHAVO.TL_Estado_Publicacion EP ON P.ID_Estado_Publicacion=EP.ID_Estado_Publicacion
	WHERE TP.Descripcion = 'Subasta'
	AND P.Fecha_Vencimiento < @Fecha_Hoy
	AND EP.Descripcion = 'Publicada'
END
GO
USE [GD1C2014]
GO

/****** Object:  StoredProcedure [LA_BANDA_DEL_CHAVO].[GetComprasNotCalificadaByClienteByParametersLike]    Script Date: 06/08/2014 21:06:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetComprasNotCalificadaByClienteByParametersLike]
@idUsuario numeric(18,2) = NULL,
@Fecha_hoy datetime = NULL,
@CodigoPublicacion nvarchar(255) = NULL,
@Descripcion nvarchar(255) = NULL,
@Precio nvarchar(255) = NULL
AS
BEGIN

SELECT C.ID_Publicacion, P.Descripcion,  '$' + CAST(P.Precio AS varchar(10)) AS Precio
FROM LA_BANDA_DEL_CHAVO.TL_Publicacion P
INNER JOIN LA_BANDA_DEL_CHAVO.TL_Compra C ON C.ID_Publicacion  = P.ID_Publicacion
INNER JOIN LA_BANDA_DEL_CHAVO.TL_Usuario u ON C.ID_Usuario = U.ID_Usuario
WHERE U.ID_Usuario=@idUsuario
AND NOT EXISTS (SELECT * FROM LA_BANDA_DEL_CHAVO.TL_Calificacion CAL
				WHERE CAL.ID_Comprador = @idUsuario
				AND CAL.ID_Publicacion = C.ID_Publicacion)
	AND ((C.ID_Publicacion LIKE ('%' + @CodigoPublicacion + '%')) OR @CodigoPublicacion is NULL)
	AND ((LOWER(P.Descripcion) LIKE ('%' + @Descripcion + '%')) OR @Descripcion is NULL)
	AND ((P.Precio LIKE ('%' + @Precio + '%')) OR @Precio is NULL)
END

GO


CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetComprasNotCalificadaByClienteByParameters]
@idUsuario numeric(18,2) = NULL,
@Fecha_hoy datetime = NULL,
@CodigoPublicacion numeric(18,2) = NULL,
@Descripcion nvarchar(255) = NULL,
@Precio numeric(18,2) = NULL
AS
BEGIN
SELECT C.ID_Publicacion, P.Descripcion,  '$' + CAST(P.Precio AS varchar(10)) AS Precio
FROM LA_BANDA_DEL_CHAVO.TL_Publicacion P
INNER JOIN LA_BANDA_DEL_CHAVO.TL_Compra C ON C.ID_Publicacion  = P.ID_Publicacion
INNER JOIN LA_BANDA_DEL_CHAVO.TL_Usuario U ON C.ID_Usuario = U.ID_Usuario
WHERE U.ID_Usuario=@idUsuario
AND NOT EXISTS (SELECT * FROM LA_BANDA_DEL_CHAVO.TL_Calificacion CAL
				WHERE CAL.ID_Comprador = @idUsuario
				AND CAL.ID_Publicacion = C.ID_Publicacion)
	AND ((C.ID_Publicacion = @CodigoPublicacion) OR @CodigoPublicacion is NULL)
	AND ((LOWER(P.Descripcion) = LOWER(@Descripcion)) OR @Descripcion is NULL)
	AND ((P.Precio = @Precio) OR @Precio is NULL)
END

GO




CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryComprasByUsuario]
	@idUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.ID_Compra, P.Descripcion, C.Compra_Fecha, P.Precio, C.Compra_Cantidad
	FROM [LA_BANDA_DEL_CHAVO].[TL_Compra] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion] AS P ON P.ID_Publicacion = C.ID_Publicacion
	WHERE C.ID_Usuario = @idUsuario
	ORDER BY C.Compra_Fecha DESC
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryComprasByUsuarioByParameters]
	@idUsuario int = NULL,
	@ID_Compra int= NULL,
	@Descripcion varchar(255) = NULL,
	@Compra_Fecha varchar(255)= NULL,
	@Precio numeric (18,2) = NULL,
	@Compra_Cantidad int = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.ID_Compra, P.Descripcion, C.Compra_Fecha, P.Precio, C.Compra_Cantidad
	FROM [LA_BANDA_DEL_CHAVO].[TL_Compra] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion] AS P ON P.ID_Publicacion = C.ID_Publicacion
	WHERE C.ID_Usuario = @idUsuario
	AND ((C.ID_Compra = @ID_Compra) OR @ID_Compra is NULL)
	AND ((LOWER(P.Descripcion) = LOWER(@Descripcion)) OR @Descripcion is NULL)
	AND ((P.Precio  = @Precio) OR @Precio is NULL)
	AND ((C.Compra_Fecha = @Compra_Fecha) OR @Compra_Fecha is NULL)
	AND ((C.Compra_Cantidad = @Compra_Cantidad) OR @Compra_Cantidad is NULL)	
	ORDER BY C.Compra_Fecha DESC
END




GO




CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryComprasByUsuarioByParametersLike]
	@idUsuario int = NULL,
	@ID_Compra varchar(255) = NULL,
	@Descripcion varchar(255) = NULL,
	@Compra_Fecha varchar(255)= NULL,
	@Precio varchar (255) = NULL,
	@Compra_Cantidad varchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.ID_Compra, P.Descripcion, C.Compra_Fecha, P.Precio, C.Compra_Cantidad
	FROM [LA_BANDA_DEL_CHAVO].[TL_Compra] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion] AS P ON P.ID_Publicacion = C.ID_Publicacion
	WHERE C.ID_Usuario = @idUsuario
	AND ((C.ID_Compra LIKE ('%' + @ID_Compra + '%')) OR @ID_Compra is NULL)
	AND ((LOWER(P.Descripcion) LIKE ('%' + LOWER(@Descripcion) + '%')) OR @Descripcion is NULL)
	AND ((P.Precio  LIKE ('%' + @Precio + '%')) OR @Precio is NULL)
	AND ((C.Compra_Fecha  LIKE ('%' + @Compra_Fecha + '%') ) OR @Compra_Fecha is NULL)
	AND ((C.Compra_Cantidad LIKE ('%' + @Compra_Cantidad + '%')) OR @Compra_Cantidad is NULL)	
	ORDER BY C.Compra_Fecha DESC
END




GO



CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesRecibidas]
	@idUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.Codigo_Calificacion, P.Descripcion, C.Cantidad_Estrellas, CLI.Apellido + ', ' + CLI.Nombre AS Nombre
	FROM [LA_BANDA_DEL_CHAVO].[TL_Calificacion] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion]  AS P  ON C.ID_Publicacion = P.ID_Publicacion
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] AS CLI ON CLI.ID_Usuario = C.ID_Comprador
	WHERE P.ID_Usuario = @idUsuario
END




GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesRecibidasByParameters]
	@idUsuario int = NULL,
	@Codigo_Calificacion int= NULL,
	@Descripcion varchar(255) = NULL,
	@Cantidad_Estrellas int = NULL,
	@Nombre varchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.Codigo_Calificacion, P.Descripcion, C.Cantidad_Estrellas, CLI.Apellido + ', ' + CLI.Nombre AS Nombre
	FROM [LA_BANDA_DEL_CHAVO].[TL_Calificacion] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion]  AS P  ON C.ID_Publicacion = P.ID_Publicacion
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] AS CLI ON CLI.ID_Usuario = C.ID_Comprador
	WHERE P.ID_Usuario = @idUsuario
	AND ((C.Codigo_Calificacion = @Codigo_Calificacion) OR @Codigo_Calificacion is NULL)
	AND ((P.Descripcion = @Descripcion) OR @Descripcion is NULL)
	AND ((C.Cantidad_Estrellas = @Cantidad_Estrellas) OR @Cantidad_Estrellas is NULL)
	AND ((CLI.Apellido + ', ' + CLI.Nombre = @Nombre) OR @Nombre is NULL)
	
	
	
END




GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesRecibidasByParametersLike]
	@idUsuario int = NULL,
	@Codigo_Calificacion varchar(255) = NULL,
	@Descripcion varchar(255) = NULL,
	@Cantidad_Estrellas varchar(255) = NULL,
	@Nombre varchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.Codigo_Calificacion, P.Descripcion, C.Cantidad_Estrellas, CLI.Apellido + ', ' + CLI.Nombre AS Nombre
	FROM [LA_BANDA_DEL_CHAVO].[TL_Calificacion] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion]  AS P  ON C.ID_Publicacion = P.ID_Publicacion
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] AS CLI ON CLI.ID_Usuario = C.ID_Comprador
	WHERE P.ID_Usuario = @idUsuario
	AND ((C.Codigo_Calificacion LIKE ('%' + @Codigo_Calificacion + '%')) OR @Codigo_Calificacion is NULL)
	AND ((P.Descripcion LIKE ('%' + @Descripcion + '%')) OR @Descripcion is NULL)
	AND ((C.Cantidad_Estrellas LIKE ('%' + @Cantidad_Estrellas + '%')) OR @Cantidad_Estrellas is NULL)
	AND ((CLI.Apellido + ', ' + CLI.Nombre LIKE ('%' + @Nombre + '%')) OR @Nombre is NULL)
	
	
	
END





GO




CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesOtorgadas]
	@idUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.Codigo_Calificacion, P.Descripcion, C.Cantidad_Estrellas,  (case when CLI.ID_Usuario IS NULL then E.Razon_Social else CLI.Apellido + ', ' + CLI.Nombre end) AS Nombre
	FROM [LA_BANDA_DEL_CHAVO].[TL_Calificacion] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion]  AS P  ON C.ID_Publicacion = P.ID_Publicacion
	LEFT JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] AS CLI ON CLI.ID_Usuario = P.ID_Usuario
	LEFT JOIN [LA_BANDA_DEL_CHAVO].[TL_Empresa] AS E ON E.ID_Empresa = P.ID_Usuario
	WHERE C.ID_Comprador = @idUsuario
END






GO



CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesOtorgadasByParameters]
	@idUsuario int = NULL,
	@Codigo_Calificacion int= NULL,
	@Descripcion varchar(255) = NULL,
	@Cantidad_Estrellas int = NULL,
	@Nombre varchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.Codigo_Calificacion, P.Descripcion, C.Cantidad_Estrellas,  (case when CLI.ID_Usuario IS NULL then E.Razon_Social else CLI.Apellido + ', ' + CLI.Nombre end) AS Nombre
	FROM [LA_BANDA_DEL_CHAVO].[TL_Calificacion] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion]  AS P  ON C.ID_Publicacion = P.ID_Publicacion
	LEFT JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] AS CLI ON CLI.ID_Usuario = P.ID_Usuario
	LEFT JOIN [LA_BANDA_DEL_CHAVO].[TL_Empresa] AS E ON E.ID_Empresa = P.ID_Usuario
	WHERE C.ID_Comprador = @idUsuario
	AND ((C.Codigo_Calificacion = @Codigo_Calificacion) OR @Codigo_Calificacion is NULL)
	AND ((P.Descripcion = @Descripcion) OR @Descripcion is NULL)
	AND ((C.Cantidad_Estrellas = @Cantidad_Estrellas) OR @Cantidad_Estrellas is NULL)
	AND (((case when CLI.ID_Usuario IS NULL then E.Razon_Social else CLI.Apellido + ', ' + CLI.Nombre end) = @Nombre) OR @Nombre is NULL)
	
END






GO





CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesOtorgadasByParametersLike]
	@idUsuario int = NULL,
	@Codigo_Calificacion varchar(255)= NULL,
	@Descripcion varchar(255) = NULL,
	@Cantidad_Estrellas varchar(255) = NULL,
	@Nombre varchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.Codigo_Calificacion, P.Descripcion, C.Cantidad_Estrellas,  (case when CLI.ID_Usuario IS NULL then E.Razon_Social else CLI.Apellido + ', ' + CLI.Nombre end) AS Nombre
	FROM [LA_BANDA_DEL_CHAVO].[TL_Calificacion] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion]  AS P  ON C.ID_Publicacion = P.ID_Publicacion
	LEFT JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] AS CLI ON CLI.ID_Usuario = P.ID_Usuario
	LEFT JOIN [LA_BANDA_DEL_CHAVO].[TL_Empresa] AS E ON E.ID_Empresa = P.ID_Usuario
	WHERE C.ID_Comprador = @idUsuario
	AND ((C.Codigo_Calificacion LIKE ('%' + @Codigo_Calificacion  + '%')) OR @Codigo_Calificacion is NULL)
	AND ((P.Descripcion LIKE ('%' + @Descripcion  + '%')) OR @Descripcion is NULL)
	AND ((C.Cantidad_Estrellas LIKE ('%' + @Cantidad_Estrellas  + '%')) OR @Cantidad_Estrellas is NULL)
	AND (((case when CLI.ID_Usuario IS NULL then E.Razon_Social else CLI.Apellido + ', ' + CLI.Nombre end) LIKE ('%' + @Nombre  + '%')) OR @Nombre is NULL)
	
END







GO


CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryOfertasByUsuario]
	@idUsuario int,
	@Fecha_hoy datetime
AS
BEGIN
SELECT O.ID_Oferta, O.Monto, O.Fecha, P.Descripcion, (CASE WHEN O.Monto = (SELECT MAX(Monto)
FROM LA_BANDA_DEL_CHAVO.TL_Oferta 
WHERE ID_Publicacion=O.ID_Publicacion ) AND P.Fecha_Vencimiento < @Fecha_hoy THEN 'Si' ELSE 'No' END) AS Ganada
FROM [LA_BANDA_DEL_CHAVO].[TL_Oferta] AS O
INNER JOIN [LA_BANDA_DEL_CHAVO].TL_Publicacion AS P ON O.ID_Publicacion = P.ID_Publicacion 
WHERE O.ID_Usuario = @idUsuario

END




GO





CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryOfertasByUsuarioByParameters]
	@idUsuario int = NULL,
	@Fecha_hoy datetime = NULL,
	@ID_Oferta int = NULL,
	@Monto numeric (18, 2) = NULL,
	@Fecha varchar(255) = NULL,
	@Descripcion varchar(255) = NULL,
	@Ganada varchar(255) = NULL
AS
BEGIN
SELECT O.ID_Oferta, O.Monto, O.Fecha, P.Descripcion, (CASE WHEN O.Monto = (SELECT MAX(Monto)
FROM LA_BANDA_DEL_CHAVO.TL_Oferta 
WHERE ID_Publicacion=O.ID_Publicacion ) AND P.Fecha_Vencimiento < @Fecha_hoy THEN 'Si' ELSE 'No' END) AS Ganada
FROM [LA_BANDA_DEL_CHAVO].[TL_Oferta] AS O
INNER JOIN [LA_BANDA_DEL_CHAVO].TL_Publicacion AS P ON O.ID_Publicacion = P.ID_Publicacion 
WHERE O.ID_Usuario = @idUsuario
	AND ((O.ID_Oferta  = @ID_Oferta) OR @ID_Oferta is NULL)
	AND ((O.Monto = @Monto) OR @Monto is NULL)
	AND ((O.Fecha = @Fecha) OR @Fecha is NULL)
	AND ((P.Descripcion = @Descripcion) OR @Descripcion is NULL)
	AND (((CASE WHEN O.Monto = (SELECT MAX(Monto)
FROM LA_BANDA_DEL_CHAVO.TL_Oferta 
WHERE ID_Publicacion=O.ID_Publicacion ) AND P.Fecha_Vencimiento < @Fecha_hoy THEN 'Si' ELSE 'No' END) = @Ganada) OR @Ganada is NULL)
	
END





GO





CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryOfertasByUsuarioByParametersLike]
	@idUsuario int = NULL,
	@Fecha_hoy datetime = NULL,
	@ID_Oferta varchar(255) = NULL,
	@Monto varchar(255) = NULL,
	@Fecha varchar(255) = NULL,
	@Descripcion varchar(255) = NULL,
	@Ganada varchar(255) = NULL
AS
BEGIN
SELECT O.ID_Oferta, O.Monto, O.Fecha, P.Descripcion, (CASE WHEN O.Monto = (SELECT MAX(Monto)
FROM LA_BANDA_DEL_CHAVO.TL_Oferta 
WHERE ID_Publicacion=O.ID_Publicacion ) AND P.Fecha_Vencimiento < @Fecha_hoy THEN 'Si' ELSE 'No' END) AS Ganada
FROM [LA_BANDA_DEL_CHAVO].[TL_Oferta] AS O
INNER JOIN [LA_BANDA_DEL_CHAVO].TL_Publicacion AS P ON O.ID_Publicacion = P.ID_Publicacion 
WHERE O.ID_Usuario = @idUsuario
	AND ((O.ID_Oferta  LIKE ('%'+ @ID_Oferta + '%') ) OR @ID_Oferta is NULL)
	AND ((O.Monto LIKE ('%'+ @Monto + '%')  ) OR @Monto is NULL)
	AND ((O.Fecha LIKE ('%'+ @Fecha + '%')) OR @Fecha is NULL)
	AND ((P.Descripcion LIKE ('%'+ @Descripcion + '%') ) OR @Descripcion is NULL)
	AND (((CASE WHEN O.Monto = (SELECT MAX(Monto)
FROM LA_BANDA_DEL_CHAVO.TL_Oferta 
WHERE ID_Publicacion=O.ID_Publicacion ) AND P.Fecha_Vencimiento < @Fecha_hoy THEN 'Si' ELSE 'No' END) LIKE ('%'+ @Ganada + '%')) OR @Ganada is NULL)
	
END






GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertUserTemporal]
	@Username nvarchar(255),
	@Password nvarchar(64)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Usuario] (Username, Password, Pass_Temporal)
	OUTPUT inserted.ID_Usuario
	VALUES (@Username, @Password, 1)
END


GO


CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllBusinessByParameters]
	@Razon_Social nvarchar(255) = NULL,
	@Cuit nvarchar(255) = NULL,
	@Email nvarchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;

SELECT E.*, U.Habilitado
	FROM [LA_BANDA_DEL_CHAVO].TL_Empresa AS E
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Usuario] AS U ON E.ID_Usuario = U.ID_Usuario

	WHERE 
	((LOWER(E.Razon_Social) = LOWER(@Razon_Social)) OR @Razon_Social is NULL)
	AND ((LOWER(E.CUIT) = LOWER(@Cuit)) OR @Cuit is NULL)
	AND ((LOWER(E.Mail) = LOWER(@Email)) OR @Email is NULL)
	
END




GO


CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllBusiness]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT E.*, U.Habilitado
	FROM [LA_BANDA_DEL_CHAVO].TL_Empresa AS E
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Usuario] AS U ON E.ID_Usuario = U.ID_Usuario
END


GO




CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllBusinessByParametersLike]
	@Razon_Social nvarchar(255) = NULL,
	@Cuit nvarchar(255) = NULL,
	@Email nvarchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT E.*, U.Habilitado
	FROM [LA_BANDA_DEL_CHAVO].TL_Empresa AS E
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Usuario] AS U ON E.ID_Usuario = U.ID_Usuario
WHERE 
	((LOWER(E.Razon_Social) LIKE  ('%' + LOWER(@Razon_Social) + '%')) OR @Razon_Social is NULL)
	AND ((LOWER(E.CUIT) LIKE  ('%' + LOWER(@Cuit) + '%')) OR @Cuit is NULL)
	AND ((LOWER(E.Mail)LIKE  ('%' + LOWER(@Email) + '%')) OR @Email is NULL)
	
END



GO





CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdateUserToDisabledById]
	@ID_User int
AS
BEGIN
	UPDATE [LA_BANDA_DEL_CHAVO].[TL_Usuario]
	SET Habilitado = 0
	WHERE ID_Usuario = @ID_User
END


GO


CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdateUserToActivateById]
	@ID_User int
AS
BEGIN
	UPDATE [LA_BANDA_DEL_CHAVO].[TL_Usuario]
	SET Habilitado = 1
	WHERE ID_Usuario = @ID_User
END



GO





CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdateBusiness]
	@ID_User int,
	@Razon_Social varchar(255),
	@Mail varchar(255),
	@Telefono varchar(255),
	@Direccion varchar(255),
	@Codigo_Postal varchar(255),
	@Ciuidad varchar(255),
	@CUIT varchar(255),
	@Nombre_Contacto varchar(255),
	@Fecha_Creacion datetime
AS
BEGIN
	UPDATE [LA_BANDA_DEL_CHAVO].[TL_Empresa] 
	SET Razon_Social = @Razon_Social, Mail = @Mail, Telefono = @Telefono,
	Direccion = @Direccion, Codigo_Postal = @Codigo_Postal, Ciudad = @Ciuidad,
	CUIT = @CUIT, Nombre_Contacto = @Nombre_Contacto, Fecha_Creacion = @Fecha_Creacion
	WHERE ID_Usuario = @ID_User
END


GO

USE [GD1C2014]
GO

/****** Object:  StoredProcedure [LA_BANDA_DEL_CHAVO].[[GetAllFormaPago]]    Script Date: 06/09/2014 02:43:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllFormaPago]
AS
BEGIN
	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Forma_Pago]
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetPublicacionesARendirByUser]
	@Fecha_Actual DateTime,
	@Id_User int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT P.* 
	FROM [LA_BANDA_DEL_CHAVO].TL_Publicacion P
		LEFT JOIN [LA_BANDA_DEL_CHAVO].TL_Usuario U ON U.ID_Usuario = P.ID_Usuario
	WHERE (P.Fecha_Vencimiento <= @Fecha_Actual OR P.Stock = 0)
		   AND P.ID_Publicacion NOT IN (SELECT ITF.ID_Publicacion FROM [LA_BANDA_DEL_CHAVO].TL_Item_Factura ITF)
		   AND P.ID_Usuario = @Id_User
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetPublicacionesMasAntiguasARendirByUser]
	@Fecha_Actual DateTime,
	@Id_User int,
	@Cantidad int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT TOP (@Cantidad) P.*
	FROM [LA_BANDA_DEL_CHAVO].TL_Publicacion P
		LEFT JOIN [LA_BANDA_DEL_CHAVO].TL_Usuario U ON U.ID_Usuario = P.ID_Usuario
		INNER JOIN [LA_BANDA_DEL_CHAVO].TL_Compra C ON C.ID_Publicacion = P.ID_Publicacion
	WHERE (P.Fecha_Vencimiento <= @Fecha_Actual OR P.Stock = 0)
		   AND P.ID_Publicacion NOT IN (SELECT ITF.ID_Publicacion FROM [LA_BANDA_DEL_CHAVO].TL_Item_Factura ITF)
		   AND P.ID_Usuario = @Id_User
	ORDER BY C.Compra_Fecha ASC
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllFormaPagoById]
	@Id_Forma_Pago int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Forma_Pago]
	WHERE ID_Forma_Pago = @Id_Forma_Pago
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetUltimoNumeroFactura]
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT MAX(F.Numero) 
	FROM [LA_BANDA_DEL_CHAVO].TL_Factura F
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllCompraByPublicacionId]
	@ID_Publicacion int
AS
BEGIN
	SELECT * FROM [LA_BANDA_DEL_CHAVO].[TL_Compra] C
	WHERE C.ID_Publicacion = @ID_Publicacion
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllItemFacturaByFacturaId]
	@ID_Factura int
AS
BEGIN
	SELECT * FROM [LA_BANDA_DEL_CHAVO].[TL_Item_Factura] ITF
	WHERE ITF.ID_Factura = @ID_Factura
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetCantidadComprasByPublicationIdGroupByClient]
	@ID_Publicacion int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT COUNT(C.Compra_Cantidad) AS Cantidad 
	FROM [LA_BANDA_DEL_CHAVO].TL_Compra C
	WHERE C.ID_Publicacion = @ID_Publicacion
	GROUP BY C.ID_Usuario
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetFacturaByNumero]
	@Numero numeric(18, 0)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT F.* FROM [LA_BANDA_DEL_CHAVO].TL_Factura F 
	WHERE F.Numero = @Numero
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertItemFactura]
	@ID_Factura int 
      ,@ID_Publicacion numeric(18,0)
      ,@Monto numeric(18,2)
      ,@Cantidad numeric(18,0)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Item_Factura] 
	([ID_Factura]
      ,[ID_Publicacion]
      ,[Monto]
      ,[Cantidad])
	OUTPUT inserted.ID_Item_Factura
	VALUES (@ID_Factura
      ,@ID_Publicacion
      ,@Monto
      ,@Cantidad)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertFactura]
	@Numero numeric(18,0) 
      ,@Fecha datetime
      ,@Total numeric(18,2)
      ,@ID_Forma_Pago int
      ,@ID_Usuario int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Factura] 
	([Numero]
      ,[Fecha]
      ,[Total]
      ,[ID_Forma_Pago]
      ,[ID_Usuario])
	OUTPUT inserted.ID_Factura
	VALUES (@Numero
      ,@Fecha
      ,@Total
      ,@ID_Forma_Pago
      ,@ID_Usuario)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetClientById]
	@ID_Cliente numeric(18,0)
AS
BEGIN
	SELECT * FROM [LA_BANDA_DEL_CHAVO].[TL_Cliente] 
	WHERE ID_Cliente = @ID_Cliente
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetFacturaById]
	@ID_Factura numeric(18,0)
AS
BEGIN
	SELECT * FROM [LA_BANDA_DEL_CHAVO].[TL_Factura] 
	WHERE ID_Factura = @ID_Factura
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InhabilitarUser]
	@ID_User int
AS
BEGIN
	UPDATE [LA_BANDA_DEL_CHAVO].[TL_Usuario]
	SET Habilitado = 0
	WHERE ID_Usuario = @ID_User
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetTipoDocumentoById]
	@ID_Tipo_Documento numeric(18,0)
AS
BEGIN
	SELECT * FROM [LA_BANDA_DEL_CHAVO].[TL_Tipo_Documento] 
	WHERE ID_Tipo_Documento = @ID_Tipo_Documento
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdateClient]
	@ID_Usuario int,
	@Nombre varchar(255),
	@Apellido varchar(255),
	@ID_Tipo_Documento int,
	@Nro_Documento numeric(18, 0),
	@Mail varchar(255),
	@Telefono varchar(255),
	@Direccion varchar(255),
	@Codigo_Postal varchar(255),
	@CUIL varchar(255),
	@Fecha_Nacimiento datetime
AS
BEGIN
	UPDATE [LA_BANDA_DEL_CHAVO].[TL_Cliente] 
	SET Nombre = @Nombre, Apellido = @Apellido, ID_Tipo_Documento = @ID_Tipo_Documento,
    Nro_Documento = @Nro_Documento, Mail = @Mail, Telefono = @Telefono,
	Direccion = @Direccion, Codigo_Postal = @Codigo_Postal, CUIL = @CUIL, 
	Fecha_nacimiento = @Fecha_Nacimiento
	WHERE ID_Usuario = @ID_Usuario
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllClients]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.*, U.Habilitado
	FROM [LA_BANDA_DEL_CHAVO].TL_Cliente AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Usuario] AS U ON C.ID_Usuario = U.ID_Usuario
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllClientsByParameters]
	@Nombre nvarchar(255) = NULL,
	@Apellido nvarchar(255) = NULL,
	@Tipo_Documento int = NULL,
	@Nro_Documento numeric(18,0) = NULL,
	@Email nvarchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.*, U.Habilitado
	FROM [LA_BANDA_DEL_CHAVO].TL_Cliente AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Usuario] AS U ON C.ID_Usuario = U.ID_Usuario

	WHERE 
	((LOWER(C.Nombre) = LOWER(@Nombre)) OR @Nombre is NULL)
	AND ((LOWER(C.Apellido) = LOWER(@Apellido)) OR @Apellido is NULL)
	AND ((C.ID_Tipo_Documento = @Tipo_Documento) OR @Tipo_Documento is NULL)
	AND ((C.Nro_Documento = @Nro_Documento) OR @Nro_Documento is NULL)
	AND ((LOWER(C.Mail) = LOWER(@Email)) OR @Email is NULL)	
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllClientsByParametersLike]
	@Nombre nvarchar(255) = NULL,
	@Apellido nvarchar(255) = NULL,
	@Tipo_Documento int = NULL,
	@Nro_Documento numeric(18,0) = NULL,
	@Email nvarchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.*, U.Habilitado
	FROM [LA_BANDA_DEL_CHAVO].TL_Cliente AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Usuario] AS U ON C.ID_Usuario = U.ID_Usuario
	
	WHERE 
	((LOWER(C.Nombre) LIKE  ('%' + LOWER(@Nombre) + '%')) OR @Nombre is NULL)
	AND ((LOWER(C.Apellido) LIKE  ('%' + LOWER(@Apellido) + '%')) OR @Apellido is NULL)
	AND ((C.ID_Tipo_Documento = @Tipo_Documento) OR @Tipo_Documento is NULL)
	AND ((C.Nro_Documento LIKE  ('%' + CAST(@Nro_Documento AS nvarchar(255)) + '%')) OR @Nro_Documento is NULL)
	AND ((LOWER(C.Mail)LIKE  ('%' + LOWER(@Email) + '%')) OR @Email is NULL)
END
GO
USE [GD1C2014]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER TL_Rol_After_Update ON [LA_BANDA_DEL_CHAVO].[TL_Rol]
FOR UPDATE
AS
	DECLARE @Activo int;
	DECLARE @ID_Rol int;
	SET @Activo = (SELECT DISTINCT Activo FROM INSERTED);
	SET @ID_Rol = (SELECT DISTINCT ID_Rol FROM INSERTED);
	
	IF (@Activo = 0)
	BEGIN
		DELETE FROM [LA_BANDA_DEL_CHAVO].[TL_Usuario_Rol]
		WHERE ([ID_Rol] = @ID_Rol)
	END
GO

CREATE TRIGGER TL_Calificacion_After_Insert ON [LA_BANDA_DEL_CHAVO].[TL_Calificacion]
FOR INSERT
AS
	DECLARE @ID_Usuario int;
	DECLARE @Promedio numeric(18,2);
	
	SET @ID_Usuario = (
						SELECT TOP 1 P.ID_Usuario 
						FROM INSERTED INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion] P ON INSERTED.ID_Publicacion = P.ID_Publicacion
					  );
					  
	SET @Promedio = (
						SELECT AVG([Cantidad_Estrellas]) 
						FROM TL_Calificacion C INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion] P ON C.ID_Publicacion = P.ID_Publicacion
						WHERE P.[ID_Usuario] = @ID_Usuario
					);
	
	UPDATE [LA_BANDA_DEL_CHAVO].[TL_Usuario]
	SET [Reputacion] = @Promedio
	WHERE ([LA_BANDA_DEL_CHAVO].[TL_Usuario].[ID_Usuario] = @ID_Usuario)
GO
USE [GD1C2014]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

BEGIN TRANSACTION
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Rol] ([Descripcion]) VALUES ('Administrador General');
	
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Usuario] ([Username], [Password])
	VALUES ('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7');
	
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Usuario_Rol]([ID_Rol], [ID_Usuario])
	VALUES (
			(SELECT Id_Rol FROM [LA_BANDA_DEL_CHAVO].[TL_Rol] WHERE [Descripcion] = 'Administrador General'),
			(SELECT Id_Usuario FROM [LA_BANDA_DEL_CHAVO].[TL_Usuario] WHERE [Username] = 'admin')
		   );
	
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad_Rol] ([ID_Rol], [ID_Funcionalidad])
	(
		SELECT [ID_Rol], [ID_Funcionalidad]
		FROM [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad], [LA_BANDA_DEL_CHAVO].[TL_Rol] R
		WHERE (R.[Descripcion] = 'Administrador General')
	);
COMMIT