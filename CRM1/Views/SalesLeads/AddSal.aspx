<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.sal_chance>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AddSal</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/Shared/Shared.js" type="text/javascript"></script>
</head>
<body>
    <!--标题部分-->
    <div id="divTitle">
        <span class="title"><a href='<%=Url.Action("Index") %>'>销售机会管理</a>&nbsp;>>&nbsp;添加销售机会</span><br />
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
                    <span class="keypoint">自动生成</span>
                </td>
                <th>
                    机会来源
                </th>
                <td>
                    <input name="chc_source" value='<%=Model.chc_source %>' type="text" class="text" />
                </td>
            </tr>
            <tr>
                <th>
                    客户名称
                </th>
                <td>
                    <input name="chc_cust_name" value='<%=Model.chc_cust_name %>' type="text" class="text firstFocus" />
                    <span class="keypoint">*</span>
                </td>
                <th>
                    成功几率(%)
                </th>
                <td>
                    <input name="chc_rate" value='<%=Model.chc_rate %>' type="text" class="text" />
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    概要
                </th>
                <td colspan="3">
                    <input name="chc_title" value='<%=Model.chc_title %>' type="text" class="text" />
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    联系人
                </th>
                <td>
                    <input name="chc_linkman" value='<%=Model.chc_linkman %>' type="text" class="text" />
                </td>
                <th>
                    联系电话
                </th>
                <td>
                    <input name="chc_tel" value='<%=Model.chc_tel %>' type="text" class="text" />
                </td>
            </tr>
            <tr>
                <th>
                    机会描述
                </th>
                <td colspan="3">
                    <textarea name="chc_desc"><%=Model.chc_desc %></textarea>
                    <span class="keypoint">*</span>
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
