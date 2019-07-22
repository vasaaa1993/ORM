using System.Collections.Generic;

namespace ORM.Interfaces
{
	public interface IQuery<T>: IEnumerable<T>
	{
        IQueryProvider Provider { get; }
    }
}
