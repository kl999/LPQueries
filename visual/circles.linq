<Query Kind="Program">
  <Reference>C:\sp\CvTest\OpenCvSharp.dll</Reference>
  <Namespace>OpenCvSharp</Namespace>
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var bmp = new Bitmap(@"C:\sp\circless\8.jpg");
    
    //bmp.fromGrayBytes(bmp.getGrayBytes());
    
    bool median = false;
    
    //median = true;
    
    if(median)
    {
        IplImage img = BitmapConverter.ToIplImage(bmp);
        
        img.Smooth(img, SmoothType.Median, 15);
        
        bmp = BitmapConverter.ToBitmap(img);
    }
	
	bmp.Dump("orig");
	
	var carr = getCircless240(bmp);
	
	var rez = new Bitmap(bmp);
	
	var g = Graphics.FromImage(rez);
	
	g.Clear(Color.Bisque);
	
	foreach(var c in carr)
	{
		g.FillEllipse(
			new SolidBrush(Color.FromArgb(c.color[2], c.color[1], c.color[0])),
			(float)(c.point.x - 9),
			(float)(c.point.y - 9),
			18,
			18);
	}
	
	rez.Dump("rez");
    
    var small = new Bitmap(rez.Width / 20, rez.Height / 20);
    
    byte[] buf = new byte[small.Width * small.Height * 4];
    
    foreach(var c in carr)
	{
        int x = (int)((c.point.x - 10) / 20);
        int y = (int)((c.point.y - 10) / 20);
        
        buf[4 * (x + (rez.Width / 20) * y) + 0] = c.color[0];
        buf[4 * (x + (rez.Width / 20) * y) + 1] = c.color[1];
        buf[4 * (x + (rez.Width / 20) * y) + 2] = c.color[2];
        buf[4 * (x + (rez.Width / 20) * y) + 3] = 255;
    }
    
    small.fromBytes(buf);
    
    small.Dump("small");
    
    small = maxColor(small);
    
    int[,] areamap = new int[small.Width, small.Height];
    
    int areaCount = 0;
    
    for(int x = 0; x < small.Width; x++)
    for(int y = 0; y < small.Height; y++)
    {
        areamap[x, y] = -1;
    }
    
    for(int x = 0; x < small.Width; x++)
    for(int y = 0; y < small.Height; y++)
    {
        if(areamap[x, y] == -1)
        {
            areamap[x, y] = areaCount;
            
            List<Point> prevIterPts = new List<Point>(new[] { new Point(x, y) });
            
            for(; prevIterPts.Count != 0;)
            {
                //prevIterPts.Dump();
                
                List<Point> iterPts = new List<Point>();
                
                foreach(var pt in prevIterPts)
                {
                    Color ptcl = small.GetPixel((int)pt.x, (int)pt.y);
                    
                    dirMtd(1, 0, small, pt, ptcl, prevIterPts, iterPts, areaCount, areamap);
                    
                    dirMtd(1, 1, small, pt, ptcl, prevIterPts, iterPts, areaCount, areamap);
                    
                    dirMtd(0, 1, small, pt, ptcl, prevIterPts, iterPts, areaCount, areamap);
                    
                    dirMtd(-1, 1, small, pt, ptcl, prevIterPts, iterPts, areaCount, areamap);
                    
                    dirMtd(-1, 0, small, pt, ptcl, prevIterPts, iterPts, areaCount, areamap);
                    
                    dirMtd(-1, -1, small, pt, ptcl, prevIterPts, iterPts, areaCount, areamap);
                    
                    dirMtd(0, -1, small, pt, ptcl, prevIterPts, iterPts, areaCount, areamap);
                    
                    dirMtd(1, -1, small, pt, ptcl, prevIterPts, iterPts, areaCount, areamap);
                }
                
                prevIterPts = iterPts;//.Dump();
            }
            
            //areamap.Dump();
            
            areaCount++;
        }
    }
    
    //areamap.Dump();
    
    var areaBmp = new Bitmap(bmp);
    Graphics g2 = Graphics.FromImage(areaBmp);
    
    for(int x = 0; x < small.Width; x++)
    for(int y = 0; y < small.Height; y++)
    {
        KnownColor kclr = (KnownColor)((areamap[x, y] % 49) + 35);
        
        Color clr = Color.FromKnownColor(kclr);
        
        clr = Color.FromArgb(100, clr.R, clr.G, clr.B);
        
        g2.FillRectangle(new SolidBrush(clr), x * 20, y * 20, 20, 20);
    }
    
    areaBmp.Dump();
	
	bmp.Dispose();
}

