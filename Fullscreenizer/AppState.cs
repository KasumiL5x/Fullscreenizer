using System;
using System.Drawing;

namespace Fullscreenizer
{
	public class AppState
	{
		public string windowText = "";
		public string className = "";
		public Image image = null;
		//
		public IntPtr originalStyle = IntPtr.Zero;
		public int initialX = 0;
		public int initialY = 0;
		public int initialWidth = 0;
		public int initialHeight = 0;

		public AppState()
		{
		}

		public bool isValid()
		{
			// windowText can be empty.
			// image can be null.

			return !((string.IsNullOrWhiteSpace(className)) ||
						(originalStyle == IntPtr.Zero) ||
						(initialWidth == 0) ||
						(initialHeight == 0));
		}
	}
}
