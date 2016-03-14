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
var dc3 = new DumpContainer();

Util.HorizontalRun (true
	, "R-G:"
	, dc
	, "G-B:"
	, dc2).Dump();
	
Util.HorizontalRun (true
	, "R-B:"
	, dc3).Dump();

byte[] arrrg = new byte[w * h * 4],
	arrgb = new byte[w * h * 4],
	arrrb = new byte[w * h * 4];
	
for(int o = 0; o < w * h * 4; o += 4)
{
	int ind = o / 4,
		x = ind % w,
		y = ind / w;
	
	arrrg[o] = 0;
	arrrg[o + 1] = (byte)(x);
	arrrg[o + 2] = (byte)(255 - y);
	
	arrgb[o] = (byte)(x);
	arrgb[o + 1] = (byte)(255 - y);
	arrgb[o + 2] = 0;
	
	arrrb[o] = (byte)(x);
	arrrb[o + 1] = 0;
	arrrb[o + 2] = (byte)(255 - y);
	
	arrrg[o + 3] = 255;
	arrgb[o + 3] = 255;
	arrrb[o + 3] = 255;
	
	//o.Dump();
}

bmp.fromBytes(arrrg);

dc.Content = bmp;

bmp.fromBytes(arrgb);

dc2.Content = bmp;

bmp.fromBytes(arrrb);

dc3.Content = bmp;

//Thread.Sleep(100);