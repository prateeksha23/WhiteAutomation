using System;
using NUnit.Framework;

namespace iClickerAutomation
{

	[TestFixture ()]
	public class GradebookAndRollCallSettingsTest
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
		public void Step03_clickOnGradebookTab() {
			session.courseSettingsWindow.clickOnGradebookTab ();
		}

		[Test ()]
		public void Step04_verifyVariousSectionsOnGradebookTab() {
			session.courseSettingsWindow.verifyVariousSectionsOnGradebookTab ();
		}

		[Test ()]
		public void Step05_verifyOptionsUnderRosterSourceDropdown() {
			session.courseSettingsWindow.verifyOptionsUnderRosterSourceDropdown ();
		}

		[Test ()]
		public void Step06_clickOnRollCallTab() {
			session.courseSettingsWindow.clickOnRollCallTab ();
		}

		[Test ()]
		public void Step07_verifyRadioButtonsUnderRegistrationSection() {
			session.courseSettingsWindow.verifyRadioButtonsUnderRegistrationSection ();
		}

		[Test ()]
		public void Step08_closeSettingsWindow() {
			session.courseSettingsWindow.clickOnSaveButton ();
			session.courseSettingsWindow.switchToMainWindow ();	
		}

		[TestFixtureTearDown ()]
		public void closeSession() {
			session.closeSession ();
		
		}
	}
}
	