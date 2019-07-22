using System;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ORM.Sql.Builders
{
    class SelectBuilder: BuilderBase
    {
        public override string Build(Expression ex)
        {
            if (!(ex is LambdaExpression))
            {
                throw new NotSupportedException($"Expression type: {ex.GetType().Name} is unsupported.");
            }

            if (ex == null)
                return DefaultQuery();

            var result = "Select" + Recurse((ex as LambdaExpression).Body) 
                + PluralizationService.CreateService(new CultureInfo("en-US")).Pluralize((ex as LambdaExpression).Parameters[0].Name);

            return result;
        }

        public string Recurse(Expression expression)
        {
            if (expression is NewExpression)
            {
                var newEx = expression as NewExpression;
                var str = "";
                var count = newEx.Arguments.Count;
                for (int i = 0; i < count; i++)
                {
                    str += $" {Recurse(newEx.Arguments[i])} AS {newEx.Members[i].Name}{(i != count - 1 ? "," : "")} ";
                }
                return str;
            }

            if (expression is MemberExpression)
            {
                var member = expression as MemberExpression;

                if(member.Member is PropertyInfo)
                {
                    return member.Member.Name;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            if (expression is MethodCallExpression)
            {
                var methodCall = expression as MethodCallExpression;

                if (methodCall.Method.DeclaringType == typeof(Enumerable).GetMethods(BindingFlags.Static | BindingFlags.Public)
            .First(m => m.Name == "Count").DeclaringType)
                {
                    var str = $"LEN({Recurse(methodCall.Arguments[0])})";
                    return str;
                }
                else
                {
                    throw new NotImplementedException();
                }
                
            }

            if (expression is ConstantExpression)
            {
                var constant = expression as ConstantExpression;
                return constant.Value.ToString();
            }

            throw new NotImplementedException();
        }

        public string DefaultQuery()
        {
            return "Select * From";
        }

       // public string NodeTypeToString(ExpressionType nodeType, )
    }
}
