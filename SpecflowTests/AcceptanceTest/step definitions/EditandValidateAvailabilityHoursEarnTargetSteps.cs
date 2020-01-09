using NUnit.Framework;
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
    public class EditandValidateAvailabilityHoursEarnTargetSteps
    {
        [Given(@"I have loggined and Edited Vailabilitya and Hours,EarnTarget Target fields")]
        public void GivenIHaveLogginedAndEditedVailabilityaAndHoursEarnTargetTargetFields()
        {
            //Availability
            //ClickAvailability
            IWebElement ClickAvailability = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
            ClickAvailability.Click();
            //ClickAvailableField
            IWebElement ClickAvailabilityField = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select"));
           


            ClickAvailabilityField.Click();
            SelectElement clickThis = new SelectElement(ClickAvailabilityField);
            clickThis.SelectByText("Part Time");

            Console.WriteLine("Availability added successfully");



            //Hours
            //ClickHours
            IWebElement ClickHours = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
            ClickHours.Click();
            //ClickHoursField
            IWebElement ClickHoursField = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select"));
            

            ClickHoursField.Click();
            SelectElement clickThis1 = new SelectElement(ClickHoursField);
            clickThis1.SelectByText("More than 30hours a week");

            Console.WriteLine("Hours added successfully");


            //EarnTarget
            //ClickEarnTarget
            IWebElement ClickEarnTarget = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
            ClickEarnTarget.Click();
            //ClickEarnTargetField
            IWebElement ClickEarnTargetField = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select"));
            

            ClickEarnTargetField.Click();
            SelectElement clickThis2 = new SelectElement(ClickEarnTargetField);
            clickThis2.SelectByText("Between $500 and $1000 per month");
            Console.WriteLine("EarnTarget added successfully");
            //Availability



            //Hours





            //EarnTarget




        }

        [Then(@"the user should be able to Edit Vailabilitya and Hours,EarnTarget Target fields")]
        public void ThenTheUserShouldBeAbleToEditVailabilityaAndHoursEarnTargetTargetFields()
        {
            //Validate Avaialability
            try
            {
                CommonMethods.ExtentReports();
                // Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit Availability Details");
                // string AvailabilityValidationExpected = "Full Time";
                IWebElement ClickAvailability = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i"));
                ClickAvailability.Click();
                // IWebElement ClickAvailabilityField = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select"));
                // ClickAvailabilityField.Click();
                Thread.Sleep(2000);
                IWebElement AvailabilityValidation = Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span"));
                Thread.Sleep(1000);
                if (AvailabilityValidation.Text == "Part Time")
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Edit Availability Successful");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Edited");
                }
                else
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Edit Availability Unsuccessful");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            //Validate Hours
            try
            {
                CommonMethods.ExtentReports();
                // Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit Hours Details");
                //ClickHours
                IWebElement ClickHours = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i"));
                ClickHours.Click();
                //ClickHoursField
                // IWebElement ClickHoursField = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select"));
                //ClickHoursField.Click();
               
                IWebElement ValidateHours = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span"));
                Thread.Sleep(1000);
                if (ValidateHours.Text == "More than 30hours a week")

                {

                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Edit Hours Successful");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Edited Hours ");
                }
                else
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Edit Hours Unsuccessful");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
            //Validate EarnTarget
            try
            {
                CommonMethods.ExtentReports();
                // Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit EarnTarget Details");
                IWebElement ClickEarnTarget = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
                ClickEarnTarget.Click();
                IWebElement ValidateEarnTarget = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span"));
                Thread.Sleep(1000);
                if (ValidateEarnTarget.Text == "Between $500 and $1000 per month")

                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Edit EarnTarget Successful");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Edited EarnTarget");
                }
                else
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Edit EarnTarget Unsuccessful");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
