using System;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using System.Windows.Automation;
using TestStack.White.UIItems.MenuItems;

namespace iClickerAutomation
{
	public class MainWindowUI : WindowsBaseAction
	{
		public IUIItem[] getListOfButtons() {
			return window.GetMultiple(SearchCriteria.ByControlType (ControlType.Button));
		}

		public IUIItem getCreateNewButton() {
			return getListOfButtons () [6];
		}

		public IUIItem getSettingsButton() {
			return getListOfButtons () [8];
		}

		public IUIItem getDeleteButton() {
			return getListOfButtons () [7];
		}

		public Button getDeleteButtonOnDeleteWindow() {
			return window.Get<Button> (SearchCriteria.ByText ("Delete Course"));
		}

		public Button getStartNewSessionButton() {
			return window.Get<Button> (SearchCriteria.ByText ("Start New Session"));
		}

		public Button getResumeSessionButton() {
			return window.Get<Button> (SearchCriteria.ByText ("Resume Session"));
		}

		public IUIItem getCourseText(String courseName) {
			return window.Get (SearchCriteria.ByText(courseName));
		}

		public Menu getFileMenu() {
			return window.Get<Menu> (SearchCriteria.ByText ("File"));
		}

		public Menu getCourseMenu() {
			return window.Get<Menu> (SearchCriteria.ByText ("Course"));
		}

		public Menu getSessionMenu() {
			return window.Get<Menu> (SearchCriteria.ByText ("Session"));
		}

		public Menu getHelpMenu() {
			return window.Get<Menu> (SearchCriteria.ByText ("Help"));
		}

		public Menu getAboutMenuFromHelp() {
			return window.Get<Menu> (SearchCriteria.ByText ("About i>clicker"));
		}

		public Menu getCheckForUpdatesMenuFromHelp() {
			return window.Get<Menu> (SearchCriteria.ByText ("Check for Update"));
		}

		public Menu getOpenGradebookMenuFromFile() {
			return window.Get<Menu> (SearchCriteria.ByText ("Open Gradebook"));
		}

		public Button getOpenGradebookButton() {
			return window.Get<Button> (SearchCriteria.ByText ("Open Gradebook"));
		}

		public IUIItem getNoCourseCreatedMessage() {
			return window.Get (SearchCriteria.ByText ("                   Create a new course to begin."));
		}
	}
}

