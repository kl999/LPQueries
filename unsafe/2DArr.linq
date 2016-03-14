<Query Kind="Statements">
  <Namespace>System.Diagnostics</Namespace>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

bool[,] arr = new bool[10, 10];

arr[1, 0] = true;

unsafe
{
	fixed(bool* p = arr)
	{
		for(int i = 0; i < 100; i++)
		{
			p[i].Dump(i.ToString());
			
			if(i % 10 == 5 || i / 10 == 3)
			{
				p[i] = true;
			}
		}
	}
}

arr.Dump();