using System;
using TestStack.White;
using TestStack.White.UIItems;
using NUnit.Framework;

namespace iClickerAutomation
{
	public class CreateCourseWindow : CreateCourseUI
	{
		Application app;

		public CreateCourseWindow (Application app)
		{
			this.app = app;
		}

		public void enterCourseName(String courseName) {
			sendKeys (courseName);
			logMessage ("User enters " + courseName + " in course name field");
		}

		public void clickOnCreateButton() {
			Button btn_create = getCreateButton ();
			Assert.IsTrue (btn_create.Visible, "Assertion failed : Create button is not visible on Create course window");
			logMessage ("Assertion passed : Create button is visible on Create course window"); 
			btn_create.Click ();
			logMessage ("Clicked on Create button on Create course window");
		}

		public void verifyErrorMessageOnDuplicateCourseCreation() {
			IUIItem txt_errorMessage = getDuplicateCourseMessage ();
			Assert.IsTrue (txt_errorMessage.Visible, "Assertion failed : No error message is displayed on duplicate course creation");
			logMessage ("Assertion Passed : Error message is displayed on duplicate course creation");
		}

		public void clickOnCloseButton() {
			Button btn_close = getCloseButton ();
			btn_close.Click ();
			logMessage ("Clicked on close button on create course window");
		}
	}
}

