/// <reference path="jquery-1.4.1.min.js" />
function pagerSubmit(curPage) {
    /// <summary>post分页</summary>    
    /// <param name="curPage" type="int">当前页码</param>
    $("#inputCurPage").val(curPage);
    $("#form1").submit();
}

$(function () {
    var bg
    $(".tblItem:even").css("background", "#ECF5FE").css("color", "#333333");
    $(".tblItem:odd").css("background", "#FFFFFF").css("color", "#284775");
    $(".tblItem").mouseover(function () {
        bg = $(this).css("background");
        $(this).css("background", "#C8E5FE");
    }).mouseout(function () {
        $(this).css("background", bg);
    });
    $(".firstFocus").focus();
    $("input").focus(function () {
        $(this).select();
    });
    $("textarea").focus(function () {
        $(this).select();
    });
    $(".timer").datepicker({ dateFormat: 'yy-mm-dd',
        dayNamesMin: ['日', '一', '二', '三', '四', '五', '六'],
        dayNamesShort: ['星期日', '星期一', '星期二', '星期三', '星期四', '星期五', '星期六'],
        monthNames: ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月'],
        monthNamesShort: ['一月', '二月', '三月', '四月', '五月', '六月', '七月', '八月', '九月', '十月', '十一月', '十二月'],
        showOn: 'button', showButtonPanel: true, currentText: '本月', closeText: '关闭'
    });
});

