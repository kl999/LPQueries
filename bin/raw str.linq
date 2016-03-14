<Query Kind="Statements">
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

unsafe
{
	char _a = '0';
	char* a = &_a;
	
	a += 2000000;
	
	string raw = "";
	for(int i = 0; i < 50; i++, a++)
	{
		"i".Dump();
		raw += *a;
	}
	
	("\"" + raw + "\"").Dump();
}