namespace Fullscreenizer
{
	partial class AllApps
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllApps));
			this.lv_apps = new System.Windows.Forms.ListView();
			this.ch_title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btn_addApp = new System.Windows.Forms.Button();
			this.gb_apps = new System.Windows.Forms.GroupBox();
			this.txt_filter = new System.Windows.Forms.TextBox();
			this.gb_apps.SuspendLayout();
			this.SuspendLayout();
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
			this.lv_apps.Size = new System.Drawing.Size(328, 180);
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
			// btn_addApp
			// 
			this.btn_addApp.Location = new System.Drawing.Point(6, 200);
			this.btn_addApp.Name = "btn_addApp";
			this.btn_addApp.Size = new System.Drawing.Size(104, 23);
			this.btn_addApp.TabIndex = 1;
			this.btn_addApp.TabStop = false;
			this.btn_addApp.Text = "Add";
			this.btn_addApp.UseVisualStyleBackColor = true;
			this.btn_addApp.Click += new System.EventHandler(this.btn_addApp_Click);
			// 
			// gb_apps
			// 
			this.gb_apps.Controls.Add(this.txt_filter);
			this.gb_apps.Controls.Add(this.btn_addApp);
			this.gb_apps.Controls.Add(this.lv_apps);
			this.gb_apps.Location = new System.Drawing.Point(7, 1);
			this.gb_apps.Name = "gb_apps";
			this.gb_apps.Size = new System.Drawing.Size(342, 230);
			this.gb_apps.TabIndex = 1;
			this.gb_apps.TabStop = false;
			// 
			// txt_filter
			// 
			this.txt_filter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_filter.ForeColor = System.Drawing.SystemColors.GrayText;
			this.txt_filter.Location = new System.Drawing.Point(116, 200);
			this.txt_filter.Name = "txt_filter";
			this.txt_filter.Size = new System.Drawing.Size(218, 23);
			this.txt_filter.TabIndex = 2;
			this.txt_filter.TextChanged += new System.EventHandler(this.txt_filter_TextChanged);
			this.txt_filter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_filter_KeyDown);
			// 
			// AllApps
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(355, 236);
			this.Controls.Add(this.gb_apps);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "AllApps";
			this.Load += new System.EventHandler(this.AllApps_Load);
			this.gb_apps.ResumeLayout(false);
			this.gb_apps.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btn_addApp;
		private System.Windows.Forms.ListView lv_apps;
		private System.Windows.Forms.ColumnHeader ch_title;
		private System.Windows.Forms.GroupBox gb_apps;
		private System.Windows.Forms.TextBox txt_filter;
	}
}