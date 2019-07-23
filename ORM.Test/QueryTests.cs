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
			Query<Book> books = new Query<Book>(new SqlQueryProvider<Book>(""));
			var abc = books
                .Where(i => !i.val)
                .Select(i => new { BookName = i.Name, Writer = i.Author, Count = i.Name.Count(), SomeInt = 55 })
                .OrderBy(i => i.BookName.Count()).GetEnumerator();
			Assert.AreEqual(true, false);
		}
	}
}
