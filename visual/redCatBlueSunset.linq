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
	
	//for (int m = 0; m < width; m += threadCount)
	{
		List<Task<byte[]>> tasks = new List<Task<byte[]>>();
		
		tasks.Add
		(
			asyncImg
			(
				width,
				buf.AsEnumerable().ToArray(),
				buf2.AsEnumerable().ToArray(),
				0
			)
		);
		
		Bitmap bmp = new Bitmap(width, height);
		bmp.fromBytes(tasks[0].Result);
		bitmaps.Add(bmp);
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
				double prcnt = 0.5;//(double)(x - m) / (double)transpZone;
				double prcnt2 = 1 - prcnt;
				
				//(transpZone + " - " + (x - m)).Dump();
				
				buf[i + 0] =
				(byte)(buf2[i + 0]);//Blue
				
				buf[i + 1] =
				(byte)(prcnt2 * buf[i + 1] + prcnt * buf2[i + 1]);//Green
				
				buf[i + 2] =
				(byte)(buf[i + 2]);//Red
			}
		}
		
		return buf;

	});
}

/*public static class supImg
{
public static byte[] getBytes(this Bitmap bmp)
{
Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
System.Drawing.Imaging.BitmapData bmpData =
bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
PixelFormat.Format32bppArgb);

IntPtr ptr = bmpData.Scan0;

int bytes = Math.Abs(bmpData.Stride) * bmp.Height;
byte[] rgbValues = new byte[bytes];

System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);

bmp.UnlockBits(bmpData);

return rgbValues;
}

public static void fromBytes(this Bitmap bmp, byte[] buf)
{
Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

System.Drawing.Imaging.BitmapData bmpData =
bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
PixelFormat.Format32bppArgb);

IntPtr ptr = bmpData.Scan0;

int bytes = Math.Abs(bmpData.Stride) * bmp.Height;

System.Runtime.InteropServices.Marshal.Copy(buf, 0, ptr, bytes);

bmp.UnlockBits(bmpData);
}

public static imgRgbaCl getRgba(byte[] buf, int height, int width)
{
return new imgRgbaCl(buf, height, width);
}

public class imgRgbaCl
{
pixel[,] pixels;

public imgRgbaCl(byte[] buf, int height, int width)
{
if (buf.Length != (height * width * 4))
throw new Exception("Buffer not for that picture?");

pixels = new pixel[width, height];
int x = 0, y = 0;

for (int i = 0; i < buf.Length; i += 4)
{
pixels[x, y].b = buf[i + 0];
pixels[x, y].g = buf[i + 1];
pixels[x, y].r = buf[i + 2];
pixels[x, y].a = buf[i + 3];
}

x++;

if (x == width)
{
y++;
x = 0;
}
}

public byte[] getBytes()
{
List<byte> rez = new List<byte>();

for (int i = 0; i < pixels.GetLength(0); i++)
{
for (int j = 0; j < pixels.GetLength(1); j++)
{
rez.Add((byte)pixels[i, j].b);
rez.Add((byte)pixels[i, j].g);
rez.Add((byte)pixels[i, j].r);
rez.Add((byte)pixels[i, j].a);
}
}

return rez.ToArray();
}

public pixel this[int x, int y]
{
get
{
return pixels[x, y];
}

set
{
pixels[x, y] = value;
}
}
}

public struct pixel
{
public int r
{
get 
{
return _r;
}

set
{
if (value < 0)
_r = 0;
else if (value > 255)
_r = 255;
else
_r = value;
}
}
private int _r;

public int g
{
get
{
return _g;
}

set
{
if (value < 0)
_g = 0;
else if (value > 255)
_g = 255;
else
_g = value;
}
}
private int _g;

public int b
{
get
{
return _b;
}

set
{
if (value < 0)
_b = 0;
else if (value > 255)
_b = 255;
else
_b = value;
}
}
private int _b;

public int a
{
get
{
return _a;
}

set
{
if (value < 0)
_a = 0;
else if (value > 255)
_a = 255;
else
_a = value;
}
}
private int _a;
}
}*/