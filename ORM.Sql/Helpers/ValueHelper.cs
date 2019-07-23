namespace ORM.Sql.Helpers
{
    static class ValueHelper
    {
        public static string ValueToString(object value)
        {
            if (value == null)
                return "NULL";
            else if (value is bool)
                return (bool)value ? "1" : "0";
            else return value.ToString();
        }
    }
}
