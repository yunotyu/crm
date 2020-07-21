using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRM.Model;
using CRM.DAL;

namespace CRM.BLL
{
    /// <summary>
    /// 服务业务逻辑类
    /// </summary>
  public  class cst_serviceService
    {
      /// <summary>
      /// 添加服务
      /// </summary>
      /// <param name="newObj"></param>
        public void AddService(cst_service newObj)
        {
            new cst_serviceRepository().AddService(newObj);
        }
      /// <summary>
      /// 根据查询对象获得服务集合
      /// </summary>
      /// <param name="searchEntity"></param>
      /// <returns></returns>
        public List<cst_service> GetServicesBySearchEntity(cst_service searchEntity)
        {
            return new cst_serviceRepository().GetServicesBySearchEntity(searchEntity);
        }
      /// <summary>
      /// 根据服务编号获得服务对象
      /// </summary>
      /// <param name="p"></param>
      /// <returns></returns>
        public cst_service GetServiceByServiceId(int p)
        {
            return new cst_serviceRepository().GetServiceByServiceId(p);
        }
      /// <summary>
      /// 修改服务
      /// </summary>
      /// <param name="newObj"></param>
        public void UpdateService(cst_service newObj)
        {
            new cst_serviceRepository().UpdateService(newObj);
        }
      /// <summary>
      /// 删除服务
      /// </summary>
      /// <param name="p"></param>
        public void DeleteService(int p)
        {
            new cst_serviceRepository().DeleteService(p);
        }
    }
}
