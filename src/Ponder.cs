using System;
using System.Linq.Expressions;

namespace Ponder
{
    public class Reflect
    {
        public static string PropertyName<T>(Expression<Func<T, object>> expression)
        {
            return GetPropertyName(expression);
        }

        static string GetPropertyName(Expression expression)
        {
            if (expression == null) return "";

            if (expression is LambdaExpression)
            {
                expression = ((LambdaExpression) expression).Body;
            }

            if (expression is UnaryExpression)
            {
                expression = ((UnaryExpression)expression).Operand;
            }

            if (expression is MemberExpression)
            {
                dynamic memberExpression = expression;

                var lambdaExpression = (Expression)memberExpression.Expression;

                string prefix;
                if (lambdaExpression != null)
                {
                    prefix = GetPropertyName(lambdaExpression);
                    if (!string.IsNullOrEmpty(prefix))
                    {
                        prefix += ".";
                    }
                }
                else
                {
                    prefix = "";
                }

                var propertyName = memberExpression.Member.Name;
                
                return prefix + propertyName;
            }

            return "";
        }
    }
}