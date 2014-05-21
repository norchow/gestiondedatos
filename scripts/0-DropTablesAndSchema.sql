BEGIN TRANSACTION
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Tipo_Documento];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Compra];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Calificacion];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Empresa];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Item_Factura];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Tarjeta_Credito];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Factura];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Forma_Pago];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Oferta];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Respuesta];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Pregunta];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad_Rol];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Rol];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Rol];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Rubro_Publicacion];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Rubro];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Publicacion];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Tipo_Publicacion];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Estado_Publicacion];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Funcionalidad];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario_Visibilidad];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Visibilidad];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Cliente];
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Usuario];

DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllFuncionalidad];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllFuncionalidadByRol];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllRolByUser];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetRolByName];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetUserByUsername];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdateUser];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdatePassword];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdateRolById];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllRol];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertFuncionalidadByRol];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertRol];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[DeleteAllFuncionalidadByRol];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllRolByNameLike];

DROP SCHEMA [LA_BANDA_DEL_CHAVO];

COMMIT