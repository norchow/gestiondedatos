using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Persistance.Entities;
using Configuration;

namespace Persistance
{
    public static class RespuestaPersistance
    {
        public static Respuesta InsertAnswer(Respuesta answer, SqlTransaction transaction)
        {
            var param = new List<SPParameter>
                {
                    new SPParameter("ID_Pregunta", answer.IdPregunta),
                    new SPParameter("Texto", answer.Texto),
                    new SPParameter("Fecha", ConfigurationVariables.FechaSistema),
                };

            var sp = (transaction != null)
                        ? new StoreProcedure(DataBaseConst.Respuesta.SPInsertAnswer, param, transaction)
                        : new StoreProcedure(DataBaseConst.Respuesta.SPInsertAnswer, param);

            answer.ID = (int)sp.ExecuteScalar(transaction);

            return answer;
        }
    }
}
