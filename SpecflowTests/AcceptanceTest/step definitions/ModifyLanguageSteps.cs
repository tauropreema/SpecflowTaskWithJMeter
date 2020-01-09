using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
    public class ModifyLanguageSteps
    {
        private int count;
        private int i;

        [Given(@"I have clicked on language tab under profile section")]
        public void GivenIHaveClickedOnLanguageTabUnderProfileSection()
        {
            //click on profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            //click on Language tab
            Driver.driver.FindElement(By.XPath("//a[@class='item active']")).Click();
            //click on modify symbol
           // Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[2]/tr/td[3]/span[1]/i")).Click();
        }

        [Given(@"i have modified language details")]
        public void GivenIHaveModifiedLanguageDetails()
        {
            try
            {
                Thread.Sleep(1000);
                IList<IWebElement> SearchResult1 = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody"));
                for (i = 1; i <= SearchResult1.Count; i++)
                {

                    IWebElement laguageSearch = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                    IWebElement ClickEdit = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i"));
                    if (laguageSearch.Text == "Spanish")
                    {
                        ClickEdit.Click();


                        //clear value in langauge field and enter new language
                        IWebElement languageModify = Driver.driver.FindElement(By.Name("name"));
                        languageModify.Click();
                        languageModify.Clear();
                        languageModify.SendKeys("Telugu");
                        //clear level and give new level
                        IWebElement levelModify = Driver.driver.FindElement(By.Name("level"));
                        SelectElement selectlevel = new SelectElement(levelModify);
                        selectlevel.SelectByText("Fluent");
                       // Driver.driver.FindElement(By.XPath("//input[@value='Update']")).Click();
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        
        [When(@"I click on Update button")]
        public void WhenIClickOnUpdateButton()
        {
            Driver.driver.FindElement(By.XPath("//input[@value='Update']")).Click();
        }
        
        [Then(@"i should be able to update the language details")]
        public void ThenIShouldBeAbleToUpdateTheLanguageDetails()
        {
            try
            {
                Thread.Sleep(1000);
                //Start the Reports
                CommonMethods.ExtentReports();
                //Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("modify a language Details");

                //Thread.Sleep(1000);
               
                    IList<IWebElement> SearchResult1 = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody"));
                    for (i = 1; i <= SearchResult1.Count; i++)
                    {

                        IWebElement laguageSearch = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                       // IWebElement ClickEdit = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i"));
                       
                            if (laguageSearch.Text == "Telugu")

                        {
                            CommonMethods.test.Log(LogStatus.Pass, "Test Passed, modified Successfully");
                            SaveScreenShotClass.SaveScreenshot(Driver.driver, "modified");
                            Console.WriteLine("Success");
                        break;
                            //return;
                        }


                        else
                           
                        Console.WriteLine("Failed");

                    }
                
            }
            catch (Exception ex)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                Assert.Fail(ex.Message);
            }
        }
    }
}