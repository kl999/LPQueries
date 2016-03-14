<Query Kind="Program">
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	Bitmap orig = new Bitmap("C:\\sp\\1.png");
	
	int width = orig.Width;
    
	Bitmap bmp = new Bitmap(orig);
	
	byte[] buf = bmp.getBytes();
    
    var dc = new DumpContainer();
    dc.Dump();
	
	for (int m = 0; m < width; m += 4)
	{
		
		var t1 = asyncImg(width, buf.ToArray(), m);
		var t2 = asyncImg(width, buf.ToArray(), m + 1);
		var t3 = asyncImg(width, buf.ToArray(), m + 2);
		var t4 = asyncImg(width, buf.ToArray(), m + 3);
		
        /*bmp.fromBytes(await t1);
		dc.Content = new Bitmap(bmp);
		
		bmp.fromBytes(await t2);
		dc.Content = new Bitmap(bmp);
		
		bmp.fromBytes(await t3);
		dc.Content = new Bitmap(bmp);*/
		
		bmp.fromBytes(await t4);
        dc.Content = null;
		dc.Content = bmp;//new Bitmap(bmp);
	}
}

private async Task<byte[]> asyncImg(int width, byte[] buf, int m)
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
tr = buf[i + 2];
tg = buf[i + 1];
tb = buf[i + 0];
}
else
{
buf[i + 0] = (byte)tb;
buf[i + 1] = (byte)tg;
buf[i + 2] = (byte)tr;

//buf[i + 0] = (byte)(255 - buf[i + 0]);
//buf[i + 1] = (byte)(255 - buf[i + 1]);
//buf[i + 2] = (byte)(255 - buf[i + 2]);
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
}