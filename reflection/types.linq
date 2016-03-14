<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	Type tp = typeof(myCl).Dump();
	
	tp.ToString().Dump();
	
	(new myCl()).GetType().Dump();
}

class myCl
{
}