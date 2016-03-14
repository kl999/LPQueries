<Query Kind="Statements" />

Random rand = new Random();
double avg = 0, avg2 = 0;
double count = 1000000000;

for(double i = 0; i < count; i++)
{
	double rnd = rand.Next(100);
	avg += rnd;
	
	if(avg2 > 0)
		avg2 = ((avg2 * i) + rnd) / (i + 1);
	else avg2 = rnd;
}

avg = avg / count;
avg.Dump();
avg2.Dump();

if(avg != avg2)
	("\n--------\n"
	+ string.Format("({0:0.### ### ### ### ### ### ### ### ### ### ###})", (avg - avg2))
	+ "\n-------------\n-----------\n-------\n").Dump();