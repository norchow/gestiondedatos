using System;
using System.Data;
using System.Data.SqlClient;
using Configuration;

namespace Persistance.Entities
{
    public class DataBaseManager
    {
        private SqlConnection _connection;

        public SqlConnection Connection
        {
            get
            {
                if (_connection.State != ConnectionState.Open)
                    OpenConnection();

                return _connection;
            }
        }

        /*
         * Constructor private -> Singleton.
         * Se instancia solo una vez, para mantener siempre la misma conexion a la DB.
         */
        private DataBaseManager()
        {
            OpenConnection();
        }

        private void OpenConnection()
        {
            try
            {
                //Abro la conexion
                _connection = new SqlConnection(ConfigurationVariables.ConnectionString);
                _connection.Open();
            }
            catch
            {
                throw new Exception("Error iniciando la conexion con la base de datos.");
            }
        }

        private static DataBaseManager _dataBaseManager;

        public static DataBaseManager Instance()
        {
            return _dataBaseManager ?? (_dataBaseManager = new DataBaseManager());
        }

        public void CloseConnection()
        {
            _connection.Close();
        }
    }
}
