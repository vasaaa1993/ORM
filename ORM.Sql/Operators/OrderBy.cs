using ORM.Interfaces;
using System;
using System.Linq.Expressions;

namespace ORM.Sql.Operators
{
	public static partial class QueryExtensions
	{
		public static IQuery<TSource> OrderBy<TSource>(this IQuery<TSource> source, Expression<Func<TSource, bool>> predicate)
		{
            source.Provider.AddExpression(SqlOperator.Select, predicate, typeof(TSource));
            return source;
		}
	}
}
