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

void Main()
{
	Bitmap inbmp = new Bitmap(@"C:\sp\3.png");
	
	Point start = new Point(),
		end = new Point();
	
	int w = inbmp.Width,
		h = inbmp.Height;
	
	int[,] map = new int[w, h];
	
	for(int x = 0; x < w; x++)
	{
		for(int y = 0; y < h; y++)
		{
			Color pcl = inbmp.GetPixel(x, y);
			
			if(pcl.G == 255 && pcl.R == 0)
			{
				start = new Point(x, y);
				
				map[x, y] = 1;
			}
			else if(pcl.R == 255 && pcl.G == 0)
			{
				end = new Point(x, y);
				
				map[x, y] = 1;
			}
			else
			{
				map[x, y] = 255 - (pcl.R / 1);
			}
		}
	}
	
	end.Dump();
	start.Dump();
	
//	map.Dump();
	
	long[,] pathmap = new long[w, h];
	
	int[,] itermap = new int[w, h];
	
	for(int x = 0; x < w; x++)
	{
		for(int y = 0; y < h; y++)
		{
			pathmap[x, y] = -1;
			
			itermap[x, y] = -1;
		}
	}
	
	itermap[end.X, end.Y] = 0;
	pathmap[end.X, end.Y] = 0;
	
	int step = -1;
	
	int sqrt2 = (int)(Math.Sqrt(2) * 100);
	
	for(bool stop = false; !stop; )
	{
		stop = true;
		
		step++;
		
		//step.Dump();
	
		for(int x = 0; x < w; x++)
		{
			for(int y = 0; y < h; y++)
			{
				if(itermap[x, y] == step)
				{
					stop = false;
					
					//itermap[x, y] = 0;
					
					if(x >= 1)
					{
						//x-1 y-1
						if(y >= 1)
						{
							long rez = pathmap[x, y] + map[x - 1, y - 1];
							
							rez = (rez * sqrt2) / 100;
							
							if(pathmap[x - 1, y - 1] == -1 || rez < pathmap[x - 1, y - 1])
							{
								pathmap[x - 1, y - 1] = rez;
								
								itermap[x - 1, y - 1] = step + 1;
							}
						}
						
						//x-1 y
						long rez2 = pathmap[x, y] + map[x - 1, y];
						
						if(pathmap[x - 1, y] == -1 || rez2 < pathmap[x - 1, y])
						{
							pathmap[x - 1, y] = rez2;
							
							itermap[x - 1, y] = step + 1;
						}
						
						//x-1 y+1
						if(y < h - 1)
						{
							long rez = pathmap[x, y] + map[x - 1, y + 1];
							
							rez = (rez * sqrt2) / 100;
							
							if(pathmap[x - 1, y + 1] == -1 || rez < pathmap[x - 1, y + 1])
							{
								pathmap[x - 1, y + 1] = rez;
								
								itermap[x - 1, y + 1] = step + 1;
							}
						}
					}
					
					if(x < w - 1)
					{
						//x+1 y-1
						if(y >= 1)
						{
							long rez = pathmap[x, y] + map[x + 1, y - 1];
							
							rez = (rez * sqrt2) / 100;
							
							if(pathmap[x + 1, y - 1] == -1 || rez < pathmap[x + 1, y - 1])
							{
								pathmap[x + 1, y - 1] = rez;
								
								itermap[x + 1, y - 1] = step + 1;
							}
						}
						
						//x+1 y
						long rez2 = pathmap[x, y] + map[x + 1, y];
						
						if(pathmap[x + 1, y] == -1 || rez2 < pathmap[x + 1, y])
						{
							pathmap[x + 1, y] = rez2;
							
							itermap[x + 1, y] = step + 1;
						}
						
						//x+1 y+1
						if(y < h - 1)
						{
							long rez = pathmap[x, y] + map[x + 1, y + 1];
							
							rez = (rez * sqrt2) / 100;
							
							if(pathmap[x + 1, y + 1] == -1 || rez < pathmap[x + 1, y + 1])
							{
								pathmap[x + 1, y + 1] = rez;
								
								itermap[x + 1, y + 1] = step + 1;
							}
						}
					}
					
					//x y-1
					if(y >= 1)
					{
						long rez = pathmap[x, y] + map[x, y - 1];
						
						if(pathmap[x, y - 1] == -1 || rez < pathmap[x, y - 1])
						{
							pathmap[x, y - 1] = rez;
							
							itermap[x, y - 1] = step + 1;
						}
					}
					
					//x y+1
					if(y < h - 1)
					{
						long rez = pathmap[x, y] + map[x, y + 1];
						
						if(pathmap[x, y + 1] == -1 || rez < pathmap[x, y + 1])
						{
							pathmap[x, y + 1] = rez;
							
							itermap[x, y + 1] = step + 1;
						}
					}
				}
			}
		}
		
		/*for(int x = 0; x < w; x++)
		{
			for(int y = 0; y < h; y++)
			{
				if(itermap[x, y] == 1)
				{
					itermap[x, y] = 2;
				}
			}
		}*/
		
		//pathmap.Dump();
		
		//break;
	}
	
	itermap.Dump();
	
	pathmap.Dump();
	
	List<Point> path = new List<Point>(new[] { start });
	
	for(;;)//(int zdf = 0; zdf < 3; zdf++)
	{
		Point cur = path.Last();
		
		if(cur == end)
			break;
		
		int x = cur.X,
			y = cur.Y;
		
		//(x + " | " + y).Dump();
		
		int curstep = itermap[x, y];
		
		int minx = -1,
			miny = -1;
		
		if(x >= 1)
		{
			//x-1 y-1
			if(y >= 1)
			{
				if(minx == -1 || pathmap[x - 1, y - 1] < pathmap[minx, miny])
				{
					minx = x - 1;
					miny = y - 1;
				}
			}
			
			//x-1 y
			if(minx == -1 || pathmap[x - 1, y] < pathmap[minx, miny])
			{
				minx = x - 1;
				miny = y;
			}
			
			//x-1 y+1
			if(y < h - 1)
			{
				if(minx == -1 || pathmap[x - 1, y + 1] < pathmap[minx, miny])
				{
					minx = x - 1;
					miny = y + 1;
				}
			}
		}
		
		if(x < w - 1)
		{
			//x+1 y-1
			if(y >= 1)
			{
				if(minx == -1 || pathmap[x + 1, y - 1] < pathmap[minx, miny])
				{
					minx = x + 1;
					miny = y - 1;
				}
			}
			
			//x+1 y
			if(minx == -1 || pathmap[x + 1, y] < pathmap[minx, miny])
			{
				minx = x + 1;
				miny = y;
			}
			
			//x+1 y+1
			if(y < h - 1)
			{
				if(minx == -1 || pathmap[x + 1, y + 1] < pathmap[minx, miny])
				{
					minx = x + 1;
					miny = y + 1;
				}
			}
		}
		
		//x y-1
		if(y >= 1)
		{
			if(minx == -1 || pathmap[x, y - 1] < pathmap[minx, miny])
			{
				minx = x;
				miny = y - 1;
			}
		}
		
		//x y+1
		if(y < h - 1)
		{
			if(minx == -1 || pathmap[x, y + 1] < pathmap[minx, miny])
			{
				minx = x;
				miny = y + 1;
			}
		}
		
		if(minx == -1) throw new Exception("BadAlg");
		
		path.Add(new Point(minx, miny));
		
		//new Point(minx, miny).Dump();
		
		//path.Last().Dump();
	}
	
	Color clr = Color.FromArgb(189, 28, 198);
	
	foreach(var pt in path.Skip(1).Reverse().Skip(1).Reverse())
	{
		inbmp.SetPixel(pt.X, pt.Y, clr);
	}
	
	var pt2 = path.First();
	
	pathmap[pt2.X, pt2.Y].Dump("algLast");
	
	int tm = map[path[0].X, path[0].Y];
	
	for(int i = 1; i < path.Count; i++)
	{
		int sum = map[path[i].X, path[i].Y];
		
		if(path[i].X - path[i - 1].X != 0 && path[i].Y - path[i - 1].Y != 0)
			sum = (sum * (int)(Math.Sqrt(2) * 100)) / 100;
		
		tm += sum;
	}
	
	tm.Dump("tm");
	
	zoom(inbmp, 7).Dump();
	
	inbmp.Dispose();
}

Bitmap zoom(Bitmap bmp, int zoom)
{
	int w = bmp.Width,
		h = bmp.Height;
	
	return new Bitmap(bmp, w * zoom, h * zoom);
}