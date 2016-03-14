<Query Kind="Program" />

void Main()
{
	a(1000).Where(i => i % 2 != 0).Dump();
	a(100).Dump("Me");
}

IEnumerable<int> a(int i)
{
	int x = i;
	
	for(int j = 0; j < x; j++)
	{
		yield return ++i;
	}
}