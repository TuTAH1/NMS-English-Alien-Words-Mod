using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Microsoft.WindowsAPICodePack.Dialogs;
using No_Mans_Sky_words_untranslator.Properties;
using static System.Net.WebUtility;
using static No_Mans_Sky_words_untranslator.Funcs;
using Timer = System.Threading.Timer;

//:. "Better comments" plugin reccomended with grey comments color.
//:Tokens:	:	\	!	TODO
//:Colors:	gree red	yell	cyan	
//:Size offset: -1; Italic ☑

//! Tasks:
//! 1. Use AMUMSS to unpack PCBANKS and pack mod.
//! 2. Add "Clear" button that will delete only (inputPath || outputPath)+fileName+lang+(".EXML" || ".MBIN") files
//! 3. Add form for filling global variables below, move global vars to Settings
//! hardly necessary:
//! ~ Replace exceptions with just debug (but in the way to not cause UB)
//! ~ Make CreateLocalisationFilesFast();

namespace No_Mans_Sky_words_untranslator
{
	public partial class FormMain : Form
	{
		private string[] FileNames = new[] { "NMS_LOC1_","NMS_UPDATE3_","NMS_LOC5_"};
		private int[] WordCountApprox = new[] { 1600, 900, 1750 }; //:exactly values are 1545; 844; 1686 
		private string[] FirstWords = new[] { "EXP_CONVERGENCE", "EXP_HOLOTERMINUS", "ATLAS_AFRAID" }; //:"-sof" – start of file
		private string[] LastWords = new[] { "WAR_OPERATIONS", "-eof", "-eof" }; //:"-eof" – end of file

		private string[] LangNames =  new[] { "English", "French", "Italian", "German", "Spanish", "Russian", "Polish", "Dutch", "Portuguese", "LatinAmericanSpanish", "BrazilianPortuguese", "SimplifiedChinese", "TraditionalChinese", "TencentChinese", "Korean", "Japanese", "USEnglish"};
		private string[] ExceptLangLames = new[] {"LatinAmericanSpanish", "USEnglish"};
		// find regex: <Property name="Id" value="(EXP|WAR|TRA|ATLAS)_[A-Z]*" />			←——— in order to find if new update have WORDs
		public FormMain()
		{
			InitializeComponent();
			if (FileNames.Length * WordCountApprox.Length * FirstWords.Length * LastWords.Length != Math.Pow(FileNames.Length, 4))
			{
				throw new ArgumentException($"Programmer error: those 4 arrays  ↑  should be equal");
			}
			tbInputFolderPath.Text = Settings.Default.OriginalFilesPath;
			tbOutputFolderPath.Text = Settings.Default.OutputFolderPath;
			tbMBINCPath.Text = Settings.Default.MBINCompiler_Path;
			btnCreateFiles.Enabled = false;
			AddDebugLine("Programm started",MessageType.Important,false);
			CheckPaths(false, true, false, true,false);
			debugField.SelectionStart = 0;
			debugField.ScrollToCaret();
			debugField.SelectionStart = debugField.TextLength;
			debugField.ScrollToCaret();
		}

		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			debugField.SelectionStart = 0;
			debugField.ScrollToCaret();
			debugField.SelectionStart = debugField.TextLength;
			debugField.ScrollToCaret();
		}


		private void tbInputFolderPath_TextChanged(object sender, EventArgs e)
		{
			Settings.Default.OriginalFilesPath = (sender as TextBox).Text;
			Settings.Default.Save();
			CheckPaths(InputFolder:true);
		}

		private void tbOutputFilePath_TextChanged(object sender, EventArgs e)
		{
			Settings.Default.OutputFolderPath = (sender as TextBox).Text;
			Settings.Default.Save();
			CheckPaths(OutputFolder:true);
		}

		private void ybMBINCPath_TextChanged(object sender, EventArgs e)
		{
			Settings.Default.MBINCompiler_Path = (sender as TextBox).Text;
			Settings.Default.Save();
			CheckPaths(MBINC:true);
		}

