<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.orders>" %>

<%@ Import Namespace="CRM.Web.Controllers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>OrderHistoryInfo</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/Shared/Shared.js" type="text/javascript"></script>
</head>
<body>
    <%Html.BeginForm("OrderHistoryInfo", "CustomerManager", FormMethod.Post, new { id = "form1" }); %>
    <!--标题部分-->
    <div id="divTitle">
        <span class="title"><a href='<%=Url.Action("Index") %>'>客户信息管理</a>&nbsp;>><a href='<%=Url.Action("OrderHistory",new{id=Model.odr_cust_no}) %>'>历史订单</a>&nbsp;>>&nbsp;订单详细</span><br />
        <hr />
    </div>
    <div id="divTitleH">
    </div>
    <!--标题部分结束-->
    <div class="divTable2">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    订单编号
                </th>
                <td>
                    <span class="keypoint">
                        <%=Model.odr_id %></span>
                </td>
                <th>
                    日期
                </th>
                <td>
                    <%=Model.odr_date %>
                </td>
            </tr>
            <tr>
                <th>
                    送货地址
                </th>
                <td>
                    <%=Model.odr_addr %>
                </td>
                <th>
                    总金额
                </th>
                <td>
                    <%=Html.Encode( ViewData["totalMoney"]) %>
                </td>
            </tr>
            <tr>
                <th>
                    状态
                </th>
                <td>
                    <%=Model.odr_status == 0 ? "<span class='keypoint'>未回款</span>" : "已回款"%>
                </td>
                <th>
                </th>
                <td>
                </td>
            </tr>
        </table>
    </div>
    <!--表头操作部分-->
    <div id="divListTop">
        <input type="button" onclick=javascript:window.location.href='<%=Url.Action("OrderHistory",new{id=Model.odr_cust_no}) %>'; value="返回" class="transparent button" />
    </div>
    <!--列表部分-->
    <div id="divList">
        <% PageHelper<CRM.Model.orders_line> pagerHelper = ViewData["pagerHelper"] as PageHelper<CRM.Model.orders_line>;
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
                    商品
                </th>
                <th>
                    数量
                </th>
                <th>
                    单位
                </th>
                <th>
                    单价（元）
                </th>
                <th>
                    金额（元）
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
                    <%=Html.Encode(item.product.prod_name) %>
                </td>
                <td>
                    <%=Html.Encode(item.odd_unit) %>
                </td>
                <td>
                    <%=Html.Encode(item.odd_count) %>
                </td>
                <td>
                    <%=Html.Encode(item.odd_price) %>
                </td>
                <td>
                    <%=Html.Encode(item.odd_price*item.odd_count) %>
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
