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
		
		if(dst > 50)
		{
			//"Z".Dump();
			Console.Beep(2000, 1000);
		}
		
		t.Wait();
	}
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