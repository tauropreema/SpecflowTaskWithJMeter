using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecflowPages
{
    public class ConstantUtils
    {
        //Base Url
        public static string Url = "http://www.skillswap.pro/";
        public static string ScreenshotPath = Directory.GetCurrentDirectory() + @"\SpecflowPages\TestReports\Screenshots\";


        //ScreenshotPath
        //string currentDirectory = Environment.CurrentDirectory;

        //public static string ScreenshotPath = Directory.GetCurrentDirectory() + @"\SpecflowPages\TestReports\Screenshots\";

        // public static string ScreenshotPath = Directory.GetCurrentDirectory() + @"C:\Users\arun\source\repos\SpecflowTests-Base(1)\SpecflowTests-Base\SpecflowTests-Base\SpecflowTests\SpecflowPages\TestReports\Screenshots\";

        //public static string ScreenshotPath = @"C:\Users\arun\source\repos\SpecflowTests-Base(1)\SpecflowTests-Base\SpecflowTests-Base\SpecflowTests\SpecflowPages\TestReports\Screenshots\";


        //ExtentReportsPath
        public static string ReportsPath = Directory.GetCurrentDirectory() + @"\SpecflowPages\TestReports\Test.html";
        //public static string ReportsPath = @"C:\Users\arun\source\repos\SpecflowTests-Base(1)\SpecflowTests-Base\SpecflowTests-Base\SpecflowTests\SpecflowPages\TestReports\Test.html";

        //ReportXML Path
        public static string ReportXMLPath = Directory.GetCurrentDirectory() + @"\SpecflowPages\TestReports\ReportXML.xml";
        //public static string ReportXMLPath = @"C:\Users\arun\source\repos\SpecflowTests-Base(1)\SpecflowTests-Base\SpecflowTests-Base\SpecflowTests\SpecflowPages\TestReports\ReportXML.xml";
        public static string ExcelPath = Directory.GetCurrentDirectory() + @"\SpecflowPages\TestReports\TestData.xlsx";
    }
}
