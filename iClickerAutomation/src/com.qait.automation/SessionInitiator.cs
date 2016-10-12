using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.Factory;
using System.Diagnostics;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

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
		public ToolBarWindow toolbarWindow;
		public WindowsBaseAction baseActions;
		public ResultChartWindow resultsWindow;
		public GradebookWindow gradebookWindow;
		public HelpWindow helpWindow;

		public IWebDriver driver;
		public LoginPageActions loginPage;
		public CoursesPageActions coursePage;
		int processId;

		public SessionInitiator ()
		{
			_attachApplication ();
			_initWindows ();
			_startSikuliServer ();
		}

		public void _startSikuliServer() {
			Process p = Process.Start ("cmd.exe","/k java -jar sikuli.jar");
			processId = p.Id;
		}

		private void _initWindows() {
			mainWindow = new MainWindow (app);
			createCourseWindow = new CreateCourseWindow (app);
			courseSettingsWindow = new CourseSettingsWindow (app);
			logInWindow = new LogInToMyReefPollingAccountWindow (app);
			createAccountWindow = new CreateMyReefPollingAccountWindow (app);
			courseDetailsWindow = new CourseDetailsWindow (app);
			toolbarWindow = new ToolBarWindow (app);
			resultsWindow = new ResultChartWindow (app);
			gradebookWindow = new GradebookWindow (app);
			helpWindow = new HelpWindow (app);
			baseActions = new WindowsBaseAction ();
		}

		private void _attachApplication() {
			Process.Start (YamlReader.getData("Application.path"));
			WindowsBaseAction windowBase = new WindowsBaseAction ();
			windowBase.hardWait (3);
			var processes = Process.GetProcessesByName(YamlReader.getData("Application.processName"));
			app = Application.Attach (processes[0]);
		}

		public void launchUrl(String url) {
			driver.Navigate().GoToUrl(url);
		}

		public void initializeDriver () {
			//driver = new ChromeDriver ("..\\..\\resources\\drivers");
			driver = new FirefoxDriver();
			WindowsBaseAction windowBase = new WindowsBaseAction ();
			driver.Manage ().Window.Maximize ();
			driver.Manage ().Timeouts ().ImplicitlyWait (TimeSpan.FromSeconds(30));
			_initWebPages ();	
		}

		public void _initWebPages() {
			loginPage = new LoginPageActions (driver);
			coursePage = new CoursesPageActions (driver);
		}

		public void launchApplication() {
			app = Application.Launch (YamlReader.getData("Application.path"));
		}

		public void closeSession() {
			//var processes = Process.GetProcessesByName("C:\Windows\System32\cmd.exe - java  -jar sikuli.jar");
			//processes[0].Close();
			Process.GetProcessById(processId).Kill();

			/*Process[] processes = Process.GetProcesses ();
			foreach (Process p in processes) {
				if (p.Id == processId) {
					p.Kill();
					System.Console.WriteLine ("Closed sikuli server");
				}
			}*/
			app.Close ();
		}

		public void quitBrowser() {
			driver.Quit ();
		}
	}
}

