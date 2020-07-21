<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<CRM.Model.cst_customer>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update</title>
    <link href="../../Styles/Shared/Shared.css" rel="stylesheet" type="text/css" />
    <script src="../../Scripts/Shared/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../../Scripts/Shared/Shared.js" type="text/javascript"></script>
</head>
<body>
    <!--标题部分-->
    <div id="divTitle">
        <span class="title"><a href='<%=Url.Action("Index") %>'>客户信息管理</a>&nbsp;>>&nbsp;客户信息编辑</span><br />
        <hr />
    </div>
    <div id="divTitleH">
    </div>
    <!--标题部分结束-->
    <%Html.BeginForm(); %>
    <!--搜索条件或编辑列表部分-->
    <div class="divTable2">

        <input name="cust_Id" value='<%=Model.cust_Id %>' type="hidden" />
        <input name="cust_no" value='<%=Model.cust_no %>' type="hidden" />
        <input name="cust_status" value='<%=Model.cust_status %>' type="hidden" />

        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    客户编号
                </th>
                <td>
                    <span class="keypoint">
                        <%=Model.cust_no %></span>
                </td>
                <th>
                    客户名称
                </th>
                <td>
                    <input name="cust_name" value='<%=Model.cust_name %>' type="text" class="text" />
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    地区
                </th>
                <td>
                    <%=Html.DropDownList("cust_region", ViewData["region"] as SelectList, "--请选择--")%>
                    <span class="keypoint">*</span>
                </td>
                <th>
                    客服经理
                </th>
                <td>
                    <%=Html.DropDownList("cust_manager_id", ViewData["sys_user"] as SelectList, "--请选择--")%>
                    <%--<%=Html.DropDownListFor(m=>m.cust_manager_id.Value, ViewData["sys_user"] as SelectList) %>--%>
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    客户等级
                </th>
                <td>
                    <%=Html.DropDownList("cust_level", ViewData["level"] as SelectList, "--请选择--")%>
                    <span class="keypoint">*</span>
                </td>
                <th>
                </th>
                <td>
                </td>
            </tr>
            <tr>
                <th>
                    客户满意度
                </th>
                <td>
                    <%=Html.DropDownList("cust_satisfy", ViewData["satisfy"] as SelectList, "--请选择--")%>
                    <span class="keypoint">*</span>
                </td>
                <th>
                    客户信用度
                </th>
                <td>
                    <%=Html.DropDownList("cust_credit", ViewData["credit"] as SelectList, "--请选择--")%>
                    <span class="keypoint">*</span>
                </td>
            </tr>
        </table>
    </div>
    <!--搜索条件或编辑列表部分-->
    <div class="divTable2">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    地址
                </th>
                <td>
                    <input name="cust_addr" value='<%=Model.cust_addr %>' type="text" class="text" />
                    <span class="keypoint">*</span>
                </td>
                <th>
                    邮政编码
                </th>
                <td>
                    <input name="cust_zip" value='<%=Model.cust_zip %>' type="text" class="text" />
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    电话
                </th>
                <td>
                    <input name="cust_tel" value='<%=Model.cust_tel %>' type="text" class="text firstFocus" />
                    <span class="keypoint">*</span>
                </td>
                <th>
                    传真
                </th>
                <td>
                    <input name="cust_fax" value='<%=Model.cust_fax %>' type="text" class="text" />
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    网址
                </th>
                <td colspan="3">
                    <input name="cust_website" value='<%=Model.cust_website %>' type="text" class="text" />
                    <span class="keypoint">*</span>
                </td>
            </tr>
        </table>
    </div>
    <!--搜索条件或编辑列表部分-->
    <div class="divTable2">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <th>
                    营业执照注册号
                </th>
                <td>
                    <input name="cust_licence_no" value='<%=Model.cust_licence_no %>' type="text" class="text" />
                </td>
                <th>
                    法人
                </th>
                <td>
                    <input name="cust_chieftain" value='<%=Model.cust_chieftain%>' type="text"
                        class="text" />
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    注册资金（万元）
                </th>
                <td>
                    <input name="cust_bankroll" value='<%=Model.cust_bankroll %>' type="text" class="text" />
                </td>
                <th>
                    年营业额
                </th>
                <td>
                    <input name="cust_turnover" value='<%=Model.cust_turnover %>' type="text" class="text" />
                </td>
            </tr>
            <tr>
                <th>
                    开户银行
                </th>
                <td>
                    <input name="cust_bank" value='<%=Model.cust_bank %>' type="text" class="text" />
                    <span class="keypoint">*</span>
                </td>
                <th>
                    银行帐号
                </th>
                <td>
                    <input name="cust_bank_account" value='<%=Model.cust_bank_account %>' type="text"
                        class="text" />
                    <span class="keypoint">*</span>
                </td>
            </tr>
            <tr>
                <th>
                    地税登记号
                </th>
                <td>
                    <input name="cust_local_tax_no" value='<%=Model.cust_local_tax_no %>' type="text"
                        class="text" />
                </td>
                <th>
                    国税登记号
                </th>
                <td colspan="3">
                    <input name="cust_national_tax_no" value='<%=Model.cust_national_tax_no %>' type="text"
                        class="text" />
                </td>
            </tr>
        </table>
    </div>
    
    <!--编辑后操作部分部分-->
    <div id="divControlEnd">
        <input type="submit" value="保存" class="transparent button" />
        <input type="reset" value="重置" class="transparent button" />
        <input type="button" onclick=javascript:window.location.href='<%=Url.Action("LinkMan",new{id=Model.cust_Id}) %>'; value="联 系 人" class="transparent button2" />
        <input type="button" onclick=javascript:window.location.href='<%=Url.Action("ContactRecord",new{id=Model.cust_Id}) %>'; value="交往记录" class="transparent button2" />
        <input type="button" onclick=javascript:window.location.href='<%=Url.Action("OrderHistory",new{id=Model.cust_no}) %>'; value="历史订单" class="transparent button2" />
        <input type="button" onclick=javascript:window.location.href='<%=Url.Action("Index") %>'; value="返回" class="transparent button" />
    </div>
    <%Html.EndForm(); %>
</body>
</html>
