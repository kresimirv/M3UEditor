using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;

namespace M3UEditor
{
	/// <summary>
	/// MainForm class
	/// </summary>
	public partial class frmMain : Form
	{
		#region Data Members & Constructor
		
		private MainModel mainModel = null;
		private string appTitle = string.Empty;
		private bool urlCheckRunning = false;
		
		//input control group visibility enum
		private enum InputControlsDiplay 
		{
			Disabled = 0,
			Enabled = 1
		};
		
		//output control group visibility enum
		private enum OutputControlsDiplay 
		{
			Disabled = 0,
			Enabled = 1,
			PartialyEnabled = 2
		};
		
		public frmMain()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//hide File->Close menu item
			mnuMainMenuFileClose.Enabled = false;
			
			//manipulation controls
			this.EnableInputManipulationControls(InputControlsDiplay.Disabled);
			this.EnableOutputManipulationControls(OutputControlsDiplay.Enabled);
		}

		#endregion
		
		#region Events
		
		void frmMainLoad(object sender, EventArgs e)
		{
			//create main model
			mainModel = new MainModel();
			
			//refresh
			RefreshOutputData();
			
			//save app title
			this.appTitle = this.Text;
			
			//status bar - message
			this.lblStatusBar.Text = String.Format("Ready");
		}
		
