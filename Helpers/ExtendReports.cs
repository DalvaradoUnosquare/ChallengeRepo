using System;
using System.IO;
using NUnit.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;


namespace InterviewPractice.Helpers
{
    public class ExtendReports
    {
        #region Constructors
        public ExtentReports extent;
        public static ExtentHtmlReporter htmlReporter;
        #endregion

        #region Methods
        [OneTimeSetUp]
        public void ExtentStart()
        {
            FileInfo file = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"\Helpers\Files\TestEvidence"));

            var htmlreporter = new ExtentHtmlReporter(file + "Report" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            htmlReporter = new ExtentHtmlReporter(htmlreporter.ToString());
            extent = new ExtentReports();

            extent.AttachReporter(htmlreporter);
            extent.AddSystemInfo("OS", "Windows");
        }

        [OneTimeTearDown]
        public void ExtentClose()
        {
            extent.Flush();
        }
        #endregion
    }
}
