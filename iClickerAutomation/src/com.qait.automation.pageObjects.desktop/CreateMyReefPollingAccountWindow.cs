using System;
using TestStack.White;
using TestStack.White.UIItems;
using NUnit.Framework;

namespace iClickerAutomation
{
	public class CreateMyReefPollingAccountWindow : CreateReefPollingAccountUI
	{
		Application app;

		public CreateMyReefPollingAccountWindow (Application app)
		{
			this.app = app;
		}
			

		public void enterDetailsForAccount(){
			sendKeys ("First");
			logMessage ("User enters First in first name field");
			sendKeys ("Last");
			logMessage ("User enters Last in last name field");
			String email = "email"+DateTime.Now.Ticks+"@reef-eduction.com";
			sendKeys (email);
			logMessage ("User enters " + email + " in email text field");
			sendKeys ("password");
			logMessage ("User enters password in password field");
			sendKeys ("password");
			logMessage ("User enters password in retype password field");
		}

		public void selectIAgreeCheckbox() {
			IUIItem chkbox_agree = getIAgreeCheckbox ();
			Assert.IsTrue (chkbox_agree.Visible, "Assertion failed : I agree checkbox is not visible on Create account window");
			logMessage ("Assertion passed : I agree checkbox is visible on Create account window");
			chkbox_agree.Click ();
			logMessage ("User selects I Agree checkbox on Create account window");
		}

		public void clickOnCreateButton() {
			Button btn_createNewAccount = getCreateButton ();
			Assert.IsTrue (btn_createNewAccount.Visible, "Assertion failed : Create button is not visible on Create account window");
			logMessage ("Assertion passed : Create button is visible on Create account window");
			btn_createNewAccount.Click ();
			logMessage ("clicked on Create account button on create account window");
		}
	}
}

