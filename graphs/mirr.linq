<Query Kind="Program">
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	List<double> LstSqr = new List<double>();
	List<double> LstSqrt = new List<double>();

	for(int i = 0; i < 1000; i++)
	{
		LstSqr.Add( sqr(i) );
		LstSqrt.Add( sqrt(i) );
	}
	
	LstSqr.Dump();
	
	"eeeeeeeeeeeeee".Dump();
	
	LstSqrt.Dump();
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