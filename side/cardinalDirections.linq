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
	for(int i = 0; i <= 8; i++)
		(i.ToString() + ": " + ((CardinalDirections.dir)i).ToString()).Dump();
		
	"\n----\n".Dump();
		
	int[,] a = new int[10,10];
	
	var mapDir = new CardinalDirections(10, 10);
	
	var pt = new intPoint(5,5);
	a[pt.y, pt.x] += 4;
	
	a.Dump();
	
	bool can;
	
	var sw = new Stopwatch();
	sw.Restart();
	
	can = mapDir.north(pt);
	
	sw.Stop();
	
	can.Dump();
	
	pt.Dump();
	
	sw.Elapsed.Dump();
	
	a[pt.y, pt.x] += 3;
	
	mapDir.northeast(pt);
	
	a[pt.y, pt.x] += 2;
	
	mapDir.east(pt);
	
	a[pt.y, pt.x] += 1;
	
	mapDir.southeast(pt);
	
	a[pt.y, pt.x] += 1;
	
	mapDir.south(pt);
	
	a[pt.y, pt.x] += 1;
	
	mapDir.southwest(pt);
	
	a[pt.y, pt.x] += 1;
	
	mapDir.west(pt);
	
	a[pt.y, pt.x] += 1;
	
	mapDir.northwest(pt);
	
	a[pt.y, pt.x] += 1;
	
	a.Dump();
	
	sw.Restart();
	
	mapDir.n(pt);
	
	a[pt.y, pt.x] += 1;
	
	mapDir.ne(pt);
	
	a[pt.y, pt.x] += 1;
	
	mapDir.e(pt);
	
	a[pt.y, pt.x] += 1;
	
	mapDir.se(pt);
	
	a[pt.y, pt.x] += 1;
	
	mapDir.s(pt);
	
	a[pt.y, pt.x] += 1;
	
	mapDir.sw(pt);
	
	a[pt.y, pt.x] += 1;
	
	mapDir.w(pt);
	
	a[pt.y, pt.x] += 1;
	
	mapDir.nw(pt);
	
	a[pt.y, pt.x] += 1;
	
	sw.Stop();
	
	a.Dump();
	
	sw.Elapsed.Dump();
	
	/*for(int x = 0; x < mapDir.width; x++)
	{
		for(int y = 0; y < mapDir.height; y++)
		{
			Console.Write(a[x, y]);
		}
		Console.WriteLine();
	}*/
}

class CardinalDirections
{
	public int width;
	public int height;
	
	public CardinalDirections(int _width, int _height)
	{
		width = _width;
		height = _height;
	}
	
	public bool north(intPoint pt)
	{
		if(pt.y > 0)
		{
			pt.y--;
		}
		
		return false;
	}
	
	public bool n(intPoint pt)
	{
		return north(pt);
	}
	
	public bool northeast(intPoint pt)
	{
		if(pt.x < width - 1 && pt.y > 0)
		{
			pt.x++;
			
			pt.y--;
		}
		
		return false;
	}
	
	public bool ne(intPoint pt)
	{
		return northeast(pt);
	}
	
	public bool east(intPoint pt)
	{
		if(pt.x < width - 1)
		{
			pt.x++;
		}
		
		return false;
	}
	
	public bool e(intPoint pt)
	{
		return east(pt);
	}
	
	public bool southeast(intPoint pt)
	{
		if(pt.x < width - 1 && pt.y < height - 1)
		{
			pt.x++;
			
			pt.y++;
		}
		
		return false;
	}
	
	public bool se(intPoint pt)
	{
		return southeast(pt);
	}
	
	public bool south(intPoint pt)
	{
		if(pt.y < height - 1)
		{
			pt.y++;
		}
		
		return false;
	}
	
	public bool s(intPoint pt)
	{
		return south(pt);
	}
	
	public bool southwest(intPoint pt)
	{
		if(pt.x > 0 && pt.y < height - 1)
		{
			pt.x--;
		
			pt.y++;
		}
		
		return false;
	}
	
	public bool sw(intPoint pt)
	{
		return southwest(pt);
	}
	
	public bool west(intPoint pt)
	{
		if(pt.x > 0)
		{
			pt.x--;
		}
		
		return false;
	}
	
	public bool w(intPoint pt)
	{
		return west(pt);
	}
	
	public bool northwest(intPoint pt)
	{
		if(pt.y > 0 && pt.x > 0)
		{
			pt.x--;
			
			pt.y--;
		}
		
		return false;
	}
	
	public bool nw(intPoint pt)
	{
		return northwest(pt);
	}
	
	public enum dir
	{
		north = 1,
		northeast,
		east,
		southeast,
		south,
		southwest,
		west,
		northwest
		
	}
}

class intPoint
{
	public int x;
	public int y;
	
	public intPoint(int _x, int _y)
	{
		x = _x;
		y = _y;
	}
}