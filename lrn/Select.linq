<Query Kind="Statements" />

int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

arr = arr.Select( i =>
{
	if(i == 0)
		return 10;
	if(i > 3)
		return i -= 3;
	return i;
}).ToArray();

arr.Dump();