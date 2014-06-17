using System.Collections.Generic;
using Persistance.Entities;
using System.Data.SqlClient;
using System.Data;
using System;
using Tools;

namespace Persistance
{
    public static class UsuarioPersistance
    {
        public static List<Usuario> GetAll()
        {
            //Traigo todos los usuarios almacenados en la base de datos
            var sp = new StoreProcedure(DataBaseConst.Usuario.SPGetAllUsuario);
            return sp.ExecuteReader<Usuario>();
        }

        public static Usuario GetByUsername(string userName)
        {
            //Traigo el usuario cuyo nombre de usuario coincida con el del parametro
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

        public static void UpdateToDisabledById(int userID)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_User", userID)
                };
            var sp = new StoreProcedure(DataBaseConst.Usuario.SPUpdateUserToDisabledById, param);

            sp.ExecuteNonQuery(null);
        }

        public static void UpdateToActivateById(int userID)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_User", userID)
                };
            var sp = new StoreProcedure(DataBaseConst.Usuario.SPUpdateUserToActivateById, param);

            sp.ExecuteNonQuery(null);
        }

        public static Usuario GetById(int idUser)
        {
            //Traigo el usuario cuyo id coincida con el del parametro
            var param = new List<SPParameter> { new SPParameter("ID_Usuario", idUser) };
            var sp = new StoreProcedure(DataBaseConst.Usuario.SPGetUserById, param);

            var users = sp.ExecuteReader<Usuario>();

            if (users == null || users.Count == 0)
                return null;

            return users[0];
        }

        public static Usuario InsertUser(Usuario user, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Username", user.Username), 
                    new SPParameter("Password", user.Password)
                };

            var sp = (transaction != null)
                        ? new StoreProcedure(DataBaseConst.Usuario.SPInsertUser, param, transaction)
                        : new StoreProcedure(DataBaseConst.Usuario.SPInsertUser, param);

            user.ID = (int)sp.ExecuteScalar(transaction);
            
            return user;
        }

        public static Usuario InsertUserTemporal(Usuario user, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Username", user.Username), 
                    new SPParameter("Password", user.Password)
                };

            var sp = (transaction != null)
                        ? new StoreProcedure(DataBaseConst.Usuario.SPInsertUserTemporal, param, transaction)
                        : new StoreProcedure(DataBaseConst.Usuario.SPInsertUserTemporal, param);

            user.ID = (int)sp.ExecuteScalar(transaction);

            return user;
        }

        public static void InhabilitarUser(Usuario user)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_User", user.ID)
                };
            var sp = new StoreProcedure(DataBaseConst.Usuario.SPInhabilitarUser, param);

            sp.ExecuteNonQuery(null);
        }

        public static Usuario Login(string userName, string password)
        {
            //Traigo el usuario cuyo nombre de usuario y contraseña coincidan con los parametros
            var usuario = GetByUsername(userName);

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
