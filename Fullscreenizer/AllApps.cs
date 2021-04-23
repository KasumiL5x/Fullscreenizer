using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Fullscreenizer
{
	public partial class AllApps : Form
	{
		List<AppState> _windowStates = new List<AppState>();
		Dictionary<IntPtr, AppState> _windowHandles = new Dictionary<IntPtr,AppState>();
		ImageList _windowImages = new ImageList();
		Timer _updateTimer = new Timer();
		bool _addedClasses = false;
		Config _config = null; // Not owned by this form.

		public bool AddedClasses
		{
			get{ return _addedClasses; }
		}

		public AllApps( Config config )
		{
			_config = config;

			InitializeComponent();
			lv_apps.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			lv_apps.SmallImageList = _windowImages;

			_updateTimer.Tick += _updateTimer_Tick;
			_updateTimer.Interval = 1000;
			_updateTimer.Start();
		}

		private void _updateTimer_Tick(object sender, EventArgs e)
		{
			refreshApps();
			updateListView();
		}

		private void AllApps_Load(object sender, System.EventArgs e)
		{
			refreshApps();
			updateListView();
		}

		private void btn_addApp_Click(object sender, EventArgs e)
		{
			if( lv_apps.SelectedItems.Count == 0 )
			{
				return;
			}

			foreach (ListViewItem item in lv_apps.SelectedItems)
			{
				AppState state = _windowHandles[(IntPtr)item.Tag];
				if( !_config.Classes.Contains(state.className) )
				{
					_config.Classes.Add(state.className);
				}
			}

			_addedClasses = true;
		}

		private void lv_apps_DoubleClick(object sender, EventArgs e)
		{
			btn_addApp.PerformClick();
			Close();
		}

		private void txt_filter_TextChanged(object sender, EventArgs e)
		{
			updateListView();
		}

		private void txt_filter_KeyDown(object sender, KeyEventArgs e)
		{
			if( e.KeyCode == Keys.Escape )
			{
				txt_filter.Clear();
			}
		}

		private void refreshApps()
		{
			List<IntPtr> visibleWindows = Win32.getVisibleWindows(true);
			foreach( IntPtr hwnd in visibleWindows )
			{
				if( _windowHandles.ContainsKey(hwnd) )
				{
					continue;
				}

				AppState state = new AppState();
				state.windowText = Win32.getWindowText(hwnd);
				state.className = Win32.getClassName(hwnd);
				state.image = Win32.getIcon(hwnd);
				_windowStates.Add(state);
				_windowHandles[hwnd] = state;
			}

			List<KeyValuePair<IntPtr, AppState>> handlesToRemove = new List<KeyValuePair<IntPtr, AppState>>();
			foreach( KeyValuePair<IntPtr, AppState> window in _windowHandles )
			{
				if( !visibleWindows.Contains(window.Key) )
				{
					handlesToRemove.Add(window);
					continue;
				}

				window.Value.windowText = Win32.getWindowText(window.Key);
			}
			foreach( KeyValuePair<IntPtr, AppState> window in handlesToRemove )
			{
				_windowStates.Remove(window.Value);
				_windowHandles.Remove(window.Key);
			}
		}

		private void updateListView()
		{
			lv_apps.BeginUpdate();

			bool shouldFilter = !string.IsNullOrWhiteSpace(txt_filter.Text);
			string filterText = txt_filter.Text.ToLower();

			bool shouldRebuildImages = false;

			// Add new window handles to the list view.
			foreach( KeyValuePair<IntPtr, AppState> window in _windowHandles )
			{
				if( lv_apps.Items.ContainsKey(window.Key.ToString()) )
				{
					continue;
				}

				ListViewItem item = new ListViewItem();
				item.Name = window.Key.ToString();
				item.Text = window.Value.windowText;
				item.Tag = window.Key;
				lv_apps.Items.Add(item);

				shouldRebuildImages = true;
			}

			for( int i = lv_apps.Items.Count-1; i >= 0; --i )
			{
				if( !_windowHandles.ContainsKey((IntPtr)lv_apps.Items[i].Tag) ||
					  (shouldFilter && !lv_apps.Items[i].Text.ToLower().Contains(filterText)) )
				{
					lv_apps.Items.RemoveAt(i);
					shouldRebuildImages = true;
					continue;
				}

				lv_apps.Items[i].Text = _windowHandles[(IntPtr)lv_apps.Items[i].Tag].windowText;
			}

			if( shouldRebuildImages )
			{
				rebuildImageList();
			}

			lv_apps.EndUpdate();
		}

		private void rebuildImageList()
		{
			_windowImages.Images.Clear();
			foreach( ListViewItem item in lv_apps.Items )
			{
				AppState state = _windowHandles[(IntPtr)item.Tag];
				if( state.image == null )
				{
					continue;
				}
				_windowImages.Images.Add(state.image);
				item.ImageIndex = _windowImages.Images.Count - 1;
			}
		}
	}
}
