using System;
using NUnit.Framework;

namespace iClickerAutomation
{
	
	[TestFixture ()]
	public class ToolbarTest
	{
		SessionInitiator session;
		String courseName = "TestCourse" + DateTime.Now.Ticks;

		[TestFixtureSetUp ()]
		public void init() {
			session = new SessionInitiator ();
		}


		[Test ()]
		public void Step01_createNewCourse() {
			session.mainWindow.setForgroundwindow ();
			session.mainWindow.clickOnCreateNewCourseButton ();
			session.createCourseWindow.enterCourseName (courseName);
			session.createCourseWindow.clickOnCreateButton ();
			session.mainWindow.verifyCourseCreated (courseName);
		}

		[Test ()]
		public void Step02_openSettingsForCreatedCourse() {
			session.mainWindow.clickOnSettingsButton ();
		}

		[Test ()]
		public void Step03_enableReefPolling() {
			session.courseSettingsWindow.clickOnReefPollingTab ();
			session.courseSettingsWindow.clickOnEnableReefPollingButton ();
			session.logInWindow.clickOnCreateAccountButton ();
			session.createAccountWindow.enterDetailsForAccount ();
			session.createAccountWindow.selectIAgreeCheckbox ();
			session.createAccountWindow.clickOnCreateButton ();
			session.courseDetailsWindow.enterInstitutionDetails (YamlReader.getData("course.institutionName"));
			session.courseDetailsWindow.enterCourseName (courseName);
			session.courseDetailsWindow.clickOnCreateButton ();
			session.courseDetailsWindow.verifyCourseDetails ();
			session.courseSettingsWindow.clickOnSaveButton ();
			session.courseSettingsWindow.switchToMainWindow ();
			session.mainWindow.verifyStartSessionButtonEnabled ();
		}

		[Test ()]
		public void Step04_startNewSession () {
			session.mainWindow.clickOnStartNewSessionButton ();
		}

		[Test ()]
		public void Step05_verifyButtonsPresentOnToolsbar() {
			session.toolbarWindow.verifyButtonsPresentOnToolbar ();
		}

		[Test ()]
		public void Step06_verifyButtonsDisappearOnMimimizingTheToolbar() {
			session.toolbarWindow.clickOnMinimizeMaximizeButton ();
			session.toolbarWindow.verifyButtonsDisappearOnMinimize ();
		}

		[Test ()]
		public void Step07_verifyAllButtonsArePresentOnMaximizingTheToolabr() {
			session.toolbarWindow.clickOnMinimizeMaximizeButton ();
			session.toolbarWindow.verifyButtonsPresentOnToolbar ();
		}

		[Test ()]
		public void Step08_verifyTimerStartsOnStaringPoll() {
			session.toolbarWindow.clickOnStartStopPollingButton ();
			session.toolbarWindow.verifyTimerPanelAppears ();
		}

		[Test ()]
		public void Step09_createStudent () {
			session.initializeDriver ();
			session.launchUrl (YamlReader.getData("web.url"));
			String studentEmail = "Student" + DateTime.Now.Ticks + "@reef-education.com";
			session.loginPage.clickOnCreateANewAccountButton ();
			session.loginPage.createNewStudent (studentEmail);
			session.loginPage.clickOnSignInToReefEduction ();
			session.loginPage.loginToReefEducation (studentEmail);
			session.loginPage.clickOnNotAtThisTimeButton ();
		}

		[Test ()]
		public void Step10_addCourse() {
			session.coursePage.clickOnAddACourseButton ();
			session.coursePage.findInstitution (YamlReader.getData("course.institutionName"));
			session.coursePage.findCourse (courseName);
			session.coursePage.clickOnAddToThisCourse ();
		}

		[Test ()]
		public void Step11_joinSession() {
			session.coursePage.selectCourse (courseName);
			session.coursePage.clickOnJoinButton ();
			session.coursePage.selectOption ();
		}

		[Test ()]
		public void Step12_stopPolling() {
			session.toolbarWindow.clickOnStartStopPollingButton ();
		}

