﻿using System;
using System.Linq.Expressions;

namespace ORM.Sql
{
    internal class QueryItem
    {
        public SqlOperator Operator { get; set; }
        public Expression Expression { get; set; }
        public Type Operand { get; set; }

        public QueryItem(SqlOperator op, Expression ex, Type operand)
        {
            Operator = op;
            Expression = ex;
            Operand = operand;
        }
    }
}
