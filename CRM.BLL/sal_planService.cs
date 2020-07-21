using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;
using CRM.DAL;

namespace CRM.BLL
{
    /// <summary>
    /// 销售计划业务逻辑类
    /// </summary>
    public class sal_planService
    {
        /// <summary>
        /// 根据机会编号获得计划集合
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public List<sal_plan> GetPlanBySalId(int p)
        {
            return new sal_planRepository().GetPlanBySalId(p);
        }

        /// <summary>
        /// 添加销售计划
        /// </summary>
        /// <param name="sal"></param>
        public void AddPlan(sal_plan sal)
        {
            new sal_planRepository().AddPlan(sal);
        }

        /// <summary>
        /// 修改计划
        /// </summary>
        /// <param name="p"></param>
        public void UpdateTodoPlan(sal_plan sal)
        {
            new sal_planRepository().UpdateTodoPlan(sal);
        }

        /// <summary>
        /// 根据计划编号删除计划
        /// </summary>
        /// <param name="p"></param>
        public void DeletePlanByPlanId(int p)
        {
            new sal_planRepository().DeletePlanByPlanId(p);
        }

        /// <summary>
        /// 修改销售计划结果
        /// </summary>
        /// <param name="sal"></param>
        public void UpdateTodoPlanResult(sal_plan sal)
        {
            new sal_planRepository().UpdateTodoPlanResult(sal);
        }
        /// <summary>
        /// 开发失败（终止开发）
        /// </summary>
        /// <param name="id"></param>
        public void PlanError(int id)
        {
            new sal_chanceRepository().PlanError(id);
        }

        /// <summary>
        /// 开发成功
        /// </summary>
        /// <param name="id">计划编号</param>
        /// <param name="userId">当前用户编号</param>
        /// <param name="userName">当前用户名称</param>
        public void PlanOk(int id,int userId,string userName)
        {
            sal_chance sal = new sal_chanceService().GetSalById(id);
            cst_customer cst = new cst_customer();
            cst_linkman lkman = new cst_linkman();
            //编号
            cst.cust_no = "KH" + new Random().Next(10000000, 99999999);
            cst.cust_name = sal.chc_cust_name;
            cst.cust_manager_id = userId;
            cst.cust_manager_name = userName;
            lkman.lkm_name = sal.chc_linkman;
            lkman.lkm_mobile = sal.chc_tel;
            lkman.lkm_cust_name = sal.chc_cust_name;
            lkman.lkm_cust_no = cst.cust_no;
            new cst_customerRepository().AddCustomer(cst);
            new cst_linkmanRepository().AddLinkMan(lkman);
            new sal_chanceRepository().PlanOk(id);
        }
    }
}
