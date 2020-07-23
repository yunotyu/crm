using CRM.Model.Attribute;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model.Utils
{
    public class ExcelHelper
    {
        public static HSSFWorkbook Export<T>(T model,List<T>data)
        {
            //判断上面是否有特性，然后获取属性名
            List<string> li = new List<string>();
            //存储要导出的Excel列名的属性
            List<string> propNames = new List<string>();
            foreach(var item in model.GetType().GetProperties())
            {
                foreach(var attr in item.GetCustomAttributes(false))
                {
                    if (attr.GetType() == typeof(IgnoreAttribute))
                    {
                        continue;
                    }
                    else
                    {
                        if (attr.GetType() == typeof(DisplayNameAttribute))
                        {
                            li.Add(((DisplayNameAttribute)attr).DisplayName);
                            propNames.Add(item.Name);
                        }
                    }
                }
            }

            //创建Excel表
            HSSFWorkbook workbook = new HSSFWorkbook();
            //创建表格的一个sheet
            HSSFSheet sheet = workbook.CreateSheet("信息") as HSSFSheet;

            sheet.DefaultColumnWidth = 25;
            sheet.DefaultRowHeight = 30 * 20;

            //创建表头
            HSSFRow row = sheet.CreateRow(0) as HSSFRow;

            //创建列的样式
            HSSFCellStyle style = workbook.CreateCellStyle() as HSSFCellStyle;
            //设置垂直居中
            style.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.Center;
            //设置水平居中
            style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;

            //创建列
            for(int i = 0; i < li.Count(); i++)
            {
                var cell = row.CreateCell(i);
                cell.SetCellValue(li[i]);
                row.Cells[i].CellStyle = style;
            }
            
            //填充数据
            for(int i = 0; i < data.Count(); i++)
            {
                HSSFRow row1 = sheet.CreateRow(i+1) as HSSFRow;
                for(int j = 0; j < propNames.Count(); j++)
                {
                    row1.CreateCell(j).SetCellValue(data[i].GetType().GetProperty(propNames[j]).GetValue(data[i]).ToString());
                }
            }
            return workbook;
        }
    }
}
