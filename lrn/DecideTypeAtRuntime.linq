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
	var lst = new List<bs>(new bs[] { new bs(), new a(), new b() });
	
	foreach(var o in lst)
		hello(o);
	
	"".Dump();
	
	foreach(var o in lst)
		hello((dynamic)o);
}

void hello(bs o)
{
	"Hello base".Dump();
}

void hello(a o)
{
	"Hello a".Dump();
}

void hello(b o)
{
	"Hello b".Dump();
}

class bs
{
}

class a : bs
{
}

class b : bs
{
}