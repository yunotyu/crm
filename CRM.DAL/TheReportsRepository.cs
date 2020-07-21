using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;

namespace CRM.DAL
{
    /// <summary>
    /// 报表数据访问类
    /// </summary>
    public class TheReportsRepository
    {
        /// <summary>
        /// 查询客户贡献报表数据
        /// </summary>
        /// <param name="searchEntity"></param>
        /// <returns></returns>
        public List<ContributeReportModel> GetContributesBySearchEntity(orders searchEntity)
        {
            var db = LinqHelper.GetDataContext();
            if (searchEntity.odr_id > 0)
            {
                return (from p in db.orders_line
                        where p.orders.odr_cust_name.Contains
                        (searchEntity.odr_cust_name == null ? "" : searchEntity.odr_cust_name)
                        && p.orders.odr_date.Year == searchEntity.odr_id
                        group p by p.orders.odr_cust_name into g
                        select new ContributeReportModel
                        {
                            Name = g.Key,
                            TotalMoney = g.Sum(p => p.odd_price.Value)
                        }).ToList();
            }
            else
            {
                return (from p in db.orders_line
                        where p.orders.odr_cust_name.Contains
                        (searchEntity.odr_cust_name == null ? "" : searchEntity.odr_cust_name)
                        group p by p.orders.odr_cust_name into g
                        select new ContributeReportModel
                        {
                            Name = g.Key,
                            TotalMoney = g.Sum(p => p.odd_price.Value)
                        }).ToList();
            }
        }

        /// <summary>
        /// 查询客户构成报表数据
        /// </summary>
        /// <param name="searchEntity"></param>
        /// <returns></returns>
        public List<ComposingReportModel> GetComposingReportBySearchEntity(ComposingReportModel searchEntity)
        {
            var db = LinqHelper.GetDataContext();
            if (searchEntity.TypeName == "按等级")
            {
                return (from c in db.cst_customer
                        group c by c.cust_level_label into nc
                        select new ComposingReportModel
                        {
                            TypeName = nc.Key,
                            CustomerCount = nc.Count()
                        }).ToList();
            }
            else if (searchEntity.TypeName == "按信用度")
            {
                return (from c in db.cst_customer
                        group c by c.cust_credit into nc
                        select new ComposingReportModel
                        {
                            TypeName = new bas_dictRepository().GetDictsByType("客户信用度")[nc.Key.Value].dict_item,
                            CustomerCount = nc.Count()
                        }).ToList();
            }
            else
            {
                return (from c in db.cst_customer
                        group c by c.cust_satisfy into nc
                        select new ComposingReportModel
                        {
                            TypeName = new bas_dictRepository().GetDictsByType("客户满意度")[nc.Key.Value].dict_item,
                            CustomerCount = nc.Count()
                        }).ToList();
            }
        }
    }
}
