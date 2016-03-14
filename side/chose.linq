<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Action hit = () => "Hit".Dump();
	Action run = () => "Run".Dump();

	Func<string, suggestedAction> sugHit = (str) =>
	{
		if(str == "day")
			return new suggestedAction(){a = hit, proc = 80};
		
		return new suggestedAction(){a = hit, proc = 0};
	};
	
	Func<string, suggestedAction> sugRun = (str) =>
	{
		if(str == "night")
			return new suggestedAction(){a = run, proc = 80};
		
		return new suggestedAction(){a = run, proc = 0};
	};
	
	List<Func<string, suggestedAction>> variants =
		new List<Func<string, suggestedAction>>(new[]{sugHit, sugRun});
	
	Random rand = new Random();
	
	variants
	.Select(i => i("day"))
	.Select(i => {i.proc += rand.Next(10) - 4; return i;})
	.OrderByDescending(i => i.proc)
	.First().a();
	//.Dump();
}

struct suggestedAction
{
	public Action a;
	
	public int proc;
}