﻿using System;
using System.Linq.Expressions;

namespace ORM.Implementations.Operators
{
	public static partial class QueryExtensions
	{
		public static IQuery<TSource> OrderBy<TSource>(this IQuery<TSource> source, Expression<Func<TSource, bool>> predicate)
		{
			return null;
		}
	}
}