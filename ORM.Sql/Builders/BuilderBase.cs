using ORM.Sql.Helpers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ORM.Sql.Builders
{
    abstract class BuilderBase
    {
        protected string Operator { get; set; }

        public virtual string Build(Expression ex, Type type = null)
        {
            if (!(ex is LambdaExpression))
            {
                throw new NotSupportedException($"Expression type: {ex.GetType().Name} is unsupported.");
            }

            var lambdaEx = ex as LambdaExpression;

            var result = $"{Operator} " + Recurse((ex as LambdaExpression).Body);

            return result;
        }

        protected virtual string Recurse(Expression expression)
        {
            if (expression is BinaryExpression)
            {
                var binary = expression as BinaryExpression;
                var right = Recurse(binary.Right);
                return $" {Recurse(binary.Left)} {OperationHelper.NodeTypeToSqlOperation(binary.NodeType, right == "NULL")} {right}";
            }

            if (expression is UnaryExpression)
            {
                var unary = expression as UnaryExpression;
                var operand = Recurse(unary.Operand);
                return $"{OperationHelper.NodeTypeToSqlOperation(unary.NodeType, operand == "NULL")} {operand}";
            }

            if (expression is NewExpression)
            {
                var newEx = expression as NewExpression;
                var str = "";
                var count = newEx.Arguments.Count;
                for (int i = 0; i < count; i++)
                {
                    str += $"{Recurse(newEx.Arguments[i])} AS {newEx.Members[i].Name}{(i != count - 1 ? "," : "")} ";
                }
                return str;
            }

            if (expression is MemberExpression)
            {
                var member = expression as MemberExpression;

                if (member.Member is PropertyInfo)
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

                return ValueHelper.ValueToString(constant.Value);
            }

            throw new NotImplementedException();
        }
    }
}
