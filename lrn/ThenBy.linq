<Query Kind="Program" />

void Main()
{
	List<Int> lst = new List<Int>();
	
	for(int i = 1; !(i > 10); i++)
	{
		for(int j = 1; !(j > 10); j++)
		{
			lst.Add(new Int{ i1 = i, i2 = j });
		}
	}
	
	lst.OrderBy(o => o.i1).ThenByDescending( o => o.i2).Select(o => o.ToString()).Dump();
}

class Int
{
	public int i1 = 0;
	public int i2 = 0;
	
	public override string ToString()
	{
		return string.Format("{0,2} {1,2}", i1, i2);
	}
}