<Query Kind="Program">
  <Namespace>System.Threading</Namespace>
</Query>

void Main()
{
	bool lost = false;
	
	Source source = new Source();
	
	eCl me = new eCl(source);
	
	List<eCl> subEngs = new List<eCl>();
	
	for(int i = 0; i < 5; i++)
	{
		subEngs.Add(new eCl(source));
	}
	
	for(; !lost;)
	{
		me.work(subEngs);
		
		source.power.Dump("U: " + DateTime.Now);
		Thread.Sleep(500);
		
		if(source.power < 0)
		{
			lost = true;
			"U lost!".Dump();
		}
	}
}

class eCl
{
	Source source;
	
	double lose = 0.45f;
	
	public eCl(Source src)
	{
		source = src;
	}
	
	public void work(List<eCl> subs)
	{
		double tkAmm = 10;
		
		source.power -= tkAmm;
		
		foreach(eCl obj in subs)
		{
			obj.isWorkedOn((tkAmm * lose));
		}
	}
	
	public void isWorkedOn(double amm)
	{
		double finish = amm * lose;
		source.power += finish;
	}
}

class Source
{
	public Source()
	{
		
	}
	public double power = 100;
}