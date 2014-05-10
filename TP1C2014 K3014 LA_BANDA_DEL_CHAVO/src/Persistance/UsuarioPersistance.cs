using System.Collections.Generic;
using Persistance.Entities;

namespace Persistance
{
    public class UsuarioPersistance
    {
        public Usuario GetUserByUsername(string userName)
        {
            var param = new List<SPParameter> { new SPParameter("Username", userName) };
            var sp = new StoreProcedure(DataBaseConst.Usuario.SPGetUserByUsername, param);

            var usuarios = sp.ExecuteReader<Usuario>();

            if (usuarios == null || usuarios.Count == 0)
                return null;

            return usuarios[0];
        }

        public void ChangePassword(Usuario usuario, string password)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_User", usuario.ID),
                    new SPParameter("Password", password)
                };
            var sp = new StoreProcedure(DataBaseConst.Usuario.SPUpdatePassword, param);

            sp.ExecuteNonQuery();
        }

        public void Update(Usuario user)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_User", user.ID),
                    new SPParameter("Intentos_Fallidos", user.LoginFails),
                    new SPParameter("Activo", user.Activo)
                };
            var sp = new StoreProcedure(DataBaseConst.Usuario.SPUpdateUser, param);

            sp.ExecuteNonQuery();
        }
    }
}
