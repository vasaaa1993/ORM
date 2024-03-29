﻿using ORM.Interfaces;
using System;
using System.Linq.Expressions;

namespace ORM.Sql.Operators
{
	public static partial class QueryExtensions
	{
		public static IQuery<TSource> Where<TSource>(this IQuery<TSource> source, Expression<Func<TSource, bool>> predicate)
		{
            source.Provider.AddExpression(SqlOperator.Where, predicate, typeof(TSource));
            return source;
		}
	}
}
