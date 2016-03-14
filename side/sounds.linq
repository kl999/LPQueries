<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

#define TIMER

[DllImport("user32.dll")] 
internal static extern short GetKeyState(int keyCode);

[DllImport("user32.dll")]
static extern void keybd_event(
	byte bVk,
	byte bScan,
	uint dwFlags,
	int dwExtraInfo
);

void Main()
{
	var o = new ScrPos();
	
	for(;;)
	{
		var t = Task.Run(() => 
		{
			Thread.Sleep(500);
			//"X".Dump();
		});
		
		long dst = o.dst;
		
		o.dst = 0;
		
		if(dst > 20)
		{
			//"Z".Dump();
			cont();
		}
		
		t.Wait();
	}
}

void cont()
{
	var dc = new DumpContainer();
	dc.Dump();
	
	/*Thread.Sleep(
	1000 //ms
	* 60//s
	* 60//min
	* 2//h
	);*/
	
	var rand = new Random();
	
#if TIMER
	Task.Delay(
		0//1000 * 60 * 30//30 min
	).Wait();
#endif
	
	for(int i = 1;
#if TIMER
	i <
	5//200 * 5 ms
	* 1//s
	* 1//min
	* 1//h
#endif
	; i++)//(int i = 1; i < 320; i++)
	{
		//dc.Content = i;
		
		if(rand.Next(2) == 1)
			PressKeyboardButton((int)keys.num);
		if(rand.Next(2) == 1)
			PressKeyboardButton((int)keys.caps);
		if(rand.Next(2) == 1)
			PressKeyboardButton((int)keys.scroll);
		
		Console.Beep(100 * (5 + rand.Next(80)), 200);
        
        if(rand.Next(2) == 1)
            PressKeyboardButton((int)keys.left);
        else
            PressKeyboardButton((int)keys.right);
	}
	
	//"End".Dump();
}

private void PressKeyboardButton(int keyCode)
{
    const int KEYEVENTF_EXTENDEDKEY = 0x1;
    const int KEYEVENTF_KEYUP = 0x2;
 
    keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
    keybd_event((byte)keyCode, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
}

enum keys
{
	num = 0x90,
	caps = 0x14,
	scroll = 0x91,
    left = 0x25,
    right = 0x27
}

class ScrPos
{
	private object dstLocker = new object();
	private long _dst = 0;
	public long dst
	{
		get
		{
			lock(dstLocker) return _dst;
		}
		set
		{
			lock(dstLocker) _dst = value;
		}
	}
	
	public ScrPos()
	{
		Task.Run((Action)work);
	}
	
	public void work()
	{
//		var dc = new DumpContainer();
//		
//		dc.Dump();
		
		Point prevpt = new Point(0, 0);
		
		prevpt = (Point)GetCursorPosition();
		
		long dist = 0;
		
		for(;;)
		{
			Thread.Sleep(100);
			
			Point pt = GetCursorPosition();
			
			if(pt.IsEmpty)
				continue;
			
			int xv = Math.Abs(prevpt.X - pt.X);
			xv *= xv;
			
			int yv = Math.Abs(prevpt.Y - pt.Y);
			yv *= yv;
			
			if(xv - 1 < 0 || yv - 1 < 0)
				continue;
			
			dist += (long)Math.Sqrt(xv + yv);
			
	//		if(dist < 0)
	//		{
	//			prevpt.Dump();
	//			pt.Dump();
	//			
	//			(xv + " | " + yv
	//				+ "\t\t" + Math.Sqrt(xv) + " | " + Math.Sqrt(yv)).Dump();
	//			
	//			"----------------------------------------------".Dump();
	//		}
			
			prevpt = pt;
			
//			dc.Content =
//				//pt;
//				dist;
			
			dst = dist;
		}
	}
	
	// <summary>
	/// Struct representing a point.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	private struct POINT
	{
		public int X;
		public int Y;
		
		public static implicit operator Point(POINT point)
		{
			return new Point(point.X, point.Y);
		}
	}
	
	/// <summary>
	/// Retrieves the cursor's position, in screen coordinates.
	/// </summary>
	/// <see>See MSDN documentation for further information.</see>
	[DllImport("user32.dll")]
	private static extern bool GetCursorPos(out POINT lpPoint);
	
	private static Point GetCursorPosition()
	{
		POINT lpPoint;
		GetCursorPos(out lpPoint);
		//bool success = User32.GetCursorPos(out lpPoint);
		// if (!success)
		
		return lpPoint;
	}
}