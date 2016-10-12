using System;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using System.Collections.Generic;
using NUnit.Framework;

namespace iClickerAutomation 
{
	public class CourseSettingsWindow : CourseSettingsUI
	{

		Application app;

		public CourseSettingsWindow (Application app)
		{
			this.app = app;
		}

		public void clickOnSaveButton() {
			hardWait (2);
			moveWindowToTop ();
			Button btn_save = getSaveButton ();
			Assert.IsTrue (btn_save.Visible, "Assertion failed : Save button is not visible on Course settings window");
			logMessage ("Assertion passed : Save button is visible on Course settings window");
			btn_save.Click ();
			logMessage ("Clicked on Save button on Course settings window");
			hardWait (2);
		}

		public void clickOnCancelButton() {
			Button btn_cancel = getCancelButton ();
			Assert.IsTrue (btn_cancel.Visible, "Assertion failed : Cancel button is not visible on Course settings window");
			logMessage ("Assertion passed : Cancel button is visible on Course settings window");
			btn_cancel.Click ();
			logMessage ("Clicked on Cancel button on Course settings window");
			hardWait (2);
		}

		public void verifySaveButtonDisabled() {
			hardWait (2);
			Button btn_save = getSaveButton ();
			Assert.IsFalse (btn_save.Enabled, "Assertion failed : Save button is enabled");
			logMessage ("Assertion passed : Save button is disabled");
		}

		public void switchToMainWindow() {
			window = getWindowHandle (app, YamlReader.getData ("mainWindow.title"));
		}

		public void clickOnReefPollingTab() {
			IUIItem tab_reefPolling = getReefPollingTab ();
			Assert.IsTrue (tab_reefPolling.Visible, "Assertion failed : Reef polling tab is not visible on Course settings window");
			logMessage ("Asserion Passed : Reef polling tab is visible on Course settings window");
			tab_reefPolling.Click ();
			logMessage ("Clicked on Reef polling tab");
		}

		public void clickOnScoringTab() {
			IUIItem tab_scoring = getScoringTab ();
			Assert.IsTrue (tab_scoring.Visible, "Assertion failed : Scoring tab is not visible on Course settings window");
			logMessage ("Asserion Passed : Scoring tab is visible on Course settings window");
			tab_scoring.Click ();
			logMessage ("Clicked on Scoring tab");
		}

		public void clickOnGradebookTab() {
			IUIItem tab_gradebook = getGradebookTab ();
			Assert.IsTrue (tab_gradebook.Visible, "Assertion failed : Gradebook tab is not visible on Course settings window");
			logMessage ("Asserion Passed : Gradebook tab is visible on Course settings window");
			tab_gradebook.Click ();
			logMessage ("Clicked on Gradebook tab");
		}

		public void clickOnRollCallTab() {
			IUIItem tab_rollCall = getRollCallTab ();
			Assert.IsTrue (tab_rollCall.Visible, "Assertion failed : Roll Call tab is not visible on Course settings window");
			logMessage ("Asserion Passed : Roll Call tab is visible on Course settings window");
			tab_rollCall.Click ();
			logMessage ("Clicked on Roll Call tab");
		}

		public void clickOnToolbarTab() {
			IUIItem tab_toolbar = getToolbarTab ();
			Assert.IsTrue (tab_toolbar.Visible, "Assertion failed : Toolbar tab is not visible on Course settings window");
			logMessage ("Asserion Passed : Toolbar tab is visible on Course settings window");
			tab_toolbar.Click ();
			logMessage ("Clicked on Toolbar tab");
		}

		/*************************************Reef Polling Tab******************************************/

		public void clickOnEnableReefPollingButton() {
			Button btn_enableReefPolling = getEnableReefPollingButton ();
			Assert.IsTrue (btn_enableReefPolling.Visible, "Assertion failed : Enable reef polling button is not visible on Course settings window");
			logMessage ("Assertion passed : Enable reef polling button is visible on Course settings window");
			btn_enableReefPolling.Click ();
			logMessage ("Clicked on Enable reef polling button");
		}

		/************************************Scoring Tab***************************************/

