using System;
using Persistance.Entities;

namespace Session
{
    public static class SessionManager
    {
        //Usuario logueado
        public static Usuario CurrentUser { get; set; }

        //Rol con el que decidio loguearse (en caso que posea mas de uno). Sino es el unico que tiene
        public static Rol CurrentRol { get; set; }

        //Fecha de acceso del usuario
        public static DateTime CurrentLoginDate { get; set; }

        public static void ClearCurrentSession()
        {
            //Borro los datos del ultimo acceso
            SessionManager.CurrentRol = null;
            SessionManager.CurrentUser = null;
            SessionManager.CurrentLoginDate = new DateTime();
        }
    }
}
