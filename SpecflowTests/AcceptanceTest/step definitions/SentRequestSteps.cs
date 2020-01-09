using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest.step_definitions
{
    [Binding]
    public class SentRequestSteps
    {
        [Given(@"I have Loggined and Clicked on ManageRequests button")]
        public void GivenIHaveLogginedAndClickedOnManageRequestsButton()
        {
            //Click on Manage request
            IWebElement ClickonManageRequest = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]"));
            ClickonManageRequest.Click();
        }
        
        [When(@"I Clicked on Sent Request")]
        public void WhenIClickedOnSentRequest()
        {
            //Clicked on Sent request
            Thread.Sleep(2000);
            IWebElement ClickSentRequest = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[2]"));
            ClickSentRequest.Click();
        }
        
        [Then(@"i should be able to see Sent requests")]
        public void ThenIShouldBeAbleToSeeSentRequests()
        {
            try
            {
                //Validation
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Findind Sent request");
                string Expectedmanagerequest = "1";
                IWebElement Actualreceivedrequest = Driver.driver.FindElement(By.XPath("//*[@id='sent-request-section']/div[2]/div[1]/div[2]/button[2]"));
                if (Actualreceivedrequest.Text == Expectedmanagerequest)
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Sentfound Successful");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SentFound Available");
                    Console.WriteLine("Success");
                }
                else
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "SentFound Unsuccessful");
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
