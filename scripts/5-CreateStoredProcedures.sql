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

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllVisibilitidadByParameters]
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

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllVisibilitidadByParametersLike]
	@Descripcion nvarchar(255) = NULL,
	@Precio_Publicar numeric(18,2) = NULL,
	@Porcentaje_Venta numeric(18,2) = NULL,
	@Duracion numeric(18,0) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Visibilidad] v
	WHERE ((LOWER(v.[Descripcion]) LIKE '%' + LOWER(@Descripcion) + '%') OR @Descripcion is NULL)
	AND (CAST(v.[Precio_Publicar] AS nvarchar) LIKE ('%' + CAST(@Precio_Publicar as nvarchar) + '%') OR @Precio_Publicar is NULL)
	AND (CAST(v.[Porcentaje_Venta] AS nvarchar) LIKE ('%' + CAST(@Porcentaje_Venta as nvarchar) + '%') OR @Porcentaje_Venta is NULL)
	AND (CAST(v.[Duracion] AS nvarchar) LIKE ('%' + CAST(@Duracion as nvarchar) + '%') OR @Duracion is NULL)
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

ALTER PROCEDURE [LA_BANDA_DEL_CHAVO].[GetComprasNotCalificadaByCliente]
@idUsuario int
AS
BEGIN
SELECT  DISTINCT C.ID_Publicacion, P.Descripcion, '$' + CAST(P.Precio AS varchar(10)) AS Precio, (case when CLI.ID_Usuario IS NULL then E.Razon_Social else CLI.Apellido + ', ' + CLI.Nombre end) AS Nombre
	FROM [LA_BANDA_DEL_CHAVO].[TL_Publicacion] P
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Compra] C ON C.ID_Publicacion  = P.ID_Publicacion
	LEFT JOIN [LA_BANDA_DEL_CHAVO].[TL_Empresa] E ON P.ID_Usuario = E.ID_Usuario
	LEFT JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] CLI ON P.ID_Usuario = CLI.ID_Usuario
	LEFT JOIN [LA_BANDA_DEL_CHAVO].[TL_Calificacion] CA ON CA.ID_Publicacion = P.ID_Publicacion
	LEFT JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] CLIE ON CLIE.ID_Cliente = C.ID_Cliente
	WHERE CLIE.ID_Usuario = @idUsuario AND CA.ID_Publicacion IS NULL AND P.ID_Tipo_Publicacion = 1
	ORDER BY Precio ASC
	
END
GO


CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertCalificacion]
	@ID_Publicacion int,
	@ID_Comprador int,
	@Cantidad_estrellas int,
	@Descripcion nvarchar(255)
	
AS
BEGIN
	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Calificacion] (ID_Publicacion, ID_Comprador, Cantidad_Estrellas, Descripcion)
	OUTPUT inserted.Codigo_Calificacion
	VALUES (@ID_Publicacion, @ID_Comprador, @Cantidad_Estrellas, @Descripcion)
END
GO
COMMIT