<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Drawing.Imaging</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Reflection.Emit</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var dsp = new DumpContainer();
dsp.Dump();

dsp.Content = "ASD";

int max = 3;

int[][] arr = new int[][]
{
	new[]{ 0, 0 },
	new[]{ 2, 0 },
	new[]{ 1, 2 }
};

for(ulong i = 0; ; i++)
{
	string str = "";
	
	//arr.Dump();
	
	for(int x = 0; x < 3; x++)
	{
		for(int y = 0; y < 3; y++)
		{
			string add = "+";
			
			foreach(var o in arr)
				if(o[0] == x && o[1] == y) add = "X";
			
			str += add;
		}
		
		str += "\n";
	}
	
	foreach(var o in arr)
	{
		if(o[0] == 0 && o[1] < max - 1)
		{
			o[1]++;
			continue;
		}
		
		if(o[0] == max - 1 && o[1] > 0)
		{
			o[1]--;
			
			continue;
		}
		
		if(o[1] == max - 1 && o[0] < max - 1)
		{
			o[0]++;
			
			continue;
		}
		
		if(o[1] == 0 && o[0] > 0)
		{
			o[0]--;
			
			continue;
		}
	}
	
	dsp.Content = str;
	
	Task.Delay(300).Wait();
}