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
        //public override string Build(Expression ex)
        //{
        //    if (ex == null)
        //        return "";

        //    if (!(ex is LambdaExpression))
        //    {
        //        throw new NotSupportedException($"Expression type: {ex.GetType().Name} is unsupported.");
        //    }

        //    var lambdaEx = ex as LambdaExpression;

        //    var result = "ORDER BY  " + Recurse((ex as LambdaExpression).Body);

        //    return result;
        //}

        //protected override string Recurse(Expression expression)
        //{
        //    if (expression is MemberExpression)
        //    {
        //        var member = expression as MemberExpression;

        //        if (member.Member is PropertyInfo)
        //        {
        //            return member.Member.Name;
        //        }
        //        else
        //        {
        //            throw new NotImplementedException();
        //        }
        //    }

        //    if (expression is MethodCallExpression)
        //    {
        //        var methodCall = expression as MethodCallExpression;

        //        if (methodCall.Method.DeclaringType == typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
        //    .First(m => m.Name == "Count").DeclaringType)
        //        {
        //            var str = $"LEN({Recurse(methodCall.Arguments[0])})";
        //            return str;
        //        }
        //        else
        //        {
        //            throw new NotImplementedException();
        //        }

        //    }

        //    throw new NotImplementedException();
        //}
    }
}
