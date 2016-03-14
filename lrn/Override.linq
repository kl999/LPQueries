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
	P o1 = new P();
	o1.mtd();
	
	Ch o2 = new Ch();
	o2.mtd();
	
	P o3 = new Ch();
	o3.mtd();
}

class P
{
	public virtual void mtd()
	{
		"Hello".Dump();
	}
}

class Ch : P
{
	public override void mtd()
	{
		"World".Dump();
	}
}