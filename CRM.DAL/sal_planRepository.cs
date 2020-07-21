using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;

namespace CRM.DAL
{
    /// <summary>
    /// 销售计划数据访问类
    /// </summary>
    public class sal_planRepository
    {
        /// <summary>
        /// 根据机会编号获得计划集合
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Model.sal_plan> GetPlanBySalId(int id)
        {
            return LinqHelper.GetDataContext().sal_plan.Where(p => p.pla_chc_id == id).ToList();
        }
        /// <summary>
        /// 添加销售计划
        /// </summary>
        /// <param name="sal"></param>
        public void AddPlan(sal_plan sal)
        {
            new LinqHelper().InsertEntity<sal_plan>(sal);
        }
        /// <summary>
        /// 修改销售计划项
        /// </summary>
        /// <param name="sal"></param>
        public void UpdateTodoPlan(sal_plan sal)
        {
            new LinqHelper().ExecuteCommand("update sal_plan set pla_todo='" + sal.pla_todo + "' where pla_id=" + sal.pla_id);
        }
        /// <summary>
        /// 根据计划编号删除计划
        /// </summary>
        /// <param name="p"></param>
        public void DeletePlanByPlanId(int p)
        {
            new LinqHelper().ExecuteCommand("Delete from sal_plan where pla_id=" + p);
        }

        /// <summary>
        /// 修改销售计划结果
        /// </summary>
        /// <param name="sal"></param>
        public void UpdateTodoPlanResult(sal_plan sal)
        {
            new LinqHelper().ExecuteCommand("update sal_plan set pla_result='" + sal.pla_result + "' where pla_id=" + sal.pla_id);
        }

    }
}
