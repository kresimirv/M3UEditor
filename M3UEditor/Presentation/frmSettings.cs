using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace M3UEditor
{
	/// <summary>
	/// Settings Form class
	/// </summary>
	public partial class frmSettings : Form
	{
		public frmSettings()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void frmSettingsLoad(object sender, EventArgs e)
		{
			//read vlc settings
			if(AppSettings.Default.VLCFilePath != string.Empty)
			{
				// if file doesnt exists
				if(File.Exists(AppSettings.Default.VLCFilePath) == false)
				{
					//reset setting
					AppSettings.Default.VLCFilePath = string.Empty;
					AppSettings.Default.Save();
					this.txtVLCFilePath.Text = string.Empty;
				}
				else //if file exists
				{
					this.txtVLCFilePath.Text = AppSettings.Default.VLCFilePath;
				}
			}
		}
		
		void btnBrowseClick(object sender, EventArgs e)
		{
			//show open file dialog
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "vlc.exe (VLC Player) | vlc.exe";
			if (ofd.ShowDialog() == DialogResult.OK) 
			{
				//save vlc settings
				AppSettings.Default.VLCFilePath = ofd.FileName;
				AppSettings.Default.Save();
				this.txtVLCFilePath.Text = ofd.FileName;
				
			}
		}
		
		void btnOkClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
	}
}
