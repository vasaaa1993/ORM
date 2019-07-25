using ORM.Sql.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORM.Sql
{
    internal class SqlQueryBuilder
    {
        private readonly IReadOnlyList<SqlOperator> _sqlOperators = new List<SqlOperator>()
        {
            SqlOperator.Select,
            SqlOperator.Where,
            SqlOperator.OrderBy
        };

        public string BuildQuery(List<QueryItem> operators)
        {
            var result = "";
            foreach (var op in _sqlOperators)
            {
                var item = GetItemByOperator(op, operators);

                if (item == null)
                    continue;

                result = GetBuilderByOperator(op).Build(result, item.Expression, item.OperandType);

            }

            return result.Trim();
        }

        private void PrepareExpressopns(List<QueryItem> operators)
        {
            if (GetItemByOperator(SqlOperator.Select, operators) == null)
            {
                operators.Add(new QueryItem(SqlOperator.Select, null, GetItemByOperator(SqlOperator.None, operators).OperandType));
            }
        }

        private QueryItem GetItemByOperator(SqlOperator op, List<QueryItem> operators)
        {
            return operators.FirstOrDefault(i => i.Operator == op) ?? null;
        }

        private BuilderBase GetBuilderByOperator(SqlOperator op)
        {
            switch (op)
            {
                case SqlOperator.Select:
                    return new SelectBuilder();
                case SqlOperator.Where:
                    return new WhereBuilder();
                case SqlOperator.OrderBy:
                    return new OrderByBuilder();
                default:
                    throw new InvalidOperationException("Invalid operation type.");
            }
        }
    }
}
