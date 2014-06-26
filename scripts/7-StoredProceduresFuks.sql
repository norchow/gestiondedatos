USE [GD1C2014]
GO

/****** Object:  StoredProcedure [LA_BANDA_DEL_CHAVO].[GetComprasNotCalificadaByClienteByParametersLike]    Script Date: 06/08/2014 21:06:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetComprasNotCalificadaByClienteByParametersLike]
@idUsuario numeric(18,2) = NULL,
@Fecha_hoy datetime = NULL,
@CodigoPublicacion nvarchar(255) = NULL,
@Descripcion nvarchar(255) = NULL,
@Precio nvarchar(255) = NULL
AS
BEGIN

SELECT C.ID_Publicacion, P.Descripcion,  '$' + CAST(P.Precio AS varchar(10)) AS Precio
FROM LA_BANDA_DEL_CHAVO.TL_Publicacion P
INNER JOIN LA_BANDA_DEL_CHAVO.TL_Compra C ON C.ID_Publicacion  = P.ID_Publicacion
INNER JOIN LA_BANDA_DEL_CHAVO.TL_Usuario u ON C.ID_Usuario = U.ID_Usuario
WHERE U.ID_Usuario=@idUsuario
AND NOT EXISTS (SELECT * FROM LA_BANDA_DEL_CHAVO.TL_Calificacion CAL
				WHERE CAL.ID_Comprador = @idUsuario
				AND CAL.ID_Publicacion = C.ID_Publicacion)
	AND ((C.ID_Publicacion LIKE ('%' + @CodigoPublicacion + '%')) OR @CodigoPublicacion is NULL)
	AND ((LOWER(P.Descripcion) LIKE ('%' + @Descripcion + '%')) OR @Descripcion is NULL)
	AND ((P.Precio LIKE ('%' + @Precio + '%')) OR @Precio is NULL)
END

GO


CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetComprasNotCalificadaByClienteByParameters]
@idUsuario numeric(18,2) = NULL,
@Fecha_hoy datetime = NULL,
@CodigoPublicacion numeric(18,2) = NULL,
@Descripcion nvarchar(255) = NULL,
@Precio numeric(18,2) = NULL
AS
BEGIN
SELECT C.ID_Publicacion, P.Descripcion,  '$' + CAST(P.Precio AS varchar(10)) AS Precio
FROM LA_BANDA_DEL_CHAVO.TL_Publicacion P
INNER JOIN LA_BANDA_DEL_CHAVO.TL_Compra C ON C.ID_Publicacion  = P.ID_Publicacion
INNER JOIN LA_BANDA_DEL_CHAVO.TL_Usuario U ON C.ID_Usuario = U.ID_Usuario
WHERE U.ID_Usuario=@idUsuario
AND NOT EXISTS (SELECT * FROM LA_BANDA_DEL_CHAVO.TL_Calificacion CAL
				WHERE CAL.ID_Comprador = @idUsuario
				AND CAL.ID_Publicacion = C.ID_Publicacion)
	AND ((C.ID_Publicacion = @CodigoPublicacion) OR @CodigoPublicacion is NULL)
	AND ((LOWER(P.Descripcion) = LOWER(@Descripcion)) OR @Descripcion is NULL)
	AND ((P.Precio = @Precio) OR @Precio is NULL)
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
	WHERE C.ID_Usuario = @idUsuario
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
	WHERE C.ID_Usuario = @idUsuario
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
	WHERE C.ID_Usuario = @idUsuario
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
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] AS CLI ON CLI.ID_Usuario = C.ID_Comprador
	WHERE P.ID_Usuario = @idUsuario
END




GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesRecibidasByParameters]
	@idUsuario int = NULL,
	@Codigo_Calificacion int= NULL,
	@Descripcion varchar(255) = NULL,
	@Cantidad_Estrellas int = NULL,
	@Nombre varchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.Codigo_Calificacion, P.Descripcion, C.Cantidad_Estrellas, CLI.Apellido + ', ' + CLI.Nombre AS Nombre
	FROM [LA_BANDA_DEL_CHAVO].[TL_Calificacion] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion]  AS P  ON C.ID_Publicacion = P.ID_Publicacion
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] AS CLI ON CLI.ID_Usuario = C.ID_Comprador
	WHERE P.ID_Usuario = @idUsuario
	AND ((C.Codigo_Calificacion = @Codigo_Calificacion) OR @Codigo_Calificacion is NULL)
	AND ((P.Descripcion = @Descripcion) OR @Descripcion is NULL)
	AND ((C.Cantidad_Estrellas = @Cantidad_Estrellas) OR @Cantidad_Estrellas is NULL)
	AND ((CLI.Apellido + ', ' + CLI.Nombre = @Nombre) OR @Nombre is NULL)
	
	
	
END




GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesRecibidasByParametersLike]
	@idUsuario int = NULL,
	@Codigo_Calificacion varchar(255) = NULL,
	@Descripcion varchar(255) = NULL,
	@Cantidad_Estrellas varchar(255) = NULL,
	@Nombre varchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.Codigo_Calificacion, P.Descripcion, C.Cantidad_Estrellas, CLI.Apellido + ', ' + CLI.Nombre AS Nombre
	FROM [LA_BANDA_DEL_CHAVO].[TL_Calificacion] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion]  AS P  ON C.ID_Publicacion = P.ID_Publicacion
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] AS CLI ON CLI.ID_Usuario = C.ID_Comprador
	WHERE P.ID_Usuario = @idUsuario
	AND ((C.Codigo_Calificacion LIKE ('%' + @Codigo_Calificacion + '%')) OR @Codigo_Calificacion is NULL)
	AND ((P.Descripcion LIKE ('%' + @Descripcion + '%')) OR @Descripcion is NULL)
	AND ((C.Cantidad_Estrellas LIKE ('%' + @Cantidad_Estrellas + '%')) OR @Cantidad_Estrellas is NULL)
	AND ((CLI.Apellido + ', ' + CLI.Nombre LIKE ('%' + @Nombre + '%')) OR @Nombre is NULL)
	
	
	
END





GO




CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesOtorgadas]
	@idUsuario int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.Codigo_Calificacion, P.Descripcion, C.Cantidad_Estrellas,  (case when CLI.ID_Usuario IS NULL then E.Razon_Social else CLI.Apellido + ', ' + CLI.Nombre end) AS Nombre
	FROM [LA_BANDA_DEL_CHAVO].[TL_Calificacion] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion]  AS P  ON C.ID_Publicacion = P.ID_Publicacion
	LEFT JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] AS CLI ON CLI.ID_Usuario = P.ID_Usuario
	LEFT JOIN [LA_BANDA_DEL_CHAVO].[TL_Empresa] AS E ON E.ID_Empresa = P.ID_Usuario
	WHERE C.ID_Comprador = @idUsuario
END






GO



CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesOtorgadasByParameters]
	@idUsuario int = NULL,
	@Codigo_Calificacion int= NULL,
	@Descripcion varchar(255) = NULL,
	@Cantidad_Estrellas int = NULL,
	@Nombre varchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.Codigo_Calificacion, P.Descripcion, C.Cantidad_Estrellas,  (case when CLI.ID_Usuario IS NULL then E.Razon_Social else CLI.Apellido + ', ' + CLI.Nombre end) AS Nombre
	FROM [LA_BANDA_DEL_CHAVO].[TL_Calificacion] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion]  AS P  ON C.ID_Publicacion = P.ID_Publicacion
	LEFT JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] AS CLI ON CLI.ID_Usuario = P.ID_Usuario
	LEFT JOIN [LA_BANDA_DEL_CHAVO].[TL_Empresa] AS E ON E.ID_Empresa = P.ID_Usuario
	WHERE C.ID_Comprador = @idUsuario
	AND ((C.Codigo_Calificacion = @Codigo_Calificacion) OR @Codigo_Calificacion is NULL)
	AND ((P.Descripcion = @Descripcion) OR @Descripcion is NULL)
	AND ((C.Cantidad_Estrellas = @Cantidad_Estrellas) OR @Cantidad_Estrellas is NULL)
	AND (((case when CLI.ID_Usuario IS NULL then E.Razon_Social else CLI.Apellido + ', ' + CLI.Nombre end) = @Nombre) OR @Nombre is NULL)
	
END






GO





CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesOtorgadasByParametersLike]
	@idUsuario int = NULL,
	@Codigo_Calificacion varchar(255)= NULL,
	@Descripcion varchar(255) = NULL,
	@Cantidad_Estrellas varchar(255) = NULL,
	@Nombre varchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT C.Codigo_Calificacion, P.Descripcion, C.Cantidad_Estrellas,  (case when CLI.ID_Usuario IS NULL then E.Razon_Social else CLI.Apellido + ', ' + CLI.Nombre end) AS Nombre
	FROM [LA_BANDA_DEL_CHAVO].[TL_Calificacion] AS C
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Publicacion]  AS P  ON C.ID_Publicacion = P.ID_Publicacion
	LEFT JOIN [LA_BANDA_DEL_CHAVO].[TL_Cliente] AS CLI ON CLI.ID_Usuario = P.ID_Usuario
	LEFT JOIN [LA_BANDA_DEL_CHAVO].[TL_Empresa] AS E ON E.ID_Empresa = P.ID_Usuario
	WHERE C.ID_Comprador = @idUsuario
	AND ((C.Codigo_Calificacion LIKE ('%' + @Codigo_Calificacion  + '%')) OR @Codigo_Calificacion is NULL)
	AND ((P.Descripcion LIKE ('%' + @Descripcion  + '%')) OR @Descripcion is NULL)
	AND ((C.Cantidad_Estrellas LIKE ('%' + @Cantidad_Estrellas  + '%')) OR @Cantidad_Estrellas is NULL)
	AND (((case when CLI.ID_Usuario IS NULL then E.Razon_Social else CLI.Apellido + ', ' + CLI.Nombre end) LIKE ('%' + @Nombre  + '%')) OR @Nombre is NULL)
	
END







GO


CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryOfertasByUsuario]
	@idUsuario int,
	@Fecha_hoy datetime
AS
BEGIN
SELECT O.ID_Oferta, O.Monto, O.Fecha, P.Descripcion, (CASE WHEN O.Monto = (SELECT MAX(Monto)
FROM LA_BANDA_DEL_CHAVO.TL_Oferta 
WHERE ID_Publicacion=O.ID_Publicacion ) AND P.Fecha_Vencimiento < @Fecha_hoy THEN 'Si' ELSE 'No' END) AS Ganada
FROM [LA_BANDA_DEL_CHAVO].[TL_Oferta] AS O
INNER JOIN [LA_BANDA_DEL_CHAVO].TL_Publicacion AS P ON O.ID_Publicacion = P.ID_Publicacion 
WHERE O.ID_Usuario = @idUsuario

END




GO





CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryOfertasByUsuarioByParameters]
	@idUsuario int = NULL,
	@Fecha_hoy datetime = NULL,
	@ID_Oferta int = NULL,
	@Monto numeric (18, 2) = NULL,
	@Fecha varchar(255) = NULL,
	@Descripcion varchar(255) = NULL,
	@Ganada varchar(255) = NULL
AS
BEGIN
SELECT O.ID_Oferta, O.Monto, O.Fecha, P.Descripcion, (CASE WHEN O.Monto = (SELECT MAX(Monto)
FROM LA_BANDA_DEL_CHAVO.TL_Oferta 
WHERE ID_Publicacion=O.ID_Publicacion ) AND P.Fecha_Vencimiento < @Fecha_hoy THEN 'Si' ELSE 'No' END) AS Ganada
FROM [LA_BANDA_DEL_CHAVO].[TL_Oferta] AS O
INNER JOIN [LA_BANDA_DEL_CHAVO].TL_Publicacion AS P ON O.ID_Publicacion = P.ID_Publicacion 
WHERE O.ID_Usuario = @idUsuario
	AND ((O.ID_Oferta  = @ID_Oferta) OR @ID_Oferta is NULL)
	AND ((O.Monto = @Monto) OR @Monto is NULL)
	AND ((O.Fecha = @Fecha) OR @Fecha is NULL)
	AND ((P.Descripcion = @Descripcion) OR @Descripcion is NULL)
	AND (((CASE WHEN O.Monto = (SELECT MAX(Monto)
FROM LA_BANDA_DEL_CHAVO.TL_Oferta 
WHERE ID_Publicacion=O.ID_Publicacion ) AND P.Fecha_Vencimiento < @Fecha_hoy THEN 'Si' ELSE 'No' END) = @Ganada) OR @Ganada is NULL)
	
END





GO





CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryOfertasByUsuarioByParametersLike]
	@idUsuario int = NULL,
	@Fecha_hoy datetime = NULL,
	@ID_Oferta varchar(255) = NULL,
	@Monto varchar(255) = NULL,
	@Fecha varchar(255) = NULL,
	@Descripcion varchar(255) = NULL,
	@Ganada varchar(255) = NULL
AS
BEGIN
SELECT O.ID_Oferta, O.Monto, O.Fecha, P.Descripcion, (CASE WHEN O.Monto = (SELECT MAX(Monto)
FROM LA_BANDA_DEL_CHAVO.TL_Oferta 
WHERE ID_Publicacion=O.ID_Publicacion ) AND P.Fecha_Vencimiento < @Fecha_hoy THEN 'Si' ELSE 'No' END) AS Ganada
FROM [LA_BANDA_DEL_CHAVO].[TL_Oferta] AS O
INNER JOIN [LA_BANDA_DEL_CHAVO].TL_Publicacion AS P ON O.ID_Publicacion = P.ID_Publicacion 
WHERE O.ID_Usuario = @idUsuario
	AND ((O.ID_Oferta  LIKE ('%'+ @ID_Oferta + '%') ) OR @ID_Oferta is NULL)
	AND ((O.Monto LIKE ('%'+ @Monto + '%')  ) OR @Monto is NULL)
	AND ((O.Fecha LIKE ('%'+ @Fecha + '%')) OR @Fecha is NULL)
	AND ((P.Descripcion LIKE ('%'+ @Descripcion + '%') ) OR @Descripcion is NULL)
	AND (((CASE WHEN O.Monto = (SELECT MAX(Monto)
FROM LA_BANDA_DEL_CHAVO.TL_Oferta 
WHERE ID_Publicacion=O.ID_Publicacion ) AND P.Fecha_Vencimiento < @Fecha_hoy THEN 'Si' ELSE 'No' END) LIKE ('%'+ @Ganada + '%')) OR @Ganada is NULL)
	
END






GO

CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertUserTemporal]
	@Username nvarchar(255),
	@Password nvarchar(64)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [LA_BANDA_DEL_CHAVO].[TL_Usuario] (Username, Password, Pass_Temporal)
	OUTPUT inserted.ID_Usuario
	VALUES (@Username, @Password, 1)
END


GO


CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllBusinessByParameters]
	@Razon_Social nvarchar(255) = NULL,
	@Cuit nvarchar(255) = NULL,
	@Email nvarchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;

SELECT E.*, U.Habilitado
	FROM [LA_BANDA_DEL_CHAVO].TL_Empresa AS E
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Usuario] AS U ON E.ID_Usuario = U.ID_Usuario

	WHERE 
	((LOWER(E.Razon_Social) = LOWER(@Razon_Social)) OR @Razon_Social is NULL)
	AND ((LOWER(E.CUIT) = LOWER(@Cuit)) OR @Cuit is NULL)
	AND ((LOWER(E.Mail) = LOWER(@Email)) OR @Email is NULL)
	
END




GO


CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllBusiness]

AS
BEGIN
	SET NOCOUNT ON;

	SELECT E.*, U.Habilitado
	FROM [LA_BANDA_DEL_CHAVO].TL_Empresa AS E
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Usuario] AS U ON E.ID_Usuario = U.ID_Usuario
END


GO




CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllBusinessByParametersLike]
	@Razon_Social nvarchar(255) = NULL,
	@Cuit nvarchar(255) = NULL,
	@Email nvarchar(255) = NULL
AS
BEGIN
	SET NOCOUNT ON;

	SELECT E.*, U.Habilitado
	FROM [LA_BANDA_DEL_CHAVO].TL_Empresa AS E
	INNER JOIN [LA_BANDA_DEL_CHAVO].[TL_Usuario] AS U ON E.ID_Usuario = U.ID_Usuario
WHERE 
	((LOWER(E.Razon_Social) LIKE  ('%' + LOWER(@Razon_Social) + '%')) OR @Razon_Social is NULL)
	AND ((LOWER(E.CUIT) LIKE  ('%' + LOWER(@Cuit) + '%')) OR @Cuit is NULL)
	AND ((LOWER(E.Mail)LIKE  ('%' + LOWER(@Email) + '%')) OR @Email is NULL)
	
END



GO





CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdateUserToDisabledById]
	@ID_User int
AS
BEGIN
	UPDATE [LA_BANDA_DEL_CHAVO].[TL_Usuario]
	SET Habilitado = 0
	WHERE ID_Usuario = @ID_User
END


GO


CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdateUserToActivateById]
	@ID_User int
AS
BEGIN
	UPDATE [LA_BANDA_DEL_CHAVO].[TL_Usuario]
	SET Habilitado = 1
	WHERE ID_Usuario = @ID_User
END



GO





CREATE PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdateBusiness]
	@ID_User int,
	@Razon_Social varchar(255),
	@Mail varchar(255),
	@Telefono varchar(255),
	@Direccion varchar(255),
	@Codigo_Postal varchar(255),
	@Ciuidad varchar(255),
	@CUIT varchar(255),
	@Nombre_Contacto varchar(255),
	@Fecha_Creacion datetime
AS
BEGIN
	UPDATE [LA_BANDA_DEL_CHAVO].[TL_Empresa] 
	SET Razon_Social = @Razon_Social, Mail = @Mail, Telefono = @Telefono,
	Direccion = @Direccion, Codigo_Postal = @Codigo_Postal, Ciudad = @Ciuidad,
	CUIT = @CUIT, Nombre_Contacto = @Nombre_Contacto, Fecha_Creacion = @Fecha_Creacion
	WHERE ID_Usuario = @ID_User
END


GO

