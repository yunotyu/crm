<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.ViewModels.Chance_Plan_ViewModel>" %>

<%@ Import Namespace="CRM.Web.Controllers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Index</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="/Styles/EasyUiCss/themes/default/easyui.css"/>
    <link rel="stylesheet" type="text/css" href="/Styles/EasyUiCss/themes/icon.css"/>
    <script src="../../Scripts/Shared/jquery-3.5.1.js" type="text/javascript"></script>
    <script src="../../Scripts/Shared/Shared.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.easyui.min.js" type="text/javascript"></script>
</head>
<body>
    <!--标题部分-->
    <div id="divTitle">
        <span class="title">客户开发计划</span><br />
        <hr />
    </div>
    <div id="divTitleH"></div>
    <!--标题部分结束-->
    <%Html.BeginForm("Index", "SalesPlan", FormMethod.Post, new { id = "form1" }); %>
    <!--表头操作部分-->
    <div id="divListTop">
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
                    <input name="chc_cust_name" type="text" class="text" value="<%=Model.Chc_Cust_Name %>"/>
                </td>
                <th>
                    概要
                </th>
                <td>
                    <input name="chc_title" type="text" class="text" value="<%=Model.Chc_Title %>" />
                </td>
                <th>
                    联系人
                </th>
                <td>
                    <input name="chc_linkman" type="text" class="text" value="<%=Model.Chc_Linkman %>"/>
                </td>
                <th>
                    计划日期
                </th>
                 <td>
                     <div style="display: inline-block">
                         开始日期:<input  name="start_pla_date"class="easyui-datebox" value="<%=Model.Start_Pla_Date %>"/><br/>
                         结束日期:<input  name="end_pla_date"class="easyui-datebox" value="<%=Model.End_Pla_Date %>" />
                     </div>
                </td>
            </tr>
        </table>
    </div>
    <!--列表部分-->
    <div id="divList">
        <% PageHelper<CRM.Model.sal_plan> pagerHelper = ViewData["pagerHelper"] as PageHelper<CRM.Model.sal_plan>;
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
                    对应的客户名
                </th>
                <th>
                    计划日期
                </th>
                <th>
                    计划内容
                </th>
                <th>
                    执行结果
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
                    <%=Html.Encode(item.sal_chance.chc_cust_name) %>
                </td>
                <td>
                    <%=Html.Encode(item.pla_date) %>
                </td>
                <td>
                    <%=Html.Encode(item.pla_todo) %>
                </td>
                <td>
                    <%=Html.Encode(item.pla_result) %>
                </td>
                
                <td>
                    <a href='<%=Url.Action("PlanInfo") %>/<%=Html.Encode(item.pla_id) %>'>
                        <img src="../../Images/ico/bt_detail.gif" title="查看详细计划" alt="制定计划" class="imgLink" />
                    </a>
                    <%if ((Session["user"] as CRM.Model.sys_user).usr_role_id == 2|| (Session["user"] as CRM.Model.sys_user).usr_role_id == 5)
                      { %>
                    <a href='<%=Url.Action("AddPlan") %>/<%=Html.Encode(item.pla_id) %>'>
                        <img src="../../Images/ico/bt_plan.gif" title="制定计划" alt="制定计划" class="imgLink" />
                    </a>
                    <%} %>
                    <%if ((Session["user"] as CRM.Model.sys_user).usr_role_id == 2||(Session["user"] as CRM.Model.sys_user).usr_role_id == 5)
                      {%>
                    <a href='<%=Url.Action("ExcutePlan") %>/<%=Html.Encode(item.pla_id) %>'>
                        <img src="../../Images/ico/bt_feedback.gif" title="执行计划"  alt="执行计划" class="imgLink" />
                    </a>
                    <%} %>
                    <%if (item.sal_chance.chc_create_id == (Session["user"] as CRM.Model.sys_user).usr_id || (Session["user"] as CRM.Model.sys_user).usr_role_id == 2|| (Session["user"] as CRM.Model.sys_user).usr_role_id == 5)
                      { %>
                    <a href='<%=Url.Action("PlanOk") %>/<%=Html.Encode(item.pla_id) %>'>
                        <img src="../../Images/ico/bt_yes.gif" title="开发成功" class="imgLink" />
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
