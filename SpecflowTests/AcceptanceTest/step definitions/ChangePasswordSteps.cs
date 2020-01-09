using OpenQA.Selenium;
using SpecflowPages;
using System;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class ChangePasswordSteps
    {
        [Given(@"I clicked on the change password on Profile page")]
        public void GivenIClickedOnTheChangePasswordOnProfilePage()
        {
            try
            {
                IWebElement HiMessage = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));
                HiMessage.Click();
                IWebElement ChangePassword = Driver.driver.FindElement(By.XPath("//a[contains(.,'Change Password')]"));
                ChangePassword.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [When(@"I add a new password")]
        public void WhenIAddANewPassword()
        {
            try
            {
                IWebElement OldPassword = Driver.driver.FindElement(By.Name("oldPassword"));
                IWebElement NewPassword = Driver.driver.FindElement(By.Name("newPassword"));
                IWebElement ConfirmPassword = Driver.driver.FindElement(By.Name("confirmPassword"));
                IWebElement ProfileSave = Driver.driver.FindElement(By.XPath("//button[@role='button']"));
                CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "ChangePassword");
                OldPassword.SendKeys(CommonMethods.ExcelLib.ReadData(2, "CurrentPassword"));
                NewPassword.SendKeys(CommonMethods.ExcelLib.ReadData(2, "NewPassword"));
                ConfirmPassword.SendKeys(CommonMethods.ExcelLib.ReadData(2, "NewPassword"));
                ProfileSave.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [Then(@"that password should be changed")]
        public void ThenThatPasswordShouldBeChanged()
        {
            try
            {
                CommonMethods.ExtentReports();
                //extent Reports              
                CommonMethods.test = CommonMethods.extent.StartTest("Change Password test");
                string ChangePasswordSuccess = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3")).Text;
                if (ChangePasswordSuccess == "Description")
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Password changed successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Password changed successfully");
                }
                else
                {
                    CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Password not changed successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "Password changed successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}