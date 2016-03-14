<Query Kind="Program">
  <Namespace>System.IO</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	if(File.Exists("c:\\sp\\log.txt"))
		File.Delete("c:\\sp\\log.txt");
	
	Task t1 = new Task( () =>
	{
		for(int i = 0 ; i < 100; i++)
			log.write("hello " + i + " from 1");
	});
	
	Task t2 = new Task( () =>
	{
		for(int i = 0 ; i < 100; i++)
			log.write("hello " + i + " from 2");
	});
	
	t1.Start();
	t2.Start();
	
	await t1;
	await t2;
}

public static class log
{
	private static object locker = new object();

	public static void write(string msg)
	{
		lock(locker) if(msg != null || msg != "")
			using(StreamWriter wrtr = new StreamWriter("c:\\sp\\log.txt", true))
			{
				wrtr.WriteLine();
				wrtr.WriteLine();
				wrtr.WriteLine();
				wrtr.WriteLine("-----------------------");
				wrtr.WriteLine(String.Format("| {0} |", DateTime.Now));
				wrtr.WriteLine("-----------------------");
				wrtr.WriteLine("vvvvvvvvvvvvvvvvvvvvvvv");
				wrtr.WriteLine();
				
				string[] temp = msg.Split('\n');
				
				foreach(string str in temp)
					wrtr.WriteLine(str);
				
				wrtr.WriteLine();
				wrtr.WriteLine("^^^^^^^^^^^^^^^^^^^^^^^");
				wrtr.WriteLine();
			}
	}
}