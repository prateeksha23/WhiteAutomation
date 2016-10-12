using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace iClickerAutomation
{
	public class CourseDetailsUI : WindowsBaseAction
	{

		public Button getCreateButton() {
			return window.Get<Button> (SearchCriteria.ByText("Create"));
		}

		public Button getDisableReefButton() {
			return window.Get<Button> (SearchCriteria.ByText ("Disable REEF Polling"));
		}

		public Button getEditButton() {
			return window.Get<Button> (SearchCriteria.ByText ("Edit"));
		}
	}
}

