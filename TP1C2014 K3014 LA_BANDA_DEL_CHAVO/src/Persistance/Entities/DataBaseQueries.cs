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
            public static String SPGetRolByName = "LA_BANDA_DEL_CHAVO.GetRolByName";
            public static String SPGetAllRolByUser = "LA_BANDA_DEL_CHAVO.GetAllRolByUser";
            public static String SPGetAllRolByNameLike = "LA_BANDA_DEL_CHAVO.GetAllRolByNameLike";
            public static String SPInsertRol = "LA_BANDA_DEL_CHAVO.InsertRol";
            public static String SPInsertFuncionalidadByRol = "LA_BANDA_DEL_CHAVO.InsertFuncionalidadByRol";
            public static String SPUpdateRolById = "LA_BANDA_DEL_CHAVO.UpdateRolById";
            public static String SPDeleteAllFuncionalidadByRol = "LA_BANDA_DEL_CHAVO.DeleteAllFuncionalidadByRol";
        }

        public static class Usuario
        {
            public static String SPGetUserByUsername = "LA_BANDA_DEL_CHAVO.GetUserByUsername";
            public static String SPGetUserById = "LA_BANDA_DEL_CHAVO.GetUserById";
            public static String SPUpdateUser = "LA_BANDA_DEL_CHAVO.UpdateUser";
            public static String SPUpdatePassword = "LA_BANDA_DEL_CHAVO.UpdatePassword";
        }

        public static class Visibilidad
        {
            public static String SPGetAllVisibilidad = "LA_BANDA_DEL_CHAVO.GetAllVisibilidad";
            public static String SPInsertVisibilidad = "LA_BANDA_DEL_CHAVO.InsertVisibilidad";
            public static String SPUpdateVisibilidad = "LA_BANDA_DEL_CHAVO.UpdateVisibilidad";
            public static String SPGetVisibilidadById = "LA_BANDA_DEL_CHAVO.GetVisibilidadById";
            public static String SPGetAllVisibilidadByParameters = "LA_BANDA_DEL_CHAVO.GetAllVisibilitidadByParameters";
            public static String SPGetAllVisibilidadByParametersLike = "LA_BANDA_DEL_CHAVO.GetAllVisibilitidadByParametersLike";
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
            public static String SPInsert = "LA_BANDA_DEL_CHAVO.InsertPublicacion";
            public static String SPUpdate = "LA_BANDA_DEL_CHAVO.UpdatePublicacion";
            public static String SPGetAllByUserId = "LA_BANDA_DEL_CHAVO.GetAllPublicationByUserId";
            public static String SPGetNotCalifiedByClientId = "LA_BANDA_DEL_CHAVO.GetComprasNotCalificadaByCliente";
        }

        public static class Calificacion
        {
            public static String SPInsertCalificacion = "LA_BANDA_DEL_CHAVO.InsertCalificacion";
          }
    }
}
