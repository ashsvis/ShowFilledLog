/*
 * Created by SharpDevelop.
 * User: Сектор2
 * Date: 07.08.2018
 * Time: 12:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShowFilledLog
{
	/// <summary>
	/// Description of TuningFolderForm.
	/// </summary>
	public partial class TuningFolderForm : Form
	{
		public TuningFolderForm(string folder)
		{
			InitializeComponent();
			lbFolder.Text = folder;
			folderBrowserDialog1.SelectedPath = folder;
		}
		
		void BtnSelectClick(object sender, EventArgs e)
		{
            var mainForm = (MainForm)this.Owner;
            folderBrowserDialog1.SelectedPath = mainForm.WorkPath;
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK)
			{
				lbFolder.Text = folderBrowserDialog1.SelectedPath;
			}
		}
		
		public void UpdateFolder(ref string folder)
		{
			folder = lbFolder.Text;
		}
	}
}
