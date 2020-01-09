using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest.step_definitions
{
    [Binding]
    public class AddAvailabilitySteps
    {
        [Given(@"I have loggined and Clicked on Availability")]
        public void GivenIHaveLogginedAndClickedOnAvailability()
        {
            //ClickAvailability
            IWebElement ClickAvailability = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
            ClickAvailability.Click();
            //ClickAvailableField
            IWebElement ClickAvailabilityField = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select"));
            ClickAvailabilityField.Click();
        }

        [Given(@"I have Added Availability")]
        public void GivenIHaveAddedAvailability()
        {
            CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "Profile");

           // CommonMethods.test = CommonMethods.extent.StartTest("adding Availability Details");
            IWebElement ClickAvailabilityField1 = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select"));


            if (CommonMethods.ExcelLib.ReadData(2, "AvailableTime") == "Full time")
            {
                
                // CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "Profile");
                SelectElement clickThis = new SelectElement(ClickAvailabilityField1);
                clickThis.SelectByText("Full Time");
               
            }
            else if (CommonMethods.ExcelLib.ReadData(2, "AvailableTime") == "Part time")
            {
                SelectElement clickThis = new SelectElement(ClickAvailabilityField1);

                clickThis.SelectByText("Part Time");
            }
        }

        [Then(@"the Availability should be added")]
        public void ThenTheAvailabilityShouldBeAdded()
        {
            try
            {
                CommonMethods.ExtentReports();
                // Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Availability Details");
                // string AvailabilityValidationExpected = "Full Time";
                IWebElement ClickAvailability = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
                ClickAvailability.Click();
                // IWebElement ClickAvailabilityField = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select"));
                // ClickAvailabilityField.Click();
                Thread.Sleep(2000);
                IWebElement AvailabilityValidation = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span"));
                if (AvailabilityValidation.Text == "Full Time")
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Availability Successful");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "added");
                }
                else
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Availability Unsuccessful");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

