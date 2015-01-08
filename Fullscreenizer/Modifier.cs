using System;

namespace Fullscreenizer
{
	[Flags]
	public enum Modifier : int
	{
		None  = (1 << 0),
		Ctrl  = (1 << 1),
		Shift = (1 << 2),
		Alt   = (1 << 3)
	}
}
