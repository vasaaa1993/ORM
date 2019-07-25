using ORM.Sql.Helpers;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ORM.Sql.Builders
{
    class WhereBuilder: BuilderBase
    {
        public WhereBuilder()
        {
            Operator = "WHERE";
        }
    }
}
