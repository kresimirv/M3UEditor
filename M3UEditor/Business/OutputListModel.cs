using System;
using System.ComponentModel;

namespace M3UEditor
{
	/// <summary>
	/// Output list model
	/// </summary>
	public class OutputListModel
	{
		private BindingList<M3URecord> _records = null;
		private BindingList<M3URecord> _filteredRecords = null;
		
		public BindingList<M3URecord> Records
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
		
		public BindingList<M3URecord> FilteredRecords
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
		
		public OutputListModel()
		{
		}
	}
}
