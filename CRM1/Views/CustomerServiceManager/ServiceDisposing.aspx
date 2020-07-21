<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.cst_service>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ServiceDisposing</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/Shared/Shared.js" type="text/javascript"></script>
</head>
<body>
    <!--标题部分-->
    <div id="divTitle">
        <span class="title">客户服务处理</span><br />
        <hr />
    </div>
    <div id="divTitleH">
    </div>
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
                    <span class="keypoint">
                        <%=Html.Encode(Model.svr_id) %></span>
                </td>
                <th>
                    服务类型
                </th>
                <td>
                    <%=Html.Encode(Model.svr_type) %>
                </td>
            </tr>
            <tr>
                <th>
                    概要
                </th>
                <td colspan="3">
                    <%=Html.Encode(Model.svr_title) %>
                </td>
            </tr>
            <tr>
                <th>
                    客户
                </th>
                <td>
                    <%=Html.Encode(Model.svr_cust_name) %>
                </td>
                <th>
                    状态
                </th>
                <td>
                    <%=Html.Encode(Model.svr_status) %>
                </td>
            </tr>
            <tr>
                <th>
                    客户请求
                </th>
                <td colspan="3">
                    <%=Html.Encode(Model.svr_request) %>
                </td>
            </tr>
            <tr>
                <th>
                    创建人
                </th>
                <td>
                    <%=Html.Encode(Model.svr_create_by) %>
                </td>
                <th>
                    创建时间
                </th>
                <td>
                    <%=Html.Encode(Model.svr_create_date) %>
                </td>
            </tr>
        </table>
    </div>
    <div class="divTable2">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    分配给:
                </th>
                <td>
                    <%=Html.Encode(Model.svr_due_to) %>
                </td>
                <th>
                    分配时间:
                </th>
                <td>
                    <%=Html.Encode(Model.svr_due_date) %>
                </td>
            </tr>
        </table>
    </div>
    <div class="divTable2">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    服务处理:
                </th>
                <td colspan="3">
                    <textarea name="svr_deal"><%=Model.svr_deal %></textarea>
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    处理人:
                </th>
                <td>
                <%=Html.Encode((Session["user"] as CRM.Model.sys_user).usr_name) %>
                </td>
                <th>
                    处理时间:
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
        <input type="button" onclick=javascript:window.location.href='<%=Url.Action("ServiceDispose") %>'; value="返回" class="transparent button" />
    </div>
    <%Html.EndForm(); %>
</body>
</html>
