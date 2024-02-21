<Query Kind="Statements" />

var rand = new Random();

int aScore = 0, bScore = 0,
	sampleSize = 100000;

var log = new List<string>();

for(int i = 0; i < sampleSize; i++)
{
	var a = rand.Next(300);
	var b = rand.Next(150);
	
	var result = a > b;
	
	log.Add($"{a}/10 vs {b}/5: {result}");
	
	if(result) aScore++; else bScore++;
}

aScore.Dump("A Score");
bScore.Dump("B Score");

$"{bScore / (sampleSize / 100M)} %".Dump();

log.Dump();
