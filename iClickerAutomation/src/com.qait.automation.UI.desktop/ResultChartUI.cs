using System;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using System.Windows.Automation;

namespace iClickerAutomation
{
	public class ResultChartUI : WindowsBaseAction
	{
		public ListBox getListOfOptionsUnderComboBox() {
			return window.Get<ListBox> (SearchCriteria.ByControlType (ControlType.List));
		}

	}
}

