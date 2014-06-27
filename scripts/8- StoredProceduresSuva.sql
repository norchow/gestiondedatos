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