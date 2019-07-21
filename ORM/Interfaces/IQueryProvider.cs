using System.Linq.Expressions;

namespace ORM
{
	public interface IQueryProvider
	{
		string Build();
	}
}
