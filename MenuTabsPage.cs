using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;


namespace android
{
    internal class MenuTabsPage
    {
        private AndroidDriver<AndroidElement> driver;
        public AndroidElement launchUnitWorkflowLink => driver.FindElementByXPath("//android.widget.FrameLayout[1]/android.widget.LinearLayout[1]/android.widget.FrameLayout[1]/android.widget.FrameLayout[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.support.v4.widget.DrawerLayout[1]/android.view.ViewGroup[2]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.widget.ScrollView[1]/android.view.ViewGroup[1]/android.view.ViewGroup[4]/android.view.ViewGroup[3]/android.widget.TextView[1]");

        public AndroidElement setOfflineproperiesLink => driver.FindElement(By.XPath(""));

        public AndroidElement propertyTasksLink => driver.FindElement(By.XPath("//*[@text='Tasks' and ./parent::*[(./preceding-sibling::* | ./following-sibling::*)[./*[@text='Property Tasks - Acumenics Salt Lake']]]]"));

        public MenuTabsPage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public bool? IsDisplayed => driver.FindElement(By.XPath("//*[@text='Tasks' and ./parent::*[(./preceding-sibling::* | ./following-sibling::*)[./*[@text='Property Tasks - Acumenics Salt Lake']]]]")).Displayed;

        internal PropertyTasksPage openTasksPage()
        {
            propertyTasksLink.Click();

            return new PropertyTasksPage(driver);
        }

       

        internal SetOfflineProperiesPage openSetOfflinePropertiesPage()
        {
            setOfflineproperiesLink.Click();
            return new SetOfflineProperiesPage(driver);
        }

        internal LaunchUnitWorkflowPage openLaunchUnitWorkflowPage()
        {
            launchUnitWorkflowLink.Click();
            return new LaunchUnitWorkflowPage(driver);
        }
    }
}