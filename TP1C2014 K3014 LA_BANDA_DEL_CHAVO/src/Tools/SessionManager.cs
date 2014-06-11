using System;
using Persistance.Entities;

namespace Session
{
    public static class SessionManager
    {
        public static Usuario CurrentUser { get; set; }

        public static Rol CurrentRol { get; set; }

        public static DateTime CurrentLoginDate { get; set; }
    }
}
