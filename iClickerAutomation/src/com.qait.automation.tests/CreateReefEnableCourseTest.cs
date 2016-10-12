using System;
using NUnit.Framework;

namespace iClickerAutomation
{
	[TestFixture ()]
	public class CreateReefEnableCourseTest
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
		public void Step05_startPolling () {
			session.toolbarWindow.clickOnStartStopPollingButton ();
		}

		[Test ()]
		public void Step06_createStudent () {
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
		public void Step07_addCourse() {
			session.coursePage.clickOnAddACourseButton ();
			session.coursePage.findInstitution (YamlReader.getData("course.institutionName"));
			session.coursePage.findCourse (courseName);
			session.coursePage.clickOnAddToThisCourse ();
		}

		[Test ()]
		public void Step08_joinSession() {
			session.coursePage.selectCourse (courseName);
			session.coursePage.clickOnJoinButton ();
			session.coursePage.selectOption ();
		}

		[Test ()]
		public void Step09_stopPolling() {
			session.toolbarWindow.clickOnStartStopPollingButton ();
		}

		[TestFixtureTearDown ()]
		public void closeSession() {
			session.closeSession ();
			session.quitBrowser ();
		}
	}
}