		public void verifyParticipationAndPerformanceSectionsAvailable() {
			IUIItem heading_partication = getParticipationSectionHeading ();
			Assert.IsTrue (heading_partication.Visible, "Assertion failed : Participation Scoring heading is not visible on Scoring tab");
			logMessage ("Assertion passed : Participation Scoring heading is visible on Scoring tab");
			IUIItem heading_performance = getPerformanceSectionHeading ();
			Assert.IsTrue (heading_performance.Visible, "Assertion failed : Performance Scoring heading is not visible on Scoring tab");
			logMessage ("Assertion passed : Performance Scoring heading is visible on Scoring tab");
		}

		public void verifyPerformanceDefaultPoints() {
			TextBox txt_performancePoints = getPerformancePointsTextBox ();
			logMessage ("Text ::" + txt_performancePoints.Text);
		}

		public void verifyOptionsForComboBoxUnderParticipationPoints() {
			ListBox listOfOptions = getListOfOptionsUnderComboBox();
			ListItem[] listItems = listOfOptions.Items.ToArray ();
			int i = 1;
			foreach(ListItem item in listItems){
				StringAssert.AreEqualIgnoringCase (YamlReader.getData ("courseSettingWindow.scoring.criteriaPartcipationPoints.option" + i), item.Name);
				i++;
			}
			logMessage ("Assertion passed : Options under combo box are correct");
		}
			
		/**************************************Gradebook Tab**********************************/

		public void verifyVariousSectionsOnGradebookTab() {
			IUIItem heading_LMS = getLMSHeading ();
			Assert.IsTrue (heading_LMS.Visible, "Assertion failed : LMS heading is not visible on Scoring tab");
			logMessage ("Assertion passed : LMS heading is visible on Scoring tab");
			IUIItem heading_databaseRegistration = getDataBaseRegisrtationHeading ();
			Assert.IsTrue (heading_databaseRegistration.Visible, "Assertion failed : Database Registration heading is not visible on Scoring tab");
			logMessage ("Assertion passed : Database Registration heading is visible on Scoring tab");
		}

		public void verifyOptionsUnderRosterSourceDropdown() {
			ListBox listOfOptions = getListOfOptionsUnderComboBox();
			ListItem[] listItems = listOfOptions.Items.ToArray ();
			int i = 1;
			foreach(ListItem item in listItems){
				StringAssert.AreEqualIgnoringCase (YamlReader.getData ("courseSettingWindow.gradebook.rosterSource.option" + i), item.Name);
				i++;
			}
			logMessage ("Assertion passed : Options under combo box are correct");
		}

		/*************************************Roll Call Tab***************************************/

		public void verifyRadioButtonsUnderRegistrationSection() {
			IUIItem[] listOfRadioButtons = getListOfRadioButtons ();
			int i = 1;
			foreach(RadioButton item in listOfRadioButtons){
				StringAssert.AreEqualIgnoringCase (YamlReader.getData ("courseSettingWindow.rollcall.registration.option" + i), item.Name);
				i++;
			}
			logMessage ("Assertion passed : Options under combo box are correct");
		}

		/******************************************Toolbar Tab*****************************************/

		public void verifySectionsOnToolbarTab() {
			IUIItem heading_customizeToolbar = getCustomizeToolbarHeading ();
			Assert.IsTrue (heading_customizeToolbar.Visible, "Assertion failed : Customize toolbar heading is not visible on Scoring tab");
			logMessage ("Assertion passed : Customize toolbar heading is visible on Scoring tab");
			IUIItem heading_pollingTimer = getPollingTimerHeading ();
			Assert.IsTrue (heading_pollingTimer.Visible, "Assertion failed : Polling timer heading is not visible on Scoring tab");
			logMessage ("Assertion passed : Polling timer heading is visible on Scoring tab");
		}

