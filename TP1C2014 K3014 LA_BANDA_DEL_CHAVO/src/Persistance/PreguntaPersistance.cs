using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistance.Entities;
using System.Data.SqlClient;

namespace Persistance
{
    public static class PreguntaPersistance
    {
        public static Pregunta InsertQuestion(Pregunta question, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Publicacion", question.IdPublicacion),
                    new SPParameter("Texto", question.Texto)
                };

            var sp = (transaction != null)
                        ? new StoreProcedure(DataBaseConst.Pregunta.SPInsertQuestion, param, transaction)
                        : new StoreProcedure(DataBaseConst.Pregunta.SPInsertQuestion, param);

            question.ID = (int)sp.ExecuteScalar(transaction);

            return question;
        }
    }
}
