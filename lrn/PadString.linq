<Query Kind="Statements" />

for(int i = 1; i < 1000000; i += i * 2)
{
	i.ToString().PadLeft(6,'-').Dump();
}