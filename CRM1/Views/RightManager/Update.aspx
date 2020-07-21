<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.sys_user>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/RightManager/Update.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("legend input").click(function () {
                $(this).parent().nextAll("input").attr("checked", $(this).attr("checked"));
            });
            $("legend").nextAll("input").click(function () {
                if ($(this).attr("checked")) {
                    $(this).prevAll("legend").children("input").attr("checked", "checked");
                }
                else if ($(this).siblings("input:checked").length == 0) {
                    $(this).prevAll("legend").children("input").removeAttr("checked");
                }
            });
        });
    </script>
</head>
<body>
    <%Html.BeginForm(); %>
    <!--标题部分-->
    <div id="divTitle">
        <span class="title">分配权限>></span> &nbsp;[当前用户:&nbsp; <span class="keypoint">
            <%=Model.usr_name %></span>&nbsp; 角色:&nbsp; <span class="keypoint">
                <%=Model.sys_role.role_name %></span>]
        <br />
        <hr />
    </div>
    <div id="divTitleH"></div>
    <!--标题部分结束-->
    <!--分配权限部分-->
    <div>
        <%List<CRM.Model.sys_right> allList = ViewData["allList"] as List<CRM.Model.sys_right>;
          List<CRM.Model.sys_right> curList = ViewData["curList"] as List<CRM.Model.sys_right>;

          foreach (var parentItem in allList.Where(r => r.right_parent_code == "001").ToList())
          {
        %>
        <fieldset>
            <legend>
                <% if (curList.Where(r => r.right_parent_code == parentItem.right_code).Count() > 0)
                   {
                %>
                <input id='<%=parentItem.right_code %>' name='<%=parentItem.right_code %>' type="checkbox" value='<%=parentItem.right_code %>'
                    checked="checked" />
                <% }
                   else
                   { 
                %>
                <input id='<%=parentItem.right_code %>' name='<%=parentItem.right_code %>' type="checkbox" value='<%=parentItem.right_code %>' />
                <%
                   }
                %><label for='<%=parentItem.right_code %>'><%=parentItem.right_text %></label>
            </legend>
            <%
              foreach (var childItem in allList.Where(r => r.right_parent_code == parentItem.right_code).ToList())
              {
                  if (curList.Where(r => r.right_code == childItem.right_code).Count() > 0)
                  {
            %>
            <input id='<%=childItem.right_code %>' name='<%=childItem.right_code %>' type="checkbox" value='<%=childItem.right_code %>'
                checked="checked" />
            <%
                  }
                  else
                  { 
            %>
            <input id='<%=childItem.right_code %>' name='<%=childItem.right_code %>' type="checkbox" value='<%=childItem.right_code %>' />
            <%
                  }
            %>
            <label for='<%=childItem.right_code %>'>
                <%=Html.Encode(childItem.right_text) %></label>
            <%
              }
            %>
        </fieldset>
        <%
          } 
        %>
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
