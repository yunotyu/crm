using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model.Utils
{
    public class Common
    {
        /// <summary>
        /// 用于类型转换
        /// </summary>
        public static object Cast(string typeName, object val)
        {
            object data = null;
            switch (typeName)
            {
                case "Nullable`1":
                    {
                        if (!int.TryParse(val.ToString(), out int i))
                        {
                            return data = null;
                        }
                        data = Convert.ToInt32(val);
                        break;
                    }
                case "Int32":
                    {
                        if (!int.TryParse(val.ToString(), out int i))
                        {
                            return data = null;
                        }
                        data = Convert.ToInt32(val);
                        break;
                    }
                case "Double":
                    {
                        data = Convert.ToDouble(val);
                        break;
                    }
                case "Datetime":
                    {
                        data = Convert.ToDateTime(val);
                        break;
                    }
                case "String":
                    {
                        data = val.ToString();
                        break;
                    }
            }
            return data;
        }


        /// <summary>
        /// 用于更新部分字段，获取前台传递的字段，
        /// 反射拼接对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="propNames"></param>
        /// <returns></returns>
        public static bool UpdateSomeFiel<T>(T model, IDictionary<string, object> forms, DbContext db) where T :class
        {
            foreach (var p in forms)
            {
                if (model.GetType().GetProperty(p.Key) == null)
                {
                    continue;
                }
                else
                {
                    //获取属性的类型，然后将值转换为该类型的值
                    var val = Cast(model.GetType().GetProperty(p.Key).PropertyType.Name, p.Value);
                    model.GetType().GetProperty(p.Key).SetValue(model, val);
                }
            }
            db.Set<T>().Attach(model);
            foreach (var p in forms)
            {
                if (model.GetType().GetProperty(p.Key) != null)
                {
                    db.Entry<T>(model).Property(p.Key).IsModified = true;
                }
            }
            try
            {
                return db.SaveChanges() > 0;

            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static string GetCstManaName(string name,string id)
        {
            var val = "";
            if (name == "cust_level")
            {
                switch (id)
                {
                    case "1":
                        {
                            val= "普通客户";
                            break;
                        }
                    case "2":
                        {
                            val = "重点开发客户";
                            break;
                        }
                    case "3":
                        {
                            val = "大客户";
                            break;
                        }
                    case "4":
                        {
                            val = "合作伙伴";
                            break;
                        }
                    case "5":
                        {
                            val = "战略合作伙伴";
                            break;
                        }
                }
            }
            return val;
        }
    }
}
