using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Fullscreenizer
{
	/**
	 * Config format:
	 *     | bool   | default to false | If the hotkey is activated upon load.
	 *     | int    | default to 0     | Bit flag for the modifier of the hotkey modifier(s).
	 *     | int    | default to 0     | Bit flag for the key of the hotkey.
	 *     | bool   | default to true  | Scale the window when fullscreenizing.
	 *     | bool   | default to true  | Move the window to the top-left when fullscreenizing.
	 *     | string | default to none  | All following lines are read as window classes to look for.
	 */
	public class Config
	{
		private const string CONFIG_FILE = "fullscreenizer.cfg";

		private bool _hotkeyActive;
		public bool HotkeyActive
		{
			get{ return _hotkeyActive; }
			set{ _hotkeyActive = value; }
		}

		private Modifier _modifierFlags;
		public Modifier ModifierFlags
		{
			get{ return _modifierFlags; }
			set{ _modifierFlags = value; }
		}

		private Keys _keyFlag;
		public Keys KeyFlags
		{
			get{ return _keyFlag; }
			set{ _keyFlag = value; }
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

		private List<string> _classes = new List<string>();
		public List<string> Classes
		{
			get{ return _classes; }
			set{ _classes = value; }
		}

		public void reset()
		{
			_hotkeyActive = false;
			_modifierFlags = Modifier.Ctrl;
			_keyFlag = Keys.Home;
			_scaleWindow = true;
			_moveWindow = true;
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
			if( !readHotkeyPart(sr) )
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

		private bool readHotkeyPart( StreamReader sr )
		{
			// One string used for all parameters.  If this is null after reading a line, there was no contents to read.
			string line = null;

			// Read the active status of the hotkey.
			if( ((line = sr.ReadLine()) == null) || !bool.TryParse(line, out _hotkeyActive) )
			{
				return false;
			}

			// Read the hotkey modifier flags.
			int tmpModifier = 0;
			if( ((line = sr.ReadLine()) == null) || !int.TryParse(line, out tmpModifier) )
			{
				return false;
			}
			_modifierFlags = (Modifier)tmpModifier;

			// Read the hotkey key flag.
			int tmpKey = 0;
			if( ((line = sr.ReadLine()) == null) || !int.TryParse(line, out tmpKey) )
			{
				return false;
			}
			_keyFlag = (Keys)tmpKey;

			// If no modifier or no key is provided, fail.
			if( _modifierFlags == Modifier.None || _keyFlag == 0 )
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
			sw.WriteLine(_hotkeyActive.ToString());
			sw.WriteLine(((int)_modifierFlags).ToString());
			sw.WriteLine(((int)_keyFlag).ToString());
			sw.WriteLine(_scaleWindow.ToString());
			sw.WriteLine(_moveWindow.ToString());
			sw.Close();
		}

		public void writeConfigFile()
		{
			StreamWriter sw = new StreamWriter(new FileStream(CONFIG_FILE, FileMode.Create));
			sw.WriteLine(_hotkeyActive.ToString());
			sw.WriteLine(((int)_modifierFlags).ToString());
			sw.WriteLine(((int)_keyFlag).ToString());
			sw.WriteLine(_scaleWindow.ToString());
			sw.WriteLine(_moveWindow.ToString());
			foreach( string curr in _classes )
			{
				sw.WriteLine(curr);
			}
			sw.Close();
		}
	}
}
