using ORM.Sql.Builders;
using System;
using System.Collections.Generic;
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
            _connectionString = connectionString;
            _operators.Add(new QueryItem(SqlOperator.None, null, typeof(T)));
        }

        public void AddExpression(object operation, Expression ex, Type operand)
        {
            if (!Enum.TryParse(operation.ToString(), out SqlOperator sqlOp))
            {
                throw new NotSupportedException("Wrong type of operator. Operator must be one of SqlOperator.");
            }

            _operators.Add(new QueryItem(sqlOp, ex, operand));
        }

        public string Build()
		{
            return new SqlQueryBuilder().BuildQuery(_operators);
        }
	}
}