		void mnuMainMenuFileOpenClick(object sender, EventArgs e)
		{
			try
			{
				//show open file dialog
				OpenFileDialog ofd = new OpenFileDialog();
				ofd.Filter = "M3U File (*.m3u) | *.m3u";
				if (ofd.ShowDialog() == DialogResult.OK) 
				{
					//clear input grid and data
					this.ClearInputGridAndData();
					
					//clear filter
					this.txtSearchInput.Text = string.Empty;
					
					//parse m3u file	
					M3UParser parser = new M3UParser();
					mainModel.LoadM3UList(parser.ParseFile(ofd.FileName));
					
					//refresh dgvs
					RefreshInputData();
					RefreshOutputData();
					
					//enable manipulation controls
					this.EnableInputManipulationControls(InputControlsDiplay.Enabled);
					this.EnableOutputManipulationControls(OutputControlsDiplay.Enabled);
					mnuMainMenuFileClose.Enabled = true;
					
					//change app title
					this.Text = this.appTitle + string.Format(" [{0}]", ofd.FileName);
					
					//status bar - message
					this.UpdateStatusBar();
				}
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		
		void mnuMainMenuFileExitClick(object sender, EventArgs e)
		{
			//exit app
			Application.Exit();
		}
		
		void mnuMainMenuFileCloseClick(object sender, EventArgs e)
		{
			if(MessageBox.Show("Are you sure you want to close opened M3U list?", "Close confirm", 
			                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				//clear input grid and data
				this.ClearInputGridAndData();
				
				//disable manipulation controls
				this.EnableInputManipulationControls(InputControlsDiplay.Disabled);
				
				//clear filter
				this.txtSearchInput.Text = string.Empty;
				
				//enable File->Close menu item
				mnuMainMenuFileClose.Enabled = false;
				
				//change app title
				this.Text = this.appTitle;
				
				//status bar - message
				this.UpdateStatusBar();
			}
		}
		
		void mnuMainMenuFileExportAsClick(object sender, EventArgs e)
		{
			//if there are no output records
			if(mainModel.TotalOutputRecords == 0)
			{
				MessageBox.Show("Please add at least one channel before exporting!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			
			try
			{
				//show save file dialog
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Filter = "M3U File (*.m3u) | *.m3u";
				if (sfd.ShowDialog() == DialogResult.OK) 
				{
					//export M3U list to file
					M3UExporter exporter = new M3UExporter();
					string exportData = exporter.Export(mainModel.ExportRecords);
					
					File.WriteAllText(sfd.FileName, exportData);
				}
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			
		}
		
		void mnuMainMenuFileSettingsClick(object sender, EventArgs e)
		{
			//show Settings form
			frmSettings f = new frmSettings();
			f.ShowDialog();
		}
		
		void txtSearchInputTextChanged(object sender, EventArgs e)
		{
			try
			{
				//if no input records
				if(mainModel.TotalInputRecords == 0)
				{
					return;
				}
				
				//filter records
				string entered = this.txtSearchInput.Text.Trim();
				mainModel.FilterInput(entered);
				this.RefreshInputData();
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		
		void txtSearchOutputTextChanged(object sender, EventArgs e)
		{
			//get entered filter text
			string entered = this.txtSearchOutput.Text.Trim();
			if(entered == string.Empty) //filter active
			{
				//enable all output controls
				this.EnableOutputManipulationControls(OutputControlsDiplay.Enabled);
			}
			else //filter active
			{
				//enable part of output controls
				this.EnableOutputManipulationControls(OutputControlsDiplay.PartialyEnabled);
			}
			
			//refresh
			this.RefreshOutputData();
		}
		
		void btnAddRecordClick(object sender, EventArgs e)
		{
			//get first selected item index
			int firstSelected = -1;
			if(dgvInputRecords.SelectedCells.Count > 0)
			{
				firstSelected = dgvInputRecords.SelectedRows[0].Index;
			}
			
			//add all selected records to output
			foreach (DataGridViewRow r in dgvInputRecords.SelectedRows)
			{
				M3URecord rec = ((M3URecord)r.DataBoundItem).Clone();
				mainModel.AddOutputRecord(rec);
			}
			
			//reorder and refresh
			mainModel.ReorderOutput();
			this.RefreshOutputData();
			
			//select next row (input)
			this.DGVSelectRowAndCenter(dgvInputRecords, firstSelected + 1);
			
			//select last row (output)
			this.DGVSelectRowAndCenter(dgvOutputRecords, dgvOutputRecords.Rows.Count - 1);
			
			//status bar - message
			this.UpdateStatusBar();
		}
		
		void btnAddAllRecordsClick(object sender, EventArgs e)
		{
			try
			{
				this.Cursor = Cursors.WaitCursor; //change cursor
				
				//add all input records to output list
				mainModel.AddAllInputRecordsToOutput();
				
				//refresh
				this.RefreshOutputData();
				
				//select last row
				this.DGVSelectRowAndCenter(dgvOutputRecords, dgvOutputRecords.Rows.Count - 1);
				
				//status bar - message
				this.UpdateStatusBar();
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			finally
			{
				this.Cursor = Cursors.Default; //change cursor
			}
		}
		
		void btnRemoveRecordsClick(object sender, EventArgs e)
		{
			//get first selected row index
			int firstSelected = -1;
			if(dgvOutputRecords.SelectedRows.Count > 0)
			{
				firstSelected = dgvOutputRecords.SelectedRows[0].Index;
			}
			
			//for each selected - remove it
			foreach (DataGridViewRow r in dgvOutputRecords.SelectedRows)
			{
				M3URecord rec = (M3URecord)r.DataBoundItem;
				mainModel.RemoveOutputRecord(rec);
			}
			
			//reorder and refresh
			mainModel.ReorderOutput();
			this.RefreshOutputData();
			
			//select row in place of deleted
			this.DGVSelectRowAndCenter(dgvOutputRecords, firstSelected);
			
			//status bar - message
			this.UpdateStatusBar();
		}
		
		void btnRemoveAllRecordsClick(object sender, EventArgs e)
		{
			try
			{
				if(mainModel.TotalOutputRecords == 0)
				{
					return;
				}
				
				if(MessageBox.Show("Are you sure you want to remove all output channels?", "Remove confirm", 
				                   MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					this.Cursor = Cursors.WaitCursor; //change cursor
					
					//remove all output records
					mainModel.RemoveAllOutputRecords();
					
					//refresh
					this.RefreshOutputData();
					
					//status bar - message
					this.UpdateStatusBar();
				}
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			finally
			{
				this.Cursor = Cursors.Default; //change cursor
			}
		}
		
		void btnNewRecordClick(object sender, EventArgs e)
		{
			//add new record
			mainModel.NewOutputRecord();
			
			//refresh data
			this.RefreshOutputData();
			
			//select last row
			this.DGVSelectRowAndCenter(dgvOutputRecords, dgvOutputRecords.Rows.Count - 1);	
			
			//status bar - message
			this.UpdateStatusBar();
		}
		
		void btnMoveUpRecordClick(object sender, EventArgs e)
		{
			//if records exists
			if(dgvOutputRecords.SelectedRows.Count > 0  && mainModel.TotalOutputRecords == mainModel.TotalOutputFilteredRecords)
			{
				//get index of first selected record
				int index = dgvOutputRecords.SelectedRows[0].Index;
				
				DataGridViewRow r = dgvOutputRecords.SelectedRows[0];
				M3URecord rec = (M3URecord)r.DataBoundItem;

				if(mainModel.MoveUpOutputRecord(rec, index))
				{
					//reorder & refresh data
					mainModel.ReorderOutput();
					this.RefreshOutputData();
					
					//select moved row
					this.DGVSelectRowAndCenter(dgvOutputRecords, index - 1);
				}
				
			}
		}
		
		void btnMoveDownRecordClick(object sender, EventArgs e)
		{
			//if records exists
			if(dgvOutputRecords.SelectedRows.Count > 0  && mainModel.TotalOutputRecords == mainModel.TotalOutputFilteredRecords)
			{
				//get index of first selected record
				int index = dgvOutputRecords.SelectedRows[0].Index;
				
				DataGridViewRow r = dgvOutputRecords.SelectedRows[0];
				M3URecord rec = (M3URecord)r.DataBoundItem;
				if(mainModel.MoveDownOutputRecord(rec, index))
				{
					//reorder & refresh data
					mainModel.ReorderOutput();
					this.RefreshOutputData();
					
					//select moved row
					this.DGVSelectRowAndCenter(dgvOutputRecords, index + 1);
				}
				
			}
		}
		
		void dgvInputRecordsCellClick(object sender, DataGridViewCellEventArgs e)
		{
			//detect VLC button click
			if (e.ColumnIndex == this.dgvInputRecords.Columns["VLC"].Index)
		    {
				DataGridViewRow r = dgvInputRecords.Rows[e.RowIndex];
				M3URecord rec = (M3URecord)r.DataBoundItem;
				
				if(rec != null)
				{
					//lunch vlc
					if(rec.URL != string.Empty)
					{
						VLCIntegration vlc = new VLCIntegration();
						bool success = vlc.OpenWebURL(rec.URL);
						if(success == false)
						{
							MessageBox.Show("Unable to lunch VLC player, check your Settings!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
				}
		    }
		}
		
		void dgvOutputRecordsCellClick(object sender, DataGridViewCellEventArgs e)
		{
			//detect VLC button click
			if (e.ColumnIndex == this.dgvOutputRecords.Columns["VLC"].Index)
		    {
				DataGridViewRow r = dgvOutputRecords.Rows[e.RowIndex];
				M3URecord rec = (M3URecord)r.DataBoundItem;
				
				if(rec != null)
				{
					//lunch vlc
					if(rec.URL != string.Empty)
					{
						VLCIntegration vlc = new VLCIntegration();
						bool success = vlc.OpenWebURL(rec.URL);
						if(success == false)
						{
							MessageBox.Show("Unable to lunch VLC player, check your Settings!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
				}
		    }
		}
		
		async void btnbtnCheckRecordsURLsClick(object sender, EventArgs e)
		{
			try
			{
				//prevent multiple run at same time
				if(this.urlCheckRunning == true)
				{
					return;
				}
				
				//set isRunning flag
				this.urlCheckRunning = true;
				
				//status bar - message
				this.UpdateStatusBar();
				
				//run URL check async and wait to finish
				await Task.Run(() => mainModel.CheckOutputListURLs());
				
				//get index of first selected record
				int index = -1;
				if(dgvOutputRecords.SelectedRows.Count > 0)
				{
					index = dgvOutputRecords.SelectedRows[0].Index;
				}
				
				//refresh
				this.RefreshOutputData();
				
				//select previously selected row
				if(index >= 0)
				{
					this.DGVSelectRowAndCenter(this.dgvOutputRecords, index);
				}
				
				
				//set isRunning flag - false
				this.urlCheckRunning = false;
				
				//status bar - message
				this.UpdateStatusBar();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		
		#endregion
		
		#region Methods
		
		/// <summary>
		/// Clear input dgv and data
		/// </summary>
		void ClearInputGridAndData()
		{
			//clear input list
			mainModel.RemoveAllInputRecords();
			
			//clear dgv
			this.dgvInputRecords.DataSource = null;
			for(int i = 0; i < this.dgvInputRecords.Columns.Count; i++) // clear all extra columns in dgv
			{
				this.dgvInputRecords.Columns.Remove(this.dgvInputRecords.Columns[i]);
			}
		}
		
		/// <summary>
		/// Refresh input data
		/// </summary>
		void RefreshInputData() 
		{
			try
			{
				//set dgv datasource, columns, widths
				this.SetDGVColumnsSourceAndWidth(this.dgvInputRecords, mainModel.InputFilteredRecords);
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		
		/// <summary>
		/// Refresh output data
		/// </summary>
		void RefreshOutputData() 
		{
			try
			{
				//filter records
				string entered = this.txtSearchOutput.Text.Trim();
				mainModel.FilterOutput(entered);
				
				//set dgv datasource, columns, widths
				this.SetDGVColumnsSourceAndWidth(this.dgvOutputRecords, mainModel.OutputFilteredRecords);
				
				//change row color based on URLValid status
				for(int i = 0; i < this.dgvOutputRecords.Rows.Count; i++)
				{
					DataGridViewRow row = this.dgvOutputRecords.Rows[i];
					M3URecord rec = (M3URecord)row.DataBoundItem;
					
					if(rec != null)
					{
						if(rec.URLValid == false)
						{
							row.DefaultCellStyle.BackColor = Color.Coral;
						}
						else
						{
							row.DefaultCellStyle.BackColor = Color.White;
						}
					}
				}
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		
		/// <summary>
		/// Enable/disable input control group
		/// </summary>
		/// <param name="dislayStatus"></param>
		void EnableInputManipulationControls(InputControlsDiplay dislayStatus) 
		{
			if(dislayStatus == InputControlsDiplay.Enabled) //enable
			{
				this.lblSearchInput.Enabled = true;
				this.txtSearchInput.Enabled = true;
				this.btnAddRecord.Enabled = true;
				this.btnAddAllRecords.Enabled = true;
			}
			else if(dislayStatus == InputControlsDiplay.Disabled) //disable
			{
				this.lblSearchInput.Enabled = false;
				this.txtSearchInput.Enabled = false;
				this.btnAddRecord.Enabled = false;
				this.btnAddAllRecords.Enabled = false;
				
			}
		}
		
		/// <summary>
		/// Enable/disable output control group
		/// </summary>
		/// <param name="dislayStatus"></param>
		void EnableOutputManipulationControls(OutputControlsDiplay dislayStatus) 
		{
			if(dislayStatus == OutputControlsDiplay.Enabled) //enable
			{
				this.lblSearchOutput.Enabled = true;
				this.txtSearchOutput.Enabled = true;
				this.btnRemoveRecords.Enabled = true;
				this.btnRemoveAllRecords.Enabled = true;
				this.btnNewRecord.Enabled = true;
				this.btnMoveUpRecord.Enabled = true;
				this.btnMoveDownRecord.Enabled = true;
				this.btnCheckRecordsURLs.Enabled = true;
			}
			else if (dislayStatus == OutputControlsDiplay.Disabled) //disable
			{
				this.lblSearchOutput.Enabled = false;
				this.txtSearchOutput.Enabled = false;
				this.btnRemoveRecords.Enabled = false;
				this.btnRemoveAllRecords.Enabled = false;
				this.btnNewRecord.Enabled = false;
				this.btnMoveUpRecord.Enabled = false;
				this.btnMoveDownRecord.Enabled = false;
				this.btnCheckRecordsURLs.Enabled = false;
			}
			else if (dislayStatus == OutputControlsDiplay.PartialyEnabled) //enable only filter & remove
			{
				this.lblSearchOutput.Enabled = true;
				this.txtSearchOutput.Enabled = true;
				this.btnRemoveRecords.Enabled = true;
				this.btnRemoveAllRecords.Enabled = false;
				this.btnNewRecord.Enabled = false;
				this.btnMoveUpRecord.Enabled = false;
				this.btnMoveDownRecord.Enabled = false;
				this.btnCheckRecordsURLs.Enabled = false;
			}
		}
		
		/// <summary>
		/// Set DGV data source, columns and columns width
		/// </summary>
		/// <param name="dgv"></param>
		/// <param name="ds"></param>
		void SetDGVColumnsSourceAndWidth(DataGridView dgv, Object ds)
		{
			//set dgv data source and column widths 
			dgv.DataSource = null;
			for(int i = 0; i < dgv.Columns.Count; i++) // clear all extra columns in dgv
			{
				dgv.Columns.Remove(dgv.Columns[i]);
			}

			dgv.DataSource = ds;
			dgv.Columns["ID"].Visible = false;
			dgv.Columns["URLValid"].Visible = false;
			dgv.Columns["Order"].Width = 50;
			dgv.Columns["Name"].Width = 400;
			dgv.Columns["GroupTitle"].Width = 170;
			dgv.Columns["GroupTitle"].HeaderText = "Group";
			dgv.Columns["Logo"].Width = 150;
			dgv.Columns["URL"].Width = 250;
			
			//add vlc button column
			DataGridViewButtonColumn vlcButtonColumn = new DataGridViewButtonColumn();
			vlcButtonColumn.Name = "VLC";
			vlcButtonColumn.Text = "VLC";
			vlcButtonColumn.HeaderText = "VLC";
			vlcButtonColumn.UseColumnTextForButtonValue = true;
			dgv.Columns.Add(vlcButtonColumn);
			dgv.Columns["VLC"].Width = 80;
			
			//set dgv column resize mode
			dgv.Columns["Order"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["GroupTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			dgv.Columns["Logo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			dgv.Columns["URL"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
		}
		
		/// <summary>
		/// Scroll to center of display DGV's selected row
		/// </summary>
		/// <param name="dgv"></param>
		void DGVSelectionScrollToCenter(Component dgv)
        {
			var dataGridView = dgv as DataGridView;
            int halfWay = (dataGridView.DisplayedRowCount(false) / 2);
            if (dataGridView.FirstDisplayedScrollingRowIndex + halfWay > dataGridView.SelectedRows[0].Index ||
                (dataGridView.FirstDisplayedScrollingRowIndex + dataGridView.DisplayedRowCount(false) - halfWay) <= dataGridView.SelectedRows[0].Index)
            {
                int targetRow = dataGridView.SelectedRows[0].Index;
                targetRow = Math.Max(targetRow-halfWay, 0);
                dataGridView.FirstDisplayedScrollingRowIndex = targetRow;
            }
        }
		
		/// <summary>
		/// Select DGV row and scroll to display center
		/// </summary>
		/// <param name="dgv"></param>
		/// <param name="index"></param>
		void DGVSelectRowAndCenter(Component dgv, int index)
		{
			var dataGridView = dgv as DataGridView;
			
			if(dataGridView.Rows.Count > 0)
			{
				dataGridView.ClearSelection();
				if(dataGridView.Rows.Count - 1 >= index)
				{
					dataGridView.Rows[index].Selected = true;
				}
				else
				{
					dataGridView.Rows[dataGridView.Rows.Count - 1].Selected = true;
				}
				
				this.DGVSelectionScrollToCenter(dataGridView);
			}
		}
		
		/// <summary>
		/// Update status bar message
		/// </summary>
		void UpdateStatusBar()
		{
			//status bar - message
			this.lblStatusBar.Text = String.Format("Input list: {0} channels, Output list: {1} channels", mainModel.TotalInputRecords, mainModel.TotalOutputRecords);
			if(this.urlCheckRunning == true) //url checking message
			{
				this.lblStatusBar.Text += String.Format(", URL check is progress...");
			}
		}
		
		#endregion
		
	}	
}
