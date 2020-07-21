using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;
using CRM.DAL;

namespace CRM.BLL
{
    /// <summary>
    /// 报表业务逻辑类
    /// </summary>
   public class TheReportsService
    {
       /// <summary>
       /// 查询客户贡献报表数据
       /// </summary>
       /// <param name="searchEntity"></param>
       /// <returns></returns>
       public List<ContributeReportModel> GetContributesBySearchEntity(orders searchEntity)
        {
            return new TheReportsRepository().GetContributesBySearchEntity(searchEntity);
        }
       /// <summary>
       /// 查询客户构成报表数据
       /// </summary>
       /// <param name="searchEntity"></param>
       /// <returns></returns>
       public List<ComposingReportModel> GetComposingReportBySearchEntity(ComposingReportModel searchEntity)
       {
           return new TheReportsRepository().GetComposingReportBySearchEntity(searchEntity);
       }
    }
}
