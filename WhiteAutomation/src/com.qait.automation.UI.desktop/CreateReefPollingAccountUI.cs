using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using System.Windows.Automation;

namespace iClickerAutomation
{
	public class CreateReefPollingAccountUI : WindowsBaseAction
	{
		public IUIItem getIAgreeCheckbox() {
			return window.Get (SearchCriteria.ByControlType (ControlType.CheckBox));
		}

		public Button getCreateButton() {
			return window.Get<Button> (SearchCriteria.ByText("Create"));
		}
	}
}

