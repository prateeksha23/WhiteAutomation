using System;
using TestStack.White;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.Factory;
using System.Windows.Automation;
using System.Diagnostics;
using System.Runtime.InteropServices;
using NLog;
using System.Xml;
using System.Data;
using System.IO;
using NUnit.Framework;
using System.Net;
using System.IO;

namespace iClickerAutomation
{
	public class WindowsBaseAction
	{
		[DllImport("user32.dll", SetLastError = true)]
		internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

		[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
		internal static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll")]
		static extern bool SetForegroundWindow(IntPtr hWnd);

		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		public static Window window;
		private static Logger logger = LogManager.GetCurrentClassLogger();

		public Window getWindowHandle(Application app, String handle){
			return app.GetWindow (handle, InitializeOption.NoCache);
		}

		public void sendKeys(String text) {
			System.Windows.Forms.SendKeys.SendWait (text);
			System.Windows.Forms.SendKeys.SendWait ("{TAB}");
		}

		public void hardWait(int seconds) {
			System.Threading.Thread.Sleep(seconds*1000);
		}

		public String verifyImagePresent(String image) {
			HttpWebRequest myHttpWebRequest1 =
				(HttpWebRequest)WebRequest.Create("http://127.0.0.1:4567/action/exists/"+image+"/10");
			myHttpWebRequest1.Method = "GET";
			HttpWebResponse myHttpWebResponse1 = 
				(HttpWebResponse)myHttpWebRequest1.GetResponse();
			Stream streamResponse=myHttpWebResponse1.GetResponseStream();
			StreamReader streamRead = new StreamReader( streamResponse );
			return streamRead.ReadToEnd ();
		}

		public void logMessage(String message) {
			logger.Info (message);
		}

		public void moveWindowToTop() {
			IntPtr id;
			id = GetForegroundWindow ();
			MoveWindow (id, 0, 0, 200, 200, true);
		}

		public void setForgroundwindow() {
			hardWait (5);
			var processes = Process.GetProcessesByName("iclicker");
			Application app = Application.Attach (processes[0]);
			ShowWindow (processes[0].MainWindowHandle, 3);
			SetForegroundWindow(processes[0].MainWindowHandle);
			hardWait (5);
		}

		public void verifyValueInConfigFile(String param) {
			XmlDataDocument xml = new XmlDataDocument ();
			XmlNodeList xmlnode ;
			FileStream fs = new FileStream(YamlReader.getData("Application.globalConfigPath"), FileMode.Open, FileAccess.Read);
			xml.Load(fs);
			xmlnode = xml.GetElementsByTagName(param);
			StringAssert.AreEqualIgnoringCase ("false", xmlnode [0].InnerText.Trim (), "Assertion failed : mcOnly value is not set to false by default");
			logMessage ("Assertion passed : mcOnly value is set to false by default");
			fs.Close ();
		}

		public void changeValueInXml(String param, String value) {
			XmlDocument xml = new XmlDocument ();
			XmlNodeList xmlnode ;
			xml.Load(YamlReader.getData("Application.globalConfigPath"));
			xmlnode = xml.GetElementsByTagName(param);
			xmlnode [0].InnerText=value;
			System.Console.WriteLine ("xml value ::"+xmlnode [0].InnerText.Trim ());
			logMessage ("mcOnly value changed to true");
			xml.Save (YamlReader.getData("Application.globalConfigPath"));
		}
	}
}

