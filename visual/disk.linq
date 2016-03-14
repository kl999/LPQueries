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

int h = 200,
	w = 200;

Bitmap bmp = new Bitmap(h, w);

int bLen = h * w * 4,
	len = h * w;

byte[] buf = new byte[bLen];

int cx = 100,
	cy = 100,
	cr = 80;

for(int i = 0; i < len; i++)
{
	int tInd = i * 4,
		x = i % w,
		y = i / w;
	
	byte cl = 255;
	
	int xDist = Math.Abs(x - cx),
		yDist = Math.Abs(y - cy),
		dist = (int)Math.Sqrt(xDist * xDist + yDist * yDist);
	
	if(dist < cr)
	{
		cl = 0;
	}
	
	buf[tInd + 2] = cl;
	buf[tInd + 1] = cl;
	buf[tInd] = cl;
	buf[tInd + 3] = 255;
}

bmp.fromBytes(buf);

bmp.Dump("rez");