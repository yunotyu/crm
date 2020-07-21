<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.bas_dict>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Add</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/CustomerManager/UpdateLinkMan.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/Shared/Shared.js" type="text/javascript"></script>
</head>
<body>
    <!--标题部分-->
    <div id="divTitle">
        <span class="title"><a href='<%=Url.Action("Index") %>'>数据字典管理</a>&nbsp;>>&nbsp;数据字典添加</span><br />
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
                    编号
                </th>
                <td style="width:150px;">
                <span class="keypoint">自动生成</span>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <th>
                    类别
                </th>
                <td>
                    <input type="text" class="text" name="dict_type" value='<%=Model.dict_type %>' />
                </td>
                <td>
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    条目
                </th>
                <td>
                    <input type="text" class="text" name="dict_item" value='<%=Model.dict_item %>' />
                </td>
                <td>
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    值
                </th>
                <td>
                    <input type="text" class="text" name="dict_value" value='<%=Model.dict_value %>' />
                </td>
                <td>
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    允许编辑
                </th>
                <td>
                    <%if (Model.dict_is_editable ==0)
                      { %>
                    <input id="editB" type="radio" name="dict_is_editable" value="1" /><label for="editB" style="color:Green;">√</label>
                    <input id="editA" type="radio" name="dict_is_editable" value="0" checked="checked" /><label
                        for="editA" class="keypoint">×</label>
                    <%}
                      else
                      { %>
                    <input id="editB" type="radio" name="dict_is_editable" value="1" checked="checked" /><label for="editB" style="color:Green;">√</label>
                    <input id="editA" type="radio" name="dict_is_editable" value="0"  /><label
                        for="editA" class="keypoint">×</label>
                    <%} %>
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
        <input type="button" onclick=javascript:window.location.href='<%=Url.Action("Index") %>'; value="返回" class="transparent button" />
    </div>
    <%Html.EndForm(); %>
</body>
</html>
