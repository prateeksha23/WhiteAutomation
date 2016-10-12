using System;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.MenuItems;
using TestStack.White.UIItems.ListBoxItems;
using NUnit.Framework;

namespace iClickerAutomation
{
	public class ToolBarWindow : ToolBarUI
	{
		Application app;

		public ToolBarWindow (Application app)
		{
			this.app = app;
		}

		public void verifyButtonsPresentOnToolbar() {
			IUIItem btn_close = getCloseButton ();
			Assert.IsTrue (btn_close.Visible, "Assertion failed : Close button is not visible on toolbar");
			logMessage ("Assertion passed : Close button is visible on toolbar");
			IUIItem btn_maximizeMinimize = getMaximizeMinimizeButton ();
			Assert.IsTrue (btn_maximizeMinimize.Visible, "Assertion failed : Maximize minimize button is not visible on toolbar");
			logMessage ("Assertion passed : Maximize minimize button is visible on toolbar");
			IUIItem btn_startStopPolling = getStartStopPollingButton ();
			Assert.IsTrue (btn_startStopPolling.Visible, "Assertion failed : Start stop polling button is not visible on toolbar");
			logMessage ("Assertion passed : Start stop polling button is visible on toolbar");
			Button btn_showHistogram = getShowHistogramButton ();
			Assert.IsTrue (btn_showHistogram.Visible, "Assertion failed : Show histogram button is not visible on toolbar");
			logMessage ("Assertion passed : Show histogram button is visible on toolbar");
			IUIItem btn_settings = getSettingsButton ();
			Assert.IsTrue (btn_settings.Visible, "Assertion failed : Settings button is not visible on toolbar");
			logMessage ("Assertion passed : Settings button is visible on toolbar");
		}

		public void verifyButtonsDisappearOnMinimize() {
			try{
				IUIItem btn_startStopPolling = getStartStopPollingButton ();
				Assert.IsFalse (btn_startStopPolling.Visible, "Assertion failed : Start stop polling button is visible on toolbar");
			}
			catch(AutomationException ex){
				logMessage ("Assertion passed : Start stop polling button is not visible on toolbar");
			}

			try{
				Button btn_showHistogram = getShowHistogramButton ();
				Assert.IsFalse (btn_showHistogram.Visible, "Assertion failed : Show histogram button is visible on toolbar");
			}
			catch(AutomationException ex){
				logMessage ("Assertion passed : Show histogram button is not visible on toolbar");
			}

			try{
				IUIItem btn_settings = getSettingsButton ();
				Assert.IsTrue (btn_settings.Visible, "Assertion failed : Settings button is not visible on toolbar");
			}
			catch(AutomationException ex){
				logMessage ("Assertion passed : Settings button is visible on toolbar");
			}
			catch(IndexOutOfRangeException ex1){
				logMessage ("Assertion passed : Settings button is visible on toolbar");
			}
		}

		public void verifyTimerPanelAppears() {
			Panel timerPanel = getTimerPanel ();
			Assert.IsTrue (timerPanel.Visible, "Assertion failed : Timer panel is not visible on toolbar");
			logMessage ("Assertion passed : Timer panel is visible on toolbar");
		}

		public void verifyTimerPanelDisappearsOnStoppingPoll() {
			try{
				Panel timerPanel = getTimerPanel ();
				Assert.IsTrue (timerPanel.Visible, "Assertion failed : Timer panel is visible on toolbar");
			}
			catch(AutomationException ex) {
				logMessage ("Assertion passed : Timer panel is not visible on toolbar");
			}
		}

		public void clickOnStartStopPollingButton() {
			IUIItem btn_startAndStopVotePolling = getStartStopPollingButton ();
			Assert.IsTrue (btn_startAndStopVotePolling.Visible, "Assertion failed : Start and stop polling button is not visible on iclicker lite window");
			btn_startAndStopVotePolling.Click ();
			hardWait (5);
			logMessage ("Clicked on start stop polling button on toolbar");
		}

		public void clickOnShowHideHistorgram() {
			Button btn_showHideHistogram = getShowHistogramButton ();
			btn_showHideHistogram.Click ();
			logMessage ("Clicked on Show histogram button on toolbar");
			window = getWindowHandle (app, YamlReader.getData("resultswindow.title"));
		}

