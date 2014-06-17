using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;

namespace Persistance
{
    public static class EstadoPublicacionPersistance
    {
        public static List<EstadoPublicacion> GetAll()
        {
            //Obtengo todos los estados de publicacion almacenadas en la base de datos
            var sp = new StoreProcedure(DataBaseConst.EstadoPublicacion.SPGetAllEstadoPublicacion);
            return sp.ExecuteReader<EstadoPublicacion>();
        }

        public static EstadoPublicacion GetById(int idStatusPublication)
        {
            //Obtengo el estado de publicacion cuyo id es igual al del parametro
            var param = new List<SPParameter> { new SPParameter("ID_Estado_Publicacion", idStatusPublication) };
            var sp = new StoreProcedure(DataBaseConst.EstadoPublicacion.SPGetAllEstadoPublicacionById, param);

            var statusPublication = sp.ExecuteReader<EstadoPublicacion>();

            if (statusPublication == null || statusPublication.Count == 0)
                return null;

            return statusPublication[0];
        }
    }
}

