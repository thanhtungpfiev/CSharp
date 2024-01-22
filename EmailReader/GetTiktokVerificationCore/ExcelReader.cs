using System;
using System.Data;
using System.IO;
using OfficeOpenXml;

namespace GetTiktokVerificationCore
{
    public class ExcelReader
    {
        public void ReadColumnValues(string filePath)
        {
            FileInfo existingFile = new FileInfo(filePath);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                foreach (var worksheet in package.Workbook.Worksheets)
                {
                    int rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= 5; row++)
                    {
                        object colAValue = worksheet.Cells[row, 1].Value;
                        object colBValue = worksheet.Cells[row, 2].Value;
                        object colCValue = worksheet.Cells[row, 3].Value;

                        // Check if column A has a value
                        if (!string.IsNullOrEmpty(colAValue?.ToString()))
                        {
                            // Process the row only if column A has a value
                            //Console.WriteLine($"Row {row} - Column A: {colAValue}, Column B: {colBValue}, Column C: {colCValue}");
                            if (!string.IsNullOrEmpty(colBValue?.ToString()) && !string.IsNullOrEmpty(colCValue?.ToString()))
                            {
                                string verificationValue = GetTiktokVerificationMain.GetVerificationCode(colBValue.ToString(), colCValue.ToString());
                                worksheet.Cells[row, 11].Value = verificationValue;
                            }

                        }
                        else
                        {
                            // Skip the row if column A is empty
                            break;
                        }
                    }
                }
                


                // Save the changes to the Excel file
                package.Save();
            }
        }
    }

}
