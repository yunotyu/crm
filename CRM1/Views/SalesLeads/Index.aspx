<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.sal_chance>" %>

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
        <span class="title">销售机会管理</span><br />
        <hr />
    </div>
    <div id="divTitleH"></div>
    <!--标题部分结束-->
    <%Html.BeginForm("Index", "SalesLeads", FormMethod.Post, new { id = "form1" }); %>
    <!--表头操作部分-->
    <div id="divListTop">
        <input type="button" onclick="javascript:window.location.href='<%=Url.Action("AddSal") %>'"
            class="transparent button" value="添加" />
        <input type="submit" class="transparent button" value="查询" />
    </div>
    <!--搜索条件部分-->
    <div class="divTable3">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    客户名称
                </th>
                <td>
                    <input name="chc_cust_name" value='<%=Model.chc_cust_name %>' type="text" class="text" />
                </td>
                <th>
                    概要
                </th>
                <td>
                    <input name="chc_title" value='<%=Model.chc_title %>' type="text" class="text" />
                </td>
                <th>
                    联系人
                </th>
                <td>
                    <input name="chc_linkman" value='<%=Model.chc_linkman %>' type="text" class="text" />
                </td>
            </tr>
        </table>
    </div>
    <!--列表部分-->
    <div id="divList">
        <% PageHelper<CRM.Model.sal_chance> pagerHelper = ViewData["pagerHelper"] as PageHelper<CRM.Model.sal_chance>;
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
                    客户名称
                </th>
                <th>
                    概要
                </th>
                <th>
                    联系人
                </th>
                <th>
                    联系电话
                </th>
                <th>
                    创建时间
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
                    <%=Html.Encode(item.chc_cust_name) %>
                </td>
                <td>
                    <%=Html.Encode(item.chc_title) %>
                </td>
                <td>
                    <%=Html.Encode(item.chc_linkman) %>
                </td>
                <td>
                    <%=Html.Encode(item.chc_tel) %>
                </td>
                <td>
                    <%=Html.Encode(item.chc_create_date) %>
                </td>
                <td>
                    <%if (item.chc_create_id == (Session["user"] as CRM.Model.sys_user).usr_id || (Session["user"] as CRM.Model.sys_user).usr_role_id == 2 || (Session["user"] as CRM.Model.sys_user).usr_role_id == 5)
    { %>
                    <a href='<%=Url.Action("Update") %>/<%=Html.Encode(item.chc_id) %>'>
                        <img src="../../Images/ico/bt_edit.gif" title="编辑" alt="编辑" class="imgLink" />
                    </a>
                    <%} %>
                    <%if ((Session["user"] as CRM.Model.sys_user).usr_role_id == 2||(Session["user"] as CRM.Model.sys_user).usr_role_id == 5)
                      {%>
                    <a href='<%=Url.Action("AllotSal") %>/<%=Html.Encode(item.chc_id) %>'>
                        <img src="../../Images/ico/bt_linkman.gif" title="指派" alt="指派" class="imgLink" />
                    </a>
                    <%} %>
                    <%if (item.chc_create_id == (Session["user"] as CRM.Model.sys_user).usr_id || (Session["user"] as CRM.Model.sys_user).usr_role_id == 2||(Session["user"] as CRM.Model.sys_user).usr_role_id == 5)
                      { %>
                    <a href='<%=Url.Action("Delete") %>/<%=Html.Encode(item.chc_id) %>'>
                        <img src="../../Images/ico/bt_del.gif" title="删除" alt="删除" class="imgLink" />
                    </a>
                    <%} %>
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
    <%Html.EndForm(); %>
</body>
</html>
