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
    public class DeleteCertificationSteps
    {
        [Given(@"I have clicked on certification details which is present under the profile")]
        public void GivenIHaveClickedOnCertificationDetailsWhichIsPresentUnderTheProfile()
        {
            //clicking on cerification Tab 
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")).Click();
        }

        [When(@"I press delete certication button")]
        public void WhenIPressDeleteCerticationButton()
        {
            try
            {
                //Populate data from excel sheet
                CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "Certifications");
                int tempValue = 0;
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    tempValue = 1;
                    Thread.Sleep(5000);
                    //Fetch the Certificate
                    string Certificate = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    if (Certificate == CommonMethods.ExcelLib.ReadData(2, "DeleteCertification"))
                    {
                        //click on Delete button
                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[4]/span[2]/i")).Click();
                        tempValue++;
                        return;
                    }
                }
                if ((NoOfRows.Count) == 0)
                    Console.WriteLine("There exist no records to Delete");
                if (tempValue == 1)
                {
                    Console.WriteLine("There are no matching records to Delete");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }

        [Then(@"the certification details should be deleted")]
        public void ThenTheCertificationDetailsShouldBeDeleted()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Delete a Certification");
                int tempValue = 0;
                Thread.Sleep(1000);
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    tempValue = 1;
                    string ExpectedValue = CommonMethods.ExcelLib.ReadData(2, "DeleteCertification");
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Fail, "Test Failed");
                        return;
                    }

                }
                if ((NoOfRows.Count) == 0 || tempValue == 1)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Deleted Certification Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "CertificationDeleted");
                }
            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }
    }
}