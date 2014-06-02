using System;
using System.Linq;
using Persistance.Entities;
using Persistance;
using Tools;

namespace Logic
{
    public class UsuarioLogic
    {
        public Usuario Login(string userName, string password)
        {
            var usuario = UsuarioPersistance.GetByUsername(userName);

            if (usuario == null)
                throw new Exception("El nombre de usuario ingresado no existe.");

            if (!usuario.Activo)
                throw new Exception("El usuario ingresado no se encuentra habilitado para operar el sistema.");

            if (usuario.Password != SHA256Helper.Encode(password))
            {
                usuario.LoginFails += 1;
                usuario.Activo = usuario.LoginFails < 3;
                UsuarioPersistance.Update(usuario);

                throw new Exception("La contraseña ingresada no es valida.");
            }

            if (usuario.RolesActivos.Count == 0)
                throw new Exception("No cuenta con un rol habilitado, por lo que no puede ingresar al sistema.");

            usuario.LoginFails = 0;
            UsuarioPersistance.Update(usuario);

            return usuario;
        }
    }
}
