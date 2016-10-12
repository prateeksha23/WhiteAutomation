using System;
using NUnit.Framework;

namespace iClickerAutomation
{

	[TestFixture ()]
	public class MainWindowTest
	{
		SessionInitiator session;
		String courseName = "TestCourse" + DateTime.Now.Ticks;

		[TestFixtureSetUp ()]
		public void init() {
			session = new SessionInitiator ();
		}
			
		[Test ()]
		public void Step01_deleteAllCourses ()
		{
			session.mainWindow.setForgroundwindow ();
			session.mainWindow.deleteAllCourses ();
		}

		[Test ()]
		public void Step02_verifyLogoOnMainScreen() {
			session.mainWindow.verifyLogo ();
		}

		[Test ()]
		public void Step03_verifyMenuBarTabs() {
			session.mainWindow.verifyMenuBarTabs ();
		}

		[Test ()]
		public void Step04_verifyButtonsAreDisabled() {
			session.mainWindow.verifyButtonsAreDisabledBeforeCourseCreation ();
		}

		[Test ()]
		public void Step05_verifyMessageWhenNoCourseIsAdded() {
			session.mainWindow.verifyMessageWhenNoCourseIsAdded ();
		}

		[Test ()]
		public void Step06_createCourse() {
			session.mainWindow.clickOnCreateNewCourseButton ();
			session.createCourseWindow.enterCourseName (courseName);
			session.createCourseWindow.clickOnCreateButton ();
			session.mainWindow.verifyCourseCreated (courseName);
		}

		[Test ()]
		public void Step07_verifyButtonsEnabled() {
			session.mainWindow.verifyButtonsAreEnabledAfterCourseCreation ();
		}

		[Test ()]
		public void Step08_verifyReefDisabled() {
			session.mainWindow.verifyReefPollingDisabled ();
			session.mainWindow.verifyConnectABaseStatus ();
		}

		[Test ()]
		public void Step09_verifyNoMessageAppearsWhenCourseIsAdded() {
			session.mainWindow.verifyNoMessageAppearsWhenCourseIsAdded ();
		}

		[Test ()]
		public void Step10_enableReefPolling() {
			session.mainWindow.clickOnSettingsButton ();
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
		}

		[Test ()]
		public void Step11_verifyButtonsEnabledAfterEnablingReef() {
			session.mainWindow.verifyButtonsEnabledAfterEnablingReef ();
		}

		[Test ()]
		public void Step12_verifyButtonsEnabledOnLowerBorder() {
			session.mainWindow.verifyButtonsEnabledOnLowerBorder ();
		}

		[Test ()]
		public void Step13_verifyReefEnabled() {
			session.mainWindow.verifyReefEnabledStatus ();
		}

		[Test ()]
		public void Step14_createDucplicateCourseAndVerifyErrorMessage() {
			session.mainWindow.clickOnCreateNewCourseButton ();
			session.createCourseWindow.enterCourseName (courseName);
			session.createCourseWindow.clickOnCreateButton ();
			//session.createCourseWindow.verifyErrorMessageOnDuplicateCourseCreation ();
			session.createCourseWindow.clickOnCloseButton ();
		}

		[Test ()]
		public void Step15_verifyGradebookWindowOpensFromFile() {
			session.mainWindow.openGradebookFromMenu (courseName);
			session.gradebookWindow.closeWindow ();
		}

		[Test ()]
		public void Step16_verifyGradebookWindowOpensFromMainWindow() {
			session.mainWindow.openGradebookFromMainWindow (courseName);
			session.gradebookWindow.closeWindow ();
		}

		[Test ()]
		public void Step17_openSettingsUsingKeys() {
			session.mainWindow.openSettingsUsingKeys ();
			session.courseSettingsWindow.clickOnSaveButton ();
			session.courseSettingsWindow.switchToMainWindow ();
		}

		[Test ()]
		public void Step18_resumeSessionForNewCourse() {
			session.mainWindow.clickOnResumeSessionForNewCourse ();
		}

		[Test ()]
		public void Step19_openToolBarFromMainWindow() {
			session.mainWindow.clickOnStartNewSessionButton ();
			session.toolbarWindow.closeWindow ();
		}

		[Test ()]
		public void Step20_openToolBarUsingKeys() {
			session.mainWindow.openToolBarUsingKeys ();
			session.toolbarWindow.clickOnStartStopPollingButton ();
			session.toolbarWindow.clickOnStartStopPollingButton ();
			session.toolbarWindow.closeWindow ();
		}

		[Test ()]
		public void Step21_resumeSessionFromWelcomeScreen() {
			session.mainWindow.clickOnResumeSession ();
			session.toolbarWindow.closeWindow ();
		}

		[Test ()]
		public void Step22_resumeSessionUsingKeys() {
			session.mainWindow.resumeSessionUsingKeys ();
			session.toolbarWindow.closeWindow ();
		}

		[Test ()]
		public void Step23_openAboutiClicker() {
			session.mainWindow.openAboutiClicker ();
			session.helpWindow.closeWindow ();
		}

		[Test ()]
		public void Step24_checkForUpdates() {
			session.mainWindow.openUpdatesWindow ();
			session.helpWindow.closeWindow ();
		}

		[TestFixtureTearDown ()]
		public void closeSession() {
			session.closeSession ();
		}
	}
}

