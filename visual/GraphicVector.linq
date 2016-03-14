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
	var showDC = new DumpContainer();
	
	showDC.Dump("Screen");
	
	Bitmap render = new Bitmap(640, 480);
	
	var g = Graphics.FromImage(render);
	
	g.Clear(Color.White);
	
	showDC.Content = render;
	
	var o = new Point(100, 10);
	
	var vel = new Point(0, 0);//(2, 1);
	
	var accel = new Point(0.1, 0.1);
	
	var stop = Task.Run(() => Console.ReadLine());
	
	var startdt = DateTime.Now;
	
	var path = new List<Point>();
	
	bool f1 = false;
	
	for(bool go = true; go; )
	{
		var tmr = Task.Delay(200);
		
		if( (DateTime.Now - startdt) > TimeSpan.Parse("0:0:8"))
		{
			accel = new Point(-0.3, -0.2);
		}
		
		if( (DateTime.Now - startdt) > TimeSpan.Parse("0:0:18") && !f1)
		{
			"45".Dump();
			
			vel = angledQ(vel, 45);
			
			f1 = true;
			
			//go = false;
		}
		
		vel.add(accel);
		
		o.add(vel);
		
		//---
		
		path.Add(o.copy());
		
		g.Clear(Color.White);
		
		g.FillEllipse(Brushes.Black, (int)o.x, (int)o.y, 10, 10);
		
		showDC.Content = null;
		
		showDC.Content = render;
		
		tmr.Wait();
		
		if(stop.IsCompleted)
			go = false;
	}
	
	g.Clear(Color.White);
	
	foreach(var pt in path.AsEnumerable().Reverse().Skip(1).Where((i, ind) => ind % 3 == 0))
	{
		g.FillEllipse(Brushes.Gray, (int)pt.x, (int)pt.y, 10, 10);
	}
	
	g.FillEllipse(Brushes.Black, (int)o.x, (int)o.y, 10, 10);
	
	showDC.Content = null;
	
	showDC.Content = render;
	
	path.Dump();
}

Point angledQ(Point input, int angle)
{
	double oldlen = Math.Sqrt(input.x*input.x + input.y*input.y);
	
	if(angle >= 90)
		return new Point(0, 0);
	
	double tmp = (double)angle / 90.0;
	
	double newlen = oldlen * tmp;
	
	double olda = Math.Asin(input.y / oldlen);
	
	double a = (double)angle * Math.PI / 180.0;
	
	//sin(olda + a) = y / newlen
	
	double yf = Math.Sin(olda + a) * newlen;
	
	double xf = Math.Sqrt(newlen*newlen - yf*yf);
	
	(newlen + " " + xf + " " + yf).Dump();
	
	return new Point(xf, yf);
}

////////////////////////////////////////////////////////////////////////////////////////////////

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