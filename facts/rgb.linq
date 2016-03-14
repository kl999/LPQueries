<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

int h = 255, w = 255;
var bmp = new Bitmap(w, h);
var g = Graphics.FromImage(bmp);

var dc = new DumpContainer();
var dc2 = new DumpContainer();

Util.HorizontalRun (true
	, dc
	, dc2).Dump();

for(int i = 0; i < 256; i++)
{
	dc2.Content = i;
	
	byte[] arr = new byte[w * h * 4];
	
	for(int o = 0; o < w * h * 4; o += 4)
	{
		int ind = o / 4,
			x = ind % w,
			y = ind / w;
		
		arr[o] = (byte)i;
		arr[o + 1] = (byte)(x);
		arr[o + 2] = (byte)(255 - y);
		
		arr[o + 3] = 255;
		
		//o.Dump();
	}
	
	bmp.fromBytes(arr);
	
	dc.Content = bmp;
	
	//Thread.Sleep(100);
}