using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;

namespace Persistance
{
    public static class CalificacionesPersistance
    {
        public static List<PublicacionNotCalified> GetAllPubicacionNotCalified(Usuario user)
        {
            var param = new List<SPParameter> { new SPParameter("idUsuario", user.ID) };
            var sp = new StoreProcedure(DataBaseConst.Publicacion.SPGetNotCalifiedByClientId, param);
            return sp.ExecuteReader<PublicacionNotCalified>();
        }
    }
}
