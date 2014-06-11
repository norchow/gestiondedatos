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
	WHERE EP.Descripcion='Publicada'
	AND P.Fecha_Vencimiento>@Fecha_hoy
	AND (TP.Descripcion = 'Subasta' OR P.Stock>0)
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertQuestion]
	@ID_Publicacion int 
    ,@Texto text
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