<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.ViewModels.Cst_Custom_ViewModel>" %>

<%@ Import Namespace="CRM.Web.Controllers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Index</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/Shared/Shared.js" type="text/javascript"></script>
</head>
<body>
    <!--标题部分-->
    <div id="divTitle">
        <span class="title">客户信息管理</span><br />
        <hr />
    </div>
    <div id="divTitleH">
    </div>
    <!--标题部分结束-->
    <%Html.BeginForm("Index", "CustomerManager", FormMethod.Post, new { id = "form1" }); %>
    <!--表头操作部分-->
    <div id="divListTop">
        <input type="submit" class="transparent button" value="查询" />
    </div>
    <!--搜索条件部分-->
    <div class="divTable3">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    客户编号
                </th>
                <td>
                    <input name="cust_no" value='<%=Model.cust_no %>' type="text" class="text" />
                </td>
                <th>
                    客户名称
                </th>
                <td>
                    <input name="cust_name" value='<%=Model.cust_name %>' type="text" class="text" />
                </td>
                <th>
                    地区
                </th>
                <td>
                <%=Html.DropDownList("cust_region", ViewData["region"] as SelectList, "--请选择--")%>
                </td>
            </tr>
            <tr>
                <th>
                    客服经理
                </th>
                <td>
                    <input name="cust_manager_name" value='<%=Model.cust_manager_name %>' type="text"
                        class="text" />
                </td>
                <th>
                    客户等级
                </th>
                <td>
                <%=Html.DropDownList("cust_level", ViewData["level"] as SelectList, "--请选择--")%>
                </td>
                <th>
                </th>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <!--列表部分-->
    <div id="divList">
        <% PageHelper<CRM.Model.cst_customer> pagerHelper = ViewData["pagerHelper"] as PageHelper<CRM.Model.cst_customer>;
           if (pagerHelper.TotalCount == 0)
           {
        %>
        <!--没有任何数据-->
        <div class="nodata">
        </div>
        <%
           }
           else
           {
        %>
        <!--数据列表-->
        <table cellpadding="0" cellspacing="0">
            <tr class="tblHead">
                <th>
                    序号
                </th>
                <th>
                    客户编号
                </th>
                <th>
                    客户名称
                </th>
                <th>
                    地区
                </th>
                <th>
                    客服经理
                </th>
                <th>
                    客户等级
                </th>
                <th>
                    操作
                </th>
            </tr>
            <%
               int index = 1;
               foreach (var item in pagerHelper)
               {
            %>
            <tr class="tblItem">
                <td>
                    <%=index++ %>
                </td>
                <td>
                    <%=Html.Encode(item.cust_no) %>
                </td>
                <td>
                    <%=Html.Encode(item.cust_name) %>
                </td>
                <td>
                    <%=Html.Encode(item.cust_region) %>
                </td>
                <td>
                    <%=Html.Encode(item.cust_manager_name) %>
                </td>
                <td>
                    <%=Html.Encode(item.cust_level_label) %>
                </td>
                <td>
                   <%-- <%if (item.chc_create_id == (Session["user"] as CRM.Model.sys_user).usr_id || (Session["user"] as CRM.Model.sys_user).usr_role_id == 2)
                      { %>--%>
                    <a href='<%=Url.Action("Update") %>/<%=Html.Encode(item.cust_Id) %>'>
                        <img src="../../Images/ico/bt_edit.gif" title="编辑" class="imgLink" />
                    </a>
                    <%--<%} %>
                    <%if ((Session["user"] as CRM.Model.sys_user).usr_role_id == 2)
                      {%>--%>
                    <a href='<%=Url.Action("LinkMan") %>/<%=Html.Encode(item.cust_Id) %>'>
                        <img src="../../Images/ico/bt_linkman.gif" title="联系人" class="imgLink" />
                    </a>
                    <%--<%} %>--%>
                <%--    <%if (item.chc_create_id == (Session["user"] as CRM.Model.sys_user).usr_id || (Session["user"] as CRM.Model.sys_user).usr_role_id == 2)
                      { %>--%>
                    <a href='<%=Url.Action("ContactRecord") %>/<%=Html.Encode(item.cust_no) %>'>
                        <img src="../../Images/ico/bt_acti.gif" title="交往记录" class="imgLink" />
                    </a>
                    <a href='<%=Url.Action("OrderHistory") %>/<%=Html.Encode(item.cust_no) %>'>
                        <img src="../../Images/ico/bt_orders.gif" title="历史订单" class="imgLink" />
                    </a>
                    <a href='<%=Url.Action("Delete") %>/<%=Html.Encode(item.cust_Id) %>'>
                        <img src="../../Images/ico/bt_del.gif" title="删除客户" class="imgLink" />
                    </a>
                <%--    <%} %>--%>
                </td>
            </tr>
            <%
               }
            %>
        </table>
        <%  } %>
    </div>
    <!--分页部分-->
    <div id="divPager">
        <input type="hidden" id="inputCurPage" name="curPage" value="0" />
        <%=pagerHelper.PagerHtmlA %>
    </div>
</body>
</html>
