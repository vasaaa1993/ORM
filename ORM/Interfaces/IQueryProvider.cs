using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ORM.Interfaces
{
	public interface IQueryProvider
	{
        void AddExpression(object operation, Expression ex, Type operandType);

        IEnumerable<TResult> Execute<TResult>();
    }
}
