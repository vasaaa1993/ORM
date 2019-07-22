using System.Linq.Expressions;

namespace ORM.Sql.Builders
{
    abstract class BuilderBase
    {
        public virtual string Build(Expression ex)
        {
            return "";
        }
    }
}
