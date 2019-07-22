using NUnit.Framework;
using ORM.Sql;
using ORM.Sql.Operators;
using ORM.Tests.Models;
using System.Linq;

namespace ORM.Tests
{
	[TestFixture]
	public class QueryTests
	{
		[Test]
		public void Test()
		{
			Query<Book> books = new Query<Book>(new SqlQueryProvider(""));
			var abc = books.Where(i => i.Name.Count() > 5).Select(i => new { BookName = i.Name, Writer = i.Author, Count = i.Name.Count(), SomeInt = 55 }).GetEnumerator();
			Assert.AreEqual(true, false);
		}
	}
}