		private void btnBrowseInputFolder_Click(object sender, EventArgs e)
		{
			CommonOpenFileDialog dialog = new CommonOpenFileDialog();
			dialog.IsFolderPicker = true;
			if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
			{
				string newPath = dialog.FileName;
				tbInputFolderPath.Text = newPath;
				Settings.Default.OriginalFilesPath = newPath;
				Settings.Default.Save();
				CheckPaths(InputFolder:true);
			}
		}
		private void btnBrowseOutputFolderPath_Click(object sender, EventArgs e)
		{
			CommonOpenFileDialog dialog = new CommonOpenFileDialog();
			dialog.IsFolderPicker = true;
			if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
			{
				string newPath = dialog.FileName;
				tbOutputFolderPath.Text = newPath;
				Settings.Default.OutputFolderPath = newPath;
				Settings.Default.Save();
				CheckPaths(OutputFolder:true);
			}
		}

		private void btnMBINCPath_Click(object sender, EventArgs e)
		{
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "exeCUTEble|*.exe"; 
			if (dialog.ShowDialog() == DialogResult.OK)
			{
				string newPath = dialog.FileName;
				tbMBINCPath.Text = newPath;
				Settings.Default.MBINCompiler_Path = newPath;
				Settings.Default.Save();
				CheckPaths(MBINC:true);
			}
		}

		private void btnCreateFiles_Click(object sender, EventArgs e)
		{
			CreateLocalisationFiles(Settings.Default.OriginalFilesPath,Settings.Default.OutputFolderPath, LangNames);
		}

		private async void btnUnpack_Click(object sender, EventArgs e)
		{
			btnUnpack.Text = "Cancel unpacking";
			await Convert(Settings.Default.OriginalFilesPath,Settings.Default.MBINCompiler_Path, true,LangNames);
		}

		private void btnDebugClear_Click(object sender, EventArgs e)
		{
			debugField.Text = "Debug:";
		}

		//:functions created for forms, but not called by events
		#region Not-event functions

		private void CheckPaths(bool all = false, bool InputFolder = false, bool OutputFolder = false, bool MBINC = false, bool Debug = true)
		{
			if (all) InputFolder = OutputFolder = MBINC = true;

			if (InputFolder)
				if (tbInputFolderPath.Text.Length == 0)
				{
					tbInputFolderPath.BackColor = Color.LightPink;
					btnUnpack.Enabled = false;
				} else { 
					CheckXMLFiles(true);
					tbInputFolderPath.BackColor = Color.White;
					btnUnpack.Enabled = true;
					if (!Settings.Default.OriginalFilesPath.EndsWith("\\"))
						Settings.Default.OriginalFilesPath += "\\";
				}

			if (MBINC)
				if (tbMBINCPath.Text.Length == 0 ||!tbMBINCPath.Text.EndsWith(".exe"))
				{
					btnUnpack.ForeColor = Color.Black;
					tbMBINCPath.BackColor = Color.LightPink;
					btnUnpack.Enabled = false;
				} else {
					tbMBINCPath.BackColor = Color.White;
					btnUnpack.Enabled = true;
					if (tbMBINCPath.Text.EndsWith("MBINCompiler.exe")) //:Lock MBINC path change if it 90% surely valid
					{
						//tbMBINCPath.Enabled = false;
						//btnMBINCPath.Enabled = false;
						tbMBINCPath.BackColor = Color.LightGreen;
					}
				}

			if (OutputFolder)
			{
				if (tbOutputFolderPath.Text.Length == 0) //!triple and double dublication of code, can be refactored
				{
					tbOutputFolderPath.BackColor =  Color.LightPink;
					btnCreateFiles.Enabled = false;
				}
				else
				{
					var path = Settings.Default.OutputFolderPath;
					int lastFolderIndex = Int32.MaxValue;
					while (!Directory.Exists(path))
					{
						lastFolderIndex = path.LastIndexOf("\\");
						if (lastFolderIndex < 0)
						{
							//MessageBox.Show("Output path error: disk not found", "Error", MessageBoxButtons.OK);
							//Settings.Default.OutputFolderPath = "";
							tbOutputFolderPath.BackColor =  Color.LightPink;
							btnCreateFiles.Enabled = false;
							return;
						}
						path = path.Slice(0, lastFolderIndex);
					}

					if (lastFolderIndex == Int32.MaxValue)
					{
						tbOutputFolderPath.BackColor = Color.White;
						if (!Settings.Default.OutputFolderPath.EndsWith("\\"))
							Settings.Default.OutputFolderPath += "\\";
					}
					else
					{
						DialogResult dialog = new FormFolderRename(Settings.Default.OutputFolderPath, lastFolderIndex).ShowDialog();
						if (dialog == DialogResult.Yes)
						{
							Directory.CreateDirectory(Settings.Default.OutputFolderPath);
							tbOutputFolderPath.BackColor = Color.White;
							if (!Settings.Default.OutputFolderPath.EndsWith("\\"))
								Settings.Default.OutputFolderPath += "\\";
						}
						else
						{
							tbOutputFolderPath.BackColor =  Color.LightPink;
							btnCreateFiles.Enabled = false;
						}
					}
				}

			}
		}

