<Query Kind="Statements" />

Random rand = new Random();

List<int> inLst = new List<int>();

for(int i = 0; i < 1000; i++)
{
	inLst.Add(rand.Next(100));
}

int num = 0;

inLst.Where( o => 
	++num == inLst.Where( x => { bool a = x % 2 == ++num % 2; --num; return a; } ).ToList()[num]  ).Dump();