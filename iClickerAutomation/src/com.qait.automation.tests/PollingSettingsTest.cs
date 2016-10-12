using System;
using NUnit.Framework;

namespace iClickerAutomation
{
	[TestFixture ()]
	public class PollingSettingsTest
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
		public void Step03_clickOnToolbarTab() {
			session.courseSettingsWindow.clickOnToolbarTab ();
		}

		[Test ()]
		public void Step04_verifySectionsOnToolbarTab() {
			session.courseSettingsWindow.verifySectionsOnToolbarTab ();
		}

		[Test ()]
		public void Step05_verifyOptionsUnderToolbarSize() {
			session.courseSettingsWindow.verifyOptionsUnderToolbarSize ();
		}

		[Test ()]
		public void Step06_verifyNormalIsSelectedForToolbarSize() {
			session.courseSettingsWindow.verifyNormalIsSelectedForToolbarSize ();
		}

		[Test ()]
		public void Step07_closeSettingsWindow() {
			session.courseSettingsWindow.clickOnSaveButton ();
		}

		[TestFixtureTearDown ()]
		public void closeSession() {
			session.closeSession ();
		}
	}
}