		//: Checking for .EXML files are already unpacked
		private void CheckXMLFiles(bool Debug = true)
		{
			bool xmlExist = true;
			foreach (var locFile in FileNames)
			{
				foreach (var lang in LangNames)
				{
					if (ExceptLangLames.Contains(lang)) continue;
					var path = Settings.Default.OriginalFilesPath + locFile + lang.ToUpper() + ".EXML";
					if (!File.Exists(path))
					{
						xmlExist = false;
						if (Debug) AddDebugLine(path+" not found", MessageType.Warning);
					}

				}
			}

			if (xmlExist) Unpacked();
		}

		public void AddDebugLine(string Text, MessageType messageType = MessageType.Default, bool newLine = true)
		{
			debugField.AddLineWithTime(Text, messageType, newLine);
		}

		public void Unpacked()
		{
			btnUnpack.Text = "Unpacked";
			btnUnpack.Enabled = false;
			btnUnpack.BackColor = Color.FromArgb(200,200,200);
			btnUnpack.ForeColor = Color.FromArgb(173, 174, 187);

			btnBrowseInputFolder.Enabled = false;
			tbInputFolderPath.Enabled = false;

			btnMBINCPath.Enabled = false;
			tbMBINCPath.Enabled = false;


			if (tbOutputFolderPath.Text.Length != 0)
			{
				btnCreateFiles.Enabled = true;
			}
			else
			{
				tbOutputFolderPath.BackColor = Color.LightPink;
			}
		}

		#endregion

		//:Functions for this programm
		#region Logic Functions

