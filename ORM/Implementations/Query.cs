using System;
using System.Collections;
using System.Collections.Generic;

namespace ORM
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
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
