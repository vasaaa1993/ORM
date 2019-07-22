using ORM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ORM.Sql
{
    public class SqlQueryProvider : IQueryProvider
	{
        private readonly List<QueryItem> _operators = new List<QueryItem>();

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
			throw new NotImplementedException();
		}
	}
}
