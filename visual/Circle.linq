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

int depth = 20;
List<DumpContainer> dcl;

void Main()
{
	dcl = new List<DumpContainer>();
	
	for(int i = 0; i < depth * 2 + 1; i++)
	{
		if(i == depth) { "".Dump(); continue;}
		
		dcl.Add(new DumpContainer());
		
		dcl.Last().Dump();
	}
	
	/*place(1, '5');
	dcl[7].Content = "Z"; return;*/
	
	var end = Task.Run(() => { Console.ReadLine(); });
	
	bool back = false;
	
	for(int z = 0; ; z++)
	{
		clear();
		
		if(z == depth) { z = 0; back = back ? false : true; }
		
		if(!back)
		{
			place(z + 1, '8');
			
			place(-depth - -z, '1');
		}
		else
		{
			place(-z - 1, '8');
			
			place(depth - z, '1');
		}
		
		if(!end.IsCompleted)
		{
			Thread.Sleep(50);
		}
		else
			break;
	}
}

void clear()
{
	int n = 0;
	
	for(; n < depth; n++)
	{
		place(n + 1, '-');
	}
	
	for(; n > 0; n--)
	{
		place(-depth - -n - 1, '-');
	}
}

void place(int pos, char ch)
{
	int apos = Math.Abs(pos);
	
	if(pos < 0)
	{
		pos = depth + apos - 1;
		
		apos = depth - apos;
	}
	else
	{
		pos -=1;
		apos -= 1;
	}
	
	//pos.Dump();
	
	dcl[pos].Content = (new string(' ', apos) + ch);
}