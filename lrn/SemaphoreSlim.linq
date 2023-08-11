<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var semaphore = new SemaphoreSlim(0, 2);

Task.Run(() =>
{
	for(;;)
	{
		semaphore.Wait();
		
		"A".Dump();
	}
});

Task.Run(() =>
{
	for(;;)
	{
		semaphore.Wait();
		
		"A".Dump();
	}
});

new Hyperlinq(() => semaphore.Release(2), "Release 2").Dump();

new Hyperlinq(() => semaphore.Release(), "Release 1").Dump();

new Hyperlinq(() => semaphore.Release(3), "Release 3").Dump();
