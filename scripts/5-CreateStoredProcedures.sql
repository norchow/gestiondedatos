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