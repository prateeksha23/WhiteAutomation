using System;
using NUnit.Framework;

namespace iClickerAutomation
{
	[TestFixture ()]
	public class ScoringTest
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
		public void Step03_clickOnScoringTab() {
			session.courseSettingsWindow.clickOnScoringTab ();
		}

		[Test ()]
		public void Step04_verifyScoringSettingsSectionsAvailable() {
			session.courseSettingsWindow.verifyParticipationAndPerformanceSectionsAvailable ();
		}

		[Test ()]
		public void Step05_verifyOptionsForComboBoxUnderParticipationPoints() {
			session.courseSettingsWindow.verifyOptionsForComboBoxUnderParticipationPoints ();
		}

		[Test ()]
		public void Step06_closeSettingsWindow() {
			session.courseSettingsWindow.clickOnSaveButton ();
			session.courseSettingsWindow.switchToMainWindow ();
		}

		[TestFixtureTearDown ()]
		public void closeSession() {
			session.closeSession ();
		}
	}
}

