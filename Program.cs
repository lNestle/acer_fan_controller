/*
 * Created by SharpDevelop.
 * User: Nestle_
 * Date: 03.02.2016
 * Time: 17:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace FanController
{
	internal sealed class Program
	{
		[DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [STAThread]
        private static void Main(string[] input)
        {
	        Console.WriteLine(input);
            var principal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
			var hasAdministrativeRight = principal.IsInRole(WindowsBuiltInRole.Administrator);
			if(!hasAdministrativeRight)
			{
		        if(input.Length != 0 && input.Contains("-admin"))
		        {
			        var process = new ProcessStartInfo{Verb = "runas", FileName = Application.ExecutablePath};
			        try
	                {
	                    Process.Start(process);
	                }
			        catch
			        {
				        // ignored
			        }

			        return;
		        }
			}
			
			var processes = Process.GetProcesses();
			var pid = Process.GetCurrentProcess().Id;
			foreach(var process in processes)
			{
				if(pid == process.Id)
					continue;

				if(process.ProcessName.IndexOf("FanController", StringComparison.Ordinal) == -1 && process.MainWindowTitle != "Fan Controller by Nestle_")
					continue;
				
				try
				{
					ShowWindow(process.MainWindowHandle, 9);
					Interaction.AppActivate(process.Id);
				}
				catch
				{
					// ignored
				}
				return;
			}

			var lang = "";
			if(input.Contains("-russian"))
				lang = "ru-RU";
			else if(input.Contains("-english"))
				lang = "en-US";
			
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(hasAdministrativeRight, lang));
        }
	}
}
