USE [GD1C2014]
GO

/****** Object:  StoredProcedure [LA_BANDA_DEL_CHAVO].[GetComprasNotCalificadaByClienteByParametersLike]    Script Date: 06/08/2014 21:06:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetComprasNotCalificadaByClienteByParametersLike]
@idUsuario numeric(18,2) = NULL,
@CodigoPublicacion nvarchar(255) = NULL,
@Descripcion nvarchar(255) = NULL,
@Precio nvarchar(255) = NULL,
@Vendedor nvarchar(255) = NULL
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
	AND ((C.ID_Publicacion LIKE ('%' + @CodigoPublicacion + '%')) OR @CodigoPublicacion is NULL)
	AND ((LOWER(P.Descripcion) LIKE ('%' + @Descripcion + '%')) OR @Descripcion is NULL)
	AND ((P.Precio LIKE ('%' + @Precio + '%')) OR @Precio is NULL)
	AND ((LOWER(case when CLI.ID_Usuario IS NULL then E.Razon_Social else CLI.Apellido + ', ' + CLI.Nombre end) LIKE ('%' + LOWER(@Vendedor) + '%')) OR @Vendedor is NULL)
	ORDER BY Precio ASC
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetComprasNotCalificadaByClienteByParameters]
@idUsuario numeric(18,2) = NULL,
@CodigoPublicacion numeric(18,2) = NULL,
@Descripcion nvarchar(255) = NULL,
@Precio numeric(18,2) = NULL,
@Vendedor nvarchar(255) = NULL
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
	AND ((C.ID_Publicacion = @CodigoPublicacion) OR @CodigoPublicacion is NULL)
	AND ((LOWER(P.Descripcion) = LOWER(@Descripcion)) OR @Descripcion is NULL)
	AND ((P.Precio = @Precio) OR @Precio is NULL)
	AND ((LOWER((case when CLI.ID_Usuario IS NULL then E.Razon_Social else CLI.Apellido + ', ' + CLI.Nombre end)) = LOWER(@Vendedor)) OR @Vendedor is NULL)
	ORDER BY Precio ASC
	
END
GO





CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryComprasByUsuario]
	@idUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.ID_Compra, P.Descripcion, C.Compra_Fecha, P.Precio, C.Compra_Cantidad
	FROM [LA_BANDA_DEL_CHAVO].[TL_Compra] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion] AS P ON P.ID_Publicacion = C.ID_Publicacion
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] AS CLI ON CLI.ID_Cliente = C.ID_Cliente
	WHERE CLI.ID_Usuario = @idUsuario
	ORDER BY C.Compra_Fecha DESC
END
GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryComprasByUsuarioByParameters]
	@idUsuario int = NULL,
	@ID_Compra int= NULL,
	@Descripcion varchar(255) = NULL,
	@Compra_Fecha varchar(255)= NULL,
	@Precio numeric (18,2) = NULL,
	@Compra_Cantidad int = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.ID_Compra, P.Descripcion, C.Compra_Fecha, P.Precio, C.Compra_Cantidad
	FROM [LA_BANDA_DEL_CHAVO].[TL_Compra] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion] AS P ON P.ID_Publicacion = C.ID_Publicacion
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] AS CLI ON CLI.ID_Cliente = C.ID_Cliente
	WHERE CLI.ID_Usuario = @idUsuario
	AND ((C.ID_Compra = @ID_Compra) OR @ID_Compra is NULL)
	AND ((LOWER(P.Descripcion) = LOWER(@Descripcion)) OR @Descripcion is NULL)
	AND ((P.Precio  = @Precio) OR @Precio is NULL)
	AND ((C.Compra_Fecha = @Compra_Fecha) OR @Compra_Fecha is NULL)
	AND ((C.Compra_Cantidad = @Compra_Cantidad) OR @Compra_Cantidad is NULL)	
	ORDER BY C.Compra_Fecha DESC
END




GO




CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryComprasByUsuarioByParametersLike]
	@idUsuario int = NULL,
	@ID_Compra varchar(255) = NULL,
	@Descripcion varchar(255) = NULL,
	@Compra_Fecha varchar(255)= NULL,
	@Precio varchar (255) = NULL,
	@Compra_Cantidad varchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.ID_Compra, P.Descripcion, C.Compra_Fecha, P.Precio, C.Compra_Cantidad
	FROM [LA_BANDA_DEL_CHAVO].[TL_Compra] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion] AS P ON P.ID_Publicacion = C.ID_Publicacion
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] AS CLI ON CLI.ID_Cliente = C.ID_Cliente
	WHERE CLI.ID_Usuario = @idUsuario
	AND ((C.ID_Compra LIKE ('%' + @ID_Compra + '%')) OR @ID_Compra is NULL)
	AND ((LOWER(P.Descripcion) LIKE ('%' + LOWER(@Descripcion) + '%')) OR @Descripcion is NULL)
	AND ((P.Precio  LIKE ('%' + @Precio + '%')) OR @Precio is NULL)
	AND ((C.Compra_Fecha  LIKE ('%' + @Compra_Fecha + '%') ) OR @Compra_Fecha is NULL)
	AND ((C.Compra_Cantidad LIKE ('%' + @Compra_Cantidad + '%')) OR @Compra_Cantidad is NULL)	
	ORDER BY C.Compra_Fecha DESC
END




GO



CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesRecibidas]
	@idUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.Codigo_Calificacion, P.Descripcion, C.Cantidad_Estrellas, CLI.Apellido + ', ' + CLI.Nombre AS Nombre
	FROM [LA_BANDA_DEL_CHAVO].[TL_Calificacion] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion]  AS P  ON C.ID_Publicacion = P.ID_Publicacion
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] AS CLI ON CLI.ID_Cliente = C.ID_Comprador
	WHERE P.ID_Usuario = @idUsuario
END




GO