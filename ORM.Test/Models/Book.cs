using ORM.Sql.Attributes;
using System;

namespace ORM.Tests.Models
{
    //[Table(Name = "BlaBla")]
    public class Book
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Author { get; set; }
		public int PageCount { get; set; }
		public int YearOfPublishing { get; set; }
		public string ISBN { get; set; }
		public string Language { get; set; }
		public bool IsPublished { get; set; }
    }


}
