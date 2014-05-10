using System.Collections.Generic;
using System.Data.SqlClient;

namespace Persistance.Entities
{
    public interface IMapable
    {
        IMapable Map(SqlDataReader reader);
        List<SPParameter> UnMap(IMapable entity);
    }
}
