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
	SET NOCOUNT ON;

	UPDATE [LA_BANDA_DEL_CHAVO].[TL_Usuario]
	SET Intentos_Fallidos = @Intentos_Fallidos, Activo = @Activo
	WHERE ID_Usuario = @ID_User
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdatePassword]
	@ID_User int,
	@Password nvarchar(64)
AS
BEGIN
	SET NOCOUNT ON;

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

COMMIT