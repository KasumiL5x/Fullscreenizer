using System.Runtime.InteropServices;

namespace Fullscreenizer
{
	[StructLayout(LayoutKind.Sequential)]
	struct MONITORINFO
	{
		public int cbSize;
		public RECT rcMonitor;
		public RECT rcWork;
		public uint dwFlags;
	}
}
