using System;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace Our.Umbraco.EditorsDashboard.Extensions
{
    public static class TypeExtensions
    {
        public static string GetTableName(this Type type)
        {
            var attr = type.GetCustomAttribute<TableNameAttribute>(false);
            return attr != null ? attr.Value : type.Name;
        }

        public static string GetPrimaryKeyName(this Type type)
        {
            var attr = type.GetCustomAttribute<PrimaryKeyAttribute>(true);
            return attr != null ? attr.Value : "Id";
        }
    }
}
