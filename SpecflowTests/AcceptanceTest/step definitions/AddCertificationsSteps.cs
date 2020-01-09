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
    public class AddCertificationsSteps
    {
        [Given(@"I have clicked on Certification tab under profile")]
        public void GivenIHaveClickedOnCertificationTabUnderProfile()
        {
            try
            {
                //Click on Certifications tab
                Driver.WaitForElement(Driver.driver, By.XPath("//a[contains(text(),'Certifications')]"), 60);
                Driver.driver.FindElement(By.XPath("//a[contains(text(),'Certifications')]")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [Given(@"I have clicked on add new and given details")]
        public void GivenIHaveClickedOnAddNewAndGivenDetails()
        {
            try
            {
                //Click on Add New Button
                Driver.driver.FindElement(By.XPath("(//div[@class='ui teal button '][contains(.,'Add New')])[3]")).Click();
                //Populate data from excel sheet
                CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "Certifications");
                //Add CertificationName
                Driver.driver.FindElement(By.Name("certificationName")).SendKeys(CommonMethods.ExcelLib.ReadData(2, "Certificate"));
                //Add CertificationFrom
                Driver.driver.FindElement(By.Name("certificationFrom")).SendKeys(CommonMethods.ExcelLib.ReadData(2, "From"));
                //Choose the year
                IWebElement year = Driver.driver.FindElement(By.Name("certificationYear"));
                SelectElement yearDropdown = new SelectElement(year);
                yearDropdown.SelectByText(CommonMethods.ExcelLib.ReadData(2, "Year"));
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            try
            {
                //click add
                Driver.driver.FindElement(By.XPath("//input[contains(@value,'Add')]")).Click();
            }
            catch (NoSuchElementException)
            {
                return;
            }
        }

        [Then(@"i should me able to add certification details")]
        public void ThenIShouldMeAbleToAddCertificationDetails()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Certification");
                int tempValue = 0;
                Thread.Sleep(1000);
                //Find the no of Table body 
                IReadOnlyCollection<IWebElement> NoOfRows = Driver.driver.FindElements(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody"));
                for (int i = 1; i <= NoOfRows.Count; i++)
                {
                    string ExpectedValue = CommonMethods.ExcelLib.ReadData(2, "Certificate");
                    string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody[" + i + "]/tr/td[1]")).Text;
                    Thread.Sleep(500);
                    if (ExpectedValue == ActualValue)
                    {
                        CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added Certification Successfully");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "CertificationAdded");
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