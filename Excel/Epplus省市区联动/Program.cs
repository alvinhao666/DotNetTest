using OfficeOpenXml;
using OfficeOpenXml.DataValidation;
using OfficeOpenXml.DataValidation.Contracts;
using OfficeOpenXml.Style;


// See https://blog.csdn.net/duyelang/article/details/49720153

MemoryStream memoryStream = new MemoryStream();
using (ExcelPackage ep = new ExcelPackage())
{
    ExcelWorksheet ws = ep.Workbook.Worksheets.Add("Sheet1");

    var exRang1 = ws.Cells[1, 1, 1, 3];
    exRang1.Value = "起始地";
    exRang1.Merge = true;
    exRang1.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
    exRang1.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

    var exRang2 = ws.Cells[1, 4, 1, 6];
    exRang2.Value = "目的地";
    exRang2.Merge = true;
    exRang2.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
    exRang2.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

    ws.DefaultColWidth = 18;
    ws.Cells[2, 1].Value = "省";
    ws.Cells[2, 2].Value = "市";
    ws.Cells[2, 3].Value = "区";
    ws.Cells[2, 4].Value = "省";
    ws.Cells[2, 5].Value = "市";
    ws.Cells[2, 6].Value = "区";

    var provinceSourceWs = ep.Workbook.Worksheets.Add("ProvinceSource");

    var citySourceWs = ep.Workbook.Worksheets.Add("CitySource");

    //var provinces = _areaProvider.GetProvinces();

    //var allCityCount = 0;
    //for (int i = 0; i < provinces.Count; i++)
    //{
    //    var pro = provinces[i];

    //    provinceSourceWs.Cells[1, i + 1].Value = pro.Name;
    //    provinceSourceWs.Cells[1, i + 1].Style.Font.Bold = true;

    //    var citys = _areaProvider.GetCities(pro.Code);

    //    for (int j = 0; j < citys.Count; j++)
    //    {
    //        var city = citys[j];

    //        provinceSourceWs.Cells[j + 2, i + 1].Value = city.Name;

    //        citySourceWs.Cells[1, allCityCount + 1].Value = city.Name;
    //        citySourceWs.Cells[1, allCityCount + 1].Style.Font.Bold = true;

    //        var areas = _areaProvider.GetDistricts(city.Code);

    //        for (int k = 0; k < areas.Count; k++)
    //        {
    //            var area = areas[k];

    //            citySourceWs.Cells[k + 2, allCityCount + 1].Value = area.Name;
    //        }

    //        ep.Workbook.Names.Add(pro.Name + city.Name, citySourceWs.Cells[2, allCityCount + 1, areas.Count + 1, allCityCount + 1]);

    //        allCityCount++;
    //    }

    //    ep.Workbook.Names.Add(pro.Name, provinceSourceWs.Cells[2, i + 1, citys.Count + 1, i + 1]);
    //}
    ////名称管理器
    //ep.Workbook.Names.Add("省", provinceSourceWs.Cells[1, 1, 1, provinces.Count]);
    //省下拉框
    var validation = ws.DataValidations.AddListValidation("A3:A100");
    SetExcelListValidation(validation);
    validation.Formula.ExcelFormula = "省";
    //市下拉框
    var validation2 = ws.DataValidations.AddListValidation("B3:B100");
    SetExcelListValidation(validation2);
    validation2.Formula.ExcelFormula = "INDIRECT($A3)";

    //区下拉框
    var validation3 = ws.DataValidations.AddListValidation("C3:C100");
    SetExcelListValidation(validation3);
    validation3.Formula.ExcelFormula = "INDIRECT($A3&$B3)";

    //省下拉框
    var validation4 = ws.DataValidations.AddListValidation("D3:D100");
    SetExcelListValidation(validation4);
    validation4.Formula.ExcelFormula = "省";
    //市下拉框
    var validation5 = ws.DataValidations.AddListValidation("E3:E100");
    SetExcelListValidation(validation5);
    validation5.Formula.ExcelFormula = "INDIRECT($D3)";

    //区下拉框
    var validation6 = ws.DataValidations.AddListValidation("F3:F100");
    SetExcelListValidation(validation6);
    validation6.Formula.ExcelFormula = "INDIRECT($D3&$E3)";

    ep.Workbook.CreateVBAProject();
    OfficeOpenXml.VBA.ExcelVbaProject proj = ep.Workbook.VbaProject;
    OfficeOpenXml.VBA.ExcelVBAModule sheetmodule = proj.Modules["Sheet1"];
    sheetmodule.Name = "sheet1";

    sheetmodule.Code = @"Private Sub Worksheet_Change(ByVal Target As Range)
                                        Dim Rng As Range
                                        If Target.Row < 3 Then Exit Sub '修改第一行（标题）不往下执行
                                        For Each Rng In Target
                                            If  Rng.Column = 1 Then '修改A列
                                                Rng.Offset(0, 1).ClearContents '清除B列
                                            End If
                                            If  Rng.Column = 2 Then '修改B列
                                                Rng.Offset(0, 1).ClearContents '清除C列
                                            End If
                                            If  Rng.Column = 4 Then '修改D列
                                                Rng.Offset(0, 1).ClearContents '清除E列
                                            End If
                                            If  Rng.Column = 5 Then '修改E列
                                                Rng.Offset(0, 1).ClearContents '清除F列
                                            End If
                                        Next
                                    End Sub";

    ep.SaveAs(memoryStream);
}

//memoryStream.Seek(0, SeekOrigin.Begin);
//using (var fs = new FileStream("E://test.xlsm", FileMode.CreateNew))
//{
//    memoryStream.CopyTo(fs);
//}


void SetExcelListValidation(IExcelDataValidationList item)
{
    item.ShowErrorMessage = true;
    item.ErrorStyle = ExcelDataValidationWarningStyle.warning;
    item.ErrorTitle = "无效数据";
    item.Error = "请从下拉列表中选择有效的数据";
}