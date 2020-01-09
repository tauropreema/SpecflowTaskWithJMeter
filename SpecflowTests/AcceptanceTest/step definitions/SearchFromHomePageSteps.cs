using OpenQA.Selenium;
using SpecflowPages;
using System;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class SearchFromHomePage
    {
        [Given(@"I write and clicked on the search on Profile page.")]
        public void GivenIWriteAndClickedOnTheSearchOnProfilePage()
        {
            try
            {
                CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "SearchSkills");
                IWebElement SearchSkills = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[1]/input"));
                IWebElement SearchIcon = Driver.driver.FindElement(By.XPath("//i[@class='search link icon']"));
                //Search on Search skills               
                SearchSkills.SendKeys(CommonMethods.ExcelLib.ReadData(2, "SearchSkillsByCategory"));
                SearchIcon.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Then(@"the results should be displayed based on search.")]
        public void ThenTheResultsShouldBeDisplayedBasedOnSearch()
        {
            try
            {
                CommonMethods.ExtentReports();
                //extent Reports              
                CommonMethods.test = CommonMethods.extent.StartTest("Search test");
                IWebElement Results = Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[1]/h3"));
                if (Results.Text == "Refine Results")
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Results shown successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Results shown successfully");
                }
                else
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Results not shown successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Results not shown successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
