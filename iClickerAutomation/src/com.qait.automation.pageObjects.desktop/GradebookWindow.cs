using System;
using TestStack.White;
using TestStack.White.UIItems;
using NUnit.Framework;

namespace iClickerAutomation
{
	public class GradebookWindow : GradebookUI
	{
		Application app;

		public GradebookWindow (Application app) 
		{
			this.app = app;
		}

		public void closeWindow() {
			window.Close ();
			window = getWindowHandle (app, YamlReader.getData ("mainWindow.title"));
		}
	}
}

