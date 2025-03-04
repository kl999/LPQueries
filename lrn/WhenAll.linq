<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

Random rand = new Random();

async void Main()
{
	var sw = new System.Diagnostics.Stopwatch();
	sw.Start();
	
	var nums = Enumerable.Repeat(0, 20).Select((i, ind) => A(ind));
	var chars = Enumerable.Repeat((byte)'a', 26).Select((i, ind) => B((byte)(i + ind)));
	
	await Task.WhenAll(nums.Concat(chars));
	//foreach(var task in nums.Concat(chars)) await task;
	
	"End".Dump();
	sw.Stop();
	sw.Dump();
}

private async Task A(int a)
{
	await Task.Delay(500 + rand.Next(500));
	
	$"t:{Thread.CurrentThread.ManagedThreadId}(p:{Thread.CurrentThread.IsThreadPoolThread}) = {a}".Dump();
}

private async Task B(byte b)
{
	await Task.Delay(500 + rand.Next(500));
	
	$"t:{Thread.CurrentThread.ManagedThreadId}(p:{Thread.CurrentThread.IsThreadPoolThread}) = {(char)b}".Dump();
}
