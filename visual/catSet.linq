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
	
	
	Bitmap orig2 = new Bitmap("C:\\sp\\2.png");
	
	int width2 = orig2.Width;
	int height2 = orig2.Height;
	
	byte[] buf2 = orig2.getBytes();
	
	for (int m = 0; m < width; m += threadCount)
	{
		List<Task<byte[]>> tasks = new List<Task<byte[]>>();
		
		for(int i = 0; i < threadCount; i++)
		{
			tasks.Add
			(
				asyncImg
				(
					width,
					buf.AsEnumerable().ToArray(),
					buf2.AsEnumerable().ToArray(),
					m + i
				)
			);
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
	
	foreach(Bitmap bmp in bitmaps)
	{
		bmp.Dump();
	}
	
//	int bmc = bitmaps.Count;
//	int step = bmc / 10;
//	for(int i = 0; i < bmc; i += step)
//		bitmaps[i].Dump();
//	bitmaps.Last().Dump();
}

private async Task<byte[]> asyncImg(int width, byte[] buf, byte[] buf2, int m)
{
	return await Task.Run(() =>
	{
		int transpZone = 100;
	
		for (int i = 0; i < buf.Length; i += 4)
		{
			int ind = i / 4;
			//int y = ind / width;
			int x = ind % width;
			
			if (x < m)
			{
				
			}
			else
			{
				if(x > m + transpZone)
				{
					buf[i + 0] = buf2[i + 0];
					buf[i + 1] = buf2[i + 1];
					buf[i + 2] = buf2[i + 2];
				}
				else
				{
					double prcnt = (double)(x - m) / (double)transpZone;
					double prcnt2 = 1 - prcnt;
					
					//(transpZone + " - " + (x - m)).Dump();
					
					buf[i + 0] =
					(byte)(prcnt2 * buf[i + 0] + prcnt * buf2[i + 0]);
					
					buf[i + 1] =
					(byte)(prcnt2 * buf[i + 1] + prcnt * buf2[i + 1]);
					
					buf[i + 2] =
					(byte)(prcnt2 * buf[i + 2] + prcnt * buf2[i + 2]);
				}
			}
		}
		
		return buf;

	});
}