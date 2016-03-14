<Query Kind="Program">
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Locker locker = new Locker();
	
	lock(locker)
	{
		Task.Run(() =>
		{
			lock(locker)
			{
				"Unlocked".Dump();
			}
		});
		
		//locker.val += 1;
		Thread.Sleep(100);
	}
	
	"Lock lifted".Dump();
}

class Locker
{
	public int val = 0;
}