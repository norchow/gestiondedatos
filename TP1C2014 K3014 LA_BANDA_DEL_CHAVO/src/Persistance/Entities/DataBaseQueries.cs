using System;

namespace Persistance.Entities
{
    public static class DataBaseConst
    {
        public static class Funcionalidad
        {
            public static String SPGetAllFuncionalidad = "LA_BANDA_DEL_CHAVO.GetAllFuncionalidad";
            public static String SPGetAllFuncionalidadByRol = "LA_BANDA_DEL_CHAVO.GetAllFuncionalidadByRol";
        }

        public static class Rol
        {
            public static String SPGetAllRol = "LA_BANDA_DEL_CHAVO.GetAllRol";
            public static String SPGetAllRolNotAdmin = "LA_BANDA_DEL_CHAVO.GetAllRolNotAdmin";
            public static String SPGetRolByName = "LA_BANDA_DEL_CHAVO.GetRolByName";
            public static String SPGetAllRolByUser = "LA_BANDA_DEL_CHAVO.GetAllRolByUser";
            public static String SPGetAllRolByNameLike = "LA_BANDA_DEL_CHAVO.GetAllRolByNameLike";
            public static String SPInsertRol = "LA_BANDA_DEL_CHAVO.InsertRol";
            public static String SPInsertFuncionalidadByRol = "LA_BANDA_DEL_CHAVO.InsertFuncionalidadByRol";
            public static String SPUpdateRolById = "LA_BANDA_DEL_CHAVO.UpdateRolById";
            public static String SPDeleteAllFuncionalidadByRol = "LA_BANDA_DEL_CHAVO.DeleteAllFuncionalidadByRol";
            public static String SPInsertUserRole = "LA_BANDA_DEL_CHAVO.InsertUserRole";
        }

        public static class Usuario
        {
            public static String SPGetAllUsuario = "LA_BANDA_DEL_CHAVO.GetAllUsuario";
            public static String SPGetUserByUsername = "LA_BANDA_DEL_CHAVO.GetUserByUsername";
            public static String SPGetUserById = "LA_BANDA_DEL_CHAVO.GetUserById";
            public static String SPInsertUser = "LA_BANDA_DEL_CHAVO.InsertUser";
            public static String SPUpdateUser = "LA_BANDA_DEL_CHAVO.UpdateUser";
            public static String SPUpdatePassword = "LA_BANDA_DEL_CHAVO.UpdatePassword";
            public static String SPInhabilitarUser = "LA_BANDA_DEL_CHAVO.InhabilitarUser";
            public static String SPUpdateUserToDisabledById = "LA_BANDA_DEL_CHAVO.UpdateUserToDisabledById";
            public static String SPUpdateUserToActivateById = "LA_BANDA_DEL_CHAVO.UpdateUserToActivateById";
            
            public static String SPInsertUserTemporal = "LA_BANDA_DEL_CHAVO.InsertUserTemporal";
        }

        public static class Visibilidad
        {
            public static String SPGetAllVisibilidad = "LA_BANDA_DEL_CHAVO.GetAllVisibilidad";
            public static String SPGetAllVisibilidadActive = "LA_BANDA_DEL_CHAVO.GetAllVisibilidadActive";
            public static String SPInsertVisibilidad = "LA_BANDA_DEL_CHAVO.InsertVisibilidad";
            public static String SPUpdateVisibilidad = "LA_BANDA_DEL_CHAVO.UpdateVisibilidad";
            public static String SPGetVisibilidadById = "LA_BANDA_DEL_CHAVO.GetVisibilidadById";
            public static String SPGetAllVisibilidadByParameters = "LA_BANDA_DEL_CHAVO.GetAllVisibilidadByParameters";
            public static String SPGetAllVisibilidadByParametersLike = "LA_BANDA_DEL_CHAVO.GetAllVisibilidadByParametersLike";
            public static String SPGetVisibilidadPurchasesByUser = "LA_BANDA_DEL_CHAVO.GetVisibilityPurchasesByUser";
            public static String SPGetVisibilidadPurchasesByUserAndID = "LA_BANDA_DEL_CHAVO.GetVisibilityPurchasesByUserAndID";
            public static String SPInsertVisibilidadPurchases = "LA_BANDA_DEL_CHAVO.InsertVisibilityPurchases";
            public static String SPUpdateVisibilidadPurchases = "LA_BANDA_DEL_CHAVO.UpdateVisibilityPurchases";

        }

