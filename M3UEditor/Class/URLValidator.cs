using System;
using System.Net;

namespace M3UEditor
{
	/// <summary>
	/// URLValidator class
	/// </summary>
	public static class URLValidator
	{
		private const int urlCheckTimeout = 5000;
		
		/// <summary>
		/// Check if URL is valid
		/// </summary>
		/// <param name="url">URL (string)</param>
		/// <returns>True if url is valid else false</returns>
		public static bool IsURLActive(string url)
		{
			bool result = false;
			try 
			{
				HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
				request.Method = "HEAD";
				request.Timeout = urlCheckTimeout;
				HttpWebResponse response = (HttpWebResponse)request.GetResponse();
				response.Close();
		        result = true;
			}
			catch(Exception)
			{
			}
			
			return result;
		}
		
	}
}
