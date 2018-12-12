using System;
using OpenQA.Selenium.Appium.Android;

namespace android
{
    internal class SetOfflineProperiesPage
    {
        private AndroidDriver<AndroidElement> driver;

        public SetOfflineProperiesPage(AndroidDriver<AndroidElement> driver) => this.driver = driver;

        internal void ClickAcceptConnectionWaringButtonIfPresent()
        {
            throw new NotImplementedException();
        }

        internal void SelectPropertiesToBeSyncked()
        {
            throw new NotImplementedException();
        }

        internal void ClickSaveButton()
        {
            throw new NotImplementedException();
        }
    }
}