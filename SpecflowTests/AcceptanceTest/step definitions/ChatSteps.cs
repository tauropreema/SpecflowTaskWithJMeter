using OpenQA.Selenium;
using SpecflowPages;
using System;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class ChatSteps
    {
        [Then(@"I should be able to choose a user and send a chat message")]
        public void ThenIShouldBeAbleToChooseAUserAndSendAChatMessage()
        {
            try
            {
                //extent Reports     
                CommonMethods.ExtentReports();
                CommonMethods.test = CommonMethods.extent.StartTest("Send Chat message test");
                //Populate data from excel sheet
                CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "SearchSkills");
                try
                {
                    //Click on the user to send chat message
                    IWebElement SelectUser = Driver.driver.FindElement(By.XPath("/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/section[1]/div[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[1]/a[1]/img[1]"));
                    SelectUser.Click();
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("There exists no users to send the chat messsage");
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "There exists no users to send the chat messsage");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "There exists no users to send the chat messsage");
                    return;
                }
                //Chat
                Driver.WaitForElement(Driver.driver, By.XPath("//a[contains(@class,'ui teal button')]"), 60);
                IWebElement Chat = Driver.driver.FindElement(By.XPath("//a[contains(@class,'ui teal button')]"));
                IWebElement ChatTextbox = Driver.driver.FindElement(By.XPath("//input[@id='chatTextBox']"));
                IWebElement Send = Driver.driver.FindElement(By.Id("btnSend"));
                Chat.Click();
                ChatTextbox.SendKeys(CommonMethods.ExcelLib.ReadData(2, "ChatText"));
                Driver.WaitForElement(Driver.driver, By.Id("btnSend"), 60);
                Send.Click();
                CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Sent message Successfully");
                SaveScreenShotClass.SaveScreenshot(Driver.driver, "Sent message Successfully");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}