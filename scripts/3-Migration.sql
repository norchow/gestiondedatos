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
