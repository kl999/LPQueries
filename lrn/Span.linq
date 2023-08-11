<Query Kind="Program">
  <Namespace>BenchmarkDotNet.Attributes</Namespace>
</Query>

#load "BenchmarkDotNet"

void Main()
{
	RunBenchmark();
}

public void UseSpan(Span<int> a)
{
	var sum = 0;
	
	for(int i = 0; i < a.Length; i++)
	{
		sum += a[i];
	}
	
	Console.WriteLine(sum);
}

[Benchmark]
public void UseArray()   // Benchmark methods must be public.
{
	Span<int> a = new []{ 1, 2, 3, 4, 5 };
	
	var sum = 0;
	
	for(int i = 0; i < a.Length; i++)
	{
		sum += a[i];
	}
	
	Console.WriteLine(sum);
}

[Benchmark]
public void UseStackAlock()   // Benchmark methods must be public.
{
	Span<int> a = stackalloc int[]{ 1, 2, 3, 4, 5 };
	
	var sum = 0;
	
	for(int i = 0; i < a.Length; i++)
	{
		sum += a[i];
	}
	
	Console.WriteLine(sum);
}

[GlobalSetup]
public void BenchmarkSetup()
{
	// optional setup code...
}