<Query Kind="Statements" />

unsafe
{
	byte* a = stackalloc byte [1];
	
	for (int i = 0; i < 10000; ++i)
		Console.Write(String.Format(" {0:X}",a[i])); // Print raw memory
}