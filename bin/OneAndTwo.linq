<Query Kind="Program">
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

bool forOne = true;
bool forTwo = true;

void Main()
{
//	Task.Run(() => one());
//	
//	Thread.Sleep(100);
//	
//	Task.Run(() => two());

	for(int i = 0 ;i < 1000; i++)
	{
		var a = i; 
		hi(a);
	}
}

object locker = new object();

Random rand = new Random();

void hi(int i)
{
	Action a = () =>
	{
		Thread.Sleep(rand.Next(10));
		
		("hi " + i).Dump();
	};
	Task.Run(a);
}

void one()
{
	for(;;)
	{
		
		
		
		if(forOne)
		{
			forTwo = false;
			
			Thread.Sleep(20);
			
			forTwo = true;
		}
		else
		{
			"one is dead".Dump();
			forTwo = false;
			break;
		}
		
		Thread.Sleep(100);
		
		
	}
}

void two()
{
	for(;;)
	{
		
		
		
		if(forTwo)
		{
			forOne = false;
			
			Thread.Sleep(3);
			
			forOne = true;
		}
		else
		{
			"two is dead".Dump();
			forOne = false;
			break;
		}
		
		
		Thread.Sleep(100);
		
	}
}