		public async Task Convert(string FolderPath, string MBINCPath, bool MBIN, string[] LangNames)
		{
			int procCountBeg = Process.GetProcessesByName("MBINCompiler.exe").Length; //:How many MCompilers running before launch
			int procCount = 0;
			string sourceEXT = MBIN ? ".MBIN" : ".EXML";
			string targetEXT = !MBIN ? ".MBIN" : ".EXML";
			bool noErrors = true;
			progressBar.Initialize();
			AddDebugLine($"Launching MBINC for converting {sourceEXT} to {targetEXT}");
			progressBar.Maximum = (FileNames.Length * LangNames.Length+2);
			//:files that can't be unpacked and should be skipped while checking convertion ending
			List<string> exceptionFilesData = new List<string>(LangNames.Length*FileNames.Length);

			foreach (var locFile in FileNames)
			{
				foreach (var lang in LangNames)
				{
					if (ExceptLangLames.Contains(lang)) continue;
					string filePath = FolderPath + locFile + lang.ToUpper() + sourceEXT;
					string filePathQuotes = $"\"{filePath}\"";
					if (File.Exists(FolderPath + locFile + lang.ToUpper() + targetEXT))
					{
						AddDebugLine($"{filePathQuotes} is already unpacked", MessageType.Warning);
						exceptionFilesData.Add(locFile+lang);
						progressBar.Increment(1);
					}
					else
					{
						try
						{
							if (File.Exists(filePath))
							{
								var p = new Process(); //Process.Start();
								p.StartInfo.FileName = Settings.Default.MBINCompiler_Path;
								p.StartInfo.Arguments = "convert -q -y " + filePathQuotes; //:-f for skip errors -Q for no log;
								p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
								p.Start();
								procCount++;
							}
							else
							{
								AddDebugLine($"Can't find file {filePathQuotes}", MessageType.Error);
								exceptionFilesData.Add(locFile+lang);
								progressBar.Increment(1);
								noErrors = false;
							}
						}
						catch (Exception e)
						{
							AddDebugLine($"Exception: {e.Message}", MessageType.Error);
							exceptionFilesData.Add(locFile+lang);
							progressBar.Increment(1);
							noErrors = false;
						}
					}

				}
			}

			progressBar.Increment(2);
			//AddDebugLine("Waiting for converting");

			//foreach (var locFile in FileNames)
			//{
			//	foreach (var lang in LangNames)
			//	{
			//		if (ExceptLangLames.Contains(lang)) continue;
			//		if (exceptionFilesData.Contains(locFile+lang)) continue;
			//		while (!File.Exists(Settings.Default.OriginalFilesPath + "\\"+ locFile + lang+".EXML"))
			//		{
			//			Application.DoEvents();
			//			Thread.Sleep(300); //TODO: Find a better func for pause
			//			//Timer timer = new Timer();
			//		}
					
			//	}
			//}

			AddDebugLine("Waiting for the conversion completion");
			//progressBar.Style = ProgressBarStyle.Marquee;
			while (procCount > procCountBeg)
			{
				Application.DoEvents();
				Thread.Sleep(300); //TODO: Find a better func for pause
				var newProcCount = Process.GetProcessesByName("MBINCompiler").Length - procCountBeg;
				if (newProcCount != procCount)
				{
					progressBar.Increment(procCount-newProcCount);
					procCount = newProcCount;
				}
			}

			AddDebugLine("Conversion done", MessageType.Good);

			progressBar.Visible = false;
			CheckPaths(InputFolder:true);
		}

		public void CreateLocalisationFilesFast(string InputFolderPath, string OutputFolderPath, string[] LangNames)
		{
			//:There's will be optimized but a bit more risky version of {CreateLocalisationFiles()} if needed
		}

