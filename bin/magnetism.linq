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
string template = @"
...
.x.
...
";
	
string real = @"
...
...
.x.
";

ld(template).Dump();
}

bool[,] ld(string orig)
{
	string[] lines = orig.Split('\n');
	
	//lines.Dump();
	
	int len = lines.Length - 2,
		lenw = lines[1].Trim().Length;
	
	bool[,] rez = new bool[lenw, len];
	
	for(int i = 0; i < len; i++)
	{
		for(int j = 0; j < lenw; j++)
		{
			rez[i, j] = lines[i + 1][j] == '.' ? false : true;
		}
	}
	
	return rez;
}