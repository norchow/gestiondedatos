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

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllRol]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT *
	FROM [LA_BANDA_DEL_CHAVO].[TL_Rol]
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

COMMIT

