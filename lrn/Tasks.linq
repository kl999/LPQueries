<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

Task tsk = new Task(() =>
					{
						Thread.Sleep(1000);
						"Hello threads!".Dump();
					});

Action<Task> tsk3 = new Action<Task>((i)=>{ "asd".Dump(); });
tsk.ContinueWith(tsk3);
tsk.Start();

Task tsk2 = new Task(()=>{"z".Dump();});
Task.WaitAll(new Task[]{ tsk });

tsk2.Start();

Task.Run(() => 
{
	Thread.Sleep(1000);
	"Hi all,".Dump();
});