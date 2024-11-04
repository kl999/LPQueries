<Query Kind="Statements" />

int aStat = 100,
	bStat = 99;

var rand = new Random();

int aScore = 0, bScore = 0,
	sampleSize = 100000;

var log = new List<string>();

for(int i = 0; i < sampleSize; i++)
{
	var a = rand.Next(aStat);
	var b = rand.Next(bStat);
	
	var result = a > b;
	
	log.Add($"{a}/{aStat} vs {b}/{bStat}: {result}");
	
	if(result) aScore++; else bScore++;
}

aScore.Dump("A Score");
bScore.Dump("B Score");

$"{aScore / (sampleSize / 100M)} %".Dump();

log.Dump();
