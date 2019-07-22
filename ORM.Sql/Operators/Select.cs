using ORM.Interfaces;
using System;
using System.Linq.Expressions;

namespace ORM.Sql.Operators
{
	public static partial class QueryExtensions
	{
		public static IQuery<TResult> Select<TSource, TResult>(this IQuery<TSource> source, Expression<Func<TSource, TResult>> expression)
		{
            source.Provider.AddExpression(SqlOperator.Select, expression, typeof(TSource));
            return new Query<TResult>(source.Provider);
        }
	}
}
