using System.Collections.Generic;
using Persistance.Entities;

namespace Persistance
{
    public static class UsuarioPersistance
    {
        public static Usuario GetByUsername(string userName)
        {
            var param = new List<SPParameter> { new SPParameter("Username", userName) };
            var sp = new StoreProcedure(DataBaseConst.Usuario.SPGetUserByUsername, param);

            var users = sp.ExecuteReader<Usuario>();

            if (users == null || users.Count == 0)
                return null;

            return users[0];
        }

        public static void ChangePassword(Usuario user, string password)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_User", user.ID),
                    new SPParameter("Password", password)
                };
            var sp = new StoreProcedure(DataBaseConst.Usuario.SPUpdatePassword, param);

            sp.ExecuteNonQuery(null);
        }

        public static void Update(Usuario user)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_User", user.ID),
                    new SPParameter("Intentos_Fallidos", user.LoginFails),
                    new SPParameter("Activo", user.Activo)
                };
            var sp = new StoreProcedure(DataBaseConst.Usuario.SPUpdateUser, param);

            sp.ExecuteNonQuery(null);
        }

        public static Usuario GetById(string idUser)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Usuario", idUser) };
            var sp = new StoreProcedure(DataBaseConst.Usuario.SPGetUserById, param);

            var users = sp.ExecuteReader<Usuario>();

            if (users == null || users.Count == 0)
                return null;

            return users[0];
        }
    }
}
