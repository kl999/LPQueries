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
	List<bClass> lst = new List<bClass>();
	
	lst.Add(new bClass());
	
	lst.Add(new heir());
	
	lst.Add(new heir2());
	
	foreach(bClass o in lst)
		o.doTmth();
}

class bClass
{
	public virtual void doTmth()
	{
		"base".Dump();
	}
}

class heir : bClass
{
	public override void doTmth()
	{
		"heir".Dump();
	}
}

class heir2 : heir
{
	public override void doTmth()
	{
		"heir of:".Dump();
		
		base.doTmth();
	}
}