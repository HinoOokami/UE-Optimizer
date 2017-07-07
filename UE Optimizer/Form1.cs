using System;
using System.Collections.Generic;
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
		List<string> filesList = new List<string>();

		public MainForm()
		{
			InitializeComponent();

			_di = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
			_path = _di.FullName;
			lblPath.Text = _di.ToString();
			HideList(true);
			btnStart.Enabled = false;
			lblStatus.Visible = false;
		}

		private void EnableButton(Button button, bool enable) => button.Enabled = enable;

	    private void HideList(bool hide)
		{
			if (hide)
				chkLbFiles.Hide();

			else
				chkLbFiles.Show();
		}

		private List<KeyValuePair<string, string>> _configFiles = new List<KeyValuePair<string, string>>();

		private async void btnBrowse_Click(object sender, EventArgs e)
		{
			var fb = new FolderBrowserDialog
			{
				SelectedPath = _path,
				Description = "Выберите папку с настройками игры на Unreal Engine.\n" +
							  "(можно указать папку MyGames для поиска всех игр Steam).",
				ShowNewFolderButton = false
			};

			if (fb.ShowDialog() == DialogResult.OK)
				_path = fb.SelectedPath;

            lblPath.Text = _path;

			_di = new DirectoryInfo(_path);
			
			await SearchFiles(_di.ToString());

			if (filesList.Count == 0)
			{
				MessageBox.Show("Конфигурационные файлы не найдены!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			await Task.Run(() =>
						   {
							   foreach (string file in filesList)
							   {
								   try
								   {
									   using (var sr = new StreamReader(file))
									   {
										   int i = 0;
										   while (!sr.EndOfStream && i < 20)
										   {
											   i++;
											   string str = sr.ReadLine();
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
									   MessageBox.Show(ex.Message, "Ошибка доступа к файлу!", MessageBoxButtons.OK, MessageBoxIcon.Error);
								   }
							   }
						   });

			if (_configFiles.Count == 0)
			{
				MessageBox.Show("Конфигурационные файлы не найдены!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			if (chkLbFiles.Items.Count > 0)
				HideList(false);
		}

		private void chkLbFiles_ItemCheck(object sender, ItemCheckEventArgs e)
		{
			if (e.NewValue == CheckState.Checked)
				EnableButton(btnStart, true);

			else if (chkLbFiles.CheckedItems.Count == 1)
				EnableButton(btnStart, false);
		}

		private async void btnStart_Click(object sender, EventArgs e)
		{
			await Task.Run(async () =>
						   {
							   for (int i = 0; i < chkLbFiles.Items.Count; i++)
							   {
								   if (chkLbFiles.GetItemChecked(i))
								   {
									   var fi = new FileInfo(_configFiles[i].Value);
									   string sourceFileName = fi.FullName;
									   string backupFileName = sourceFileName.Insert(sourceFileName.Length - 4, "_UEOptimizer_Backup");
									   var bfi = new FileInfo(backupFileName);

									   if (!bfi.Exists)
										   File.Copy(sourceFileName, backupFileName);

									   var entries = new List<string>();

									   try
									   {
										   using (var sr = new StreamReader(fi.FullName))
										   {
											   string line = sr.ReadLine();

											   while (line != null)
											   {
												   entries.Add(line);
												   line = sr.ReadLine();
											   }
										   }
									   }
									   catch (Exception ex)
									   {
										   MessageBox.Show(ex.Message, "Ошибка чтения из файла!", MessageBoxButtons.OK, MessageBoxIcon.Error);
									   }

									   await Replace(entries);

									   try
									   {
										   if (fi.IsReadOnly)
											   fi.IsReadOnly = false;

										   using (var sw = new StreamWriter(fi.FullName, false))
										   {
											   foreach (string str in entries)
											   {
												   sw.WriteLine(str);
											   }
										   }

										   fi.IsReadOnly = true;
									   }
									   catch (Exception ex)
									   {
										   MessageBox.Show(ex.Message, "Ошибка записи в файл!", MessageBoxButtons.OK, MessageBoxIcon.Error);
									   }

									   lblStatus.Visible = true;
								   }
							   }
						   });
		}

		private async Task Replace(List<string> entries)
		{
		    Task t = Task.Run(() => Parallel.For(0, entries.Count, i =>
		         {
		             string str = entries[i];
		             if (!string.IsNullOrEmpty(str) && str.Contains('='))
		             {
		                 string subStrKey = str.Substring(0, str.IndexOf('='));
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
		                         subStrValue = (numUdVram.Value / 4).ToString();
		                         break;
		                 }
		                 if (!string.IsNullOrEmpty(subStrValue))
		                     entries[i] = subStrKey + "=" + subStrValue;
		             }
		         }));
		    await t;
		}

		private string ToTrue(string str)
		{
			string subStrValue = str.Substring(str.IndexOf('=') + 1);
			if (subStrValue == "FALSE")
				subStrValue = "TRUE";
			else if (subStrValue == "False")
				subStrValue = "True";
			else if (subStrValue.ToLower() == "false")
				subStrValue = "true";

			return subStrValue;
		}

		private string ToFalse(string str)
		{
			string subStrValue = str.Substring(str.IndexOf('=') + 1);
			if (subStrValue == "TRUE")
				subStrValue = "FALSE";
			else if (subStrValue == "True")
				subStrValue = "False";
			else if (subStrValue.ToLower() == "true")
				subStrValue = "false";

			return subStrValue;
		}

		private string ToZero(string str)
		{
			string subStrValue = str.Substring(str.IndexOf('=') + 1);

			byte check = 1;
			foreach (char c in subStrValue)
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

		private async Task SearchFiles(string path)
		{
			try
			{
				foreach (string dir in Directory.GetDirectories(path))
				{
					foreach (string file in Directory.GetFiles(dir, "*Engine.ini", SearchOption.TopDirectoryOnly))
					{
						filesList.Add(file);
					}
					await SearchFiles(dir);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка доступа!", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}