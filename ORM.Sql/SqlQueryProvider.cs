using ORM.Sql.Helpers;
using ORM.Sql.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using IQueryProvider = ORM.Interfaces.IQueryProvider;

namespace ORM.Sql
{
    public class SqlQueryProvider<T> : IQueryProvider
	{
        private readonly List<QueryItem> _operators = new List<QueryItem>();
        private readonly string _connectionString;

        public SqlQueryProvider(string connectionString)
        {
            _operators.Add(new QueryItem(SqlOperator.None, null, typeof(T)));
            _connectionString = connectionString;
        }

        public void AddExpression(object operation, Expression ex, Type operand)
        {
            if (!Enum.TryParse(operation.ToString(), out SqlOperator sqlOp))
            {
                throw new NotSupportedException("Wrong type of operator. Operator must be one of SqlOperator.");
            }

            _operators.Add(new QueryItem(sqlOp, ex, operand));
        }

        public IEnumerable<TResult> Execute<TResult>()
        {
            var sql = new SqlQueryBuilder().BuildQuery(_operators);

            IEnumerable<ParameterItem> parameters = ResultParameterOrderHelper.GetListOfResultParameters(_operators.FirstOrDefault(i => i.Operator == SqlOperator.Select));

            IEnumerable<TResult> result;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();

                result = SqlResultMapper.Map<TResult>(reader, parameters);

                reader.Close();
            }   
            return result;
        }
    }
}
