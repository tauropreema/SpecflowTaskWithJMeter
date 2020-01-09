using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecflowPages;
using System;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest.step_definitions
{
    [Binding]
    public class AddHoursSteps
    {
        [Given(@"I loggined and Clicked on Hours and Hours field,added Hours")]
        public void GivenILogginedAndClickedOnHoursAndHoursFieldAddedHours()
        {
            //ClickHours
            IWebElement ClickHours = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
            ClickHours.Click();
            //ClickHoursField
            IWebElement ClickHoursField = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select"));
            ClickHoursField.Click();
            CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "Profile");
           
           // ClickHours.Click();
            
            //ClickHoursField.Click();
            if (CommonMethods.ExcelLib.ReadData(2, "Hours") == "Less than 30hours a week")
            {

                SelectElement clickThis = new SelectElement(ClickHoursField);
                clickThis.SelectByText("Less than 30hours a week");
                Console.WriteLine("Hours added successfully");
            }
            else if (CommonMethods.ExcelLib.ReadData(2, "Hours") == "More than 30hours a week")
            {
                SelectElement clickThis = new SelectElement(ClickHoursField);
                clickThis.SelectByText("More than 30hours a week");
                Assert.Pass("Hours added successfully");
            }
            else if (CommonMethods.ExcelLib.ReadData(2, "Hours") == "As needed")
            {
                SelectElement clickThis = new SelectElement(ClickHoursField);
                clickThis.SelectByText("As needed");
                Assert.Pass("Hours added successfully");
            }
        }
        
        [Then(@"the Hours should be added")]
        public void ThenTheHoursShouldBeAdded()
        {
            try {
                CommonMethods.ExtentReports();
                // Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Hours Details");
                //ClickHours
                 IWebElement ClickHours = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
                 ClickHours.Click();
                //ClickHoursField
                // IWebElement ClickHoursField = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select"));
                //ClickHoursField.Click();
                IWebElement ValidateHours = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span"));
           if(ValidateHours.Text == "Less than 30hours a week")
                {

                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Hours Successful");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Hours added");
                }
                else
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Hours Unsuccessful");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
