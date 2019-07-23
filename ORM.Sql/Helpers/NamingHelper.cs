using ORM.Sql.Attributes;
using System;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Linq;

namespace ORM.Sql.Helpers
{
	static class NamingHelper
	{
		public static string GetTableName(Type modelType)
		{
			var attributes = Attribute.GetCustomAttributes(modelType);
			var tableAttr = attributes.FirstOrDefault(a => a.GetType() == typeof(TableAttribute));

			if (tableAttr != null)
				return (tableAttr as TableAttribute).Name;

			return PluralizationService
				.CreateService(new CultureInfo("en-US"))
				.Pluralize(modelType.Name);
		}
	}
}
