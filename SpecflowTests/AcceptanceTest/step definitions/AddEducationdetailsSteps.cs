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
    public class AddEducationdetailsSteps
    {
        [Given(@"I have clicked on Education tab")]
        public void GivenIHaveClickedOnEducationTab()
        {
            //clicking on Education Tab 
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")).Click();
            //click on add new
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")).Click();
        }

        [Given(@"I have entered Education Deatils")]
        public void GivenIHaveEnteredEducationDeatils()
        {
            try
            {
                //Populate data from excel sheet
                CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "Education");
                //Add the College name
                Driver.driver.FindElement(By.Name("instituteName")).SendKeys(CommonMethods.ExcelLib.ReadData(2, "InstituteName"));
                //Add the country of College
                IWebElement countryDropdown = Driver.driver.FindElement(By.Name("country"));
                SelectElement country = new SelectElement(countryDropdown);
                country.SelectByText(CommonMethods.ExcelLib.ReadData(2, "Country"));
                //Choose title
                IWebElement titleDropdown = Driver.driver.FindElement(By.Name("title"));
                SelectElement title = new SelectElement(titleDropdown);
                title.SelectByText(CommonMethods.ExcelLib.ReadData(2, "Title"));
                // Add Degree
                Driver.driver.FindElement(By.Name("degree")).SendKeys(CommonMethods.ExcelLib.ReadData(2, "Degree"));
                //Choose Year of Graduation
                IWebElement yearDropdown = Driver.driver.FindElement(By.Name("yearOfGraduation"));
                SelectElement yearOfGraduation = new SelectElement(yearDropdown);
                yearOfGraduation.SelectByText(CommonMethods.ExcelLib.ReadData(2, "YearOfGraduation"));
                //Click on Add button
                Driver.driver.FindElement(By.XPath("//input[contains(@value,'Add')]")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Then(@"Education Details should be added\.")]
        public void ThenEducationDetailsShouldBeAdded_()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Education");
                Thread.Sleep(1000);
                int tempValue = 0;
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    string ExpectedValue = CommonMethods.ExcelLib.ReadData(2, "Title");
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Education Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationAdded");
                        tempValue++;
                        return;
                    }
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