using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Factory;
using System.Diagnostics;

namespace iClickerAutomation
{
	public class SessionInitiator
	{
		[DllImport("user32.dll")]
		static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		Application app;
		public MainWindow mainWindow;
		public CreateCourseWindow createCourseWindow;
		public CourseSettingsWindow courseSettingsWindow;
		public LogInToMyReefPollingAccountWindow logInWindow;
		public CreateMyReefPollingAccountWindow createAccountWindow;
		public CourseDetailsWindow courseDetailsWindow;
		public IClickerLiteWindow iClickerLiteWindow;
		public BaseAction baseActions;

		public SessionInitiator ()
		{
			_attachApplication ();
			_initWindows ();
		}

		private void _initWindows() {
			mainWindow = new MainWindow (app);
			createCourseWindow = new CreateCourseWindow (app);
			courseSettingsWindow = new CourseSettingsWindow (app);
			logInWindow = new LogInToMyReefPollingAccountWindow (app);
			createAccountWindow = new CreateMyReefPollingAccountWindow (app);
			courseDetailsWindow = new CourseDetailsWindow (app);
			iClickerLiteWindow = new IClickerLiteWindow (app);
		}

		private void _attachApplication() {
			var processes = Process.GetProcessesByName("iclicker");
			app = Application.Attach (processes[0]);
			ShowWindow (processes[0].MainWindowHandle, 3);
			SetForegroundWindow(processes[0].MainWindowHandle);
		}
	}
}

