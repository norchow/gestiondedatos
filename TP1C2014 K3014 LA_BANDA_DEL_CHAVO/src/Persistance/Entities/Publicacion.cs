﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Globalization;

namespace Persistance.Entities
{
    public class Publicacion : IMapable
    {
        public int ID { get; set; }

        public string Descripcion { get; set; }

        public int Stock { get; set; }

        public double Precio { get; set; }

        public Usuario UsuarioCreador { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public Visibilidad Visibilidad { get; set; }

        public TipoPublicacion TipoPublicacion { get; set; }

        public EstadoPublicacion EstadoPublicacion { get; set; }

        public List<Rubro> Rubros { get; set; }

        public bool RecibirPreguntas { get; set; }

        private string _usuarioCreador;

        private int _visibilidad;

        private int _estadoPublicacion;

        private int _tipoPublicacion;

        public Publicacion()
        {
            Rubros = new List<Rubro>();
        }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Publicacion
            {
                ID = Int32.Parse(reader["ID_Publicacion"].ToString()),
                Descripcion = ((String)reader["Descripcion"]).Trim(),
                Stock = Int32.Parse(reader["Stock"].ToString()),
                Precio = double.Parse(reader["Precio"].ToString()),
                _usuarioCreador = reader["ID_Usuario"].ToString(),
                _visibilidad = Convert.ToInt32(reader["ID_Visibilidad"].ToString()),
                _estadoPublicacion = Convert.ToInt32(reader["ID_Estado_Publicacion"].ToString()),
                _tipoPublicacion = Int32.Parse(reader["ID_Tipo_Publicacion"].ToString()),
                RecibirPreguntas = bool.Parse(reader["Permitir_Preguntas"].ToString()),
                FechaInicio = DateTime.Today,
                FechaVencimiento = DateTime.Today
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }

        internal void GetObjectsById()
        {
            UsuarioCreador = UsuarioPersistance.GetUserById(_usuarioCreador);
            Visibilidad = VisibilidadPersistance.GetVisibilityById(_visibilidad);
            EstadoPublicacion = EstadoPublicacionPersistance.GetPublicationStatusById(_estadoPublicacion);
            TipoPublicacion = TipoPublicacionPersistance.GetPublicationTypeById(_tipoPublicacion);
            Rubros = RubroPersistance.GetByPublicationId(ID);
        }
    }
}