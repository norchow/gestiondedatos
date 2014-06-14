
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
DROP TABLE [LA_BANDA_DEL_CHAVO].[TL_Tipo_Documento];

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
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllVisibilidad];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertVisibilidad];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdateVisibilidad];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetVisibilidadById];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllVisibilidadByParameters];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllVisibilidadByParametersLike];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllTipoPublicacion];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllEstadoPublicacion];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllRubro];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetPublicacionById];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertPublicacion];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetUserById];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllTipoPublicacionById];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllEstadoPublicacionById];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertRubroByPublicacion];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllRubroByPublicacionId];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllPublicationByUserId];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[DeleteRubroByPublicacion];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[UpdatePublicacion];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertCalificacion];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetComprasNotCalificadaByCliente];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertUser];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllTipoDocumento];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetClientByPhone];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetClientByDocument];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertClient];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllRolNotAdmin];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetCompanyByBusinessName];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetCompanyByCUIT];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertCompany];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllUsuario];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetComprasNotCalificadaByClienteByParameters];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetComprasNotCalificadaByClienteByParametersLike];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllFormaPago];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllPublicationActive];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertQuestion];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryComprasByUsuario];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryComprasByUsuarioByParameters];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryComprasByUsuarioByParametersLike];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetPublicacionesARendirByUser];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetPublicacionesMasAntiguasARendirByUser];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesRecibidas];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllPublicacionByParameters];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetAllPublicacionByParametersLike];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesRecibidasByParameters];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesRecibidasByParametersLike];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesOtorgadas];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesOtorgadasByParameters];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryCalificacionesOtorgadasByParametersLike];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryOfertasByUsuario];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryOfertasByUsuarioByParameters];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetHistoryOfertasByUsuarioByParametersLike];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetUnansweredQuestionsByUserId];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[InsertAnswer];
DROP PROCEDURE [LA_BANDA_DEL_CHAVO].[GetQuestionsAndAnswersById];

DROP SCHEMA [LA_BANDA_DEL_CHAVO];
