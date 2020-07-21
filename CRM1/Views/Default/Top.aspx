<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.sys_user>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Top</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/Default/Top.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/Shared/MoveTime.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Logout() {
            $.ajax({
                url: '<%=Url.Action("LogOut") %>',
                type: "get",
                success: function (data) {
                    if (data == "ok") {
                        window.parent.location.href = '<%=Url.Action("Login","Shared") %>';
                    }
                    else {
                        alert("系统繁忙，请稍后再试!");
                    }
                }
            });
        }
        function ShutDown() {
            $.ajax({
                url: '<%=Url.Action("LogOut") %>',
                type: "get",
                success: function (data) {
                    if (data == "ok") {
                        window.onunload;
                    }
                    else {
                        alert("系统繁忙，请稍后再试!");
                    }
                }
            });
        }
    </script>
</head>
<body onload="getCurrentTime('spanCurTime',0);">
    <div id="divBg">
        <div id="divLogo">
        </div>
        <span id="prjTitle">客户关系管理系统</span>
        <div id="divControl">
            <a href="javascript:Logout();">注销</a>&nbsp;|&nbsp;<a href="javascript:ShutDown();">安全退出</a>
        </div>
    </div>
    <div id="divWelcome">
        <span id="loginRole">欢迎
            <%=Html.Encode(Model.sys_role.role_name) %>：<%=Html.Encode(Model.usr_name) %></span>
        <span id="spanCurTime" style="float:right; padding-right:10px;"></span>
    </div>
</body>
</html>
