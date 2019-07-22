using NUnit.Framework;
using ORM.Sql;
using ORM.Sql.Operators;
using ORM.Tests.Models;

namespace ORM.Tests
{
	[TestFixture]
	public class QueryTests
	{
		[Test]
		public void Test()
		{
			Query<Book> books = new Query<Book>(new SqlQueryProvider());
			var abc = books.Where(i => i.Name.Length > 5).Select(i => new { i.Name, i.Author });
			Assert.AreEqual(true, false);
		}
	}
}
