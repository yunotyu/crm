<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error</title>
    <script type="text/javascript">
        /*定义一个时间变量，用于表示几秒后返回*/
        var sec = 5;
        /*数秒*/
        function RunTime() {
            if (sec == 0) {
                window.location.href = '<%=ViewData["backUrl"].ToString() %>';
            }
            else {
                document.getElementById("spanTime").innerHTML = sec;
                sec--;
                setTimeout(RunTime, 1000);
            }
        }
    </script>
</head>
<body onload="RunTime();">
    <div>
        错误消息:<span style="color: Red;"><%=ViewData["msg"].ToString() %></span><br />
        系统将在<span id="spanTime" style="color: Red"></span>秒后自动跳转，点击<a href='<%=ViewData["backUrl"].ToString() %>'>这里</a>立即跳转。
    </div>
</body>
</html>
