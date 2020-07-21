<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.cst_linkman>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>AddLinkMan</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/CustomerManager/UpdateLinkMan.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/Shared/Shared.js" type="text/javascript"></script>
</head>
<body>
    <!--标题部分-->
    <div id="divTitle">
        <span class="title"><a href='<%=Url.Action("Index") %>'>客户信息管理</a>&nbsp;>>&nbsp;联系人添加</span><br />
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
                    姓名
                </th>
                <td style="width:150px;">
                    <input name="lkm_name" type="text" value='<%=Model.lkm_name %>' class="text" />
                </td>
                <td>
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    性别
                </th>
                <td>
                    <%if (Model.lkm_sex == "男")
                      { %>
                    <input id="sexA" type="radio" name="lkm_sex" value="男" checked="checked" /><label
                        for="sexA">男</label>
                    <input id="sexB" type="radio" name="lkm_sex" value="女" /><label for="sexB">女</label>
                    <%}
                      else
                      { %>
                    <input id="sexA" type="radio" name="lkm_sex" value="男" /><label for="sexA">男</label>
                    <input id="sexB" type="radio" name="lkm_sex" value="女" checked="checked" /><label
                        for="sexB">女</label>
                    <%} %>
                </td>
                <td>
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    职位
                </th>
                <td>
                    <input type="text" class="text" name="lkm_postion" value='<%=Model.lkm_postion %>' />
                </td>
                <td>
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    办公电话
                </th>
                <td>
                    <input type="text" class="text" name="lkm_tel" value='<%=Model.lkm_tel %>' />
                </td>
                <td>
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    手机
                </th>
                <td>
                    <input type="text" class="text" name="lkm_mobile" value='<%=Model.lkm_mobile %>' />
                </td>
                <td>
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    备注
                </th>
                <td>
                    <input type="text" class="text" name="lkm_memo" value='<%=Model.lkm_memo %>' />
                </td>
                <td>
                    <span class="keypoint">*</span>
                </td>
            </tr>
        </table>
    </div>
    <!--编辑后操作部分部分-->
    <div id="divControlEnd">
        <input type="submit" value="保存" class="transparent button" />
        <input type="reset" value="重置" class="transparent button" />
        <input type="button" onclick=javascript:window.location.href='<%=Url.Action("LinkMan",new{id=ViewData["cst_id"].ToString()}) %>'; value="返回" class="transparent button" />
    </div>
    <%Html.EndForm(); %>
</body>
</html>
