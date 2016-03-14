<Query Kind="Statements">
  <Connection>
    <ID>f2f6e2b4-0f40-48df-b2c7-82584a77c393</ID>
    <Server>.\SQLEXPRESS</Server>
    <AttachFile>true</AttachFile>
    <UserInstance>true</UserInstance>
    <AttachFileName>&lt;ApplicationData&gt;\LINQPad\Nutshell.mdf</AttachFileName>
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

int sCount = str.Count.Dump("Count");

var inQue = new BlockingCollection<string>();

var outQue = new ConcurrentBag<string>();

Random rand = new Random();

Task t1 = new Task(() =>
{
	for(int i = 0; i < 1000; i++)
	{
		inQue.TryAdd(str[rand.Next(sCount)]);
		Thread.Sleep(rand.Next(5));
		if(i==500)
		{inQue.CompleteAdding(); break;}
	}
});

Task t2 = new Task(() =>
{
	for(int i = 0; i < 1000 && !inQue.IsAddingCompleted; i++)
	{
		string temp = "none";
		
		try{
		temp = inQue.Take();} catch(Exception ex){ex.Message.Dump();}
		
		temp.Dump();
		
		if(temp != null)
		outQue.Add(temp);
	}
});

t1.Start();
t2.Start();

Task.WaitAll(new Task[]{ t1, t2 });

//outQue.Dump();