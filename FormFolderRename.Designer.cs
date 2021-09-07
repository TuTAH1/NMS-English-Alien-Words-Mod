
namespace No_Mans_Sky_words_untranslator
{
	partial class FormFolderRename
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFolderRename));
			this.t = new System.Windows.Forms.RichTextBox();
			this.btnYes = new System.Windows.Forms.Button();
			this.btnNo = new System.Windows.Forms.Button();
			this.layout = new System.Windows.Forms.TableLayoutPanel();
			this.panelYesNo = new System.Windows.Forms.Panel();
			this.layout.SuspendLayout();
			this.panelYesNo.SuspendLayout();
			this.SuspendLayout();
			// 
			// t
			// 
			this.t.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.t.BackColor = System.Drawing.Color.Black;
			this.t.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.t.DetectUrls = false;
			this.t.ForeColor = System.Drawing.Color.White;
			this.t.Location = new System.Drawing.Point(0, 107);
			this.t.Margin = new System.Windows.Forms.Padding(0);
			this.t.MaxLength = 500;
			this.t.Name = "t";
			this.t.ReadOnly = true;
			this.t.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
			this.t.Size = new System.Drawing.Size(1088, 28);
			this.t.TabIndex = 0;
			this.t.Text = "Здесь могла бы быть ваша реклама (placeholder)";
			// 
			// btnYes
			// 
			this.btnYes.AutoSize = true;
			this.btnYes.BackColor = System.Drawing.Color.White;
			this.btnYes.Dock = System.Windows.Forms.DockStyle.Left;
			this.btnYes.Location = new System.Drawing.Point(0, 0);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new System.Drawing.Size(90, 43);
			this.btnYes.TabIndex = 1;
			this.btnYes.Text = "Yes";
			this.btnYes.UseVisualStyleBackColor = false;
			this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
			// 
			// btnNo
			// 
			this.btnNo.AutoSize = true;
			this.btnNo.BackColor = System.Drawing.Color.White;
			this.btnNo.Dock = System.Windows.Forms.DockStyle.Right;
			this.btnNo.Location = new System.Drawing.Point(188, 0);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(90, 43);
			this.btnNo.TabIndex = 2;
			this.btnNo.Text = "No";
			this.btnNo.UseVisualStyleBackColor = false;
			this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
			// 
			// layout
			// 
			this.layout.AutoSize = true;
			this.layout.BackColor = System.Drawing.Color.Black;
			this.layout.ColumnCount = 1;
			this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.layout.Controls.Add(this.panelYesNo, 0, 1);
			this.layout.Controls.Add(this.t, 0, 0);
			this.layout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.layout.Location = new System.Drawing.Point(0, 0);
			this.layout.Name = "layout";
			this.layout.RowCount = 2;
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.16151F));
			this.layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.83849F));
			this.layout.Size = new System.Drawing.Size(1088, 291);
			this.layout.TabIndex = 3;
			// 
			// panelYesNo
			// 
			this.panelYesNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.panelYesNo.Controls.Add(this.btnYes);
			this.panelYesNo.Controls.Add(this.btnNo);
			this.panelYesNo.Location = new System.Drawing.Point(405, 245);
			this.panelYesNo.Name = "panelYesNo";
			this.panelYesNo.Size = new System.Drawing.Size(278, 43);
			this.panelYesNo.TabIndex = 4;
			// 
			// FormFolderRename
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1088, 291);
			this.Controls.Add(this.layout);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "FormFolderRename";
			this.Text = "Create folders?";
			this.layout.ResumeLayout(false);
			this.panelYesNo.ResumeLayout(false);
			this.panelYesNo.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RichTextBox t;
		private System.Windows.Forms.Button btnYes;
		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.TableLayoutPanel layout;
		private System.Windows.Forms.Panel panelYesNo;
	}
}