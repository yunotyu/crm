<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Import Namespace="CRM.Web.Controllers" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AddPlan</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/SalesPlan/AddPlan.css" rel="stylesheet" type="text/css" />
    <link href="../../Scripts/PlugIn/IxEdit/IxEdit_Css/ui-sui.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/PlugIn/IxEdit/IxEdit_Js/jquery-ui-1.7.2.custom.min.js"
        type="text/javascript"></script>
    <script src="../../Scripts/Shared/Shared.js" type="text/javascript"></script>
    <script src="../../Scripts/SalesPlan/AddPlan.js" type="text/javascript"></script>
    <script type="text/javascript">
        function Save(button, id) {
            var todo = $(button).parent().prev().children("input").val();
            $.ajax({
                url: '<%=Url.Action("UpdateTodoPlan") %>',
                type: "POST",
                data: { pla_id: id, pla_todo: todo },
                dataType: "text",
                success: function (data) {
                    if (data == "ok") {
                        alert("修改成功");
                    }
                    else {
                        alert("修改失败，请重试！");
                    }
                }
            });
        }
        function Delete(planId) {
            if (confirm("确定要删除当前计划吗?")) {
                $.ajax({
                    url: '<%=Url.Action("DeletePlan") %>' + "/" + planId,
                    type: "get",
                    dataType: "text",
                    success: function (data) {
                        if (data == "ok") {
                            window.location.href = window.location.href + "?";
                        }
                        else {
                            alert("删除失败，请重试！");
                        }
                    }
                });
            }
        }
    </script>
</head>
<body>
    <!--标题部分开始-->
    <div id="divTitle">
        <span class="title"><a href='<%=Url.Action("Index") %>'>客户开发计划</a>&nbsp;>>&nbsp;修改计划</span><br />
        <hr />
    </div>
    <div id="divTitleH">
    </div>
    <!--标题部分结束-->
    <!--搜索条件或编辑列表部分-->
    <div class="divTable2">
        <%CRM.Model.sal_chance curSal = ViewData["curSal"] as CRM.Model.sal_chance; %>
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    编号
                </th>
                <td>
                    <span class="keypoint">
                        <%=curSal.chc_id %></span>
                </td>
                <th>
                    机会来源
                </th>
                <td>
                    <%=curSal.chc_source %>
                </td>
            </tr>
            <tr>
                <th>
                    客户名称
                </th>
                <td>
                    <%=curSal.chc_cust_name %>
                </td>
                <th>
                    成功几率(%)
                </th>
                <td>
                    <%=curSal.chc_rate %>
                </td>
            </tr>
            <tr>
                <th>
                    概要
                </th>
                <td colspan="3">
                    <%=curSal.chc_title %>
                </td>
            </tr>
            <tr>
                <th>
                    联系人
                </th>
                <td>
                    <%=curSal.chc_linkman %>
                </td>
                <th>
                    联系电话
                </th>
                <td>
                    <%=curSal.chc_tel %>
                </td>
            </tr>
            <tr>
                <th>
                    机会描述
                </th>
                <td colspan="3">
                    <%=curSal.chc_desc %>
                </td>
            </tr>
            <tr>
                <th>
                    创建人:
                </th>
                <td>
                    <%=curSal.chc_create_by%>
                </td>
                <th>
                    创建时间:
                </th>
                <td>
                    <%=curSal.chc_create_date%>
                </td>
            </tr>
            <tr>
                <th>
                    指派给:
                </th>
                <td>
                    <%=curSal.chc_due_to%>
                </td>
                <th>
                    指派时间:
                </th>
                <td>
                    <%=curSal.chc_due_date%>
                </td>
            </tr>
        </table>
    </div>
    <!--列表部分-->
    <div id="divList">
        <% PageHelper<CRM.Model.sal_plan> pagerHelper = ViewData["pagerHelper"] as PageHelper<CRM.Model.sal_plan>;
           if (pagerHelper.TotalCount == 0)
           {
        %>
        <!--没有任何数据-->
        <div class="nodata">
        </div>
        <%
           }
           else
           {
        %>
        <!--数据列表-->
        <table cellpadding="0" cellspacing="0">
            <tr class="tblHead">
                <th>
                    序号
                </th>
                <th>
                    日期
                </th>
                <th>
                    计划项
                </th>
                <th>
                    操作
                </th>
                <th>
                </th>
            </tr>
            <%
               int index = 1;
               foreach (var item in pagerHelper)
               {
            %>
            <tr class="tblItem">
                <td style="width: 50px;">
                    <%=index++ %>
                </td>
                <td style="width: 150px;">
                    <%=Html.Encode(item.pla_date) %>
                </td>
                <td style="width: 400px;">
                    <input type="text" value='<%=Html.Encode(item.pla_todo) %>' class="text" style="width: 400px;" />
                </td>
                <td style="width: 150px;">
                    <input type="button" onclick='Save(this,<%=Html.Encode(item.pla_id) %>);' value="保存"
                        class="button transparent" />
                    <input type="button" value="删除" onclick='Delete(<%=item.pla_id %>)' class="button transparent" />
                </td>
                <td style="width: auto;">
                </td>
            </tr>
            <%
               }
            %>
        </table>
        <%  } %>
    </div>
    <%Html.BeginForm(); %>
    <div class="divTable2 private">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th style="width: 80px;">
                    日期
                </th>
                <td style="width: 150px;">
                    <input type="text" name="pla_date" style="width: 100px;" class="text timer" />
                    <span class="keypoint">*</span>
                </td>
                <th style="width: 100px;">
                    计划项
                </th>
                <td style="width: 400px;">
                    <input type="text" value="" style="width:190px;" name="pla_todo" class="text" />
                    <span class="keypoint">*</span>
                    <input type="submit" value="确定" class="transparent button" />
                    <input type="button" onclick=javascript:window.location.href='<%=Url.Action("ExcutePlan") %>'+"/"+<%=curSal.chc_id %> value="执行计划" class="transparent button2" />
                    <input type="button" onclick=javascript:window.location.href='<%=Url.Action("Index") %>'; value="返回" class="transparent button" />
                </td>
            </tr>
        </table>
    </div>
    <%Html.EndForm(); %>
</body>
</html>
