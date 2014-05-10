using System.Collections.Generic;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public class Funcionalidad : IMapable
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }

        public IMapable Map(SqlDataReader reader)
        {
            return new Funcionalidad
                {
                    ID = int.Parse(reader["ID_Funcionalidad"].ToString()),
                    Descripcion = reader["Descripcion"].ToString()
                };
        }

        public List<SPParameter> UnMap(IMapable entity)
        {
            return new List<SPParameter>();
        }
    }

    public enum Funcionalidades
    {
        ABM_Rol,
        ABM_Afiliado,
        ABM_Profesional,
        Registro_Agenda,
        Compra_Bono,
        Pedido_Turno,
        Registro_Llegada,
        Registro_Resultado,
        Cancelacion_Atencion,
        Emision_Receta,
        Estadisticas
    }
}
