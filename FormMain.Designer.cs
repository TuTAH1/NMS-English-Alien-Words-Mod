
namespace No_Mans_Sky_words_untranslator
{
	partial class FormMain
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.labelEngilshFilePath = new System.Windows.Forms.Label();
			this.btnBrowseInputFolder = new System.Windows.Forms.Button();
			this.btnCreateFiles = new System.Windows.Forms.Button();
			this.btnDebugClear = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.labelOutputFile = new System.Windows.Forms.Label();
			this.btnBrowseOutputFilePath = new System.Windows.Forms.Button();
			this.tbOutputFolderPath = new System.Windows.Forms.TextBox();
			this.tbInputFolderPath = new System.Windows.Forms.TextBox();
			this.labelMBINCPath = new System.Windows.Forms.Label();
			this.tbMBINCPath = new System.Windows.Forms.TextBox();
			this.btnMBINCPath = new System.Windows.Forms.Button();
			this.lbProgressStatus = new System.Windows.Forms.Label();
			this.btnUnpack = new System.Windows.Forms.Button();
			this.debugField = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// labelEngilshFilePath
			// 
			this.labelEngilshFilePath.AutoSize = true;
			this.labelEngilshFilePath.Location = new System.Drawing.Point(14, 85);
			this.labelEngilshFilePath.Name = "labelEngilshFilePath";
			this.labelEngilshFilePath.Size = new System.Drawing.Size(130, 20);
			this.labelEngilshFilePath.TabIndex = 0;
			this.labelEngilshFilePath.Text = "Original files path";
			// 
			// btnBrowseInputFolder
			// 
			this.btnBrowseInputFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowseInputFolder.AutoSize = true;
			this.btnBrowseInputFolder.Location = new System.Drawing.Point(681, 77);
			this.btnBrowseInputFolder.Name = "btnBrowseInputFolder";
			this.btnBrowseInputFolder.Size = new System.Drawing.Size(78, 35);
			this.btnBrowseInputFolder.TabIndex = 2;
			this.btnBrowseInputFolder.Text = "Browse";
			this.btnBrowseInputFolder.UseVisualStyleBackColor = true;
			this.btnBrowseInputFolder.Click += new System.EventHandler(this.btnBrowseInputFolder_Click);
			// 
			// btnCreateFiles
			// 
			this.btnCreateFiles.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCreateFiles.Location = new System.Drawing.Point(12, 12);
			this.btnCreateFiles.Name = "btnCreateFiles";
			this.btnCreateFiles.Size = new System.Drawing.Size(530, 55);
			this.btnCreateFiles.TabIndex = 3;
			this.btnCreateFiles.Text = "Create localisation files";
			this.btnCreateFiles.UseVisualStyleBackColor = true;
			this.btnCreateFiles.Click += new System.EventHandler(this.btnCreateFiles_Click);
			// 
			// btnDebugClear
			// 
			this.btnDebugClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDebugClear.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.btnDebugClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnDebugClear.Location = new System.Drawing.Point(16, 574);
			this.btnDebugClear.Name = "btnDebugClear";
			this.btnDebugClear.Size = new System.Drawing.Size(742, 35);
			this.btnDebugClear.TabIndex = 5;
			this.btnDebugClear.Text = "Clear Debug";
			this.btnDebugClear.UseVisualStyleBackColor = false;
			this.btnDebugClear.Click += new System.EventHandler(this.btnDebugClear_Click);
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.progressBar.ForeColor = System.Drawing.Color.DodgerBlue;
			this.progressBar.Location = new System.Drawing.Point(16, 214);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(741, 25);
			this.progressBar.Step = 1;
			this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar.TabIndex = 6;
			this.progressBar.Visible = false;
			this.progressBar.VisibleChanged += new System.EventHandler(this.progressBar_VisibleChanged);
			// 
			// labelOutputFile
			// 
			this.labelOutputFile.AutoSize = true;
			this.labelOutputFile.Location = new System.Drawing.Point(12, 120);
			this.labelOutputFile.Name = "labelOutputFile";
			this.labelOutputFile.Size = new System.Drawing.Size(138, 20);
			this.labelOutputFile.TabIndex = 8;
			this.labelOutputFile.Text = "Output folder path";
			// 
			// btnBrowseOutputFilePath
			// 
			this.btnBrowseOutputFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowseOutputFilePath.AutoSize = true;
			this.btnBrowseOutputFilePath.Location = new System.Drawing.Point(681, 115);
			this.btnBrowseOutputFilePath.Name = "btnBrowseOutputFilePath";
			this.btnBrowseOutputFilePath.Size = new System.Drawing.Size(78, 35);
			this.btnBrowseOutputFilePath.TabIndex = 10;
			this.btnBrowseOutputFilePath.Text = "Browse";
			this.btnBrowseOutputFilePath.UseVisualStyleBackColor = true;
			this.btnBrowseOutputFilePath.Click += new System.EventHandler(this.btnBrowseOutputFolderPath_Click);
			// 
			// tbOutputFolderPath
			// 
			this.tbOutputFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutputFolderPath.Location = new System.Drawing.Point(160, 117);
			this.tbOutputFolderPath.Name = "tbOutputFolderPath";
			this.tbOutputFolderPath.Size = new System.Drawing.Size(518, 26);
			this.tbOutputFolderPath.TabIndex = 9;
			this.tbOutputFolderPath.TextChanged += new System.EventHandler(this.tbOutputFilePath_TextChanged);
			// 
			// tbInputFolderPath
			// 
			this.tbInputFolderPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbInputFolderPath.Location = new System.Drawing.Point(160, 78);
			this.tbInputFolderPath.Name = "tbInputFolderPath";
			this.tbInputFolderPath.Size = new System.Drawing.Size(518, 26);
			this.tbInputFolderPath.TabIndex = 1;
			this.tbInputFolderPath.TextChanged += new System.EventHandler(this.tbInputFolderPath_TextChanged);
			// 
			// labelMBINCPath
			// 
			this.labelMBINCPath.AutoSize = true;
			this.labelMBINCPath.Location = new System.Drawing.Point(12, 162);
			this.labelMBINCPath.Name = "labelMBINCPath";
			this.labelMBINCPath.Size = new System.Drawing.Size(151, 20);
			this.labelMBINCPath.TabIndex = 8;
			this.labelMBINCPath.Text = "MBIN Compiler path";
			// 
			// tbMBINCPath
			// 
			this.tbMBINCPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbMBINCPath.Location = new System.Drawing.Point(160, 158);
			this.tbMBINCPath.Name = "tbMBINCPath";
			this.tbMBINCPath.Size = new System.Drawing.Size(518, 26);
			this.tbMBINCPath.TabIndex = 11;
			this.tbMBINCPath.TextChanged += new System.EventHandler(this.ybMBINCPath_TextChanged);
			// 
			// btnMBINCPath
			// 
			this.btnMBINCPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMBINCPath.AutoSize = true;
			this.btnMBINCPath.Location = new System.Drawing.Point(681, 155);
			this.btnMBINCPath.Name = "btnMBINCPath";
			this.btnMBINCPath.Size = new System.Drawing.Size(78, 35);
			this.btnMBINCPath.TabIndex = 12;
			this.btnMBINCPath.Text = "Browse";
			this.btnMBINCPath.UseVisualStyleBackColor = true;
			this.btnMBINCPath.Click += new System.EventHandler(this.btnMBINCPath_Click);
			// 
			// lbProgressStatus
			// 
			this.lbProgressStatus.BackColor = System.Drawing.Color.Transparent;
			this.lbProgressStatus.Location = new System.Drawing.Point(16, 191);
			this.lbProgressStatus.Name = "lbProgressStatus";
			this.lbProgressStatus.Size = new System.Drawing.Size(742, 20);
			this.lbProgressStatus.TabIndex = 13;
			this.lbProgressStatus.Text = "Progress Status";
			this.lbProgressStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.lbProgressStatus.Visible = false;
			// 
			// btnUnpack
			// 
			this.btnUnpack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnUnpack.BackColor = System.Drawing.SystemColors.Control;
			this.btnUnpack.Location = new System.Drawing.Point(548, 12);
			this.btnUnpack.Name = "btnUnpack";
			this.btnUnpack.Size = new System.Drawing.Size(210, 55);
			this.btnUnpack.TabIndex = 14;
			this.btnUnpack.Text = "Unpack";
			this.btnUnpack.UseVisualStyleBackColor = true;
			this.btnUnpack.Click += new System.EventHandler(this.btnUnpack_Click);
			// 
			// debugField
			// 
			this.debugField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.debugField.BackColor = System.Drawing.Color.Black;
			this.debugField.ForeColor = System.Drawing.Color.Gray;
			this.debugField.Location = new System.Drawing.Point(16, 246);
			this.debugField.Name = "debugField";
			this.debugField.ReadOnly = true;
			this.debugField.Size = new System.Drawing.Size(742, 322);
			this.debugField.TabIndex = 15;
			this.debugField.Text = "";
			this.debugField.WordWrap = false;
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(771, 622);
			this.Controls.Add(this.debugField);
			this.Controls.Add(this.btnUnpack);
			this.Controls.Add(this.lbProgressStatus);
			this.Controls.Add(this.btnMBINCPath);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.tbMBINCPath);
			this.Controls.Add(this.btnBrowseOutputFilePath);
			this.Controls.Add(this.tbOutputFolderPath);
			this.Controls.Add(this.labelMBINCPath);
			this.Controls.Add(this.labelOutputFile);
			this.Controls.Add(this.btnDebugClear);
			this.Controls.Add(this.btnCreateFiles);
			this.Controls.Add(this.btnBrowseInputFolder);
			this.Controls.Add(this.tbInputFolderPath);
			this.Controls.Add(this.labelEngilshFilePath);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormMain";
			this.Text = "English Alien Words mod maker";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelEngilshFilePath;
		private System.Windows.Forms.Button btnBrowseInputFolder;
		private System.Windows.Forms.Button btnCreateFiles;
		private System.Windows.Forms.Button btnDebugClear;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label labelOutputFile;
		private System.Windows.Forms.Button btnBrowseOutputFilePath;
		private System.Windows.Forms.TextBox tbOutputFolderPath;
		private System.Windows.Forms.TextBox tbInputFolderPath;
		private System.Windows.Forms.Label labelMBINCPath;
		private System.Windows.Forms.TextBox tbMBINCPath;
		private System.Windows.Forms.Button btnMBINCPath;
		private System.Windows.Forms.Label lbProgressStatus;
		private System.Windows.Forms.Button btnUnpack;
		private System.Windows.Forms.RichTextBox debugField;
	}
}

