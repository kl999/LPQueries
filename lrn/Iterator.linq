<Query Kind="Program" />

void Main()
{
	foreach(int i in en(3))
	{
		i.Dump();
	}
}

IEnumerable<int> en(int start)
{
	for(int i = start; i <= start + 10; i++)
	{
		yield return i * 10;
	}
}