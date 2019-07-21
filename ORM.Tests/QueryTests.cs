using NUnit.Framework;
using ORM.Implementations.Operators;
using ORM.Tests.Models;

namespace ORM.Tests
{
	public class QueryTests
	{
		[Test]
		public void Test()
		{
			Query<Book> books = new Query<Book>(new SqlQueryProvider());
			var abc = books.Select(i => new { Name = i.Name, Author = i.Author });
		}
	}
}
