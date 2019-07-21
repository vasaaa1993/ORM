using System;
using System.Linq.Expressions;

namespace ORM.Implementations.Operators
{
	public static partial class QueryExtensions
	{
		public static IQuery<TResult> Select<TSource, TResult>(this IQuery<TSource> source, Expression<Func<TSource, TResult>> expression)
		{
			return null;
		}
	}
}
