using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public class Empresa : IMapable
    {
        public int ID { get; set; }
        public int IdUsuario { get; set; }
        public String RazonSocial { get; set; }
        public String Mail { get; set; }
        public String Telefono { get; set; }
        public String Direccion { get; set; }
        public String CodigoPostal { get; set; }
        public String Ciudad { get; set; }
        public String CUIT { get; set; }
        public String NombreContacto { get; set; }
        public DateTime FechaCreacion { get; set; }

        public Boolean Habilitado { get; set; }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Empresa
            {
                ID = Int32.Parse(reader["ID_Empresa"].ToString()),
                IdUsuario = Int32.Parse(reader["ID_Usuario"].ToString()),
                RazonSocial = ((String)reader["Razon_Social"]).Trim(),
                Mail = ((String)reader["Mail"]).Trim(),
                Telefono = (!(reader["Telefono"] is DBNull)) ? ((String)reader["Telefono"]).Trim() : "",
                Direccion = ((String)reader["Direccion"]).Trim(),
                CodigoPostal = ((String)reader["Codigo_Postal"]).Trim(),
                Ciudad = (!(reader["Ciudad"] is DBNull)) ? ((String)reader["Ciudad"]).Trim() : "",
                CUIT = ((String)reader["CUIT"]).Trim(),
                NombreContacto = (!(reader["Nombre_Contacto"] is DBNull)) ? ((String)reader["Nombre_Contacto"]).Trim() : "",
                FechaCreacion = DateTime.Parse(reader["Fecha_Creacion"].ToString()),
                Habilitado = Boolean.Parse(reader["Habilitado"].ToString())
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
