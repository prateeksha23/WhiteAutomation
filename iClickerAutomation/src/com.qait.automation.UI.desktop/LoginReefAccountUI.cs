using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;

namespace iClickerAutomation
{
	public class LoginReefAccountUI : WindowsBaseAction
	{
		public Button getCreateAccountButton() {
			return window.Get<Button> (SearchCriteria.ByText ("Create Account"));
		}
	}
}

