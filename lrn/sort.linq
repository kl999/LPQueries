<Query Kind="Statements" />

Random rand = new Random();
var a = new int[100];

for(int i = 0; i < a.Length; i++)
{
	a[i] = rand.Next(20) + 1;
}

int[] b = (int[])a.Clone();

Array.Sort (a,
	(i, j) => 
	{
		if(i == j) return 0;
		
		if(i < 10 && j > 10) return -1;
		
		if(i > 10 && j < 10) return 1;
		
		if(i > j) return -1;
		
		if(i < j) return 1;
		
		return 0; 
	});
//Array.Sort (a,(x, y) => x % 2 == y % 2 ? 0 : x % 2 == 1 ? -1 : 1);

b.Select((i, j) => string.Format("{0:00}: {1,2} {2,2}", j, i, a[j])).Dump();

int[] arr = new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

Array.Sort(arr, (x, y) =>
{
	return -1;
});

arr.Dump();