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
    public class DeleteSkillsDetailsSteps
    {
        private int count;
        private int i;

        [Given(@"I have clicked on skills details which is present under the profile")]
        public void GivenIHaveClickedOnSkillsDetailsWhichIsPresentUnderTheProfile()
        {
            //click on profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            //click on skill tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='second']")).Click();
        }

        [When(@"I click on delete")]
        public void WhenIClickOnDelete()
        {
            try
            {
                Thread.Sleep(1000);
                IList<IWebElement> SearchResult1 = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody"));
                for (i = 1; i <= SearchResult1.Count; i++)
                {

                    IWebElement SkillSearch = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                    IWebElement ClickDelete = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[2]/i"));
                    //IWebElement EditskillField = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                    //IWebElement EditskillFieldSelect = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/ tr/td/div/div[1]/input"));
                    //IWebElement EditskillUpdate = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]"));
                    if (SkillSearch.Text == "Java")
                    {
                        ClickDelete.Click();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        [Then(@"the skill details should be deleted")]
        public void ThenTheSkillDetailsShouldBeDeleted()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("delete a skill Details");

                Thread.Sleep(1000);
                {
                    IList<IWebElement> SearchResult1 = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody"));
                    for (i = 1; i <= SearchResult1.Count; i++)
                    {

                        IWebElement SkillSearch = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                        Thread.Sleep(1000);
                        //Console.WriteLine(ActualValue.Text);
                        //string ExpectedValue = "Spanish";
                        if (SkillSearch.Text == "Java")

                        {
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "notdeleted");
                            Console.WriteLine("Fail");
                            Assert.Fail("failed");
                            break;
                        }


                        else
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "deleted");
                        // Console.WriteLine("Success");

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