using System;

namespace M3UEditor
{
	/// <summary>
	/// M3URecord class
	/// </summary>
	public class M3URecord
	{
		public int Order { get; set; }
		public string ID { get; set; }
		public string Name { get; set; }
		public string GroupTitle { get; set; }
		public string Logo { get; set; }
		public string URL  { get; set; }
		public bool URLValid  { get; set; }
		
		public M3URecord()
		{
			this.Order = 0;
			this.ID = string.Empty;
			this.Name = string.Empty;
			this.GroupTitle = string.Empty;
			this.Logo = string.Empty;
			this.URL = string.Empty;
			this.URLValid = true;
		}
		
		public M3URecord Clone()
	    {
			M3URecord rec = new M3URecord();
			rec.ID = this.ID;
			rec.Name = this.Name;
			rec.GroupTitle = this.GroupTitle;
			rec.Logo = this.Logo;
			rec.Order = this.Order;
			rec.URL = this.URL;
			rec.URLValid = this.URLValid;
			
			return rec;
	    }
	}
}
