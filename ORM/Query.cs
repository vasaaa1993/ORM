﻿using ORM.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ORM.Sql
{
	public class Query<T> : IQuery<T>
	{
		public Query(IQueryProvider provider)
		{
			Provider = provider;
		}

		public IQueryProvider Provider { get; }

		public IEnumerator<T> GetEnumerator()
		{
            var str = Provider.Build();
            return new List<T>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
