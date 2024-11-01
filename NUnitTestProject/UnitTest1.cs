using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;


namespace NUnitTestProject
{
    public class Tests
    {
        private AndroidDriver driver;

        [SetUp]
        public void Setup()
        {
            var options = new AppiumOptions();
            options.AddAdditionalAppiumOption("platformName", "Android");
            options.AddAdditionalAppiumOption("deviceName", "Android Emulator");
            options.AddAdditionalAppiumOption("app", "path/to/your/calculator.apk"); // Update with the actual APK path
            options.AddAdditionalAppiumOption("automationName", "UiAutomator2");
            options.AddAdditionalAppiumOption("noReset", true);

            driver = new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/wd/hub"), options);
        }

        [Test]
        public void AdditionTest()
        {
            // Find UI elements and perform operations
            var button1 = _driver.FindElementByAccessibilityId("Button1AccessibilityId");
            var buttonPlus = _driver.FindElementByAccessibilityId("ButtonPlusAccessibilityId");
            var button2 = _driver.FindElementByAccessibilityId("Button2AccessibilityId");
            var buttonEqual = _driver.FindElementByAccessibilityId("ButtonEqualAccessibilityId");
            var resultDisplay = _driver.FindElementByAccessibilityId("ResultDisplayAccessibilityId");

            button1.Click();
            buttonPlus.Click();
            button2.Click();
            buttonEqual.Click();

            Assert.AreEqual("3", resultDisplay.Text); // Change "3" to the expected result based on your calculator logic
        }

        [TearDownAttribute]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}