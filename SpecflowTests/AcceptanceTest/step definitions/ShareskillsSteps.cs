using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecflowPages;
using System;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;
//using AutoIt;

namespace SpecflowTests.AcceptanceTest.step_definitions
{
    [Binding]
    public class ShareskillsSteps
    {
        private int i;

        [Given(@"I have loggined and clicked on shareskill button")]
        public void GivenIHaveLogginedAndClickedOnShareskillButton()
        {
            //Click on shareskill button
            Driver.driver.FindElement(By.CssSelector("div.ui:nth-child(1) div:nth-child(1) section.nav-secondary:nth-child(2) div.ui.eight.item.menu div.right.item:nth-child(5) > a.ui.basic.green.button")).Click();
        }

        [Given(@"I have entered all the data in to the fields")]
        public void GivenIHaveEnteredAllTheDataInToTheFields()
        {
            CommonMethods.ExcelLib.PopulateInCollection(ConstantUtils.ExcelPath, "ShareSkills");
            //Title
            IWebElement Title = Driver.driver.FindElement(By.Name("title"));
            Title.SendKeys(CommonMethods.ExcelLib.ReadData(2, "title"));
            //Description
            IWebElement Description = Driver.driver.FindElement(By.Name("description"));
            Description.SendKeys(CommonMethods.ExcelLib.ReadData(2, "EnterDescription"));
            //Category
            IWebElement Category = Driver.driver.FindElement(By.Name("categoryId"));
            Category.Click();
            // Select Graphics & Design
            IWebElement GraphicsDesign = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(3) div.twelve.wide.column div.fields div.five.wide.field:nth-child(1) select.ui.fluid.dropdown > option:nth-child(2)"));
            GraphicsDesign.Click();
            //SubCategory
            IWebElement SubCategory = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(3) div.twelve.wide.column div.fields div.five.wide.field:nth-child(2) div.fields:nth-child(1) > select.ui.fluid.dropdown"));
            SubCategory.Click();
            //LogoDesign 
            IWebElement LogoDesign = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(3) div.twelve.wide.column div.fields div.five.wide.field:nth-child(2) div.fields:nth-child(1) select.ui.fluid.dropdown > option:nth-child(2)"));
            LogoDesign.Click();
            //Tags
            IWebElement Tag = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(4) div.twelve.wide.column div.form-wrapper.field div.ReactTags__tags div.ReactTags__selected div.ReactTags__tagInput > input.ReactTags__tagInputField"));
            Tag.SendKeys(CommonMethods.ExcelLib.ReadData(2, "TagName"));
            Console.WriteLine("Tagname success");
            Tag.SendKeys(Keys.Enter);
            Console.WriteLine("KeysEnter255line success");
            //Servicetype
            IWebElement ServiceTypeHourly = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(5) div.twelve.wide.column div.inline.fields div.field:nth-child(1) div.ui.radio.checkbox > label:nth-child(2)"));
            if (CommonMethods.ExcelLib.ReadData(2, "ServiceType") == "Hourly basis service")
            {
                ServiceTypeHourly.Click();
                Console.WriteLine("Servicetypehourly success");
            }
            else if (CommonMethods.ExcelLib.ReadData(2, "ServiceType") == "One-off service")
            {
                //ServiceTypeOnOff 
                IWebElement ServiceTypeOnOff = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(5) div.twelve.wide.column div.inline.fields div.field:nth-child(1) div.ui.radio.checkbox > label:nth-child(2)"));
                ServiceTypeOnOff.Click();
                Console.WriteLine("Servicetypeonoff success");
            }

            //LocationTypeOnsite 
            IWebElement LocationTypeOnsite = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(6) div.twelve.wide.column div.inline.fields div.field:nth-child(1) div.ui.radio.checkbox > label:nth-child(2)"));
            if (CommonMethods.ExcelLib.ReadData(2, "SelectLocationType") == "On-site")
            {
                LocationTypeOnsite.Click();
                Console.WriteLine("LocationTypeonsite success");
            }
            else if (CommonMethods.ExcelLib.ReadData(2, "SelectLocationType") == "Online")
            {
                //LocationTypeOnline 
                IWebElement LocationTypeOnline = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(6) div.twelve.wide.column div.inline.fields div.field:nth-child(2) div.ui.radio.checkbox > input:nth-child(1)"));
                LocationTypeOnline.Click();
                Console.WriteLine("LocationTypeOnline success");
            }

            //StartDate
            IWebElement StartDate = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(7) div.twelve.wide.column div.form-wrapper div.fields:nth-child(1) div.five.wide.field:nth-child(2) > input:nth-child(1)"));
            StartDate.SendKeys(CommonMethods.ExcelLib.ReadData(2, "StartDate"));
            Console.WriteLine("StartDate");
            //EndDate
            IWebElement EndDate = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(7) div.twelve.wide.column div.form-wrapper div.fields:nth-child(1) div.five.wide.field:nth-child(4) > input:nth-child(1)"));
            EndDate.SendKeys(CommonMethods.ExcelLib.ReadData(2, "EndDate"));
            Console.WriteLine("EndDate");
            //Select Weekday
            IWebElement Weekday = Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[1]/div/input"));
            Weekday.Click();
            //StartTime
            IWebElement StartTime = Driver.driver.FindElement(By.Name("StartTime"));
            StartTime.SendKeys(CommonMethods.ExcelLib.ReadData(2, "StartTime"));
            Console.WriteLine("StartTime");
            //EndTime
            IWebElement EndTime = Driver.driver.FindElement(By.Name("EndTime"));
            EndTime.SendKeys(CommonMethods.ExcelLib.ReadData(2, "EndTime"));
            Console.WriteLine("EndTime");


            //SkillExchange
            IWebElement SkillExchange = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(8) div.twelve.wide.column:nth-child(2) div.inline.fields div.field:nth-child(1) div.ui.radio.checkbox > label:nth-child(2)"));
            if (CommonMethods.ExcelLib.ReadData(2, "SelectSkillTrade") == "Skill-exchange")
            {
                //RequiredSkills
                IWebElement RequiredSkills = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(8) div.twelve.wide.column:nth-child(4) div.field div.form-wrapper div.ReactTags__tags div.ReactTags__selected div.ReactTags__tagInput > input.ReactTags__tagInputField"));
                RequiredSkills.Click();
                RequiredSkills.SendKeys(CommonMethods.ExcelLib.ReadData(2, "ExchangeSkill"));
                RequiredSkills.SendKeys(Keys.Enter);

            }
            else if (CommonMethods.ExcelLib.ReadData(2, "SelectSkillTrade") == "Credit")
            {
                //SkillTrade Amount
                IWebElement CreditAmount = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(8) div.ten.wide.column:nth-child(4) div:nth-child(1) div.ui.right.labeled.input > input:nth-child(2)"));
                CreditAmount.Click();
                CreditAmount.SendKeys(CommonMethods.ExcelLib.ReadData(2, "AmountInExchange"));
                CreditAmount.SendKeys(Keys.Enter);
            }

            //SkillTrade credit
            // IWebElement Credit = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(8) div.twelve.wide.column:nth-child(2) div.inline.fields div.field:nth-child(2) div.ui.radio.checkbox > label:nth-child(2)"));

            //WorkSample
            IWebElement WorkSample = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(9) div.row div.twelve.wide.column div:nth-child(1) label.worksamples-file:nth-child(1) div.ui.grid span:nth-child(1) > i.huge.plus.circle.icon.padding-25"));
            IWebElement upload = Driver.driver.FindElement(By.XPath("//*[@id='selectFile']"));

            // Uploading File path



            // Uploading File path
           var GetCurrentDirectory = Directory.GetCurrentDirectory();
            string path = GetCurrentDirectory + @"\SpecflowPages\TestReports\Upload Files\Samplework.txt";
            upload.SendKeys(path);


            //Active

            IWebElement StatusActive = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(10) div.twelve.wide.column div.inline.fields div.field:nth-child(1) div.ui.radio.checkbox > label:nth-child(2)"));

            if (CommonMethods.ExcelLib.ReadData(2, "UserStatus") == "Active")
            {
                StatusActive.Click();
            }
            else if (CommonMethods.ExcelLib.ReadData(2, "UserStatus") == "Hidden")
            {
                IWebElement StatusHidden = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(10) div.twelve.wide.column div.inline.fields div.field:nth-child(2) div.ui.radio.checkbox > label:nth-child(2)"));
                StatusHidden.Click();
            }

        }

