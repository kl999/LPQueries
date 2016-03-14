<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Runtime.InteropServices</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	"a".OnDemand("z").GetType().Dump();
	
	new WithOnDem().Dump();
}

class WithOnDem
{
	public DumpContainer Fun = "I say it is fun!".OnDemand("fun");
}