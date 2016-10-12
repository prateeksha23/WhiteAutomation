using System;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.Finder;
using NUnit.Framework;

namespace iClickerAutomation
{
	public class MainWindow : MainWindowUI
	{
		Application app;

		public MainWindow (Application app)
		{
			this.app = app;
			window = getWindowHandle (app, YamlReader.getData ("mainWindow.title"));
		}

		public void verifyLogo() {
			hardWait (2);
			StringAssert.AreEqualIgnoringCase ("true", verifyImagePresent ("logo.png"), "Assertion failed : Logo image is not present");
			logMessage("Assertion passed : Logo image is present");
		}

		public void verifyReefPollingDisabled() {
			hardWait (2);
			StringAssert.AreEqualIgnoringCase ("true", verifyImagePresent ("reefDisabled.png"), "Assertion failed : Reef disabled status is not present");
			logMessage("Assertion passed : Reef disabled status is present");
		}

		public void verifyConnectABaseStatus() {
			hardWait (2);
			StringAssert.AreEqualIgnoringCase ("true", verifyImagePresent ("connectBase.png"), "Assertion failed : Connect a base status is not present");
			logMessage("Assertion passed : Connect a base status is present");
		}

		public void verifyReefEnabledStatus() {
			hardWait (2);
			StringAssert.AreEqualIgnoringCase ("true", verifyImagePresent ("reefEnabled.png"), "Assertion failed : Reef enabled status is not present");
			logMessage("Assertion passed : Reef enabled status is present");
		}
			
		public void clickOnCreateNewCourseButton() {
			hardWait (2);
			Button btn_createNew = (Button)getCreateNewButton ();
			Assert.IsTrue (btn_createNew.Visible, "Assertion failed : Button to create new course is not visible on main window");
			logMessage ("Assertion passed : Button to create new course is visible on main window");
			btn_createNew.Click ();
			logMessage ("Clicked on create button on main window");
		}

		public void clickOnSettingsButton() {
			Button btn_settings = (Button)getSettingsButton ();
			Assert.IsTrue (btn_settings.Visible, "Assertion failed : Settings Button is not visible on main window");
			logMessage ("Assertion passed : Settings Button is visible on main window");
			btn_settings.Click ();
			logMessage ("Clicked on settings button on main window");
			window = getWindowHandle (app, YamlReader.getData ("courseSettingWindow.title"));
		}

		public void clickOnStartNewSessionButton() {
			Button btn_startNewSession = getStartNewSessionButton ();
			Assert.IsTrue (btn_startNewSession.Visible, "Assertion failed : Start new session Button is not visible on main window");
			logMessage ("Assertion passed : Start new session Button is visible on main window");
			btn_startNewSession.Click ();
			logMessage ("Clicked on Start new session button");
			window = getWindowHandle (app, YamlReader.getData ("toolbar.title"));
		}

		public void clickOnResumeSessionForNewCourse() {
			Button btn_resumeSession = getResumeSessionButton ();
			Assert.IsTrue (btn_resumeSession.Visible, "Assertion failed : Resume session Button is not visible on main window");
			logMessage ("Assertion passed : Resume session Button is visible on main window");
			btn_resumeSession.Click ();
			logMessage ("Clicked on Resume session button");
			window = getWindowHandle (app, "Cannot resume session");
			logMessage ("Error message appears on clicking Resume Session button for new course");
			window.Close ();
			window = getWindowHandle (app, YamlReader.getData ("mainWindow.title"));
		}

		public void clickOnResumeSession() {
			hardWait (2);
			Button btn_resumeSession = getResumeSessionButton ();
			Assert.IsTrue (btn_resumeSession.Visible, "Assertion failed : Resume session Button is not visible on main window");
			logMessage ("Assertion passed : Resume session Button is visible on main window");
			btn_resumeSession.Click ();
			logMessage ("Clicked on Resume session button");
			window = getWindowHandle (app, YamlReader.getData ("toolbar.title"));
		}

		public void verifyCourseCreated(String courseName) {
			IUIItem list_courses = getCourseText (courseName);
			Assert.AreEqual (list_courses.Name, courseName, "Assertion failed : Created course is not visible in courses list ");
			logMessage ("Assertion passed : Created course is visible in courses list");
		}

		public void verifyStartSessionButtonEnabled() {
			Button btn_startNewSession = getStartNewSessionButton ();
			Assert.IsTrue (btn_startNewSession.Enabled, "Assertion failed : Start new session Button is not enabled on main window");
			logMessage ("Assertion passed : Start new session Button is enabled on main window");
		}

		public void deleteAllCourses() {
			Button btn_delete = (Button)getDeleteButton ();
			while (btn_delete.Enabled) {
				hardWait (1);
				btn_delete.Click ();
				Button btn_deleteCourse = getDeleteButtonOnDeleteWindow ();
				btn_deleteCourse.Click ();
				hardWait (1);
			}
		}

		public void verifyMenuBarTabs() {
			Menu menu_file = getFileMenu ();
			Assert.IsTrue (menu_file.Visible, "Assertion failed : File menu button is not visible on main window");
			logMessage ("Assertion passed : File menu button is visible on main window");
			Menu menu_course = getCourseMenu ();
			Assert.IsTrue (menu_course.Visible, "Assertion failed : Course menu button is not visible on main window");
			logMessage ("Assertion passed : Course menu button is visible on main window");
			Menu menu_session = getSessionMenu ();
			Assert.IsTrue (menu_session.Visible, "Assertion failed : Session menu button is not visible on main window");
			logMessage ("Assertion passed : Session menu button is visible on main window");
			Menu menu_help = getHelpMenu ();
			Assert.IsTrue (menu_help.Visible, "Assertion failed : Help menu button is not visible on main window");
			logMessage ("Assertion passed : Help menu button is visible on main window");
		}


