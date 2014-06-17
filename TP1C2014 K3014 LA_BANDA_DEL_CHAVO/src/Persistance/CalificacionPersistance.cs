using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using Filters;
using Configuration;

namespace Persistance
{
    public static class CalificacionPersistance
    {
        public static List<PublicacionNotCalified> GetAllPubicacionNotCalified(Usuario user)
        {
            var param = new List<SPParameter> { new SPParameter("idUsuario", user.ID),
                                               new SPParameter("Fecha_hoy", ConfigurationVariables.FechaSistema)};
            var sp = new StoreProcedure(DataBaseConst.Calificacion.SPGetNotCalifiedByClientId, param);
            return sp.ExecuteReader<PublicacionNotCalified>();
        }


        public static List<PublicacionNotCalified> GetAllPubicacionNotCalifiedByParameters(PublicacionNotCalifiedFilters filters, Usuario user)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("idUsuario", user.ID),
                     new SPParameter("Fecha_hoy", ConfigurationVariables.FechaSistema),
                    new SPParameter("CodigoPublicacion", filters.Codigo ?? (object)DBNull.Value),
                    new SPParameter("Descripcion", filters.Descripcion ?? (object)DBNull.Value),
                    new SPParameter("Precio", filters.Precio ?? (object)DBNull.Value)
                };

            var sp = new StoreProcedure(DataBaseConst.Calificacion.SPGetNotCalifiedByClientIdByParameters, param);

            return sp.ExecuteReader<PublicacionNotCalified>();
        }

        public static List<PublicacionNotCalified> GetAllPubicacionNotCalifiedByParametersLike(PublicacionNotCalifiedFilters filters, Usuario user)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("idUsuario", user.ID),
                     new SPParameter("Fecha_hoy", ConfigurationVariables.FechaSistema),
                    new SPParameter("CodigoPublicacion", filters.Codigo ?? (object)DBNull.Value),
                    new SPParameter("Descripcion", filters.Descripcion ?? (object)DBNull.Value),
                    new SPParameter("Precio", filters.Precio ?? (object)DBNull.Value)
                };

            var sp = new StoreProcedure(DataBaseConst.Calificacion.SPGetNotCalifiedByClientIdByParametersLike, param);

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

        public static List<HistoryReputacion> getAllCalifiedToMe(Usuario user)
        {
            var param = new List<SPParameter> { new SPParameter("idUsuario", user.ID) };
            var sp = new StoreProcedure(DataBaseConst.Calificacion.SPGetHistoryCalificacionesRecibidas, param);
            return sp.ExecuteReader<HistoryReputacion>();
        }
        

        public static List<HistoryReputacion> getAllCalifiedToMeByParameters(Usuario user, HistoryReputacionFilters filters)
        {
            var param = new List<SPParameter> { new SPParameter("idUsuario", user.ID),
                    new SPParameter("Codigo_Calificacion", filters.Codigo ?? (object)DBNull.Value),
                    new SPParameter("Descripcion", filters.Descripcion ?? (object)DBNull.Value),
                    new SPParameter("Cantidad_Estrellas", filters.Cantidad ?? (object)DBNull.Value),
                    new SPParameter("Nombre", filters.Nombre ?? (object)DBNull.Value)
            
            };
            var sp = new StoreProcedure(DataBaseConst.Calificacion.SPGetHistoryCalificacionesRecibidasByParameters, param);
            return sp.ExecuteReader<HistoryReputacion>();
        }

        public static List<HistoryReputacion> getAllCalifiedToMeByParametersLike(Usuario user, HistoryReputacionFilters filters)
        {
            var param = new List<SPParameter> { new SPParameter("idUsuario", user.ID),
                    new SPParameter("Codigo_Calificacion", filters.Codigo ?? (object)DBNull.Value),
                    new SPParameter("Descripcion", filters.Descripcion ?? (object)DBNull.Value),
                    new SPParameter("Cantidad_Estrellas", filters.Cantidad ?? (object)DBNull.Value),
                    new SPParameter("Nombre", filters.Nombre ?? (object)DBNull.Value)
            
            };
            var sp = new StoreProcedure(DataBaseConst.Calificacion.SPGetHistoryCalificacionesRecibidasByParametersLike, param);
            return sp.ExecuteReader<HistoryReputacion>();
        }
        

        public static List<HistoryReputacion> getAllCalifiedByMeToOther(Usuario user)
        {
            var param = new List<SPParameter> { new SPParameter("idUsuario", user.ID) };
            var sp = new StoreProcedure(DataBaseConst.Calificacion.SPGetHistoryCalificacionesOtorgadas, param);
            return sp.ExecuteReader<HistoryReputacion>();
        }


        public static List<HistoryReputacion> getAllCalifiedByMeToOtherByParameters(Usuario user, HistoryReputacionFilters filters)
        {
            var param = new List<SPParameter> { new SPParameter("idUsuario", user.ID),
                    new SPParameter("Codigo_Calificacion", filters.Codigo ?? (object)DBNull.Value),
                    new SPParameter("Descripcion", filters.Descripcion ?? (object)DBNull.Value),
                    new SPParameter("Cantidad_Estrellas", filters.Cantidad ?? (object)DBNull.Value),
                    new SPParameter("Nombre", filters.Nombre ?? (object)DBNull.Value)
            
            };
            var sp = new StoreProcedure(DataBaseConst.Calificacion.SPGetHistoryCalificacionesOtorgadasByParameters, param);
            return sp.ExecuteReader<HistoryReputacion>();
        }

        public static List<HistoryReputacion> getAllCalifiedByMeToOtherByParametersLike(Usuario user, HistoryReputacionFilters filters)
        {
            var param = new List<SPParameter> { new SPParameter("idUsuario", user.ID),
                    new SPParameter("Codigo_Calificacion", filters.Codigo ?? (object)DBNull.Value),
                    new SPParameter("Descripcion", filters.Descripcion ?? (object)DBNull.Value),
                    new SPParameter("Cantidad_Estrellas", filters.Cantidad ?? (object)DBNull.Value),
                    new SPParameter("Nombre", filters.Nombre ?? (object)DBNull.Value)
            
            };
            var sp = new StoreProcedure(DataBaseConst.Calificacion.SPGetHistoryCalificacionesOtorgadasByParametersLike, param);
            return sp.ExecuteReader<HistoryReputacion>();
        }


        public static int getAverageCalificationToMe(Usuario user)
        {
            int promedio = 0;
            List<HistoryReputacion> calificaciones = getAllCalifiedToMe(user);
            int cantidad = calificaciones.Count;
            if (calificaciones != null && cantidad > 0)
            {
                int suma = 0;
                foreach (var calif in calificaciones)
                {
                    suma += calif.Cantidad_Estrellas;
                }
                promedio = (int)Math.Round((decimal)suma / cantidad);
            }
            return promedio;
        }

        public static object GetByUserId(Usuario usuario)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Usuario", usuario.ID)
                };

            var sp = new StoreProcedure(DataBaseConst.Calificacion.SPGetCalificationByUserId, param);

            Double calification = 0.0;
            var reader = sp.ExecuteReader(null);
            while (reader.Read())
                calification = Convert.ToDouble(reader[0]);

            if (!reader.IsClosed)
                reader.Close();

            return calification;
        }
    }



}
