using System;
using System.Diagnostics;
using System.IO;

namespace M3UEditor
{
	/// <summary>
	/// VLCIntegration - class for using external VLC Player
	/// </summary>
	public class VLCIntegration
	{
		public VLCIntegration()
		{
		}
		
		/// <summary>
		/// Open VLC player and play video from given URL
		/// </summary>
		/// <param name="url">URL</param>
		/// <returns>If player started - true otherwise false</returns>
		public bool OpenWebURL(string url)
		{
			//check VLC path app setting
			if(AppSettings.Default.VLCFilePath != string.Empty)
			{
				//check if vlc.exe exists
				if(File.Exists(AppSettings.Default.VLCFilePath))
				{
					//run VLC with URL param
					Process vlcProcess = new Process();
		            vlcProcess.StartInfo.FileName = AppSettings.Default.VLCFilePath;
		            vlcProcess.StartInfo.Arguments = url;
		            bool started = vlcProcess.Start();
		            
		            return started;
				}
			}
			return false;
		}
		
		
	}
}
