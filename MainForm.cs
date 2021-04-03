/*
 * Created by SharpDevelop.
 * User: Nestle_
 * Date: 03.02.2016
 * Time: 17:59
 * Thanks: https://github.com/neduard/acer_5750G_fan_maximiser
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Management;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using OpenHardwareMonitor.Hardware;
using Microsoft.Win32;

namespace FanController
{
	public partial class MainForm : Form
	{
		private readonly Font forTray = new Font("Arial", 20F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
		private Timer timerShow;
		private const string LPC_LINK = "ftp://ftp2.acer-euro.com/Archiv/notebook/aspire_5750G/fan/FanController_V1.0.0.3.zip",
			FORUM_LINK = "http://acerfans.ru/index.php?do=showpost&id=369157",
			FAN_MAN_NAME = "fan.dll",
			FAN_MAN_HASH = "4CF47BB88C87142983765061D6D36323",
			NEXT_LINE = "\n\r",
			SPACE_STRING = " ";
		private ContextMenu menu;
		private bool fanActive, customMode, Admin, lpcError;
		private int tempCpu, tempGpu, startTemp;
		private Properties.Settings1 settings = Properties.Settings1.Default;
		private ResourceManager rm;
		private Computer myComputer;
		private readonly MySettings pcSettings = new MySettings(new Dictionary<string, string>
		{
			{ "/intelcpu/0/temperature/0/values", "H4sIAAAAAAAEAOy9B2AcSZYlJi9tynt/SvVK1+B0oQiAYBMk2JBAEOzBiM3mkuwdaUcjKasqgcplVmVdZhZAzO2dvPfee++999577733ujudTif33/8/XGZkAWz2zkrayZ4hgKrIHz9+fB8/Iu6//MH37x79i9/+NX6N3/TJm9/5f/01fw1+fosnv+A/+OlfS37/jZ/s/Lpv9fff6Ml/NTef/yZPnozc5679b+i193//TQZ+/w2Dd+P9/sZeX/67v/GTf/b3iP3u4/ObBL//73+i+f039+D8Zk/+xz/e/P6beu2TQZju8yH8f6OgzcvPv/U3/Rb8+z/0f/9b/+yfaOn8079X6fr6Cws7ln/iHzNwflPv99/wyS/+xY4+v/evcJ+733+jJ5//Cw7/4ndy9Im3+U2e/Fbnrk31C93vrt/fyPvdb+N//hsF7/4/AQAA//9NLZZ8WAIAAA==" },
			{ "/intelcpu/0/load/0/values", "H4sIAAAAAAAEAOy9B2AcSZYlJi9tynt/SvVK1+B0oQiAYBMk2JBAEOzBiM3mkuwdaUcjKasqgcplVmVdZhZAzO2dvPfee++999577733ujudTif33/8/XGZkAWz2zkrayZ4hgKrIHz9+fB8/Iu6//MH37x79i9++mpwcv/md/9df89egZ/xX/ym/5y/4D37618Lv7ya//u+58+u+5d9/z7/5t/w9/6u5fP5bH/6av+eTkXyefXxp26ONaf/v/dG/sf39D/rvnv4e5vc/0IP56/waK/vuHzf5I38P8/tv+mv8Rbb9f0pwTF9/zr/1X9vP/8I//+/6Pf7Z30N+/zdf/HX29zd/859q4aCNP5b//U+U3/+7f+zXOjZwfqvDX/V7/o9/vPz+a1G/pv0f+fGlhfk7eZ//N3/0v28//5X0u/n8Cxq7+f1X/tHft20A5x8a/W5/02+BP36Nf+j/nv8XfzrT+c2//Ob4p3+vktvUhNs/+xcWikP6e/4T/5jS5M8/sL8vP/5ff49f/Ivl9//sHzv6PX/vXyG//9R/94/9HuZ34P/5vyC//3W/5e/1exa/k+Bw4bUBnU2bP4Xg/1bn0uafeTH6PatfKL//N3/0t2y/gG9+/8+IzqYNxmU+/+jwX7afY67/nwAAAP//GYSA31gCAAA=" },
		});
		
		[DllImport("nvcpl.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool NvCplGetThermalSettings
		(
			uint nWindowsMonitorNumber,
			out uint pdwCoreTemp,
			out uint pdwAmbientTemp,
			out uint pdwUpperLimit
		);
 
        [DllImport("nvcpl.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int NvGetLastError();
 
        [DllImport("nvcpl.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern StringBuilder NvGetLastErrorMessage();
		
		[DllImport("fan.dll", CallingConvention = CallingConvention.Cdecl)]
		private static extern int SetFanSpeed(char value);
		
		public MainForm(bool admin, string lang)
		{
			InitializeComponent();
			if(lang.Length > 0)
			{
				var culture = System.Globalization.CultureInfo.CreateSpecificCulture(lang.Length > 0 ? lang : "en");
				System.Threading.Thread.CurrentThread.CurrentCulture = culture; 
				System.Threading.Thread.CurrentThread.CurrentUICulture = culture;
			}
			
			rm = new ResourceManager("FanController.Properties.localize", typeof(MainForm).Assembly);
			lpcError = false;
			customMode = false;
			Admin = admin;
			settings.Save();
			if(!CheckMotherboard())
			{
				var result = MessageBox.Show(GetLocalized("WARNING_TEXT"), GetLocalized("WARNING"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if(result == DialogResult.Cancel)
	                Environment.Exit(0);
			}
			
			Application.ApplicationExit += OnApplicationExit;
			
			if(admin)
			{
				label6.Text = GetLocalized("RUN_AS");
				myComputer = new Computer(pcSettings){CPUEnabled = true, GPUEnabled = true};
				myComputer.Open();
			}
			
			timerShow = new Timer();
			timerShow.Tick += NextTick;
			timerShow.Enabled = true;
			
			FanManagement(0);
			if(settings.Temp <= 39 || settings.Temp >= 99)
			{
				settings.Temp = 50;
				startTemp = 50;
			}
			else
				startTemp = settings.Temp;
			
			labelStartTemp.Text = startTemp + GetLocalized("DEGREE_CELSIUS");
			if(settings.Time < 1 || settings.Temp >= 99)
			{
				settings.Time = 5;
				timerShow.Interval = 5000;
			}
			else
			{
				startTemp = settings.Temp;
				timerShow.Interval = settings.Time * 1000;
			}
			
			labelTime.Text = settings.Time + SPACE_STRING + GetLocalized("SECONDS");
			SetLabels();
			if(settings.TrayStart)
				MinimizeProgram();
			
			switch(settings.TrayTemp)
			{
				case 1:
					radioGPU.Checked = true;
					break;
				case 2:
					radioCPU.Checked = true;
					break;
			}
		}
		
		private void SetLabels()
		{
			label1.Text = GetLocalized("MANUAL_MODE");
			label2.Text = GetLocalized("AUTOSTART");
			label3.Text = GetLocalized("INFO");
			label4.Text = GetLocalized("SETTINGS");
			label8.Text = GetLocalized("TRAY");
			label9.Text = GetLocalized("TIMER");
			buttonSaveTimer.Text = GetLocalized("SAVE");
			buttonSaveStartTemp.Text = GetLocalized("SAVE");
			labelTextGPU.Text = GetLocalized("TEMP") + SPACE_STRING + GetLocalized("LABEL_GPU");
			labelTextCPU.Text = GetLocalized("TEMP") + SPACE_STRING + GetLocalized("LABEL_CPU");
			labelTempGPU.Text = GetLocalized("INITIALIZATION");
			labelTempCPU.Text = GetLocalized("INITIALIZATION");
			labelTextMode.Text = GetLocalized("FAN_MODE");
			labelTextTempOn.Text = GetLocalized("MAX_MODE_START_TEMP");
			label7.Text = GetLocalized("LAPTOP");
			labelNotebook.Text = GetPcName();
			labelMode.Text = GetLocalized(fanActive ? "MAX_MODE" : "NORMAL_MODE");
			menu = new ContextMenu();
            menu.MenuItems.Add(0, new MenuItem(GetLocalized("NORMALIZE"), Show_Click));
            menu.MenuItems.Add(1, new MenuItem(GetLocalized("EXIT"), Exit_Click));
			notifyIcon1.ContextMenu = menu;
			AutorunCheckBox.Checked = CheckOnStartUp();
		}
		
		private void NextTick(object sender, EventArgs e)
		{
            label6.Text = "";
            if(Admin)
            {
				tempCpu = GetAdminTemperatureCpu();
				//TempGPU = getAdminTemperatureGPU();
				tempGpu = GetNormalTemperatureGpu();
				label6.Text = GetLocalized("RUN_AS");
            }
            else
            {
				tempGpu = GetNormalTemperatureGpu();
	            tempCpu = GetNormalTemperatureCpu();
            }
            
			if(tempCpu > 0)
			{
				labelTempCPU.Text = tempCpu + GetLocalized("DEGREE_CELSIUS");
				if(!Admin)
					label6.Text = GetLocalized("OHW_DETECT") + NEXT_LINE;
			}
			else
				labelTempCPU.Text = GetLocalized("INITIALIZATION");
			
			if(tempGpu > 0)
			{
				labelTempGPU.Text = tempGpu + GetLocalized("DEGREE_CELSIUS");
				if(!Admin)
					label6.Text += GetLocalized("GPU_DETECT");
			}
			else
				labelTempGPU.Text = GetLocalized("INITIALIZATION");
			
			if(tempCpu == 0 && tempGpu == 0)
				label6.Text = GetLocalized(Admin ? "RUN_AS" : "NOT_DETECTED");
			
			if(notifyIcon1.Visible)
			{
				if(radioGPU.Checked && settings.TrayTemp == 1)
					DrawTrayString(tempGpu.ToString(), forTray, ColorTranslator.FromHtml("#FF0000"));
				
				if(radioCPU.Checked && settings.TrayTemp == 2)
					DrawTrayString(tempCpu.ToString(), forTray, ColorTranslator.FromHtml("#FF0000"));
			}
            FanControl();
		}
		
		private int GetAdminTemperatureCpu()
		{
            var temp = 0;
            foreach(var hardwareItem in myComputer.Hardware)
            {
	            if(hardwareItem.HardwareType != HardwareType.CPU)
		            continue;
	            
	            hardwareItem.Update();
	            foreach(var subHardware in hardwareItem.SubHardware)
		            subHardware.Update();

	            foreach(var sensor in hardwareItem.Sensors)
	            {
		            if(sensor.SensorType != SensorType.Temperature)
			            continue;
		            
		            temp = sensor.Value.HasValue ? Convert.ToInt32(sensor.Value.Value) : 0;
		            break;
	            }
            }
            return temp;
		}
		
		private int GetAdminTemperatureGpu()
		{
			var temp = 0;
            foreach(var hardwareItem in myComputer.Hardware)
            {
	            if(hardwareItem.HardwareType != HardwareType.GpuNvidia)
		            continue;
	            
	            hardwareItem.Update();
	            foreach(var subHardware in hardwareItem.SubHardware)
		            subHardware.Update();

	            foreach(var sensor in hardwareItem.Sensors)
	            {
		            if(sensor.SensorType != SensorType.Temperature)
			            continue;
		            
		            temp = sensor.Value.HasValue ? Convert.ToInt32(sensor.Value.Value) : 0;
		            break;
	            }
            }
            return temp;
		}
		
		private static int GetNormalTemperatureGpu()
		{
			var retTemp = 0;
			int count;
            var gpuHandles  = new Nvidia.NvPhysicalGpuHandle[64];
            var sensors = new Nvidia.NvGPUThermalSettings{Sensor = new Nvidia.NvSensor[3]};
            var status = Nvidia.NVAPI.NvAPI_EnumPhysicalGPUs(gpuHandles, out count);
			if(status != 0)
				return 0;
			
			if(count == 0)
				return 0;
	            
			for(var i = 0; i < count; ++i)
			{
				sensors.Version = 65604; // V2 struct
				sensors.Count = 3;
				status = Nvidia.NVAPI.NvAPI_GPU_GetThermalSettings(gpuHandles[i], 15, ref sensors);
				if(status != 0)
					continue;
	                
				for(var j = 0; j < sensors.Count; ++j)
				{
					retTemp = int.Parse("" + sensors.Sensor[j].CurrentTemp);
					if(retTemp > 0)
						return retTemp;
				}
			}
            return retTemp;
		}
		
		private static int GetNormalTemperatureCpu()
		{
			var retTemp = 0;
			try
            {
                var searcher = new ManagementObjectSearcher("root\\OpenHardwareMonitor", "SELECT value FROM Sensor WHERE SensorType = 'Temperature'");
                foreach(var o in searcher.Get())
                {
	                var queryObj = (ManagementObject)o;
	                retTemp = int.Parse(queryObj["value"].ToString());
                	break;
                }
            }
            catch
            {
            	retTemp = 0;
            }
            return retTemp;
		}
		
		private void MinimizeProgram()
		{
			if(WindowState != FormWindowState.Minimized)
				return;
			
			//this.Hide();
			notifyIcon1.Visible = true;
			if(settings.Minimize)
				return;
			
			settings.Minimize = true;
			notifyIcon1.BalloonTipText = GetLocalized("MINIMIZE");
			notifyIcon1.BalloonTipTitle = GetLocalized("INFO");
			notifyIcon1.ShowBalloonTip(800);
		}
		
		private void NormalizeFanController()
		{
		    Show();
			WindowState = FormWindowState.Normal;
			notifyIcon1.Visible = false;
		}
		
		private void Form1_Resize(object sender, EventArgs e)  
		{
			MinimizeProgram();
		}
		
		private void Exit_Click(object sender, EventArgs e)
		{
		    Close();
		}
		
		private void Show_Click(object sender, EventArgs e) 
		{
			NormalizeFanController();
		}
		
		private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)  
		{
			Show();
			WindowState = FormWindowState.Normal;
			notifyIcon1.Visible = false;
		}
		
		private void textStartTemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }
		
		private void change_KeyPress(object sender, MouseEventArgs e) 
        {
			if(customMode)
			{
				customMode = false;
				FanManagement(0);
			}
			else
			{
				customMode = true;
            	FanManagement(1);
			}
        }
		
		private void change_Autorun(object sender, MouseEventArgs e) 
        {
			AutorunCheckBox.Checked = AddOnStartUp();
        }
		
		private void go_to_forum(object sender, MouseEventArgs e)
		{
			Process.Start(FORUM_LINK);
		}
		
		private void textStartTemp_TextChange(object sender, EventArgs e)
        {
            
        }
		
		private void DrawTrayString(string str, Font font, Color foreColor)
        {
			var bmp = Resource1.main.ToBitmap();
			using(var g = Graphics.FromImage(bmp))
            {
                g.DrawString(str, font, new SolidBrush(foreColor), 0, 0);
            }
            notifyIcon1.Icon = Icon.FromHandle(bmp.GetHicon());
        }
		
		private void change_Time(object sender, EventArgs e)
        {
			int newTime;
			var isInt = int.TryParse(textTime.Text, out newTime);
			if(!isInt)
				return;
			
			if(newTime > 99 || newTime < 1)
				MessageBox.Show(GetLocalized("TICK_TIME_ERROR"), GetLocalized("ERROR"));
			else
			{
				settings.Time = newTime;
				settings.Save();
				labelTime.Text = newTime + SPACE_STRING + GetLocalized("SECONDS");
				timerShow.Interval = newTime * 1000;
				MessageBox.Show(GetLocalized("SAVED_TEXT") + newTime + SPACE_STRING + GetLocalized("SECONDS"), GetLocalized("SAVED"));
			}
		}
		
		private void change_StartTemp(object sender, EventArgs e)
        {
			int newTemp;
			var isInt = int.TryParse(textStartTemp.Text, out newTemp);
			if(!isInt)
				return;
			
			if(newTemp > 99 || newTemp < 40)
				MessageBox.Show(GetLocalized("SAVE_ERROR_TEXT"), GetLocalized("ERROR"));
			else
			{
				settings.Temp = newTemp;
				settings.Save();
				labelStartTemp.Text = newTemp + GetLocalized("DEGREE_CELSIUS");
				startTemp = newTemp;
				MessageBox.Show(GetLocalized("SAVED_TEXT") + startTemp + GetLocalized("DEGREE_CELSIUS"), GetLocalized("SAVED"));
			}
        }
		
		private void click_RadioGPU(object sender, EventArgs e)
		{
			if(settings.TrayTemp == 1)
			{
				settings.TrayTemp = 0;
				settings.Save();
				radioGPU.Checked = false;
			}
			else if(radioGPU.Checked)
			{
				settings.TrayTemp = 1;
				settings.Save();
			}
		}
		
		private void click_RadioCPU(object sender, EventArgs e)
		{
			if(settings.TrayTemp == 2)
			{
				radioCPU.Checked = false;
				settings.TrayTemp = 0;
				settings.Save();
			}
			else if(radioCPU.Checked)
			{
				settings.TrayTemp = 2;
				settings.Save();
			}
		}
		
		private int GetStartTemp()
		{
			if(startTemp > 39 && startTemp < 99)
				return startTemp;
			
			startTemp = 50;
			labelStartTemp.Text = startTemp + GetLocalized("DEGREE_CELSIUS");
			return startTemp;
		}
		
		private void FanControl()
		{
			if(!customMode)
			{
				var temp = GetStartTemp();
				if(tempCpu >= temp || tempGpu >= temp)
				{
					if(!fanActive)
	            		FanManagement(1);
				}
	           	else
	           	{
					if(fanActive && tempCpu <= temp - 5 && tempGpu <= temp - 5)
						FanManagement(0);
	           	}
			}
			
			notifyIcon1.Text = GetLocalized("TRAY_CPU") + labelTempCPU.Text + NEXT_LINE + GetLocalized("TRAY_GPU") + labelTempGPU.Text + NEXT_LINE + GetLocalized("TRAY_MODE") + labelMode.Text;
		}
		
		private void ShowLpcError()
		{
			lpcError = true;
			var result = MessageBox.Show(GetLocalized("ACER_PROGRAM"), GetLocalized("ERROR"), MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
			switch(result)
			{
				case DialogResult.OK:
					Process.Start(LPC_LINK);
					Environment.Exit(0);
					break;
				
				case DialogResult.Cancel:
					Environment.Exit(0);
					break;
				
				case DialogResult.None:
					break;
				
				case DialogResult.Abort:
					break;
				
				case DialogResult.Retry:
					break;
				
				case DialogResult.Ignore:
					break;
				
				case DialogResult.Yes:
					break;
				
				case DialogResult.No:
					break;
				
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
		
		private void FanManagement(int i)
		{
			if(File.Exists(FAN_MAN_NAME) && GetHashMd5(FAN_MAN_NAME) == FAN_MAN_HASH && lpcError == false)
			{
				var r = SetFanSpeed(i == 1 ? (char)0x77 : (char)0x76);
				if(r == 0)
					return;
				
				if(i == 1)
                {
	                fanActive = true;
	                labelMode.Text = GetLocalized("MAX_MODE");
                }
                else
                {
	                fanActive = false;
	                labelMode.Text = GetLocalized("NORMAL_MODE");
                }
			}
			else if(!File.Exists(FAN_MAN_NAME))
				label7.Text = GetLocalized("DLL_NOT_FOUND");
			else if(GetHashMd5(FAN_MAN_NAME) != FAN_MAN_HASH)
				label7.Text = GetLocalized("OLD_DLL") + FAN_MAN_NAME;
		}
		
		private void OnApplicationExit(object sender, EventArgs e)
        {
			FanManagement(0);
        }
		
		private static string GetPcName()
		{
			var regKey = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\BIOS");
			return regKey != null ? Convert.ToString(regKey.GetValue("SystemProductName")) : "";
		}
		
		private static bool CheckMotherboard()
		{
			var regKey = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\BIOS");
			return regKey != null && Convert.ToString(regKey.GetValue("BaseBoardProduct")) == "JE50_HR";
		}
		
		private static string GetHashMd5(string path)
        {
            using(var fs = File.OpenRead(path))
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                var fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                var checkSum = md5.ComputeHash(fileData);
                var result = BitConverter.ToString(checkSum).Replace("-", string.Empty);
                return result;
            }
        }
        
        private bool AddOnStartUp()
        {
            var regKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            if(regKey == null)
	            return false;

            try
            {
	            if(!CheckOnStartUp())
	            {
		            var result = MessageBox.Show(GetLocalized("AUTOSTART_ADD"), GetLocalized("ATTENTION"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
		            switch(result)
		            {
			            case DialogResult.Yes:
				            regKey.SetValue("FanController", Application.ExecutablePath + " -admin");
				            MessageBox.Show(GetLocalized("AUTOSTART_ADDED_ADMIN"), GetLocalized("INFO"));
				            break;

			            case DialogResult.No:
				            regKey.SetValue("FanController", Application.ExecutablePath);
				            MessageBox.Show(GetLocalized("AUTOSTART_ADDED"), GetLocalized("INFO"));
				            break;

			            case DialogResult.Cancel:
				            return false;

			            case DialogResult.None:
				            break;

			            case DialogResult.OK:
				            break;

			            case DialogResult.Abort:
				            break;

			            case DialogResult.Retry:
				            break;

			            case DialogResult.Ignore:
				            break;

			            default:
				            throw new ArgumentOutOfRangeException();
		            }

		            return true;
	            }
	            else
		            regKey.DeleteValue("FanController");

	            regKey.Close();
            }
            catch
            {
	            // ignored
            }

            MessageBox.Show(GetLocalized("AUTOSTART_REMOVED"), GetLocalized("INFO"));
			return false;
        }
        
        private static bool CheckOnStartUp()
        {
        	var regKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            if(regKey == null)
	            return false;
            
            var has = Convert.ToString(regKey.GetValue("FanController"));
            return has == Application.ExecutablePath || has == Application.ExecutablePath + " -admin";
        }

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// ignored
		}

		private string GetLocalized(string name)
		{
			try
			{
				return rm.GetString(name);
			}
			catch
			{
				return "LABEL \"" + name + "\" not found";
			}
		}
	}
	
	public class MySettings : ISettings
    {
        private IDictionary<string, string> settings = new Dictionary<string, string>();

        public MySettings(IDictionary<string, string> settings)
        {
            this.settings = settings;
        }

        public bool Contains(string name)
        {
            return settings.ContainsKey(name);
        }

        public string GetValue(string name, string value)
        {
	        string result;
	        return settings.TryGetValue(name, out result) ? result : value;
        }

        public void Remove(string name)
        {
            settings.Remove(name);
        }

        public void SetValue(string name, string value)
        {
            settings[name] = value;
        }
    }
}
