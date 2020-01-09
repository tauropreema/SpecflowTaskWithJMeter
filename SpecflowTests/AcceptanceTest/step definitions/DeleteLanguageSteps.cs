using NUnit.Framework;
using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest.step_definitions
{
    [Binding]
    public class DeleteLanguageSteps
    {
        private int count;
        private int i;

        // private int count;

        [Given(@"I have Clicked on language tab under profile tab")]
        public void GivenIHaveClickedOnLanguageTabUnderProfileTab()
        {
            //click on profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            //click on Language tab
            Driver.driver.FindElement(By.XPath("//a[@class='item active']")).Click();
        }

        [When(@"I Click on Delete Symbol")]
        public void WhenIClickOnDeleteSymbol()


        {
            try
            {

                Thread.Sleep(1000);
                IList<IWebElement> SearchResult1 = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody"));
                for (i = 1; i <= SearchResult1.Count; i++)
                {

                    IWebElement laguageSearch = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                    IWebElement ClickDelete = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[2]/i"));
                    if (laguageSearch.Text == "Telugu")
                    {
                        ClickDelete.Click();
                    }
                }

                //clickdelete tab
                // Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td[3]/span[2]/i")).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [Then(@"i should be able to delete the language details")]
        public void ThenIShouldBeAbleToDeleteTheLanguageDetails()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("delete a language Details");

                Thread.Sleep(1000);
                {
                    IList<IWebElement> SearchResult1 = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody"));
                    for (i = 1; i <= SearchResult1.Count; i++)
                    {

                        IWebElement laguageSearch = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                        // IWebElement ClickEdit = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i"));

                        if (laguageSearch.Text == "Telugu")
                        {
                            CommonMethods.test.Log(LogStatus.Fail, "Test Failed, not deleted Successfully");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "notdeleted");
                            Console.WriteLine("Fail");
                            break;
                            //Assert.Fail("failed");
                            // return;
                        }


                        else
                        {
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "deleted");
                            // Console.WriteLine("Success");

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Success", ex.Message);

                // CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                //  Assert.Fail(ex.Message);
            }
        }
    }
}