using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;

namespace android
{
    internal class LogInPageLeo
    {
        private AndroidDriver<AndroidElement> driver;

        public LogInPageLeo(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }

        public bool? IsLoaded => new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.XPath("//*[@text='Login']"))).Displayed;
        public AndroidElement EmailBox => driver.FindElement(By.XPath("//hierarchy/android.widget.FrameLayout[1]/android.widget.LinearLayout[1]/android.widget.FrameLayout[1]/android.widget.FrameLayout[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.widget.ScrollView[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.widget.EditText[1]"));
        public AndroidElement PasswordBox => driver.FindElement(By.XPath("//hierarchy/android.widget.FrameLayout[1]/android.widget.LinearLayout[1]/android.widget.FrameLayout[1]/android.widget.FrameLayout[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.widget.ScrollView[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.view.ViewGroup[1]/android.widget.EditText[2]"));
        public AndroidElement LoginButton => driver.FindElement(By.XPath("//*[@text='Login']"));

        internal MapPageLeo EnterCredentialsAndLogIn(string email, string password)
        {
            EmailBox.SendKeys(email);
            PasswordBox.SendKeys(password);
            LoginButton.Click();

            return new MapPageLeo(driver);
        }
    }
}