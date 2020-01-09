using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class SearchSteps
    {
        [When(@"I enter the category or subcategory name.")]
        public void WhenIEnterTheCategoryOrSubcategoryName()
        {
            CommonMethods.ExcelLib.ReadData(2, "SearchSkills");
            IWebElement SearchSkills = Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[2]/input"));
            SearchSkills.SendKeys(CommonMethods.ExcelLib.ReadData(2, "Category"));
            SearchSkills.SendKeys(Keys.Enter);
        }

        [Then(@"the results should be displayed on the Search Page.")]
        public void ThenTheResultsShouldBeDisplayedOnTheSearchPage()
        {
            try
            {
                CommonMethods.ExtentReports();
                //extent Reports              
                CommonMethods.test = CommonMethods.extent.StartTest("Search by category test");
                IWebElement Results = Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div"));
                // IWebElement NoResults = Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/h3"));
                CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Results shown successfully");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Results shown successfully");
            }
            catch (NoSuchElementException)
            {
                CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "No Results found");
            }
        }
        [When(@"I enter the user name.")]
        public void WhenIEnterTheUserName()
        {
            //Populate with excel data
            CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "SearchSkills");
            string FirstXpath = "//html/body/div/div/div/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div[";
            string SecondXpath = "]/div[1]/span[1]";
            //Find search user to type user name
            Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[1]/div[1]/i")).Click();
            Driver.WaitForElement(Driver.driver, By.XPath("//input[@placeholder='Search user']"), 60);
            Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[1]/div[1]/i")).Click();
            IWebElement SearchUser = Driver.driver.FindElement(By.XPath("//input[@placeholder='Search user']"));
            SearchUser.SendKeys(CommonMethods.ExcelLib.ReadData(2, "SearchUser"));
            SearchUser.SendKeys(Keys.Enter);
            Driver.WaitForElement(Driver.driver, By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div"), 1000);
            //Get the no of users list
            IList<IWebElement> SearchUserList = Driver.driver.FindElements(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[3]/div[1]/div/div[2]/div"));
            for (int rowNum = 2; rowNum <= SearchUserList.Count; rowNum++)
            {
                SearchUser.SendKeys(Keys.Enter);
                //Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[1]/div[1]/i")).Click();
                //SearchUser.SendKeys(CommonMethods.ExcelLib.ReadData(2, "SearchUser"));
                //SearchUser.SendKeys(Keys.Enter);
                Driver.WaitForElement(Driver.driver, By.XPath(FirstXpath + rowNum + SecondXpath), 60);
                IWebElement userList = Driver.driver.FindElement(By.XPath(FirstXpath + rowNum + SecondXpath));
                if (CommonMethods.ExcelLib.ReadData(2, "SearchUser") == userList.Text)
                {
                    userList.Click();
                    Thread.Sleep(3000);
                    try
                    {
                        IWebElement DisplayMessage = Driver.driver.FindElement(By.XPath("//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/h3"));
                        if (DisplayMessage.Text == "No results found, please select a new category!")
                        {
                            //do nothing
                        }
                    }
                    catch (NoSuchElementException)
                    {
                        //Exist = true;
                        return;
                    }
                }
            }
        }
    }

}