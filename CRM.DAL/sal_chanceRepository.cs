using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;
using System.Data.Linq.SqlClient;


namespace CRM.DAL
{
    /// <summary>
    /// 销售机会数据访问类
    /// </summary>
    public class sal_chanceRepository
    {
        private LinqHelper helper = new LinqHelper();

        /// <summary>
        /// 获得所有销售机会
        /// </summary>
        /// <returns></returns>
        public List<sal_chance> GetAllSalChance()
        {
            return helper.GetList<sal_chance>();
        }
        /// <summary>
        /// 根据机会查询对象获得机会集合
        /// </summary>
        /// <param name="searchEntity"></param>
        /// <returns></returns>
        public List<sal_chance> GetSalsBySearchEntity(sal_chance searchEntity)
        {
            List<sal_chance> list = new List<sal_chance>();

            list = (from s in LinqHelper.GetDataContext().sal_chance
                    where s.chc_cust_name.Contains(searchEntity.chc_cust_name == null ? "" : searchEntity.chc_cust_name)
                    && s.chc_title.Contains(searchEntity.chc_title == null ? "" : searchEntity.chc_title)
                    && s.chc_linkman.Contains(searchEntity.chc_linkman == null ? "" : searchEntity.chc_linkman)
                    orderby s.chc_id descending
                    select s).ToList();
            return list;
        }
        /// <summary>
        /// 根据机会编号获得机会对象
        /// </summary>
        /// <param name="salId"></param>
        /// <returns></returns>
        public sal_chance GetSalById(int salId)
        {
            return helper.GetEntity<sal_chance>(s => s.chc_id == salId);
        }
        /// <summary>
        /// 更新销售机会
        /// </summary>
        /// <param name="sal"></param>
        public void UpdateSal(sal_chance sal)
        {
            helper.UpadateEntity<sal_chance>(sal);
        }
        /// <summary>
        /// 新增销售机会
        /// </summary>
        /// <param name="sal"></param>
        public void AddSal(sal_chance sal)
        {
            helper.InsertEntity<sal_chance>(sal);
        }
        /// <summary>
        /// 根据编号删除销售机会
        /// </summary>
        /// <param name="p"></param>
        public void DeleteSalById(int p)
        {
            new LinqHelper().ExecuteCommand("delete from  sal_chance where chc_id=" + p);
        }
        
        /// <summary>
        /// 开发失败（终止开发）
        /// </summary>
        /// <param name="id"></param>
        public void PlanError(int id)
        {
            new LinqHelper().ExecuteCommand("update sal_chance set chc_status=3 where chc_id=" + id);
        }
        /// <summary>
        /// 开发成功
        /// </summary>
        /// <param name="id"></param>
        public void PlanOk(int id)
        {
            new LinqHelper().ExecuteCommand("update sal_chance set chc_status=2 where chc_id=" + id);
        }
    }
}
