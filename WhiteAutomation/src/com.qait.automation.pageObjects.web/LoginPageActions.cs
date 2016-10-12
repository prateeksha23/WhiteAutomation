using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace iClickerAutomation
{
	public class LoginPageActions : WebBaseAction
	{
		IWebDriver driver;

		[FindsBy(How = How.LinkText, Using = "Create a New Account")]
		private IWebElement btn_createNewAccount;

		[FindsBy(How = How.Id, Using="firstName")]
		private IWebElement inp_firstName;

		[FindsBy(How = How.Id, Using="lastName")]
		private IWebElement inp_lastName;

		[FindsBy(How = How.Id, Using="userEmail")]
		private IWebElement inp_email;

		[FindsBy(How = How.Id, Using="userPassword")]
		private IWebElement inp_password;

		[FindsBy(How = How.Id, Using="confirmPassword")]
		private IWebElement inp_confirmPassword;

		[FindsBy(How = How.XPath, Using="//input[@aria-describedby='studentAgreement']")]
		private IWebElement chkbox_iAgree;

		[FindsBy(How = How.XPath, Using="//button[text()='Create Account']")]
		private IWebElement btn_createAccount;

		[FindsBy(How = How.XPath, Using="//div[@id='account-create-page']//button")]
		private IWebElement btn_signInToReefEducation;

		[FindsBy(How = How.XPath, Using="//button[text()='Sign In']")]
		private IWebElement btn_signIn;

		[FindsBy(How = How.XPath, Using="//form[@ng-submit='addClicker()']//a")]
		private IWebElement btn_notAtThisTime;

		public LoginPageActions(IWebDriver driver) : base(driver) {
			this.driver = driver;
		}

		public void clickOnCreateANewAccountButton() {
			verifyPageTitle ("REEF Education - Login");
			btn_createNewAccount.Click();
			logMessage ("Clicked on Create a New Account button");
		}

		public void createNewStudent(String studentEmail) {
			hardWait (2);
			verifyPageTitle ("REEF Education - Create Account");
			inp_firstName.SendKeys ("First");
			logMessage ("User enters First in first name field");
			inp_lastName.SendKeys ("Last");
			logMessage ("User enters Last in last name field");
			inp_email.SendKeys (studentEmail);
			logMessage ("User enters " + studentEmail + " in email field");
			inp_password.SendKeys ("password");
			logMessage ("User enters password in password field");
			inp_confirmPassword.SendKeys ("password");
			logMessage ("User enters password in confirm password field");
			chkbox_iAgree.Click ();
			logMessage ("User checks student agreement checkbox");
			btn_createAccount.Click ();
			logMessage ("Clicked on Create Account button");
			hardWait (2);
			verifyPageTitle ("REEF Education");
		}

		public void clickOnSignInToReefEduction() {
			hardWait (2);
			btn_signInToReefEducation.Click ();
			logMessage ("Clicked on Sign In To Reef Education button");
		}

		public void loginToReefEducation(String studentEmail) {
			hardWait (2);
			verifyPageTitle ("REEF Education - Login");
			inp_email.SendKeys (studentEmail);
			logMessage ("User enters " + studentEmail + " in email field");
			inp_password.SendKeys ("password");
			logMessage ("User enters password in password field");
			driver.FindElement (By.XPath ("//button[text()='Sign In']")).Click ();
			logMessage ("Clicked on Sign In button");
		}

		public void clickOnNotAtThisTimeButton() {
			hardWait (2);
			btn_notAtThisTime.Click ();
			logMessage ("Clicked on Not at this time button");
		}
	}
}

