using System;
using System.Threading;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;



namespace android
{
    [TestFixture("single", "galaxy-s9")]
    public class SingleTest : BrowserStackNUnitTest
    {
        

        public SingleTest(string profile, string device) : base(profile, device) { }



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

        [Test()]

        public void setOfflinePropertiesAndSave()
        {
            testPOMLogIn();
            MapPageLeo mapPageLeo = new MapPageLeo(driver);

            MenuTabsPage menuTabsPage = mapPageLeo.openMenu();
            Assert.IsTrue(menuTabsPage.IsDisplayed);
            SetOfflineProperiesPage setOfflineProperiesPage = menuTabsPage.openSetOfflinePropertiesPage();
            setOfflineProperiesPage.ClickAcceptConnectionWaringButtonIfPresent();
            setOfflineProperiesPage.SelectPropertiesToBeSyncked();
            setOfflineProperiesPage.ClickSaveButton();
            Assert.IsTrue(mapPageLeo.isDisplayedAfterSynckingProperiesFromOfflinePage);

        }

        [Test()]

        public void launchUnitWorkflow()
        {
            testPOMLogIn();
            MapPageLeo mapPageLeo = new MapPageLeo(driver);

            MenuTabsPage menuTabsPage = mapPageLeo.openMenu();
            Assert.IsTrue(menuTabsPage.IsDisplayed);
            LaunchUnitWorkflowPage launchUnitWorkflowPage = menuTabsPage.openLaunchUnitWorkflowPage();
            UnitWorkflowDetailsPage unitWorkflowDetailsPage = launchUnitWorkflowPage.ClickOnLaunchButtonOfSelectedUnitWorkflow();
            unitWorkflowDetailsPage.EnterNameOfUnitWorkflow();
            unitWorkflowDetailsPage.SelectPropertiesAndDate();
            SelectUnitPage selectUnitPage = unitWorkflowDetailsPage.ClickLaunchButton();
            selectUnitPage.FilterUnits();
            UnitWorkflowTasksPage unitWorkflowTasksPage = selectUnitPage.SelectUnitsandClickLaunch();
            Assert.IsTrue(unitWorkflowTasksPage.IsDisplayed);
            UnitFilterPage unitFilterPage = unitWorkflowTasksPage.ClickOnFilterBy();
            Assert.IsTrue(unitFilterPage.IsDisplayed);
            unitFilterPage.EnterUnitNumberAndBuildingAndPressFilterButton();
            Assert.IsTrue(unitWorkflowTasksPage.IsDisplayed);
            Assert.IsTrue(unitWorkflowTasksPage.FilterDisplayCorectResults);



        }



    }
}
