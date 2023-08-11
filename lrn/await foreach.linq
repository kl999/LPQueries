<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

await foreach(var a in GetValsAsync())
{
	a.Dump();
}

async IAsyncEnumerable<int> GetValsAsync()
{
	for(int i = 0; i < 100; i++)
	{
		await Task.Delay(100 + Random.Shared.Next(200));
		
		yield return i;
	}
}