<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/Shared/Login.css" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/PlugIn/formValidator/validator.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/PlugIn/formValidator/jquery_last.js" type="text/javascript"></script>
    <script src="../../Scripts/PlugIn/formValidator/formValidatorRegex.js" type="text/javascript"></script>
    <script src="../../Scripts/PlugIn/formValidator/formValidator_min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function RefreshValiCode(obj) {
            obj.src = obj.src + "?";
            $("#valicode").select();
        }
        $(function () {
            $("#usr_name").select();
        });
    </script>
</head>
<body>
    <%Html.BeginForm("Login", "Shared", FormMethod.Post, new { id = "form1" }); %>
    <div id="login_panel">
        <div id="top">
        </div>
        <div id="middle">
            <div id="left">
            </div>
            <div id="center">
                <table id="tblLogin">
                    <tr>
                        <td>
                            用户名:
                        </td>
                        <td>
                            <%=Html.TextBox("usr_name", "yfr", new {style = "background: url(../../Images/Login/user_login_name.gif) no-repeat;"  })%>
                        </td>
                        <td>
                            <div id="usr_nameTip">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            密 码:
                        </td>
                        <td>
                            <%=Html.Password("usr_pwd", "123", new { style = "background: url(../../Images/Login/user_login_password.gif) no-repeat;" })%>
                        </td>
                        <td>
                            <div id="usr_pwdTip">
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            验证码:
                        </td>
                        <td>
                            <%=Html.TextBox("valicode", "", new {style="background: url(../../Images/Login/user_login_validatecode.gif) no-repeat; width: 66px;" })%>
                            <img onclick="RefreshValiCode(this)" src='<%=Url.Action("GetValicodeImage") %>' alt="看不清楚" />
                        </td>
                        <td>
                            <div id="valicodeTip">
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="right">
                <div id="r_top">
                    <input type="submit" class="transparent" value="" />
                </div>
                <div id="r_right">
                </div>
                <div id="r_buttom">
                </div>
            </div>
        </div>
        <div id="buttom">
            <div class="left">
            </div>
            <div class="right">
            </div>
        </div>
    </div>
    <%--<div id="divShow" style="display:none;">
    <img src="../Images/Shared/loading.gif" style="vertical-align:middle" />&nbsp;登录中，请稍后....
    </div>--%>
    <%Html.EndForm(); %>
</body>
</html>
