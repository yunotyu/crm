<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.sal_chance>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AllotSal</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/Shared/Shared.js" type="text/javascript"></script>
</head>
<body>
    <!--标题部分-->
    <div id="divTitle">
        <span class="title"><a href='<%=Url.Action("Index") %>'>销售机会管理</a>&nbsp;>>&nbsp;指派销售机会</span><br />
        <hr />
    </div>
    <div id="divTitleH"></div>
    <!--标题部分结束-->
    <!--搜索条件或编辑列表部分-->
    <%Html.BeginForm(); %>
    <div class="divTable2">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    编号
                </th>
                <td>
                    <%if (Model.chc_id > 0)
                      {%>
                    <span>
                        <%=Model.chc_id %></span>
                    <%}
                      else
                      {
                          throw new Exception("数据异常，请重试!");
                      } %>
                </td>
                <th>
                    机会来源
                </th>
                <td>
                    <%=Model.chc_source %>
                </td>
            </tr>
            <tr>
                <th>
                    客户名称
                </th>
                <td>
                    <%=Model.chc_cust_name %>
                </td>
                <th>
                    成功几率(%)
                </th>
                <td>
                    <%=Model.chc_rate %>
                </td>
            </tr>
            <tr>
                <th>
                    概要
                </th>
                <td colspan="3">
                    <%=Model.chc_title %>
                </td>
            </tr>
            <tr>
                <th>
                    联系人
                </th>
                <td>
                    <%=Model.chc_linkman %>
                </td>
                <th>
                    联系电话
                </th>
                <td>
                    <%=Model.chc_tel %>
                </td>
            </tr>
            <tr>
                <th>
                    机会描述
                </th>
                <td colspan="3">
                    <%=Model.chc_desc %>
                </td>
            </tr>
            <tr>
                <th>
                    创建人
                </th>
                <td>
                    <%=Model.chc_create_by %>
                </td>
                <th>
                    创建时间
                </th>
                <td>
                    <%=Model.chc_create_date %>
                </td>
            </tr>
        </table>
    </div>
    <div class="divTable2">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    指派给:
                </th>
                <td>
                    <%=Html.DropDownList("chc_due_id", ViewData["userList"] as SelectList,"--请选择--")%>
                    <span class="keypoint">*</span>
                </td>
                <th>
                    指派时间:
                </th>
                <td>
                    <span class="keypoint">当前时间</span>
                </td>
            </tr>
        </table>
    </div>
    <!--编辑后操作部分部分-->
    <div id="divControlEnd">
        <input type="submit" value="保存" class="transparent button" />
        <input type="reset" value="重置" class="transparent button" />
        <input type="button" onclick=javascript:window.location.href='<%=Url.Action("Index") %>'; value="返回" class="transparent button" />
    </div>
    <%Html.EndForm(); %>
</body>
</html>
