using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Fullscreenizer
{
    /**
	 * Config format:
	 *     | bool   | default to false | If the fullscreenize hotkey is activated upon load.
	 *     | int    | default to 0     | Bit flag for the modifier of the fullscreenize hotkey modifier(s).
	 *     | int    | default to 0     | Bit flag for the key of the fullscreenize hotkey.
	 *     | bool   | default to false | If the lock cursor hotkey is activated upon load.
	 *     | int    | default to 0     | Bit flag for the modifier of the lock cursor hotkey modifier(s).
	 *     | int    | default to 0     | Bit flag for the key of the lock cursor hotkey.
	 *     | bool   | default to true  | Scale the window when fullscreenizing.
	 *     | bool   | default to true  | Move the window to the top-left when fullscreenizing.
	 *     | bool   | default to true  | Lock the cursor to the application's window.
	 *     | bool   | default to true  | Minimize the application to tray.
	 *     | string | default to none  | All following lines are read as window classes to look for.
	 */
    public class Config
	{
		private const string CONFIG_FILE = "fullscreenizer.cfg";

		private bool _fullscreenizeHotkeyActive;
		public bool FullscreenizeHotkeyActive
		{
			get{ return _fullscreenizeHotkeyActive; }
			set{ _fullscreenizeHotkeyActive = value; }
		}

		private Modifier _fullscreenizeModifierFlags;
		public Modifier FullscreenizeModifierFlags
		{
			get{ return _fullscreenizeModifierFlags; }
			set{ _fullscreenizeModifierFlags = value; }
		}

		private Keys _fullscreenizeKeyFlags;
		public Keys FullscreenizeKeyFlags
		{
			get{ return _fullscreenizeKeyFlags; }
			set{ _fullscreenizeKeyFlags = value; }
		}

		private bool _lockCursorHotkeyActive;
		public bool LockCursorHotkeyActive
		{
			get{ return _lockCursorHotkeyActive; }
			set{ _lockCursorHotkeyActive = value; }
		}

		private Modifier _lockCursorModifierFlags;
		public Modifier LockCursorModifierFlags
		{
			get{ return _lockCursorModifierFlags; }
			set{ _lockCursorModifierFlags = value; }
		}

		private Keys _lockCursorKeyFlags;
		public Keys LockCursorKeyFlags
		{
			get{ return _lockCursorKeyFlags; }
			set{ _lockCursorKeyFlags = value; }
		}

		private bool _scaleWindow;
		public bool ScaleWindow
		{
			get{ return _scaleWindow; }
			set{ _scaleWindow = value; }
		}

		private bool _moveWindow;
		public bool MoveWindow
		{
			get{ return _moveWindow; }
			set{ _moveWindow = value; }
		}

		private bool _lockCursor;
		public bool LockCursor
		{
			get{ return _lockCursor; }
			set{ _lockCursor = value; }
		}

		private bool _minimizeToTray;
		public bool MinimizeToTray
		{
			get{ return _minimizeToTray; }
			set{ _minimizeToTray = value; }
		}

		private List<string> _classes = new List<string>();
		public List<string> Classes
		{
			get{ return _classes; }
			set{ _classes = value; }
		}

		public void reset()
		{
			_fullscreenizeHotkeyActive = false;
			_fullscreenizeModifierFlags = Modifier.Ctrl;
			_fullscreenizeKeyFlags = Keys.Home;
			_lockCursorHotkeyActive = false;
			_lockCursorModifierFlags = Modifier.Ctrl;
			_lockCursorKeyFlags = Keys.End;
			_scaleWindow = true;
			_moveWindow = true;
			_lockCursor = true;
			_minimizeToTray = true;
			_classes.Clear();
		}

		public bool readConfigFile()
		{
			reset();

			// If the config file couldn't be found, create a default config file.
			if( !File.Exists(CONFIG_FILE) )
			{
				createDefaultConfig();
			}

			// Read the hotkey and classes from the config file.
			StreamReader sr = new StreamReader(new FileStream(CONFIG_FILE, FileMode.Open));
			if( !readFullscreenizeHotkeyPart(sr) )
			{
				return false;
			}
			if( !readLockCursorHotkeyPart(sr) )
			{
				return false;
			}
			if( !readOptionsPart(sr) )
			{
				return false;
			}
			readClassesPart(sr);
			sr.Close();

			return true;
		}

		private bool readFullscreenizeHotkeyPart( StreamReader sr )
		{
			// One string used for all parameters.  If this is null after reading a line, there was no contents to read.
			string line = null;

			// Read the active status of the fullscreenize hotkey.
			if( ((line = sr.ReadLine()) == null) || !bool.TryParse(line, out _fullscreenizeHotkeyActive) )
			{
				return false;
			}

			// Read the fullscreenize hotkey modifier flags.
			int tmpModifier = 0;
			if( ((line = sr.ReadLine()) == null) || !int.TryParse(line, out tmpModifier) )
			{
				return false;
			}
			_fullscreenizeModifierFlags = (Modifier)tmpModifier;

			// Read the fullscreenize hotkey key flag.
			int tmpKey = 0;
			if( ((line = sr.ReadLine()) == null) || !int.TryParse(line, out tmpKey) )
			{
				return false;
			}
			_fullscreenizeKeyFlags = (Keys)tmpKey;

			// If no modifier or no key is provided, fail.
			if( _fullscreenizeModifierFlags == Modifier.None || _fullscreenizeKeyFlags == 0 )
			{
				return false;
			}
			
			return true;
		}

        private bool readLockCursorHotkeyPart( StreamReader sr )
		{
			// One string used for all parameters.  If this is null after reading a line, there was no contents to read.
			string line = null;

			// Read the active status of the lock cursor hotkey.
			if( ((line = sr.ReadLine()) == null) || !bool.TryParse(line, out _lockCursorHotkeyActive) )
			{
				return false;
			}

			// Read the lock cursor hotkey modifier flags.
			int tmpModifier = 0;
			if( ((line = sr.ReadLine()) == null) || !int.TryParse(line, out tmpModifier) )
			{
				return false;
			}
			_lockCursorModifierFlags = (Modifier)tmpModifier;

			// Read the lock cursor hotkey key flag.
			int tmpKey = 0;
			if( ((line = sr.ReadLine()) == null) || !int.TryParse(line, out tmpKey) )
			{
				return false;
			}
			_lockCursorKeyFlags = (Keys)tmpKey;

			// If no modifier or no key is provided, fail.
			if( _lockCursorModifierFlags == Modifier.None || _lockCursorKeyFlags == 0 )
			{
				return false;
			}

			// If the lock cursor key is the same than the fullscreenize key, fail.
			if( _lockCursorKeyFlags == _fullscreenizeKeyFlags)
			{
				return false;
			}

			return true;
		}

		private bool readOptionsPart( StreamReader sr )
		{
			string line = null;

			// Read scale window.
			if( ((line = sr.ReadLine()) == null) || !bool.TryParse(line, out _scaleWindow) )
			{
				return false;
			}

			// Read move window.
			if( ((line = sr.ReadLine()) == null) || !bool.TryParse(line, out _moveWindow) )
			{
				return false;
			}

			// Read lock cursor.
			if( ((line = sr.ReadLine()) == null) || !bool.TryParse(line, out _lockCursor) )
			{
				return false;
			}

			// Read minimize to tray.
			if( ((line = sr.ReadLine()) == null) || !bool.TryParse(line, out _minimizeToTray) )
			{
				return false;
			}

			return true;
		}

		private void readClassesPart( StreamReader sr )
		{
			string line = null;
			while( (line = sr.ReadLine()) != null )
			{
				// If the string is invalid, ignore it.
				if( string.IsNullOrWhiteSpace(line) || string.IsNullOrEmpty(line) )
				{
					continue;
				}

				_classes.Add(line);
			}
		}

		public void createDefaultConfig()
		{
			reset(); // Just to be safe.

			StreamWriter sw = new StreamWriter(new FileStream(CONFIG_FILE, FileMode.Create));
			sw.WriteLine(_fullscreenizeHotkeyActive.ToString());
			sw.WriteLine(((int)_fullscreenizeModifierFlags).ToString());
			sw.WriteLine(((int)_fullscreenizeKeyFlags).ToString());
			sw.WriteLine(_lockCursorHotkeyActive.ToString());
			sw.WriteLine(((int)_lockCursorModifierFlags).ToString());
			sw.WriteLine(((int)_lockCursorKeyFlags).ToString());
			sw.WriteLine(_scaleWindow.ToString());
			sw.WriteLine(_moveWindow.ToString());
			sw.WriteLine(_lockCursor.ToString());
			sw.WriteLine(_minimizeToTray.ToString());
			sw.Close();
		}

		public void writeConfigFile()
		{
			StreamWriter sw = new StreamWriter(new FileStream(CONFIG_FILE, FileMode.Create));
			sw.WriteLine(_fullscreenizeHotkeyActive.ToString());
			sw.WriteLine(((int)_fullscreenizeModifierFlags).ToString());
			sw.WriteLine(((int)_fullscreenizeKeyFlags).ToString());
			sw.WriteLine(_lockCursorHotkeyActive.ToString());
			sw.WriteLine(((int)_lockCursorModifierFlags).ToString());
			sw.WriteLine(((int)_lockCursorKeyFlags).ToString());
			sw.WriteLine(_scaleWindow.ToString());
			sw.WriteLine(_moveWindow.ToString());
			sw.WriteLine(_lockCursor.ToString());
			sw.WriteLine(_minimizeToTray.ToString());
			foreach( string curr in _classes )
			{
				sw.WriteLine(curr);
			}
			sw.Close();
		}
	}
}
