<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.cst_customer>" %>

<%@ Import Namespace="CRM.Web.Controllers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>OrderHistory</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/Shared/Shared.js" type="text/javascript"></script>
</head>
<body>
    <%Html.BeginForm("OrderHistory", "CustomerManager", FormMethod.Post, new { id = "form1" }); %>
    <!--标题部分-->
    <div id="divTitle">
        <span class="title"><a href='<%=Url.Action("Index") %>'>客户信息管理</a>&nbsp;>>&nbsp;历史订单</span><br />
        <hr />
    </div>
    <div id="divTitleH">
    </div>
    <!--标题部分结束-->
    <div class="divTable2">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    客户编号
                </th>
                <td>
                    <span class="keypoint">
                        <%=Model.cust_no %></span>
                </td>
                <th>
                    客户名称
                </th>
                <td>
                    <%=Model.cust_name %>
                </td>
            </tr>
        </table>
    </div>
    <!--表头操作部分-->
    <div id="divListTop">
        <input type="button" onclick=javascript:window.location.href='<%=Url.Action("Index") %>'; value="返回" class="transparent button" />
    </div>
    <!--列表部分-->
    <div id="divList">
        <% PageHelper<CRM.Model.orders> pagerHelper = ViewData["pagerHelper"] as PageHelper<CRM.Model.orders>;
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
                    订单编号
                </th>
                <th>
                    日期
                </th>
                <th>
                    送货地址
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
                    <%=Html.Encode(item.odr_id) %>
                </td>
                <td>
                    <%=Html.Encode(item.odr_date) %>
                </td>
                <td>
                    <%=Html.Encode(item.odr_addr) %>
                </td>
                <td>
                    <%=Html.Encode(item.odr_status==0?"未回款":"已回款") %>
                </td>
                <td>
                    <a href='<%=Url.Action("OrderHistoryInfo") %>/<%=Html.Encode(item.odr_id) %>'>
                        <img src="../../Images/ico/bt_edit.gif" title="查看详细" class="imgLink" />
                    </a>
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
