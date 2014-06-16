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
	
	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Cliente]
	WHERE [Telefono] = @Telefono
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetClientByDocument]
	@Tipo_documento int,
	@Nro_documento numeric(18,0)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Cliente]
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
	
	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Empresa]
	WHERE [Razon_Social] = @Razon_Social
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetCompanyByCUIT]
	@CUIT nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Empresa]
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
    ,@Texto nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Pregunta] ([ID_Publicacion]
      ,[Texto])
	OUTPUT inserted.ID_Pregunta
	VALUES (@ID_Publicacion
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
	
	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Cliente]
	WHERE ID_Usuario = @ID_Usuario
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetCompanyByUserId]
	@ID_Usuario int
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Empresa]
	WHERE ID_Usuario = @ID_Usuario
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
	,@ID_Cliente int 
	,@Monto int
    ,@Fecha datetime
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Oferta] ([ID_Publicacion]
	  ,[ID_Cliente]
      ,[Monto]
      ,[Fecha])
	OUTPUT inserted.ID_Oferta
	VALUES (@ID_Publicacion
	  ,@ID_Cliente
      ,@Monto
      ,@Fecha)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertPurchase]
	@ID_Publicacion int 
	,@ID_Cliente int 
    ,@Compra_Fecha datetime
    ,@Compra_Cantidad int
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Compra] ([ID_Publicacion]
	  ,[ID_Cliente]
      ,[Compra_Fecha]
      ,[Compra_Cantidad])
	OUTPUT inserted.ID_Compra
	VALUES (@ID_Publicacion
	  ,@ID_Cliente
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