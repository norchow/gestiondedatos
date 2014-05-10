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
            public static String SPInsertFuncionalidadXRol = "LA_BANDA_DEL_CHAVO.InsertFuncionalidadXRol";
            public static String SPDeleteFuncionalidadXRol = "LA_BANDA_DEL_CHAVO.DeleteFuncionalidadXRol";
            public static String SPUpdateRolById = "LA_BANDA_DEL_CHAVO.UpdateRolById";
            public static String SPDeleteAllFuncionalidadXRol = "LA_BANDA_DEL_CHAVO.DeleteAllFuncionalidadXRol";
        }

        public static class Usuario
        {
            public static String SPGetUserByUsername = "LA_BANDA_DEL_CHAVO.GetUserByUsername";
            public static String SPUpdateUser = "LA_BANDA_DEL_CHAVO.UpdateUser";
            public static String SPUpdatePassword = "LA_BANDA_DEL_CHAVO.UpdatePassword";
        }
    }
}
