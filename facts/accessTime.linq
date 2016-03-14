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
	int a = 5;
	
	var c = new cls();
	
	var sw = new Stopwatch();
	
	sw.Restart();
	for(int i = 0; i < 1000000000; i++)
	{
		if(c.a == 5)
		{
			
		}
	}
	sw.Stop();
	sw.Dump("obj");
	
	sw.Restart();
	for(int i = 0; i < 1000000000; i++)
	{
		if(a == 5)
		{
			
		}
	}
	sw.Stop();
	sw.Dump("nothing");
	
	int[] arr = new int[5];
	
	sw.Restart();
	for(int i = 0; i < 1000000000; i++)
	{
		if(arr.Length == 5)
		{
			
		}
	}
	sw.Stop();
	sw.Dump("arr");
	
	sw.Restart();
	for(int i = 0; i < 100000000; i++)
	{
		List<int> az = new List<int>();
	}
	sw.Stop();
	sw.Dump("init list");
		
	sw.Restart();
	for(int i = 0; i < 100000000; i++)
	{
		int[] az = new int[10];
	}
	sw.Stop();
	sw.Dump("init arr");
}

class cls
{
	public int a = 5;
}