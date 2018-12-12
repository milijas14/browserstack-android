using System;
using System.Threading;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace android
{
  [TestFixture("parallel", "pixel")]
  [TestFixture("parallel", "nexus6")]
  
  [Parallelizable(ParallelScope.Fixtures)]
  public class ParallelTest : BrowserStackNUnitTest
  {
    public ParallelTest(string profile, string device) : base(profile,device){ }


        [Test()]

        public void testPOMLogIn()
        {
            LogInPageLeo logInPageLeo = new LogInPageLeo(driver);
            Assert.IsTrue(logInPageLeo.IsLoaded);
            MapPageLeo mapPageLeo = logInPageLeo.EnterCredentialsAndLogIn("milos.milicevic@acumenics.com", "pass1234");
            Assert.IsTrue(mapPageLeo.IsLoadedAfterLogIn);
        }

        [Test()]

        public void skipDFandCompleteTask()
        {
            testPOMLogIn();
            MapPageLeo mapPageLeo = new MapPageLeo(driver);

            MenuTabsPage menuTabsPage = mapPageLeo.openMenu();
            Assert.IsTrue(menuTabsPage.IsDisplayed);
            PropertyTasksPage propertyTasksPage = menuTabsPage.openTasksPage();
            Assert.IsTrue(propertyTasksPage.IsDisplayed);

            DynamicFormPage dynamicFormPage = propertyTasksPage.tapOnDFiconOnTask();
            dynamicFormPage.tapOnSkipButtonAndCompleteTask();
            Assert.IsTrue(dynamicFormPage.taskIsCompleted);
        }
    }
}
