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
).Split()
.Select( (i, ind) => i.PadRight(15) + ind)
.ToList();

//var inQue = new ConcurrentQueue<string>();
var inQue = new BlockingCollection<string>();

var outQue = new ConcurrentQueue<string>();

object locker = new object();

Task t1 = new Task(() =>
{
	try
	{
		for(int i = 0; i < str.Count; i++)
		{
			//inQue.Enqueue(str[i]);
			inQue.Add(str[i]);
			//Task.Delay(300).Wait();
		}
	} catch (Exception ex) { ex.Message.Dump(); }
});

Task t2 = new Task(() =>
{
	try
	{
		for(int i = 0; i < str.Count; i++)
		{
			string temp = "no one be hear transform asdfg";
			//if(inQue.TryDequeue(out temp))
			temp = inQue.Take();
			{				
				outQue.Enqueue(temp);
			}
		}
	} catch (Exception ex) { ex.Message.Dump(); }
});

t1.Start();
t2.Start();

Task.WaitAll(new Task[]{ t1, t2 });

outQue.Dump();