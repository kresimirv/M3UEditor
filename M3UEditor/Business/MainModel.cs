using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace M3UEditor
{
	/// <summary>
	/// Business class for Main form
	/// </summary>
	public class MainModel
	{
		#region Data Members & Constructor
		
		private InputListModel _inputModel = new InputListModel();
		private OutputListModel _outputModel = new OutputListModel();
		
		public int TotalInputRecords
		{
			get
			{
				if(_inputModel == null || _inputModel.Records == null)
				{
					return 0;
				}
				
				return _inputModel.Records.Count;
			}
		}
		
		public int TotalOutputRecords
		{
			get
			{
				if(_outputModel == null || _outputModel.Records == null)
				{
					return 0;
				}
				
				return _outputModel.Records.Count;
			}
		}
		
		public List<M3URecord> InputFilteredRecords
		{
			get
			{
				return _inputModel.FilteredRecords;
			}
		}
		
		public int TotalOutputFilteredRecords
		{
			get
			{
				return _outputModel.FilteredRecords.Count;
			}
		}
		
		public BindingList<M3URecord> OutputFilteredRecords
		{
			get
			{
				return _outputModel.FilteredRecords;
			}
		}
		
		public List<M3URecord> ExportRecords
		{
			get
			{
				return _outputModel.Records.ToList();
			}
		}
		
		public MainModel()
		{
			//create empty output list if first load
			if(_outputModel.Records == null)
			{
				_outputModel.Records = new BindingList<M3URecord>();
			}
		}
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Create new output record - prefilled
		/// </summary>
		public void NewOutputRecord()
		{
			//add new record
			M3URecord rec = new M3URecord();
			rec.ID = "New channel";
			rec.Order = _outputModel.Records.Count + 1;
			rec.Name = "New channel";
			rec.GroupTitle = "New group";
			rec.Logo = "New logo";
			rec.URL = "http://";
			
			_outputModel.Records.Add(rec);
		}
		
		/// <summary>
		/// Add output record
		/// </summary>
		/// <param name="rec"></param>
		public void AddOutputRecord(M3URecord rec)
		{
			if(rec == null)
			{
				return;
			}
			
			//if no output records
			if(_outputModel.Records == null)
			{
				_outputModel.Records = new BindingList<M3URecord>();
			}
			
			//check if already exists
			if(_outputModel.Records.Any(x => x.URL == rec.URL) == false)
			{
				//add record
				_outputModel.Records.Add(rec);
			}
		}
		
		/// <summary>
		/// Add all input records to output list
		/// </summary>
		public void AddAllInputRecordsToOutput()
		{
			//for each input record add them to output
			foreach (M3URecord r in _inputModel.Records)
			{
				M3URecord rec = r.Clone();
				rec.Order = _outputModel.Records.Count + 1;
				
				//check if already not exists
				if(_outputModel.Records.Any(x => x.URL == rec.URL) == false)
				{
					_outputModel.Records.Add(rec);
				}
				
			}
		}
		
		/// <summary>
		/// Clear input list
		/// </summary>
		public void RemoveAllInputRecords()
		{
			//clear lists
			_inputModel.Records = null;
			_inputModel.FilteredRecords = null;
		}
		
		/// <summary>
		/// Remove output record
		/// </summary>
		/// <param name="rec"></param>
		public void RemoveOutputRecord(M3URecord rec)
		{
			if(rec == null)
			{
				return;
			}
			
			_outputModel.Records.Remove(rec);
		}
		
		/// <summary>
		/// Remove all output records
		/// </summary>
		public void RemoveAllOutputRecords()
		{
			_outputModel.Records = new BindingList<M3URecord>();
		}
		
		/// <summary>
		/// Filter input list
		/// </summary>
		/// <param name="filter">Filter (string)</param>
		public void FilterInput(string filter)
		{
			_inputModel.FilteredRecords = _inputModel.Records.Where(x => x.Order.ToString() == filter || x.Name.ToUpper().Contains(filter.ToUpper()) ||  x.GroupTitle.ToUpper().Contains(filter.ToUpper()) ||  x.Logo.ToUpper().Contains(filter.ToUpper()) || x.URL.ToUpper().Contains(filter.ToUpper()) ).ToList();
		}
		
		/// <summary>
		/// Filter output list
		/// </summary>
		/// <param name="filter">Filter (string)</param>
		public void FilterOutput(string filter)
		{
			_outputModel.FilteredRecords = new BindingList<M3URecord>(_outputModel.Records.Where(x => x.Order.ToString() == filter || x.Name.ToUpper().Contains(filter.ToUpper()) ||  x.GroupTitle.ToUpper().Contains(filter.ToUpper()) ||  x.Logo.ToUpper().Contains(filter.ToUpper()) || x.URL.ToUpper().Contains(filter.ToUpper()) ).ToList());
		}
		
		/// <summary>
		/// Move selected output record up in list - change order
		/// </summary>
		/// <param name="rec">M3URecord object</param>
		/// <param name="index">Current index in list</param>
		/// <returns></returns>
		public bool MoveUpOutputRecord(M3URecord rec, int index)
		{
			bool result = false;
			
			if(rec == null)
			{
				return result;
			}
			
			
			if(rec.Order > 1)
			{
				//remove from list and add on new place in list
				_outputModel.Records.Remove(rec);
				_outputModel.Records.Insert(index - 1, rec);
				result = true;
			}
			
			return result;
		}
		
		/// <summary>
		/// Move selected output record down in list - change order
		/// </summary>
		/// <param name="rec">M3URecord object</param>
		/// <param name="index">Current index in list</param>
		/// <returns></returns>
		public bool MoveDownOutputRecord(M3URecord rec, int index)
		{
			bool result = false;
			
			if(rec == null)
			{
				return result;
			}
			
			if(rec.Order < this.TotalOutputRecords)
				{
					//remove from list and add on new place in list
					_outputModel.Records.Remove(rec);
					_outputModel.Records.Insert(index + 1, rec);
					result = true;
			}
			
			return result;
		}
		
		/// <summary>
		/// Load M3U list
		/// </summary>
		/// <param name="m3uRecords"></param>
		public void LoadM3UList(List<M3URecord> m3uRecords)
		{
			_inputModel.Records = m3uRecords;

			//populate lists
			_inputModel.FilteredRecords = _inputModel.Records;
			_outputModel.FilteredRecords = _outputModel.Records;
		}
		
		/// <summary>
		/// Reorder data in output list (order column)
		/// </summary>
		public void ReorderOutput()
		{
			//change order for each record in output list
			int count = 1;
			foreach(M3URecord rec in _outputModel.Records)
			{
				rec.Order = count;
				count++;
			}
		}
		
		/// <summary>
		/// Check output list records URL validity
		/// </summary>
		public void CheckOutputListURLs()
		{
			//go through all output records
			for(int i = 0; i < _outputModel.Records.Count; i++)
			{
				M3URecord rec = _outputModel.Records[i];
				if(rec != null)
				{
					string url = rec.URL.Trim();
					
					//if invalid url
					if(url == string.Empty)
					{
						rec.URLValid = false;	
						continue;
					}
					
					//if regular url
					//check if url valid
					bool isActive = URLValidator.IsURLActive(rec.URL);
					if(isActive == false)
					{
						rec.URLValid = false;							
					}
					else
					{
						rec.URLValid = true;
					}
				}
			}
		}
		
		#endregion
		
	}
}
