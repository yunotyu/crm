<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.storage>" %>

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
        <span class="title">库存信息查询</span><br />
        <hr />
    </div>
    <div id="divTitleH">
    </div>
    <!--标题部分结束-->
    <%Html.BeginForm("Index", "StorageSearch", FormMethod.Post, new { id = "form1" }); %>
    <!--表头操作部分-->
    <div id="divListTop">
        <input type="submit" class="transparent button" value="查询" />
    </div>
    <!--搜索条件部分-->
    <div class="divTable3">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    产品
                </th>
                <td>
                    <input name="prod_name" value='<%=Model.product.prod_name %>' type="text" class="text" />
                </td>
                <th>
                    仓库
                </th>
                <td colspan="3">
                    <input name="stk_warehouse" value='<%=Model.stk_warehouse %>' type="text" class="text" />
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
        <% PageHelper<CRM.Model.storage> pagerHelper = ViewData["pagerHelper"] as PageHelper<CRM.Model.storage>;
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
                    名称
                </th>
                <th>
                    仓库
                </th>
                <th>
                    货位
                </th>
                <th>
                    件数
                </th>
                <th>
                    备注
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
                    <%=Html.Encode(item.stk_warehouse) %>
                </td>
                <td>
                    <%=Html.Encode(item.stk_ware) %>
                </td>
                <td>
                    <%=Html.Encode(item.stk_count) %>
                </td>
                <td>
                    <%=Html.Encode(item.stk_memo) %>
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
