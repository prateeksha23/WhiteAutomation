using System;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.Factory;
using System.Windows.Automation;
using System.Diagnostics;
using System.Runtime.InteropServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using NLog;

namespace iClickerAutomation
{
	public class WebBaseAction
	{
		IWebDriver driver;

		public WaitUtil wait; 
		private static Logger logger = LogManager.GetCurrentClassLogger();

		public WebBaseAction(IWebDriver driver) {
			this.driver = driver;
			wait = new WaitUtil (driver);
			PageFactory.InitElements (driver, this);
		}

		public void hardWait(int seconds) {
			System.Threading.Thread.Sleep(seconds*1000);
		}

		public void verifyPageTitle(String title) {
			StringAssert.AreEqualIgnoringCase (title, driver.Title, "Assertion Failed : Current page title is not correct");
			logMessage ("Assertion Passed : Current page title is "+title);
		}

		public void logMessage(String message) {
			logger.Info (message);
		}
	}
}

