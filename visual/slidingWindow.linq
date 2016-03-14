<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

unsafe void Main()
{
	var tmpbmp = new Bitmap(@"c:\sp\test\template.png");
	int tmpw = tmpbmp.Width,
		tmph = tmpbmp.Height,
		tmpsum = tmpw * tmph;
	byte[] tmparr = tmpbmp.getGrayBytes();
	
	var tgbmp = new Bitmap(
		@"c:\sp\test\targetImg2.png"
		//@"c:\sp\test\many.png"
		);
	int tgw = tgbmp.Width,
		tgh = tgbmp.Height;
	
	("w: " + tgw + "\nh: " + tgh + "\narea: " + (tgw * tgh)).Dump();
	
	byte[] tgarr = tgbmp.getGrayBytes();
	
	var rezbmp = new Bitmap(tgbmp);
	var g = Graphics.FromImage(rezbmp);
	
	Random rand = new Random();
	
	List<Rectangle> rects = new List<Rectangle>();
	List<Rectangle> srchRects = new List<Rectangle>();
	
	int iterct = 0, rectct = 0;
	
	var sw = new Stopwatch();
	sw.Restart();
	fixed(byte* tmpptr = &tmparr[0])
	fixed(byte* tgptr = &tgarr[0])
	{
		for(int i = 0; /*i < 100*/; i++)
		{
			if(rects.Count > 0) break;
			
			iterct++;
			
			for(int tgx = 0; tgx < tgw - tmpw; tgx++)
			for(int tgy = 0; tgy < tgh - tmph; tgy++)
			{
				if(rand.Next(10000) > 9998)
				{
					rectct++;
//					srchRects.Add(new Rectangle(tgx, tgy, tmpw, tmph));
					int sum = 0;
					
					for(int x = 0; x < tmpw; x++)
					for(int y = 0; y < tmph; y++)
					{
						if(tmpptr[x + y * tmpw] == tgptr[(tgx + x) + (tgy + y) * tgw])
						{
							sum++;
						}
					}
					
					if(((double)sum / (double)tmpsum) * 100 > 80)
					{
						rects.Add(new Rectangle(tgx, tgy, tmpw, tmph));
					}
					
//					(((double)sum / (double)tmpsum) * 100).Dump();
				}
			}
		}
	}
	sw.Stop();
	
	("Iteration count: " + iterct
	+ "\nRectangle count: " + rectct + "\nTime: " + sw.ElapsedMilliseconds).Dump();
//	srchRects.Count.Dump("Number of rects searched");
//	foreach(var rect in srchRects)
//		g.DrawRectangle(Pens.Gray, rect);
	
	foreach(var rect in rects)
		g.DrawRectangle(Pens.Red, rect);
	
	rezbmp.Dump();
}