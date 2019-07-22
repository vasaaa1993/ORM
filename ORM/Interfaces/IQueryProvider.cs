using System;
using System.Linq.Expressions;

namespace ORM.Interfaces
{
	public interface IQueryProvider
	{
        void AddExpression(object operation, Expression ex, Type operandType);

        string Build();
	}
}
