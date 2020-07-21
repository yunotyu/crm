<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.cst_lost>" %>

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
        <span class="title">客户流失管理</span><br />
        <hr />
    </div>
    <div id="divTitleH">
    </div>
    <!--标题部分结束-->
    <%Html.BeginForm("Index", "CustomerLost", FormMethod.Post, new { id = "form1" }); %>
    <!--表头操作部分-->
    <div id="divListTop">
        <input type="submit" class="transparent button" value="查询" />
    </div>
    <!--搜索条件部分-->
    <div class="divTable3">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    客户
                </th>
                <td>
                    <input name="lst_cust_name" value='<%=Model.lst_cust_name %>' type="text" class="text" />
                </td>
                <th>
                    客服经理
                </th>
                <td>
                    <input name="lst_cust_manager_name" value='<%=Model.lst_cust_manager_name %>' type="text"
                        class="text" />
                </td>
                <th>
                    状态
                </th>
                <td>
                    <%=Html.DropDownList("lst_status", ViewData["cstStatus"] as SelectList, "--请选择--")%>
                </td>
            </tr>
        </table>
    </div>
    <!--列表部分-->
    <div id="divList">
        <% PageHelper<CRM.Model.cst_lost> pagerHelper = ViewData["pagerHelper"] as PageHelper<CRM.Model.cst_lost>;
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
                    客户
                </th>
                <th>
                    客服经理
                </th>
                <th>
                    上次下单时间
                </th>
                <th>
                    确认流失时间
                </th>
                <th>
                    状态
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
                    <%=Html.Encode(item.lst_cust_name) %>
                </td>
                <td>
                    <%=Html.Encode(item.lst_cust_manager_name) %>
                </td>
                <td>
                    <%=Html.Encode(item.lst_last_order_date) %>
                </td>
                <td>
                    <%=Html.Encode(item.lst_lost_date) %>
                </td>
                <td>
                    <%=Html.Encode(item.lst_status==1?"预警":item.lst_status==2?"暂缓流失":"已经流失") %>
                </td>
                <td>
                    <%if (item.lst_status != 3)
                      { %>
                    <a href='<%=Url.Action("CustomerLosted") %>/<%=Html.Encode(item.lst_id) %>'>
                        <img src="../../Images/ico/bt_confirm.gif" title="确认流失" class="imgLink" />
                    </a><a href='<%=Url.Action("CustomerLosting") %>/<%=Html.Encode(item.lst_id) %>'>
                        <img src="../../Images/ico/bt_relay.gif" title="暂缓流失" class="imgLink" />
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
