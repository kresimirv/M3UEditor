using System;
using System.ComponentModel;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace M3UEditor
{
	/// <summary>
	/// M3UParser - class for parsing M3U files
	/// </summary>
	public class M3UParser
	{
		public M3UParser()
		{
		}
		
		/// <summary>
		/// Parse M3U file and return List<M3URecord>
		/// </summary>
		/// <param name="filename">File name</param>
		/// <returns>List<M3URecord></returns>
		public List<M3URecord> ParseFile(string filename) 
		{
			List<M3URecord> result = new List<M3URecord>();
			
			//read file into string list
			string fileContents = File.ReadAllText(filename);
			List<string> rawLines = fileContents.Split('\n').ToList();
			
			//remove unneeded characters
			List<string> lines = new List<string>();
			for(int i = 0; i < rawLines.Count; i++)
			{
				string line = rawLines[i].Replace("\r", "").Replace("\n", "");
				
				if(line != string.Empty)
				{
					lines.Add(line);
				}
			}
			
			// check if file contains items
			if(lines.Count < 3)
			{
				throw new M3UException("File doesnt contain items");
			}
			
			int channelCounter = 1; // channel counter
			
			//first line - header
			if(lines[0].StartsWith(M3UConstants.FILE_HEADER, StringComparison.InvariantCultureIgnoreCase)) {
			
				// go through each line
				for(int i = 1; i < lines.Count; i++) 
				{
					//if line is heading info
					if(lines[i].StartsWith(M3UConstants.LINE_HEADING, StringComparison.InvariantCultureIgnoreCase))
					{
						//if end of file is not reached
						if((i+1) <= (lines.Count - 1))
						{
							//if line heading - skip
							if(lines[i+1].StartsWith(M3UConstants.LINE_HEADING, StringComparison.InvariantCultureIgnoreCase))
							{
								continue;
							}
							//if line is url - process
							else if(lines[i+1].StartsWith("http", StringComparison.InvariantCultureIgnoreCase))
							{
								string heading = lines[i];
								string url = lines[i+1];
								
								//process heading & url
								M3URecord rec = ProcessHeadingAndURL(heading, url);
								rec.Order = channelCounter;
								channelCounter++;
								result.Add(rec);
								
								// Debug.WriteLine(lines[i]);
								// Debug.WriteLine(lines[i+1]);
							}
							else //if line is unknown - skip
							{
								continue;
							}
						}
					}
					else //if not heading - skip
					{
						continue;
					}
				}
				
			}
			else //if invalid header
			{
				throw new M3UException("Invalid Header");
			}
			
			return result;
		}
		
		/// <summary>
		/// Process heading and url strings and return M3URecord object
		/// </summary>
		/// <param name="heading">Heading string</param>
		/// <param name="url">URL string</param>
		/// <returns>M3URecord</returns>
		public M3URecord ProcessHeadingAndURL(string heading, string url) 
		{
			//extract info
			MatchCollection idMatches = Regex.Matches(heading, "tvg-ID=\"([^\"]*)\"");
			MatchCollection nameMatches = Regex.Matches(heading, "tvg-name=\"([^\"]*)\"");
			MatchCollection groupTitleMatches = Regex.Matches(heading, "group-title=\"([^\"]*)\"");
			MatchCollection logoMatches = Regex.Matches(heading, "tvg-logo=\"([^\"]*)\"");
			
			//create M3URecord
			M3URecord rec = new M3URecord();
			// parse it as plain
			if(idMatches.Count == 0 && nameMatches.Count == 0 && groupTitleMatches.Count == 0)
			{
				rec.Name = heading.Replace(M3UConstants.LINE_HEADING, "").Replace(",", "").Trim();
			}
			else //parse it as extended
			{
				if(idMatches.Count >= 1)
				{
					rec.ID = idMatches[0].Value.ToString().Replace("tvg-ID=", "").Replace("\"", "").Trim();
				}
				if(nameMatches.Count >= 1)
				{
					rec.Name = nameMatches[0].Value.ToString().Replace("tvg-name=", "").Replace("\"", "").Trim();
				}
				if(groupTitleMatches.Count >= 1)
				{
					rec.GroupTitle = groupTitleMatches[0].Value.ToString().Replace("group-title=", "").Replace("\"", "").Trim();
				}
				if(logoMatches.Count >= 1)
				{
					rec.Logo = logoMatches[0].Value.ToString().Replace("tvg-logo=", "").Replace("\"", "").Trim();
				}
			}
			rec.URL = url;
			
			return rec;
		}
	
		
	}
}
