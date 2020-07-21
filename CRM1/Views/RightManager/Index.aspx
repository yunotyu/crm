<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<%@ Import Namespace="CRM.Web.Controllers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Index</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/Shared/Shared.js" type="text/javascript"></script>
    <script type="text/javascript">
        function newWindow(args) {
            var strUrl = '<%=Url.Action("Update") %>/' + args;
            window.location.href = strUrl;
        }
    </script>
</head>
<body>
    <%Html.BeginForm("Index", "RightManager", FormMethod.Post, new {id="form1" }); %>
    <!--标题部分-->
    <div id="divTitle">
        <span class="title">权限管理</span><br />
        <hr />
    </div>
    <div id="divTitleH"></div>
    <!--标题部分结束-->
    <!--列表部分-->
    <div id="divList">
        <% PageHelper<CRM.Model.sys_user> pagerHelper = ViewData["pagerHelper"] as PageHelper<CRM.Model.sys_user>;
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
                    用户名称
                </th>
                <th>
                    角色名称
                </th>
                <th>
                    角色描述
                </th>
                <th>
                    操作
                </th>
            </tr>
            <%
               foreach (var item in pagerHelper)
               {
            %>
            <tr class="tblItem">
                <td>
                    <%=Html.Encode(item.usr_name) %>
                </td>
                <td>
                    <%=Html.Encode(item.sys_role.role_name) %>
                </td>
                <td>
                    <%=Html.Encode(item.sys_role.role_desc) %>
                </td>
                <td>
                    <a href='javascript:newWindow(<%=item.usr_id %>)'>权限分配</a>
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
        <input type="hidden" id="inputCurPage" name="curPage" />
        <%=pagerHelper.PagerHtmlA %>
    </div>
    <%Html.EndForm(); %>
</body>
</html>