		public void verifyButtonsAreDisabledBeforeCourseCreation() {
			hardWait (2);
			Button btn_startNewSession = getStartNewSessionButton ();
			Assert.IsFalse (btn_startNewSession.Enabled, "Assertion failed : Start new session Button is enabled when there is no course");
			logMessage ("Assertion passed : Start new session Button is not enabled when there is no course");
			Button btn_resumeSession = getResumeSessionButton ();
			Assert.IsFalse (btn_resumeSession.Enabled, "Assertion failed : Resume session Button is enabled when there is no course");
			logMessage ("Assertion passed : Resume session Button is not enabled when there is no course");
			Button btn_openGradebook = getOpenGradebookButton ();
			Assert.IsFalse (btn_openGradebook.Enabled, "Assertion failed : Open gradebook button is enabled when there is no course");
			logMessage ("Assertion passed : Open gradebook button is not enabled when there is no course");
		}

		public void verifyMessageWhenNoCourseIsAdded() {
			IUIItem txt_message = getNoCourseCreatedMessage ();
			Assert.IsTrue (txt_message.Visible, "Assertion Failed : Message is not visible when no course is created");
			logMessage ("Assertion Passed : Message is visible when no course is created");
		}

		public void verifyNoMessageAppearsWhenCourseIsAdded() {
			try{
				IUIItem txt_message = getNoCourseCreatedMessage();
				Assert.IsFalse (txt_message.Visible, "Assertion Failed : Message is visible when course is created");
			}
			catch(AutomationException ex) {
				System.Console.WriteLine (ex);
				logMessage("Assertion Passed : Message is visible not when course is created");
			}
		}

		public void verifyButtonsAreEnabledAfterCourseCreation() {
			Button btn_openGradebook = getOpenGradebookButton ();
			Assert.IsTrue (btn_openGradebook.Enabled, "Assertion failed : Open gradebook button is not enabled after course is created");
			logMessage ("Assertion passed : Open gradebook button is enabled after course is created");
		}

		public void verifyButtonsEnabledAfterEnablingReef() {
			Button btn_startNewSession = getStartNewSessionButton ();
			Assert.IsTrue (btn_startNewSession.Enabled, "Assertion failed : Start new session Button is not enabled after course is created");
			logMessage ("Assertion passed : Start new session Button is enabled after enabling reef");
			Button btn_resumeSession = getResumeSessionButton ();
			Assert.IsTrue (btn_resumeSession.Enabled, "Assertion failed : Resume session Button is not enabled after course is created");
			logMessage ("Assertion passed : Resume session Button is enabled after enabling reef");
			Button btn_openGradebook = getOpenGradebookButton ();
			Assert.IsTrue (btn_openGradebook.Enabled, "Assertion failed : Open gradebook button is not enabled after course is created");
			logMessage ("Assertion passed : Open gradebook button is enabled after enabling reef");
		}

		public void verifyButtonsEnabledOnLowerBorder() {
			Button btn_createNew = (Button)getCreateNewButton ();
			Assert.IsTrue (btn_createNew.Visible, "Assertion failed : Button to create new course is not visible on main window");
			logMessage ("Assertion passed : Button to create new course is visible on main window");
			Button btn_delete = (Button)getDeleteButton ();
			Assert.IsTrue (btn_delete.Visible, "Assertion failed : Button to delete course is not visible on main window");
			logMessage ("Assertion passed : Button to delete course is visible on main window");
			Button btn_settings = (Button)getSettingsButton ();
			Assert.IsTrue (btn_settings.Visible, "Assertion failed :  Setting button is not visible on main window");
			logMessage ("Assertion passed : Setting button is visible on main window");
		}

		public void openGradebookFromMenu(String coursename) {
			Menu menu_file = getFileMenu ();
			menu_file.Click ();
			Menu menu_openGradebook = getOpenGradebookMenuFromFile ();
			menu_openGradebook.Click ();
			logMessage ("Clicked on Open Gradebook from File menu");
			window = getWindowHandle (app, coursename);
		}

		public void openGradebookFromMainWindow(String coursename) {
			Button btn_openGradebook = getOpenGradebookButton ();
			btn_openGradebook.Click ();
			logMessage ("Clicked on Open Gradebook button from main window");
			window = getWindowHandle (app, coursename);
		}

		public void openAboutiClicker() {
			Menu menu_help = getHelpMenu ();
			menu_help.Click ();
			Menu menu_about = getAboutMenuFromHelp ();
			menu_about.Click ();
			logMessage ("Clicked on About iClicker from Help menu");
			window = getWindowHandle (app, YamlReader.getData("aboutWindow.title"));
		}

		public void openUpdatesWindow() {
			Menu menu_help = getHelpMenu ();
			menu_help.Click ();
			Menu menu_updates = getCheckForUpdatesMenuFromHelp ();
			menu_updates.Click ();
			logMessage ("Clicked on Check for update from Help menu");
			window = getWindowHandle (app, YamlReader.getData("updatesWindow.title"));
		}

		public void openSettingsUsingKeys() {
			sendKeys("^(e)");
			window = getWindowHandle (app, YamlReader.getData ("courseSettingWindow.title"));
		}

		public void openToolBarUsingKeys() {
			sendKeys("^(s)");
			window = getWindowHandle (app, YamlReader.getData ("toolbar.title"));
		}

		public void resumeSessionUsingKeys() {
			sendKeys("^(r)");
			window = getWindowHandle (app, YamlReader.getData ("toolbar.title"));
		}

		public void switchToToolbar() {
			window = getWindowHandle (app, YamlReader.getData ("toolbar.title"));
		}
			
	}
}

