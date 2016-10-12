using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace iClickerAutomation
{
	public class CoursesPageActions : WebBaseAction
	{
		IWebDriver driver;

		[FindsBy(How = How.XPath, Using = "//button[text()='Add a Course']")]
		private IWebElement btn_addACourse;

		[FindsBy(How = How.Id, Using = "searchInput")]
		private IWebElement inp_search;

		[FindsBy(How = How.XPath, Using = "//ul[@id='-search-results']//span")]
		private IWebElement txt_institutionName;

		[FindsBy(How = How.XPath, Using = "//ul[@id='-search-results']//span")]
		private IWebElement txt_courseName;

		[FindsBy(How = How.XPath, Using = "//button[text()='Add This Course']")]
		private IWebElement btn_addThisCourse;

		[FindsBy(How = How.CssSelector, Using = ".btn.join-button")]
		private IWebElement btn_join;

		[FindsBy(How = How.XPath, Using = "//button[text()='A']")]
		private IWebElement btn_optionA;

		[FindsBy(How = How.CssSelector, Using = ".form-group.numeric-answer-textarea textarea")]
		private IWebElement inp_numeric;

		[FindsBy(How = How.Id, Using = "shortAnswerInput")]
		private IWebElement inp_shortAnswer;

		[FindsBy(How = How.XPath, Using = "//button[text()='Send']")]
		private IWebElement btn_send;

		public CoursesPageActions(IWebDriver driver) : base(driver) {
			this.driver = driver;
		}

		public void clickOnAddACourseButton() {
			hardWait (1);
			verifyPageTitle ("REEF Education - Courses");
			btn_addACourse.Click ();
			logMessage ("Clicked on Add a Course button");
		}

		public void findInstitution(String institutionName) {
			verifyPageTitle ("REEF Education - Find Your Institution");
			inp_search.SendKeys (institutionName);
			logMessage ("User enters " + institutionName + " in fnd institution field");
			txt_institutionName.Click ();
			logMessage ("User selects institution from results");
		}

		public void findCourse(String courseName) {
			hardWait (1);
			verifyPageTitle ("REEF Education - Find Your Instructor");
			inp_search.SendKeys (courseName);
			logMessage ("User enters " + courseName + " in find course field");
			txt_courseName.Click ();
			logMessage ("User selects course from results");
		}

		public void clickOnAddToThisCourse() {
			verifyPageTitle ("REEF Education - Confirm Course");
			btn_addThisCourse.Click ();
			logMessage ("Clicked on Add this course button");
		}

		public void selectCourse(String courseName) {
			hardWait (1);
			verifyPageTitle ("REEF Education - Courses");
			driver.FindElement (By.XPath ("//label[text()='" + courseName + "']")).Click ();
			logMessage ("Clicked on " + courseName);
			hardWait (1);
			verifyPageTitle ("REEF Education - "+courseName);
		}

		public void clickOnJoinButton() {
			btn_join.Click ();
			logMessage ("Clicked on Join button");
		}

		public void selectOption() {
			hardWait (3);
			btn_optionA.Click ();
			logMessage ("Clicked on option A");
			hardWait (5);
		}

		public void attemptNumericQuestion() {
			inp_numeric.SendKeys ("123");
			logMessage ("User enters 123 as answer");
			btn_send.Click ();
			logMessage ("Clicked on Send Button");
		}

		public void attemptShortAnswerQuestion() {
			inp_shortAnswer.SendKeys ("abc123");
			logMessage ("User enters abc123 as short answer");
			btn_send.Click ();
			logMessage ("Clicked on Send Button");
		}

	}
}

