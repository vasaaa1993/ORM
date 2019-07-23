﻿using NUnit.Framework;
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
                .Where(i => !i.IsPublished && i.YearOfPublishing > 2000)
                .Select(i => new { BookName = i.Name, Writer = i.Author, Count = i.Name.Count(), SomeInt = 55 })
                .OrderBy(i => i.BookName.Count()).GetEnumerator();
			Assert.AreEqual(true, false);
		}
	}
}
