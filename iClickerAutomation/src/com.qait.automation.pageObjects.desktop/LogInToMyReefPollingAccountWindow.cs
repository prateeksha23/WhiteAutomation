using System;
using TestStack.White;
using TestStack.White.UIItems;
using NUnit.Framework;

namespace iClickerAutomation
{
	public class LogInToMyReefPollingAccountWindow : LoginReefAccountUI
	{
		Application app;

		public LogInToMyReefPollingAccountWindow (Application app)
		{
			this.app = app;
		}

		public void clickOnCreateAccountButton() {
			Button btn_createAccount = getCreateAccountButton ();
			Assert.IsTrue (btn_createAccount.Visible, "Assertion failed : Create New Account button is not visible on login window");
			logMessage ("Assertion passed : Create New Account button is visible on login window");
			btn_createAccount.Click ();
			logMessage ("Clicked on create account button on login window");
		}
	}
}

