using System;
using TestStack.White;
using TestStack.White.UIItems;
using NUnit.Framework;

namespace iClickerAutomation
{
	public class CourseDetailsWindow : CourseDetailsUI
	{
		Application app;


		public CourseDetailsWindow (Application app)
		{
			this.app = app;
		}

		public void enterInstitutionDetails(String institutionName) {
			window.WaitWhileBusy();
			hardWait (5);
			sendKeys (institutionName);
			logMessage("User enters "+institutionName+" in Institution name field");

		}

		public void enterCourseName(String courseName) {
			sendKeys (courseName);
			logMessage("User enters "+courseName+" in Course name field");
		}

		public void clickOnCreateButton() {
			hardWait (2);
			Button btn_createReefEnabledCourse = getCreateButton ();
			Assert.IsTrue (btn_createReefEnabledCourse.Visible, "Assertion failed : Create button is not visible on Institution details window");
			logMessage("Asserion Passed : Create button is visible on Institution details window");
			btn_createReefEnabledCourse.Click ();
			logMessage("Clicked on Create button on Course details window");
		}

		public void verifyCourseDetails() {
			Button btn_disableReef = getDisableReefButton ();
			Assert.IsTrue (btn_disableReef.Visible, "Assertion failed : Disable reef button is not visible on Course details window");
			logMessage("Asserion Passed : Disable reef button is visible on Course details window");
			Button btn_edit = getEditButton ();
			Assert.IsTrue (btn_edit.Visible, "Assertion failed : Edit button is not visible on Course details window");
			logMessage("Asserion Passed : Edit button is visible on Course details window");
		}
	}
}

