using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System;

namespace android
{
    internal class MapPageLeo
    {
        private AndroidDriver<AndroidElement> driver;
        internal bool? isDisplayedAfterSynckingProperiesFromOfflinePage;

        public AndroidElement menuButton => driver.FindElement(By.XPath("//hierarchy/android.widget.FrameLayout[1]/android.widget.LinearLayout[1]/android.widget.FrameLayout[1]/android.widget.FrameLayout[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.support.v4.widget.DrawerLayout[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.widget.ImageView[1]"));

        public MapPageLeo(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public bool? IsLoadedAfterLogIn => new WebDriverWait(driver, TimeSpan.FromSeconds(90)).Until(ExpectedConditions.ElementExists(By.XPath("//android.view.View[@content-desc='Google Map']"))).Displayed;

        internal MenuTabsPage openMenu()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//hierarchy/android.widget.FrameLayout[1]/android.widget.LinearLayout[1]/android.widget.FrameLayout[1]/android.widget.FrameLayout[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.support.v4.widget.DrawerLayout[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.widget.ImageView[1]")));
            menuButton.Click();
            return new MenuTabsPage(driver);
        }
    }
}