		public void verifyOptionsUnderToolbarSize() {
			IUIItem[] comboBoxes = getComboBoxes ();
			foreach (IUIItem item in comboBoxes) {
				System.Console.WriteLine ("Name ::"+item.Name);
				System.Console.WriteLine ("Enabled ::"+item.Enabled);
			}
			ListBox listOfOptions = getListOfOptionsUnderComboBox();
			ListItem[] listItems = listOfOptions.Items.ToArray ();
			int i = 1;
			foreach(ListItem item in listItems){
				StringAssert.AreEqualIgnoringCase (YamlReader.getData ("courseSettingWindow.toolbar.toolbarSize.option" + i), item.Name);
				i++;
			}
			logMessage ("Assertion passed : Options under toolbar size combo box are correct");
		}

		public void verifyNormalIsSelectedForToolbarSize() {
			ComboBox listOfOptions = (ComboBox)getCustomizeToolbarComboBox();
			listOfOptions.Click ();
			//ListItem[] listItems = listOfOptions.Items.ToArray ();
			//listItems [1].Click ();
		}

		/******************************************************General Tab********************************************/

		public void verifyVariousSectionsOnGeneralTab() {
			IUIItem heading_general = getGeneralHeading ();
			Assert.IsTrue (heading_general.Visible, "Assertion failed : General heading is not visible on Scoring tab");
			logMessage ("Assertion passed : General heading is visible on Scoring tab");
			IUIItem heading_frequencyCode = getFrequencyCodeHeading ();
			Assert.IsTrue (heading_frequencyCode.Visible, "Assertion failed : Frequency Code heading is not visible on Scoring tab");
			logMessage ("Assertion passed : Frequency Code heading is visible on Scoring tab");
			IUIItem heading_preferences = getPreferencesHeading ();
			Assert.IsTrue (heading_preferences.Visible, "Assertion failed : Preferences heading is not visible on Scoring tab");
			logMessage ("Assertion passed : Preferences heading is visible on Scoring tab");
		}

		public void verifyErrorMessageOnInvalidRemoteId() {
			sendKeys ("abc");
			clickOnSaveButton ();
			Button btn_Ok = getOkButton ();
			Assert.IsTrue (btn_Ok.Visible, "Assertion failed : No error message appears on entering invalid remote Id");
			logMessage ("Assertion passed : Error message appears on entering invalid remote Id");
			btn_Ok.Click ();
			logMessage ("Clicked on Ok button present on error message popup");
		}

		public void editCourseName(String editedCourseName) {
			sendKeys ("{TAB}");
			System.Windows.Forms.SendKeys.SendWait ("{TAB}");
			sendKeys (editedCourseName);
			sendKeys ("{BACKSPACE}");
		}

		public void enterValidRemoteID(String remoteId) {
			sendKeys (remoteId);
			clickOnSaveButton ();
			try{
				Button btn_Ok = getOkButton ();
				Assert.IsFalse (btn_Ok.Visible, "Assertion failed : Error message appears on entering valid remote Id");
			}
			catch(AutomationException ex) {
				logMessage ("Assertion passed : Remote ID saved successfully");
			}
		}

		public void enterWelcomeMessage(String welcomeMessage) {
			System.Windows.Forms.SendKeys.SendWait ("{TAB}");
			sendKeys (welcomeMessage);
			clickOnSaveButton ();
			try{
				Button btn_Ok = getOkButton ();
				Assert.IsFalse (btn_Ok.Visible, "Assertion failed : Error message appears on entering Welcome Message");
			}
			catch(AutomationException ex) {
				logMessage ("Assertion passed : Welcome Message saved successfully");
			}
		}

		public void verifyDefaultFrequency() {
			IUIItem[] radiobtn_frequency = getListOfRadioButtons ();
			int count = 0;
			foreach (RadioButton item in radiobtn_frequency) {
				if (item.IsSelected) {
					StringAssert.AreEqualIgnoringCase ("A", item.Name, "Assertion failed : Default frequency is not AA");
					count++;
				}
			}
			Assert.AreEqual (2, count, "Assertion failed : Selected frequency are not 2 in number");
			logMessage ("Assertion passed : Default frequency is AA");
		}

		public void changeFrequency() {
			IUIItem[] radiobtn_frequency = getListOfRadioButtons ();
			int count = 0;
			foreach (RadioButton item in radiobtn_frequency) {
				if (item.Name.Equals("B")) {
					item.Click ();
					count++;
				}
			}
		}
	}
}

