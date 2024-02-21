<Query Kind="Statements">
  <Namespace>System.Text.Json</Namespace>
  <Namespace>System.Text.Json.Nodes</Namespace>
  <Namespace>System.Text.Json.Serialization</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

dynamic getThreads()
{
	ThreadPool.GetAvailableThreads(out int worker, out int io);

	ThreadPool.GetMaxThreads(out int workerMax, out int ioMax);

	return new{ worker, io, workerMax, ioMax };
}

(getThreads() as object).Dump("Initial");

/*var tasks = new List<Task>();
for(int i = 0; i < 1000; i++)
{
	var id = i;
	tasks.Add(new Task(async () =>
	{
		Task.Delay(5000).Wait();
		$"{DateTime.Now:mm:ss.ffff}: Task {id} start".Dump();
		await Task.Delay(5000);
		$"{DateTime.Now:mm:ss.ffff}: Task {id} finish".Dump();
	}));
}*/

var dc = new DumpContainer ().Dump();

var trdStop = false;
var trd = new Thread(() =>
{
	for(;!trdStop;)
	{
		dc.Content = getThreads();
	}
	
	dc.Content = JsonNode.Parse("""
{
	"End": "!"
}
""");
});

trd.Start();

Parallel.ForEach(new int[1000], async (a, b, id) =>
{
	Task.Delay(500).Wait();
	$"{DateTime.Now:mm:ss.ffff}: Task {id} start".Dump();
	await Task.Delay(5000);
	$"{DateTime.Now:mm:ss.ffff}: Task {id} finish".Dump();
});

trdStop = true;
