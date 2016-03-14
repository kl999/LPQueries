<Query Kind="Program">
  <Namespace>System.Threading</Namespace>
</Query>

void Main()
{
	difChance(100);
}

void difChance(int count)
{
	int interval = DateTime.Now.Millisecond;
	Thread.Sleep(interval * 5);
	Random rand = new Random(DateTime.Now.Hour + DateTime.Now.Millisecond);
	
	if(interval > 100)
		interval /= 10;
		
	List<string> rez = new List<string>();
	
	for(int i = 0; i < count; i++)
	{
		int a = 0;
		int b = 0;
		
		if(i == 0)
		{ a = 0; b = 100; }
		
		if(i == 1)
		{ a = 100; b = 0; }
		
		if(i == 2)
		{ a = 100; b = 50; }
		
		if(i > 2 || count < 100)
		{
			a = rand.Next(101);
			Thread.Sleep(interval);
			
			b = rand.Next(101);
			Thread.Sleep(interval);
		}
		
		int differ = a - b;
		
		//----------------------------------------
		
		double percent = (double)differ;
		
		if(percent >= 0)
		{
			percent = 30 + percent * 0.7;
		
			percent *= 0.973;
		}
		else
		{
			percent = 100 + percent;
			
			percent = 2.7 + percent * 0.273;
		}
		
		//----------------------------------------
		
		rez.Add(
		String.Format("{0,2}: {1,3} - {2,-3}"
			+ " difference = {3,-3:-0;\' '0;equals}\n"
			+ "percent is:  {4:0.##}%",
			i, a, b, differ, percent)
			);
	}
	rez.Dump();
}