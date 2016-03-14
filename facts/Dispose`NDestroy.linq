<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	{
		//new ClTst();
		
		/*using(ClTst a = new ClTst())
		{
		}*/
		
		cl2 cl = new cl2(new ClTst());
	}
	
	Task.Delay(1000).Wait();
	
	"\nNext\n".Dump();
	
	using(ClTst a = new ClTst())
	{
	}
}

class ClTst : IDisposable
{
	public void Dispose()
	{
		Console.WriteLine("Disposed");
	}
	
	~ClTst()
	{
		Console.WriteLine("Destructed");
	}
}

class cl2
{
	ClTst obj;

	public cl2(ClTst _obj)
	{
		obj = _obj;
	}
}