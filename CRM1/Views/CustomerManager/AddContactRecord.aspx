<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.cst_activity>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>AddContactRecord</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/CustomerManager/AddContactRecord.css" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/PlugIn/IxEdit/IxEdit_Css/ui-sui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/PlugIn/IxEdit/IxEdit_Js/jquery-ui-1.7.2.custom.min.js"
        type="text/javascript"></script>
    <script src="../../Scripts/Shared/Shared.js" type="text/javascript"></script>
</head>
<body>
    <!--标题部分-->
    <div id="divTitle">
        <span class="title"><a href='<%=Url.Action("Index") %>'>客户信息管理</a>&nbsp;>>&nbsp;交往记录添加</span><br />
        <hr />
    </div>
    <div id="divTitleH">
    </div>
    <!--标题部分结束-->
    <%Html.BeginForm(); %>
    <!--搜索条件或编辑列表部分-->
    <div class="divTable">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    日期
                </th>
                <td style="width:150px;">
                    <input name="atv_date" type="text" value='<%=Model.atv_date %>' class="text timer" style="width:200px; float:left;" />
                </td>
                <td>
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    地点
                </th>
                <td>
                    <input type="text" name="atv_place" value='<%=Model.atv_place %>' class="text" />
                </td>
                <td>
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    概要
                </th>
                <td>
                    <input type="text" class="text" name="atv_title" value='<%=Model.atv_title %>' />
                </td>
                <td>
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    详细信息
                </th>
                <td>
                    <input type="text" class="text" name="atv_desc" value='<%=Model.atv_desc %>' />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <th>
                    备注
                </th>
                <td>
                    <input type="text" class="text" name="aty_remark" value='<%=Model.aty_remark %>' />
                </td>
                <td>
                </td>
            </tr>
        </table>
        <input type="hidden" name="id" value="<%=ViewData["cst_no"] %>" />
    </div>
    <!--编辑后操作部分部分-->
    <div id="divControlEnd">
        <input type="submit" value="保存" class="transparent button" />
        <input type="reset" value="重置" class="transparent button" />
        <input type="button" onclick=javascript:window.location.href='<%=Url.Action("ContactRecord",new{id=ViewData["cst_no"].ToString()}) %>'; value="返回" class="transparent button" />
    </div>
    <%Html.EndForm(); %>
</body>
</html>
