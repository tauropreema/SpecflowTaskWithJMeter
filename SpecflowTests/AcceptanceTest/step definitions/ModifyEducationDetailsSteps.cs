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
    public class ModifyEducationDetailsSteps
    {

        [Given(@"I have clicked on the Education Details under the profle section")]
        public void GivenIHaveClickedOnTheEducationDetailsUnderTheProfleSection()
        {
            //clicking on Education Tab 
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")).Click();
        }

        [Given(@"I have modified already existing data")]
        public void GivenIHaveModifiedAlreadyExistingData()
        {
            try
            {
                //Populate data from excel sheet
                CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "Education");
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    Thread.Sleep(5000);
                    //Fetch the Title
                    string Title = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;
                    if (Title == CommonMethods.ExcelLib.ReadData(2, "Title"))
                    {
                        //Click on Edit button
                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[6]/span[1]")).Click();
                        //Edit the University 
                        IWebElement insituteName = Driver.driver.FindElement(By.Name("instituteName"));
                        insituteName.Clear();
                        insituteName.SendKeys(CommonMethods.ExcelLib.ReadData(2, "EditInstituteName"));
                        //Choose title
                        IWebElement titleDropdown = Driver.driver.FindElement(By.Name("title"));
                        SelectElement title = new SelectElement(titleDropdown);
                        title.SelectByText(CommonMethods.ExcelLib.ReadData(2, "EditTitle"));
                        return;
                    }
                }
                Console.WriteLine("Education to be edited does not exist");
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [When(@"I Press add")]
        public void WhenIPressAdd()
        {
            try
            {
                //click update
                Driver.driver.FindElement(By.XPath("//input[contains(@value,'Update')]")).Click();
            }
            catch (NoSuchElementException)
            {
                return;
            }
        }

        [Then(@"the Modified data should be listed in education details\.")]
        public void ThenTheModifiedDataShouldBeListedInEducationDetails_()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Education");
                Thread.Sleep(1000);
                int tempValue = 0;
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    string ExpectedValue = CommonMethods.ExcelLib.ReadData(2, "EditTitle");
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Updated Education Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationUpdated");
                        tempValue++;
                        return;
                    }

                    else
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                }
                if (tempValue == 0)
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}