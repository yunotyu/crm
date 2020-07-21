//动态时间
function getCurrentTime(id,geshi)
{
	var myYear,myMonth,myDate,myDayIndex,myDay,myWeekArray; 
	var hours, minutes, seconds, xfile;
	var intHours, intMinutes, intSeconds;
	var today;
	var timeString,dateString,allTimeString;
	myWeekArray = new Array("星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六");
	today = new Date();
	intHours = today.getHours();
	intMinutes = today.getMinutes();
	intSeconds = today.getSeconds();
		
	myYear = today.getFullYear();
	myMonth =today.getMonth() + 1;
	myDate =today.getDate();
	myDayIndex = today.getDay();
		
	for(var i = 0;i<myWeekArray.length;i++)
	{
		if(myDayIndex == i)
		{
			myDay = myWeekArray[i];
		}
	}
		
	hours = intHours + ":";
		
	if (intMinutes < 10)
	{
		minutes = "0"+intMinutes+":";
	} 
	else 
	{
		minutes = intMinutes+":";
	}
		
	if (intSeconds < 10)
	{
		seconds = "0"+intSeconds+" ";
	} 
	else
	{
		seconds = intSeconds+" ";
	}
		
	dateString = myYear +"年"+ myMonth +"月"+ myDate +"日" + " " + myDay;
	timeString = dateString + " 时间：";
	allTimeString = timeString + hours + minutes + seconds;

	if (geshi == 0) {
	    //首页显示
	    document.getElementById(id).innerHTML = allTimeString;
	} else {
	    //添加销售机会时间显示
	    document.getElementById(id).value = myYear + "-" + myMonth + "-" + myDate + " " + hours + minutes + seconds;
	}

	window.setTimeout("getCurrentTime('" + id + "'," + geshi + ");", 1000);
}
