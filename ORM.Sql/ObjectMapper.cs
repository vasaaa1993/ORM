using System.Collections.Generic;
using System.Data.SqlClient;

namespace ORM.Sql
{
    static class SqlResultMapper
    {
        public static IEnumerable<T> Map<T>(SqlDataReader reader)
        {
            return default(IEnumerable<T>);
        }
    }
}
