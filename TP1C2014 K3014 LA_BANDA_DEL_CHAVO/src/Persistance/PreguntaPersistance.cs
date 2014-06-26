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
                    new SPParameter("ID_Usuario", question.IdUsuario),
                    new SPParameter("Texto", question.Texto)
                };

            var sp = (transaction != null)
                        ? new StoreProcedure(DataBaseConst.Pregunta.SPInsertQuestion, param, transaction)
                        : new StoreProcedure(DataBaseConst.Pregunta.SPInsertQuestion, param);

            question.ID = (int)sp.ExecuteScalar(transaction);

            return question;
        }

        public static List<PublicacionPregunta> GetUnansweredQuestionsByUserId(int userId)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Usuario", userId)
                };

            var sp = new StoreProcedure(DataBaseConst.Pregunta.SPGetUnansweredByUserId, param);

            var preguntas = sp.ExecuteReader<PublicacionPregunta>();

            if (preguntas == null || preguntas.Count == 0)
                return null;

            return preguntas;
        }
    }
}
