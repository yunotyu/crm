<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.product>" %>

<%@ Import Namespace="CRM.Web.Controllers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Index</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/Shared/Shared.js" type="text/javascript"></script>
</head>
<body>
    <!--标题部分-->
    <div id="divTitle">
        <span class="title">产品信息查询</span><br />
        <hr />
    </div>
    <div id="divTitleH">
    </div>
    <!--标题部分结束-->
    <%Html.BeginForm("Index", "ProductSearch", FormMethod.Post, new { id = "form1" }); %>
    <!--表头操作部分-->
    <div id="divListTop">
        <input type="submit" class="transparent button" value="查询" />
    </div>
    <!--搜索条件部分-->
    <div class="divTable3">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    名称
                </th>
                <td>
                    <input name="prod_name" value='<%=Model.prod_name %>' type="text" class="text" />
                </td>
                <th>
                    型号
                </th>
                <td>
                    <input name="prod_type" value='<%=Model.prod_type %>' type="text" class="text" />
                </td>
                <th>
                    批次
                </th>
                <td>
                    <input name="prod_batch" value='<%=Model.prod_batch %>' type="text" class="text" />
                </td>
            </tr>
        </table>
    </div>
    <!--列表部分-->
    <div id="divList">
        <% PageHelper<CRM.Model.product> pagerHelper = ViewData["pagerHelper"] as PageHelper<CRM.Model.product>;
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
                    型号
                </th>
                <th>
                    批次/等级
                </th>
                <th>
                    单位
                </th>
                <th>
                    单价
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
                    <%=Html.Encode(item.prod_name) %>
                </td>
                <td>
                    <%=Html.Encode(item.prod_type) %>
                </td>
                <td>
                    <%=Html.Encode(item.prod_batch) %>
                </td>
                <td>
                    <%=Html.Encode(item.prod_unit) %>
                </td>
                <td>
                    <%=Html.Encode(item.prod_price) %>
                </td>
                <td>
                    <%=Html.Encode(item.prod_memo) %>
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
