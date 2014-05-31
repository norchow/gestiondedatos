using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public class TipoPublicacion : IMapable
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new TipoPublicacion
            {
                ID = Int32.Parse(reader["ID_Tipo_Publicacion"].ToString()),
                Descripcion = ((String)reader["Descripcion"]).Trim()
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}