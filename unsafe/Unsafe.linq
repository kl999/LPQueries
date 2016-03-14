<Query Kind="Program" />

static void Main()
{
	Test test = new Test();
	unsafe
	{
		fixed (int* p = &test.x)	// Pins test.x
		{
			*p = 9;
		}
		System.Console.WriteLine (test.x);
	}
}

class Test
{
	public int x;
}