<Query Kind="Statements" />

double max = 100;

for(int i = 0; i < max; i++)
{
	( max * (Math.Pow(((i / max) - 0.5), 3) * 4 + 0.5) ).Dump();
}