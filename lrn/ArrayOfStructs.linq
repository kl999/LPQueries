<Query Kind="Program" />

void Main()
{
	def[] arr = new def[3];
	
	arr[0].i.Dump();
	
	arr[0] = new def(3);
	
	arr[0].i.Dump();
}

struct def
{
	public int i;
	
	public def(int _i)
	{
		i = _i;
	}
}