Bitmap maxColor(Bitmap bmp)
{
    var rez = new Bitmap(bmp);
    
    //bmp.Dump();
    
    for(int x = 0; x < bmp.Width; x++)
    for(int y = 0; y < bmp.Height; y++)
    {
        var clr = bmp.GetPixel(x, y);
        
        int r = clr.R,
            g = clr.G,
            b = clr.B;
        
        double pr = 255.0 / (double)Math.Max(Math.Max(r, g), b);
        
        if(pr > 5) pr = 0;
        
        r = (int)(r * pr); r = r < 0 ? 0 : r;
        g = (int)(g * pr); g = g < 0 ? 0 : g;
        b = (int)(b * pr); b = b < 0 ? 0 : b;
        
    //    clr.Dump();
    //    
    //    (r + " " + g + " " + b).Dump();
        
        var clr2 = Color.FromArgb(r, g, b);
        
        rez.SetPixel(x, y, clr2);
    }
    
    return rez;
}

void dirMtd(int cx, int cy, Bitmap small, Point pt, Color ptcl, List<Point> prevIterPts, List<Point> iterPts, int areaCount, int[,] areamap)
{
    try
    {
        Color cl = small.GetPixel((int)pt.x + cx, (int)pt.y + cy);
        
        if(areamap[(int)pt.x + cx, (int)pt.y + cy] != -1)
            return;
        
        if(Math.Abs(cl.R - ptcl.R)
            + Math.Abs(cl.G - ptcl.G)
            + Math.Abs(cl.B - ptcl.B) < 30)
        {
            iterPts.Add(new Point((int)pt.x + cx, (int)pt.y + cy));
            
            areamap[(int)pt.x + cx, (int)pt.y + cy] = areaCount;
        }
    }
    catch(ArgumentOutOfRangeException) { }
}

List<Circle> getCircless240(Bitmap bmp)
{
	var buf = bmp.getBytes();
	
	int bmpw = bmp.Width,
        bmph = bmp.Height;
	
	var rez = new List<Circle>();
	
	for(int x = 0; x < bmpw; x += 20)
	for(int y = 0; y < bmph; y += 20)
	{
		rez.Add(getCircle(buf, x, y, 20, 20, bmpw));
	}
	
	return rez;
}

Circle getCircle(byte[] buf, int x, int y, int w, int h, int bmpw)
{
	List<int[]> allc = new List<int[]>();
	
	for(int tx = 0; tx < w; tx++)
	for(int ty = 0; ty < h; ty++)
	{
		int r = 0,
			g = 0,
			b = 0;
		
		int ind = ((x + tx) + (bmpw * (y + ty))) * 4;
		
		r = buf[ind + 2];
		g = buf[ind + 1];
		b = buf[ind + 0];
		
		bool found = false;
		
		for(int i = 0; i < allc.Count; i++)
		{
			if(Math.Abs(allc[i][0] - r) < 50
				&& Math.Abs(allc[i][1] - g) < 10
				&& Math.Abs(allc[i][2] - b) < 10)
			{
				found = true;
				
				allc[i][3]++;
			}
		}
		
		if(!found)
		{
			allc.Add(new int[] { r, g, b, 1 });
		}
	}
    
    double[] rez = new double[3];
    
    //rez = allc.OrderByDescending(i => i[3]).First().Select(i => (double)i).ToArray();
    
    int all = w * h;
    
//    foreach(var c in allc)
//    {
//        rez[0] += ((double)c[3] / (double)all) * (double)(c[0]);
//        
//        rez[1] += ((double)c[3] / (double)all) * (double)(c[1]);
//        
//        rez[2] += ((double)c[3] / (double)all) * (double)(c[2]);
//    }
//    
//    rez = rez.Select(i => i > 255 ? 255 : i).ToArray();
    
    List<int[]> meanc = new List<int[]>();
    
    foreach(var c in allc)
    {
        int prc = c[3] * 100 / all;
        
        if(prc > 10)
        {
            meanc.Add(c);
        }
    }
    
    if(meanc.Count > 0)
    {    
        int sum = meanc.Sum(i => i[3]);
        
        foreach(var c in meanc)
        {
            rez[0] += ((double)c[3] / (double)sum) * (double)(c[0]);
            
            rez[1] += ((double)c[3] / (double)sum) * (double)(c[1]);
            
            rez[2] += ((double)c[3] / (double)sum) * (double)(c[2]);
        }
        
        rez = rez.Select(i => i > 255 ? 255 : i).ToArray();
    }
    else
    {
        rez = allc.OrderByDescending(i => i[3]).First().Select(i => (double)i).ToArray();
    }
    
    rez = rez.Select(i => i > 255 ? 255 : i).ToArray();
	
	return new Circle(x + w / 2, y + h / 2, (byte)rez[0], (byte)rez[1], (byte)rez[2]);
}

class Circle
{
	public Point point;
	
	//B G R
	public byte[] color = new byte[3];
	
	public Circle(int x, int y, byte r, byte g, byte b)
	{
		point = new Point(x, y);
		
		color[2] = r;
		color[1] = g;
		color[0] = b;
	}
}

class Point
{
	public double
		x,
		y;
	
	public Point()
	{
		x = 0;
		y = 0;
	}
	
	public Point(double _x, double _y)
	{
		x = _x;
		y = _y;
	}
	
	public Point add(Point o)
	{
		x += o.x;
		y += o.y;
		
		return this;
	}
	
	public Point copy()
	{
		return new Point(x, y);
	}
}