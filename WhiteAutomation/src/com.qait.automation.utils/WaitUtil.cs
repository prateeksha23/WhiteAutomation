using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace iClickerAutomation
{
	public class WaitUtil
	{
		IWebDriver driver;
		WebDriverWait wait;

		public WaitUtil(IWebDriver driver) {
			this.driver = driver;
			this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
		}

		public void waitForElementToBeVisible(By locator) {
			wait.Until (ExpectedConditions.ElementIsVisible (locator));
		}
	}
}

