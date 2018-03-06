namespace M3UEditor
{
	partial class frmMain
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.MenuStrip mnuMainMenu;
		private System.Windows.Forms.ToolStripMenuItem mnuFile;
		private System.Windows.Forms.ToolStripMenuItem mnuMainMenuFileOpen;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem mnuMainMenuFileExit;
		private System.Windows.Forms.DataGridView dgvInputRecords;
		private System.Windows.Forms.SplitContainer scMainSplitContainer;
		private System.Windows.Forms.Panel pnlInput;
		private System.Windows.Forms.TextBox txtSearchInput;
		private System.Windows.Forms.Label lblSearchInput;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btnAddAllRecords;
		private System.Windows.Forms.Button btnAddRecord;
		private System.Windows.Forms.DataGridView dgvOutputRecords;
		private System.Windows.Forms.ToolStripButton btnRemoveAllRecords;
		private System.Windows.Forms.ToolStripButton btnMoveUpRecord;
		private System.Windows.Forms.ToolStripButton btnMoveDownRecord;
		private System.Windows.Forms.ToolStripMenuItem mnuMainMenuFileClose;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStripMenuItem mnuMainMenuFileExportAs;
		private System.Windows.Forms.ToolStripButton btnNewRecord;
		private System.Windows.Forms.TextBox txtSearchOutput;
		private System.Windows.Forms.Label lblSearchOutput;
		private System.Windows.Forms.ToolStripMenuItem mnuMainMenuFileSettings;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStrip tsOutputToolbar;
		private System.Windows.Forms.ToolStripButton btnRemoveRecords;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripButton btnCheckRecordsURLs;
		private System.Windows.Forms.Label lblInputList;
		private System.Windows.Forms.StatusStrip ssStatusBar;
		private System.Windows.Forms.ToolStripStatusLabel lblStatusBar;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.mnuMainMenu = new System.Windows.Forms.MenuStrip();
			this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuMainMenuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuMainMenuFileSettings = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuMainMenuFileExportAs = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuMainMenuFileClose = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuMainMenuFileExit = new System.Windows.Forms.ToolStripMenuItem();
			this.scMainSplitContainer = new System.Windows.Forms.SplitContainer();
			this.pnlInput = new System.Windows.Forms.Panel();
			this.lblInputList = new System.Windows.Forms.Label();
			this.txtSearchInput = new System.Windows.Forms.TextBox();
			this.lblSearchInput = new System.Windows.Forms.Label();
			this.dgvInputRecords = new System.Windows.Forms.DataGridView();
			this.tsOutputToolbar = new System.Windows.Forms.ToolStrip();
			this.btnRemoveRecords = new System.Windows.Forms.ToolStripButton();
			this.btnRemoveAllRecords = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.btnNewRecord = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.btnMoveUpRecord = new System.Windows.Forms.ToolStripButton();
			this.btnMoveDownRecord = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.btnCheckRecordsURLs = new System.Windows.Forms.ToolStripButton();
			this.dgvOutputRecords = new System.Windows.Forms.DataGridView();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtSearchOutput = new System.Windows.Forms.TextBox();
			this.lblSearchOutput = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnAddAllRecords = new System.Windows.Forms.Button();
			this.btnAddRecord = new System.Windows.Forms.Button();
			this.ssStatusBar = new System.Windows.Forms.StatusStrip();
			this.lblStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
			this.mnuMainMenu.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.scMainSplitContainer)).BeginInit();
			this.scMainSplitContainer.Panel1.SuspendLayout();
			this.scMainSplitContainer.Panel2.SuspendLayout();
			this.scMainSplitContainer.SuspendLayout();
			this.pnlInput.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvInputRecords)).BeginInit();
			this.tsOutputToolbar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvOutputRecords)).BeginInit();
			this.panel2.SuspendLayout();
			this.ssStatusBar.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMainMenu
			// 
			this.mnuMainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.mnuMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mnuFile});
			this.mnuMainMenu.Location = new System.Drawing.Point(0, 0);
			this.mnuMainMenu.Name = "mnuMainMenu";
			this.mnuMainMenu.Size = new System.Drawing.Size(1182, 28);
			this.mnuMainMenu.TabIndex = 0;
			this.mnuMainMenu.Text = "menuStrip1";
			// 
			// mnuFile
			// 
			this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mnuMainMenuFileOpen,
			this.toolStripMenuItem1,
			this.mnuMainMenuFileSettings,
			this.toolStripSeparator2,
			this.mnuMainMenuFileExportAs,
			this.mnuMainMenuFileClose,
			this.toolStripSeparator1,
			this.mnuMainMenuFileExit});
			this.mnuFile.Name = "mnuFile";
			this.mnuFile.Size = new System.Drawing.Size(44, 24);
			this.mnuFile.Text = "&File";
			// 
			// mnuMainMenuFileOpen
			// 
			this.mnuMainMenuFileOpen.Name = "mnuMainMenuFileOpen";
			this.mnuMainMenuFileOpen.Size = new System.Drawing.Size(156, 26);
			this.mnuMainMenuFileOpen.Text = "&Open";
			this.mnuMainMenuFileOpen.Click += new System.EventHandler(this.mnuMainMenuFileOpenClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(153, 6);
			// 
			// mnuMainMenuFileSettings
			// 
			this.mnuMainMenuFileSettings.Name = "mnuMainMenuFileSettings";
			this.mnuMainMenuFileSettings.Size = new System.Drawing.Size(156, 26);
			this.mnuMainMenuFileSettings.Text = "&Settings";
			this.mnuMainMenuFileSettings.Click += new System.EventHandler(this.mnuMainMenuFileSettingsClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(153, 6);
			// 
			// mnuMainMenuFileExportAs
			// 
			this.mnuMainMenuFileExportAs.Name = "mnuMainMenuFileExportAs";
			this.mnuMainMenuFileExportAs.Size = new System.Drawing.Size(156, 26);
			this.mnuMainMenuFileExportAs.Text = "&Export As...";
			this.mnuMainMenuFileExportAs.Click += new System.EventHandler(this.mnuMainMenuFileExportAsClick);
			// 
			// mnuMainMenuFileClose
			// 
			this.mnuMainMenuFileClose.Name = "mnuMainMenuFileClose";
			this.mnuMainMenuFileClose.Size = new System.Drawing.Size(156, 26);
			this.mnuMainMenuFileClose.Text = "&Close";
			this.mnuMainMenuFileClose.Click += new System.EventHandler(this.mnuMainMenuFileCloseClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(153, 6);
			// 
			// mnuMainMenuFileExit
			// 
			this.mnuMainMenuFileExit.Name = "mnuMainMenuFileExit";
			this.mnuMainMenuFileExit.Size = new System.Drawing.Size(156, 26);
			this.mnuMainMenuFileExit.Text = "E&xit";
			this.mnuMainMenuFileExit.Click += new System.EventHandler(this.mnuMainMenuFileExitClick);
			// 
			// scMainSplitContainer
			// 
			this.scMainSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.scMainSplitContainer.Location = new System.Drawing.Point(0, 28);
			this.scMainSplitContainer.Name = "scMainSplitContainer";
			this.scMainSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// scMainSplitContainer.Panel1
			// 
			this.scMainSplitContainer.Panel1.Controls.Add(this.pnlInput);
			this.scMainSplitContainer.Panel1.Controls.Add(this.dgvInputRecords);
			// 
			// scMainSplitContainer.Panel2
			// 
			this.scMainSplitContainer.Panel2.Controls.Add(this.tsOutputToolbar);
			this.scMainSplitContainer.Panel2.Controls.Add(this.dgvOutputRecords);
			this.scMainSplitContainer.Panel2.Controls.Add(this.panel2);
			this.scMainSplitContainer.Size = new System.Drawing.Size(1182, 562);
			this.scMainSplitContainer.SplitterDistance = 245;
			this.scMainSplitContainer.TabIndex = 3;
			// 
			// pnlInput
			// 
			this.pnlInput.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.pnlInput.Controls.Add(this.lblInputList);
			this.pnlInput.Controls.Add(this.txtSearchInput);
			this.pnlInput.Controls.Add(this.lblSearchInput);
			this.pnlInput.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlInput.Location = new System.Drawing.Point(0, 0);
			this.pnlInput.Name = "pnlInput";
			this.pnlInput.Size = new System.Drawing.Size(1182, 40);
			this.pnlInput.TabIndex = 0;
			// 
			// lblInputList
			// 
			this.lblInputList.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInputList.Location = new System.Drawing.Point(12, 12);
			this.lblInputList.Name = "lblInputList";
			this.lblInputList.Size = new System.Drawing.Size(100, 23);
			this.lblInputList.TabIndex = 0;
			this.lblInputList.Text = "Input list";
			// 
			// txtSearchInput
			// 
			this.txtSearchInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearchInput.Location = new System.Drawing.Point(204, 9);
			this.txtSearchInput.Name = "txtSearchInput";
			this.txtSearchInput.Size = new System.Drawing.Size(953, 22);
			this.txtSearchInput.TabIndex = 2;
			this.txtSearchInput.TextChanged += new System.EventHandler(this.txtSearchInputTextChanged);
			// 
			// lblSearchInput
			// 
			this.lblSearchInput.Location = new System.Drawing.Point(132, 12);
			this.lblSearchInput.Name = "lblSearchInput";
			this.lblSearchInput.Size = new System.Drawing.Size(66, 23);
			this.lblSearchInput.TabIndex = 1;
			this.lblSearchInput.Text = "&Search:";
			// 
			// dgvInputRecords
			// 
			this.dgvInputRecords.AllowUserToAddRows = false;
			this.dgvInputRecords.AllowUserToDeleteRows = false;
			this.dgvInputRecords.AllowUserToResizeRows = false;
			this.dgvInputRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvInputRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvInputRecords.Location = new System.Drawing.Point(0, 46);
			this.dgvInputRecords.Name = "dgvInputRecords";
			this.dgvInputRecords.ReadOnly = true;
			this.dgvInputRecords.RowTemplate.Height = 24;
			this.dgvInputRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvInputRecords.Size = new System.Drawing.Size(1182, 196);
			this.dgvInputRecords.TabIndex = 1;
			this.dgvInputRecords.TabStop = false;
			this.dgvInputRecords.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInputRecordsCellClick);
			// 
			// tsOutputToolbar
			// 
			this.tsOutputToolbar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tsOutputToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tsOutputToolbar.ImageScalingSize = new System.Drawing.Size(25, 25);
			this.tsOutputToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.btnRemoveRecords,
			this.btnRemoveAllRecords,
			this.toolStripSeparator3,
			this.btnNewRecord,
			this.toolStripSeparator4,
			this.btnMoveUpRecord,
			this.btnMoveDownRecord,
			this.toolStripSeparator5,
			this.btnCheckRecordsURLs});
			this.tsOutputToolbar.Location = new System.Drawing.Point(0, 281);
			this.tsOutputToolbar.Name = "tsOutputToolbar";
			this.tsOutputToolbar.Size = new System.Drawing.Size(1182, 32);
			this.tsOutputToolbar.TabIndex = 2;
			this.tsOutputToolbar.TabStop = true;
			this.tsOutputToolbar.Text = "toolStrip1";
			// 
			// btnRemoveRecords
			// 
			this.btnRemoveRecords.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveRecords.Image")));
			this.btnRemoveRecords.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRemoveRecords.Name = "btnRemoveRecords";
			this.btnRemoveRecords.Size = new System.Drawing.Size(92, 29);
			this.btnRemoveRecords.Text = "&Remove";
			this.btnRemoveRecords.Click += new System.EventHandler(this.btnRemoveRecordsClick);
			// 
			// btnRemoveAllRecords
			// 
			this.btnRemoveAllRecords.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveAllRecords.Image")));
			this.btnRemoveAllRecords.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnRemoveAllRecords.Name = "btnRemoveAllRecords";
			this.btnRemoveAllRecords.Size = new System.Drawing.Size(114, 29);
			this.btnRemoveAllRecords.Text = "Remove &All";
			this.btnRemoveAllRecords.Click += new System.EventHandler(this.btnRemoveAllRecordsClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
			// 
			// btnNewRecord
			// 
			this.btnNewRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnNewRecord.Image")));
			this.btnNewRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnNewRecord.Name = "btnNewRecord";
			this.btnNewRecord.Size = new System.Drawing.Size(68, 29);
			this.btnNewRecord.Text = "&New";
			this.btnNewRecord.Click += new System.EventHandler(this.btnNewRecordClick);
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
			// 
			// btnMoveUpRecord
			// 
			this.btnMoveUpRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveUpRecord.Image")));
			this.btnMoveUpRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnMoveUpRecord.Name = "btnMoveUpRecord";
			this.btnMoveUpRecord.Size = new System.Drawing.Size(98, 29);
			this.btnMoveUpRecord.Text = "Move &Up";
			this.btnMoveUpRecord.Click += new System.EventHandler(this.btnMoveUpRecordClick);
			// 
			// btnMoveDownRecord
			// 
			this.btnMoveDownRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveDownRecord.Image")));
			this.btnMoveDownRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnMoveDownRecord.Name = "btnMoveDownRecord";
			this.btnMoveDownRecord.Size = new System.Drawing.Size(118, 29);
			this.btnMoveDownRecord.Text = "Move &Down";
			this.btnMoveDownRecord.Click += new System.EventHandler(this.btnMoveDownRecordClick);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 32);
			// 
			// btnCheckRecordsURLs
			// 
			this.btnCheckRecordsURLs.Image = ((System.Drawing.Image)(resources.GetObject("btnCheckRecordsURLs.Image")));
			this.btnCheckRecordsURLs.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnCheckRecordsURLs.Name = "btnCheckRecordsURLs";
			this.btnCheckRecordsURLs.Size = new System.Drawing.Size(113, 29);
			this.btnCheckRecordsURLs.Text = "&Check URLs";
			this.btnCheckRecordsURLs.Click += new System.EventHandler(this.btnbtnCheckRecordsURLsClick);
			// 
			// dgvOutputRecords
			// 
			this.dgvOutputRecords.AllowUserToAddRows = false;
			this.dgvOutputRecords.AllowUserToDeleteRows = false;
			this.dgvOutputRecords.AllowUserToResizeRows = false;
			this.dgvOutputRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvOutputRecords.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.dgvOutputRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvOutputRecords.Location = new System.Drawing.Point(0, 60);
			this.dgvOutputRecords.Name = "dgvOutputRecords";
			this.dgvOutputRecords.RowTemplate.Height = 24;
			this.dgvOutputRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvOutputRecords.Size = new System.Drawing.Size(1182, 215);
			this.dgvOutputRecords.TabIndex = 1;
			this.dgvOutputRecords.TabStop = false;
			this.dgvOutputRecords.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOutputRecordsCellClick);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.LightYellow;
			this.panel2.Controls.Add(this.txtSearchOutput);
			this.panel2.Controls.Add(this.lblSearchOutput);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.btnAddAllRecords);
			this.panel2.Controls.Add(this.btnAddRecord);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1182, 54);
			this.panel2.TabIndex = 0;
			// 
			// txtSearchOutput
			// 
			this.txtSearchOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.txtSearchOutput.Location = new System.Drawing.Point(482, 18);
			this.txtSearchOutput.Name = "txtSearchOutput";
			this.txtSearchOutput.Size = new System.Drawing.Size(675, 22);
			this.txtSearchOutput.TabIndex = 4;
			this.txtSearchOutput.TextChanged += new System.EventHandler(this.txtSearchOutputTextChanged);
			// 
			// lblSearchOutput
			// 
			this.lblSearchOutput.Location = new System.Drawing.Point(410, 20);
			this.lblSearchOutput.Name = "lblSearchOutput";
			this.lblSearchOutput.Size = new System.Drawing.Size(66, 23);
			this.lblSearchOutput.TabIndex = 3;
			this.lblSearchOutput.Text = "Sea&rch:";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(12, 17);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Output list";
			// 
			// btnAddAllRecords
			// 
			this.btnAddAllRecords.Image = ((System.Drawing.Image)(resources.GetObject("btnAddAllRecords.Image")));
			this.btnAddAllRecords.Location = new System.Drawing.Point(257, 12);
			this.btnAddAllRecords.Name = "btnAddAllRecords";
			this.btnAddAllRecords.Size = new System.Drawing.Size(100, 33);
			this.btnAddAllRecords.TabIndex = 2;
			this.btnAddAllRecords.UseVisualStyleBackColor = true;
			this.btnAddAllRecords.Click += new System.EventHandler(this.btnAddAllRecordsClick);
			// 
			// btnAddRecord
			// 
			this.btnAddRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRecord.Image")));
			this.btnAddRecord.Location = new System.Drawing.Point(151, 12);
			this.btnAddRecord.Name = "btnAddRecord";
			this.btnAddRecord.Size = new System.Drawing.Size(100, 34);
			this.btnAddRecord.TabIndex = 1;
			this.btnAddRecord.UseVisualStyleBackColor = true;
			this.btnAddRecord.Click += new System.EventHandler(this.btnAddRecordClick);
			// 
			// ssStatusBar
			// 
			this.ssStatusBar.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.ssStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.lblStatusBar});
			this.ssStatusBar.Location = new System.Drawing.Point(0, 593);
			this.ssStatusBar.Name = "ssStatusBar";
			this.ssStatusBar.Size = new System.Drawing.Size(1182, 22);
			this.ssStatusBar.TabIndex = 4;
			this.ssStatusBar.Text = "statusStrip1";
			// 
			// lblStatusBar
			// 
			this.lblStatusBar.Name = "lblStatusBar";
			this.lblStatusBar.Size = new System.Drawing.Size(0, 17);
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1182, 615);
			this.Controls.Add(this.ssStatusBar);
			this.Controls.Add(this.scMainSplitContainer);
			this.Controls.Add(this.mnuMainMenu);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mnuMainMenu;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "M3U Editor - IPTV list editor";
			this.Load += new System.EventHandler(this.frmMainLoad);
			this.mnuMainMenu.ResumeLayout(false);
			this.mnuMainMenu.PerformLayout();
			this.scMainSplitContainer.Panel1.ResumeLayout(false);
			this.scMainSplitContainer.Panel2.ResumeLayout(false);
			this.scMainSplitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.scMainSplitContainer)).EndInit();
			this.scMainSplitContainer.ResumeLayout(false);
			this.pnlInput.ResumeLayout(false);
			this.pnlInput.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvInputRecords)).EndInit();
			this.tsOutputToolbar.ResumeLayout(false);
			this.tsOutputToolbar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvOutputRecords)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.ssStatusBar.ResumeLayout(false);
			this.ssStatusBar.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
