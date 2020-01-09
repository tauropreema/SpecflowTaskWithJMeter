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
    public class ModifySkillsSteps
    {
        private int count;
        private int i;

        [Given(@"I have clicked on the skill Details under the profle section")]
        public void GivenIHaveClickedOnTheSkillDetailsUnderTheProfleSection()
        {
            //click on profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            //click on skill tab
            Driver.driver.FindElement(By.XPath("//a[@data-tab='second']")).Click();
            //click on modify symbol
          //  Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[5]/tr/td[3]/span[1]/i")).Click();
        }

        [Given(@"I have modified already existing skill data")]
        public void GivenIHaveModifiedAlreadyExistingSkillData()
        {
            try
            {
                Thread.Sleep(1000);
                IList<IWebElement> SearchResult1 = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody"));
                for (i = 1; i <= SearchResult1.Count; i++)
                {

                    IWebElement SkillSearch = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                    IWebElement ClickEdit = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i"));
                    //IWebElement EditskillField = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/div[1]/input"));
                    //IWebElement EditskillFieldSelect = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/ tr/td/div/div[1]/input"));
                    //IWebElement EditskillUpdate = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td/div/span/input[1]"));
                    if (SkillSearch.Text == "Guiter")
                    {
                        ClickEdit.Click();
                        //IWebElement skillModify = Driver.driver.FindElement(By.XPath(""));
                        IWebElement skillName = Driver.driver.FindElement(By.Name("name"));
                        skillName.Clear();
                        skillName.SendKeys("Java");
                        IWebElement skillLevel = Driver.driver.FindElement(By.Name("level"));
                        SelectElement skillDropdown = new SelectElement(skillLevel);
                        skillDropdown.SelectByText("Intermediate");
                        Driver.driver.FindElement(By.XPath("//input[@value='Update']")).Click();
                        //EditskillField.Clear();
                        //EditskillField.SendKeys("sitar");
                        //// IWebElement skilllevelModify = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[5]/tr/td/div/div[2]/select"));
                        //SelectElement selectskilllevel = new SelectElement(EditskillFieldSelect);
                        //selectskilllevel.SelectByText("Beginner");
                        //EditskillUpdate.Click();
                    }


                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            }

        [When(@"When I Press add")]
        public void WhenWhenIPressAdd()
        {
            Console.WriteLine("Success Added");

        }
        
        [Then(@"Then the Modified data should be listed in skills details\.")]
        public void ThenThenTheModifiedDataShouldBeListedInSkillsDetails_()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("modify a skills Details");

                IList<IWebElement> SearchResult1 = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody"));
                for (i = 1; i <= SearchResult1.Count; i++)
                {

                    IWebElement SkillSearch = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody[" + i + "]/tr/td[1]"));
                    // IWebElement ClickEdit = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]/span[1]/i"));

                    if (SkillSearch.Text == "Java")
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, modified Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "modified");
                        Console.WriteLine("Success");
                        break;
                    }


                    



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