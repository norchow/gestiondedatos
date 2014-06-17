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

        public static Funcionalidades? GetByName(string func)
        {
            if (func == "ABM de Rol") return Funcionalidades.ABM_Rol;
            if (func == "ABM de Cliente (Comprador/Vendedor)") return Funcionalidades.ABM_Cliente;
            if (func == "ABM de Empresa (Vendedor)") return Funcionalidades.ABM_Empresa;
            if (func == "ABM de Usuarios") return Funcionalidades.ABM_Usuario;
            if (func == "ABM de Visibilidad de Publicacion") return Funcionalidades.ABM_Visibilidad;
            if (func == "Generar Publicacion") return Funcionalidades.Generar_Publicacion;
            if (func == "Editar Publicacion") return Funcionalidades.Editar_Publicacion;
            if (func == "Gestion de Preguntas") return Funcionalidades.Gestion_Preguntas;
            if (func == "Comprar/Ofertar") return Funcionalidades.Comprar_Ofertar;
            if (func == "Historial del Cliente") return Funcionalidades.Historial_Cliente;
            if (func == "Calificar al Vendedor") return Funcionalidades.Calificar_Vendedor;
            if (func == "Facturar Publicaciones") return Funcionalidades.Facturar_Publicaciones;
            if (func == "Listado Estadistico") return Funcionalidades.Listado_Estadistico;

            return null;
        }
    }

    public enum Funcionalidades
    {
        ABM_Rol,
        ABM_Cliente,
        ABM_Empresa,
        ABM_Usuario,
        ABM_Visibilidad,
        Generar_Publicacion,
        Editar_Publicacion,
        Gestion_Preguntas,
        Comprar_Ofertar,
        Historial_Cliente,
        Calificar_Vendedor,
        Facturar_Publicaciones,
        Listado_Estadistico
    }
}
