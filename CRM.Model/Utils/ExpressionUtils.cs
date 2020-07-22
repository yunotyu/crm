using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace CRM.Model.Utils
{
    /// <summary>
    /// 表达式目录树拼接帮助类,记得最后要compile，再传给函数
    /// 也可以使用linqkit
    /// </summary>
    public class ExpressionUtils
    {

        public static Expression<Func<T,bool>> True<T>()
        {
            return t => true;
        }

        public static Expression<Func<T, bool>> False<T>()
        {
            return t => false;
        }

        /// <summary>
        /// And拼接，注意表达式的参数要写成一样
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="expressions"></param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> And<T>(Expression<Func<T, bool>> expressions1, Expression<Func<T, bool>>expressions2)
        {
            var invokeExpression = Expression.Invoke(expressions2, expressions1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expressions1.Body,invokeExpression), expressions1.Parameters);
        }

        public static Expression<Func<T, bool>> Or<T>(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }
}
