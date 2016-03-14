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
	RecCl o = null;
	
	{
		o = new RecCl("outer"){ inCl = new RecCl("inner") };
		
		o = o.inCl;
	}
	
	System.GC.Collect();
	
	Thread.Sleep(15000);
	
	o.Dump();
	
	"End".Dump();
}

class RecCl
{
	public RecCl inCl = null;
	
	public string name;
	
	public RecCl(string _name)
	{
		name = _name;
	}
	
	~RecCl()
	{
		("I \"" + name + "\" die!").Dump();
	}
}