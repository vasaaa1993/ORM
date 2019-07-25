using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ORM.Sql.Builders
{
    class OrderByBuilder: BuilderBase
    {
        public OrderByBuilder()
        {
            Operator = "ORDER BY";
        }

        public override string Build(string prev, Expression ex, Type type = null)
        {
            if (!(ex is LambdaExpression))
            {
                throw new NotSupportedException($"Expression type: {ex.GetType().Name} is unsupported.");
            }

            var lambdaEx = ex as LambdaExpression;

            var result = $"SELECT * FROM ({prev}) AS A{DateTime.UtcNow.Ticks.ToString()} {Operator} " + Recurse((ex as LambdaExpression).Body);

            return result;
        }
    }
}
