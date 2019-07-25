using NUnit.Framework;
using ORM.Sql;
using ORM.Sql.Operators;
using ORM.Tests.Models;
using System.Configuration;
using System.Linq;

namespace ORM.Tests
{
	[TestFixture]
	public class QueryTests
	{
		[Test]
		public void Test()
		{
			Query<Book> books = new Query<Book>(new SqlQueryProvider<Book>(ConfigurationManager.ConnectionStrings["ORM_DbConnection"].ConnectionString));
			var abc = books
                .Where(i => i.YearOfPublishing > 1900)
                .Select(i => new { BookName = i.Name, Writer = i.Author, Count = i.Name.Count(), SomeInt = 55 })
                .OrderBy(i => i.BookName.Count());
            foreach (var item in abc)
            {
                System.Console.WriteLine(item);
            }
		}
	}
}
