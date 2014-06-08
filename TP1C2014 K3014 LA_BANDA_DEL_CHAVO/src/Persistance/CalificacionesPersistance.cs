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

        public static int InsertCalification(Calificacion calif)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Publicacion", calif.ID_Publicacion),
                                                new SPParameter("ID_Comprador", calif.ID_Comprador),                                         
                                                new SPParameter("Cantidad_Estrellas", calif.stars),
                                                new SPParameter("Descripcion", calif.description)};
            var sp = new StoreProcedure(DataBaseConst.Calificacion.SPInsertCalificacion, param);
            return sp.ExecuteNonQuery(null);
        }

    }



}
