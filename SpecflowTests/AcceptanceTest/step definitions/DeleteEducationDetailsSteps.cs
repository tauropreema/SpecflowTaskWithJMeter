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
    public class DeleteEducationDetailsSteps
    {
        [Given(@"I have clicked on Education details which is present under the profile")]
        public void GivenIHaveClickedOnEducationDetailsWhichIsPresentUnderTheProfile()
        {
            //click on education details
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")).Click();
        }

        [When(@"I press delete")]
        public void WhenIPressDelete()
        {
            try
            {
                //Populate data from excel sheet
                CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "Education");
                //Find the no of Table body 
                int tempValue = 0;
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    tempValue = 1;
                    //Fetch the Title
                    string Title = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;
                    if (Title == CommonMethods.ExcelLib.ReadData(2, "DeleteEducation"))
                    {
                        //Click on Delete button
                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[6]/span[2]/i")).Click();
                        tempValue++;
                        return;
                    }
                }
                if ((NoOfRows.Count) == 0)
                    Console.WriteLine("There exist no records to Delete");
                if (tempValue == 1)
                    Console.WriteLine("There are no matching records to Delete");
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Then(@"the education details should be deleted")]
        public void ThenTheEducationDetailsShouldBeDeleted()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Education");
                int tempValue = 0;
                Thread.Sleep(1000);
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    tempValue = 1;
                    string ExpectedValue = CommonMethods.ExcelLib.ReadData(2, "DeleteEducation");
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[" + i + "]/tr/td[3]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                        return;
                    }
                }
                if ((NoOfRows.Count) == 0 || tempValue == 1)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted Education Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "EducationDeleted");
                }
            }

            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }
        }
    }
}