        [When(@"I press save")]
        public void WhenIPressSave()
        {
            //Save

            IWebElement ClickSave = Driver.driver.FindElement(By.CssSelector("div.ui.container:nth-child(3) div.listing form.ui.form div.ui.vertically.padded.right.aligned.grid:nth-child(11) div.sixteen.wide.column > input.ui.teal.button:nth-child(1)"));
            ClickSave.Click();
            Driver.driver.Navigate().Refresh();
             Driver.driver.Navigate().Back();
            IWebElement ClickManageListingModule = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[3]"));
            
           // Actions actions = new Actions(Driver.driver);
           // actions.MoveToElement(ClickManageListingModule);
           // actions.Perform();
            ClickManageListingModule.Click();
        }

        [Then(@"the shareskill details should be added")]
        public void ThenTheShareskillDetailsShouldBeAdded()
        {
            try
            {
                for (i = 1; i <= i++; i++)
                {
                    CommonMethods.ExtentReports();
                    CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill Details");
                    //Click on Manage Listing
                  // IWebElement ClickManageListingModule = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[3]"));
                  // ClickManageListingModule.Click();
                   // Driver.driver.Navigate().Refresh();
                    Thread.Sleep(1000);
                    string ShareSkillSucess = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr["+i+"]/td[3]")).Text;

                    Thread.Sleep(1000);

                    if (ShareSkillSucess == "Testing with Java")
                    {
                        CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Shared Skill Successful");
                        SaveScreenShotClass.SaveScreenshot(Driver.driver, "added");
                        break;
                    }
                    else
                    {
                        CommonMethods.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Share Skill Unsuccessful");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
    }
}