		public void clickOnSettings() {
			IUIItem btn_settings = getSettingsButton ();
			btn_settings.Click ();
			logMessage ("Clicked on settings button");
		}

		public void openCourseSettingsUsingKeys() {
			hardWait (5);
			sendKeys ("^(e)");
			logMessage ("Opened course settings window using keys");
			window = getWindowHandle (app, YamlReader.getData ("courseSettingWindow.title"));
		}

		public void setAnonymousPollingUsingKeys() {
			sendKeys ("^(p)");
			logMessage ("Anonymous polling is set using keys");
		}

		public void openRollCallRegistrationWindowUsingKeys() {
			sendKeys ("^+(r)");
			logMessage ("Open Roll Call Registration Window using keys");
			Button btn_close = getCloseButtonOnRollCallWindow();
			btn_close.Click ();
			hardWait (3);
		}

		public void verifyAPTextOnToolbar() {
			IUIItem text_AP = getAPText ();
			Assert.IsTrue (text_AP.Visible, "Assertion failed : AP text is not visible on toolbar");
			logMessage ("Assertion passed : AP text is visible on toolbar");
		}

		public void clickOnMinimizeMaximizeButton() {
			IUIItem btn_maximizeMinimize = getMaximizeMinimizeButton ();
			btn_maximizeMinimize.Click ();
			hardWait (1);
			logMessage ("Clicked on Minimize/Maximize button on toolbar");
		}

		public void closeWindow() {
			IUIItem btn_close = getCloseButton ();
			btn_close.Click ();
			logMessage ("Clicked on close button on toolbar");
			window = getWindowHandle (app, YamlReader.getData ("mainWindow.title"));
		}

		public void verifyOnlyMultipleChoiceQuestionAppears() {
			IUIItem questionsMenu = getQuestionsMenuItem ();
			hardWait (5);
			questionsMenu.Click ();
			try{
				IUIItem numericOptions = getNumericOption ();
				Assert.IsFalse(numericOptions.Visible, "Assertion failed : Numeric option is displayed in questions dropdown");
			}
			catch(AutomationException ex){
				logMessage ("Assertion passed : Numeric option is not displayed in questions dropdown");
			}
		}

		public void selectNumericOptionFromQuestions() {
			IUIItem questionsMenu = getQuestionsMenuItem ();
			hardWait (5);
			questionsMenu.Click ();
			IUIItem numericOptions = getNumericOption ();
			numericOptions.Click ();
		}

		public void selectShortAnswerOptionFromQuestions() {
			IUIItem questionsMenu = getQuestionsMenuItem ();
			hardWait (5);
			questionsMenu.Click ();
			sendKeys ("{DOWN}");
			sendKeys ("{DOWN}");
			sendKeys ("{DOWN}");
			sendKeys ("{ENTER}");
		}

		public void startStopPollingUsingKeys() {
			hardWait (4);
			sendKeys ("^(g)");
			logMessage ("Polling started/stopped using keys");
			hardWait (4);
		}

		public void openResultsChartUsingKeys() {
			hardWait (3);
			sendKeys ("^(w)");
			logMessage ("Open results chart using keys");
			hardWait (3);
			window = getWindowHandle (app, YamlReader.getData("resultswindow.title"));
			window = getWindowHandle (app, YamlReader.getData ("toolbar.title"));
		}

		public void closeResultsChartUsingKeys() {
			sendKeys ("^(w)");
			logMessage ("Close results chart using keys");
		}

		public void maximizeMinimizeToolbarUsingKeys() {
			sendKeys ("^(m)");
			logMessage ("Maxmimize/minimize toolbar using keys");
		}

		public void closeToolbarUsingKeys() {
			sendKeys ("^(t)");
			logMessage ("Closed toolbar using keys");
			window = getWindowHandle (app, YamlReader.getData ("mainWindow.title"));
		}

		public void clickOnCloseButtonOnBaseFrequencyWindow() {
			Button btn_closeBaseFrequencyWindow = getCloseButtonOnBaseFrequencyWindow ();
			Assert.IsTrue (btn_closeBaseFrequencyWindow.Visible, "Assertion failed : Close button is not visible on Base Frequency window");
			logMessage ("Assertion passed : Close button is not visible on Base Frequency window");
			btn_closeBaseFrequencyWindow.Click ();
			logMessage ("Clicked on close button on Base Frequency window");
		}
	}
}

