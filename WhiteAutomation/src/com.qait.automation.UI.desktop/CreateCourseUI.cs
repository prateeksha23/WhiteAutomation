using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace iClickerAutomation
{
	public class CreateCourseUI : WindowsBaseAction
	{
		public Button getCreateButton() {
			return window.Get<Button> (SearchCriteria.ByText("Create"));
		}

		public IUIItem getDuplicateCourseMessage() {
			return window.Get (SearchCriteria.ByText ("Course already exists."));
		}

		public Button getCloseButton() {
			return window.Get<Button> (SearchCriteria.ByText ("Close"));
		}
	}
}

