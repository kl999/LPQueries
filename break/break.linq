<Query Kind="Program" />

void Main()
{
	one();
	
	int[] a = new[]{ 1, 10, 100 };
	var q = a.Select(i => i);
	
	//q.Dump();
	
	q = a.Where(i => q.Contains(i));
	
	q.Dump();
}

void one()
{
	"one".Dump();
	two();
}

void two()
{
	one();
	"two".Dump();
}