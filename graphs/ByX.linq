<Query Kind="Program">
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	for(double i = 0; i < 1000; i++)
	{
		if(i < 200)
		{
			sqr(i).Dump();
		}
		else if(i < 500)
		{
			sqrt(i).Dump();
		}
		else if(i < 800)
		{
			sqr(i).Dump();
		}
		else
		{
			sqrt(i).Dump();
		}
	}
}

double sqr(double i)
{
	i = i / 1000;
	return ( i * i );
}

double sqrt(double i)
{
	return ( Math.Sqrt(i / 1000) );
}