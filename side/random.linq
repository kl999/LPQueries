<Query Kind="Statements">
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

Random rand = new Random(DateTime.Now.Millisecond);

int times = 100000, iter = 1000;

object locker = new object();

double[] tRez = new double[iter];

int count = 0;

Parallel.For(0, iter, (i) => 
{
	double[] buf = new double[times];
	for(int j = 0; j < times; j++)
	{
		lock(locker)
			buf[j] = rand.Next(100);
	}
	
	double avg = 0;
	for(int j = 0; j < times; j++)
	{
		avg += buf[j];
	}
	avg = avg / times;
	
	tRez[i] = avg;
	
	Interlocked.Increment(ref count);
	count.Dump();
});

//tRez.Dump();

List<double[]> rez = new List<double[]>();
//rez.Add(new double[] {0, 0});

foreach(int num in tRez)
{
	bool found = false;
	
	for(int i = 0; i < rez.Count; i++)
	{
		if(rez[i][0] == num)
		{
			found = true;
			rez[i][1]++;
		}
	}
	
	if(!found)
	{
		rez.Add(new double[] {num, 1});
	}
}

rez.OrderBy(i => i[0]).Dump();

rez.OrderBy(i => i[1]).Dump();