using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.IO;

namespace NopiStandard
{
    public class Class1
    {

        public static void dropDownList(string[] datas, string filePath)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("下拉列表测试");
            ISheet hidden = workbook.CreateSheet("hidden");
            //数据源sheet页不显示
            workbook.SetSheetHidden(workbook.GetSheetIndex(hidden), true);
            ICellStyle style = workbook.CreateCellStyle();
            style.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Center;
            IRow row = null;
            ICell cell = null;
            for (int i = 0; i < datas.Length; i++)
            {
                row = hidden.CreateRow(i);
                cell = row.CreateCell(0);
                cell.SetCellValue(datas[i]);
            }
            IName namedCell = workbook.CreateName();
            namedCell.NameName = "hidden";
            namedCell.RefersToFormula = "hidden!A$1:A$" + datas.Length;
            HSSFDataValidationHelper dvHelper = new HSSFDataValidationHelper(sheet as HSSFSheet);
            IDataValidationConstraint dvConstraint = (IDataValidationConstraint)dvHelper.CreateFormulaListConstraint("hidden");
            CellRangeAddressList addressList = null;
            HSSFDataValidation validation = null;
            for (int i = 0; i < datas.Length; i++)
            {
                row = sheet.CreateRow(i);
                cell = row.CreateCell(0);
                cell.CellStyle = style;
                addressList = new CellRangeAddressList(i, i, 0, 0);
                validation = (HSSFDataValidation)dvHelper.CreateValidation(dvConstraint, addressList);
                sheet.AddValidationData(validation);
            }

            FileStream stream = new FileStream(filePath, FileMode.CreateNew);
            workbook.Write(stream);
            stream.Close();
        }


        public static void SetCellDropdownList(ISheet sheet, int firstrow, int lastrow, int firstcol, int lastcol, string[] vals)
        {
            //设置生成下拉框的行和列
            var cellRegions = new CellRangeAddressList(firstrow, lastrow, firstcol, lastcol);

            //设置 下拉框内容
            DVConstraint constraint = DVConstraint.CreateExplicitListConstraint(vals);

            //绑定下拉框和作用区域，并设置错误提示信息
            HSSFDataValidation dataValidate = new HSSFDataValidation(cellRegions, constraint);
            dataValidate.CreateErrorBox("输入不合法", "请输入或选择下拉列表中的值。");
            dataValidate.ShowPromptBox = true;

            sheet.AddValidationData(dataValidate);
        }

        /// <summary>
        /// 用于下拉列表数据过多导致的  Npoi 导出Excel 下拉列表异常: String literals in formulas can't be bigger than 255 Chars ASCII
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="sheet"></param>
        /// <param name="name"></param>
        /// <param name="firstrow"></param>
        /// <param name="lastrow"></param>
        /// <param name="firstcol"></param>
        /// <param name="lastcol"></param>
        /// <param name="vals"></param>
        /// <param name="sheetindex"></param>
        public static void  SetCellDropdownList(HSSFWorkbook workbook, ISheet sheet, string name, int firstrow, int lastrow, int firstcol, int lastcol, string[] vals, int sheetindex = 1)
        {
            //先创建一个Sheet专门用于存储下拉项的值
            ISheet sheet2 = workbook.CreateSheet(name);
            //隐藏
            workbook.SetSheetHidden(sheetindex, true);
            int index = 0;
            foreach (var item in vals)
            {
                sheet2.CreateRow(index).CreateCell(0).SetCellValue(item);
                index++;
            }
            //创建的下拉项的区域：
            var rangeName = name + "Range";
            IName range = workbook.CreateName();
            range.RefersToFormula = name + "!$A$1:$A$" + index;
            range.NameName = rangeName;
            CellRangeAddressList regions = new CellRangeAddressList(firstrow, lastrow, firstcol, lastcol);

            DVConstraint constraint = DVConstraint.CreateFormulaListConstraint(rangeName);
            HSSFDataValidation dataValidate = new HSSFDataValidation(regions, constraint);
            dataValidate.CreateErrorBox("输入不合法", "请输入或选择下拉列表中的值。");
            dataValidate.ShowPromptBox = true;
            sheet.AddValidationData(dataValidate);
        }

    }
}
