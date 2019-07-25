using ORM.Sql.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ORM.Sql
{
    static class SqlResultMapper
    {
        public static IEnumerable<T> Map<T>(SqlDataReader reader, IEnumerable<ParameterItem> parameters)
        {
            List<T> result = new List<T>();
            
            while (reader.Read())
            {
                int i = 0;
                object[] arr = parameters.Select(p => GetValueByType(reader, i++, p.Type)).ToArray();
                var obj = (T)Activator.CreateInstance(typeof(T), arr);
                result.Add(obj);
            }
            return result;
        }

        private static object GetValueByType(SqlDataReader reader, int index, Type type)
        {
            if (type == typeof(double))
                return reader.GetDouble(index);

            if (type == typeof(int))
                return reader.GetInt32(index);

            if (type == typeof(string))
                return reader.GetString(index).Trim();

            if (type == typeof(bool))
                return reader.GetBoolean(index);

            throw new NotImplementedException($"Type - {type.Name} is not supported by mapper.");
        }
    }
}