		[Test ()]
		public void Step13_startPollingForNumeric() {
			session.toolbarWindow.selectNumericOptionFromQuestions ();
			session.toolbarWindow.clickOnStartStopPollingButton ();
		}

		[Test ()]
		public void Step14_attemptNumericQuestion() {
			session.coursePage.attemptNumericQuestion ();
			session.toolbarWindow.clickOnStartStopPollingButton ();
		}

		[Test ()]
		public void Step15_startPollingForShortAnswer() {
			session.toolbarWindow.selectShortAnswerOptionFromQuestions ();
			session.toolbarWindow.clickOnStartStopPollingButton ();
		}

		[Test ()]
		public void Step16_attemptShortAnswerQuestion() {
			session.coursePage.attemptShortAnswerQuestion ();
			session.toolbarWindow.clickOnStartStopPollingButton ();
		}

		[Test ()]
		public void Step17_clickOnShowHideResultsIcon() {
			session.toolbarWindow.clickOnShowHideHistorgram ();
		}

		[Test ()]
		public void Step18_verifyQuestionsOnResultsChart() {
			session.resultsWindow.verifyQuestions ();
			session.resultsWindow.closeWindow ();
		}

		[Test ()]
		public void Step19_openCourseSettingsUsingKeys() {
			session.toolbarWindow.openCourseSettingsUsingKeys ();
			session.courseSettingsWindow.clickOnSaveButton ();
			session.mainWindow.switchToToolbar ();
		}

		[Test ()]
		public void Step20_setAnonymousPollingUsingKeys() {
			session.toolbarWindow.setAnonymousPollingUsingKeys ();
			//session.toolbarWindow.verifyAPTextOnToolbar ();
		}

		[Test ()]
		public void Step21_openResultsChartUsingKeys() {
			session.toolbarWindow.openResultsChartUsingKeys ();
		}

		[Test ()]
		public void Step22_closeResultsChartUsingKeys() {
			session.toolbarWindow.closeResultsChartUsingKeys ();
		}

		[Test ()]
		public void Step23_openRollCallRegistrationWindowUsingKeys() {
			session.toolbarWindow.openRollCallRegistrationWindowUsingKeys ();
		}

		[Test ()]
		public void Step24_startPollingUsingKeys() {
			session.toolbarWindow.startStopPollingUsingKeys ();
			session.toolbarWindow.verifyTimerPanelAppears ();
		}

		[Test ()]
		public void Step25_stopPollingUsingKeys() {
			session.toolbarWindow.startStopPollingUsingKeys ();
			session.toolbarWindow.verifyTimerPanelDisappearsOnStoppingPoll ();
		}

		[Test ()]
		public void Step26_minimizeToolBarUsingKeys() {
			session.toolbarWindow.maximizeMinimizeToolbarUsingKeys ();
			session.toolbarWindow.verifyButtonsDisappearOnMinimize ();
		}

		[Test ()]
		public void Step27_maximizeToolBarUsingKeys() {
			session.toolbarWindow.maximizeMinimizeToolbarUsingKeys ();
			session.toolbarWindow.verifyButtonsPresentOnToolbar ();
		}

		[Test ()]
		public void Step28_closeToolbarUsingKeys() {
			session.toolbarWindow.closeToolbarUsingKeys ();
		}

		[Test ()]
		public void Step29_verifymcOnlyParmInConfigFile() {
			session.baseActions.verifyValueInConfigFile ("mcOnly");
		}

		[Test ()]
		public void Step30_changemcOnlyValueToTrueAndVerify() {
			session.baseActions.changeValueInXml ("mcOnly", "true");
			session.closeSession ();
			session = new SessionInitiator ();
			session.mainWindow.clickOnStartNewSessionButton ();
			session.toolbarWindow.verifyOnlyMultipleChoiceQuestionAppears ();
			session.baseActions.changeValueInXml ("mcOnly", "false");
		}

		[Test ()]
		public void Step31_closeToolBar() {
			session.toolbarWindow.closeWindow ();
		}

		[TestFixtureTearDown ()]
		public void closeSession() {
			session.closeSession ();
			session.quitBrowser ();
		}

	}
}

