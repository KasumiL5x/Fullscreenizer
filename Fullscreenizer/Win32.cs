using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Fullscreenizer
{
	public static class Win32
	{
		// For enumeration of top-level windows.
		public delegate bool EnumDesktopWindowsDelegate(IntPtr hWnd, int lParam);
		[DllImport("user32.dll")]
		static extern bool EnumDesktopWindows(IntPtr hDesktop, EnumDesktopWindowsDelegate lpfn, IntPtr lParam);

		// Getting of foreground window.
		[DllImport("user32.dll")]
		static extern IntPtr GetForegroundWindow();

		// Window visibility checking.
		[DllImport("user32.dll")]
		static extern bool IsWindowVisible(IntPtr hWnd);

		// Window text (title) related.
		[DllImport("user32.dll")]
		static extern int GetWindowTextLength(IntPtr hWnd);
		[DllImport("user32.dll")]
		static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

		// Window class name.
		[DllImport("user32.dll")]
		static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName,int nMaxCount);

		// Icon getting.
		static readonly UInt32 WM_GETICON = 0x007F;
		static readonly IntPtr ICON_BIG = new IntPtr(1);
		static readonly IntPtr ICON_SMALL = new IntPtr(0);
		static readonly IntPtr ICON_SMALL2 = new IntPtr(2);
		static readonly int GCL_HICON = -14;
		static readonly int GCL_HICONSM = -34;
		[DllImport("user32.dll")]
		static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
		[DllImport("user32.dll", EntryPoint="GetClassLong")]
		static extern uint GetClassLongPtr32(IntPtr hWnd, int nIndex);
		[DllImport("user32.dll", EntryPoint="GetClassLongPtr")]
		static extern IntPtr GetClassLongPtr64(IntPtr hWnd, int nIndex);
		static IntPtr GetClassLongPtr(IntPtr hWnd, int nIndex)
		{
			if( IntPtr.Size == 8 )
			{
				return GetClassLongPtr64(hWnd, nIndex);
			}
			else
			{
				return new IntPtr(GetClassLongPtr32(hWnd, nIndex));
			}
		}

		// Checking if something is a window.
		[DllImport("user32.dll")]
		static extern bool IsWindow(IntPtr hWnd);

		// Error reporting.
		[DllImport("kernel32.dll")]
		static extern uint GetLastError();

		// Window style stuff.
		static readonly int GWL_STYLE = -16;
		static readonly int WS_CAPTION = 0x00C00000;
		static readonly int WS_THICKFRAME = 0x00040000;
		static readonly int WS_MINIMIZE = 0x20000000;
		static readonly int WS_MAXIMIZE = 0x01000000;
		static readonly int WS_SYSMENU = 0x00080000;
		static readonly int BORDERLESS_FLAGS = ~(WS_CAPTION | WS_THICKFRAME | WS_MINIMIZE | WS_MAXIMIZE | WS_SYSMENU);
		[DllImport("user32.dll", EntryPoint="GetWindowLong")]
		static extern IntPtr GetWindowLongPtr32(IntPtr hWnd, int nIndex);
		[DllImport("user32.dll", EntryPoint="GetWindowLongPtr")]
		static extern IntPtr GetWindowLongPtr64(IntPtr hWnd, int nIndex);
		static IntPtr GetWindowLongPtr(IntPtr hWnd, int nIndex)
		{
			if( IntPtr.Size == 8 )
			{
				return GetWindowLongPtr64(hWnd, nIndex);
			}
			else
			{
				return GetWindowLongPtr32(hWnd, nIndex);
			}
		}
		[DllImport("user32.dll", EntryPoint="SetWindowLong")]
		static extern int SetWindowLong32(IntPtr hWnd, int nIndex, int dwNewLong);
		[DllImport("user32.dll", EntryPoint="SetWindowLongPtr")]
		static extern IntPtr SetWindowLongPtr64(IntPtr hWnd, int nIndex, IntPtr dwNewLong);
		static IntPtr SetWindowLongPtr(IntPtr hWnd, int nIndex, IntPtr dwNewLong)
		{
			if( IntPtr.Size == 8 )
			{
				return SetWindowLongPtr64(hWnd, nIndex, dwNewLong);
			}
			else
			{
				return new IntPtr(SetWindowLong32(hWnd, nIndex, dwNewLong.ToInt32()));
			}
		}

		// Window rect stuff.
		static readonly IntPtr HWND_TOP = new IntPtr(0);
		[Flags]
		public enum SetWindowPosFlags : uint
		{
			SWP_FRAMECHANGED = 0x0020,
			SWP_NOREPOSITION = 0x0200,
			SWP_NOSIZE = 0x0001
		}
		[DllImport("user32.dll", SetLastError=true)]
		static extern bool GetWindowRect(IntPtr hwnd, out RECT lpRect);
		[DllImport("user32.dll", SetLastError=true)]
		static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

		// Monitor stuff.
		static readonly uint MONITOR_DEFAULTTONEAREST = 0;
		[DllImport("user32.dll")]
		static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);
		[DllImport("user32.dll")]
		static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

		public static bool enumDesktopWindows( EnumDesktopWindowsDelegate proc )
		{
			return EnumDesktopWindows(IntPtr.Zero, proc, IntPtr.Zero);
		}

		public static IntPtr getForegroundWindow()
		{
			return GetForegroundWindow();
		}

		public static List<IntPtr> getVisibleWindows( bool ignoreWindowsWithoutTitle=true, bool ignoreCommonWindows=true )
		{
			List<IntPtr> windows = new List<IntPtr>();
			EnumDesktopWindowsDelegate proc = delegate( IntPtr hwnd, int lparam )
			{
				if( !isWindowVisible(hwnd) )
				{
					return true;
				}
				string windowText = getWindowText(hwnd);
				if( ignoreWindowsWithoutTitle )
				{
					
					if( string.IsNullOrEmpty(windowText) || string.IsNullOrWhiteSpace(windowText) )
					{
						return true;
					}
				}
				if( ignoreCommonWindows )
				{
					if( windowText.Equals("Program Manager") )
					{
						return true;
					}
				}
				windows.Add(hwnd);
				return true;
			};
			enumDesktopWindows(proc);
			return windows;
		}

		public static bool isWindowVisible( IntPtr hwnd )
		{
			return IsWindowVisible(hwnd);
		}

		public static string getWindowText( IntPtr hwnd )
		{
			int size = GetWindowTextLength(hwnd);
			if( size <= 0 )
			{
				return "";
			}
			size += 1;
			StringBuilder sb = new StringBuilder(size);
			GetWindowText(hwnd, sb, sb.Capacity);
			return sb.ToString();
		}

		public static string getClassName( IntPtr hwnd )
		{
			StringBuilder sb = new StringBuilder(256); // 256 is max size of class name.
			GetClassName(hwnd, sb, sb.Capacity);
			return sb.ToString();
		}

		public static Image getIcon( IntPtr hwnd )
		{
			try
			{
				// Get the icon, trying different types until one succeeds.
				IntPtr icon = SendMessage(hwnd, WM_GETICON, ICON_SMALL2, IntPtr.Zero);
				if( icon == IntPtr.Zero )
				{
					icon = SendMessage(hwnd, WM_GETICON, ICON_SMALL, IntPtr.Zero);
				}
				if( icon == IntPtr.Zero )
				{
					icon = SendMessage(hwnd, WM_GETICON, ICON_BIG, IntPtr.Zero);
				}
				if( icon == IntPtr.Zero )
				{
					icon = GetClassLongPtr(hwnd, GCL_HICON);
				}
				if( icon == IntPtr.Zero )
				{
					icon = GetClassLongPtr(hwnd, GCL_HICONSM);
				}
				if( icon == IntPtr.Zero )
				{
					return null;
				}
				
				return Icon.FromHandle(icon).ToBitmap();
			}
			catch( Exception )
			{
				return null;
			}
		}

		public static bool isWindow( IntPtr hwnd )
		{
			return IsWindow(hwnd);
		}

		public static uint getLastError()
		{
			return GetLastError();
		}

		public static IntPtr getWindowStyle( IntPtr hwnd )
		{
			return GetWindowLongPtr(hwnd, GWL_STYLE);
		}

		public static void setWindowStyle( IntPtr hwnd, IntPtr style )
		{
			SetWindowLongPtr(hwnd, GWL_STYLE, style);
		}

		public static bool isWindowBorderlessStyle( IntPtr hwnd )
		{
			// If anding the current style and the borderless flags is equal to the current style, then it's
			// currently in borderless fullscreen.
			int currentStyle = getWindowStyle(hwnd).ToInt32();
			return ((currentStyle & BORDERLESS_FLAGS) == currentStyle);
		}

		public static void getWindowRect( IntPtr hwnd, out int x, out int y, out int width, out int height )
		{
			RECT rect = new RECT();
			GetWindowRect(hwnd, out rect);
			x = rect.X;
			y = rect.Y;
			width = rect.Width;
			height = rect.Height;
		}

		public static void setWindowPos( IntPtr hwnd, int x, int y, int width, int height, SetWindowPosFlags flags )
		{
			SetWindowPos(hwnd, HWND_TOP, x, y, width, height, (uint)flags);
		}

		public static void getWindowMonitorSize( IntPtr hwnd, out int x, out int y, out int width, out int height )
		{
			IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);
			MONITORINFO info = new MONITORINFO();
			info.cbSize = Marshal.SizeOf(info);
			GetMonitorInfo(monitor, ref info);
			x = info.rcMonitor.X;
			y = info.rcMonitor.Y;
			width = info.rcMonitor.Width;
			height = info.rcMonitor.Height;
		}

		public static void makeWindowBorderless( IntPtr hwnd )
		{
			int style = getWindowStyle(hwnd).ToInt32();
			style &= BORDERLESS_FLAGS;
			SetWindowLongPtr(hwnd, GWL_STYLE, new IntPtr(style));
		}

		public static bool isWindowFullscreen( IntPtr hwnd )
		{
			getWindowMonitorSize(hwnd, out int monitorX, out int monitorY, out int monitorWidth, out int monitorHeight);
			getWindowRect(hwnd, out int windowX, out int windowY, out int windowWidth, out int windowHeight);

			return ((monitorX == windowX) &&
						(monitorY == windowY) &&
						(monitorWidth == windowWidth) &&
						(monitorHeight == windowHeight));
		}
	}
}
