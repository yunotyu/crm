<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.cst_service>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ServiceCreation</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/Shared/Shared.js" type="text/javascript"></script>
</head>
<body>
    <!--标题部分-->
    <div id="divTitle">
        <span class="title">客户服务创建</span><br />
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
                    <span class="keypoint">自动生成</span>
                </td>
                <th>
                    服务类型
                </th>
                <td>
                    <%=Html.DropDownList("svr_type", ViewData["serviceType"] as SelectList, "--请选择--")%>
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    概要
                </th>
                <td colspan="3">
                    <input name="svr_title" style="width:400px;" value='<%=Model.svr_title %>' type="text" class="text" />
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    客户
                </th>
                <td>
                    <input name="svr_cust_name" value='<%=Model.svr_cust_name %>' type="text" class="text" />
                    <span class="keypoint">*</span>
                </td>
                <th>
                    状态
                </th>
                <td>
                    <span class="keypoint">新创建</span>
                </td>
            </tr>
            <tr>
                <th>
                    客户请求
                </th>
                <td colspan="3">
                    <textarea name="svr_request"><%=Model.svr_request%></textarea>
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    创建人
                </th>
                <td>
                    <span>
                        <%=Html.Encode((Session["user"] as CRM.Model.sys_user).usr_name) %></span>
                </td>
                <th>
                    创建时间
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
    </div>
    <%Html.EndForm(); %>
</body>
</html>
