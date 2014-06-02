using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using System.Data.SqlClient;

namespace Persistance
{
    public static class RubroPersistance
    {
        public static List<Rubro> GetAll()
        {
            var sp = new StoreProcedure(DataBaseConst.Rubro.SPGetAllRubro);
            return sp.ExecuteReader<Rubro>();
        }

        public static List<Rubro> GetByPublicationId(int publicationID)
        {
            var param = new List<SPParameter> { new SPParameter("ID_Publicacion", publicationID) };
            var sp = new StoreProcedure(DataBaseConst.Rubro.SPGetAllRubroByPublicationId, param);

            var rubros = sp.ExecuteReader<Rubro>();

            if (rubros == null || rubros.Count == 0)
                return null;

            return rubros;
        }

        public static int InsertByPublication(Publicacion publication, SqlTransaction transaction)
        {
            var regsAffected = 0;

            foreach (var rubro in publication.Rubros)
            {
                var param = new List<SPParameter> { new SPParameter("ID_Rubro", rubro.ID), new SPParameter("ID_Publicacion", publication.ID) };
                var sp = (transaction != null)
                            ? new StoreProcedure(DataBaseConst.Rubro.SPInsertRubroByPublicacion, param, transaction)
                            : new StoreProcedure(DataBaseConst.Rubro.SPInsertRubroByPublicacion, param);

                regsAffected += sp.ExecuteNonQuery(transaction);
            }

            return regsAffected;
        }

        public static int DeleteByPublication(Publicacion publication, SqlTransaction transaction)
        {
            var regsAffected = 0;

            foreach (var rubro in publication.Rubros)
            {
                var param = new List<SPParameter> { new SPParameter("ID_Publicacion", publication.ID) };
                var sp = (transaction != null)
                            ? new StoreProcedure(DataBaseConst.Rubro.SPDeleteRubroByPublicacion, param, transaction)
                            : new StoreProcedure(DataBaseConst.Rubro.SPDeleteRubroByPublicacion, param);

                regsAffected += sp.ExecuteNonQuery(transaction);
            }

            return regsAffected;
        }
    }
}
