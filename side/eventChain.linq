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

///chain of events with different time length

void Main()
{
	Random rand = new Random();
	List<draw> randL = new List<draw>();
	
	for(int i = 0; i < 10; i++)
	{
		if(i % 2 == 0)
			randL.Add(new drawSticks(rand.Next(10)));
		else
			randL.Add(new drawStars(rand.Next(10)));
	}
	
	randL.Select(i => ((drawSticks)i).times).Dump();
	
	for( ; !randL.Last().done; )
	{
		Task del = Task.Delay(500);
		
		Console.Write("_");
		
		foreach(drawSticks o in randL)
		{
			if(!o.done)
			{
				o.draw();
				break;
			}
		}
		
		del.Wait();
	}
}

interface draw
{
	bool done { get; set; }
	
	void draw();
}

class drawSticks : draw
{
	public bool done { get; set; }
	
	public int times = 0;
	
	internal int drawn = 0;
	
	public drawSticks(int _times)
	{
		times = _times;
		
		done = false;
	}
	
	public virtual void draw()
	{
		if(times != 0)
		{
			Console.Write("|");
			
			drawn++;
		}
		
		if(drawn == times)
		{
			done = true;
			Console.Write(" " + drawn + "\n");
		}
	}
}

class drawStars : drawSticks
{
	public drawStars(int _times) : base(_times)
	{
		
	}
	
	public override void draw()
	{
		if(times != 0)
		{
			Console.Write("*");
			
			drawn++;
		}
		
		if(drawn == times)
		{
			done = true;
			Console.Write(" " + drawn + "\n");
		}
	}
}