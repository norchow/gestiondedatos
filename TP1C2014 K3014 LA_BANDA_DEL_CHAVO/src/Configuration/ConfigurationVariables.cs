using System.Configuration;

namespace Configuration
{
    public static class ConfigurationVariables
    {
        public static string ConnectionString { get; set; }

        private static bool _iniciado;

        public static void Iniciar()
        {
            if (!_iniciado)
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

                _iniciado = true;
            }
        }
    }
}
