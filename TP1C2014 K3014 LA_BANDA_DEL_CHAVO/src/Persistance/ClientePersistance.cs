using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using System.Data.SqlClient;
using System.Data;

namespace Persistance
{
    public static class ClientePersistance
    {
        public static Cliente GetById(int id)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Cliente", id)
                };

            var sp = new StoreProcedure(DataBaseConst.Cliente.SPGetById, param);

            var clients = sp.ExecuteReader<Cliente>();

            if (clients == null || clients.Count == 0)
                return null;

            return clients[0];
        }

        public static Cliente GetByPhone(string phone)
        {
            var param = new List<SPParameter> { new SPParameter("Telefono", phone) };
            var sp = new StoreProcedure(DataBaseConst.Cliente.SPGetClientByPhone, param);

            var users = sp.ExecuteReader<Cliente>();

            if (users == null || users.Count == 0)
                return null;

            return users[0];
        }

        public static Cliente GetByPhone(string phone, SqlTransaction transaction)
        {
            var param = new List<SPParameter> { new SPParameter("Telefono", phone) };
            var sp = new StoreProcedure(DataBaseConst.Cliente.SPGetClientByPhone, param, transaction);

            var users = sp.ExecuteReaderTransactioned<Cliente>(transaction);

            if (users == null || users.Count == 0)
                return null;

            return users[0];
        }

        public static Cliente GetByUserId(int userId)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Usuario", userId) };
            var sp = new StoreProcedure(DataBaseConst.Cliente.SPGetClientByUserId, param);

            var users = sp.ExecuteReader<Cliente>();

            if (users == null || users.Count == 0)
                return null;

            return users[0];
        }

        public static Cliente GetByDocument(int tipoDocumento, int nroDocumento)
        {
            var param = new List<SPParameter> { new SPParameter("Tipo_documento", tipoDocumento), new SPParameter("Nro_documento", nroDocumento) };
            var sp = new StoreProcedure(DataBaseConst.Cliente.SPGetClientByDocument, param);

            var users = sp.ExecuteReader<Cliente>();

            if (users == null || users.Count == 0)
                return null;

            return users[0];
        }

        public static Cliente GetByDocument(int tipoDocumento, int nroDocumento, SqlTransaction transaction)
        {
            var param = new List<SPParameter> 
                { 
                    new SPParameter("Tipo_documento", tipoDocumento), 
                    new SPParameter("Nro_documento", nroDocumento) 
                };
            var sp = new StoreProcedure(DataBaseConst.Cliente.SPGetClientByDocument, param, transaction);

            var users = sp.ExecuteReaderTransactioned<Cliente>(transaction);

            if (users == null || users.Count == 0)
                return null;

            return users[0];
        }

        public static Cliente InsertClient(Cliente client, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Usuario", client.IdUsuario),
                    new SPParameter("Nombre", client.Nombre),
                    new SPParameter("Apellido", client.Apellido),
                    new SPParameter("ID_Tipo_documento", client.TipoDocumento), 
                    new SPParameter("Nro_documento", client.NroDocumento),
                    new SPParameter("Mail", client.Mail),
                    new SPParameter("Telefono", client.Telefono),
                    new SPParameter("Direccion", client.Direccion),
                    new SPParameter("Codigo_Postal", client.CodigoPostal),
                    new SPParameter("Fecha_nacimiento", client.FechaNacimiento),
                    new SPParameter("CUIL", client.CUIL)
                };

            var sp = (transaction != null)
                        ? new StoreProcedure(DataBaseConst.Cliente.SPInsertClient, param, transaction)
                        : new StoreProcedure(DataBaseConst.Cliente.SPInsertClient, param);

            client.ID = (int)sp.ExecuteScalar(transaction);

            return client;
        }
    }
}
