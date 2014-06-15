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
	
	SELECT * 
	FROM [LA_BANDA_DEL_CHAVO].TL_Publicacion P
		LEFT JOIN [LA_BANDA_DEL_CHAVO].TL_Usuario U ON U.ID_Usuario = P.ID_Usuario
	WHERE (P.Fecha_Vencimiento <= @Fecha_Actual 
		   OR P.Stock <= (SELECT SUM(C.Compra_Cantidad) FROM [LA_BANDA_DEL_CHAVO].TL_Compra C
					      WHERE C.ID_Publicacion = P.ID_Publicacion
					      GROUP BY C.ID_Publicacion))
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
	
	SELECT TOP (@Cantidad) *
	FROM [LA_BANDA_DEL_CHAVO].TL_Publicacion P
		LEFT JOIN [LA_BANDA_DEL_CHAVO].TL_Usuario U ON U.ID_Usuario = P.ID_Usuario
		INNER JOIN [LA_BANDA_DEL_CHAVO].TL_Compra C ON C.ID_Publicacion = P.ID_Publicacion
	WHERE (P.Fecha_Vencimiento <= @Fecha_Actual 
		   OR P.Stock <= (SELECT SUM(C.Compra_Cantidad) FROM [LA_BANDA_DEL_CHAVO].TL_Compra C
					      WHERE C.ID_Publicacion = P.ID_Publicacion
					      GROUP BY C.ID_Publicacion))
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
	GROUP BY C.ID_Cliente
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetFacturaByPublicacionId]
	@ID_Publicacion int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT * FROM [LA_BANDA_DEL_CHAVO].TL_Factura F 
	INNER JOIN [LA_BANDA_DEL_CHAVO].TL_Item_Factura ITF ON ITF.ID_Factura = F.ID_Factura
	WHERE ITF.ID_Publicacion = @ID_Publicacion
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