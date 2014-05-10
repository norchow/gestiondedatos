using System;
using System.Linq;
using Persistance.Entities;
using Persistance;
using Tools;

namespace Logic
{
    public class UsuarioLogic
    {
        private readonly UsuarioPersistance _persistance;

        public UsuarioLogic()
        {
            _persistance = new UsuarioPersistance();
        }

        public Usuario Login(string userName, string password)
        {
            var usuario = _persistance.GetUserByUsername(userName);

            if (usuario == null)
                throw new Exception("El nombre de usuario ingresado no existe.");

            if (!usuario.Activo)
                throw new Exception("El usuario ingresado no se encuentra habilitado para operar el sistema.");

            if (usuario.Password != SHA256Helper.Encode(password))
            {
                usuario.LoginFails += 1;
                usuario.Activo = usuario.LoginFails < 3;
                _persistance.Update(usuario);

                throw new Exception("La contraseña ingresada no es valida.");
            }

            if (usuario.RolesActivos.Count == 0)
                throw new Exception("No cuenta con un rol habilitado, por lo que no puede ingresar al sistema.");

            usuario.LoginFails = 0;
            _persistance.Update(usuario);

            return usuario;
        }
    }
}
