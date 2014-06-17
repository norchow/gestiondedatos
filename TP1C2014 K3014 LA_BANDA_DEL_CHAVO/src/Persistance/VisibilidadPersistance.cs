using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using Filters;

namespace Persistance
{
    public static class VisibilidadPersistance
    {
        public static List<Visibilidad> GetAll()
        {
            var sp = new StoreProcedure(DataBaseConst.Visibilidad.SPGetAllVisibilidad);
            return sp.ExecuteReader<Visibilidad>();
        }

        public static List<Visibilidad> GetAllActive()
        {
            var sp = new StoreProcedure(DataBaseConst.Visibilidad.SPGetAllVisibilidadActive);
            return sp.ExecuteReader<Visibilidad>();
        }

        public static Visibilidad GetById(int id)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Visibilidad", id)
                };

            var sp = new StoreProcedure(DataBaseConst.Visibilidad.SPGetVisibilidadById, param);

            var visibilities = sp.ExecuteReader<Visibilidad>();

            if (visibilities == null || visibilities.Count == 0)
                return null;

            return visibilities[0];
        }

        public static List<Visibilidad> GetAllByParameters(VisibilidadFilters filters)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Descripcion", filters.Descripcion ?? (object)DBNull.Value),
                    new SPParameter("Precio_Publicar", filters.PrecioPublicar ?? (object)DBNull.Value),
                    new SPParameter("Porcentaje_Venta", filters.PorcentajeVenta ?? (object)DBNull.Value),
                    new SPParameter("Duracion", filters.Duracion ?? (object)DBNull.Value)
                };

            var sp = new StoreProcedure(DataBaseConst.Visibilidad.SPGetAllVisibilidadByParameters, param);

            return sp.ExecuteReader<Visibilidad>();
        }

        public static List<Visibilidad> GetAllByParametersLike(VisibilidadFilters filters)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("Descripcion", filters.Descripcion ?? (object)DBNull.Value)
                };

            var sp = new StoreProcedure(DataBaseConst.Visibilidad.SPGetAllVisibilidadByParametersLike, param);

            return sp.ExecuteReader<Visibilidad>();
        }

        public static int Insert(Visibilidad visibility)
        {
            var param = new List<SPParameter>
                { 
                    new SPParameter("Descripcion", visibility.Descripcion),
                    new SPParameter("Precio_Publicar", visibility.PrecioPublicar),
                    new SPParameter("Porcentaje_Venta", visibility.PorcentajeVenta),
                    new SPParameter("Duracion", visibility.Duracion),
                    new SPParameter("Activo", visibility.Activo),
                };

            var sp = new StoreProcedure(DataBaseConst.Visibilidad.SPInsertVisibilidad, param);

            return sp.ExecuteNonQuery(null);
        }

        public static int Update(Visibilidad visibility)
        {
            var param = new List<SPParameter>
                { 
                    new SPParameter("ID_Visibilidad", visibility.ID),
                    new SPParameter("Descripcion", visibility.Descripcion),
                    new SPParameter("Precio_Publicar", visibility.PrecioPublicar),
                    new SPParameter("Porcentaje_Venta", visibility.PorcentajeVenta),
                    new SPParameter("Duracion", visibility.Duracion),
                    new SPParameter("Activo", visibility.Activo),
                };

            var sp = new StoreProcedure(DataBaseConst.Visibilidad.SPUpdateVisibilidad, param);

            return sp.ExecuteNonQuery(null);
        }
    }
}
