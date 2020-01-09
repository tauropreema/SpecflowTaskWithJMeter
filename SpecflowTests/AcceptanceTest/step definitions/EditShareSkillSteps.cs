using NUnit.Framework;
using OpenQA.Selenium;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests.AcceptanceTest.step_definitions
{
    [Binding]
    public class EditShareSkillSteps
    {
        private int i;

        [Given(@"I have Loggined and Clicked on manage listing")]
        public void GivenIHaveLogginedAndClickedOnManageListing()
        {
            //Click on Manage Listing Button
            IWebElement ClickManageListing = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[3]"));
            ClickManageListing.Click();


        }

        [Given(@"I have Clicked on Edit and Edited details")]
        public void GivenIHaveClickedOnEditAndEditedDetails()
        {
            try
            {
                for (i = 1; i <= i++; i++)
                {
                    //Start the Reports
                    CommonMethods.ExtentReports();
                    Thread.Sleep(1000);
                    CommonMethods.test = CommonMethods.extent.StartTest("Edit a Skill Details");


                    IWebElement Validatetitle = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[3]"));
                    //*[@id="listing-management-section"]/div[2]/div[1]/div[1]/table/tbody/tr[2]/td[3]
                    //*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]
                    IWebElement ClickEditButton = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[" + i + "]/td[8]/div/button[2]/i"));
                    if (Validatetitle.Text == "Performance Testing")
                    {
                        //Click on Edit nad Adde details

                        ClickEditButton.Click();
                        CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Got Titleto edit Successful");
                        Assert.Pass("Edit title clicked");
                        break;
                       


                    }
                }

                    //else
                    //{
                    //    Console.WriteLine("unSuccessfull edit button clicked");
                       
                    //}
                    
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
           


                
        }

        [When(@"I press Save")]
        public void WhenIPressSave()
        {
            Thread.Sleep(1000);
            CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "ShareSkills");
            Thread.Sleep(1000);
            IWebElement EditTitle = Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input"));
            Thread.Sleep(1000);
            EditTitle.Clear();
            Thread.Sleep(1000);
            EditTitle.SendKeys(CommonMethods.ExcelLib.ReadData(2, "EditTitle"));



            Thread.Sleep(1000);
            //EditDesription
            IWebElement EditDesription = Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea"));
            Thread.Sleep(1000);
            EditDesription.Clear();
            Thread.Sleep(1000);
            EditDesription.SendKeys(CommonMethods.ExcelLib.ReadData(2, "EditDescription"));
            //ClickSave
            IWebElement ClickSaveEdit = Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]"));
            ClickSaveEdit.Click();
        }


        [Then(@"the Shareskills should be added")]
        public void ThenTheShareskillsShouldBeAdded()
        {
            //Validation
            //Validatetitle


            try
            {
                for (i = 1; i <= i++; i++)
                {
                    //Start the Reports
                    CommonMethods.ExtentReports();
                    Thread.Sleep(2000);
                    CommonMethods.test = CommonMethods.extent.StartTest("Edit a Skill Details");
                    IWebElement Validatetitle = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr["+i+"]/td[3]"));

                    Thread.Sleep(1000);
                    if (Validatetitle.Text == "Performance Testing")
                    {
                        CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "EditTitle Successful");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "Edit Shareskills added");
                        Console.WriteLine("Success");
                        break;
                    }
                    else
                    {
                        CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Edit Share Skill Unsuccessful");
                        Console.WriteLine("Success");
                    }
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
    }

