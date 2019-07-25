using ORM.Sql.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ORM.Sql.Helpers
{
    static class ResultParameterOrderHelper
    {
        public static IEnumerable<ParameterItem> GetListOfResultParameters(QueryItem item)
        {
            List<ParameterItem> result = new List<ParameterItem>();

            if(item.Expression == null)
            {
                result.AddRange(item.OperandType.GetProperties().Select(i => new ParameterItem() { Name = i.Name, Type = i.PropertyType }));
                
            }
            else
            {
                var lambda = item.Expression as LambdaExpression;
                var newEx = lambda.Body as NewExpression;
                result.AddRange(newEx.Members.Select(m => m as PropertyInfo).Select(m => new ParameterItem() { Name = m.Name, Type = m.PropertyType }));
            }

            return result;
        }
    }
}
