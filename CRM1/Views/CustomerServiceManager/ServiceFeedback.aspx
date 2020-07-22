<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.cst_service>" %>

<%@ Import Namespace="CRM.Web.Controllers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ServiceFeedback</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/PlugIn/IxEdit/IxEdit_Css/ui-sui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/PlugIn/IxEdit/IxEdit_Js/jquery-ui-1.7.2.custom.min.js"
        type="text/javascript"></script>
    <script src="../../Scripts/Shared/Shared.js" type="text/javascript"></script>
</head>
<body>
    <!--标题部分-->
    <div id="divTitle">
        <span class="title">客户服务反馈</span><br />
        <hr />
    </div>
    <div id="divTitleH">
    </div>
    <!--标题部分结束-->
    <%Html.BeginForm("ServiceFeedback", "CustomerServiceManager", FormMethod.Post, new { id = "form1" }); %>
    <!--表头操作部分-->
    <div id="divListTop">
        <input type="submit" class="transparent button" value="查询" />
    </div>
    <!--搜索条件或编辑列表部分-->
    <div class="divTable3">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    客户
                </th>
                <td>
                    <%=Html.DropDownList("svr_cust_name", ViewData["cst_name"] as List<SelectListItem>, "--请选择--")%>
                </td>
                <th>
                    概要
                </th>
                <td>
                    <input name="svr_title" value='<%=Model.svr_title %>' type="text" class="text" />
                </td>
                <th>
                    服务类型
                </th>
                <td>
                    <%=Html.DropDownList("svr_type", ViewData["serviceType"] as SelectList, "--请选择--")%>
                </td>
            </tr>
            <tr>
                <th>
                    创建时间
                </th>
                <td colspan="3">
                    <input type="text" name="date1" style="width:100px;" class="text timer" value='<%=Html.Encode(ViewData["date1"].ToString()) %>' />
                    -
                    <input type="text" name="date2" style="width:100px;" class="text timer"  value='<%=Html.Encode(ViewData["date2"].ToString()) %>'/>
                </td>
                <th>
                    状态
                </th>
                <td>
                    <span class="keypoint">已处理</span>
                </td>
            </tr>
        </table>
    </div>
    <!--列表部分-->
    <div id="divList">
        <% PageHelper<CRM.Model.cst_service> pagerHelper = ViewData["pagerHelper"] as PageHelper<CRM.Model.cst_service>;
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
                    服务类型
                </th>
                <th>
                    创建人
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
                    <%=Html.Encode(item.svr_cust_name) %>
                </td>
                <td>
                    <%=Html.Encode(item.svr_title) %>
                </td>
                <td>
                    <%=Html.Encode(item.svr_type) %>
                </td>
                <td>
                    <%=Html.Encode(item.svr_create_by) %>
                </td>
                <td>
                    <%=Html.Encode(item.svr_create_date) %>
                </td>
                <td>
                    <a href='<%=Url.Action("ServiceFeedbacking") %>/<%=Html.Encode(item.svr_id) %>'>
                        <img src="../../Images/ico/bt_feedback.gif" title="处理"  class="imgLink" />
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
