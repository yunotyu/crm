using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;
using CRM.DAL;

namespace CRM.BLL
{
    /// <summary>
    /// 销售机会服务类
    /// </summary>
    public class sal_chanceService
    {
        private sal_chanceRepository salDao = new sal_chanceRepository();
        /// <summary>
        /// 获得所有销售机会
        /// </summary>
        /// <returns></returns>
        public List<sal_chance> GetAllSal()
        {
            return salDao.GetAllSalChance();
        }
        /// <summary>
        /// 根据机会查询对象获得未指派的机会集合
        /// </summary>
        /// <param name="searchEntity"></param>
        /// <returns></returns>
        public List<sal_chance> GetSalsBySearchEntity(sal_chance searchEntity)
        {
            return salDao.GetSalsBySearchEntity(searchEntity).Where(s => s.chc_status == 0).ToList();
        }

        /// <summary>
        /// 根据机会查询对象获得已指派的机会集合
        /// </summary>
        /// <param name="searchEntity"></param>
        /// <returns></returns>
        public List<sal_chance> GetAppointSalsBySearchEntity(sal_chance searchEntity)
        {
            return salDao.GetSalsBySearchEntity(searchEntity).Where(s => s.chc_status > 0).ToList();
        }

        /// <summary>
        /// 根据机会编号获得机会对象
        /// </summary>
        /// <param name="salId"></param>
        /// <returns></returns>
        public sal_chance GetSalById(int salId)
        {
            return salDao.GetSalById(salId);
        }
        /// <summary>
        /// 新增或更新销售机会对象
        /// </summary>
        /// <param name="sal"></param>
        public void AddOrUpdateSal(sal_chance sal)
        {
            //补全分配信息
            if (sal.chc_status == 0)
            {
                sal.chc_due_date = DateTime.Now;
            }
            if (sal.chc_due_id > 0)
            {
                sal.chc_due_to = new sys_userRepository().GetUserByUserId(sal.chc_due_id.Value).usr_name;
                sal.chc_status = 1;
            }
            else
            {
                sal.chc_status = 0;
            }
            //新增或修改
            if (sal.chc_id > 0)
            {
                salDao.UpdateSal(sal);
            }
            else
            {
                sal.chc_create_date = DateTime.Now;
                salDao.AddSal(sal);
            }
        }
        /// <summary>
        /// 根据机会编号删除销售机会
        /// </summary>
        /// <param name="p"></param>
        public void Delete(int p)
        {
            salDao.DeleteSalById(p);
        }
    }
}
