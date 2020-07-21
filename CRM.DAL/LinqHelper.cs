using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;
using System.Configuration;
using System.Linq.Expressions;
using System.Data.SqlClient;
using System.Data.Linq;
using System.Data.Entity;
using System.Data.Sql;

namespace CRM.DAL
{
    /// <summary>
    /// Linq数据访问层
    /// </summary>
    public class LinqHelper
    {

        public lf_crm_db2Entities Db { get; set; }

        public LinqHelper()
        {
            Db = new lf_crm_db2Entities();
        }

        /// <summary>
        /// 获得数据上下文
        /// </summary>
        /// <returns></returns>
        public static lf_crm_db2Entities GetDataContext()
        {
            lf_crm_db2Entities crmDB = new lf_crm_db2Entities();
            return crmDB;
        }

        /// <summary>
        /// 通过表达式目录树拼接where条件
        /// </summary>
        /// <typeparam name="T">要查询的实体类型</typeparam>
        /// <param name="proDic">前台发送过来的参数集合</param>
        /// <returns></returns>
        public static Expression<Func<T, bool>> GetExpress<T>(IDictionary<string,object>proDic)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            BinaryExpression finalExpression=null;
            int count = 0;

            foreach (var pro in proDic)
            {
                if (typeof(T).GetProperty(pro.Key)==null)
                {
                    continue;
                }
                if (string.IsNullOrEmpty(pro.Value.ToString()))
                {
                    continue;
                }
                Expression expressionProperty = Expression.Property(parameter, typeof(T).GetProperty(pro.Key));
                ConstantExpression constantExpression = Expression.Constant(pro.Value, typeof(T).GetProperty(pro.Key).PropertyType);
                BinaryExpression binaryExpression = Expression.Equal(expressionProperty, constantExpression);
                if (count== 0)
                {
                    finalExpression = binaryExpression;
                    count++;
                    continue;
                }
                finalExpression = Expression.And(finalExpression, binaryExpression);
                count++;
            }

            //当没有传入查询参数时，查询构造查询全部的条件
            if (finalExpression == null)
            {
                var finalExpression1 = Expression.Constant(true, typeof(Boolean));
                return Expression.Lambda<Func<T, bool>>(finalExpression1, new ParameterExpression[]
                {
                parameter
                });
            }

            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T,bool>>(finalExpression, new ParameterExpression[]
            {
                parameter
            });
            return lambda;
        }

        /// <summary>
        /// 获取所有的数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetList<T>() where T : class
        {
            return Db.Set<T>().Where(d => true).ToList();
        }
        /// <summary>
        /// 获取指定的单个实体
        /// 如果不存在则返回null
        /// 如果存在多个则抛异常
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="predicate">Lamda表达式</param>
        /// <returns>Entity</returns>
        public T GetEntity<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return Db.Set<T>().Where(predicate).SingleOrDefault();
          
        }
        /// <summary>
        /// 用SQL语句查询
        /// </summary>
        /// <typeparam name="T">实体类类型</typeparam>
        /// <param name="sql">sql语句</param>
        /// <param name="parameters">sql参数</param>
        /// <returns>集合</returns>
        public List<T> GetListBySql<T>(string sql, params SqlParameter[] parameters) where T : class
        {
            return Db.Set<T>().SqlQuery(sql, parameters).ToList() ;
        }


        public  bool ExecuteCommand(string sql,params SqlParameter[] sqlParameters)
        {
            return Db.Database.ExecuteSqlCommand(sql, sqlParameters)>0?true:false;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <typeparam name="T">实体类类型</typeparam>
        /// <param name="eneiey">实体对象</param>
        public void InsertEntity<T>(T entity) where T : class
        {
            Db.Set<T>().Add(entity);
            Db.SaveChanges();
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <typeparam name="T">实体类类型</typeparam>
        /// <param name="predicate">Lamda表达式</param>
        public void DeleteEntity<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            var entity= Db.Set<T>().Where(predicate).SingleOrDefault();
            Db.Set<T>().Remove(entity);
            Db.SaveChanges();
        }
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T">实体类类型</typeparam>
        /// <param name="list">实体集合</param>
        public void DeletesEntity<T>(List<T> list) where T : class
        {
            //using (CRMDBDataContext db = GetDataContext())
            //{
            //    Db.Database.BeginTransaction();
            //    try
            //    {
            //        foreach (var item in list)
            //        {
            //            db.GetTable<T>().Attach(item);
            //            db.Refresh(RefreshMode.KeepCurrentValues, item);
            //        }
            //        db.GetTable<T>().DeleteAllOnSubmit(list.AsEnumerable<T>());
            //        db.SubmitChanges();
            //        db.Transaction.Commit();
            //    }
            //    catch (Exception ex)
            //    {
            //        db.Transaction.Rollback();
            //        throw new Exception(ex.Message);
            //    }
            //}
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <typeparam name="T">实体类类型</typeparam>
        /// <param name="entity">实体对象</param>
        public void UpadateEntity<T>(T entity) where T : class
        {
            Db.Set<T>().Attach(entity);
            Db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();
        }

        public bool SaveChanges()
        {
            return Db.SaveChanges()>0?true:false;
        }
    }
}
