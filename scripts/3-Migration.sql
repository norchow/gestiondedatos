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
 
--BEGIN TRANSACTION
--INSERT INTO LA_BANDA_DEL_CHAVO.TL_Publicacion (Codigo_Publicacion,ID_Tipo_Publicacion,Descripcion,ID_Usuario,Nro_Documento,Mail,Telefono,Direccion,Codigo_Postal,Fecha_nacimiento)(
--  SELECT DISTINCT 0
--	  ,LEFT([Publ_Cli_Nombre],1)+LOWER(SUBSTRING([Publ_Cli_Nombre],2,LEN([Publ_Cli_Nombre])))
--	  ,[Publ_Cli_Apeliido]
--	  ,1
--	  ,[Publ_Cli_Dni]
--	  ,[Publ_Cli_Mail]
--	  ,NULL
--	  ,[Publ_Cli_Dom_Calle]+' '+CAST([Publ_Cli_Nro_Calle] AS VARCHAR)+' '+CAST([Publ_Cli_Piso] AS VARCHAR)+' '+[Publ_Cli_Depto] AS Direccion
--      ,[Publ_Cli_Cod_Postal]
--      ,[Publ_Cli_Fecha_Nac]
-- FROM gd_esquema.Maestra
--COMMIT
-- WHERE [Publ_Cli_Dni] IS NOT NULL); 