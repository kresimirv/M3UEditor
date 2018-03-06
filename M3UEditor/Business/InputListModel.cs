using System;
using System.Collections.Generic;

namespace M3UEditor
{
	/// <summary>
	/// Input list model
	/// </summary>
	public class InputListModel
	{
		private List<M3URecord> _records = null;
		private List<M3URecord> _filteredRecords = null;
		
		public List<M3URecord> Records
		{
			get
			{
				return _records;
			}
			set
			{
				this._records = value;
					
			}
		}
		
		public List<M3URecord> FilteredRecords
		{
			get
			{
				return _filteredRecords;
			}
			set
			{
				this._filteredRecords = value;
					
			}
		}
		
		public InputListModel()
		{
		}
	}
}
