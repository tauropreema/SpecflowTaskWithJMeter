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
    public class ModifyCertificationSteps
    {
        [Given(@"I have clicked on the Certification Details under the profle section")]
        public void GivenIHaveClickedOnTheCertificationDetailsUnderTheProfleSection()
        {
            //clicking on cerification Tab 
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")).Click();
        }

        [Given(@"I have modified already existing cerification data")]
        public void GivenIHaveModifiedAlreadyExistingCerificationData()
        {
            try
            {
                //Populate data from excel sheet
                CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "Certifications");
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    Thread.Sleep(5000);
                    //Fetch the Certificate
                    string Certificate = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    if (Certificate == CommonMethods.ExcelLib.ReadData(2, "Certificate"))

                    {
                        //Click on Edit
                        Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[4]/span[1]/i")).Click();
                        IWebElement certificationName = Driver.driver.FindElement(By.Name("certificationName"));
                        certificationName.Clear();
                        certificationName.SendKeys(CommonMethods.ExcelLib.ReadData(2, "EditCertificate"));
                        IWebElement year = Driver.driver.FindElement(By.XPath("//select[@name='certificationYear']"));
                        SelectElement yearDropdown = new SelectElement(year);
                        yearDropdown.SelectByText(CommonMethods.ExcelLib.ReadData(2, "EditYear"));
                        return;
                    }
                }
                Console.WriteLine("Certificate to be edited does not exist");
                return;
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [When(@"I Press add button")]
        public void WhenIPressAddButton()
        {
            try
            {
                //click on update
                Driver.driver.FindElement(By.XPath("//input[contains(@value,'Update')]")).Click();
            }
            catch (NoSuchElementException)
            {
                return;
            }
        }

        [Then(@"the Modified data should be listed in Certification details\.")]
        public void ThenTheModifiedDataShouldBeListedInCertificationDetails_()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Edit a Certification");
                Thread.Sleep(1000);
                int tempValue = 0;
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    string ExpectedValue = CommonMethods.ExcelLib.ReadData(2, "EditCertificate");
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Edited Certification Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "CertificationEdited");
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