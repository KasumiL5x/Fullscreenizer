using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Fullscreenizer
{
	public partial class Fullscreenizer : Form
	{
		// How often to poll, update, and prune windows.
		const int UPDATE_INTERVAL = 1000;
		// How often a window can be fullscreenized (regardless of window for simplicity). This is double the update
		// interval so that at least one update can run before the next fullscreenize.
		const int FULLSCREENIZE_INTERVAL = UPDATE_INTERVAL * 2;

		Config _config = new Config();
		KeyboardHook _hook = new KeyboardHook();
		Modifier _currHeldModifier = Modifier.None; // Used to check if the user is pressing the correct modifiers.
		Keys _currHeldKey = Keys.None; // Used to check if the user is pressing the correct key.
		

		// All states of windows we are tracking.
		List<AppState> _windowStates = new List<AppState>();
		// Matches window handles to the states in the above list.
		Dictionary<IntPtr, AppState> _windowHandles = new Dictionary<IntPtr,AppState>();
		// Window icons for the tracked handles.
		ImageList _windowImages = new ImageList();
		// Timer for polling, updating, and pruning windows.
		Timer _windowUpdateTimer = new Timer();

		// Timer for allowing a window to be fullscreenized.
		Timer _canFullscreenizeTimer = new Timer();
		bool _canFullscreenize = true;

		public Fullscreenizer()
		{
			InitializeComponent();
			lv_apps.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
			lv_apps.SmallImageList = _windowImages;

			// Add callbacks to the keyboard hook.
			_hook.KeyDown += new KeyEventHandler(hotkeyPressed);
			_hook.KeyUp += new KeyEventHandler(hotkeyReleased);
			// Build a list of keys for the hotkey key combobox.
			buildKeysList();

			// Parse the config file.
			processConfig();

			// Grab the initial windows.
			refreshApps();
			updateListView();

			// Configure the update timer.
			_windowUpdateTimer.Interval = UPDATE_INTERVAL;
			_windowUpdateTimer.Tick += _windowUpdateTimer_Tick;
			_windowUpdateTimer.Start();

			// Configure the fullscreenize timer.
			_canFullscreenizeTimer.Interval = FULLSCREENIZE_INTERVAL;
			_canFullscreenizeTimer.Tick += _canFullscreenizeTimer_Tick;
			_canFullscreenizeTimer.Start();
		}

		void Fullscreenizer_FormClosing(object sender, FormClosingEventArgs e)
		{
			_config.writeConfigFile();
		}

		void Fullscreenizer_Resize(object sender, EventArgs e)
		{
			if (WindowState == FormWindowState.Minimized && chk_minimizeToTray.Checked)
			{
				Hide();
				notifyIcon.Visible = true;
			}
		}

		void chk_fullscreenizeEnableHotkey_Click(object sender, EventArgs e)
		{
			// Flip the hotkey.
			chk_fullscreenizeEnableHotkey.Checked = !chk_fullscreenizeEnableHotkey.Checked;
			// Update the config.
			_config.FullscreenizeHotkeyActive = chk_fullscreenizeEnableHotkey.Checked;
			// Enable or disable based on status.
			if (chk_fullscreenizeEnableHotkey.Checked)
			{
				enableHotkey();
			}
			else
			{
				disableHotkey();
			}
		}

		void chk_fullscreenizeHotkeyModCtrl_Click(object sender, EventArgs e)
		{
			if( !chk_fullscreenizeHotkeyModShift.Checked && !chk_fullscreenizeHotkeyModAlt.Checked )
			{
				return;
			}

			chk_fullscreenizeHotkeyModCtrl.Checked = !chk_fullscreenizeHotkeyModCtrl.Checked;
			updateModifierFlags();
			if( _config.FullscreenizeHotkeyActive )
			{
				enableHotkey();
			}
		}

		void chk_fullscreenizeHotkeyModShift_Click(object sender, EventArgs e)
		{
			if( !chk_fullscreenizeHotkeyModCtrl.Checked && !chk_fullscreenizeHotkeyModAlt.Checked )
			{
				return;
			}

			chk_fullscreenizeHotkeyModShift.Checked = !chk_fullscreenizeHotkeyModShift.Checked;
			updateModifierFlags();
			if( _config.FullscreenizeHotkeyActive )
			{
				enableHotkey();
			}
		}

		void chk_fullscreenizeHotkeyModAlt_Click(object sender, EventArgs e)
		{
			if( !chk_fullscreenizeHotkeyModCtrl.Checked && !chk_fullscreenizeHotkeyModShift.Checked )
			{
				return;
			}

			chk_fullscreenizeHotkeyModAlt.Checked = !chk_fullscreenizeHotkeyModAlt.Checked;
			updateModifierFlags();
			if( _config.FullscreenizeHotkeyActive )
			{
				enableHotkey();
			}
		}

		void cb_fullscreenizeHotkeyKey_SelectionChangeCommitted(object sender, EventArgs e)
		{
			_config.FullscreenizeKeyFlags = (Keys)cb_fullscreenizeHotkeyKey.SelectedItem;
			if (_config.FullscreenizeHotkeyActive)
			{
				enableHotkey();
			}
		}

		private void chk_lockCursorEnableHotkey_Click(object sender, EventArgs e)
		{
			// Flip the hotkey.
			chk_lockCursorEnableHotkey.Checked = !chk_lockCursorEnableHotkey.Checked;
			// Update the config.
			_config.LockCursorHotkeyActive = chk_lockCursorEnableHotkey.Checked;
			// Enable or disable based on status.
			if (chk_lockCursorEnableHotkey.Checked)
			{
				enableHotkey();
			}
			else
			{
				disableHotkey();
			}
		}

		private void chk_lockCursorHotkeyModCtrl_Click(object sender, EventArgs e)
		{
			if (!chk_lockCursorHotkeyModShift.Checked && !chk_lockCursorHotkeyModAlt.Checked)
			{
				return;
			}

			chk_lockCursorHotkeyModCtrl.Checked = !chk_lockCursorHotkeyModCtrl.Checked;
			updateModifierFlags();
			if (_config.LockCursorHotkeyActive)
			{
				enableHotkey();
			}
		}

		private void chk_lockCursorHotkeyModShift_Click(object sender, EventArgs e)
		{
			if (!chk_lockCursorHotkeyModCtrl.Checked && !chk_lockCursorHotkeyModAlt.Checked)
			{
				return;
			}

			chk_lockCursorHotkeyModShift.Checked = !chk_lockCursorHotkeyModShift.Checked;
			updateModifierFlags();
			if (_config.LockCursorHotkeyActive)
			{
				enableHotkey();
			}
		}

		private void chk_lockCursorHotkeyModAlt_Click(object sender, EventArgs e)
		{
			if (!chk_lockCursorHotkeyModCtrl.Checked && !chk_lockCursorHotkeyModShift.Checked)
			{
				return;
			}

			chk_lockCursorHotkeyModAlt.Checked = !chk_lockCursorHotkeyModAlt.Checked;
			updateModifierFlags();
			if (_config.LockCursorHotkeyActive)
			{
				enableHotkey();
			}
		}

		private void cb_lockCursorHotkeyKey_SelectionChangeCommitted(object sender, EventArgs e)
		{
			_config.LockCursorKeyFlags = (Keys)cb_lockCursorHotkeyKey.SelectedItem;
			if( _config.LockCursorHotkeyActive )
			{
				enableHotkey();
			}
		}

		void btn_fullscreenizeApp_Click(object sender, EventArgs e)
		{
			if( lv_apps.SelectedItems.Count == 0 )
			{
				return;
			}

			ListViewItem item = lv_apps.SelectedItems[0];
			fullscreenizeWindow((IntPtr)item.Tag);
		}

		void btn_removeApp_Click(object sender, EventArgs e)
		{
			GC.Collect();
			if( lv_apps.SelectedItems.Count == 0 )
			{
				return;
			}

			ListViewItem item = lv_apps.SelectedItems[0];
			AppState state = _windowHandles[(IntPtr)item.Tag];
			_config.Classes.Remove(state.className);

			refreshApps();
			updateListView();
		}

		void btn_showAllApps_Click(object sender, EventArgs e)
		{
			AllApps frm = new AllApps(_config);
			frm.ShowDialog(this);
			if( frm.AddedClasses )
			{
				refreshApps();
				updateListView();
			}
		}

		void _windowUpdateTimer_Tick(object sender, EventArgs e)
		{
			refreshApps();
			updateListView();
		}

		void _canFullscreenizeTimer_Tick(object sender, EventArgs e)
		{
			_canFullscreenize = true;
		}

		void chk_scaleToFit_CheckedChanged(object sender, EventArgs e)
		{
			_config.ScaleWindow = chk_scaleToFit.Checked;
		}

		void chk_moveWindow_CheckedChanged(object sender, EventArgs e)
		{
			_config.MoveWindow = chk_moveWindow.Checked;
		}

		private void chk_lockCursor_CheckedChanged(object sender, EventArgs e)
		{
			_config.LockCursor = chk_lockCursor.Checked;
		}

		void chk_minimizeToTray_CheckedChanged(object sender, EventArgs e)
		{
			_config.MinimizeToTray = chk_minimizeToTray.Checked;
		}

		void lbl_website_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("https://github.com/KasumiL5x/Fullscreenizer");
		}

		private void toolStripMenuItemShow_Click(object sender, EventArgs e)
		{
			Show();
			WindowState = FormWindowState.Normal;
			notifyIcon.Visible = false;
		}

		private void toolStripMenuItemClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		void processConfig()
		{
			// Read the config file, and if there's an error parsing it, warn the user and exit.
			// This is favorable as it doesn't mean the user loses their config even it if fails.
			if( !_config.readConfigFile() )
			{
				MessageBox.Show("Failed to parse config file. Please fix or delete it.");
				Environment.Exit(-1);
			}

			// Read the modifier bit flag and enable checkboxes as required.
			chk_fullscreenizeHotkeyModCtrl.Checked  = ((_config.FullscreenizeModifierFlags & Modifier.Ctrl) != 0);
			chk_fullscreenizeHotkeyModShift.Checked = ((_config.FullscreenizeModifierFlags & Modifier.Shift) != 0);
			chk_fullscreenizeHotkeyModAlt.Checked   = ((_config.FullscreenizeModifierFlags & Modifier.Alt) != 0);
			chk_lockCursorHotkeyModCtrl.Checked     = ((_config.LockCursorModifierFlags & Modifier.Ctrl) != 0);
			chk_lockCursorHotkeyModShift.Checked    = ((_config.LockCursorModifierFlags & Modifier.Shift) != 0);
			chk_lockCursorHotkeyModAlt.Checked      = ((_config.LockCursorModifierFlags & Modifier.Alt) != 0);

			// Read the key bit flag and set the comboboxes as required.
			cb_fullscreenizeHotkeyKey.SelectedItem = _config.FullscreenizeKeyFlags;
			cb_lockCursorHotkeyKey.SelectedItem = _config.LockCursorKeyFlags;

			// Read the active state of the hotkey and create the hotkey if required.
			if ( _config.FullscreenizeHotkeyActive )
			{
				chk_fullscreenizeEnableHotkey.Checked = true;
				enableHotkey();
			}

			if (_config.FullscreenizeHotkeyActive)
			{
				chk_lockCursorEnableHotkey.Checked = true;
				enableHotkey();
			}

			// Read the options.
			chk_scaleToFit.Checked     = _config.ScaleWindow;
			chk_moveWindow.Checked     = _config.MoveWindow;
			chk_lockCursor.Checked     = _config.LockCursor;
			chk_minimizeToTray.Checked = _config.MinimizeToTray;
		}

		void buildKeysList()
		{
			List<Keys> keyDict = new List<Keys>();
			keyDict.Add(Keys.A);
			keyDict.Add(Keys.B);
			keyDict.Add(Keys.C);
			keyDict.Add(Keys.D);
			keyDict.Add(Keys.E);
			keyDict.Add(Keys.F);
			keyDict.Add(Keys.G);
			keyDict.Add(Keys.H);
			keyDict.Add(Keys.I);
			keyDict.Add(Keys.J);
			keyDict.Add(Keys.K);
			keyDict.Add(Keys.L);
			keyDict.Add(Keys.M);
			keyDict.Add(Keys.N);
			keyDict.Add(Keys.O);
			keyDict.Add(Keys.P);
			keyDict.Add(Keys.Q);
			keyDict.Add(Keys.R);
			keyDict.Add(Keys.S);
			keyDict.Add(Keys.T);
			keyDict.Add(Keys.U);
			keyDict.Add(Keys.V);
			keyDict.Add(Keys.W);
			keyDict.Add(Keys.X);
			keyDict.Add(Keys.Y);
			keyDict.Add(Keys.Z);
			keyDict.Add(Keys.D1);
			keyDict.Add(Keys.D2);
			keyDict.Add(Keys.D3);
			keyDict.Add(Keys.D4);
			keyDict.Add(Keys.D5);
			keyDict.Add(Keys.D6);
			keyDict.Add(Keys.D7);
			keyDict.Add(Keys.D8);
			keyDict.Add(Keys.D9);
			keyDict.Add(Keys.D0);
			keyDict.Add(Keys.F1);
			keyDict.Add(Keys.F2);
			keyDict.Add(Keys.F3);
			keyDict.Add(Keys.F4);
			keyDict.Add(Keys.F5);
			keyDict.Add(Keys.F6);
			keyDict.Add(Keys.F7);
			keyDict.Add(Keys.F8);
			keyDict.Add(Keys.F9);
			keyDict.Add(Keys.F10);
			keyDict.Add(Keys.F11);
			keyDict.Add(Keys.F12);
			keyDict.Add(Keys.Insert);
			keyDict.Add(Keys.Delete);
			keyDict.Add(Keys.Home);
			keyDict.Add(Keys.End);
			keyDict.Add(Keys.PageUp);
			keyDict.Add(Keys.PageDown);
			cb_fullscreenizeHotkeyKey.DataSource = new BindingSource(keyDict, null);
			cb_lockCursorHotkeyKey.DataSource = new BindingSource(keyDict, null);
		}

		void updateModifierFlags()
		{
			_config.FullscreenizeModifierFlags = Modifier.None;
			if( chk_fullscreenizeHotkeyModCtrl.Checked )
			{
				_config.FullscreenizeModifierFlags |= Modifier.Ctrl;
			}
			if( chk_fullscreenizeHotkeyModShift.Checked )
			{
				_config.FullscreenizeModifierFlags |= Modifier.Shift;
			}
			if( chk_fullscreenizeHotkeyModAlt.Checked )
			{
				_config.FullscreenizeModifierFlags |= Modifier.Alt;
			}

			_config.LockCursorModifierFlags = Modifier.None;
			if( chk_lockCursorHotkeyModCtrl.Checked )
			{
				_config.LockCursorModifierFlags |= Modifier.Ctrl;
			}
			if( chk_lockCursorHotkeyModShift.Checked )
			{
				_config.LockCursorModifierFlags |= Modifier.Shift;
			}
			if( chk_lockCursorHotkeyModAlt.Checked )
			{
				_config.LockCursorModifierFlags |= Modifier.Alt;
			}
		}

		void hotkeyPressed( object sender, KeyEventArgs e )
		{
			// Append the currently held modifiers bit flag if any of the considered keys are pressed.
			if( e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey )
			{
				_currHeldModifier |= Modifier.Ctrl;
			}
			else if( e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey )
			{
				_currHeldModifier |= Modifier.Shift;
			}
			else if( e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu )
			{
				_currHeldModifier |= Modifier.Alt;
			}
			else if( e.KeyCode == _config.FullscreenizeKeyFlags || e.KeyCode == _config.LockCursorKeyFlags )
			{
				// Also for the key, too.
				_currHeldKey = e.KeyCode;
			}

			// Do we care about the modifiers?
			bool careAboutCtrl = (_config.FullscreenizeModifierFlags & Modifier.Ctrl) != 0 || (_config.LockCursorModifierFlags & Modifier.Ctrl) != 0;
			bool careAboutShift = (_config.FullscreenizeModifierFlags & Modifier.Shift) != 0 || (_config.LockCursorModifierFlags & Modifier.Shift) != 0;
			bool careAboutAlt = (_config.FullscreenizeModifierFlags & Modifier.Alt) != 0 || (_config.LockCursorModifierFlags & Modifier.Alt) != 0;
			// The actual currently held values.
			bool ctrlPressed = (_currHeldModifier & Modifier.Ctrl) != 0;
			bool shiftPressed = (_currHeldModifier & Modifier.Shift) != 0;
			bool altPressed = (_currHeldModifier & Modifier.Alt) != 0;

			// If we care and it's pressed, or we don't care, it's OK.
			bool ctrlOk = (careAboutCtrl && ctrlPressed) || (!careAboutCtrl);
			bool shiftOk = (careAboutShift && shiftPressed) || (!careAboutShift);
			bool altOk = (careAboutAlt && altPressed) || (!careAboutAlt);

			IntPtr foregroundWindow = Win32.getForegroundWindow();
			if ( foregroundWindow == IntPtr.Zero )
			{
				return;
			}

			// If all are OK and the held key matches out desired key...
			if( ctrlOk && shiftOk && altOk && (_currHeldKey == _config.FullscreenizeKeyFlags) )
			{
				fullscreenizeWindow(foregroundWindow);
			}

			if( ctrlOk && shiftOk && altOk && (_currHeldKey == _config.LockCursorKeyFlags) )
			{
				Win32.getWindowRect(foregroundWindow, out int x, out int y, out int width, out int height );

				// The cursor was already locked to the window bounds, unlock it
				if( Cursor.Clip.Equals(new Rectangle(x, y, width, height)) )
				{
					Cursor.Clip = Rectangle.Empty;
				}
				// Lock the cursor to the window bounds
				else
				{
					Cursor.Clip = new Rectangle(x, y, width, height);
				}
			}
		}

		void hotkeyReleased( object sender, KeyEventArgs e )
		{
			// Not the modifiers if they were released.
			if( e.KeyCode == Keys.LControlKey || e.KeyCode == Keys.RControlKey )
			{
				_currHeldModifier = _currHeldModifier & ~Modifier.Ctrl;
			}
			else if( e.KeyCode == Keys.LShiftKey || e.KeyCode == Keys.RShiftKey )
			{
				_currHeldModifier = _currHeldModifier & ~Modifier.Shift;
			}
			else if( e.KeyCode == Keys.LMenu || e.KeyCode == Keys.RMenu )
			{
				_currHeldModifier = _currHeldModifier & ~Modifier.Alt;
			}
			else if( e.KeyCode == _config.FullscreenizeKeyFlags || e.KeyCode == _config.LockCursorKeyFlags )
			{
				// Same for the keycode.
				_currHeldKey = _currHeldKey & ~e.KeyCode;
			}
		}

		void enableHotkey()
		{
			_hook.hook();
			_hook.removeAllKeys();

			if( (_config.FullscreenizeModifierFlags & Modifier.Ctrl) != 0 || (_config.LockCursorModifierFlags & Modifier.Ctrl) != 0 )
			{
				_hook.addKey(Keys.LControlKey);
				_hook.addKey(Keys.RControlKey);
			}
			if( (_config.FullscreenizeModifierFlags & Modifier.Shift) != 0 || (_config.LockCursorModifierFlags & Modifier.Shift) != 0 )
			{
				_hook.addKey(Keys.LShiftKey);
				_hook.addKey(Keys.RShiftKey);
			}
			if( (_config.FullscreenizeModifierFlags & Modifier.Alt) != 0 || (_config.LockCursorModifierFlags & Modifier.Alt) != 0 )
			{
				_hook.addKey(Keys.LMenu);
				_hook.addKey(Keys.RMenu);
			}

			if( _config.FullscreenizeHotkeyActive )
			{
				_hook.addKey(_config.FullscreenizeKeyFlags);
			}
			if ( _config.LockCursorHotkeyActive )
			{
				_hook.addKey(_config.LockCursorKeyFlags);
			}
	}

	void disableHotkey()
		{
			_hook.unhook(); // Doesn't remove keys; just disables.
		}

		void refreshApps()
		{
			List<IntPtr> visibleWindows = Win32.getVisibleWindows(true);
			foreach( IntPtr hwnd in visibleWindows )
			{
				if( _windowHandles.ContainsKey(hwnd) )
				{
					continue;
				}

				// Ignore classes that aren't in the Classes list.
				string className = Win32.getClassName(hwnd);
				if( !_config.Classes.Contains(className) )
				{
					continue;
				}

				AppState state = new AppState();
				state.windowText = Win32.getWindowText(hwnd);
				state.className = className;
				state.image = Win32.getIcon(hwnd);
				
				_windowStates.Add(state);
				_windowHandles[hwnd] = state;
			}

			List<KeyValuePair<IntPtr, AppState>> handlesToRemove = new List<KeyValuePair<IntPtr,AppState>>();
			foreach( KeyValuePair<IntPtr, AppState> window in _windowHandles )
			{
				// If the visible windows list doesn't contain the current window's HWND...
				if( !visibleWindows.Contains(window.Key) )
				{
					handlesToRemove.Add(window);
					continue;
				}

				// If the window handle is registered but the class name is no longer in the Classes list...
				// (this happens when removing)
				if( _windowHandles.ContainsKey(window.Key) && !_config.Classes.Contains(window.Value.className) )
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

		void updateListView()
		{
			lv_apps.BeginUpdate();
			
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
				if( !_windowHandles.ContainsKey((IntPtr)lv_apps.Items[i].Tag) )
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

		void rebuildImageList()
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

		void fullscreenizeWindow( IntPtr hwnd )
		{
			if( !_canFullscreenize )
			{
				return;
			}

			if( !_windowHandles.ContainsKey(hwnd) )
			{
				return;
			}

			AppState state = _windowHandles[hwnd];

			bool isFullscreen = Win32.isWindowFullscreen(hwnd);
			bool isBorderless = Win32.isWindowBorderlessStyle(hwnd);

			// If the window is fullscreen but not borderless, it is most likely in actual fullscreen mode, so we don't
			// want to try to touch it.
			if( isFullscreen && !isBorderless )
			{
				return;
			}

			// Used to check for fullscreen here, too, but now we allow for no scaling, so don't check it.
			if( isBorderless )
			{
				// If borderless, but the state is invalid (no initial information), ignore the request.
				// This can happen if the window we're tracking started out borderless or was made borderless by another
				// program.
				if( !state.isValid() )
				{
					return;
				}
				// Restore the window back to its initial style, position, and size.
				Win32.setWindowStyle(hwnd, state.originalStyle);
				Win32.setWindowPos(hwnd, state.initialX, state.initialY, state.initialWidth, state.initialHeight, Win32.SetWindowPosFlags.SWP_FRAMECHANGED);

				// Unlock the cursor
				Cursor.Clip = Rectangle.Empty;
			}
			else
			{
				// Get the initial window settings before fullscreening. We do this every time as the user may want it
				// on a certain monitor, thus the position would change. The user could also have changed the resolution
				// in-game since we detected the window, and so on.
				state.originalStyle = Win32.getWindowStyle(hwnd);
				Win32.getWindowRect(hwnd, out state.initialX, out state.initialY, out state.initialWidth, out state.initialHeight);

				// Get the size and position of the monitor the window is open on.
				int monitorX = 0;
				int monitorY = 0;
				int monitorWidth = 0;
				int monitorHeight = 0;
				Win32.getWindowMonitorSize(hwnd, out monitorX, out monitorY, out monitorWidth, out monitorHeight);
				// Make the window borderless.
				Win32.makeWindowBorderless(hwnd);

				if( chk_lockCursor.Checked )
				{
					// Lock the cursor to the window bounds
					Cursor.Clip = new Rectangle(state.initialX, state.initialY, state.initialWidth, state.initialHeight);
				}

				if( chk_scaleToFit.Checked && chk_moveWindow.Checked )
				{
					// Move the window to the top-left of the monitor and scale it to fill.
					Win32.setWindowPos(hwnd, monitorX, monitorY, monitorWidth, monitorHeight, Win32.SetWindowPosFlags.SWP_FRAMECHANGED);
				}
				else if( chk_scaleToFit.Checked && !chk_moveWindow.Checked )
				{
					// Only scale the window to fill and don't change the position.
					Win32.setWindowPos(hwnd, monitorX, monitorY, monitorWidth, monitorHeight, Win32.SetWindowPosFlags.SWP_NOREPOSITION);
				}
				else if( !chk_scaleToFit.Checked && chk_moveWindow.Checked )
				{
					// Only move the window and don't scale it.
					Win32.setWindowPos(hwnd, monitorX, monitorY, monitorWidth, monitorHeight, Win32.SetWindowPosFlags.SWP_NOSIZE);
				}
				// Otherwise, don't do anything.
			}

			_canFullscreenize = false;
		}

		private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				Show();
				WindowState = FormWindowState.Normal;
				notifyIcon.Visible = false;
			}
		}
	}
}
