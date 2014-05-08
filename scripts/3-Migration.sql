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
INSERT INTO LA_BANDA_DEL_CHAVO.TL_Cliente (ID_Usuario,Nombre,Apellido,Tipo_Documento,Nro_Documento,Mail,Telefono,Direccion,Codigo_Postal,Fecha_nacimiento)(
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
	 INSERT INTO LA_BANDA_DEL_CHAVO.TL_Estado_Publicacion (Descripcion)(
	 SELECT DISTINCT Publicacion_Estado FROM gd_esquema.Maestra);
 COMMIT
 
 BEGIN TRANSACTION
	 INSERT INTO LA_BANDA_DEL_CHAVO.TL_Visibilidad(ID_Visibilidad, Descripcion, Precio_Publicar,Porcentaje_Venta)(
	 SELECT DISTINCT [Publicacion_Visibilidad_Cod]
      ,[Publicacion_Visibilidad_Desc]
      ,[Publicacion_Visibilidad_Precio]
      ,[Publicacion_Visibilidad_Porcentaje] FROM gd_esquema.Maestra);
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
      ,(SELECT EP.ID_Estado_Publicacion FROM LA_BANDA_DEL_CHAVO.TL_Estado_Publicacion EP WHERE EP.Descripcion=[Publicacion_Estado])
 FROM gd_esquema.Maestra
 WHERE [Publicacion_Cod] IS NOT NULL); 
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
		SELECT ID_Usuario, ID_Visibilidad, COUNT(*)
		FROM LA_BANDA_DEL_CHAVO.TL_Publicacion
		GROUP BY ID_Usuario, ID_Visibilidad
		)ORDER BY 1
COMMIT

BEGIN TRANSACTION
	INSERT INTO LA_BANDA_DEL_CHAVO.TL_Calificacion (Codigo_Calificacion, ID_Publicacion, ID_Comprador, Cantidad_Estrellas, Descripcion) (
		SELECT [Calificacion_Codigo],
			   [Publicacion_Cod],
			   (SELECT ID_Usuario FROM LA_BANDA_DEL_CHAVO.TL_Usuario U WHERE CONVERT(nvarchar(255), Cli_Dni) = U.Username),
		       [Calificacion_Cant_Estrellas],
		       [Calificacion_Descripcion]
		FROM gd_esquema.Maestra
		WHERE [Calificacion_Codigo] IS NOT NULL)
COMMIT

BEGIN TRANSACTION 
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Oferta] (ID_Cliente, ID_Publicacion, Monto, Fecha) (
		SELECT 
			(SELECT ID_Cliente FROM LA_BANDA_DEL_CHAVO.TL_Cliente C WHERE Cli_Dni = C.Nro_Documento),
			[Publicacion_Cod],
			[Oferta_Monto],
			[Oferta_Fecha]
		FROM gd_esquema.Maestra
		WHERE [Publicacion_Tipo] = 'Subasta'
		AND [Oferta_Monto] IS NOT NULL)
COMMIT

BEGIN TRANSACTION 
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Compra] (ID_Publicacion, ID_Cliente, Compra_Fecha, Compra_Cantidad) (
		SELECT 
			[Publicacion_Cod],
			(SELECT ID_Cliente FROM LA_BANDA_DEL_CHAVO.TL_Cliente C WHERE Cli_Dni = C.Nro_Documento),
			[Compra_Fecha],
			[Compra_Cantidad]
		FROM gd_esquema.Maestra
		WHERE [Publicacion_Tipo] = 'Compra Inmediata'
		AND [Compra_Cantidad] IS NOT NULL)
COMMIT

BEGIN TRANSACTION 
INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Factura] (Numero, Fecha, Descripcion_Forma_Pago, Total) (
	SELECT DISTINCT [Factura_Nro], [Factura_Fecha], [Forma_Pago_Desc], [Factura_Total]
	FROM [gd_esquema].[Maestra]
	WHERE [Factura_Fecha] IS NOT NULL)
COMMIT