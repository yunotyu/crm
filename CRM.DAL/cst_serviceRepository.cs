using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;

namespace CRM.DAL
{
    /// <summary>
    /// 客户服务数据访问类
    /// </summary>
    public class cst_serviceRepository
    {
        /// <summary>
        /// 添加服务
        /// </summary>
        /// <param name="newObj"></param>
        public void AddService(cst_service newObj)
        {
            new LinqHelper().InsertEntity<cst_service>(newObj);
        }

        /// <summary>
        /// 根据查询对象获得服务集合
        /// </summary>
        /// <param name="searchEntity"></param>
        /// <returns></returns>
        public List<cst_service> GetServicesBySearchEntity(cst_service searchEntity)
        {
            return (from s in LinqHelper.GetDataContext().cst_service
                    where s.svr_cust_name.Contains(searchEntity.svr_cust_name == null ? "" : searchEntity.svr_cust_name)
                    && s.svr_title.Contains(searchEntity.svr_title == null ? "" : searchEntity.svr_title)
                    && s.svr_type.Contains(searchEntity.svr_type == null ? "" : searchEntity.svr_type)
                    && s.svr_status == searchEntity.svr_status
                    select s).ToList();

        }

        /// <summary>
        /// 根据服务编号获得服务对象
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public cst_service GetServiceByServiceId(int p)
        {
            return LinqHelper.GetDataContext().cst_service.Where(s => s.svr_id == p).FirstOrDefault();
        }

        /// <summary>
        /// 修改服务
        /// </summary>
        /// <param name="newObj"></param>
        public void UpdateService(cst_service newObj)
        {
            new LinqHelper().UpadateEntity<cst_service>(newObj);
        }

        /// <summary>
        /// 删除服务
        /// </summary>
        /// <param name="p"></param>
        public void DeleteService(int p)
        {
            new LinqHelper().ExecuteCommand("delete from cst_service where svr_id="+p);
        }
    }
}
