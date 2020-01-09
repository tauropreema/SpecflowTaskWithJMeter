using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest.step_definitions
{
    [Binding]
    public class DeleteShareskillsSteps
    {
        private int i;
        private int count;

        [Given(@"I have Loggined and clicked on Manage Listing")]
        public void GivenIHaveLogginedAndClickedOnManageListing()
        {
            //Click on Manage Listing
            IWebElement ClickManageListing = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[3]"));
            ClickManageListing.Click();

        }

        [When(@"I press Delete")]
        public void WhenIPressDelete()
        {
            try
            {
                Thread.Sleep(1000);
               // IList<IWebElement> SearchResult1 = Driver.driver.FindElements(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody"));
                for (i = 1; i <= i++; i++)
                {
                    Thread.Sleep(1000);
                    IWebElement SearchforSkill = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr["+i+"]/td[3]"));
                    //IWebElement DeleteShareskill = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[8]/div/button[3]/i"));
                    if (SearchforSkill.Text == "Testing Automation with selenium")
                    {
                        Thread.Sleep(1000);
                        IWebElement DeleteShareskill = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr["+i+"]/td[8]/div/button[3]/i"));
                        DeleteShareskill.Click();
                        //AlertDelete
                        Thread.Sleep(1000);
                        IWebElement AlertDelete = Driver.driver.FindElement(By.XPath("//*[@class='ui icon positive right labeled button']"));
                        AlertDelete.Click();
                    }
                    else
                    {
                        Console.WriteLine("Couldnot find element");
                    }


                }




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        [Then(@"the Shareskill details should be deleted")]
        public void ThenTheShareskillDetailsShouldBeDeleted()
        {
            //Validation
            //ValidateDeleteShareSkill
            try
            {
                Thread.Sleep(2000);
                // string ExpectedAfterdeletion = "You do not have any service listings!";
                //Start the Reports
                CommonMethods.ExtentReports();

                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Skill Details");



                IList<IWebElement> SearchResult1 = Driver.driver.FindElements(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody"));
                for (i = 1; i <= SearchResult1.Count; i++)
                {

                    IWebElement SearchforSkill = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[3]"));
                    // IWebElement DeleteShareskill = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[8]/div/button[3]/i"));
                    if (SearchforSkill.Text == "Testing Automation with selenium")
                    {
                        CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Delete unSuccessful");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "Delete Shareskills unsuccessfull");
                        Console.WriteLine("unSuccess");
                        break;
                    }
                    else
                    {
                        CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Delete Share Skill successful");
                        Console.WriteLine("Success");
                    }
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}