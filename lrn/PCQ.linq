<Query Kind="Program">
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var inQue = new BlockingCollection<tCl>();
	
	var outQue = new ConcurrentBag<string>();
	
	Random rand = new Random();
	
	Task t1 = new Task(() =>
	{
		for(;;)
		{
			tCl temp = new tCl();
			string tStr = Console.ReadLine();
			
			temp.word = tStr;
			temp.length = tStr.Length;
			
			inQue.TryAdd(temp);
			
			if(tStr == "exit")
			break;
		}
	});
	
	Task t2 = new Task(() =>
	{
		for(;;)
		{
			tCl temp = inQue.Take();
			
			int i = 1;
			foreach(char ch in temp.word)
			{
				if(ch == 'a')
				{
					temp.firstA = i;
					"hello".Dump();
					break;
				}
				i++;
			}
			
			temp.Dump();
			
			if(temp.word == "exit")
			break;
		}
	});
	
	t1.Start();
	t2.Start();
	
	Task.WaitAll(new Task[]{ t1, t2 });
}

class tCl
{
	public string word = "no";
	public int length = -1;
	public int? firstA = null;
	
	public override string ToString()
	{
		if(firstA != null)
		return String.Format("\"{0}\" : len = {1}, first 'a' at = {2}", word, length, firstA);
		else
		return String.Format("\"{0}\" : len = {1}, no 'a' letters", word, length);
	}
}