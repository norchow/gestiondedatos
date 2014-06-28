using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using Filters;
using System.Data.SqlClient;

namespace Persistance
{
    public static class VisibilidadPersistance
    {
        public static List<Visibilidad> GetAll()
        {
            //Obtengo la lista de visibilidades que se encuentran almacenadas en la base de datos
            var sp = new StoreProcedure(DataBaseConst.Visibilidad.SPGetAllVisibilidad);
            return sp.ExecuteReader<Visibilidad>();
        }

        public static List<Visibilidad> GetAllActive()
        {
            //Obtengo la lista de visibilidades que se encuentren activas
            var sp = new StoreProcedure(DataBaseConst.Visibilidad.SPGetAllVisibilidadActive);
            return sp.ExecuteReader<Visibilidad>();
        }

        public static Visibilidad GetById(int id)
        {
            //Obtengo la visibilidad que cumplen ciertos filtros (busqueda exacta)
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
            //Obtengo la lista de visibilidades que cumplen ciertos filtros (busqueda exacta)
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
            //Obtengo la lista de visibilidades que cumplen ciertos filtros (busqueda inexacta)
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

        public static Dictionary<int, int> GetAllByUser(Usuario usuario, SqlTransaction transaction)
        {
            var dictionary = new Dictionary<int, int>();
            var param = new List<SPParameter>
                { 
                    new SPParameter("ID_Usuario", usuario.ID)
                };

            var sp = new StoreProcedure(DataBaseConst.Visibilidad.SPGetVisibilidadPurchasesByUser, param, transaction);
            var reader = sp.ExecuteReader(transaction);

            while (reader.Read())
                dictionary.Add(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]));

            if (!reader.IsClosed)
                reader.Close();

            return dictionary;
        }

        public static bool InsertVisibilidadesRendidasPorUsuario(Dictionary<int, int> visibilidadesPorUsuario, int idUsuario, SqlTransaction transaction)
        {
            var regsAfectados = 0;
            foreach (var visibilidadUsuario in visibilidadesPorUsuario)
	        {
                if (ExisteVisibilidadRendidaPorUsuario(visibilidadUsuario, idUsuario, transaction))
                    regsAfectados += UpdateVisibilidadRendidaPorUsuario(visibilidadUsuario, idUsuario, transaction);
                else
                    regsAfectados += InsertVisibilidadRendidaPorUsuario(visibilidadUsuario, idUsuario, transaction);
	        }
            
            return regsAfectados == visibilidadesPorUsuario.Count;
        }

        private static bool ExisteVisibilidadRendidaPorUsuario(KeyValuePair<int, int> visibilidadUsuario, int idUsuario, SqlTransaction transaction)
        {
            var existe = false;
            var param = new List<SPParameter>
                { 
                    new SPParameter("ID_Usuario", idUsuario),
                    new SPParameter("ID_Visibilidad", visibilidadUsuario.Key)
                };

            var sp = new StoreProcedure(DataBaseConst.Visibilidad.SPGetVisibilidadPurchasesByUserAndID, param, transaction);
            var reader = sp.ExecuteReader(transaction);

            while (reader.Read())
                existe = true;

            if (!reader.IsClosed)
                reader.Close();

            return existe;
        }

        private static int InsertVisibilidadRendidaPorUsuario(KeyValuePair<int, int> visibilidadUsuario, int idUsuario, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                { 
                    new SPParameter("ID_Usuario", idUsuario),
                    new SPParameter("ID_Visibilidad", visibilidadUsuario.Key),
                    new SPParameter("Cantidad_Compras", visibilidadUsuario.Value)
                };

            var sp = new StoreProcedure(DataBaseConst.Visibilidad.SPInsertVisibilidadPurchases, param, transaction);

            return sp.ExecuteNonQuery(transaction);
        }

        private static int UpdateVisibilidadRendidaPorUsuario(KeyValuePair<int, int> visibilidadUsuario, int idUsuario, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                { 
                    new SPParameter("ID_Usuario", idUsuario),
                    new SPParameter("ID_Visibilidad", visibilidadUsuario.Key),
                    new SPParameter("Cantidad_Compras", visibilidadUsuario.Value)
                };

            var sp = new StoreProcedure(DataBaseConst.Visibilidad.SPUpdateVisibilidadPurchases, param, transaction);

            return sp.ExecuteNonQuery(transaction);
        }
    }
}
