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

int i = 0;

void Main()
{
	foreach(var o in a(fin()))
	{
		("out: " + o).Dump();
	}
}

IEnumerable<int> a(IEnumerable<int> b)
{
	foreach(int o in b)
	{
		("m: " + i).Dump();
		
		yield return i++;
	}
	
	yield break;
}

IEnumerable<int> fin()
{
	for(int o = 0; o < 10; o++)
	{
		("d: " + i).Dump();
		
		yield return i++;
	}
	
	yield break;
}