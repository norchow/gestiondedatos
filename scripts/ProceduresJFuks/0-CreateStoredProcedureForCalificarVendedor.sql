USE [GD1C2014]
GO

/****** Object:  StoredProcedure [LA_BANDA_DEL_CHAVO].[GetComprasNotCalificadaByCliente]    Script Date: 06/04/2014 23:58:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetComprasNotCalificadaByCliente]
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
	WHERE CLIE.ID_Usuario = @idUsuario AND CA.ID_Publicacion IS NULL
	ORDER BY Precio ASC
	
END


GO