        public static class TipoPublicacion
        {
            public static String SPGetAllTipoPublicacion = "LA_BANDA_DEL_CHAVO.GetAllTipoPublicacion";
            public static String SPGetAllTipoPublicacionById = "LA_BANDA_DEL_CHAVO.GetAllTipoPublicacionById";
        }

        public static class EstadoPublicacion
        {
            public static String SPGetAllEstadoPublicacion = "LA_BANDA_DEL_CHAVO.GetAllEstadoPublicacion";
            public static String SPGetAllEstadoPublicacionById = "LA_BANDA_DEL_CHAVO.GetAllEstadoPublicacionById"; 
        }

        public static class Rubro
        {
            public static String SPGetAllRubro = "LA_BANDA_DEL_CHAVO.GetAllRubro";
            public static String SPInsertRubroByPublicacion = "LA_BANDA_DEL_CHAVO.InsertRubroByPublicacion";
            public static String SPGetAllRubroByPublicationId = "LA_BANDA_DEL_CHAVO.GetAllRubroByPublicacionId";
            public static String SPDeleteRubroByPublicacion = "LA_BANDA_DEL_CHAVO.DeleteRubroByPublicacion";
        }

        public static class Publicacion
        {
            public static String SPGetById = "LA_BANDA_DEL_CHAVO.GetPublicacionById";
            public static String SPGetAllByVisibilityId = "LA_BANDA_DEL_CHAVO.GetPublicacionByVisibilityId";
            public static String SPInsert = "LA_BANDA_DEL_CHAVO.InsertPublicacion";
            public static String SPUpdate = "LA_BANDA_DEL_CHAVO.UpdatePublicacion";
            public static String SPGetAllByUserId = "LA_BANDA_DEL_CHAVO.GetAllPublicationByUserId";
            public static String SPGetPublicacionesARendirByUser = "LA_BANDA_DEL_CHAVO.GetPublicacionesARendirByUser";
            public static String SPGetPublicacionesMasAntiguasARendirByUser = "LA_BANDA_DEL_CHAVO.GetPublicacionesMasAntiguasARendirByUser";
            public static String SPGetAllActive = "LA_BANDA_DEL_CHAVO.GetAllPublicationActive";
            public static String SPGetAllActiveByParameters = "LA_BANDA_DEL_CHAVO.GetAllPublicationActiveByParameters";
            public static String SPGetAllActiveByParametersLike = "LA_BANDA_DEL_CHAVO.GetAllPublicationActiveByParametersLike";
            public static String SPGetAllPublicacionByParameters = "LA_BANDA_DEL_CHAVO.GetAllPublicacionByParameters";
            public static String SPGetAllPublicacionByParametersLike = "LA_BANDA_DEL_CHAVO.GetAllPublicacionByParametersLike";
            public static String SPGetQuestionsAndAnswersById = "LA_BANDA_DEL_CHAVO.GetQuestionsAndAnswersById";
            public static String SPGetAllActiveAndFreeByUserId = "LA_BANDA_DEL_CHAVO.GetAllActiveAndFreeByUserId";
            public static String SPGetFinishedAuctions = "LA_BANDA_DEL_CHAVO.GetFinishedAuctions";
        }

