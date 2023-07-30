using CRUD_Operations_Product_and_Category.POCO;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ServiceLayer.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace CRUD_Operations_Product_and_Category.Controllers
{
    public class ExcelController : Controller
    {
        private readonly IReportService _ProductReport;

        public ExcelController(IReportService ProductReport)
        {
            _ProductReport = ProductReport;
        }

        // GET: Excel
        public async Task<ActionResult> ExportDataToExcel()
        {
            // Fetch data from the database
            var d = _ProductReport.GetReport(1);

            var data = await d;

            // Create a new Excel package
            using (var excelPackage = new ExcelPackage())
            {
                // Create a worksheet
                var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                // Set the column headers dynamically based on the property names
                var properties = typeof(Report).GetProperties();
                for (var i = 0; i < properties.Length; i++)
                {
                    var columnName = properties[i].Name;
                   worksheet.Cells[1, i + 1].Value = columnName;
                    worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                    worksheet.Cells[1, i + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Purple);
                }

                // Set the data rows
                for (var i = 0; i < data.Count; i++)
                {
                    var row = i + 2; // Start from row 2

                    for (var j = 0; j < properties.Length; j++)
                    {
                        var value = properties[j].GetValue(data[i]);
                        worksheet.Cells[row, j + 1].Value = value;
                        if (value.Equals( "Abhijit"))
                        {
                            worksheet.Cells[row, j + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                            worksheet.Cells[row, j + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Orange);
                        }
                    }
                }

                // Generate the Excel file bytes
                var fileBytes = excelPackage.GetAsByteArray();

                // Set the response content type and headers
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=Report.xlsx");

                // Write the file bytes to the response
                Response.BinaryWrite(fileBytes);
                Response.Flush();
                Response.End();
            }

            return null;
        }


    }
}