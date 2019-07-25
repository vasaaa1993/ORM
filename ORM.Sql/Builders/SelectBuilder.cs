using ORM.Sql.Helpers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ORM.Sql.Builders
{
    class SelectBuilder: BuilderBase
    {
        public SelectBuilder()
        {
            Operator = "SELECT";
        }

        // for now we ignore prev
        public override string Build(string prev, Expression ex, Type type = null)
        {
            var result = $"{Operator} ";

            if (ex == null)
                result += "*";
            else
            {
                if (!(ex is LambdaExpression))
                {
                    throw new NotSupportedException($"Expression type: {ex.GetType().Name} is unsupported.");
                }

                var lambdaEx = ex as LambdaExpression;

                result += Recurse(lambdaEx.Body);

                if (type == null)
                    type = (lambdaEx.Parameters.First() as ParameterExpression)?.Type;
            }

            if (type == null)
                throw new InvalidOperationException("Type cannot be null in the select statment");

            result += $" From {NamingHelper.GetTableName(type)}";

            return result;
        }
    }
}
