using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowPages;
using System;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class AddDescriptionSteps
    {
        [Given(@"I clicked on the Add description icon on Profile page")]
        public void GivenIClickedOnTheAddDescriptionIconOnProfilePage()
        {

            Driver.driver.FindElement(By.XPath("(//i[contains(@class,'outline write icon')])[1]")).Click();

        }

        [When(@"I add a description")]
        public void WhenIAddADescription()
        {
            //Populate the data
            CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "EditDescription");
            IWebElement ProfileDescription = Driver.driver.FindElement(By.XPath("//textarea[@name='value']"));
            ProfileDescription.Clear();
            ProfileDescription.SendKeys(CommonMethods.ExcelLib.ReadData(2, "Description"));
            Driver.driver.FindElement(By.XPath("//button[contains(@type,'button')]")).Click();
        }

        [Then(@"that description should be added")]
        public void ThenThatDescriptionShouldBeAdded()
        {
            try
            {
                CommonMethods.ExtentReports();
                // Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Description Details");
                IWebElement Description = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span"));
                if (CommonMethods.ExcelLib.ReadData(2, "Description") == Description.Text)
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Description added Successful");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Description added");
                }
                else
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Adding Unsuccessful");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Adding Description Unsuccessful");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}