		public async void CreateLocalisationFiles(string InputFolderPath, string OutputFolderPath, string[] LangNames)
		{
			progressBar.Initialize();
			string[] acceptedLangNames = new string[LangNames.Length - ExceptLangLames.Length-1];
			{
				int i = 0;
				foreach (var lang in LangNames)
				{
					if (!(ExceptLangLames.Contains(lang) || lang == LangNames[0]))
					{
						acceptedLangNames[i] = lang;
						i++;
					}
				}
			}
			progressBar.Maximum = (int)(acceptedLangNames.Length*FileNames.Length*3);

			for (int f = 0; f < FileNames.Length; f++)//!: that can be done in parrallel mode
			{
				string firstWord = FirstWords[f]; //:in order not to slow down the program by constantly accessing the array
				string lastWord = LastWords[f];
				List<Word> words = new List<Word>(WordCountApprox[f]); //!Word can be simplified to string by not cheking ID. Would cause UB (unlikely) instead of error
				StreamReader fileEnglish = new StreamReader(InputFolderPath + FileNames[f] + LangNames[0].ToUpper() + ".EXML",Encoding.UTF8);
				AddDebugLine("Searching for WORD in English file");

				string lineEnglish = null;
				string WORD;

				if (firstWord != "-sof")
				{
					while (!fileEnglish.EndOfStream)
					{
						lineEnglish = fileEnglish.ReadLine();
						if (lineEnglish.Contains(firstWord)) break;
					}

					string id = firstWord;

					lineEnglish = fileEnglish.ReadLine(); //!error if next line to ID is not an english property
					if (lineEnglish.Contains("<Property name=\"English\"")) //!Code duplication
					{
						lineEnglish = fileEnglish.ReadLine();
						WORD = lineEnglish.Slice("<Property name=\"Value\" value=\"", "\" />");
						words.Add(new Word(id, WORD));
					}
					else
					{
						throw new Exception($"«<Property name=\"English\"» expected after id {id}, but found {lineEnglish}");
					}
				}

				progressBar.Increment(1);
				AddDebugLine("Writting English words in memory");
				while (true)
				{
					lineEnglish = fileEnglish.ReadLine();
					if (lineEnglish == null) 
						if (lastWord == "-eof") break;
						else throw new EndOfStreamException($"English file {FileNames[f]} ended before it should"); //TODO: обработать исключение

					string id = lineEnglish.Slice(" <Property name=\"Id\" value=\"", "\" />");
					if (id != null)
					{
						lineEnglish = fileEnglish.ReadLine();
						if (lineEnglish.Contains("<Property name=\"English\""))
						{
							lineEnglish = fileEnglish.ReadLine();
							WORD = lineEnglish.Slice("<Property name=\"Value\" value=\"", "\" />");
							words.Add(new Word(id, WORD));
							if (id == lastWord) break;
						}
						else
						{
							throw new Exception($"«<Property name=\"English\"» expected after id {id}, but found {lineEnglish}");
						}
					}
				}
				
				fileEnglish.Close(); 

				progressBar.Increment(2);

				StreamReader[] filesLang = new StreamReader[acceptedLangNames.Length];
				StreamWriter[] newFilesLangs = new StreamWriter[acceptedLangNames.Length];
				for (int l = 0; l < acceptedLangNames.Length; l++)
				{
					filesLang[l] = new StreamReader(InputFolderPath + FileNames[f] + acceptedLangNames[l].ToUpper() + ".EXML",Encoding.UTF8); //:Opening original files
					newFilesLangs[l] = new StreamWriter(OutputFolderPath + FileNames[f] + acceptedLangNames[l].ToUpper() + ".EXML",false,Encoding.UTF8); //:Creating mod files
					AddDebugLine($"Searching for WORD in {FileNames[f]+acceptedLangNames[l]} file");

					string line = null;
					if (firstWord != "-sof")
					{
						do //:Copying localisation from original file
						{
							line = filesLang[l].ReadLine();
							if (line == null) throw new EndOfStreamException($"File {FileNames[f]+acceptedLangNames[l]} ended before it should"); //TODO: обработать исключение
							newFilesLangs[l].WriteLine(line);
						} while (!line.Contains(firstWord));
					}

					progressBar.Increment(1);

					AddDebugLine($"Replacing words localisation in {FileNames[f]+acceptedLangNames[l]}");

					string wordID = firstWord;
					bool end = false;
					int w = 0;
					//newFilesLangs[l].Close(); //\ for Debug
					do
					{
						//newFilesLangs[l] = new StreamWriter(OutputFolderPath + FileNames[f] + acceptedLangNames[l].ToUpper() + ".EXML",true,Encoding.UTF8); //\ for Debug
						string id;
						id = line.Slice("<Property name=\"Id\" value=\"", "\" />"); //!loop can be simplified to goind to <Property name="{acceptedLangNames[i]}" line and skipping 53 lines. Will cause UB if languages number changes. UB can be fixed by gathering langnum while reading first TkLocalisationEntry

						if (id != null)
						{
							if (end) break;
							else
							if (id == lastWord) end = true;
							else
							if (id == words[w].ID)
							{
								//newFilesLangs[l].Close(); //\ for Debug
								while (true) //TODO: fix [UB if langname will not be found (unlikely)]
								{
									//newFilesLangs[l] = new StreamWriter(OutputFolderPath + FileNames[f] + acceptedLangNames[l].ToUpper() + ".EXML",true,Encoding.UTF8); //\ for Debug
									line = filesLang[l].ReadLine(); //!can be optimizated by skipping 3 lines. UB improbable.
									if (line.Contains($"<Property name=\"{acceptedLangNames[l]}\""))
									{
										newFilesLangs[l].WriteLine(line);
										filesLang[l].ReadLine();
										newFilesLangs[l].WriteLine($"        <Property name=\"Value\" value=\"{words[w++].value}\" />"); //:Putting English WORD in new localisation file
										break;
									} 
									else newFilesLangs[l].WriteLine(line);
								//	newFilesLangs[l].Close(); //\ for Debug
								}
							}
							else
							{
								throw new Exception($"id {words[w].ID} expected, but {id} found"); //TODO:обработать исключиение
							}
						}

						line = filesLang[l].ReadLine(); //reading next line
						if (line==null)
							if (lastWord == "-eof") break;
							else throw new EndOfStreamException($"ile {FileNames[f] + acceptedLangNames[l] + ".EXML"} ended before it should"); //TODO: обработать исключение
						newFilesLangs[l].WriteLine(line);
					//	newFilesLangs[l].Close(); //\ for Debug

					} while (true);
					progressBar.Increment(1);

					while (line!=null) //:Дозапись
					{
						line = filesLang[l].ReadLine();
						newFilesLangs[l].WriteLine(line);
					}
					filesLang[l].Close();
					newFilesLangs[l].Close();
					progressBar.Increment(1);

				}
			}

			AddDebugLine("Localisation files done",MessageType.Good);
			progressBar.Visible = false;
			AddDebugLine("Converting localisation files to MBIN");

			foreach (var fileName in FileNames) //:deleting .Mbin if it exist just in case
			{
				foreach (var lang in acceptedLangNames)
				{
					var path = OutputFolderPath + fileName + lang + ".MBIN";
					try
					{
						if (File.Exists(path))
						{
							File.Delete(path);
							AddDebugLine($"{path} already exist. It have been deleted", MessageType.Error);
						}
					}
					catch (Exception e)
					{
						AddDebugLine("Error:"+e.Message,MessageType.Error);
					}
				}
			}

			await Convert(OutputFolderPath, Settings.Default.MBINCompiler_Path, false,acceptedLangNames);
			AddDebugLine("Deleting .EXML files");

			foreach (var fileName in FileNames)
			{
				foreach (var lang in LangNames)
				{
					string path = OutputFolderPath + fileName + lang;
					try
					{
						if (File.Exists(path+ ".MBIN"))
							File.Delete(OutputFolderPath + fileName + lang + ".EXML");
						else 
							AddDebugLine($"File {path} haven't been converted", MessageType.Error);
					}
					catch (Exception e)
					{
						AddDebugLine("Error:"+e.Message);
					}
				}
			}

			AddDebugLine(".EXML files deleted");
		}