        public static class Calificacion
        {
            public static String SPInsertCalificacion = "LA_BANDA_DEL_CHAVO.InsertCalificacion";
            public static String SPGetNotCalifiedByClientId = "LA_BANDA_DEL_CHAVO.GetComprasNotCalificadaByCliente";
            public static String SPGetNotCalifiedByClientIdByParameters = "LA_BANDA_DEL_CHAVO.GetComprasNotCalificadaByClienteByParameters";
            public static String SPGetNotCalifiedByClientIdByParametersLike = "LA_BANDA_DEL_CHAVO.GetComprasNotCalificadaByClienteByParametersLike";
            public static String SPGetHistoryCalificacionesRecibidas = "LA_BANDA_DEL_CHAVO.GetHistoryCalificacionesRecibidas";
            public static String SPGetHistoryCalificacionesRecibidasByParameters = "LA_BANDA_DEL_CHAVO.GetHistoryCalificacionesRecibidasByParameters";
            public static String SPGetHistoryCalificacionesRecibidasByParametersLike = "LA_BANDA_DEL_CHAVO.GetHistoryCalificacionesRecibidasByParametersLike";
            public static String SPGetCalificationByUserId = "LA_BANDA_DEL_CHAVO.GetCalificacionByUserId";
            public static String SPGetHistoryCalificacionesOtorgadas = "LA_BANDA_DEL_CHAVO.GetHistoryCalificacionesOtorgadas";
            public static String SPGetHistoryCalificacionesOtorgadasByParameters = "LA_BANDA_DEL_CHAVO.GetHistoryCalificacionesOtorgadasByParameters";
            public static String SPGetHistoryCalificacionesOtorgadasByParametersLike = "LA_BANDA_DEL_CHAVO.GetHistoryCalificacionesOtorgadasByParametersLike";
        }

        public static class FormaPago
        {
            public static String SPGetAllFormaPago = "LA_BANDA_DEL_CHAVO.GetAllFormaPago";
            public static String SPGetAllFormaPagoById = "LA_BANDA_DEL_CHAVO.GetAllFormaPagoById";
        }
            
        public static class TipoDocumento
        {
            public static String SPGetAllTipoDocumento = "LA_BANDA_DEL_CHAVO.GetAllTipoDocumento";
            public static String SPGetById = "LA_BANDA_DEL_CHAVO.GetTipoDocumentoById";
        }

        public static class Cliente
        {
            public static String SPGetClientByPhone = "LA_BANDA_DEL_CHAVO.GetClientByPhone";
            public static String SPGetClientByDocument = "LA_BANDA_DEL_CHAVO.GetClientByDocument";
            public static String SPInsertClient = "LA_BANDA_DEL_CHAVO.InsertClient";
            public static String SPUpdateClient = "LA_BANDA_DEL_CHAVO.UpdateClient";
            public static String SPGetClientByUserId = "LA_BANDA_DEL_CHAVO.GetClientByUserId";
            public static String SPGetById = "LA_BANDA_DEL_CHAVO.GetClientById";
            public static String SPGetAllClients = "LA_BANDA_DEL_CHAVO.GetAllClients";
            public static String SPGetAllClientsByParameters = "LA_BANDA_DEL_CHAVO.GetAllClientsByParameters";
            public static String SPGetAllClientsByParametersLike = "LA_BANDA_DEL_CHAVO.GetAllClientsByParametersLike";
        }

        public static class Compra
        {
            public static String SPGetHistoryComprasByUsuario = "LA_BANDA_DEL_CHAVO.GetHistoryComprasByUsuario";
            public static String SPGetHistoryComprasByUsuarioByParameters = "LA_BANDA_DEL_CHAVO.GetHistoryComprasByUsuarioByParameters";
            public static String SPGetHistoryComprasByUsuarioByParametersLike = "LA_BANDA_DEL_CHAVO.GetHistoryComprasByUsuarioByParametersLike";
            public static String SPGetAllCompraByPublicationId = "LA_BANDA_DEL_CHAVO.GetAllCompraByPublicacionId";
            public static String SPGetCantidadComprasByPublicationIdGroupByClient = "LA_BANDA_DEL_CHAVO.GetCantidadComprasByPublicationIdGroupByClient";
            public static String SPInsertPurchase = "LA_BANDA_DEL_CHAVO.InsertPurchase";
        }

