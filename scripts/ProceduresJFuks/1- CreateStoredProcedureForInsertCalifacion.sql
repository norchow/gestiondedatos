USE [GD1C2014]
GO

/****** Object:  StoredProcedure [LA_BANDA_DEL_CHAVO].[InsertCalificacion]    Script Date: 06/05/2014 00:58:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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

