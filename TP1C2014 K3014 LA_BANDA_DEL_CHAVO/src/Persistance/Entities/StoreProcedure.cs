using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public class StoreProcedure
    {
        #region Fields

        public string Name { get; set; }

        public Dictionary<string, SPParameter> Parameters { get; private set; }

        public SqlTransaction Transaction { get; private set; }

        private DataBaseManager _dataBaseManager;

        #endregion

        public StoreProcedure()
        {
            Initialize(String.Empty, null, null);
        }

        public StoreProcedure(String spName)
        {
            Initialize(spName, null, null);
        }

        public StoreProcedure(String spName, List<SPParameter> spParameters)
        {
            Initialize(spName, spParameters, null);
        }

        public StoreProcedure(String spName, List<SPParameter> spParameters, SqlTransaction spTransaction)
        {
            Initialize(spName, spParameters, spTransaction);
        }

        private void Initialize(String spName, List<SPParameter> spParameters, SqlTransaction spTransaction)
        {
            // Seteo el nombre
            Name = String.IsNullOrEmpty(spName) ? String.Empty : spName;

            // Seteo los parametros
            if (spParameters == null || spParameters.Count == 0)
                Parameters = new Dictionary<String, SPParameter>(0);
            else
            {
                try
                {
                    Parameters = spParameters.ToDictionary(p => p.Name, p => p);
                }
                catch (Exception)
                {
                    throw new Exception("There are parameters with the same name.");
                }
            }

            // Seteo la transaccion
            Transaction = spTransaction;

            // Seteo la conexion
            _dataBaseManager = DataBaseManager.Instance();
        }

        public bool HasParameters
        {
            get { return Parameters.Count > 0; }
        }

        public bool HasTransaction
        {
            get { return Transaction != null; }
        }

        public int ExecuteNonQuery(SqlTransaction transaction)
        {
            var conn = _dataBaseManager.Connection;

            try
            {
                var cmd = new SqlCommand(Name, conn) { CommandType = CommandType.StoredProcedure };

                foreach (var parameter in Parameters.Values)
                    cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);

                if (transaction != null)
                    cmd.Transaction = transaction;

                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*
         * ExecuteReader(): Retorna el SqlDataReader
         * Hay que cerrarlo posteriormente.
         */
        public SqlDataReader ExecuteReader(SqlTransaction transaction)
        {
            var conn = _dataBaseManager.Connection;

            try
            {
                var cmd = new SqlCommand(Name, conn) {CommandType = CommandType.StoredProcedure};

                foreach (var parameter in Parameters.Values)
                    cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);

                if (transaction != null)
                    cmd.Transaction = transaction;

                // No se cierra
                return cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*
         * ExecuteReader<T>(): Retorna los objetos mapeados
         */
        public List<T> ExecuteReader<T>() where T : IMapable, new()
        {
            try
            {
                // Ejecuto la SP y obtengo el SqlDataReader
                var reader = ExecuteReader(null);

                // Mapeo los objetos
                var map = new List<T>();

                while (!reader.IsClosed && reader.Read())
                {
                    var mapable = new T();
                    map.Add((T)mapable.Map(reader));
                }

                // Cierro el datareader
                if (!reader.IsClosed)
                    reader.Close();

                return map;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*
        * ExecuteReader<T>(): Retorna los objetos mapeados
        */
        public List<T> ExecuteReaderTransactioned<T>(SqlTransaction transaction) where T : IMapable, new()
        {
            try
            {
                // Ejecuto la SP y obtengo el SqlDataReader
                var reader = ExecuteReader(transaction);

                // Mapeo los objetos
                var map = new List<T>();

                while (!reader.IsClosed && reader.Read())
                {
                    var mapable = new T();
                    map.Add((T)mapable.Map(reader));
                }

                // Cierro el datareader
                if (!reader.IsClosed)
                    reader.Close();

                return map;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Object ExecuteScalar(SqlTransaction transaction)
        {
            var conn = _dataBaseManager.Connection;

            try
            {
                var cmd = new SqlCommand(Name, conn) { CommandType = CommandType.StoredProcedure };

                foreach (var parameter in Parameters.Values)
                    cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);

                if (transaction != null)
                    cmd.Transaction = transaction;

                return cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
