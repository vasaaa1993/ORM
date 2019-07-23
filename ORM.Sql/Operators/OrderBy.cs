using ORM.Interfaces;
using System;
using System.Linq.Expressions;

namespace ORM.Sql.Operators
{
	public static partial class QueryExtensions
	{
		public static IQuery<TSource> OrderBy<TSource, TKey>(this IQuery<TSource> source, Expression<Func<TSource, TKey>> keySelector)
		{
            source.Provider.AddExpression(SqlOperator.OrderBy, keySelector, typeof(TSource));
            return source;
		}
	}
}
