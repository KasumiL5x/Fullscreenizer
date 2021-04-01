namespace Fullscreenizer
{
	partial class Fullscreenizer
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fullscreenizer));
			this.lbl_apps = new System.Windows.Forms.Label();
			this.lv_apps = new System.Windows.Forms.ListView();
			this.ch_title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btn_fullscreenizeApp = new System.Windows.Forms.Button();
			this.gb_apps = new System.Windows.Forms.GroupBox();
			this.chk_moveWindow = new System.Windows.Forms.CheckBox();
			this.chk_scaleToFit = new System.Windows.Forms.CheckBox();
			this.btn_removeApp = new System.Windows.Forms.Button();
			this.btn_showAllApps = new System.Windows.Forms.Button();
			this.lbl_website = new System.Windows.Forms.Label();
			this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItemShow = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripMenuItemClose = new System.Windows.Forms.ToolStripMenuItem();
			this.chk_minimizeToTray = new System.Windows.Forms.CheckBox();
			this.chk_lockCursor = new System.Windows.Forms.CheckBox();
			this.chk_fullscreenizeEnableHotkey = new System.Windows.Forms.CheckBox();
			this.gb_hotkeyModifier = new System.Windows.Forms.GroupBox();
			this.chk_fullscreenizeHotkeyModAlt = new System.Windows.Forms.CheckBox();
			this.chk_fullscreenizeHotkeyModShift = new System.Windows.Forms.CheckBox();
			this.chk_fullscreenizeHotkeyModCtrl = new System.Windows.Forms.CheckBox();
			this.cb_fullscreenizeHotkeyKey = new System.Windows.Forms.ComboBox();
			this.gb_fullscreenizeHotkey = new System.Windows.Forms.GroupBox();
			this.gb_lockCursorHotkey = new System.Windows.Forms.GroupBox();
			this.cb_lockCursorHotkeyKey = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.chk_lockCursorHotkeyModAlt = new System.Windows.Forms.CheckBox();
			this.chk_lockCursorHotkeyModShift = new System.Windows.Forms.CheckBox();
			this.chk_lockCursorHotkeyModCtrl = new System.Windows.Forms.CheckBox();
			this.chk_lockCursorEnableHotkey = new System.Windows.Forms.CheckBox();
			this.gb_apps.SuspendLayout();
			this.contextMenuStrip.SuspendLayout();
			this.gb_hotkeyModifier.SuspendLayout();
			this.gb_fullscreenizeHotkey.SuspendLayout();
			this.gb_lockCursorHotkey.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbl_apps
			// 
			this.lbl_apps.AutoSize = true;
			this.lbl_apps.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_apps.Location = new System.Drawing.Point(12, 9);
			this.lbl_apps.Name = "lbl_apps";
			this.lbl_apps.Size = new System.Drawing.Size(54, 24);
			this.lbl_apps.TabIndex = 1;
			this.lbl_apps.Text = "Apps";
			// 
			// lv_apps
			// 
			this.lv_apps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_title});
			this.lv_apps.FullRowSelect = true;
			this.lv_apps.GridLines = true;
			this.lv_apps.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lv_apps.HideSelection = false;
			this.lv_apps.Location = new System.Drawing.Point(6, 14);
			this.lv_apps.MultiSelect = false;
			this.lv_apps.Name = "lv_apps";
			this.lv_apps.Size = new System.Drawing.Size(328, 148);
			this.lv_apps.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lv_apps.TabIndex = 0;
			this.lv_apps.TabStop = false;
			this.lv_apps.UseCompatibleStateImageBehavior = false;
			this.lv_apps.View = System.Windows.Forms.View.Details;
			// 
			// ch_title
			// 
			this.ch_title.Text = "Title";
			// 
			// btn_fullscreenizeApp
			// 
			this.btn_fullscreenizeApp.Location = new System.Drawing.Point(6, 168);
			this.btn_fullscreenizeApp.Name = "btn_fullscreenizeApp";
			this.btn_fullscreenizeApp.Size = new System.Drawing.Size(76, 23);
			this.btn_fullscreenizeApp.TabIndex = 3;
			this.btn_fullscreenizeApp.TabStop = false;
			this.btn_fullscreenizeApp.Text = "Fullscreenize";
			this.btn_fullscreenizeApp.UseVisualStyleBackColor = true;
			this.btn_fullscreenizeApp.Click += new System.EventHandler(this.btn_fullscreenizeApp_Click);
			// 
			// gb_apps
			// 
			this.gb_apps.Controls.Add(this.chk_moveWindow);
			this.gb_apps.Controls.Add(this.chk_scaleToFit);
			this.gb_apps.Controls.Add(this.btn_removeApp);
			this.gb_apps.Controls.Add(this.lv_apps);
			this.gb_apps.Controls.Add(this.btn_showAllApps);
			this.gb_apps.Controls.Add(this.btn_fullscreenizeApp);
			this.gb_apps.Location = new System.Drawing.Point(16, 36);
			this.gb_apps.Name = "gb_apps";
			this.gb_apps.Size = new System.Drawing.Size(342, 198);
			this.gb_apps.TabIndex = 0;
			this.gb_apps.TabStop = false;
			// 
			// chk_moveWindow
			// 
			this.chk_moveWindow.AutoSize = true;
			this.chk_moveWindow.Checked = true;
			this.chk_moveWindow.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_moveWindow.Location = new System.Drawing.Point(148, 172);
			this.chk_moveWindow.Name = "chk_moveWindow";
			this.chk_moveWindow.Size = new System.Drawing.Size(53, 17);
			this.chk_moveWindow.TabIndex = 6;
			this.chk_moveWindow.Text = "Move";
			this.chk_moveWindow.UseVisualStyleBackColor = true;
			this.chk_moveWindow.CheckedChanged += new System.EventHandler(this.chk_moveWindow_CheckedChanged);
			// 
			// chk_scaleToFit
			// 
			this.chk_scaleToFit.AutoSize = true;
			this.chk_scaleToFit.Checked = true;
			this.chk_scaleToFit.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_scaleToFit.Location = new System.Drawing.Point(88, 172);
			this.chk_scaleToFit.Name = "chk_scaleToFit";
			this.chk_scaleToFit.Size = new System.Drawing.Size(53, 17);
			this.chk_scaleToFit.TabIndex = 5;
			this.chk_scaleToFit.Text = "Scale";
			this.chk_scaleToFit.UseVisualStyleBackColor = true;
			this.chk_scaleToFit.CheckedChanged += new System.EventHandler(this.chk_scaleToFit_CheckedChanged);
			// 
			// btn_removeApp
			// 
			this.btn_removeApp.Location = new System.Drawing.Point(207, 168);
			this.btn_removeApp.Name = "btn_removeApp";
			this.btn_removeApp.Size = new System.Drawing.Size(57, 23);
			this.btn_removeApp.TabIndex = 4;
			this.btn_removeApp.Text = "Remove";
			this.btn_removeApp.UseVisualStyleBackColor = true;
			this.btn_removeApp.Click += new System.EventHandler(this.btn_removeApp_Click);
			// 
			// btn_showAllApps
			// 
			this.btn_showAllApps.Location = new System.Drawing.Point(270, 168);
			this.btn_showAllApps.Name = "btn_showAllApps";
			this.btn_showAllApps.Size = new System.Drawing.Size(64, 23);
			this.btn_showAllApps.TabIndex = 3;
			this.btn_showAllApps.TabStop = false;
			this.btn_showAllApps.Text = "Show All";
			this.btn_showAllApps.UseVisualStyleBackColor = true;
			this.btn_showAllApps.Click += new System.EventHandler(this.btn_showAllApps_Click);
			// 
			// lbl_website
			// 
			this.lbl_website.AutoSize = true;
			this.lbl_website.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lbl_website.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_website.Location = new System.Drawing.Point(273, 3);
			this.lbl_website.Name = "lbl_website";
			this.lbl_website.Size = new System.Drawing.Size(93, 13);
			this.lbl_website.TabIndex = 12;
			this.lbl_website.Text = "GitHub Repository";
			this.lbl_website.Click += new System.EventHandler(this.lbl_website_Click);
			// 
			// notifyIcon
			// 
			this.notifyIcon.ContextMenuStrip = this.contextMenuStrip;
			this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
			this.notifyIcon.Text = "Fullscreenizer";
			this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
			// 
			// contextMenuStrip
			// 
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShow,
            this.toolStripSeparator,
            this.toolStripMenuItemClose});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(104, 54);
			// 
			// toolStripMenuItemShow
			// 
			this.toolStripMenuItemShow.Name = "toolStripMenuItemShow";
			this.toolStripMenuItemShow.Size = new System.Drawing.Size(103, 22);
			this.toolStripMenuItemShow.Text = "Show";
			this.toolStripMenuItemShow.Click += new System.EventHandler(this.toolStripMenuItemShow_Click);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(100, 6);
			// 
			// toolStripMenuItemClose
			// 
			this.toolStripMenuItemClose.Name = "toolStripMenuItemClose";
			this.toolStripMenuItemClose.Size = new System.Drawing.Size(103, 22);
			this.toolStripMenuItemClose.Text = "Close";
			this.toolStripMenuItemClose.Click += new System.EventHandler(this.toolStripMenuItemClose_Click);
			// 
			// chk_minimizeToTray
			// 
			this.chk_minimizeToTray.AutoSize = true;
			this.chk_minimizeToTray.Checked = true;
			this.chk_minimizeToTray.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_minimizeToTray.Location = new System.Drawing.Point(262, 23);
			this.chk_minimizeToTray.Name = "chk_minimizeToTray";
			this.chk_minimizeToTray.Size = new System.Drawing.Size(98, 17);
			this.chk_minimizeToTray.TabIndex = 7;
			this.chk_minimizeToTray.Text = "Minimize to tray";
			this.chk_minimizeToTray.UseVisualStyleBackColor = true;
			this.chk_minimizeToTray.CheckedChanged += new System.EventHandler(this.chk_minimizeToTray_CheckedChanged);
			// 
			// chk_lockCursor
			// 
			this.chk_lockCursor.AutoSize = true;
			this.chk_lockCursor.Checked = true;
			this.chk_lockCursor.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_lockCursor.Location = new System.Drawing.Point(167, 23);
			this.chk_lockCursor.Name = "chk_lockCursor";
			this.chk_lockCursor.Size = new System.Drawing.Size(82, 17);
			this.chk_lockCursor.TabIndex = 13;
			this.chk_lockCursor.Text = "Lock cursor";
			this.chk_lockCursor.UseVisualStyleBackColor = true;
			this.chk_lockCursor.CheckedChanged += new System.EventHandler(this.chk_lockCursor_CheckedChanged);
			// 
			// chk_fullscreenizeEnableHotkey
			// 
			this.chk_fullscreenizeEnableHotkey.AutoCheck = false;
			this.chk_fullscreenizeEnableHotkey.AutoSize = true;
			this.chk_fullscreenizeEnableHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chk_fullscreenizeEnableHotkey.Location = new System.Drawing.Point(16, 236);
			this.chk_fullscreenizeEnableHotkey.Name = "chk_fullscreenizeEnableHotkey";
			this.chk_fullscreenizeEnableHotkey.Size = new System.Drawing.Size(202, 28);
			this.chk_fullscreenizeEnableHotkey.TabIndex = 9;
			this.chk_fullscreenizeEnableHotkey.TabStop = false;
			this.chk_fullscreenizeEnableHotkey.Text = "Fullscreenize hotkey";
			this.chk_fullscreenizeEnableHotkey.UseVisualStyleBackColor = true;
			this.chk_fullscreenizeEnableHotkey.Click += new System.EventHandler(this.chk_fullscreenizeEnableHotkey_Click);
			// 
			// gb_hotkeyModifier
			// 
			this.gb_hotkeyModifier.Controls.Add(this.chk_fullscreenizeHotkeyModAlt);
			this.gb_hotkeyModifier.Controls.Add(this.chk_fullscreenizeHotkeyModShift);
			this.gb_hotkeyModifier.Controls.Add(this.chk_fullscreenizeHotkeyModCtrl);
			this.gb_hotkeyModifier.Location = new System.Drawing.Point(6, 9);
			this.gb_hotkeyModifier.Name = "gb_hotkeyModifier";
			this.gb_hotkeyModifier.Size = new System.Drawing.Size(139, 29);
			this.gb_hotkeyModifier.TabIndex = 11;
			this.gb_hotkeyModifier.TabStop = false;
			// 
			// chk_fullscreenizeHotkeyModAlt
			// 
			this.chk_fullscreenizeHotkeyModAlt.AutoCheck = false;
			this.chk_fullscreenizeHotkeyModAlt.AutoSize = true;
			this.chk_fullscreenizeHotkeyModAlt.Location = new System.Drawing.Point(100, 10);
			this.chk_fullscreenizeHotkeyModAlt.Name = "chk_fullscreenizeHotkeyModAlt";
			this.chk_fullscreenizeHotkeyModAlt.Size = new System.Drawing.Size(37, 17);
			this.chk_fullscreenizeHotkeyModAlt.TabIndex = 0;
			this.chk_fullscreenizeHotkeyModAlt.TabStop = false;
			this.chk_fullscreenizeHotkeyModAlt.Text = "alt";
			this.chk_fullscreenizeHotkeyModAlt.UseVisualStyleBackColor = true;
			this.chk_fullscreenizeHotkeyModAlt.Click += new System.EventHandler(this.chk_fullscreenizeHotkeyModAlt_Click);
			// 
			// chk_fullscreenizeHotkeyModShift
			// 
			this.chk_fullscreenizeHotkeyModShift.AutoCheck = false;
			this.chk_fullscreenizeHotkeyModShift.AutoSize = true;
			this.chk_fullscreenizeHotkeyModShift.Location = new System.Drawing.Point(49, 10);
			this.chk_fullscreenizeHotkeyModShift.Name = "chk_fullscreenizeHotkeyModShift";
			this.chk_fullscreenizeHotkeyModShift.Size = new System.Drawing.Size(45, 17);
			this.chk_fullscreenizeHotkeyModShift.TabIndex = 0;
			this.chk_fullscreenizeHotkeyModShift.TabStop = false;
			this.chk_fullscreenizeHotkeyModShift.Text = "shift";
			this.chk_fullscreenizeHotkeyModShift.UseVisualStyleBackColor = true;
			this.chk_fullscreenizeHotkeyModShift.Click += new System.EventHandler(this.chk_fullscreenizeHotkeyModShift_Click);
			// 
			// chk_fullscreenizeHotkeyModCtrl
			// 
			this.chk_fullscreenizeHotkeyModCtrl.AutoCheck = false;
			this.chk_fullscreenizeHotkeyModCtrl.AutoSize = true;
			this.chk_fullscreenizeHotkeyModCtrl.Checked = true;
			this.chk_fullscreenizeHotkeyModCtrl.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_fullscreenizeHotkeyModCtrl.Location = new System.Drawing.Point(5, 10);
			this.chk_fullscreenizeHotkeyModCtrl.Name = "chk_fullscreenizeHotkeyModCtrl";
			this.chk_fullscreenizeHotkeyModCtrl.Size = new System.Drawing.Size(40, 17);
			this.chk_fullscreenizeHotkeyModCtrl.TabIndex = 0;
			this.chk_fullscreenizeHotkeyModCtrl.TabStop = false;
			this.chk_fullscreenizeHotkeyModCtrl.Text = "ctrl";
			this.chk_fullscreenizeHotkeyModCtrl.UseVisualStyleBackColor = true;
			this.chk_fullscreenizeHotkeyModCtrl.Click += new System.EventHandler(this.chk_fullscreenizeHotkeyModCtrl_Click);
			// 
			// cb_fullscreenizeHotkeyKey
			// 
			this.cb_fullscreenizeHotkeyKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_fullscreenizeHotkeyKey.FormattingEnabled = true;
			this.cb_fullscreenizeHotkeyKey.Location = new System.Drawing.Point(151, 17);
			this.cb_fullscreenizeHotkeyKey.Name = "cb_fullscreenizeHotkeyKey";
			this.cb_fullscreenizeHotkeyKey.Size = new System.Drawing.Size(183, 21);
			this.cb_fullscreenizeHotkeyKey.TabIndex = 11;
			this.cb_fullscreenizeHotkeyKey.TabStop = false;
			this.cb_fullscreenizeHotkeyKey.SelectionChangeCommitted += new System.EventHandler(this.cb_fullscreenizeHotkeyKey_SelectionChangeCommitted);
			// 
			// gb_fullscreenizeHotkey
			// 
			this.gb_fullscreenizeHotkey.Controls.Add(this.cb_fullscreenizeHotkeyKey);
			this.gb_fullscreenizeHotkey.Controls.Add(this.gb_hotkeyModifier);
			this.gb_fullscreenizeHotkey.Location = new System.Drawing.Point(16, 261);
			this.gb_fullscreenizeHotkey.Name = "gb_fullscreenizeHotkey";
			this.gb_fullscreenizeHotkey.Size = new System.Drawing.Size(342, 47);
			this.gb_fullscreenizeHotkey.TabIndex = 10;
			this.gb_fullscreenizeHotkey.TabStop = false;
			// 
			// gb_lockCursorHotkey
			// 
			this.gb_lockCursorHotkey.Controls.Add(this.cb_lockCursorHotkeyKey);
			this.gb_lockCursorHotkey.Controls.Add(this.groupBox2);
			this.gb_lockCursorHotkey.Location = new System.Drawing.Point(16, 335);
			this.gb_lockCursorHotkey.Name = "gb_lockCursorHotkey";
			this.gb_lockCursorHotkey.Size = new System.Drawing.Size(342, 47);
			this.gb_lockCursorHotkey.TabIndex = 15;
			this.gb_lockCursorHotkey.TabStop = false;
			// 
			// cb_lockCursorHotkeyKey
			// 
			this.cb_lockCursorHotkeyKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_lockCursorHotkeyKey.FormattingEnabled = true;
			this.cb_lockCursorHotkeyKey.Location = new System.Drawing.Point(151, 17);
			this.cb_lockCursorHotkeyKey.Name = "cb_lockCursorHotkeyKey";
			this.cb_lockCursorHotkeyKey.Size = new System.Drawing.Size(183, 21);
			this.cb_lockCursorHotkeyKey.TabIndex = 11;
			this.cb_lockCursorHotkeyKey.TabStop = false;
			this.cb_lockCursorHotkeyKey.SelectionChangeCommitted += new System.EventHandler(this.cb_lockCursorHotkeyKey_SelectionChangeCommitted);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.chk_lockCursorHotkeyModAlt);
			this.groupBox2.Controls.Add(this.chk_lockCursorHotkeyModShift);
			this.groupBox2.Controls.Add(this.chk_lockCursorHotkeyModCtrl);
			this.groupBox2.Location = new System.Drawing.Point(6, 9);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(139, 29);
			this.groupBox2.TabIndex = 11;
			this.groupBox2.TabStop = false;
			// 
			// chk_lockCursorHotkeyModAlt
			// 
			this.chk_lockCursorHotkeyModAlt.AutoCheck = false;
			this.chk_lockCursorHotkeyModAlt.AutoSize = true;
			this.chk_lockCursorHotkeyModAlt.Location = new System.Drawing.Point(100, 10);
			this.chk_lockCursorHotkeyModAlt.Name = "chk_lockCursorHotkeyModAlt";
			this.chk_lockCursorHotkeyModAlt.Size = new System.Drawing.Size(37, 17);
			this.chk_lockCursorHotkeyModAlt.TabIndex = 0;
			this.chk_lockCursorHotkeyModAlt.TabStop = false;
			this.chk_lockCursorHotkeyModAlt.Text = "alt";
			this.chk_lockCursorHotkeyModAlt.UseVisualStyleBackColor = true;
			this.chk_lockCursorHotkeyModAlt.Click += new System.EventHandler(this.chk_lockCursorHotkeyModAlt_Click);
			// 
			// chk_lockCursorHotkeyModShift
			// 
			this.chk_lockCursorHotkeyModShift.AutoCheck = false;
			this.chk_lockCursorHotkeyModShift.AutoSize = true;
			this.chk_lockCursorHotkeyModShift.Location = new System.Drawing.Point(49, 10);
			this.chk_lockCursorHotkeyModShift.Name = "chk_lockCursorHotkeyModShift";
			this.chk_lockCursorHotkeyModShift.Size = new System.Drawing.Size(45, 17);
			this.chk_lockCursorHotkeyModShift.TabIndex = 0;
			this.chk_lockCursorHotkeyModShift.TabStop = false;
			this.chk_lockCursorHotkeyModShift.Text = "shift";
			this.chk_lockCursorHotkeyModShift.UseVisualStyleBackColor = true;
			this.chk_lockCursorHotkeyModShift.Click += new System.EventHandler(this.chk_lockCursorHotkeyModShift_Click);
			// 
			// chk_lockCursorHotkeyModCtrl
			// 
			this.chk_lockCursorHotkeyModCtrl.AutoCheck = false;
			this.chk_lockCursorHotkeyModCtrl.AutoSize = true;
			this.chk_lockCursorHotkeyModCtrl.Checked = true;
			this.chk_lockCursorHotkeyModCtrl.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_lockCursorHotkeyModCtrl.Location = new System.Drawing.Point(5, 10);
			this.chk_lockCursorHotkeyModCtrl.Name = "chk_lockCursorHotkeyModCtrl";
			this.chk_lockCursorHotkeyModCtrl.Size = new System.Drawing.Size(40, 17);
			this.chk_lockCursorHotkeyModCtrl.TabIndex = 0;
			this.chk_lockCursorHotkeyModCtrl.TabStop = false;
			this.chk_lockCursorHotkeyModCtrl.Text = "ctrl";
			this.chk_lockCursorHotkeyModCtrl.UseVisualStyleBackColor = true;
			this.chk_lockCursorHotkeyModCtrl.Click += new System.EventHandler(this.chk_lockCursorHotkeyModCtrl_Click);
			// 
			// chk_lockCursorEnableHotkey
			// 
			this.chk_lockCursorEnableHotkey.AutoCheck = false;
			this.chk_lockCursorEnableHotkey.AutoSize = true;
			this.chk_lockCursorEnableHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chk_lockCursorEnableHotkey.Location = new System.Drawing.Point(16, 310);
			this.chk_lockCursorEnableHotkey.Name = "chk_lockCursorEnableHotkey";
			this.chk_lockCursorEnableHotkey.Size = new System.Drawing.Size(187, 28);
			this.chk_lockCursorEnableHotkey.TabIndex = 14;
			this.chk_lockCursorEnableHotkey.TabStop = false;
			this.chk_lockCursorEnableHotkey.Text = "Lock cursor hotkey";
			this.chk_lockCursorEnableHotkey.UseVisualStyleBackColor = true;
			this.chk_lockCursorEnableHotkey.Click += new System.EventHandler(this.chk_lockCursorEnableHotkey_Click);
			// 
			// Fullscreenizer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(369, 387);
			this.Controls.Add(this.gb_lockCursorHotkey);
			this.Controls.Add(this.chk_lockCursorEnableHotkey);
			this.Controls.Add(this.chk_lockCursor);
			this.Controls.Add(this.chk_minimizeToTray);
			this.Controls.Add(this.lbl_website);
			this.Controls.Add(this.gb_fullscreenizeHotkey);
			this.Controls.Add(this.chk_fullscreenizeEnableHotkey);
			this.Controls.Add(this.gb_apps);
			this.Controls.Add(this.lbl_apps);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Fullscreenizer";
			this.Text = "Fullscreenizer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Fullscreenizer_FormClosing);
			this.Resize += new System.EventHandler(this.Fullscreenizer_Resize);
			this.gb_apps.ResumeLayout(false);
			this.gb_apps.PerformLayout();
			this.contextMenuStrip.ResumeLayout(false);
			this.gb_hotkeyModifier.ResumeLayout(false);
			this.gb_hotkeyModifier.PerformLayout();
			this.gb_fullscreenizeHotkey.ResumeLayout(false);
			this.gb_lockCursorHotkey.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_apps;
		private System.Windows.Forms.ListView lv_apps;
		private System.Windows.Forms.Button btn_fullscreenizeApp;
		private System.Windows.Forms.GroupBox gb_apps;
		private System.Windows.Forms.Label lbl_website;
		private System.Windows.Forms.ColumnHeader ch_title;
		private System.Windows.Forms.Button btn_showAllApps;
		private System.Windows.Forms.Button btn_removeApp;
		private System.Windows.Forms.CheckBox chk_scaleToFit;
		private System.Windows.Forms.CheckBox chk_moveWindow;
		private System.Windows.Forms.NotifyIcon notifyIcon;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShow;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClose;
		private System.Windows.Forms.CheckBox chk_minimizeToTray;
        private System.Windows.Forms.CheckBox chk_lockCursor;
        private System.Windows.Forms.CheckBox chk_fullscreenizeEnableHotkey;
        private System.Windows.Forms.GroupBox gb_hotkeyModifier;
        private System.Windows.Forms.CheckBox chk_fullscreenizeHotkeyModAlt;
        private System.Windows.Forms.CheckBox chk_fullscreenizeHotkeyModShift;
        private System.Windows.Forms.CheckBox chk_fullscreenizeHotkeyModCtrl;
        private System.Windows.Forms.ComboBox cb_fullscreenizeHotkeyKey;
        private System.Windows.Forms.GroupBox gb_fullscreenizeHotkey;
        private System.Windows.Forms.GroupBox gb_lockCursorHotkey;
        private System.Windows.Forms.ComboBox cb_lockCursorHotkeyKey;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chk_lockCursorHotkeyModAlt;
        private System.Windows.Forms.CheckBox chk_lockCursorHotkeyModShift;
        private System.Windows.Forms.CheckBox chk_lockCursorHotkeyModCtrl;
        private System.Windows.Forms.CheckBox chk_lockCursorEnableHotkey;
    }
}

