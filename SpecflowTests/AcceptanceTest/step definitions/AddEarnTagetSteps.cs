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
    public class AddEarnTagetSteps
    {
        [Given(@"I loggined and Clicked on EarnTarget and EarnTarget field,added EarnTarget")]
        public void GivenILogginedAndClickedOnEarnTargetAndEarnTargetFieldAddedEarnTarget()
        {
            //ClickEarnTarget
            IWebElement ClickEarnTarget = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
            ClickEarnTarget.Click();
            //ClickEarnTargetField
            IWebElement ClickEarnTargetField = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select"));
            ClickEarnTargetField.Click();
            CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "Profile");
           
            
            if (CommonMethods.ExcelLib.ReadData(2, "Earn Target") == "Less than $500 per month")
            {
                SelectElement clickThis = new SelectElement(ClickEarnTargetField);
                clickThis.SelectByText("Less than $500 per month");
               
            }
            else if (CommonMethods.ExcelLib.ReadData(2, "Earn Target") == "Between $500 and $1000 per month")
            {
                SelectElement clickThis = new SelectElement(ClickEarnTargetField);
                clickThis.SelectByText("Between $500 and $1000 per month");


            }
            else if (CommonMethods.ExcelLib.ReadData(2, "Earn Target") == "More than $1000 per month")
            {
                SelectElement clickThis = new SelectElement(ClickEarnTargetField);
                clickThis.SelectByText("More than $1000 per month");
            }
        }
        
        [Then(@"the EarnTarget should be added")]
        public void ThenTheEarnTargetShouldBeAdded()
        {
            try
            {
                CommonMethods.ExtentReports();
                // Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("EarnTarget Details");
                IWebElement ClickEarnTarget = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i"));
                ClickEarnTarget.Click();
                IWebElement ValidateEarnTarget = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span"));
                if (ValidateEarnTarget.Text == "Less than $500 per month")
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "EarnTarget Successful");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "EarnTarget added");
                }
                else
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "EarnTarget Unsuccessful");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }


            }
    }

