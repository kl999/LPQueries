<Query Kind="Program">
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var t1 = getAsync();
	"?m".Dump();
	
	Task.Delay(3000).Wait();
	"3 sec".Dump();
	
	(t1.Result).Dump();
}

async Task<string> getAsync()
{
	await Task.Delay(5000);
	"?a".Dump();
	
	return "5 sec";
}