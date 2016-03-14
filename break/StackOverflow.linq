<Query Kind="Program">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	rec();
}

void rec(int ct = 0)
{
	ct.Dump();
	
	if(ct < 40000)
		rec(++ct);
	else
		return;
}