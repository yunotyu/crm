using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Web.Controllers
{
    /// <summary>
    /// 填补请求数据对象帮助类
    /// </summary>
    public class RefreshMyModel
    {
        /// <summary>
        /// 补充请求的数据，如果请求数据非空，则忽略数据库中原有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="forms"></param>
        /// <param name="oldEntity"></param>
        public T RefreshToFormCollection<T>(ref FormCollection forms, T oldEntity) where T : class
        {
            T newObj = Activator.CreateInstance<T>();
            //开始填补
            foreach (var oldProperty in oldEntity.GetType().GetProperties())
            {
                //除去属性对象
                if (oldProperty.PropertyType.Namespace == "CRM.Model")
                {
                    continue;
                }
                if (forms[oldProperty.Name] != null || oldProperty.GetValue(oldEntity, null) == null)
                {
                    continue;
                }
                //判断是否需要填补和源属性值是否为空
                forms.Add(oldProperty.Name, oldProperty.GetValue(oldEntity, null).ToString());
                //根据对象属性的数据类型转换（待完善）
                if (oldProperty.PropertyType == typeof(DateTime) || oldProperty.PropertyType == typeof(DateTime?))
                {
                    oldProperty.SetValue(newObj, DateTime.Parse(forms[oldProperty.Name.ToLower()].ToString()), null);
                }
                else if (oldProperty.PropertyType == typeof(int) || oldProperty.PropertyType == typeof(int?))
                {
                    oldProperty.SetValue(newObj, int.Parse(forms[oldProperty.Name.ToLower()].ToString()), null);
                }
                else if (oldProperty.PropertyType == typeof(double) || oldProperty.PropertyType == typeof(double?))
                {
                    oldProperty.SetValue(newObj, double.Parse(forms[oldProperty.Name.ToLower()].ToString()), null);
                }
                else if (oldProperty.PropertyType == typeof(decimal) || oldProperty.PropertyType == typeof(decimal?))
                {
                    oldProperty.SetValue(newObj, decimal.Parse(forms[oldProperty.Name.ToLower()].ToString()), null);
                }
                else
                {
                    oldProperty.SetValue(newObj, forms[oldProperty.Name.ToLower()], null);
                }
            }
            return newObj;
        }
    }
}