		private void CheckMbincErrors(bool ShowMessageBox = true) //: Перед запуском mbinc записывать дату-время, а после завершения искать только файлы позже этой даты по паттерну MBINCompiler.*.log
		{
			string mbincFolder = Settings.Default.MBINCompiler_Path.Slice(0, "\\");
			string[] logs = Directory.GetFiles(mbincFolder,"MBINCompiler.*.log");
			foreach (var log in logs)
			{
				StreamReader reader = new StreamReader(log);
				string line, errors = "", errorFilePath = null;
				do
				{
					line = reader.ReadLine();
					if (line.StartsWith("[ARGS]:")&&errorFilePath==null) errorFilePath = line;
					if (line.StartsWith("[ERROR]:"))
					{
						do
						{
							errors += "\n" + line;
							line = reader.ReadLine();
						} while (line!=null && line.StartsWith("["));
					}
				} while (line != null);

				if (errors != "")
				{
					MessageBox.Show($"Convertation of file {errorFilePath} finished with errors: {errors}");
				}
			}
		}

		#endregion

		private void progressBar_VisibleChanged(object sender, EventArgs e)
		{
			lbProgressStatus.Visible = progressBar.Visible;
		}
	}

	public class Word
	{
		public string ID;
		public string value;

		public Word(string id, string value)
		{
			ID = id;
			this.value = value;
		}
	}

	public static class Funcs
	{

		public static string Slice(this string s, string Start, string End)
		{
			var start = s.IndexOfEnd(Start);
			if (start < 0) return null;

			var end =s.LastIndexOf(End);
			if (end < 0) return null;

			if (start > end) throw new ArgumentException($"start ({start}) is be bigger than end ({end})");

			return s.Slice(start, end);
		//\	try { }
		//\	catch {return null;}

		}

		public static string Slice(this string s, int Start, string End)
		{
			var end =s.LastIndexOf(End);
			if (end < 0) return null;

			if (Start > end) throw new ArgumentException($"start ({Start}) is be bigger than end ({end})");

			return s.Slice(Start, end);
			//\	try { }
			//\	catch {return null;}

		}

		public static string Slice(this string s, string Start, int End = Int32.MaxValue)
		{
			var start = s.IndexOfEnd(Start);
			if (start < 0) return null;

			if (start > End) throw new ArgumentException($"start ({start}) is be bigger than end ({End})");

			return s.Slice(start, End);
			//\	try { }
			//\	catch {return null;}

		}

		/// <summary>
		/// Slices the string form Start to End not including End
		/// </summary>
		/// <param name="s"></param>
		/// <param name="Start"></param>
		/// <param name="End"></param>
		/// <returns></returns>
		public static string Slice(this string s, int Start = 0, int End = Int32.MaxValue)
		{
			if (Start < 0) throw new ArgumentOutOfRangeException($"Start is {Start}");
			if (Start > End) throw new ArgumentException($"start ({Start}) is be bigger than end ({End})");
			if (End == Int32.MaxValue) End = s.Length;
			return s.Substring(Start, End - Start);
		}
		/// <summary>
		/// Returns next to end of s2 position
		/// </summary>
		/// <param name="s"></param>
		/// <param name="s2"></param>
		/// <returns></returns>
		public static int IndexOfEnd(this string s, string s2)
		{
			if (s == null) 
			if (s2.Length == 0) return 0;
			int i = s.IndexOf(s2);
			if (i == -1) return -1;
			else return i + s2.Length;
		}

		public static void Initialize(this ProgressBar progressBar)
		{
			progressBar.Visible = true;
			progressBar.Value = 0;
			progressBar.Style = ProgressBarStyle.Blocks;
		}

		public enum MessageType
		{
			Default,
			Warning,
			Error,
			Good,
			Important
		}

		static public void AddLineWithTime(this RichTextBox l, string NewString, MessageType messageType = MessageType.Default, bool newLine = true)
		{
			Color color = Color.White;
			switch (messageType)
			{
				case MessageType.Error:
					color = Color.Red; break;
				case MessageType.Warning:
					color= Color.Yellow; break;
				case MessageType.Good:
					color = Color.Chartreuse; break;
				case MessageType.Important:
					color = Color.FromArgb(198, 115, 255); break;
			}

			var start = l.Text.Length;
			NewString = (newLine?"\n":"") + $"[{DateTime.Now.ToLongTimeString()}] {NewString}";
			l.AppendText(NewString);
			l.Select(start,NewString.Length);
			l.SelectionColor = color;
			l.ScrollToCaret();
		}

		#region General Functions

		static public XElement FirstChild(this XElement e) => e.Elements().First();
		static public XElement LastChild(this XElement e) => e.Elements().Last();

		#endregion
	}

}
