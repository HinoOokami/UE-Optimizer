using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Text;
//using System.Threading.Tasks;

namespace UE_Optimizer
{
	public partial class MainForm : Form
	{
		string _path;
		DirectoryInfo _di;
		List<string> _filesList = new List<string>();
	    
        string _fbDesc;
	    string _mbNotFoundTxt;
	    string _mbNotFoundCap;
	    string _mbAccErrCap;
	    string _mbReadErrCap;
	    string _mbWriteErrCap;

        public MainForm()
		{
			InitializeComponent();

			_di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
			_path = _di.FullName;
			lblPath.Text = _di.ToString();
			HideList(true);
			btnStart.Enabled = false;
			lblStatus.Visible = false;
            
		    LangSelector();
		}

	    static void EnableButton(Button button, bool enable) => button.Enabled = enable;

	    void HideList(bool hide)
		{
			if (hide)
				chkLbFiles.Hide();

			else
				chkLbFiles.Show();
		}

	    List<KeyValuePair<string, string>> _configFiles = new List<KeyValuePair<string, string>>();

	    async void btnBrowse_Click(object sender, EventArgs e)
		{
			var fb = new FolderBrowserDialog
			{
				SelectedPath = _path, Description = _fbDesc, ShowNewFolderButton = false
			};

			if (fb.ShowDialog() == DialogResult.OK)
				_path = fb.SelectedPath;

            lblPath.Text = _path;

			_di = new DirectoryInfo(_path);
			
			await SearchFiles(_di.ToString());

			if (_filesList.Count == 0)
			{
				MessageBox.Show(_mbNotFoundTxt, _mbNotFoundCap, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			await Task.Run(() =>
						   {
							   foreach (var file in _filesList)
							   {
								   try
								   {
									   using (var sr = new StreamReader(file))
									   {
										   var i = 0;
										   while (!sr.EndOfStream && i < 20)
										   {
											   i++;
											   var str = sr.ReadLine();
											   if (i < 10)
												   continue;

										       if (string.IsNullOrEmpty(str) || str.Length <= 9) continue;
										       var substr = str.Substring(0, 9);

										       if (substr != "GameName=") continue;
										       var gameName = str.Substring(9);
										       _configFiles.Add(new KeyValuePair<string, string>(gameName, file));
										       chkLbFiles.Items.Add(gameName + " - " + file);
										       break;
										   }
									   }
								   }
								   catch (Exception ex)
								   {
									   MessageBox.Show(ex.Message, _mbAccErrCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
								   }
							   }
						   });

			if (_configFiles.Count == 0)
			{
				MessageBox.Show(_mbNotFoundTxt, _mbNotFoundCap, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			if (chkLbFiles.Items.Count > 0)
				HideList(false);
		}

	    void chkLbFiles_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (e.NewValue == CheckState.Checked)
				EnableButton(btnStart, true);

			else if (chkLbFiles.CheckedItems.Count == 1)
				EnableButton(btnStart, false);
		}

	    async void btnStart_Click(object sender, EventArgs e)
		{
			await Task.Run(async () =>
						   {
							   for (var i = 0; i < chkLbFiles.Items.Count; i++)
							   {
							       if (!chkLbFiles.GetItemChecked(i)) continue;
							       var fi = new FileInfo(_configFiles[i].Value);
							       var sourceFileName = fi.FullName;
							       var backupFileName = sourceFileName.Insert(sourceFileName.Length - 4, "_UEOptimizer_Backup");
							       var bfi = new FileInfo(backupFileName);

							       if (!bfi.Exists) File.Copy(sourceFileName, backupFileName);

							       var entries = new List<string>();

							       try
							       {
							           using (var sr = new StreamReader(fi.FullName))
							           {
							               var line = sr.ReadLine();

							               while (line != null)
							               {
							                   entries.Add(line);
							                   line = sr.ReadLine();
							               }
							           }
							       }
							       catch (Exception ex)
							       {
							           MessageBox.Show(ex.Message, _mbReadErrCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
							       }

							       await Replace(entries);

							       try
							       {
							           if (fi.IsReadOnly) fi.IsReadOnly = false;

							           using (var sw = new StreamWriter(fi.FullName, false))
							           {
							               foreach (var str in entries)
							               {
							                   sw.WriteLine(str);
							               }
							           }

							           fi.IsReadOnly = true;
							       }
							       catch (Exception ex)
							       {
							           MessageBox.Show(ex.Message, _mbWriteErrCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
							       }

							       lblStatus.Visible = true;
							   }
						   });
		}

	    async Task Replace(List<string> entries)
		{
		    Task t = Task.Run(() => Parallel.For(0, entries.Count, i =>
		         {
		             var str = entries[i];
		             if (string.IsNullOrEmpty(str) || !str.Contains('=')) return;
		             var subStrKey = str.Substring(0, str.IndexOf('='));
		             string subStrValue = null;
                     switch (subStrKey)
                     {
                         case "bUseTextureStreaming":
                         case "bUseBackgroundLevelStreaming":
                         case "bSmoothFrameRate":
                         case "bInitializeShadersOnDemand":
                         case "bAllowMultiThreadedShaderCompile":
                         case "OnlyStreamInTextures":
                             subStrValue = ToTrue(str);
                             break;
                         case "DisableATITextureFilterOptimizationChecks":
                         case "UseMinimalNVIDIADriverShaderOptimization":
                             subStrValue = ToFalse(str);
                             break;
                         case "MipFadeInSpeed0":
                         case "MipFadeOutSpeed0":
                         case "MipFadeInSpeed1":
                         case "MipFadeOutSpeed1":
                             subStrValue = ToZero(str);
                             break;
                         case "PhysXGpuHeapSize":
                             subStrValue = "64";
                             break;
                         case "PhysXMeshCacheSize":
                             subStrValue = "16";
                             break;
                         case "MinSmoothedFrameRate":
                             subStrValue = "30";
                             break;
                         case "MaxSmoothedFrameRate":
                             subStrValue = "400";
                             break;
                         case "PoolSize":
                             subStrValue = (numUdVram.Value / 4).ToString(CultureInfo.InvariantCulture);
                             break;
                     }
                     if (!string.IsNullOrEmpty(subStrValue))
		                 entries[i] = subStrKey + "=" + subStrValue;
                 }));
		    await t;
        }

	    static string ToTrue(string str)
		{
			var subStrValue = str.Substring(str.IndexOf('=') + 1);
			if (subStrValue == "FALSE")
				subStrValue = "TRUE";
			else if (subStrValue == "False")
				subStrValue = "True";
			else if (subStrValue.ToLower() == "false")
				subStrValue = "true";

			return subStrValue;
		}

	    static string ToFalse(string str)
		{
			var subStrValue = str.Substring(str.IndexOf('=') + 1);
			switch (subStrValue)
			{
			    case "TRUE":
			        subStrValue = "FALSE";
			        break;
			    case "True":
			        subStrValue = "False";
			        break;
			    default:
			        if (subStrValue.ToLower() == "true")
			            subStrValue = "false";
			        break;
			}

			return subStrValue;
		}

	    static string ToZero(string str)
		{
			var subStrValue = str.Substring(str.IndexOf('=') + 1);

			byte check = 1;
			foreach (var c in subStrValue)
			{
				if (c < '0' && c > '9' && c != '.' && c != '-')
				{
					check = 0;
					break;
				}
				if (c == '.')
					check = 2;
			}

			if (check > 0)
				subStrValue = check > 1 ? "0.0" : "0";

			return subStrValue;
		}

	    async Task SearchFiles(string path)
		{
			try
			{
				foreach (var dir in Directory.GetDirectories(path))
				{
					foreach (var file in Directory.GetFiles(dir, "*Engine.ini", SearchOption.TopDirectoryOnly))
					{
						_filesList.Add(file);
					}
					await SearchFiles(dir);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, _mbAccErrCap, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

	    void LangSelector()
	    {
	        var ci = CultureInfo.CurrentUICulture.Name.Substring(0, 2);

	        switch (ci)
	        {
	            case "ru":
	            case "be":
	            case "ua":
	                _fbDesc = MyStrings.FbDescRus;
	                _mbNotFoundTxt = MyStrings.MbNotFoundTxtRus;
	                _mbNotFoundCap = MyStrings.MbNotFoundCapRus;
	                _mbAccErrCap = MyStrings.MbAccErrCapRus;
	                _mbReadErrCap = MyStrings.MbReadErrCapRus;
	                _mbWriteErrCap = MyStrings.MbWriteErrCapRus;
	                btnBrowse.Text = MyStrings.BrowseRus;
	                lblVRAM.Text = MyStrings.VramRus;
	                btnStart.Text = MyStrings.StartRus;
	                lblStatus.Text = MyStrings.StatusRus;
	                break;

	            default:
	                _fbDesc = MyStrings.FbDescEng;
	                _mbNotFoundTxt = MyStrings.MbNotFoundTxtEng;
	                _mbNotFoundCap = MyStrings.MbNotFoundCapEng;
	                _mbAccErrCap = MyStrings.MbAccErrCapEng;
	                _mbReadErrCap = MyStrings.MbReadErrCapEng;
	                _mbWriteErrCap = MyStrings.MbWriteErrCapEng;
	                btnBrowse.Text = MyStrings.BrowseEng;
	                lblVRAM.Text = MyStrings.VramEng;
	                btnStart.Text = MyStrings.StartEng;
	                lblStatus.Text = MyStrings.StatusEng;
	                break;
	        }
	    }
    }
}