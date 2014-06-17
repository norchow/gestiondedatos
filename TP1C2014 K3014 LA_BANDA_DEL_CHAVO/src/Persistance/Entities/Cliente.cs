using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public class Cliente : IMapable
    {
        public int ID { get; set; }
        public int IdUsuario { get; set; }
        public String Nombre { get; set; }
        public String Apellido { get; set; }
        public int TipoDocumento { get; set; }
        public int NroDocumento { get; set; }
        public String Mail { get; set; }
        public String Telefono { get; set; }
        public String Direccion { get; set; }
        public String CodigoPostal { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public String CUIL { get; set; }

        public Boolean Habilitado { get; set; }

        //Implement of IMapable
        public IMapable Map(SqlDataReader reader)
        {
            return new Cliente
            {
                ID = Int32.Parse(reader["ID_Cliente"].ToString()),
                IdUsuario = Int32.Parse(reader["ID_Usuario"].ToString()),
                Nombre = ((String)reader["Nombre"]).Trim(),
                Apellido = ((String)reader["Apellido"]).Trim(),
                TipoDocumento = Int32.Parse(reader["ID_Tipo_Documento"].ToString()),
                NroDocumento = Int32.Parse(reader["Nro_Documento"].ToString()),
                Mail = ((String)reader["Mail"]).Trim(),
                Telefono = (!(reader["Telefono"] is DBNull)) ? ((String)reader["Telefono"]).Trim() : "",
                Direccion = ((String)reader["Direccion"]).Trim(),
                CodigoPostal = ((String)reader["Codigo_Postal"]).Trim(),
                FechaNacimiento = DateTime.Parse(reader["Fecha_nacimiento"].ToString()),
                CUIL = (!(reader["CUIL"] is DBNull)) ? ((String)reader["CUIL"]).Trim() : "",
                Habilitado = Boolean.Parse(reader["Habilitado"].ToString())
            };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }
}
