using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;

namespace Fullscreenizer
{
	[StructLayout(LayoutKind.Sequential)]
	public struct RECT
	{
		public int left, top, right, bottom;

		public RECT( int inLeft, int inTop, int inRight, int inBottom )
		{
			this.left = inLeft;
			this.top = inTop;
			this.right = inRight;
			this.bottom = inBottom;
		}

		public RECT( Rectangle r )
			: this(r.Left, r.Top, r.Right, r.Bottom)
		{
		}

		public int X
		{
			get{ return left; }
			set{ right -= (left - value); left = value; }
		}

		public int Y
		{
			get{ return top; }
			set{ bottom -= (top - value); top = value; }
		}

		public int Height
		{
			get{ return bottom - top; }
			set{ bottom = value + top; }
		}

		public int Width
		{
			get{ return right - left; }
			set{ right = value + left; }
		}

		public Point Location
		{
			get{ return new Point(left, top); }
			set{ X = value.X; Y = value.Y; }
		}

		public Size Size
		{
			get{ return new Size(Width, Height); }
			set{ Width = value.Width; Height = value.Height; }
		}

		public static implicit operator Rectangle( RECT r )
		{
			return new Rectangle(r.left, r.top, r.Width, r.Height);
		}

		public static implicit operator RECT( Rectangle r )
		{
			return new RECT(r);
		}

		public static bool operator ==( RECT r1, RECT r2 )
		{
			return r1.Equals(r2);
		}

		public static bool operator !=( RECT r1, RECT r2 )
		{
			return !r1.Equals(r2);
		}

		public bool Equals( RECT r )
		{
			return r.left == left && r.top == top && r.right == right && r.bottom == bottom;
		}

		public override bool Equals( object obj )
		{
			if (obj is RECT)
			{
				return Equals((RECT)obj);
			}
			else if (obj is Rectangle)
			{
				return Equals(new RECT((Rectangle)obj));
			}
			return false;
		}

		public override int GetHashCode()
		{
			return ((Rectangle)this).GetHashCode();
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", left, top, right, bottom);
		}
	}
}
