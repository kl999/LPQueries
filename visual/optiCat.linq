<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	int threadCount = 10;

	List<Bitmap> bitmaps = new List<Bitmap>();
	
	Stopwatch sw = new Stopwatch();
	sw.Start();

	Bitmap orig = new Bitmap("C:\\sp\\1.png");
	
	int width = orig.Width;
	int height = orig.Height;
	
	byte[] buf = orig.getBytes();
	
	for (int m = 0; m < width; m += threadCount)
	{		
		//asyncImg(width, buf.AsEnumerable().ToArray(), m)
		//asyncImg(width, (byte[])buf.Clone(), m + i)
		
		
		List<Task<byte[]>> tasks = new List<Task<byte[]>>();
		
		for(int i = 0; i < threadCount; i++)
		{			
			tasks.Add(asyncImg(width, buf.AsEnumerable().ToArray(), m + i));
		}
		
		for(int i = 0; i < threadCount; i++)
		{
			Bitmap bmp = new Bitmap(width, height);
			bmp.fromBytes(tasks[i].Result);
			bitmaps.Add(bmp);
		}
	}
	
	sw.Stop();
	sw.Dump();
	
	bitmaps.Count.Dump("rez number");
	
//	foreach(Bitmap bmp in bitmaps)
//	{
//		bmp.Dump();
//	}
	
	int bmc = bitmaps.Count;
	int step = bmc / 10;
	for(int i = 0; i < bmc; i += step)
		bitmaps[i].Dump();
	bitmaps.Last().Dump();
}

private async Task<byte[]> asyncImg(int width, byte[] buf, int m)
//private byte[] asyncImg(int width, byte[] buf, int m)
{
	return await Task.Run(() =>
	{
		int tr = 0, tg = 0, tb = 0;
		for (int i = 0; i < buf.Length; i += 4)
		{
		int ind = i / 4;
		//int y = ind / width;
		//int x = ind - y * width;
		int x = ind % width;
		
		//int x = 1, y = 1, ind = 1, m = 500;
		
		if (x < m)
		{
//		tr = buf[i + 2];
//		tg = buf[i + 1];
//		tb = buf[i + 0];
		}
		else
		{
//		buf[i + 0] = (byte)tb;
//		buf[i + 1] = (byte)tg;
//		buf[i + 2] = (byte)tr;
		
		buf[i + 0] = (byte)(255 - buf[i + 0]);
		buf[i + 1] = (byte)(255 - buf[i + 1]);
		buf[i + 2] = (byte)(255 - buf[i + 2]);
		}
		
		/*tr = buf[i + 2];
		tg = buf[i + 1];
		tb = buf[i + 0];
		
		int max = Math.Max(Math.Max(tr, tg), tb);
		buf[i + 0] = (byte)max;
		buf[i + 1] = (byte)max;
		buf[i + 2] = (byte)max;*/
		}
		
		return buf;

	});
}