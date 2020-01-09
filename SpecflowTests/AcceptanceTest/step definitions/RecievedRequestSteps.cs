using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest.step_definitions
{
    [Binding]
    public class RecievedRequestSteps
    {
        [Given(@"I have Loggined and Clicked on ManageRequests")]
        public void GivenIHaveLogginedAndClickedOnManageRequests()
        {
            //Click on Manage request
            IWebElement ClickonManageRequest = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]"));
            ClickonManageRequest.Click();
        }
        
        [When(@"I Clicked on Received Request")]
        public void WhenIClickedOnReceivedRequest()
        {
            //Clicked on recieved request
            Thread.Sleep(2000);
            IWebElement ClickReceivedRequest = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[1]"));
            ClickReceivedRequest.Click();

        }
        
        [Then(@"i should be able to see Received reuqests")]
        public void ThenIShouldBeAbleToSeeReceivedReuqests()
        {
            try {
                //Validation
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Findind received request");
                string Expectedmanagerequest = "1";
            IWebElement Actualreceivedrequest = Driver.driver.FindElement(By.XPath("//*[@id='received-request-section']/div[2]/div[1]/div/button[2]"));
            if(Actualreceivedrequest.Text == Expectedmanagerequest)
            {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Requestfound Successful");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Requestfound Available");
                    Console.WriteLine("Success");
                }
                else
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Requestfound Unsuccessful");
                    Console.WriteLine("Falied");
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
