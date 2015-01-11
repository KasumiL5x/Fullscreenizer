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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fullscreenizer));
			this.lbl_apps = new System.Windows.Forms.Label();
			this.lv_apps = new System.Windows.Forms.ListView();
			this.ch_title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btn_fullscreenizeApp = new System.Windows.Forms.Button();
			this.gb_apps = new System.Windows.Forms.GroupBox();
			this.btn_removeApp = new System.Windows.Forms.Button();
			this.btn_showAllApps = new System.Windows.Forms.Button();
			this.chk_enableHotkey = new System.Windows.Forms.CheckBox();
			this.gb_hotkey = new System.Windows.Forms.GroupBox();
			this.cb_hotkeyKey = new System.Windows.Forms.ComboBox();
			this.gb_hotkeyModifier = new System.Windows.Forms.GroupBox();
			this.chk_hotkeyModAlt = new System.Windows.Forms.CheckBox();
			this.chk_hotkeyModShift = new System.Windows.Forms.CheckBox();
			this.chk_hotkeyModCtrl = new System.Windows.Forms.CheckBox();
			this.lbl_website = new System.Windows.Forms.Label();
			this.gb_apps.SuspendLayout();
			this.gb_hotkey.SuspendLayout();
			this.gb_hotkeyModifier.SuspendLayout();
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
			// btn_removeApp
			// 
			this.btn_removeApp.Location = new System.Drawing.Point(207, 169);
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
			// chk_enableHotkey
			// 
			this.chk_enableHotkey.AutoCheck = false;
			this.chk_enableHotkey.AutoSize = true;
			this.chk_enableHotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.chk_enableHotkey.Location = new System.Drawing.Point(16, 236);
			this.chk_enableHotkey.Name = "chk_enableHotkey";
			this.chk_enableHotkey.Size = new System.Drawing.Size(87, 28);
			this.chk_enableHotkey.TabIndex = 9;
			this.chk_enableHotkey.TabStop = false;
			this.chk_enableHotkey.Text = "Hotkey";
			this.chk_enableHotkey.UseVisualStyleBackColor = true;
			this.chk_enableHotkey.Click += new System.EventHandler(this.chk_enableHotkey_Click);
			// 
			// gb_hotkey
			// 
			this.gb_hotkey.Controls.Add(this.cb_hotkeyKey);
			this.gb_hotkey.Controls.Add(this.gb_hotkeyModifier);
			this.gb_hotkey.Location = new System.Drawing.Point(16, 261);
			this.gb_hotkey.Name = "gb_hotkey";
			this.gb_hotkey.Size = new System.Drawing.Size(342, 47);
			this.gb_hotkey.TabIndex = 10;
			this.gb_hotkey.TabStop = false;
			// 
			// cb_hotkeyKey
			// 
			this.cb_hotkeyKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_hotkeyKey.FormattingEnabled = true;
			this.cb_hotkeyKey.Location = new System.Drawing.Point(151, 17);
			this.cb_hotkeyKey.Name = "cb_hotkeyKey";
			this.cb_hotkeyKey.Size = new System.Drawing.Size(183, 21);
			this.cb_hotkeyKey.TabIndex = 11;
			this.cb_hotkeyKey.TabStop = false;
			this.cb_hotkeyKey.SelectionChangeCommitted += new System.EventHandler(this.cb_hotkeyKey_SelectionChangeCommitted);
			// 
			// gb_hotkeyModifier
			// 
			this.gb_hotkeyModifier.Controls.Add(this.chk_hotkeyModAlt);
			this.gb_hotkeyModifier.Controls.Add(this.chk_hotkeyModShift);
			this.gb_hotkeyModifier.Controls.Add(this.chk_hotkeyModCtrl);
			this.gb_hotkeyModifier.Location = new System.Drawing.Point(6, 9);
			this.gb_hotkeyModifier.Name = "gb_hotkeyModifier";
			this.gb_hotkeyModifier.Size = new System.Drawing.Size(139, 29);
			this.gb_hotkeyModifier.TabIndex = 11;
			this.gb_hotkeyModifier.TabStop = false;
			// 
			// chk_hotkeyModAlt
			// 
			this.chk_hotkeyModAlt.AutoCheck = false;
			this.chk_hotkeyModAlt.AutoSize = true;
			this.chk_hotkeyModAlt.Location = new System.Drawing.Point(100, 10);
			this.chk_hotkeyModAlt.Name = "chk_hotkeyModAlt";
			this.chk_hotkeyModAlt.Size = new System.Drawing.Size(37, 17);
			this.chk_hotkeyModAlt.TabIndex = 0;
			this.chk_hotkeyModAlt.TabStop = false;
			this.chk_hotkeyModAlt.Text = "alt";
			this.chk_hotkeyModAlt.UseVisualStyleBackColor = true;
			this.chk_hotkeyModAlt.Click += new System.EventHandler(this.chk_hotkeyModAlt_Click);
			// 
			// chk_hotkeyModShift
			// 
			this.chk_hotkeyModShift.AutoCheck = false;
			this.chk_hotkeyModShift.AutoSize = true;
			this.chk_hotkeyModShift.Location = new System.Drawing.Point(49, 10);
			this.chk_hotkeyModShift.Name = "chk_hotkeyModShift";
			this.chk_hotkeyModShift.Size = new System.Drawing.Size(45, 17);
			this.chk_hotkeyModShift.TabIndex = 0;
			this.chk_hotkeyModShift.TabStop = false;
			this.chk_hotkeyModShift.Text = "shift";
			this.chk_hotkeyModShift.UseVisualStyleBackColor = true;
			this.chk_hotkeyModShift.Click += new System.EventHandler(this.chk_hotkeyModShift_Click);
			// 
			// chk_hotkeyModCtrl
			// 
			this.chk_hotkeyModCtrl.AutoCheck = false;
			this.chk_hotkeyModCtrl.AutoSize = true;
			this.chk_hotkeyModCtrl.Checked = true;
			this.chk_hotkeyModCtrl.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk_hotkeyModCtrl.Location = new System.Drawing.Point(5, 10);
			this.chk_hotkeyModCtrl.Name = "chk_hotkeyModCtrl";
			this.chk_hotkeyModCtrl.Size = new System.Drawing.Size(40, 17);
			this.chk_hotkeyModCtrl.TabIndex = 0;
			this.chk_hotkeyModCtrl.TabStop = false;
			this.chk_hotkeyModCtrl.Text = "ctrl";
			this.chk_hotkeyModCtrl.UseVisualStyleBackColor = true;
			this.chk_hotkeyModCtrl.Click += new System.EventHandler(this.chk_hotkeyModCtrl_Click);
			// 
			// lbl_website
			// 
			this.lbl_website.AutoSize = true;
			this.lbl_website.Cursor = System.Windows.Forms.Cursors.Hand;
			this.lbl_website.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_website.Location = new System.Drawing.Point(272, 9);
			this.lbl_website.Name = "lbl_website";
			this.lbl_website.Size = new System.Drawing.Size(85, 13);
			this.lbl_website.TabIndex = 12;
			this.lbl_website.Text = "www.ngreen.org";
			this.lbl_website.Click += new System.EventHandler(this.lbl_website_Click);
			// 
			// Fullscreenizer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(369, 315);
			this.Controls.Add(this.lbl_website);
			this.Controls.Add(this.gb_hotkey);
			this.Controls.Add(this.chk_enableHotkey);
			this.Controls.Add(this.gb_apps);
			this.Controls.Add(this.lbl_apps);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "Fullscreenizer";
			this.Text = "Fullscreenizer";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Fullscreenizer_FormClosing);
			this.gb_apps.ResumeLayout(false);
			this.gb_hotkey.ResumeLayout(false);
			this.gb_hotkeyModifier.ResumeLayout(false);
			this.gb_hotkeyModifier.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_apps;
		private System.Windows.Forms.ListView lv_apps;
		private System.Windows.Forms.Button btn_fullscreenizeApp;
		private System.Windows.Forms.GroupBox gb_apps;
		private System.Windows.Forms.CheckBox chk_enableHotkey;
		private System.Windows.Forms.GroupBox gb_hotkey;
		private System.Windows.Forms.ComboBox cb_hotkeyKey;
		private System.Windows.Forms.GroupBox gb_hotkeyModifier;
		private System.Windows.Forms.CheckBox chk_hotkeyModAlt;
		private System.Windows.Forms.CheckBox chk_hotkeyModShift;
		private System.Windows.Forms.CheckBox chk_hotkeyModCtrl;
		private System.Windows.Forms.Label lbl_website;
		private System.Windows.Forms.ColumnHeader ch_title;
		private System.Windows.Forms.Button btn_showAllApps;
		private System.Windows.Forms.Button btn_removeApp;
	}
}

