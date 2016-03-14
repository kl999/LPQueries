<Query Kind="Statements">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Nutshell.mdf</AttachFileName>
    <Persist>true</Persist>
  </Connection>
  <Namespace>System.Collections.Concurrent</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

List<string> str = (
  "Some say the world will end in fire "
+ "Some say in ice "
+ "From what I’ve tasted of desire "
+ "I stand with those who favor fire "
+ "But if it was to parish twice "
+ "I think I know enough of hate "
+ "To say that for distraction ice is also great "
+ "And will suffice"
).Split().ToList();

//str.Count.Dump("Count");

var inQue = new ConcurrentBag<string>(str);

var outQue = new ConcurrentQueue<string>();

Task t1 = new Task(() =>
{
	try
	{
		for(int i = 0; i < str.Count; i++)
		{
			string temp = "noonebe heartransformasdfg";
			inQue.TryTake(out temp);
			
			outQue.Enqueue(temp + " - " + temp.Length + " => First");
		}
	} catch { }
});

Task t2 = new Task(() =>
{
	try
	{
		for(int i = 0; i < str.Count; i++)
		{
			string temp = "no one be hear transform asdfg";
			inQue.TryTake(out temp);
			
			outQue.Enqueue(temp + " - " + temp.Length + " => Second");
		}
	} catch { }
});

t1.Start();
t2.Start();

Task.WaitAll(new Task[]{ t1, t2 });

//Thread.Sleep(100);

outQue.Dump();