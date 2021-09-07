using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace No_Mans_Sky_words_untranslator
{
	public partial class FormFolderRename : Form
	{
		public FormFolderRename(string path, int folderIndex, Color? selectedTextColor = null, Color? textColor = null, Color? backgroundColor = null)
		{
			if(selectedTextColor == null) selectedTextColor = Color.Orange;
			if(textColor == null) textColor = Color.White;
			if(backgroundColor == null) backgroundColor = Color.Black;


			InitializeComponent();
			int lineHeight = t.GetLineHeight();

			t.BackColor = (Color)backgroundColor;
			t.ForeColor = (Color)textColor;
			string rtbText = "\nSome folders in path are not exist. Create them?\n";
			t.Text =rtbText + path;
			t.Select(37,6);
			t.SelectionColor = (Color)selectedTextColor;
			{
				int start = folderIndex + rtbText.Length, length = t.TextLength - start;
				t.Select(start, length);
				t.SelectionColor = (Color)selectedTextColor;
			}

			t.Select(0,t.TextLength);
			t.SelectionAlignment = HorizontalAlignment.Center;
			
			t.Center(lineHeight);
			t.Select(0,0);
			this.Select();

		}

		private void btnYes_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Yes;
			this.Close();
		}

		private void btnNo_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.No;
			this.Close();
		}
	}

	public static class Func
	{
		public static int GetLineHeight(this RichTextBox rtb)
		{
			var originalText = rtb.Text;
			rtb.Text = "0\n1";
			var y1 = rtb.GetPositionFromCharIndex(0).Y;
			var y2 = rtb.GetPositionFromCharIndex(2).Y;
			rtb.Text = originalText;
			return y2 - y1;
		}

		public static void Center(this RichTextBox rtb, int LineHeight)
		{
			rtb.Height = LineHeight * rtb.Lines.Length;
		}
	}
}
