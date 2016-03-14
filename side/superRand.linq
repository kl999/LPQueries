<Query Kind="Program" />

void Main()
{
	List<double> buf = new List<double>();
	rand rd = new rand();
	
	for(int i = 0; i < 1000; i++)
	{
		//buf.Add(ret());
		buf.Add(rd.superRand());
	}
	
	buf.Dump()
		.Average().Dump("AVG");
	
	//buf.OrderBy(i => i).Dump();
	
	int[] ct = new int[10];
	buf.Select(i => { ct[(int)(i * 10)]++; return 0; }).ToArray();
	ct.Dump("Distribution");
	
	ct = new int[10];
	buf
	.Select((i, j) => 
	{
		if(j < buf.Count - 1)
		{
			return Math.Abs(i - buf[j + 1]);
		}
		return 0;
	})
	.Select(i => { ct[(int)(i * 10)]++; return 0; }).ToArray();
	ct.Dump("Distance between neighbours");
}

class rand
{
	Random random = new Random(DateTime.Now.Minute);

	double ret()
	{
		var rand = System.Security.Cryptography.RandomNumberGenerator.Create();
		/*byte[] buf = new byte[4];
		rand.GetBytes(buf);
		int i = 0;
		
		foreach(byte bt in buf)
		{
			i += (int)bt;
		}
		
		double rez = (double)i / (255 * buf.Length);
		
		return rez;*/
		
		byte[] b = new byte[4];
		rand.GetBytes(b);
		return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
	}
	
	public double superRand()
	{
		for(;;)
		{
				double i = ret();
				double j = random.NextDouble();
		
			if((int)(i * 100) == (int)(j * 100))
				return i;
		}
	}
}