<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	lcl o = new lcl();
	
	o.a.OnDemand("a of o").Dump();
	
	Lazy<lcl> o2 = new Lazy<lcl>();
	
	//new[] { 1, 3, 5 }.Select(i => i + 1).OnDemand("LZ?").Select(i => i * 3).Dump(); //DumpContainer
	
	new int[1].Select(i => new lzo()).OnDemand("THIS... IS... LZO!!!").Dump();
	
	new bool[1].Select(i =>
	{
		"I am SO lazy!".Dump();
	
		o2.Value.b().Dump();
		
		return i;
	}).OnDemand("Lazy inline for lazies").Dump();
}

class lcl
{
	public List<int> a = new List<int>(new[]{ 3, 5 });
	
	public int b()
	{
		"Get val".Dump();
		
		return 7;
	}
}

class lzo
{
	public int a = 5;
	
	public int b = 6;
	
	public lzo()
	{
		"I live!".Dump();
	}
}