        public static class Oferta
        {
            public static String SPGetHistoryOfertasByUsuario = "LA_BANDA_DEL_CHAVO.GetHistoryOfertasByUsuario";
            public static String SPGetHistoryOfertasByUsuarioByParameters = "LA_BANDA_DEL_CHAVO.GetHistoryOfertasByUsuarioByParameters";
            public static String SPGetHistoryOfertasByUsuarioByParametersLike = "LA_BANDA_DEL_CHAVO.GetHistoryOfertasByUsuarioByParametersLike";
            public static String SPGetLastOfertaByPublication = "LA_BANDA_DEL_CHAVO.GetLastOfertaByPublication";
            public static String SPInsertOffer = "LA_BANDA_DEL_CHAVO.InsertOffer";
        }

        public static class Empresa
        {
            public static String SPGetCompanyByBusinessName = "LA_BANDA_DEL_CHAVO.GetCompanyByBusinessName";
            public static String SPGetCompanyByCUIT = "LA_BANDA_DEL_CHAVO.GetCompanyByCUIT";
            public static String SPInsertCompany = "LA_BANDA_DEL_CHAVO.InsertCompany";
            public static String SPUpdateCompany = "LA_BANDA_DEL_CHAVO.UpdateBusiness";
            public static String SPGetCompanyByUserId = "LA_BANDA_DEL_CHAVO.GetCompanyByUserId";
            public static String SPGetAllBusiness = "LA_BANDA_DEL_CHAVO.GetAllBusiness";
            public static String SPGetAllBusinessByParameters = "LA_BANDA_DEL_CHAVO.GetAllBusinessByParameters";
            public static String SPGetAllBusinessByParametersLike = "LA_BANDA_DEL_CHAVO.GetAllBusinessByParametersLike";
        }

        public static class Pregunta
        {
            public static String SPInsertQuestion = "LA_BANDA_DEL_CHAVO.InsertQuestion";
            public static String SPGetUnansweredByUserId = "LA_BANDA_DEL_CHAVO.GetUnansweredQuestionsByUserId";
        }

        public static class Respuesta
        {
            public static String SPInsertAnswer = "LA_BANDA_DEL_CHAVO.InsertAnswer";
        }

        public static class Factura
        {
            public static String SPGetUltimoNumeroFactura = "LA_BANDA_DEL_CHAVO.GetUltimoNumeroFactura";
            public static String SPGetFacturaByNumero = "LA_BANDA_DEL_CHAVO.GetFacturaByNumero";
            public static String SPInsertFactura = "LA_BANDA_DEL_CHAVO.InsertFactura";
            public static String SPGetById = "LA_BANDA_DEL_CHAVO.GetFacturaById";
        }

        public static class ItemFactura
        {
            public static String SPGetAllItemFacturaByFacturaId = "LA_BANDA_DEL_CHAVO.GetAllItemFacturaByFacturaId";
            public static String SPInsertItemFactura = "LA_BANDA_DEL_CHAVO.InsertItemFactura";
        }

        public static class Estadistica
        {
            public static String SPGetSellersWithMoreProductsNotSold = "LA_BANDA_DEL_CHAVO.GetSellersWithMoreProductsNotSold";
            public static String SPGetSellersWithMoreBilling = "LA_BANDA_DEL_CHAVO.GetSellersWithMoreBilling";
            public static String SPGetClientsWithMoreNotQualifiedPublications = "LA_BANDA_DEL_CHAVO.GetClientsWithMoreNotQualifiedPublications";
            public static String SPGetSellersWithBetterQualifications = "LA_BANDA_DEL_CHAVO.GetSellersWithBetterQualifications";
        }

        public static class TarjetaCredito
        {
            public static String SPInsertCreditCard = "LA_BANDA_DEL_CHAVO.InsertCreditCard";
        }
    }
}
