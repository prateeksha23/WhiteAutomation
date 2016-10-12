using System;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using NUnit.Framework;

namespace iClickerAutomation
{
	public class ResultChartWindow : ResultChartUI
	{
		Application app;

		public ResultChartWindow (Application app)
		{
			this.app = app;
		}

		public void closeWindow() {
			window.Close ();
			window = getWindowHandle (app, YamlReader.getData ("toolbar.title"));
		}

		public void verifyQuestions() {
			ListBox list_questions = getListOfOptionsUnderComboBox ();
			ListItem[] listItems = list_questions.Items.ToArray ();
			int i = 1;
			foreach(ListItem item in listItems){
				StringAssert.AreEqualIgnoringCase (("Question " + i), item.Name);
				i++;
			}
			logMessage ("Assertion passed : Options under questions combo box are correct");
		}

	}
}

