using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using System.Windows.Automation;

namespace iClickerAutomation
{
	public class CourseSettingsUI : WindowsBaseAction
	{
		public IUIItem getReefPollingTab() {
			return window.Get (SearchCriteria.ByText ("REEF Polling"));
		}

		public IUIItem getScoringTab() {
			return window.Get (SearchCriteria.ByText ("Scoring"));
		}

		public IUIItem getGradebookTab() {
			return window.Get (SearchCriteria.ByText ("Gradebook"));
		}

		public IUIItem getRollCallTab() {
			return window.Get (SearchCriteria.ByText ("Roll Call"));
		}

		public IUIItem getToolbarTab() {
			return window.Get (SearchCriteria.ByText ("Toolbar"));
		}

		public Button getSaveButton() {
			return window.Get<Button> (SearchCriteria.ByText ("Save"));
		}

		public Button getCancelButton() {
			return window.Get<Button> (SearchCriteria.ByText ("Cancel"));
		}

		public ListBox getListOfOptionsUnderComboBox() {
			return window.Get<ListBox> (SearchCriteria.ByControlType (ControlType.List));
		}

		public IUIItem[] getListOfRadioButtons() {
			return window.GetMultiple (SearchCriteria.ByControlType (ControlType.RadioButton));
		}

		/***********************************Reef Polling Tab**************************************/

		public Button getEnableReefPollingButton() {
			return window.Get<Button> (SearchCriteria.ByText ("Enable REEF Polling"));
		}

		/*************************************Scoring Tab***************************************/

		public IUIItem getParticipationSectionHeading() {
			return window.Get (SearchCriteria.ByText ("Participation points"));
		}

		public IUIItem getPerformanceSectionHeading() {
			return window.Get (SearchCriteria.ByText ("Performance points"));
		}

		public TextBox getPerformancePointsTextBox() {
			return window.Get<TextBox> (SearchCriteria.ByText ("Participation points"));
		}



		/*********************************Gradebook Tab***************************************/

		public IUIItem getLMSHeading() {
			return window.Get (SearchCriteria.ByText ("Learning management system (LMS)"));
		}

		public IUIItem getDataBaseRegisrtationHeading () {
			return window.Get (SearchCriteria.ByText ("Locally-hosted registration database"));
		}

		/*******************************************Toolbar Tab******************************************/

		public IUIItem getCustomizeToolbarHeading() {
			return window.Get (SearchCriteria.ByText ("Customize toolbar"));
		}

		public IUIItem getPollingTimerHeading() {
			return window.Get (SearchCriteria.ByText ("Polling timer"));
		}

		public ComboBox getCustomizeToolbarComboBox() {
			return window.Get<ListBox> (SearchCriteria.ByControlType (ControlType.List)).GetParent<ComboBox>();
			//return window.Get<ComboBox> (SearchCriteria.ByControlType (ControlType.List));
		}

		public IUIItem[] getComboBoxes() {
			System.Console.WriteLine ("Length"+window.GetMultiple (SearchCriteria.ByControlType (ControlType.List)).Length);
			return window.GetMultiple (SearchCriteria.ByControlType (ControlType.List));
		}

		/************************************************General Tab*******************************************/

		public IUIItem getGeneralHeading() {
			return window.Get (SearchCriteria.ByText ("General"));
		}

		public IUIItem getFrequencyCodeHeading() {
			return window.Get (SearchCriteria.ByText ("Frequency code"));
		}

		public IUIItem getPreferencesHeading() {
			return window.Get (SearchCriteria.ByText ("Preferences"));
		}

		public Button getOkButton() {
			return window.Get<Button> (SearchCriteria.ByText ("OK"));
		}

	}
}

