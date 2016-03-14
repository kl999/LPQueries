<Query Kind="Program" />

void Main()
{
	for(en o = (en)1; (int)o < 15; o = (en)((int)o + 1))
	{
		o.Dump();
	}
}

[Flags]
enum en
{
	hello = 1,
	goodby = 2,
	dont_be_sik = 4,
	bye = 8,
	
	end_of_dialogue = goodby | dont_be_sik
}