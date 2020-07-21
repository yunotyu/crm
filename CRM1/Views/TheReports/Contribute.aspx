<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.orders>" %>

<%@ Import Namespace="CRM.Web.Controllers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Contribute</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/PlugIn/amcharts_2.5.5/amcharts/amcharts.js" type="text/javascript"></script>
    <script src="../../Scripts/PlugIn/amcharts_2.5.5/amcharts/raphael.js" type="text/javascript"></script>
    <script src="../../Scripts/Shared/Shared.js" type="text/javascript"></script>
    <script type="text/javascript">
        AmCharts.ready(function () {
            chart = new AmCharts.AmPieChart(); //实例化
            chart.dataProvider = eval('<%=ViewData["reportData"].ToString()%>'); //数据源
            chart.titleField = "Name"; //标题
            chart.valueField = "TotalMoney"; //值
            chart.outlineColor = "#FFFFFF"; //边框颜色
            chart.outlineAlpha = 0.8;
            chart.outlineThickness = 2;
            chart.depth3D = 15; //厚度
            chart.angle = 30;
            chart.write("divReport");
        });
    </script>
</head>
<body>
    <!--标题部分-->
    <div id="divTitle">
        <span class="title">客户贡献分析</span><br />
        <hr />
    </div>
    <div id="divTitleH">
    </div>
    <!--标题部分结束-->
    <%Html.BeginForm("Contribute", "TheReports", FormMethod.Post, new { id = "form1" }); %>
    <!--表头操作部分-->
    <div id="divListTop">
        <input type="button" class="transparent button2" value="导出Excel" />
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
                    <input name="odr_cust_name" value='<%=Model.odr_cust_name %>' type="text" class="text" />
                </td>
                <th>
                    年份
                </th>
                <td>
                <%=Html.DropDownList("odr_id", ViewData["years"] as SelectList)%>
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
        <% PageHelper<CRM.Model.ContributeReportModel> pagerHelper = ViewData["pagerHelper"] as PageHelper<CRM.Model.ContributeReportModel>;
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
                    订单总金额(万元)
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
                    <%=Html.Encode(item.Name) %>
                </td>
                <td>
                    <%=Html.Encode(item.TotalMoney) %>
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
    <div id="divReport">
    </div>
</body>
</html>
