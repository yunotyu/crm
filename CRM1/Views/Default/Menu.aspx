<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Menu</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/Default/Menu.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/Shared/sdmenu.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $.ajax({
                url: '<%=Url.Action("Menu") %>',
                type: "post",
                dataType: "text",
                success: function (data) {
                    document.getElementById("my_menu").innerHTML = data;
                    var myMenu = new SDMenu("my_menu"); //注意：一定要在数据请求成功之后再去初始化控件
                    myMenu.init();
                }
            })
        })
    </script>
</head>
<%--<body oncontextmenu="return false;" leftmargin="2" topmargin="2" ms_positioning="GridLayout">--%>
<body>
    <div id="my_menu" class="sdmenu">
    </div>
</body>
</html>
