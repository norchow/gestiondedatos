using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;

namespace Persistance
{
    public static class TipoPublicacionPersistance
    {
        public static List<TipoPublicacion> GetAll()
        {
            var sp = new StoreProcedure(DataBaseConst.TipoPublicacion.SPGetAllTipoPublicacion);
            return sp.ExecuteReader<TipoPublicacion>();
        }

        public static TipoPublicacion GetById(int publicationTypeId)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Tipo_Publicacion", publicationTypeId) };
            var sp = new StoreProcedure(DataBaseConst.TipoPublicacion.SPGetAllTipoPublicacionById, param);

            var typesPublication = sp.ExecuteReader<TipoPublicacion>();

            if (typesPublication == null || typesPublication.Count == 0)
                return null;

            return typesPublication[0];
        }
    }
}
