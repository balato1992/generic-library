using System;
using System.Linq.Expressions;

namespace GenericModel.Other
{
    // Reference: https://handcraftsman.wordpress.com/2008/11/11/how-to-get-c-property-names-without-magic-strings/
    // 使用方式: ReflectionUtility.GetPropertyName(() => (new ClassName()).Property)
    public static class ReflectionUtility
    {
        public static string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            MemberExpression body = (MemberExpression)expression.Body;
            return body.Member.Name;
        }
    }
}
