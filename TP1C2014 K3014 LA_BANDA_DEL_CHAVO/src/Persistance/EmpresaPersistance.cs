using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using System.Data.SqlClient;
using Filters;

namespace Persistance
{
    public static class EmpresaPersistance
    {
        public static Empresa GetByBusinessName(string businessName)
        {
            var param = new List<SPParameter> { new SPParameter("Razon_Social", businessName) };
            var sp = new StoreProcedure(DataBaseConst.Empresa.SPGetCompanyByBusinessName, param);

            var users = sp.ExecuteReader<Empresa>();

            if (users == null || users.Count == 0)
                return null;

            return users[0];
        }

        public static Empresa GetByBusinessName(string businessName, SqlTransaction transaction)
        {
            var param = new List<SPParameter> { new SPParameter("Razon_Social", businessName) };
            var sp = new StoreProcedure(DataBaseConst.Empresa.SPGetCompanyByBusinessName, param, transaction);

            var users = sp.ExecuteReaderTransactioned<Empresa>(transaction);

            if (users == null || users.Count == 0)
                return null;

            return users[0];
        }

        public static Empresa GetByCUIT(string cuit)
        {
            var param = new List<SPParameter> { new SPParameter("CUIT", cuit) };
            var sp = new StoreProcedure(DataBaseConst.Empresa.SPGetCompanyByCUIT, param);

            var users = sp.ExecuteReader<Empresa>();

            if (users == null || users.Count == 0)
                return null;

            return users[0];
        }

        public static Empresa GetByCUIT(string cuit, SqlTransaction transaction)
        {
            var param = new List<SPParameter> { new SPParameter("CUIT", cuit) };
            var sp = new StoreProcedure(DataBaseConst.Empresa.SPGetCompanyByCUIT, param, transaction);

            var users = sp.ExecuteReaderTransactioned<Empresa>(transaction);

            if (users == null || users.Count == 0)
                return null;

            return users[0];
        }

        public static Empresa GetByUserId(int userId)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Usuario", userId) };
            var sp = new StoreProcedure(DataBaseConst.Empresa.SPGetCompanyByUserId, param);

            var users = sp.ExecuteReader<Empresa>();

            if (users == null || users.Count == 0)
                return null;

            return users[0];
        }

        public static List<Empresa> GetAllBusiness()
        {
            var sp = new StoreProcedure(DataBaseConst.Empresa.SPGetAllBusiness);

            return sp.ExecuteReader<Empresa>();
        }

        public static List<Empresa> GetAllBusinessByParameters(EmpresaFilters filters)
        {
            var param = new List<SPParameter> { new SPParameter("Razon_Social", filters.RazonSocial),
                                                new SPParameter("Cuit", filters.Cuit),
                                                new SPParameter("Email", filters.Email)};
            
            var sp = new StoreProcedure(DataBaseConst.Empresa.SPGetAllBusinessByParameters, param);

            return sp.ExecuteReader<Empresa>();
        }

        public static List<Empresa> GetAllBusinessByParametersLike(EmpresaFilters filters)
        {
            var param = new List<SPParameter> { new SPParameter("Razon_Social", filters.RazonSocial ?? (object)DBNull.Value),
                                                new SPParameter("Cuit", filters.Cuit ?? (object)DBNull.Value),
                                                new SPParameter("Email", filters.Email ?? (object)DBNull.Value)};

            var sp = new StoreProcedure(DataBaseConst.Empresa.SPGetAllBusinessByParametersLike, param);

            return sp.ExecuteReader<Empresa>();
        }

        public static Empresa InsertCompany(Empresa company, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Usuario", company.IdUsuario),
                    new SPParameter("Razon_Social", company.RazonSocial),
                    new SPParameter("Mail", company.Mail),
                    new SPParameter("Telefono", company.Telefono),
                    new SPParameter("Direccion", company.Direccion),
                    new SPParameter("Codigo_Postal", company.CodigoPostal),
                    new SPParameter("Ciudad", company.Ciudad),
                    new SPParameter("CUIT", company.CUIT),
                    new SPParameter("Nombre_Contacto", company.NombreContacto),
                    new SPParameter("Fecha_Creacion", company.FechaCreacion)                    
                };

            var sp = (transaction != null)
                        ? new StoreProcedure(DataBaseConst.Empresa.SPInsertCompany, param, transaction)
                        : new StoreProcedure(DataBaseConst.Empresa.SPInsertCompany, param);

            company.ID = (int)sp.ExecuteScalar(transaction);

            return company;
        }


        public static Empresa UpdateCompany(Empresa company)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_User", company.IdUsuario),
                    new SPParameter("Razon_Social", company.RazonSocial),
                    new SPParameter("Mail", company.Mail),
                    new SPParameter("Telefono", company.Telefono),
                    new SPParameter("Direccion", company.Direccion),
                    new SPParameter("Codigo_Postal", company.CodigoPostal),
                    new SPParameter("Ciuidad", company.Ciudad),
                    new SPParameter("CUIT", company.CUIT),
                    new SPParameter("Nombre_Contacto", company.NombreContacto),
                    new SPParameter("Fecha_Creacion", company.FechaCreacion)                    
                };

            var sp = new StoreProcedure(DataBaseConst.Empresa.SPUpdateCompany, param);

            company.ID = (int)sp.ExecuteNonQuery(null);

            return company; 
        }

    }
}
