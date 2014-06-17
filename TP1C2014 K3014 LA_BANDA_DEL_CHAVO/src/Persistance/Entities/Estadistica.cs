using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Persistance.Entities;

namespace Persistance.Entities
{
    public class Estadistica : IMapable
    {
        public string Usuario { get; set; }
        public double Valor { get; set; }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Estadistica
            {
                Usuario = ((String)reader["Usuario"]).Trim(),
                Valor = double.Parse(reader["Valor"].ToString())
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }


    }


}
