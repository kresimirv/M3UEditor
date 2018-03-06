using System;
using System.Collections.Generic;
using System.Text;

namespace M3UEditor
{
	/// <summary>
	/// Class for generating M3U list as string
	/// </summary>
	public class M3UExporter
	{
		public M3UExporter()
		{
		}
		
		/// <summary>
		/// Generate M3U list (string) from List<M3URecord>
		/// </summary>
		/// <param name="m3ulist">List of M3URecords</param>
		/// <returns>M3U list (string)</returns>
		public string Export(List<M3URecord> m3ulist)
		{
			string result = string.Empty;
			
			//create header
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(M3UConstants.FILE_HEADER);
			
			//create lines
			foreach(M3URecord item in m3ulist)
			{
				//add header
				sb.AppendLine(string.Format("{0} tvg-ID=\"{1}\" tvg-name=\"{2}\" tvg-logo=\"{3}\" group-title=\"{4}\",{5}", 
				                            M3UConstants.LINE_HEADING, item.Name, item.Name, item.Logo, item.GroupTitle, item.Name));
				
				//add url
				sb.AppendLine(item.URL);
			}
			
			result = sb.ToString();
			return result;
		}
		
		
	}
}
