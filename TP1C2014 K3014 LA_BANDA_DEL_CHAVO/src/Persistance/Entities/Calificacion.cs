using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Persistance.Entities;

namespace Persistance.Entities
{
    public class Calificacion : IMapable
    {
        public int ID { get; set; }
        public int ID_Publicacion { get; set; }
        public int ID_Comprador { get; set; }
        private int _stars;
        public string description { get; set; }

        public int stars
        {
            get {return _stars ;}
            set {
                if ((value < 6) && (value > 0))
                {
                    _stars = value;
                }
                }

        }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Calificacion
            {
                ID = Int32.Parse(reader["Codigo_Calificacion"].ToString()),
                ID_Publicacion = Int32.Parse(reader["ID_Publicacion"].ToString()),
                ID_Comprador = Int32.Parse(reader["ID_Comprador"].ToString()),
                _stars = Int32.Parse(reader["Cantidad_Estrellas"].ToString()),
                description = ((String)reader["Descripcion"]).Trim()

            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }


    }


}
