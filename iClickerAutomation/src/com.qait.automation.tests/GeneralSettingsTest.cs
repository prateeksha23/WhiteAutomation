using System;
using NUnit.Framework;

namespace iClickerAutomation
{

	[TestFixture ()]
	public class GeneralSettingsTest
	{
		SessionInitiator session;
		String firstcourseName = "TestCourse" + DateTime.Now.Ticks;
		String secondCourseName, editedCourseName;

		[TestFixtureSetUp ()]
		public void init() {
			session = new SessionInitiator ();
		}

		[Test ()]
		public void Step01_createNewCourse() {
			session.mainWindow.setForgroundwindow ();
			session.mainWindow.verifyLogo ();
			session.mainWindow.clickOnCreateNewCourseButton ();
			session.createCourseWindow.enterCourseName (firstcourseName);
			session.createCourseWindow.clickOnCreateButton ();
			session.mainWindow.verifyCourseCreated (firstcourseName);
		}

		[Test ()]
		public void Step02_createAnotherCourse() {
			secondCourseName = "TestCourse" + DateTime.Now.Ticks;
			session.mainWindow.clickOnCreateNewCourseButton ();
			session.createCourseWindow.enterCourseName (secondCourseName);
			session.createCourseWindow.clickOnCreateButton ();
			session.mainWindow.verifyCourseCreated (secondCourseName);
		}

		[Test ()]
		public void Step03_openSettingsForCreatedCourse() {
			session.mainWindow.clickOnSettingsButton ();
		}

		[Test ()]
		public void Step04_verifyVariousSectionsOnGeneralTab() {
			session.courseSettingsWindow.verifyVariousSectionsOnGeneralTab ();
		}

		[Test ()]
		public void Step05_verifyErrorMessageOnInvalidRemoteId() {
			session.courseSettingsWindow.verifyErrorMessageOnInvalidRemoteId ();
		}

		[Test ()]
		public void Step06_editCourseName() {
			editedCourseName = "TestCourse" + DateTime.Now.Ticks;
			session.courseSettingsWindow.editCourseName (editedCourseName);
			session.courseSettingsWindow.clickOnSaveButton ();
			session.courseSettingsWindow.switchToMainWindow ();
			session.mainWindow.verifyCourseCreated (editedCourseName);
		}

		[Test ()]
		public void Step07_saveInstructorRemoteId() {
			session.mainWindow.clickOnSettingsButton ();
			session.courseSettingsWindow.enterValidRemoteID (YamlReader.getData("courseSettingWindow.general.instructorRemoteID"));
			session.courseSettingsWindow.switchToMainWindow ();
		}

		[Test ()]
		public void Step08_saveWelcomeMessage() {
			session.mainWindow.clickOnSettingsButton ();
			session.courseSettingsWindow.enterWelcomeMessage (YamlReader.getData("courseSettingWindow.general.welcomeMessage"));
			session.courseSettingsWindow.switchToMainWindow ();
		}

		[Test ()]
		public void Step09_verifyErrorMessageOnDuplicateCourseCreation() {
			session.mainWindow.clickOnSettingsButton ();
			session.courseSettingsWindow.verifyErrorMessageOnInvalidRemoteId ();
			session.courseSettingsWindow.editCourseName (firstcourseName);
			session.courseSettingsWindow.verifySaveButtonDisabled ();
			session.courseSettingsWindow.clickOnCancelButton ();
			session.courseSettingsWindow.switchToMainWindow ();
		}

		[Test ()]
		public void Step10_verifyDefaultFrequency() {
			session.mainWindow.clickOnSettingsButton ();
			session.courseSettingsWindow.verifyDefaultFrequency ();
		}

		[Test ()]
		public void Step11_changeFrequency() {
			session.courseSettingsWindow.changeFrequency ();
			session.courseSettingsWindow.clickOnSaveButton ();
			session.courseSettingsWindow.switchToMainWindow ();	
		}

		[Test ()]
		public void Step12_openSettingsForCreatedCourse() {
			session.mainWindow.clickOnSettingsButton ();
		}

		[Test ()]
		public void Step13_enableReefPolling() {
			session.courseSettingsWindow.clickOnReefPollingTab ();
			session.courseSettingsWindow.clickOnEnableReefPollingButton ();
			session.logInWindow.clickOnCreateAccountButton ();
			session.createAccountWindow.enterDetailsForAccount ();
			session.createAccountWindow.selectIAgreeCheckbox ();
			session.createAccountWindow.clickOnCreateButton ();
			session.courseDetailsWindow.enterInstitutionDetails (YamlReader.getData("course.institutionName"));
			session.courseDetailsWindow.enterCourseName (editedCourseName);
			session.courseDetailsWindow.clickOnCreateButton ();
			session.courseDetailsWindow.verifyCourseDetails ();
			session.courseSettingsWindow.clickOnSaveButton ();
			session.courseSettingsWindow.switchToMainWindow ();
			session.mainWindow.verifyStartSessionButtonEnabled ();
		}

		[Test ()]
		public void Step14_verifyFrequencyCodeMessageAfterChangingFrequency() {
			session.mainWindow.clickOnStartNewSessionButton ();
			session.toolbarWindow.clickOnStartStopPollingButton ();
			session.toolbarWindow.clickOnCloseButtonOnBaseFrequencyWindow ();
			session.toolbarWindow.verifyTimerPanelAppears ();
			session.toolbarWindow.clickOnStartStopPollingButton ();
			session.toolbarWindow.closeWindow ();
		}

		[TestFixtureTearDown ()]
		public void closeSession() {
			session.closeSession ();

		}
	}
}

