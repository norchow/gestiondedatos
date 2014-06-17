USE [GD1C2014]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER TL_Rol_After_Update ON [LA_BANDA_DEL_CHAVO].[TL_Rol]
FOR UPDATE
AS
	DECLARE @Activo int;
	DECLARE @ID_Rol int;
	SET @Activo = (SELECT DISTINCT Activo FROM INSERTED);
	SET @ID_Rol = (SELECT DISTINCT ID_Rol FROM INSERTED);
	
	IF (@Activo = 0)
	BEGIN
		DELETE FROM [LA_BANDA_DEL_CHAVO].[TL_Usuario_Rol]
		WHERE ([ID_Rol] = @ID_Rol)
	END
GO

CREATE TRIGGER TL_Calificacion_After_Insert ON [LA_BANDA_DEL_CHAVO].[TL_Calificacion]
FOR INSERT
AS
	DECLARE @ID_Usuario int;
	DECLARE @Promedio numeric(18,2);
	
	SET @ID_Usuario = (
						SELECT TOP 1 P.ID_Usuario 
						FROM INSERTED INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion] P ON INSERTED.ID_Publicacion = P.ID_Publicacion
					  );
					  
	SET @Promedio = (
						SELECT AVG([Cantidad_Estrellas]) 
						FROM TL_Calificacion C INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion] P ON C.ID_Publicacion = P.ID_Publicacion
						WHERE P.[ID_Usuario] = @ID_Usuario
					);
	
	UPDATE [LA_BANDA_DEL_CHAVO].[TL_Usuario]
	SET [Reputacion] = @Promedio
	WHERE ([LA_BANDA_DEL_CHAVO].[TL_Usuario].[ID_Usuario] = @ID_Usuario)
GO