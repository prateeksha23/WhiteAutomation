using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.MenuItems;
using System.Windows.Automation;

namespace iClickerAutomation
{
	public class ToolBarUI : WindowsBaseAction
	{
		public IUIItem getStartStopPollingButton() {
			return window.Get (SearchCriteria.ByText ("Start and stop vote polling"));
		}

		public Button getShowHistogramButton() {
			return window.Get<Button> (SearchCriteria.ByText ("Show or hide histogram window"));
		}

		public IUIItem[] getListOfButtons() {
			return window.GetMultiple (SearchCriteria.ByControlType (ControlType.Button));
		}

		public IUIItem[] getListOfCheckboxes() {
			return window.GetMultiple (SearchCriteria.ByControlType (ControlType.CheckBox));
		}

		public IUIItem getCloseButton() {
			return getListOfButtons() [0];
		}

		public IUIItem getMaximizeMinimizeButton() {
			return getListOfCheckboxes() [0];
		}

		public IUIItem[] getAllElements() {
			return window.GetMultiple (SearchCriteria.All);
		}

		public IUIItem getSettingsButton() {
			//o -- unknown
			//1 -- close
			//2 -- minimize
			//3, 4 -- questions drpdwn
			//5
			//IUIItem[] m = window.GetMultiple(SearchCriteria.ByControlType(ControlType.MenuItem));
			//m[0].Click ();
			IUIItem[] items = window.GetMultiple (SearchCriteria.All);
			logMessage ("No of items ::"+items.Length);
			for (int i = 0; i < items.Length; i++) {
				//logMessage ("Name ::" + items[i].Name);
				if (i == 0&&i==2) {
					continue;
				} else {
					//items[i].Click ();
				}
			}

			return items [4];
		}

		public Panel getTimerPanel() {
			return window.Get<Panel> (SearchCriteria.ByControlType (ControlType.Pane));
		}

		public IUIItem getQuestionsMenuItem() {
			return getAllElements() [3];
		}

		public IUIItem getNumericOption() {
			return window.Get (SearchCriteria.ByText ("Numeric"));
		}

		public IUIItem getAPText() {
			return window.Get (SearchCriteria.ByText ("AP mode"));
		}

		public Button getCloseButtonOnRollCallWindow() {
			return window.Get<Button> (SearchCriteria.ByText ("Close"));
		}

		public Button getCloseButtonOnBaseFrequencyWindow() {
			return window.Get<Button> (SearchCriteria.ByText ("Close"));
		}
	}
}

