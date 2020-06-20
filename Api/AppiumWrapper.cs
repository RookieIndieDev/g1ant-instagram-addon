using System;
using System.Diagnostics;
using System.Windows.Forms;
using G1ANT.Language;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;
using System.IO;

namespace G1ANT.Addon.Instagram
{
    public class AppiumWrapper
    {
        private static AndroidDriver<AndroidElement> driver;
        public static string pword;
        public static string email;
        public static void AppiumOpen()
        {
            try
            {
                var appiumServiceBuilder = new AppiumServiceBuilder().UsingAnyFreePort();
                var desiredCapabilities = new AppiumOptions();
                desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Android");
                desiredCapabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppPackage, "com.instagram.android");
                desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
                desiredCapabilities.AddAdditionalCapability(AndroidMobileCapabilityType.AppActivity, "com.instagram.mainactivity.MainActivity");
                desiredCapabilities.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "");
                driver = new AndroidDriver<AndroidElement>(appiumServiceBuilder, desiredCapabilities);
            }
            catch (Exception ex)
            {
                InstallAppiumWhenExceptionOccured(ex);
            }
            AppiumWrapper.AppiumClick("//android.widget.TextView[@index='1']", "xpath");
            AppiumWrapper.AppiumTypeText("login_username", email, "id");
            AppiumWrapper.AppiumTypeText("password", pword, "id");
            AppiumWrapper.AppiumClick("button_text", "id");
        }

        private static void InstallAppiumWhenExceptionOccured(Exception ex)
        {
            if (ex.Message.StartsWith("Invalid"))
            {
                var result = RobotMessageBox.Show("It seems you have no Appium driver installed. Would you like to install it now?", "Error", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Process.Start("\"C:\\Program Files\\nodejs\\npm.cmd\"", "install -g appium");
                }
            }
            else { throw ex; }
        }

        public static AndroidDriver<AndroidElement> GetDriver()
        {
            return driver;
        }

        public static void AppiumClick(string input, string by)
        {
            ElementHelper.GetElement(by, input).Click();
        }

        public static void AppiumTypeText(string input, string text , string by)
        {
                ElementHelper.GetElement(by, input).SendKeys(text);
        }
    }
}
