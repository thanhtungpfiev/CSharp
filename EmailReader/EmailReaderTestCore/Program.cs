using GetTiktokVerificationCore;

namespace EmailReaderTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var filePath = @"C:\Users\Admin\Downloads\Email da dang ky tiktok.xlsx";
            //var formattedFilePath = FormatFilePath(filePath);
            //var excelReader = new ExcelReader();
            //excelReader.ReadColumnValues(formattedFilePath);
            GetTiktokVerificationMain.GetVerificationCode("hunterging@gmail.com", "Wind2508a@A");
        }

        private static string FormatFilePath(string filePath)
        {
            return Path.GetFullPath(filePath);
        }
    }
}
