using System;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace android
{
    public class DynamicFormPage
    {
        
       public DynamicFormPage(AndroidDriver<AndroidElement> driver)
       {
           this.driver = driver;
            
        }

        private AndroidDriver<AndroidElement> driver;
        
        internal bool? taskIsCompleted => new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@text='Task completed!']"))).Displayed;

        private AndroidElement deleteButton => driver.FindElement(By.XPath("//*[@text='Delete']"));
        private AndroidElement timeToCompleteTaskTextField => driver.FindElement(By.XPath("//android.widget.EditText[@index='4']"));
        private AndroidElement completeTaskButton => driver.FindElement(By.XPath("//*[@text='Complete Task']"));

        private AndroidElement completeDFbutton => driver.FindElement(By.XPath("//*[@text='FINISH']"));

        private AndroidElement skipButton => driver.FindElement(By.XPath("//*[@text='SKIP']"));

        public void SWipeUntilelementVisible(string ElementID)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            var SendRequirementForScroll = wait.Until(x => x.FindElements(By.XPath(ElementID)));

            bool visible = false;
            int counter = 0;

            try
            {
                while (visible == false)
                {
                    if (counter == 0 && visible == false)
                    {
                        driver.Swipe(525, 1520, 518, 630, 0);
                        counter++;
                    }

                    else
                    {
                        driver.Swipe(525, 1520, 518, 630, 0);
                        var SendRequirementForScrollTmp = wait.Until(x => x.FindElements(By.XPath(ElementID)));
                        if (SendRequirementForScrollTmp.Count > 0)
                        {
                            counter++;
                            visible = true;
                            Console.WriteLine("Element became visible");
                            break;
                        }
                    }
                }
            }

            catch { }
        }


        private bool IsSkipDFPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        internal void tapOnSkipButtonAndCompleteTask()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@text='TASK FORM']")));
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath("//android.widget.FrameLayout[1]/android.widget.LinearLayout[1]/android.widget.FrameLayout[1]/android.widget.FrameLayout[1]/android.view.ViewGroup[1]/android.widget.FrameLayout[1]/android.widget.ProgressBar[1]")));
            if (IsSkipDFPresent(By.XPath("//*[@text='SKIP']")))
            {
                skipButton.Click();
               
            }
            else
            {
                completeDFbutton.Click();
            }
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@text='Delete']")));
            deleteButton.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//android.widget.EditText[@index='4']")));

            SWipeUntilelementVisible("//*[@text='Complete Task']");
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@text='Complete Task']")));
            completeTaskButton.Click();

        }
    }
}