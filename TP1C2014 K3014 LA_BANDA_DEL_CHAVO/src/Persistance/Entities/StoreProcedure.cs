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
            // Set the Name
            Name = String.IsNullOrEmpty(spName) ? String.Empty : spName;

            // Set the Parameters
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

            // Set the Transaction
            Transaction = spTransaction;

            // Set the Connection
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
         * ExecuteReader(): Return the SqlDataReader
         * Remember to close SqlDataReader after.
         */
        public SqlDataReader ExecuteReader()
        {
            var conn = _dataBaseManager.Connection;

            try
            {
                var cmd = new SqlCommand(Name, conn) {CommandType = CommandType.StoredProcedure};

                foreach (var parameter in Parameters.Values)
                    cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);

                // Don't close the SqlDataReader
                return cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /*
         * ExecuteReader<T>(): Return the entities mapped
         */
        public List<T> ExecuteReader<T>() where T : IMapable, new()
        {
            try
            {
                // Execute the SP and get the SqlDataReader
                var reader = ExecuteReader();

                // Map the Entities
                var map = new List<T>();

                while (!reader.IsClosed && reader.Read())
                {
                    var mapable = new T();
                    map.Add((T)mapable.Map(reader));
                }

                // Close the SqlDataReader
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
         * ExecuteReader(DelegateMap customMap): Return the entities with a custom Map
         */
        public delegate IMapable DelegateMap(SqlDataReader reader);

        public List<IMapable> ExecuteReader(DelegateMap customMap)
        {
            try
            {
                // Execute the SP and get the SqlDataReader
                var reader = ExecuteReader();

                // Map the Entities
                var map = new List<IMapable>();

                while (!reader.IsClosed && reader.Read())
                {
                    map.Add(customMap(reader));
                }

                // Close the SqlDataReader
                if (!reader.IsClosed)
                    reader.Close();

                return map;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Dictionary<String, Object> ExecuteOutput()
        {
            var conn = _dataBaseManager.Connection;

            try
            {
                var cmd = new SqlCommand(Name, conn) { CommandType = CommandType.StoredProcedure };

                foreach (var parameter in Parameters.Values)
                    cmd.Parameters.AddWithValue(parameter.Name, parameter.Value);

                cmd.ExecuteNonQuery();

                return Parameters.Values.Where(p => p.IsOutput || p.IsInputOutput).ToDictionary(p => p.Name, p => p.Value);
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

        /*
         * TODO: Query class
         */

        public void ExecuteSQLQuery(string query)
        {
            var conn = _dataBaseManager.Connection;

            try
            {
                var cmd = new SqlCommand(query, conn) {CommandType = CommandType.Text};

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ExecuteSQLQuery(string query, out SqlDataReader rdr)
        {
            rdr = null;

            var conn = _dataBaseManager.Connection;

            try
            {
                var cmd = new SqlCommand(query, conn) {CommandType = CommandType.Text, CommandTimeout = 0};
                rdr = cmd.ExecuteReader();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
