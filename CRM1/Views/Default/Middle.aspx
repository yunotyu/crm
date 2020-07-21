<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Middle</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/Default/Middle.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var isShow = true;
        $(function () {
            $("#tdControl").click(function () {
                if (isShow) {
                    $("#tdMenu").hide();
                    document.getElementById("imgControl").src = "../../Images/Middle/ArrowToRightOut.gif";
                } else {
                    $("#tdMenu").show();
                    document.getElementById("imgControl").src = "../../Images/Middle/ArrowToLeftOut.gif";
                }
                isShow = !isShow;
            });
        });
    </script>
</head>
<body>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td id="tdMenu">
                <div id="divMenu">
                    <iframe id="ifrmLeft" src="menu" scrolling="no" frameborder="0"></iframe>
                </div>
            </td>
            <td id="tdControl">
                点 击 这 里
                <img id="imgControl" alt="隐藏菜单" src="../../Images/Middle/ArrowToLeftOut.gif" />
                隐 藏 或 展 开 目 录
            </td>
            <td id="tdMain">
                <iframe id="ifrmRight" name="main" src="main" scrolling="auto" frameborder="0"></iframe>
            </td>
        </tr>
    </table>
</body>
</html>
